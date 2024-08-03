using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class IndOcorrencia : Entity
    {
        public int Id { get; set; }

        public string NumBo { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public IndTipoOcorrencia Tipo { get; set; }


        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int? CidadeId { get; set; }

        public Cidade? Cidade { get; set; }


    }
}
