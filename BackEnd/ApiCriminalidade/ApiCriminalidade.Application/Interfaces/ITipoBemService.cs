using ApiCriminalidade.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface ITipoBemService
    {
        IEnumerable<TipoBemDto> GetAll();

        TipoBemDto GetById(int id);

        TipoBemDto Post(TipoBemForm form);

        TipoBemDto? Update(int id, TipoBemForm form);

        TipoBemDto? Delete(int id);
    }
}
