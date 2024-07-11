namespace ApiCriminalidade.Dtos
{
    public class ErroDto
    {
        public int StatusCode { get; set; }

        public string Title { get; set; }

        public string ExceptionMessage { get; set; }
    }
}
