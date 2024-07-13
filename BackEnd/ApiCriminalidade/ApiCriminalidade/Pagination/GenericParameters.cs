namespace ApiCriminalidade.Pagination
{
    public class GenericParameters
    {
        const int maxPageSize = 50; //Número máximo de registros por requisição
        public int PageNumber { get; set; } = 1;

        private int _pageSize;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value>maxPageSize ? maxPageSize : value;
            }
        }
    }
}
