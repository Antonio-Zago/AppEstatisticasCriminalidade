using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IAssaltoMapper
    {
        AssaltoDto ToDto(Assalto assalto);

        Assalto ToAssalto(AssaltoForm form);
    }
}
