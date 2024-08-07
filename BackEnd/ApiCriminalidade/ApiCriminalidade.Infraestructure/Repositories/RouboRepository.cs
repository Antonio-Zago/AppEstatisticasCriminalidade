﻿using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class RouboRepository : IRouboRepository
    {
        private readonly AppDbContext _appDbContext;

        public RouboRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Roubo> GetAll()
        {
            return _appDbContext.Roubos.Include(a => a.RoubosTipoBens);
        }

        public Roubo GetById(int id)
        {
            return _appDbContext.Roubos.Where(x => x.Id == id).Include(a => a.RoubosTipoBens).FirstOrDefault();
        }

        public Roubo Post(Roubo entidade)
        {
            _appDbContext.Roubos.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public Roubo Update(Roubo entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Roubo Delete(Roubo entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
