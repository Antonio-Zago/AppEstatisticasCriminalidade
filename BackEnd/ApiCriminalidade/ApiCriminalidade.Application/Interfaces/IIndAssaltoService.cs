
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IIndAssaltoService
    {
        IEnumerable<IndRoubo> GetAll();

        IndRoubo GetById(int id);

        IndRoubo Post(IndRoubo form);


        IndRoubo? Delete(int id);
    }
}
