using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IOcorrenciaMapper
    {
        OcorrenciaDto ToDto(Ocorrencia ocorrencia);

        Ocorrencia ToOcorrencia(OcorrenciaForm form);
    }
}
