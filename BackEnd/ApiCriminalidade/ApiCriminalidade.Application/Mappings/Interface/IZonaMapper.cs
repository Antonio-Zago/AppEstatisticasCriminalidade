

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IZonaMapper
    {
        ZonaDto ToDto(Zona Entidade);

        Zona ToEntidade(ZonaForm form);
    }
}
