using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IIndOcorrenciaRepository
    {
        IEnumerable<IndOcorrencia> Add(List<IndOcorrencia> indOcorrencias);

        IEnumerable<IndOcorrencia> GetAll();
    }
}
