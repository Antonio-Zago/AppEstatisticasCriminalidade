

using ApiCriminalidade.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IIndOcorrenciaService
    {
        IEnumerable<IndOcorrencia> Add(IFormFile file);
        IEnumerable<IndOcorrencia> GetAll();


    }
}
