using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class IndRoubo : Entity
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public DateTime DataAgendamento { get; set; }

        public double IndiceAssalto { get; set; }

        public bool Ativo { get; set; }


        public Zona? Zona { get; set; }

        public int ZonaId { get; set; }

        public int QuantidadeRoubos { get; set; }


    }
}
