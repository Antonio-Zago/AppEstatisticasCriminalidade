
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Dtos
{
    public class OcorrenciaForm
    {
        public string? Descricao { get; set; }

        public DateTime? DataHora { get; set; }

        public bool CadastrouBoletimOcorrencia { get; set; }

        public TipoOcorrencia TipoOcorrencia { get; set; }
    }
}
