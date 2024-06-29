using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class IndAssaltoService : IIndAssaltoService
    {
        private readonly IIndAssaltoRepository _repository;


        public IndAssaltoService(IIndAssaltoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IndAssalto> GetAll()
        {
            var entidades = _repository.GetAll();

            return entidades;

        }

        public IndAssalto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return entidade;
        }

        public IndAssalto Post(IndAssalto form)
        {

            var entidadeSalva = _repository.Post(form);

            return entidadeSalva;
        }

        public IndAssalto? Delete(int id)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            var entidadeDeletada = _repository.Delete(entidadeBanco);

            return entidadeDeletada;

        }
    }
}
