

using ApiCriminalidade.Application.Dtos;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface ITipoArmaService
    {
        IEnumerable<TipoArmaDto> GetAll();

        TipoArmaDto GetById(int id);

        TipoArmaDto Post(TipoArmaForm form);

        TipoArmaDto? Update(int id, TipoArmaForm form);

        TipoArmaDto? Delete(int id);
    }
}
