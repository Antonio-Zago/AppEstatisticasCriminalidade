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

        private readonly IZonaMapper _mapper;


        public ZonaService(IZonaRepository repository, IZonaMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ZonaDto> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }

        public ZonaDto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public ZonaDto Post(ZonaForm form)
        {

            var entidade = _mapper.ToEntidade(form);

            entidade.Area = CalcularArea(entidade.Raio);

            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }


        public ZonaDto? Delete(int id)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            var entidadeDeletada = _repository.Delete(entidadeBanco);

            return _mapper.ToDto(entidadeDeletada);

        }

        public ZonaDto? Update(int id, ZonaForm form)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.LatitudeCentral = form.LatitudeCentral;
            entidadeBanco.LongitudeCentral = form.LongitudeCentral;
            entidadeBanco.Raio = form.Raio;
            entidadeBanco.Ativo = form.Ativo;
            entidadeBanco.CidadeId = form.CidadeId;
            entidadeBanco.Area = CalcularArea(form.Raio);

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        private decimal CalcularArea(decimal raio)
        {
            return (decimal)3.14159 * raio * raio;
        }
    }
}
