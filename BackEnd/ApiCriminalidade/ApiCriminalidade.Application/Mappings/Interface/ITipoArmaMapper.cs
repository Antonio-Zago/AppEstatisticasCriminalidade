

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface ITipoArmaMapper
    {
        TipoArmaDto ToDto(TipoArma Entidade);

        TipoArma ToEntidade(TipoArmaForm form);
    }
}
