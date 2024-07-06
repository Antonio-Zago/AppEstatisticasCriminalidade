using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();

        Usuario GetById(int id);

        Usuario Post(Usuario entidade);

        Usuario Update(Usuario entidade);

        Usuario Delete(Usuario entidade);

        Usuario? FindByEmail(string email);

        List<string> FindByEmailOrCpf(string email, string cpf);
    }
}
