
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class AssaltoRepository : IAssaltoRepository
    {
        private readonly AppDbContext _context;

        public AssaltoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assalto>> GetAll()
        {
            return await _context.Assaltos.Include(a => a.AssaltosTipoBens).ToListAsync() ;
        }

        public async  Task<Assalto> GetById(int id)
        {
            return await _context.Assaltos.Where(a => a.Id == id).Include(a => a.AssaltosTipoBens).FirstOrDefaultAsync();
        }

        public Assalto Post(Assalto assalto)
        {
            _context.Assaltos.Add(assalto);
            _context.SaveChanges();
            return assalto;
        }

        public Assalto Update(Assalto assalto)
        {
            _context.Entry(assalto).State = EntityState.Modified;
            _context.SaveChanges();

            return assalto;
        }

        public Assalto Delete(Assalto assalto)
        {
            _context.Remove(assalto);
            _context.SaveChanges();

            return assalto;
        }
    }
}
