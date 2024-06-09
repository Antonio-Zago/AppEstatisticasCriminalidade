namespace ApiCriminalidade.Models
{
    public class AssaltoTipoBem
    {
        public int AssaltoId { get; set; }

        public Assalto Assalto { get; set; }

        public int TipoBemId { get; set; }

        public TipoBem TipoBem { get; set; }
    }
}
