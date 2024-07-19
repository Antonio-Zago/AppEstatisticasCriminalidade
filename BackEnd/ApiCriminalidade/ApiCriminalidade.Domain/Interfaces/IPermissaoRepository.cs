

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface IPermissaoRepository
    {
        IEnumerable<Permissao> GetAll();

        Permissao GetById(int id);

        Permissao Post(Permissao entidade);

        Permissao Update(Permissao entidade);

        Permissao Delete(Permissao entidade);

        Permissao? FindPermissaoByName(string nome);
    }
}
