using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IIndOcorrenciaService
    {
        IEnumerable<IndOcorrencia> Add(IFormFile file);
        IEnumerable<IndOcorrencia> GetAll();

    }
}
