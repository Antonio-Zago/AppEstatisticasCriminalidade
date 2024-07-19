
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
{
    public class ZonaMapper : IZonaMapper
    {
        public ZonaDto ToDto(Zona entidade)
        {
            return new ZonaDto
            {
                Id = entidade.Id,
                LatitudeCentral = entidade.LatitudeCentral,
                LongitudeCentral = entidade.LongitudeCentral,
                Raio = entidade.Raio,
                Area = entidade.Area,
                Ativo = entidade.Ativo,
                CidadeId = entidade.CidadeId
            };
        }

        public Zona ToEntidade(ZonaForm form)
        {
            return new Zona
            {
                LatitudeCentral = form.LatitudeCentral,
                LongitudeCentral = form.LongitudeCentral,
                Raio = form.Raio,
                Ativo = form.Ativo,
                CidadeId = form.CidadeId
            };
        }
    }
}
