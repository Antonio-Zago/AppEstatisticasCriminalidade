namespace ApiCriminalidade.Models
{
    public class RouboTipoBem
    {
        public int RouboId { get; set; }

        public Roubo Roubo { get; set; }

        public int TipoBemId { get; set; }

        public TipoBem TipoBem { get; set; }
    }
}
