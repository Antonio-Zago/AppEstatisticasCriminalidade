using ApiCriminalidade.Models;
using ApiCriminalidade.Pagination;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IOcorrenciaRepository
    {
        Task<IEnumerable<Ocorrencia>> GetAll();

        Task<Ocorrencia> GetById(int id);

        Ocorrencia Post(Ocorrencia ocorrencia);

        Ocorrencia Update(Ocorrencia ocorrencia);

        Ocorrencia Delete(Ocorrencia ocorrencia);

    }
}
