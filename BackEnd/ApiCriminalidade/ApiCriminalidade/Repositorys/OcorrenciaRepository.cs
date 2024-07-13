using ApiCriminalidade.Context;
using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;
using ApiCriminalidade.Pagination;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;

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

        public Ocorrencia GetById(int id)
        {
            return _context.Ocorrencias.Where(a => a.Id == id).FirstOrDefault();
        }

        public Ocorrencia Post(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            _context.SaveChanges();
            return ocorrencia;
        }

        public Ocorrencia Update(Ocorrencia ocorrencia)
        {
            _context.Entry(ocorrencia).State = EntityState.Modified;
            _context.SaveChanges();

            return ocorrencia;
        }

        public Ocorrencia Delete(Ocorrencia ocorrencia)
        {
            _context.Remove(ocorrencia);
            _context.SaveChanges();

            return ocorrencia;
        }

        public IQueryable<Ocorrencia> GetAllQueryable()
        {

            return GetAll().AsQueryable();
        }
    }
}
