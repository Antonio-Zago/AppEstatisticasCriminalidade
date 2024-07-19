
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class IndRouboRepository : IIndRouboRepository
    {
        private readonly AppDbContext _appDbContext;

        public IndRouboRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<IndRoubo> GetAll()
        {
            return _appDbContext.IndRoubos;
        }

        public IndRoubo GetById(int id)
        {
            return _appDbContext.IndRoubos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IndRoubo Post(IndRoubo entidade)
        {
            _appDbContext.IndRoubos.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public IndRoubo Update(IndRoubo entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public IndRoubo Delete(IndRoubo entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
