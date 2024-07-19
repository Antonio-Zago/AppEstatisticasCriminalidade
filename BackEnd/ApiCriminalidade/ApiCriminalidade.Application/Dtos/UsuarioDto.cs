

using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public IEnumerable<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}
