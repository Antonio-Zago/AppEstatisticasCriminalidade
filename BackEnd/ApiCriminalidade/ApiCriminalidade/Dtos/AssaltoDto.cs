using ApiCriminalidade.Models;

namespace ApiCriminalidade.Dtos
{
    public class AssaltoDto
    {
        public int Id { get; set; }

        public int QuantidadeAgressores { get; set; }

        public bool PossuiArma { get; set; }

        public int OcorrenciaId { get; set; }

        public int TipoArmaId { get; set; }

    }
}
