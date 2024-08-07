﻿using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProcessoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Processo> GetAll()
        {
            return _appDbContext.Processos;
        }

        public Processo GetById(int id)
        {
            return _appDbContext.Processos.Where(x => x.Id == id).FirstOrDefault();
        }

        public Processo Post(Processo entidade)
        {
            _appDbContext.Processos.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public Processo Update(Processo entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Processo Delete(Processo entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
