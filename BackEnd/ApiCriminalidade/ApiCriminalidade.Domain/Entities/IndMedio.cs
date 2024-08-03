using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class IndMedio : Entity
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorMaximo { get; set; }

        public IndTipoOcorrencia Tipo { get; set; }

        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        
    }
}
