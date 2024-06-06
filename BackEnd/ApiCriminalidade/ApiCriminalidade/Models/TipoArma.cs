namespace ApiCriminalidade.Models
{
    public class TipoArma
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public bool ArmaDeFogo { get; set; }

        public IEnumerable<Assalto>? Assaltos { get; set; }
    }
}
