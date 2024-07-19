using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class TipoArma : Entity
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public bool ArmaDeFogo { get; set; }

        public IEnumerable<Assalto>? Assaltos { get; set; }
    }
}
