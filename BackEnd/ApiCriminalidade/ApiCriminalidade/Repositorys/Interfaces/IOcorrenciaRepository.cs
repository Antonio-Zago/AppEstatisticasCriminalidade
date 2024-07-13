using ApiCriminalidade.Models;
using ApiCriminalidade.Pagination;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IOcorrenciaRepository
    {
        IEnumerable<Ocorrencia> GetAll();

        Ocorrencia GetById(int id);

        Ocorrencia Post(Ocorrencia ocorrencia);

        Ocorrencia Update(Ocorrencia ocorrencia);

        Ocorrencia Delete(Ocorrencia ocorrencia);

        IQueryable<Ocorrencia> GetAllQueryable();
    }
}
