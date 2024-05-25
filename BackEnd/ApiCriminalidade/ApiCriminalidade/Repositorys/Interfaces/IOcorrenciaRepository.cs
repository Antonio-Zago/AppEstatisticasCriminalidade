using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IOcorrenciaRepository
    {
        IEnumerable<Ocorrencia> GetAll();
    }
}
