namespace ApiCriminalidade.Models
{
    public class IndMedio
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public decimal Valor { get; set; }

        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        
    }
}
