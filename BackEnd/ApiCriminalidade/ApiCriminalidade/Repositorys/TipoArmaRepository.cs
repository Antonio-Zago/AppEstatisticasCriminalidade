using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Repositorys
{
    public class TipoArmaRepository : ITipoArmaRepository
    {
        private readonly AppDbContext _appDbContext;

        public TipoArmaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TipoArma> GetAll()
        {
            return _appDbContext.TipoArmas;
        }

        public TipoArma GetById(int id)
        {
            return _appDbContext.TipoArmas.Where(x => x.Id == id).FirstOrDefault();
        }

        public TipoArma Post(TipoArma entidade)
        {
            _appDbContext.TipoArmas.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public TipoArma Update(TipoArma entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public TipoArma Delete(TipoArma entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
