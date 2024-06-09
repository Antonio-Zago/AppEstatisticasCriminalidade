using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers
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
