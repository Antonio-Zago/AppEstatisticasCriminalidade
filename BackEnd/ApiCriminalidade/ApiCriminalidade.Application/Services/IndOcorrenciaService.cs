
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Helpers;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ApiCriminalidade.Application.Services
{
    public class IndOcorrenciaService : IIndOcorrenciaService
    {
        private readonly IIndOcorrenciaRepository _indOcorrenciaRepository;

        private readonly IProcessoService _processoService;

        private readonly IIndOcorrenciaMapper _mapper;

        private readonly ICidadeService _cidadeService;


        public IndOcorrenciaService(IIndOcorrenciaRepository indOcorrenciaRepository, IIndOcorrenciaMapper mapper, IProcessoService processoService, ICidadeService cidadeService)
        {
            _indOcorrenciaRepository = indOcorrenciaRepository;
            _processoService = processoService;
            _mapper = mapper;
            _cidadeService = cidadeService;
        }

        public IEnumerable<IndOcorrencia> Add(IFormFile file)
        {
            var produtos = new List<IndOcorrencia>();

            

            var excel = new ExcelHelper<IndOcorrenciaForm>(file);

            var produtosForm = excel.GetValues();

            foreach (var entidade in RetornarEntidadesValidas(produtosForm))
            {
                var cidade = _cidadeService.GetByNome(entidade.Cidade);
                var indOcorrencia = _mapper.ToEntidade(entidade);

                if (cidade != null) 
                {
                    indOcorrencia.CidadeId = cidade.Id;
                }

                produtos.Add(indOcorrencia);
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

            _processoService.Post(new Processo
            {
                DataCriacao = DateTime.Now,
                StatusAtual = StatusProcesso.Aguardando,
                Tipo = TipoProcesso.GeracaoIndiceMedio,
                DataExecucao = null
            });
        }


    }
}
