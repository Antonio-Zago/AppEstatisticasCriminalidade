
namespace ApiCriminalidade.Domain.Entities
{
    public sealed class Usuario : Entity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public List<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}
