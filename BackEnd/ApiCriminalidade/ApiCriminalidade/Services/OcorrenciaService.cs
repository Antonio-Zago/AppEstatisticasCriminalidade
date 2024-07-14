using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Pagination;
using ApiCriminalidade.Pagination.Filtros;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using X.PagedList;

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

        public async  Task<IEnumerable<OcorrenciaDto>> GetAll()
        {
            var listaDtos = new List<OcorrenciaDto>();

            var ocorrencias = await _ocorrenciaRepository.GetAll();

            foreach (var ocorrencia in ocorrencias)
            {
                var dto = _mapper.ToDto(ocorrencia);
                listaDtos.Add(dto);
            }

            return listaDtos;         
                      
        }

        public async Task<OcorrenciaDto> GetById(int id)
        {
            var ocorrencia = await _ocorrenciaRepository.GetById(id);

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

        public async Task<OcorrenciaDto?> Update(int id, OcorrenciaForm form)
        {
            var ocorrenciaBanco = await _ocorrenciaRepository.GetById(id);

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

        public async Task<OcorrenciaDto?> Delete(int id)
        {
            var ocorrenciaBanco = await _ocorrenciaRepository.GetById(id);

            if (ocorrenciaBanco == null)
            {
                return null;
            }

            var ocorrenciaDeletada = _ocorrenciaRepository.Delete(ocorrenciaBanco);

            return _mapper.ToDto(ocorrenciaDeletada);

        }

        public async Task<IPagedList<OcorrenciaDto>> GetWithPaginationParameters(GenericParameters parameters)
        {
            var entidades = await _ocorrenciaRepository.GetAll();

            var dtos = new List<OcorrenciaDto>();
            foreach (var ocorrencia in entidades)
            {
                var dto = _mapper.ToDto(ocorrencia);
                dtos.Add(dto);
            }

            var entidadesOrdenadas = await dtos.ToPagedListAsync(parameters.PageNumber, parameters.PageSize);

            return entidadesOrdenadas;
        }

        public async Task<IPagedList<OcorrenciaDto>> GetFiltroData(OcorrenciaFiltroData filtros)
        {
            var entidades = await _ocorrenciaRepository.GetAll();
            var entidadesFiltradas = entidades.Where(a => a.DataHora >= filtros.Inicio && a.DataHora <= filtros.Fim);

            var dtos = new List<OcorrenciaDto>();
            foreach (var ocorrencia in entidadesFiltradas)
            {
                var dto = _mapper.ToDto(ocorrencia);
                dtos.Add(dto);
            }

            var result = await dtos.ToPagedListAsync(filtros.PageNumber, filtros.PageSize);

            return result;
        }


    }
}
