

using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;

namespace ApiCriminalidade.Application.Services
{
    public class ProcessoService : IProcessoService
    {
        private readonly IProcessoRepository _repository;

        public ProcessoService(IProcessoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Processo> GetAll()
        {
            var entidades = _repository.GetAll();

            return entidades;

        }

        public Processo GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return entidade;
        }

        public Processo Post(Processo form)
        {

            var entidadeSalva = _repository.Post(form);

            return entidadeSalva;
        }

        public Processo? Delete(int id)
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
