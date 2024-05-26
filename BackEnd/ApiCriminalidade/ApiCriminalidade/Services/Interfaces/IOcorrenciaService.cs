using ApiCriminalidade.Dtos;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IOcorrenciaService
    {
        IEnumerable<OcorrenciaDto> GetAll();

        OcorrenciaDto GetById(int id);

        OcorrenciaDto Post(OcorrenciaForm form);

        OcorrenciaDto? Update(int id, OcorrenciaForm form);

        OcorrenciaDto? Delete(int id);
    }
}
