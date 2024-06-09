namespace ApiCriminalidade.Dtos
{
    public class RouboForm
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }

        public IEnumerable<int> TipoBens { get; set; }
    }
}
