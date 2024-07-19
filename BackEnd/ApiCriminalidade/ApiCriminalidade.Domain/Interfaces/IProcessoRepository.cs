

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface IProcessoRepository
    {
        IEnumerable<Processo> GetAll();

        Processo GetById(int id);

        Processo Post(Processo entidade);

        Processo Update(Processo entidade);

        Processo Delete(Processo entidade);
    }
}
