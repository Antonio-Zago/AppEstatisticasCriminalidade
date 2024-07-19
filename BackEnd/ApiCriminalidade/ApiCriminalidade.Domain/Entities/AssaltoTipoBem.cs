using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class AssaltoTipoBem : Entity
    {
        public int AssaltoId { get; set; }

        public Assalto Assalto { get; set; }

        public int TipoBemId { get; set; }

        public TipoBem TipoBem { get; set; }

        
    }
}
