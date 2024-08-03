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
            var cidades = RetornarCidades();

            foreach (var cidade in cidades)
            {

                var indiceMedioRoubo = decimal.Parse(cidade["TOTALROUBO"]) / decimal.Parse(cidade["AREA"]);
                var indiceMedioFurto = decimal.Parse(cidade["TOTALFURTO"]) / decimal.Parse(cidade["AREA"]);

                CadastrarIndiceMedio(indiceMedioRoubo, int.Parse(cidade["CIDADE"]),IndTipoOcorrencia.Roubo);
                CadastrarIndiceMedio(indiceMedioFurto, int.Parse(cidade["CIDADE"]), IndTipoOcorrencia.Furto);
            }
        }


        private void CadastrarIndiceMedio(decimal indice, int cidadeId, IndTipoOcorrencia tipo)
        {
            var sql = @$"INSERT INTO INDMEDIOS(DATACADASTRO, VALOR, CIDADEID, TIPO)
                        VALUES (@DATACADASTRO,@VALOR,@CIDADEID, @TIPO)";

            _query.ExecuteNonQuery(sql, [new SqlParameter("DATACADASTRO",DateTime.Now),
                                       new SqlParameter("VALOR", indice),
                                       new SqlParameter("CIDADEID", cidadeId),
                                       new SqlParameter("TIPO", tipo)]);
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
    }
}
