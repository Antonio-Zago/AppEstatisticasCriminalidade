using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
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
