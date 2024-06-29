using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IIndAssaltoService
    {
        IEnumerable<IndAssalto> GetAll();

        IndAssalto GetById(int id);

        IndAssalto Post(IndAssalto form);


        IndAssalto? Delete(int id);
    }
}
