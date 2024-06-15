using ApiCriminalidade.Dtos;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Models;

namespace ApiCriminalidade.Mappers
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
            var dataHora = string.Concat(form.Data_Ocorrencia_Bo," ", form.Hora_ocorrencia_Bo);

            DateTime.TryParse(dataHora, out var data);

            var tipo = RetornarTipoOcorrencia(form.Rubrica);


            return new IndOcorrencia
            {
                NumBo = form.Num_Bo,
                Cidade = form.Cidade,
                Latitude = form.Latitude,
                Longitude = form.Longitude,
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
