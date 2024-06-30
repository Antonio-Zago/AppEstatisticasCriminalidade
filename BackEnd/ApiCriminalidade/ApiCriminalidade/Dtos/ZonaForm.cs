namespace ApiCriminalidade.Dtos
{
    public class ZonaForm
    {
        public decimal LatitudeCentral { get; set; }

        public decimal LongitudeCentral { get; set; }

        public decimal Raio { get; set; }

        public bool Ativo { get; set; }

        public int CidadeId { get; set; }
    }
}
