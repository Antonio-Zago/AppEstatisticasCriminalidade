using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IIndRouboRepository
    {
        IEnumerable<IndRoubo> GetAll();

        IndRoubo GetById(int id);

        IndRoubo Post(IndRoubo entidade);

        IndRoubo Update(IndRoubo entidade);

        IndRoubo Delete(IndRoubo entidade);
    }
}
