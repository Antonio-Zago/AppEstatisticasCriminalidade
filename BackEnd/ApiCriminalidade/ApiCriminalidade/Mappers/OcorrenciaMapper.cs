using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers
{
    public class OcorrenciaMapper : IOcorrenciaMapper
    {
        public OcorrenciaDto ToDto(Ocorrencia ocorrencia)
        {
            return new OcorrenciaDto
            {
                Id = ocorrencia.Id,
                Descricao = ocorrencia.Descricao,
                DataHora = ocorrencia.DataHora,
                CadastrouBoletimOcorrencia  =ocorrencia.CadastrouBoletimOcorrencia,
                TipoOcorrencia = ocorrencia.TipoOcorrencia
            };
        }

        public Ocorrencia ToOcorrencia(OcorrenciaForm form)
        {
            return new Ocorrencia
            {
                Descricao = form.Descricao,
                DataHora = form.DataHora,
                CadastrouBoletimOcorrencia = form.CadastrouBoletimOcorrencia,
                TipoOcorrencia = form.TipoOcorrencia
            };
        }

    }
}
