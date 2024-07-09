using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers
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
