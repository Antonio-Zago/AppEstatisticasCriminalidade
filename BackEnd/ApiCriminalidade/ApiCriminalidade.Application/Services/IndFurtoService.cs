using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Helpers;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Services
{
    public class IndFurtoService : IIndFurtoService
    {
        private readonly IIndFurtoRepository _repository;

        private readonly IIndFurtoMapper _mapper;

        private readonly IQuery _query;


        public IndFurtoService(IIndFurtoRepository repository, IIndFurtoMapper mapper, IQuery query)
        {
            _repository = repository;
            _mapper = mapper;
            _query = query;
        }

        public IEnumerable<IndFurtoDto> GetAll()
        {

            var listaDtos = new List<IndFurtoDto>();

            var sql = @"SELECT A.ID, A.DATAINICIO, A.DATAFIM, A.DATAAGENDAMENTO,A.INDICEFURTO, A.ATIVO, A.ZONAID, B.LATITUDECENTRAL, B.LONGITUDECENTRAL, B.RAIO, C.VALOR MEDIA, C.VALORMAXIMO MEDIAMAXIMA
                        FROM INDFURTOS A
                        INNER JOIN ZONAS B ON A.ZONAID = B.ID
                        INNER JOIN INDMEDIOS C ON C.CIDADEID = B.CIDADEID
                        WHERE C.TIPO = @TIPO
                        AND A.DATAFIM IS NULL
                        AND C.DATAFIM IS NULL";

            var entidades = _query.ExecuteReader(sql, ["ID", "DATAINICIO", "DATAFIM", "DATAAGENDAMENTO", "INDICEFURTO", "ATIVO", "ZONAID", "LATITUDECENTRAL", "LONGITUDECENTRAL", "RAIO", "MEDIA", "MEDIAMAXIMA"], [new SqlParameter("TIPO", IndTipoOcorrencia.Furto)]);



            foreach (var entidade in entidades)
            {
                var dto = new IndFurtoDto();
                dto.Id = int.Parse(entidade["ID"]);
                dto.DataInicio =  DateTime.Parse(entidade["DATAINICIO"]);
                dto.DataFim = string.IsNullOrEmpty(entidade["DATAFIM"]) ? null : DateTime.Parse(entidade["DATAFIM"]);
                dto.DataAgendamento = DateTime.Parse(entidade["DATAAGENDAMENTO"]);
                dto.IndiceFurto = decimal.Parse(entidade["INDICEFURTO"]);
                dto.Ativo = bool.Parse(entidade["ATIVO"]);
                dto.ZonaId = int.Parse(entidade["ZONAID"]);
                dto.LatitudeCentral = decimal.Parse(entidade["LATITUDECENTRAL"]);
                dto.LongitudeCentral = decimal.Parse(entidade["LONGITUDECENTRAL"]);
                dto.Raio = decimal.Parse(entidade["RAIO"]);
                dto.Media = decimal.Parse(entidade["MEDIA"]);
                dto.MediaMaxima = decimal.Parse(entidade["MEDIAMAXIMA"]);

                listaDtos.Add(dto);
            }

            return listaDtos;

        }
    }
}
