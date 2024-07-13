using ApiCriminalidade.Models;
using ApiCriminalidade.Pagination;

namespace ApiCriminalidade.Dtos
{
    public class OcorrenciaDto
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataHora { get; set; }

        public bool CadastrouBoletimOcorrencia { get; set; }

        public TipoOcorrencia TipoOcorrencia { get; set; }


    }
}
