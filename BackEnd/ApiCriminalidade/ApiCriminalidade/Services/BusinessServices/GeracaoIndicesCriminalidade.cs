using ApiCriminalidade.Helpers;
using ApiCriminalidade.Models;
using ApiCriminalidade.Services;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiCriminalidade.Services.BusinessServices
{
    public class GeracaoIndicesCriminalidade : IProcessoComponent
    {
        private readonly IQuery _query;

        private decimal latitudeCentral;

        private decimal longitudeCentral;

        private decimal raio;

        private decimal area;

        private const string NomeTabelaIndiceRoubo = "INDROUBOS";

        private const string NomeTabelaIndiceFurto = "INDFURTOS";

        public GeracaoIndicesCriminalidade(IQuery query)
        {
            _query = query;
        }

        public IProcessoComponent Create()
        {
            return this;
        }

        public void Run()
        {
            var zonas = RetornarZonas();

            foreach (var zona in zonas)
            {
                latitudeCentral = decimal.Parse(zona["LATITUDECENTRAL"]);
                longitudeCentral = decimal.Parse(zona["LONGITUDECENTRAL"]);
                raio = decimal.Parse(zona["RAIO"]);
                area = decimal.Parse(zona["AREA"]);

                GerarIndiceRoubo(zona);

                GerarIndiceFurto(zona);


            }
        }

        private void GerarIndiceRoubo(Dictionary<string,string> zona)
        {
            var quantidadeOcorrenciasRoubo = RetornarQuantidadeDeOcorrencias(raio, latitudeCentral, longitudeCentral, IndTipoOcorrencia.Roubo);

            var indiceZona = RetornarIndiceZona(area, quantidadeOcorrenciasRoubo);

            FecharUltimoHistorico(int.Parse(zona["ID"]), NomeTabelaIndiceRoubo);
            CadastrarIndiceRoubo(indiceZona, int.Parse(zona["ID"]));
        }

        private void FecharUltimoHistorico(int zonaId, string nomeTabela)
        {
            var sql = @$"UPDATE {nomeTabela}
                        SET DATAFIM = @DATAFIM,
                        ATIVO = @ATIVO
                        WHERE ZONAID = @ZONAID
                        AND DATAFIM IS NULL";

            _query.ExecuteNonQuery(sql, [new SqlParameter("DATAFIM",DateTime.Now),
                                       new SqlParameter("ATIVO", false),
                                       new SqlParameter("ZONAID", zonaId),
                                       new SqlParameter("NOMETABELA", nomeTabela)]);
        }

        private void GerarIndiceFurto(Dictionary<string, string> zona)
        {
            var quantidadeOcorrenciasFurto = RetornarQuantidadeDeOcorrencias(raio, latitudeCentral, longitudeCentral, IndTipoOcorrencia.Furto);

            var indiceZona = RetornarIndiceZona(area, quantidadeOcorrenciasFurto);

            FecharUltimoHistorico(int.Parse(zona["ID"]), NomeTabelaIndiceFurto);
            CadastrarIndiceFurto(indiceZona, int.Parse(zona["ID"]));
        }


        private void CadastrarIndiceRoubo(decimal indice, int zonaId)
        {
            var sql = @$"INSERT INTO INDROUBOS(DATAINICIO, DATAAGENDAMENTO, INDICEASSALTO,ATIVO,ZONAID)
                        VALUES (@DATAINICIO,@DATAAGENDAMENTO,@INDICEASSALTO,@ATIVO,@ZONAID)";

            _query.ExecuteNonQuery(sql, [new SqlParameter("DATAINICIO",DateTime.Now),
                                       new SqlParameter("DATAAGENDAMENTO", DateTime.Now),
                                       new SqlParameter("INDICEASSALTO", indice),
                                       new SqlParameter("ATIVO", true),
                                       new SqlParameter("ZONAID", zonaId)]);
        }

        private void CadastrarIndiceFurto(decimal indice, int zonaId)
        {
            var sql = @$"INSERT INTO INDFURTOS(DATAINICIO, DATAAGENDAMENTO, INDICEFURTO,ATIVO,ZONAID)
                        VALUES (@DATAINICIO,@DATAAGENDAMENTO,@INDICEFURTO,@ATIVO,@ZONAID)";

            _query.ExecuteNonQuery(sql, [new SqlParameter("DATAINICIO",DateTime.Now),
                                       new SqlParameter("DATAAGENDAMENTO", DateTime.Now),
                                       new SqlParameter("INDICEFURTO", indice),
                                       new SqlParameter("ATIVO", true),
                                       new SqlParameter("ZONAID", zonaId)]);
        }


        //Tenho que dividir esse método para cada tipo de ocorrencia diferente
        private decimal RetornarIndiceZona(decimal area, int quantidadeOcorrencias)
        {
            return quantidadeOcorrencias / area;
        }

        private List<Dictionary<string,string>> RetornarZonas()
        {
            var sql = @"SELECT Z.ID,Z.LATITUDECENTRAL,Z.LONGITUDECENTRAL,Z.RAIO, I.VALOR, Z.AREA
                        FROM ZONAS Z
                        INNER JOIN CIDADES C ON C.ID = Z.CIDADEID
                        INNER JOIN INDMEDIOS I ON I.CIDADEID = C.ID";

            return _query.ExecuteReader(sql,["LATITUDECENTRAL", "LONGITUDECENTRAL", "RAIO", "VALOR", "ID", "AREA"], null);
        }


        //Tenho que dividir esse método para cada tipo de ocorrencia diferente
        private int RetornarQuantidadeDeOcorrencias(decimal raio, decimal latitudeCentral, decimal longitudeCentral, IndTipoOcorrencia tipo)
        {

            var sql = $@"SELECT DISTANCIA FROM
                            (
	                            SELECT (6371 *
			                            acos(
				                            cos(radians(@LATITUDECENTRAL)) *
				                            cos(radians(latitude)) *
				                            cos(radians(@LONGITUDECENTRAL) - radians(longitude)) +
				                            sin(radians(@LATITUDECENTRAL)) *
				                            sin(radians(latitude))
			                            )) AS DISTANCIA
	                            FROM INDOCORRENCIAS 
                                WHERE TIPO = @TIPO
                            ) A
                            WHERE DISTANCIA <= @RAIO";


            var ocorrenciasPorZona = _query.ExecuteReader(sql, ["DISTANCIA"], [new SqlParameter("LATITUDECENTRAL",latitudeCentral),
                                                                            new SqlParameter("LONGITUDECENTRAL", longitudeCentral),
                                                                            new SqlParameter("RAIO", raio),
                                                                            new SqlParameter("TIPO", tipo)]);

            return ocorrenciasPorZona.Count();
        }
    }
}
