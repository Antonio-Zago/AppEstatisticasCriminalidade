using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class ZonaRepository : IZonaRepository
    {
        private readonly AppDbContext _appDbContext;

        public ZonaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Zona> GetAll()
        {
            return _appDbContext.Zonas;
        }

        public Zona GetById(int id)
        {
            return _appDbContext.Zonas.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Zona> GetByIds(IEnumerable<int> ids)
        {
            return _appDbContext.Zonas.Where(x => ids.Contains(x.Id));
        }

        public Zona Post(Zona entidade)
        {
            _appDbContext.Zonas.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public Zona Update(Zona entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Zona Delete(Zona entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
