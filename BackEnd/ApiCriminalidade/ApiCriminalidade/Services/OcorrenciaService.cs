using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public IEnumerable<Ocorrencia> GetAll()
        {
            return _ocorrenciaRepository.GetAll();
        }
    }
}
