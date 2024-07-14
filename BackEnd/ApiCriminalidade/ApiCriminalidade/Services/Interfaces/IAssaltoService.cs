using ApiCriminalidade.Dtos;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IAssaltoService
    {
        Task<IEnumerable<AssaltoDto>> GetAll();

        Task<AssaltoDto> GetById(int id);

        AssaltoDto Post(AssaltoForm form);

        Task<AssaltoDto?> Update(int id, AssaltoForm form);

        Task<AssaltoDto?> Delete(int id);
    }
}
