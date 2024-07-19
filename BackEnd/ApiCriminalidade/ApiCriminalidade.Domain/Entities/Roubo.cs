using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class Roubo : Entity
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }

        public Ocorrencia? Ocorrencia { get; set; }

        public IEnumerable<RouboTipoBem> RoubosTipoBens { get; set; }

    }
}
