using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _repository;

        private readonly ICidadeMapper _mapper;

        public CidadeService(ICidadeRepository repository, ICidadeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CidadeDto> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }

        public CidadeDto GetById(int id)
        {
            var entidade = _repository.GetById(id);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public CidadeDto GetByNome(string nome)
        {
            var entidade = _repository.GetByNome(nome);

            if (entidade == null)
            {
                return null;
            }

            return _mapper.ToDto(entidade);
        }

        public CidadeDto Post(CidadeForm form)
        {
            var entidade = _mapper.ToEntidade(form);

            var entidadeSalva = _repository.Post(entidade);

            return _mapper.ToDto(entidadeSalva);
        }

        public CidadeDto? Update(int id, CidadeForm form)
        {
            var entidadeBanco = _repository.GetById(id);

            if (entidadeBanco == null)
            {
                return null;
            }

            entidadeBanco.Area = form.Area;
            entidadeBanco.Nome = form.Nome;

            var entidadeAtualizada = _repository.Update(entidadeBanco);

            return _mapper.ToDto(entidadeAtualizada);
        }

        public CidadeDto? Delete(int id)
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
