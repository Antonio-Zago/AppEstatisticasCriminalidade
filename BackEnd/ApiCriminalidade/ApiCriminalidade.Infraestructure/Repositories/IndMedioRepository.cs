using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Infraestructure.Repositories
{
    public class IndMedioRepository : IIndMedioRepository
    {
        private readonly AppDbContext _appDbContext;

        public IndMedioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IndMedio GetById(int id)
        {
            return _appDbContext.IndMedios.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
