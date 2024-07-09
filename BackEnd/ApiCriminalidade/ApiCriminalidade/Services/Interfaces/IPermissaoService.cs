using ApiCriminalidade.Dtos;

namespace ApiCriminalidade.Services.Interfaces
{
    public interface IPermissaoService
    {
        IEnumerable<PermissaoDto> GetAll();

        PermissaoDto GetById(int id);

        PermissaoDto Post(PermissaoForm form);

        PermissaoDto? Update(int id, PermissaoForm form);

        PermissaoDto? Delete(int id);

        PermissaoDto? FindPermissaoByName(string nome);
    }
}
