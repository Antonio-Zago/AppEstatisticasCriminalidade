using System.ComponentModel.DataAnnotations;

namespace ApiCriminalidade.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataHora { get; set; }

        public bool CadastrouBoletimOcorrencia { get; set; }

        public TipoOcorrencia TipoOcorrencia { get; set; }

        public Assalto? Assalto { get; set; }
    }


}
