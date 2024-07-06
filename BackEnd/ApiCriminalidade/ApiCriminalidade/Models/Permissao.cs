namespace ApiCriminalidade.Models
{
    public class Permissao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}
