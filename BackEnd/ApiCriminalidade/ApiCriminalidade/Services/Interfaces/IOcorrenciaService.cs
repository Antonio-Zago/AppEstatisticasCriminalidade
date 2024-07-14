using ApiCriminalidade.Dtos;
using ApiCriminalidade.Pagination;
using ApiCriminalidade.Pagination.Filtros;
using X.PagedList;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IOcorrenciaService
    {
        Task<IEnumerable<OcorrenciaDto>> GetAll();

        Task<OcorrenciaDto> GetById(int id);

        OcorrenciaDto Post(OcorrenciaForm form);

        Task<OcorrenciaDto?> Update(int id, OcorrenciaForm form);

        Task<OcorrenciaDto?> Delete(int id);

        Task<IPagedList<OcorrenciaDto>> GetWithPaginationParameters(GenericParameters parameters);

        Task<IPagedList<OcorrenciaDto>> GetFiltroData(OcorrenciaFiltroData filtros);
    }
}
