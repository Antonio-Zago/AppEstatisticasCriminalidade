using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Dtos
{
    public class IndMedioDto
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public decimal Valor { get; set; }

        public int CidadeId { get; set; }
    }
}
