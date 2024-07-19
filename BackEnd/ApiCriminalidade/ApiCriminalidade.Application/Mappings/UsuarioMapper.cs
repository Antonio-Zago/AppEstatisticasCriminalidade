

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Helpers;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
{
    public class UsuarioMapper : IUsuarioMapper
    {
        public UsuarioDto ToDto(Usuario entidade)
        {
            return new UsuarioDto
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Email = entidade.Email,
                Senha = entidade.Senha,
                UsuarioPermissoes = entidade.UsuarioPermissoes,
                RefreshToken = entidade.RefreshToken,
                RefreshTokenExpiryTime = entidade.RefreshTokenExpiryTime
            };
        }

        public Usuario ToEntidade(RegisterForm form)
        {
            return new Usuario
            {
                Email = form.Email,
                Senha = form.Senha.GerarHash(),
                Nome = form.Nome,
                Cpf = form.Cpf
            };
        }
    }
}
