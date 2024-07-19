
namespace ApiCriminalidade.Domain.Entities
{
    public sealed class Cidade : Entity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Area { get; set; }

        public IEnumerable<IndMedio> IndMedios { get; set; }
        public IEnumerable<Zona> Zonas { get; set; }

        
    }
}
