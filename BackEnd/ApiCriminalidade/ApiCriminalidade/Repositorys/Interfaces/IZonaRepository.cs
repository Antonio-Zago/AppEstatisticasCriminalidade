using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IZonaRepository
    {
        IEnumerable<Zona> GetAll();

        Zona GetById(int id);

        Zona Post(Zona entidade);

        Zona Update(Zona entidade);

        Zona Delete(Zona entidade);

        IEnumerable<Zona> GetByIds(IEnumerable<int> ids);
    }
}
