using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface ITipoArmaRepository
    {
        IEnumerable<TipoArma> GetAll();

        TipoArma GetById(int id);

        TipoArma Post(TipoArma entidade);

        TipoArma Update(TipoArma entidade);

        TipoArma Delete(TipoArma entidade);
    }
}
