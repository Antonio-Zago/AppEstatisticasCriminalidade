using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    // sealed serve para dizer que está classe não pode ser herdada
    public sealed class Assalto : Entity
    {

        public int Id { get; set; }

        public int QuantidadeAgressores { get; set; }

        public bool PossuiArma { get; set; }

        public int OcorrenciaId { get; set; }

        public Ocorrencia? Ocorrencia { get; set; }

        public int TipoArmaId { get; set; }

        public TipoArma? TipoArma { get; set; }

        public IEnumerable<AssaltoTipoBem> AssaltosTipoBens { get; set; }

        
    }
}
