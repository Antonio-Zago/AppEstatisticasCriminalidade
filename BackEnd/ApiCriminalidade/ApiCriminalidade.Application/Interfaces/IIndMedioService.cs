using ApiCriminalidade.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IIndMedioService
    {
        IndMedioDto GetById(int id);
    }
}
