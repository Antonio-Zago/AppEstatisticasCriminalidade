namespace ApiCriminalidade.Application.Pagination.Filtros
{
    public class OcorrenciaFiltroData : GenericParameters
    {
        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }
    }
}
