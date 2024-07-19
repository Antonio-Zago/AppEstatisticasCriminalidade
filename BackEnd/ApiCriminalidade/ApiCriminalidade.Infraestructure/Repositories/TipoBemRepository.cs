using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class TipoBemRepository : ITipoBemRepository
    {
        private readonly AppDbContext _appDbContext;

        public TipoBemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TipoBem> GetAll()
        {
            return _appDbContext.TipoBens;
        }

        public TipoBem GetById(int id)
        {
            return _appDbContext.TipoBens.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<TipoBem> GetByIds(IEnumerable<int> ids)
        {
            return _appDbContext.TipoBens.Where(x => ids.Contains(x.Id));
        }

        public TipoBem Post(TipoBem entidade)
        {
            _appDbContext.TipoBens.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public TipoBem Update(TipoBem entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public TipoBem Delete(TipoBem entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
