using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class Permissao : Entity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<UsuarioPermissao> UsuarioPermissoes { get; set; }

    }
}
