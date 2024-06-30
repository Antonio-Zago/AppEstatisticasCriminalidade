using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IZonaMapper
    {
        ZonaDto ToDto(Zona Entidade);

        Zona ToEntidade(ZonaForm form);
    }
}
