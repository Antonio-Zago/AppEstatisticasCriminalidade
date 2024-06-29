using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Repositorys
{
    public class IndAssaltoRepository : IIndAssaltoRepository
    {
        private readonly AppDbContext _appDbContext;

        public IndAssaltoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<IndAssalto> GetAll()
        {
            return _appDbContext.IndAssaltos;
        }

        public IndAssalto GetById(int id)
        {
            return _appDbContext.IndAssaltos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IndAssalto Post(IndAssalto entidade)
        {
            _appDbContext.IndAssaltos.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public IndAssalto Update(IndAssalto entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public IndAssalto Delete(IndAssalto entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
