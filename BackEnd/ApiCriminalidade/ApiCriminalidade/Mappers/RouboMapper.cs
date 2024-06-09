using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers
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
