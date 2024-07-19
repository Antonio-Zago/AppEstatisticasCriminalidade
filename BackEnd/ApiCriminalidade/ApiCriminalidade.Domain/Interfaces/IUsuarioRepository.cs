

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();

        Usuario GetById(int id);

        Usuario Post(Usuario entidade);

        Usuario Update(Usuario entidade);

        Usuario Delete(Usuario entidade);

        Usuario? FindByEmail(string email);

        List<string> ValidarUsuarioJaExistente(RegisterForm form);

        Usuario? FindByNome(string nome);
    }

}
