using ApiCriminalidade.Context;
using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Repositorys
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly AppDbContext _appDbContext;

        public PermissaoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Permissao> GetAll()
        {
            return _appDbContext.Permissoes;
        }

        public Permissao GetById(int id)
        {
            return _appDbContext.Permissoes.Where(x => x.Id == id).FirstOrDefault();
        }

        public Permissao Post(Permissao entidade)
        {
            _appDbContext.Permissoes.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public Permissao Update(Permissao entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Permissao Delete(Permissao entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Permissao? FindPermissaoByName(string nome)
        {
            return _appDbContext.Permissoes.Where(a => a.Nome == nome).FirstOrDefault();
        }

    }
}
