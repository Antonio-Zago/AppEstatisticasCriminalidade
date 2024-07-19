
using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Mappings
{
    public class IndOcorrenciaMapper : IIndOcorrenciaMapper
    {
        //public TipoArmaDto ToDto(TipoArma entidade)
        //{
        //    return new TipoArmaDto
        //    {
        //        Id = entidade.Id,
        //        Descricao = entidade.Descricao,
        //        ArmaDeFogo = entidade.ArmaDeFogo
        //    };
        //}

        public IndOcorrencia ToEntidade(IndOcorrenciaForm form)
        {
            var hora = form.Hora_ocorrencia_Bo.Equals("NULL") ? null : form.Hora_ocorrencia_Bo;

            var dataHora = string.Concat(form.Data_Ocorrencia_Bo," ", hora);

            DateTime.TryParse(dataHora, out var data);

            var tipo = RetornarTipoOcorrencia(form.Rubrica);


            return new IndOcorrencia
            {
                NumBo = form.Num_Bo,
                Cidade = form.Cidade,
                Latitude = decimal.Parse(form.Latitude),
                Longitude = decimal.Parse(form.Longitude),
                Tipo = tipo,
                DataOcorrencia = data
            };
        }

        private IndTipoOcorrencia RetornarTipoOcorrencia(string descricao)
        {
            if (descricao.Contains("Furto (art. 155)"))
            {
                return IndTipoOcorrencia.Furto;
            }
            else if (descricao.Contains("Roubo (art. 157)"))
            {
                return IndTipoOcorrencia.Roubo;
            }

            return IndTipoOcorrencia.NaoEncontrado;

        }
    }
}
