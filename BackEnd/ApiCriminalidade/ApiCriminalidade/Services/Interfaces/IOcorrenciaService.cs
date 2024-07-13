using ApiCriminalidade.Dtos;
using ApiCriminalidade.Pagination;
using ApiCriminalidade.Pagination.Filtros;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IOcorrenciaService
    {
        IEnumerable<OcorrenciaDto> GetAll();

        OcorrenciaDto GetById(int id);

        OcorrenciaDto Post(OcorrenciaForm form);

        OcorrenciaDto? Update(int id, OcorrenciaForm form);

        OcorrenciaDto? Delete(int id);

        PagedList<OcorrenciaDto> GetWithPaginationParameters(GenericParameters parameters);

        PagedList<OcorrenciaDto> GetFiltroData(OcorrenciaFiltroData filtros);
    }
}
