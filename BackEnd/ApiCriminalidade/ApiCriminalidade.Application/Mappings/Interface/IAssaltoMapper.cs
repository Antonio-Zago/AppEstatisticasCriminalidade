

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IAssaltoMapper
    {
        AssaltoDto ToDto(Assalto assalto);

        Assalto ToAssalto(AssaltoForm form);
    }
}
