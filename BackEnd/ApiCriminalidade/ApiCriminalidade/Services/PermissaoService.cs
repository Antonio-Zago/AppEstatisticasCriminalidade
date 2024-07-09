using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoRepository _repository;

        private readonly IPermissaoMapper _mapper;

        public PermissaoService(IPermissaoRepository repository, IPermissaoMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PermissaoDto> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }

        public PermissaoDto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public PermissaoDto Post(PermissaoForm form)
        {
            var entidade = _mapper.ToEntidade(form);

            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }

        public PermissaoDto? Update(int id, PermissaoForm form)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.Nome = form.Nome;

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        public PermissaoDto? Delete(int id)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            var entidadeDeletada = _repository.Delete(entidadeBanco);

            return _mapper.ToDto(entidadeDeletada);

        }

        public PermissaoDto? FindPermissaoByName(string nome)
        {
            var entidade = _repository.FindPermissaoByName(nome);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }
    }
}
