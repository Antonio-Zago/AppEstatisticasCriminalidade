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
    public class IndMedioMapper : IIndMedioMapper
    {
        public IndMedioDto ToDto(IndMedio entidade)
        {
            return new IndMedioDto
            {
                Id = entidade.Id,
                DataCadastro = entidade.DataCadastro,
                Valor = entidade.Valor,
                CidadeId = entidade.CidadeId
            };
        }
    }
}
