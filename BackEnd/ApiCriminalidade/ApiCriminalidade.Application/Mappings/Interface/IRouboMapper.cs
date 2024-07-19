

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface IRouboMapper
    {
        RouboDto ToDto(Roubo Entidade);

        Roubo ToEntidade(RouboForm form);
    }
}
