namespace ApiProdutos.Pagination
{
    public class GenericParameters
    {
        const int MaxPageSize = 3;
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
                _pageSize = (value < MaxPageSize) ? value : MaxPageSize;
            }
        }
    }
}
