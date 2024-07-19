

using ApiCriminalidade.Application.Dtos;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IZonaService
    {
        IEnumerable<ZonaDto> GetAll();

        ZonaDto GetById(int id);

        ZonaDto Post(ZonaForm form);

        ZonaDto? Delete(int id);

        ZonaDto? Update(int id, ZonaForm form);
    }
}
