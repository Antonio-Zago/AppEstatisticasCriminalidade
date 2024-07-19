

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Pagination;
using ApiCriminalidade.Application.Pagination.Filtros;
using X.PagedList;

namespace ApiCriminalidade.Application.Interfaces
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
