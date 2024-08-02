using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Mappings
{
    public class IndFurtoMapper : IIndFurtoMapper
    {
        public IndFurtoDto ToDto(IndFurto entidade)
        {
            return new IndFurtoDto
            {
                Id = entidade.Id,
                Ativo = entidade.Ativo,
                DataAgendamento = entidade.DataAgendamento,
                DataFim = entidade.DataFim,
                DataInicio = entidade.DataInicio,
                IndiceFurto = entidade.IndiceFurto,
                ZonaId = entidade.ZonaId,
                LatitudeCentral = entidade.Zona.LatitudeCentral,
                LongitudeCentral = entidade.Zona.LongitudeCentral,
                Raio = entidade.Zona.Raio
            };
        }

    }
}
