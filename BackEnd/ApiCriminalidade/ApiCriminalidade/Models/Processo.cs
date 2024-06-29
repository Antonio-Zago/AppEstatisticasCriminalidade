namespace ApiCriminalidade.Models
{
    public class Processo
    {
        public int Id { get; set; }

        public TipoProcesso Tipo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExecucao { get; set; }

        public StatusProcesso StatusAtual { get; set; }
    }
}
