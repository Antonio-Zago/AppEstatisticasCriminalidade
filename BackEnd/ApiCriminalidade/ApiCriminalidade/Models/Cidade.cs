namespace ApiCriminalidade.Models
{
    public class Cidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Area { get; set; }

        public IEnumerable<IndMedio> IndMedios { get; set; }
        public IEnumerable<Zona> Zonas { get; set; }
    }
}
