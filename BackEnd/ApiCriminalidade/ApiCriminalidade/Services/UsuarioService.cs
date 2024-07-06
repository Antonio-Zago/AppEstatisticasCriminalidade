using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        private readonly IUsuarioMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IUsuarioMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }

        public UsuarioDto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public UsuarioDto Post(RegisterForm form)
        {
            var entidade = _mapper.ToEntidade(form);

            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }

        public UsuarioDto? Update(int id, UsuarioForm form)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.Senha = form.Senha;
            entidadeBanco.Email = form.Email;

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        public UsuarioDto? Delete(int id)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            var entidadeDeletada = _repository.Delete(entidadeBanco);

            return _mapper.ToDto(entidadeDeletada);

        }

        public UsuarioDto? FindByEmail(string email)
        {
            var usuario = _repository.FindByEmail(email);
            if (usuario != null)
            {
                return _mapper.ToDto(usuario);
            }

            return null;
        }

        public bool CheckPassword(string senhaForm, string senha)
        {
            return senhaForm == senha;
        }

        public UsuarioDto? UpdateRefreshToken(int id, UsuarioDto dto)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.RefreshToken = dto.RefreshToken;
            entidadeBanco.RefreshTokenExpiryTime = dto.RefreshTokenExpiryTime;

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        public List<string> ValidarUsuarioJaExistente(string email, string cpf)
        {
            return _repository.FindByEmailOrCpf(email, cpf); ;
        }


    }
}
