
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IProcessoService
    {
        IEnumerable<Processo> GetAll();

        Processo GetById(int id);

        Processo Post(Processo form);

        Processo? Delete(int id);
    }
}
