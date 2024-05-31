using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IAssaltoRepository
    {
        IEnumerable<Assalto> GetAll();

        Assalto GetById(int id);

        Assalto Post(Assalto ocorrencia);

        Assalto Update(Assalto ocorrencia);

        Assalto Delete(Assalto ocorrencia);
    }
}
