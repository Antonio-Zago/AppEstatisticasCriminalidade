using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class TipoBem : Entity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<AssaltoTipoBem> AssaltosTipoBens { get; set; }

        public IEnumerable<RouboTipoBem> RoubosTipoBens { get; set; }
    }
}
