using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Repositorys
{
    public class AssaltoRepository : IAssaltoRepository
    {
        private readonly AppDbContext _context;

        public AssaltoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Assalto> GetAll()
        {
            return _context.Assaltos.Include(a => a.AssaltosTipoBens) ;
        }

        public Assalto GetById(int id)
        {
            return _context.Assaltos.Where(a => a.Id == id).Include(a => a.AssaltosTipoBens).FirstOrDefault();
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
