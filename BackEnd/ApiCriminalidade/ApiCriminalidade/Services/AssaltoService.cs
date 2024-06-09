using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace ApiCriminalidade.Services
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

        public AssaltoDto? Update(int id, AssaltoForm form)
        {
            var assaltoTipoBens = new List<AssaltoTipoBem>();
            var assaltoBanco = _assaltoRepository.GetById(id);


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
