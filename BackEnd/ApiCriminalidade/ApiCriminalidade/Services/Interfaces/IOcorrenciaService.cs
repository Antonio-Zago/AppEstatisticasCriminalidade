using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IOcorrenciaService
    {
        IEnumerable<Ocorrencia> GetAll();
    }
}
