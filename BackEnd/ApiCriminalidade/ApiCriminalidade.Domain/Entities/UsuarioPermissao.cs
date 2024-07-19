using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class UsuarioPermissao : Entity
    {
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int PermissaoId { get; set; }

        public Permissao Permissao { get; set; }
    }
}
