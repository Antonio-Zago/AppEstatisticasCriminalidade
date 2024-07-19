using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _appDbContext.Usuarios;
        }

        public Usuario GetById(int id)
        {
            return _appDbContext.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Usuario> GetByIds(IEnumerable<int> ids)
        {
            return _appDbContext.Usuarios.Where(x => ids.Contains(x.Id));
        }

        public Usuario Post(Usuario entidade)
        {
            _appDbContext.Usuarios.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public Usuario Update(Usuario entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Usuario Delete(Usuario entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Usuario? FindByEmail(string email)
        {
            return _appDbContext.Usuarios.Include(u => u.UsuarioPermissoes).ThenInclude(up => up.Permissao).Where(a => a.Email == email).FirstOrDefault();
        }

        public Usuario? FindByNome(string nome)
        {
            return _appDbContext.Usuarios.Include(u => u.UsuarioPermissoes).ThenInclude(up => up.Permissao).Where(a => a.Nome == nome).FirstOrDefault();
        }

        public List<string> ValidarUsuarioJaExistente(RegisterForm form)
        {
            List<string> retorno = new List<string>();
            var usuarioEmail = _appDbContext.Usuarios.Where(a => a.Email == form.Email).FirstOrDefault();
            if (usuarioEmail != null)
            {
                retorno.Add("Email já em uso");
            }
            var usuarioCpf = _appDbContext.Usuarios.Where(a => a.Cpf == form.Cpf).FirstOrDefault();
            if (usuarioCpf != null)
            {
                retorno.Add("Cpf já em uso");
            }
            var usuarioNome= _appDbContext.Usuarios.Where(a => a.Nome == form.Nome).FirstOrDefault();
            if (usuarioCpf != null)
            {
                retorno.Add("Nome já em uso");
            }

            return retorno;
        }

    }
}
