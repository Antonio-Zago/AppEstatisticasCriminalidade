using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface ICidadeRepository
    {
        IEnumerable<Cidade> GetAll();

        Cidade GetById(int id);

        Cidade Post(Cidade entidade);

        Cidade Update(Cidade entidade);

        Cidade Delete(Cidade entidade);

        Cidade GetByNome(string nome);
    }
}
