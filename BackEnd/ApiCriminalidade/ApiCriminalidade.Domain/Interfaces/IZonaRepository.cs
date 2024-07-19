

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
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
