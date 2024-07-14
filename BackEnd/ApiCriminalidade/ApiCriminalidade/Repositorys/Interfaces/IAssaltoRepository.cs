using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IAssaltoRepository
    {
        Task<IEnumerable<Assalto>> GetAll();

        Task<Assalto> GetById(int id);

        Assalto Post(Assalto ocorrencia);

        Assalto Update(Assalto ocorrencia);

        Assalto Delete(Assalto ocorrencia);
    }
}
