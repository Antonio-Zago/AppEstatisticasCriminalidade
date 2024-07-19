

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
{
    public class AssaltoMapper : IAssaltoMapper
    {
        public AssaltoDto ToDto(Assalto assalto)
        {
            return new AssaltoDto
            {
                Id = assalto.Id,
                QuantidadeAgressores = assalto.QuantidadeAgressores,
                PossuiArma = assalto.PossuiArma,
                OcorrenciaId = assalto.OcorrenciaId,
                TipoArmaId = assalto.TipoArmaId,
                TipoBens = assalto.AssaltosTipoBens.Select(a => a.TipoBemId)
            };
        }

        public Assalto ToAssalto(AssaltoForm form)
        {
            return new Assalto
            {
                QuantidadeAgressores = form.QuantidadeAgressores,
                PossuiArma = form.PossuiArma,
                OcorrenciaId = form.OcorrenciaId,
                TipoArmaId = form.TipoArmaId
            };
        }
    }
}
