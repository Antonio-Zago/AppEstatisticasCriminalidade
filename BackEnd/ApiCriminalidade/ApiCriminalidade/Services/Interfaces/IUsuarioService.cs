using ApiCriminalidade.Dtos;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDto> GetAll();

        UsuarioDto GetById(int id);

        UsuarioDto Post(RegisterForm form);

        UsuarioDto? Update(int id, UsuarioForm form);

        UsuarioDto? Delete(int id);

        UsuarioDto? FindByEmail(string email);

        bool CheckPassword(string senhaForm, string senha);
        UsuarioDto? UpdateRefreshToken(int id, UsuarioDto dto);

        List<string> ValidarUsuarioJaExistente(RegisterForm form);

        UsuarioDto? FindByNome(string nome);

        UsuarioDto AddToRole(string email, int roleId);
    }
}
