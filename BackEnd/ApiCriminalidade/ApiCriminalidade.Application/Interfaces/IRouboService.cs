

using ApiCriminalidade.Application.Dtos;

namespace ApiCriminalidade.Application.Interfaces
{
    public interface IRouboService
    {
        IEnumerable<RouboDto> GetAll();

        RouboDto GetById(int id);

        RouboDto Post(RouboForm form);

        RouboDto? Update(int id, RouboForm form);

        RouboDto? Delete(int id);
    }
}
