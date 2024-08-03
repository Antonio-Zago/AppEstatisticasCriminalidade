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
    public class IndMedioService : IIndMedioService
    {

        private readonly IIndMedioRepository _repository;

        private readonly IIndMedioMapper _mapper;

        public IndMedioService(IIndMedioRepository repository, IIndMedioMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IndMedioDto GetById(int id) 
        { 
            var indMedio = _repository.GetById(id);

            return _mapper.ToDto(indMedio);
        }
    }
}
