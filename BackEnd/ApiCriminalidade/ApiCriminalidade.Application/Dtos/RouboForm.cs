namespace ApiCriminalidade.Application.Dtos
{
    public class RouboForm : OcorrenciaForm
    {

        public IEnumerable<int> TipoBens { get; set; }
    }
}
