using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class AssaltoService : IAssaltoService
    {
        private readonly IAssaltoRepository _assaltoRepository;

        private readonly IAssaltoMapper _mapper;

        public AssaltoService(IAssaltoRepository assaltoRepository, IAssaltoMapper mapper)
        {
            _assaltoRepository = assaltoRepository;
            _mapper = mapper;
        }

        public IEnumerable<AssaltoDto> GetAll()
        {
            var assaltos = _assaltoRepository.GetAll();

            foreach (var assalto in assaltos)
            {
                yield return _mapper.ToDto(assalto);
            }

        }

        public AssaltoDto GetById(int id)
        {
            var assalto = _assaltoRepository.GetById(id);

            if (assalto == null)
            {
                return null;
            }

            return _mapper.ToDto(assalto);
        }

        public AssaltoDto Post(AssaltoForm form)
        {
            var assalto = _mapper.ToAssalto(form);

            var assaltoSalvo = _assaltoRepository.Post(assalto);

            return _mapper.ToDto(assaltoSalvo);
        }

        public AssaltoDto? Update(int id, AssaltoForm form)
        {
            var assaltoBanco = _assaltoRepository.GetById(id);

            if (assaltoBanco == null)
            {
                return null;
            }

            assaltoBanco.QuantidadeAgressores = form.QuantidadeAgressores;
            assaltoBanco.PossuiArma = form.PossuiArma;
            assaltoBanco.OcorrenciaId = form.OcorrenciaId;
            assaltoBanco.TipoArmaId = form.TipoArmaId;

            var assaltoAtualizado = _assaltoRepository.Update(assaltoBanco);

            return _mapper.ToDto(assaltoAtualizado);
        }

        public AssaltoDto? Delete(int id)
        {
            var assaltoBanco = _assaltoRepository.GetById(id);

            if (assaltoBanco == null)
            {
                return null;
            }

            var assaltoDeletado = _assaltoRepository.Delete(assaltoBanco);

            return _mapper.ToDto(assaltoDeletado);

        }
    }
}
