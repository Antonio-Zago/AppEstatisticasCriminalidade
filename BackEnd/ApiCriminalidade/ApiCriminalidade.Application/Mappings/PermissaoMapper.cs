

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
{
    public class PermissaoMapper : IPermissaoMapper
    {
        public PermissaoDto ToDto(Permissao entidade)
        {
            return new PermissaoDto
            {
                Id = entidade.Id,
                Nome = entidade.Nome
            };
        }

        public Permissao ToEntidade(PermissaoForm form)
        {
            return new Permissao
            {
                Nome = form.Nome
            };
        }
    }
}
