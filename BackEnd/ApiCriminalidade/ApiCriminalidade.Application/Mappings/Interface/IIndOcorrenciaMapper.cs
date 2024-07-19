

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IIndOcorrenciaMapper
    {
        //TipoArmaDto ToDto(TipoArma Entidade);

        IndOcorrencia ToEntidade(IndOcorrenciaForm form);
    }
}
