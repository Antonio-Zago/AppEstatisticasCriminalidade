using ApiCriminalidade.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiCriminalidade.Domain.Entities
{
    public sealed class Ocorrencia : Entity
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataHora { get; set; }

        public bool CadastrouBoletimOcorrencia { get; set; }

        public TipoOcorrencia TipoOcorrencia { get; set; }

        public Assalto? Assalto { get; set; }

        public Roubo? Roubo { get; set; }

        
    }


}
