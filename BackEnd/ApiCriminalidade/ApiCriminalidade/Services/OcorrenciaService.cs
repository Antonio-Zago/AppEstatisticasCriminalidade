using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        private readonly IOcorrenciaMapper _mapper;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository, IOcorrenciaMapper mapper)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
            _mapper = mapper;
        }

        public IEnumerable<OcorrenciaDto> GetAll()
        {
            var ocorrencias = _ocorrenciaRepository.GetAll();

            foreach (var ocorrencia in ocorrencias)
            {
                yield return _mapper.ToDto(ocorrencia);
            }
                      
        }

        public OcorrenciaDto GetById(int id)
        {
            var ocorrencia = _ocorrenciaRepository.GetById(id);

            if (ocorrencia == null)
            {
                return null;
            }

            return _mapper.ToDto(ocorrencia);
        }

        public OcorrenciaDto Post(OcorrenciaForm form)
        {
            var ocorrencia = _mapper.ToOcorrencia(form);

            var ocorrenciaSalva = _ocorrenciaRepository.Post(ocorrencia);

            return _mapper.ToDto(ocorrenciaSalva);
        }

        public OcorrenciaDto? Update(int id, OcorrenciaForm form)
        {
            var ocorrenciaBanco = _ocorrenciaRepository.GetById(id);

            if (ocorrenciaBanco == null)
            {
                return null;
            }

            ocorrenciaBanco.Descricao = form.Descricao;
            ocorrenciaBanco.DataHora = form.DataHora;
            ocorrenciaBanco.CadastrouBoletimOcorrencia = form.CadastrouBoletimOcorrencia;

            var ocorrenciaAtualizada = _ocorrenciaRepository.Update(ocorrenciaBanco);

            return _mapper.ToDto(ocorrenciaAtualizada);
        }

        public OcorrenciaDto? Delete(int id)
        {
            var ocorrenciaBanco = _ocorrenciaRepository.GetById(id);

            if (ocorrenciaBanco == null)
            {
                return null;
            }

            var ocorrenciaDeletada = _ocorrenciaRepository.Delete(ocorrenciaBanco);

            return _mapper.ToDto(ocorrenciaDeletada);

        }
    }
}
