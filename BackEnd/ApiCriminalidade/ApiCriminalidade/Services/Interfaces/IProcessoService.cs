using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IProcessoService
    {
        IEnumerable<Processo> GetAll();

        Processo GetById(int id);

        Processo Post(Processo form);

        Processo? Delete(int id);
    }
}
