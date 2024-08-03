using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Dtos
{
    public class IndFurtoDto
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public DateTime DataAgendamento { get; set; }

        public decimal IndiceFurto { get; set; }

        public bool Ativo { get; set; }


        public int ZonaId { get; set; }

        public decimal LatitudeCentral { get; set; }

        public decimal LongitudeCentral { get; set; }

        public decimal Raio { get; set; }

        public decimal Media { get; set; }

        public decimal MediaMaxima { get; set; }
    }
}
