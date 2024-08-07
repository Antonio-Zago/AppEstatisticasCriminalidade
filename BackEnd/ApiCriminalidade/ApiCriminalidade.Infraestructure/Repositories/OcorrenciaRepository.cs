﻿
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public OcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAll()
        {
            return await _context.Ocorrencias.ToListAsync();
        }

        public async Task<Ocorrencia> GetById(int id)
        {
            return await _context.Ocorrencias.Where(a => a.Id == id).FirstOrDefaultAsync();
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

    }
}
