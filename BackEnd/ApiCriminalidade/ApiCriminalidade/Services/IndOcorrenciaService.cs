using ApiCriminalidade.Dtos;
using ApiCriminalidade.Helpers;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiCriminalidade.Services
{
    public class IndOcorrenciaService : IIndOcorrenciaService
    {
        private readonly IIndOcorrenciaRepository _indOcorrenciaRepository;

        private readonly IProcessoService _processoService;

        private readonly IIndOcorrenciaMapper _mapper;

        public IndOcorrenciaService(IIndOcorrenciaRepository indOcorrenciaRepository, IIndOcorrenciaMapper mapper, IProcessoService processoService)
        {
            _indOcorrenciaRepository = indOcorrenciaRepository;
            _processoService = processoService;
            _mapper = mapper;
        }

        public IEnumerable<IndOcorrencia> Add(IFormFile file)
        {
            var produtos = new List<IndOcorrencia>();

            var excel = new ExcelHelper<IndOcorrenciaForm>(file);

            var produtosForm = excel.GetValues();

            foreach (var entidade in RetornarEntidadesValidas(produtosForm))
            {
                produtos.Add(_mapper.ToEntidade(entidade));
            }

            var listaOcorrencias = _indOcorrenciaRepository.Add(produtos);

            CadastrarProcesso();

            return listaOcorrencias;
        }

        private List<IndOcorrenciaForm> RetornarEntidadesValidas(List<IndOcorrenciaForm> forms)
        {
            return forms.Where(f => !string.IsNullOrEmpty(f.Rubrica) &&
                                    !string.IsNullOrEmpty(f.Latitude) && !f.Latitude.Equals("NULL") && !f.Latitude.Equals("0") &&
                                    !string.IsNullOrEmpty(f.Longitude) && !f.Longitude.Equals("NULL") && !f.Longitude.Equals("0")
                                ).ToList();
        }

        public IEnumerable<IndOcorrencia> GetAll()
        {
            return _indOcorrenciaRepository.GetAll();
        }

        private void CadastrarProcesso()
        {
            _processoService.Post(new Processo
            {
                DataCriacao = DateTime.Now,
                StatusAtual = StatusProcesso.Aguardando,
                Tipo = TipoProcesso.GeracaoIndicesCriminalidade,
                DataExecucao = null
            });
        }


    }
}
