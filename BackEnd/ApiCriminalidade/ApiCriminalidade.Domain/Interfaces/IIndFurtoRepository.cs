using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface IIndFurtoRepository
    {
        IEnumerable<IndFurto> GetAll();
    }
}
