using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;

namespace ApiCriminalidade.Repositorys
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public OcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ocorrencia> GetAll()
        {
            return _context.Ocorrencias;
        }
    }
}
