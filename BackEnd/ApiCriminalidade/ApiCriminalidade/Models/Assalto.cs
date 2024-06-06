namespace ApiCriminalidade.Models
{
    public class Assalto
    {
        public int Id { get; set; }

        public int QuantidadeAgressores { get; set; }

        public bool PossuiArma { get; set; }

        public int OcorrenciaId { get; set; }

        public Ocorrencia? Ocorrencia { get; set; }

        public int TipoArmaId { get; set; }

        public TipoArma? TipoArma { get; set; }
    }
}
