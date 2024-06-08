using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers.Interface
{
    public interface IRouboMapper
    {
        RouboDto ToDto(Roubo Entidade);

        Roubo ToEntidade(RouboForm form);
    }
}
