using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IIndFurtoService
    {
        IEnumerable<IndFurtoDto> GetAll();
    }
}
