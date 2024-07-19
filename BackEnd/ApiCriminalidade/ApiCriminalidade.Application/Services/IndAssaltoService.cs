

using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;

namespace ApiCriminalidade.Application.Services
{
    public class IndAssaltoService : IIndAssaltoService
    {
        private readonly IIndRouboRepository _repository;


        public IndAssaltoService(IIndRouboRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IndRoubo> GetAll()
        {
            var entidades = _repository.GetAll();

            return entidades;

        }

        public IndRoubo GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return entidade;
        }

        public IndRoubo Post(IndRoubo form)
        {

            var entidadeSalva = _repository.Post(form);

            return entidadeSalva;
        }

        public IndRoubo? Delete(int id)
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
