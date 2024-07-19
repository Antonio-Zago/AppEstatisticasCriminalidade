

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
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
