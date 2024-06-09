using ApiCriminalidade.Models;
using Microsoft.Data.SqlClient;

namespace ApiCriminalidade.Repositorys.Interfaces
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
