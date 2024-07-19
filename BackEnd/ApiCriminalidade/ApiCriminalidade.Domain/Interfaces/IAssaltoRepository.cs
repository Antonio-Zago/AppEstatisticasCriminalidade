

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
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
