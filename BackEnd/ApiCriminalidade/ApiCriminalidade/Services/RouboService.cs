using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class RouboService : IRouboService
    {
        private readonly IRouboRepository _repository;

        private readonly IRouboMapper _mapper;

        public RouboService(IRouboRepository repository, IRouboMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            var entidade = _mapper.ToEntidade(form);

            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }

        public RouboDto? Update(int id, RouboForm form)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.OcorrenciaId = form.OcorrenciaId;

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
