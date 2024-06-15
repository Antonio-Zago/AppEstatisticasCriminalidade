namespace ApiCriminalidade.Models
{
    public class IndOcorrencia
    {
        public int Id { get; set; }

        public string NumBo { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public IndTipoOcorrencia Tipo { get; set; }

        public string Cidade { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

    }
}
