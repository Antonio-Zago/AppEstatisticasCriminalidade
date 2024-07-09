using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IPermissaoMapper
    {
        PermissaoDto ToDto(Permissao Entidade);

        Permissao ToEntidade(PermissaoForm form);
    }
}
