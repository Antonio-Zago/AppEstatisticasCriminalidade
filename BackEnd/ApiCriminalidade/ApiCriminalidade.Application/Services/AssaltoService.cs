

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;

namespace ApiCriminalidade.Application.Services
{
    public class AssaltoService : IAssaltoService
    {
        private readonly IAssaltoRepository _assaltoRepository;

        private readonly ITipoBemRepository _tipoBemRepository;

        private readonly IAssaltoMapper _mapper;

        public AssaltoService(IAssaltoRepository assaltoRepository, IAssaltoMapper mapper, ITipoBemRepository tipoBemRepository)
        {
            _assaltoRepository = assaltoRepository;
            _mapper = mapper;
            _tipoBemRepository = tipoBemRepository;
        }

        public async Task<IEnumerable<AssaltoDto>> GetAll()
        {
            var listaDtos = new List<AssaltoDto>();

            var assaltos = await _assaltoRepository.GetAll();

            foreach (var assalto in assaltos)
            {
                var dto = _mapper.ToDto(assalto);
                listaDtos.Add(dto);
            }

            return listaDtos;

        }

        public async Task<AssaltoDto> GetById(int id)
        {
            var assalto = await _assaltoRepository.GetById(id);

            if (assalto == null)
            {
                return null;
            }

            return _mapper.ToDto(assalto);
        }

        public AssaltoDto Post(AssaltoForm form)
        {
            var assaltoTipoBens = new List<AssaltoTipoBem>();
            var assalto = _mapper.ToAssalto(form);

            var tipoBens = _tipoBemRepository.GetByIds( form.TipoBens);

            if (tipoBens == null)
            {
                return null;
            }

            foreach (var tipoBem in tipoBens)
            {
                var assaltoTipoBem = new AssaltoTipoBem
                {
                    Assalto = assalto,
                    TipoBem = tipoBem
                };

                assaltoTipoBens.Add(assaltoTipoBem);
            }

            assalto.AssaltosTipoBens = assaltoTipoBens;

            var assaltoSalvo = _assaltoRepository.Post(assalto);



            return _mapper.ToDto(assaltoSalvo);
        }

        public async Task<AssaltoDto?> Update(int id, AssaltoForm form)
        {
            var assaltoTipoBens = new List<AssaltoTipoBem>();
            var assaltoBanco = await _assaltoRepository.GetById(id);


            if (assaltoBanco == null)
            {
                return null;
            }

            var tipoBens = _tipoBemRepository.GetByIds(form.TipoBens);

            if (tipoBens == null)
            {
                return null;
            }

            foreach (var tipoBem in tipoBens)
            {
                var assaltoTipoBem = new AssaltoTipoBem
                {
                    Assalto = assaltoBanco,
                    TipoBem = tipoBem
                };

                assaltoTipoBens.Add(assaltoTipoBem);
            }

            assaltoBanco.AssaltosTipoBens = assaltoTipoBens;

            assaltoBanco.QuantidadeAgressores = form.QuantidadeAgressores;
            assaltoBanco.PossuiArma = form.PossuiArma;
            assaltoBanco.OcorrenciaId = form.OcorrenciaId;
            assaltoBanco.TipoArmaId = form.TipoArmaId;
            

            var assaltoAtualizado = _assaltoRepository.Update(assaltoBanco);

            return _mapper.ToDto(assaltoAtualizado);
        }

        public async Task<AssaltoDto?> Delete(int id)
        {
            var assaltoBanco = await _assaltoRepository.GetById(id);

            if (assaltoBanco == null)
            {
                return null;
            }

            var assaltoDeletado = _assaltoRepository.Delete(assaltoBanco);

            return _mapper.ToDto(assaltoDeletado);

        }
    }
}
