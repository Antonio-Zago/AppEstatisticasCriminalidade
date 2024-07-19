

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
{
    public class RouboMapper : IRouboMapper
    {
        public RouboDto ToDto(Roubo entidade)
        {
            return new RouboDto
            {
                Id = entidade.Id,
                OcorrenciaId = entidade.OcorrenciaId,
                TipoBens = entidade.RoubosTipoBens.Select(a => a.TipoBemId)
            };
        }

        public Roubo ToEntidade(RouboForm form)
        {
            return new Roubo
            {
                OcorrenciaId = form.OcorrenciaId
            };
        }
    }
}
