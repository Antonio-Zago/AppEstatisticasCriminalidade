using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class IndFurto :Entity
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public DateTime DataAgendamento { get; set; }

        public decimal IndiceFurto { get; set; }

        public bool Ativo { get; set; }


        public Zona? Zona { get; set; }

        public int ZonaId { get; set; }
    }
}
