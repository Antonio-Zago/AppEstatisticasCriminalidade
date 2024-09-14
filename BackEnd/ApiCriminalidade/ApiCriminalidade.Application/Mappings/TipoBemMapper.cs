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
        public class TipoBemMapper : ITipoBemMapper
        {
            public TipoBemDto ToDto(TipoBem entidade)
            {
                return new TipoBemDto
                {
                    Id = entidade.Id,
                    Nome = entidade.Nome
                };
            }

            public TipoBem ToEntidade(TipoBemForm form)
            {
                return new TipoBem
                {
                    Nome = form.Nome
                };
            }
        }
}
