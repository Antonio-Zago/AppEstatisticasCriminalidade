using ApiCriminalidade.Dtos;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IAssaltoService
    {
        IEnumerable<AssaltoDto> GetAll();

        AssaltoDto GetById(int id);

        AssaltoDto Post(AssaltoForm form);

        AssaltoDto? Update(int id, AssaltoForm form);

        AssaltoDto? Delete(int id);
    }
}
