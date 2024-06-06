using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers
{
    public class TipoArmaMapper : ITipoArmaMapper
    {
        public TipoArmaDto ToDto(TipoArma entidade)
        {
            return new TipoArmaDto
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao,
                ArmaDeFogo = entidade.ArmaDeFogo
            };
        }

        public TipoArma ToEntidade(TipoArmaForm form)
        {
            return new TipoArma
            {
                Descricao = form.Descricao,
                ArmaDeFogo = form.ArmaDeFogo
            };
        }
    }
}
