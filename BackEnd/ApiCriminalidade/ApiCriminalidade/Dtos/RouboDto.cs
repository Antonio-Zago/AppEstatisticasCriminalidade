using ApiCriminalidade.Models;

namespace ApiCriminalidade.Dtos
{
    public class RouboDto
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }

        public IEnumerable<int> TipoBens { get; set; }
    }
}
