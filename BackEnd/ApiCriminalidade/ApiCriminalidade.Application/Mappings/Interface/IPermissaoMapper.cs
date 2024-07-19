
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IPermissaoMapper
    {
        PermissaoDto ToDto(Permissao Entidade);

        Permissao ToEntidade(PermissaoForm form);
    }
}
