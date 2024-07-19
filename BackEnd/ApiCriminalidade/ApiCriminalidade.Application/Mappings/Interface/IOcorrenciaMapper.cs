
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IOcorrenciaMapper
    {
        OcorrenciaDto ToDto(Ocorrencia ocorrencia);

        Ocorrencia ToOcorrencia(OcorrenciaForm form);
    }
}
