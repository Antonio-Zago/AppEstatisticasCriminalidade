

using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Interfaces;

namespace ApiCriminalidade.Application.Services
{
    public class TipoArmaService : ITipoArmaService
    {
        private readonly ITipoArmaRepository _repository;

        private readonly ITipoArmaMapper _mapper;

        public TipoArmaService(ITipoArmaRepository repository, ITipoArmaMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TipoArmaDto> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }

        public TipoArmaDto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public TipoArmaDto Post(TipoArmaForm form)
        {
            var entidade = _mapper.ToEntidade(form);

            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }

        public TipoArmaDto? Update(int id, TipoArmaForm form)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.Descricao = form.Descricao;
            entidadeBanco.ArmaDeFogo = form.ArmaDeFogo;

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        public TipoArmaDto? Delete(int id)
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
