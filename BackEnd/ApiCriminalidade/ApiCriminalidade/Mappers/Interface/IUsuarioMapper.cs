using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IUsuarioMapper
    {
        UsuarioDto ToDto(Usuario Entidade);

        Usuario ToEntidade(RegisterForm form);
    }
}
