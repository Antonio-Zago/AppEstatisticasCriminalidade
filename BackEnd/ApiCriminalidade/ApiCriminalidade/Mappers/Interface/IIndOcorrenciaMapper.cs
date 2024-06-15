using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IIndOcorrenciaMapper
    {
        //TipoArmaDto ToDto(TipoArma Entidade);

        IndOcorrencia ToEntidade(IndOcorrenciaForm form);
    }
}
