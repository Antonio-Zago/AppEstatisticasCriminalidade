
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
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
