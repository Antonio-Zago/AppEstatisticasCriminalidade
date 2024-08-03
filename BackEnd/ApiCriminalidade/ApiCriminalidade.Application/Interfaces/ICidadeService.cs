using ApiCriminalidade.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface ICidadeService
    {
        IEnumerable<CidadeDto> GetAll();

        CidadeDto GetById(int id);

        CidadeDto Post(CidadeForm form);

        CidadeDto? Update(int id, CidadeForm form);

        CidadeDto? Delete(int id);

        CidadeDto GetByNome(string nome);
    }
}
