namespace ApiCriminalidade.Models
{
    public class TipoBem
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<AssaltoTipoBem> AssaltosTipoBens { get; set; }

        public IEnumerable<RouboTipoBem> RoubosTipoBens { get; set; }
    }
}
