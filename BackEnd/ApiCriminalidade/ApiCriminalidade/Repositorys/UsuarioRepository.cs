using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Repositorys
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

        public List<string> FindByEmailOrCpf(string email, string cpf)
        {
            List<string> retorno = new List<string>();
            var usuarioEmail = _appDbContext.Usuarios.Where(a => a.Email == email).FirstOrDefault();
            if (usuarioEmail != null)
            {
                retorno.Add("Email já em uso");
            }
            var usuarioCpf = _appDbContext.Usuarios.Where(a => a.Cpf == cpf).FirstOrDefault();
            if (usuarioCpf != null)
            {
                retorno.Add("Cpf já em uso");
            }

            return retorno;
        }
    }
}
