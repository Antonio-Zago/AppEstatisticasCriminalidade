namespace ApiCriminalidade.Application.Dtos
{
    public class AssaltoForm : OcorrenciaForm
    {
        public int QuantidadeAgressores { get; set; }

        public bool PossuiArma { get; set; }

        public int TipoArmaId { get; set; }

        public IEnumerable<int> TipoBens { get; set; }
    }
}
