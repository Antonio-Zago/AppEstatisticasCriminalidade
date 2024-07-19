

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IUsuarioMapper
    {
        UsuarioDto ToDto(Usuario Entidade);

        Usuario ToEntidade(RegisterForm form);
    }
}
