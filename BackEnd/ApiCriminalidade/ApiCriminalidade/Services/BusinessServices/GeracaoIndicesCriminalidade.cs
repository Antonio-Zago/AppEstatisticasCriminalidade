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
using WokerService.Services.Interfaces;

namespace ApiCriminalidade.Services.BusinessServices
{
    public class GeracaoIndicesCriminalidade : IGeracaoIndiceCriminalidade
    {
        private readonly IQuery _query;

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
                var latitudeCentral = decimal.Parse(zona["LATITUDECENTRAL"]);
                var longitudeCentral = decimal.Parse(zona["LONGITUDECENTRAL"]);
                var raio = decimal.Parse(zona["RAIO"]);
                var area = decimal.Parse(zona["AREA"]);

                var quantidadeOcorrencias = RetornarQuantidadeDeOcorrencias(raio, latitudeCentral, longitudeCentral, TipoProcesso.GeracaoIndicesCriminalidade);

                
                //A aplicação mobile deve pegar o registro do indice da zona e comparar com o indice médio da cidade e plotar as zonas na tela
                var indiceZona = RetornarIndiceZona(area, quantidadeOcorrencias);

                //Fazer o método para inserir o registro na tabela de indices de assalto
                CadastrarIndice(indiceZona, int.Parse(zona["ID"]));
            }
        }


        private void CadastrarIndice(decimal indice, int zonaId)
        {
            var sql = @$"INSERT INTO INDASSALTOS(DATAINICIO, DATAAGENDAMENTO, INDICEASSALTO,ATIVO,ZONAID)
                        VALUES (@DATAINICIO,@DATAAGENDAMENTO,@INDICEASSALTO,@ATIVO,@ZONAID)";

            _query.ExecuteInsert(sql, [new SqlParameter("DATAINICIO",DateTime.Now),
                                       new SqlParameter("DATAAGENDAMENTO", DateTime.Now),
                                       new SqlParameter("INDICEASSALTO", indice),
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

            return _query.Execute(sql,["LATITUDECENTRAL", "LONGITUDECENTRAL", "RAIO", "VALOR", "ID", "AREA"], null);
        }


        //Tenho que dividir esse método para cada tipo de ocorrencia diferente
        private int RetornarQuantidadeDeOcorrencias(decimal raio, decimal latitudeCentral, decimal longitudeCentral, TipoProcesso tipo)
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


            var ocorrenciasPorZona = _query.Execute(sql, ["DISTANCIA"], [new SqlParameter("LATITUDECENTRAL",latitudeCentral),
                                                                            new SqlParameter("LONGITUDECENTRAL", longitudeCentral),
                                                                            new SqlParameter("RAIO", raio),
                                                                            new SqlParameter("TIPO", tipo)]);

            return ocorrenciasPorZona.Count();
        }
    }
}
