using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class RouboTipoBem : Entity
    {
        public int RouboId { get; set; }

        public Roubo Roubo { get; set; }

        public int TipoBemId { get; set; }

        public TipoBem TipoBem { get; set; }


    }
}
