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
    public class IndFurtoRepository : IIndFurtoRepository
    {
        private readonly AppDbContext _appDbContext;

        public IndFurtoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<IndFurto> GetAll()
        {
            return _appDbContext.IndFurtos.Where(a => !a.DataFim.HasValue).Include(a => a.Zona);
        }
    }
}
