using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;
using ApiCriminalidade.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Services
{
    public class IndFurtoService : IIndFurtoService
    {
        private readonly IIndFurtoRepository _repository;

        private readonly IIndFurtoMapper _mapper;


        public IndFurtoService(IIndFurtoRepository repository, IIndFurtoMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<IndFurtoDto> GetAll()
        {
            var entidades = _repository.GetAll();

            foreach (var entidade in entidades)
            {
                yield return _mapper.ToDto(entidade);
            }

        }
    }
}
