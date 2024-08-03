using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly AppDbContext _appDbContext;

        public CidadeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Cidade> GetAll()
        {
            return _appDbContext.Cidades;
        }

        public Cidade GetById(int id)
        {
            return _appDbContext.Cidades.Where(x => x.Id == id).FirstOrDefault();
        }

        public Cidade GetByNome(string nome)
        {
            return _appDbContext.Cidades.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public Cidade Post(Cidade entidade)
        {
            _appDbContext.Cidades.Add(entidade);
            _appDbContext.SaveChanges();
            return entidade;
        }

        public Cidade Update(Cidade entidade)
        {
            _appDbContext.Entry(entidade).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return entidade;
        }

        public Cidade Delete(Cidade entidade)
        {
            _appDbContext.Remove(entidade);
            _appDbContext.SaveChanges();

            return entidade;
        }
    }
}
