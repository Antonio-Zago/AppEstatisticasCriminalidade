
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;

namespace ApiCriminalidade.Application.Services
{
    public class RouboService : IRouboService
    {
        private readonly IRouboRepository _repository;

        private readonly ITipoBemRepository _tipoBemRepository;

        private readonly IRouboMapper _mapper;

        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public RouboService(IRouboRepository repository, IRouboMapper mapper, ITipoBemRepository tipoBemRepository, IOcorrenciaRepository ocorrenciaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tipoBemRepository = tipoBemRepository;
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public IEnumerable<RouboDto> GetAll()
        {
            var entidades = _repository.GetAll();


            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }

        public RouboDto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public RouboDto Post(RouboForm form)
        {
            var rouboTipoBens = new List<RouboTipoBem>();
            var entidade = _mapper.ToEntidade(form);

            var tipoBens = _tipoBemRepository.GetByIds(form.TipoBens);

            if (tipoBens == null)
            {
                return null;
            }

            foreach (var tipoBem in tipoBens)
            {
                var rouboTipoBem = new RouboTipoBem
                {
                    TipoBem = tipoBem
                };
                rouboTipoBens.Add(rouboTipoBem);
            }

            entidade.RoubosTipoBens = rouboTipoBens;

            entidade.Ocorrencia = new Ocorrencia()
            {
                Descricao = form.Descricao,
                CadastrouBoletimOcorrencia = form.CadastrouBoletimOcorrencia,
                DataHora = form.DataHora,
                TipoOcorrencia = TipoOcorrencia.Roubo
            };


            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }

        public RouboDto? Update(int id, RouboForm form)
        {
            var rouboTipoBens = new List<RouboTipoBem>();
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
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
                var rouboTipoBem = new RouboTipoBem
                {
                    Roubo = entidadeBanco,
                    TipoBem = tipoBem
                };
                rouboTipoBens.Add(rouboTipoBem);
            }

            entidadeBanco.RoubosTipoBens = rouboTipoBens;
            //entidadeBanco.OcorrenciaId = form.OcorrenciaId;

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        public RouboDto? Delete(int id)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            var entidadeDeletada = _repository.Delete(entidadeBanco);

            return _mapper.ToDto(entidadeDeletada);

        }
    }
}
