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
    public class CidadeMapper : ICidadeMapper
    {
        public CidadeDto ToDto(Cidade entidade)
        {
            return new CidadeDto
            {
                Id = entidade.Id,
                Area = entidade.Area,
                Nome = entidade.Nome
            };
        }

        public Cidade ToEntidade(CidadeForm form)
        {
            return new Cidade
            {
                Id = form.Id,
                Area = form.Area,
                Nome = form.Nome
            };
        }
    }
}
