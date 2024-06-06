namespace ApiCriminalidade.Dtos
{
    public class AssaltoForm
    {
        public int QuantidadeAgressores { get; set; }

        public bool PossuiArma { get; set; }

        public int OcorrenciaId { get; set; }

        public int TipoArmaId { get; set; }
    }
}
