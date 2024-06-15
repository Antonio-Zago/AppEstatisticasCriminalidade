using ApiCriminalidade.Dtos;
using ApiCriminalidade.Helpers;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class IndOcorrenciaService : IIndOcorrenciaService
    {
        private readonly IIndOcorrenciaRepository _indOcorrenciaRepository;

        private readonly IIndOcorrenciaMapper _mapper;

        public IndOcorrenciaService(IIndOcorrenciaRepository indOcorrenciaRepository, IIndOcorrenciaMapper mapper)
        {
            _indOcorrenciaRepository = indOcorrenciaRepository;
            _mapper = mapper;
        }

        public IEnumerable<IndOcorrencia> Add(IFormFile file)
        {
            var produtos = new List<IndOcorrencia>();

            var excel = new ExcelHelper<IndOcorrenciaForm>(file);

            var produtosForm = excel.GetValues();

            foreach (var entidade in produtosForm.Where(a => !string.IsNullOrEmpty(a.Rubrica) ))
            {
                produtos.Add(_mapper.ToEntidade(entidade));
            }

            

            return _indOcorrenciaRepository.Add(produtos);
        }

        public IEnumerable<IndOcorrencia> GetAll()
        {
            return _indOcorrenciaRepository.GetAll();
        }
    }
}
