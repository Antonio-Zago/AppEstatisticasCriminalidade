
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
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
