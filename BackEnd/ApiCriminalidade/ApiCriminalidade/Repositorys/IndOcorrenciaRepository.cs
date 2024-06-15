using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;

namespace ApiCriminalidade.Repositorys
{
    public class IndOcorrenciaRepository : IIndOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public IndOcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IndOcorrencia> Add(List<IndOcorrencia> indOcorrencias)
        {
            _context.BulkInsert(indOcorrencias);
            return indOcorrencias;
        }

        public IEnumerable<IndOcorrencia> GetAll()
        {
            
            return _context.IndOcorrencias;
        }
    }
}
