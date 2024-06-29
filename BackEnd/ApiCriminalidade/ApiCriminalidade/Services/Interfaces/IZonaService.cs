using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IZonaService
    {
        IEnumerable<Zona> GetAll();

        Zona GetById(int id);

        Zona Post(Zona form);

        Zona? Delete(int id);
    }
}
