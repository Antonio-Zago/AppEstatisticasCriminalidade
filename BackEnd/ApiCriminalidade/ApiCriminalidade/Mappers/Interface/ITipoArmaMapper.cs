using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface ITipoArmaMapper
    {
        TipoArmaDto ToDto(TipoArma Entidade);

        TipoArma ToEntidade(TipoArmaForm form);
    }
}
