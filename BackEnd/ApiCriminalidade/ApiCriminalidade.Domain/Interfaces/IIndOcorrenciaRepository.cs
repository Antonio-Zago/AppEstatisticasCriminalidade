﻿
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Domain.Interfaces
{
    public interface IIndOcorrenciaRepository
    {
        IEnumerable<IndOcorrencia> Add(List<IndOcorrencia> indOcorrencias);

        IEnumerable<IndOcorrencia> GetAll();

        int GetTotalOcorrenciasPorZona(decimal raio, decimal latitude, decimal longitude);
    }
}
