using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services
{
    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository _repository;


        public ZonaService(IZonaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Zona> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return entidade;
            }

        }

        public Zona GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return entidade;
        }

        public Zona Post(Zona form)
        {

            var entidadeSalva = _repository.Post(form);

            return entidadeSalva;
        }


        public Zona? Delete(int id)
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
