

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface ITipoBemRepository
    {
        IEnumerable<TipoBem> GetAll();

        TipoBem GetById(int id);

        TipoBem Post(TipoBem entidade);

        TipoBem Update(TipoBem entidade);

        TipoBem Delete(TipoBem entidade);

        IEnumerable<TipoBem> GetByIds(IEnumerable<int> ids);

    }

}
