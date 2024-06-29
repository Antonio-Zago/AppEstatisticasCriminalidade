using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IIndAssaltoRepository
    {
        IEnumerable<IndAssalto> GetAll();

        IndAssalto GetById(int id);

        IndAssalto Post(IndAssalto entidade);

        IndAssalto Update(IndAssalto entidade);

        IndAssalto Delete(IndAssalto entidade);
    }
}
