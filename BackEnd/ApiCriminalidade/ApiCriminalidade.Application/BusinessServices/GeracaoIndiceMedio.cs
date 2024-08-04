using ApiCriminalidade.Application.Helpers;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.BusinessServices
{
    public class GeracaoIndiceMedio : IProcessoComponent
    {
        private readonly IQuery _query;

        public GeracaoIndiceMedio(IQuery query)
        {
            _query = query;
        }
        public IProcessoComponent Create()
        {
            return this;
        }

        public void Run()
        {
            var cidades = RetornarAreaTotalPorCidade();

            foreach (var cidade in cidades)
            {

                var zonas = RetornarZonasPorCidade(int.Parse(cidade["CIDADE"]));

                foreach (var zona in zonas)
                {
                    var mediaMininaRoubo = CalcularMediaMinima(double.Parse(zona["TOTALROUBOS"]) / double.Parse(cidade["AREATOTAL"])); //Area em Km²
                    var mediaMaximaRoubo = CalcularMediaMaxima(double.Parse(zona["TOTALROUBOS"]) / double.Parse(cidade["AREATOTAL"]));


                    var mediaMininaFurto = CalcularMediaMinima(double.Parse(zona["TOTALFURTOS"]) / double.Parse(cidade["AREATOTAL"]));
                    var mediaMaximaFurto = CalcularMediaMaxima(double.Parse(zona["TOTALFURTOS"]) / double.Parse(cidade["AREATOTAL"]));


                    FecharUltimoHistorico(int.Parse(cidade["CIDADE"]), IndTipoOcorrencia.Roubo);
                    CadastrarIndiceMedio(mediaMininaRoubo, mediaMaximaRoubo, int.Parse(cidade["CIDADE"]), IndTipoOcorrencia.Roubo);
                    FecharUltimoHistorico(int.Parse(cidade["CIDADE"]), IndTipoOcorrencia.Furto);
                    CadastrarIndiceMedio(mediaMininaFurto, mediaMaximaFurto, int.Parse(cidade["CIDADE"]), IndTipoOcorrencia.Furto);
                }
                
                
            }
        }


        private void FecharUltimoHistorico(int cidadeId, IndTipoOcorrencia tipo)
        {
            var sql = @$"UPDATE INDMEDIOS
                        SET DATAFIM = @DATAFIM
                        WHERE CIDADEID = @CIDADEID
                        AND DATAFIM IS NULL
                        AND TIPO = @TIPO";

            _query.ExecuteNonQuery(sql, [new SqlParameter("DATAFIM",DateTime.Now),
                                       new SqlParameter("CIDADEID", cidadeId),
                                            new SqlParameter("TIPO", tipo)]);
        }

        private double CalcularMediaMinima(double media) 
        {
            return media - (20.0 / 100.0 * media);
        }
        private double CalcularMediaMaxima(double media)
        {
            return media + (20.0 / 100.0 * media);
        }


        private void CadastrarIndiceMedio(double indice, double indiceMaximo, int cidadeId, IndTipoOcorrencia tipo)
        {
            var sql = @$"INSERT INTO INDMEDIOS(DATACADASTRO, VALOR, CIDADEID, TIPO, VALORMAXIMO)
                        VALUES (@DATACADASTRO,@VALOR,@CIDADEID, @TIPO, @VALORMAXIMO)";

            _query.ExecuteNonQuery(sql, [new SqlParameter("DATACADASTRO",DateTime.Now),
                                       new SqlParameter("VALOR", indice),
                                       new SqlParameter("CIDADEID", cidadeId),
                                       new SqlParameter("TIPO", tipo),
                                        new SqlParameter("VALORMAXIMO", indiceMaximo)]);
        }

        private List<Dictionary<string, string>> RetornarCidades()
        {
            var sql = @"SELECT C.AREA, C.ID CIDADE, INDFURTO.TOTALFURTO, INDROUBO.TOTALROUBO
                        FROM CIDADES C
						LEFT JOIN ( SELECT  COUNT(A.ID) TOTALFURTO, A.CIDADEID
									FROM INDOCORRENCIAS A
									WHERE A.TIPO = @TIPOFURTO
									GROUP BY CIDADEID) INDFURTO
									ON INDFURTO.CIDADEID = C.ID
                       LEFT JOIN ( SELECT  COUNT(A.ID) TOTALROUBO, A.CIDADEID
									FROM INDOCORRENCIAS A
									WHERE A.TIPO = @TIPOROUBO 
									GROUP BY CIDADEID) INDROUBO
									ON INDROUBO.CIDADEID = C.ID";

            return _query.ExecuteReader(sql, ["AREA", "CIDADE", "TOTALFURTO", "TOTALROUBO"], [new SqlParameter("TIPOFURTO", IndTipoOcorrencia.Furto), new SqlParameter("TIPOROUBO", IndTipoOcorrencia.Roubo)]);
        }

        private List<Dictionary<string, string>> RetornarAreaTotalPorCidade()
        {
            var sql = @"SELECT SUM(A.AREA) AREATOTAL, B.ID CIDADE
                        FROM ZONAS A
                        INNER JOIN CIDADES B ON A.CIDADEID = B.ID
                        GROUP BY B.ID";

            return _query.ExecuteReader(sql, ["AREATOTAL", "CIDADE"], null);
        }

        private List<Dictionary<string, string>> RetornarZonasPorCidade(int cidadeId)
        {
            var sql = @"SELECT SUM(B.QUANTIDADEFURTOS) TOTALFURTOS, SUM(C.QUANTIDADEROUBOS) TOTALROUBOS
                        FROM ZONAS A
                        INNER JOIN INDFURTOS B ON B.ZONAID = A.ID
                           AND B.DATAFIM IS NULL
                        INNER JOIN INDROUBOS C ON C.ZONAID = A.ID
                           AND C.DATAFIM IS NULL
                        WHERE A.CIDADEID = @CIDADE";

            return _query.ExecuteReader(sql, ["TOTALFURTOS", "TOTALROUBOS"], [new SqlParameter("CIDADE", cidadeId)]);
        }
    }
}
