using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class Processo : Entity
    {
        public int Id { get; set; }

        public TipoProcesso Tipo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataExecucao { get; set; }

        public StatusProcesso StatusAtual { get; set; }

        
    }
}
