using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IIndAssaltoService
    {
        IEnumerable<IndRoubo> GetAll();

        IndRoubo GetById(int id);

        IndRoubo Post(IndRoubo form);


        IndRoubo? Delete(int id);
    }
}
