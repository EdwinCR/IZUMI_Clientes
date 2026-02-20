namespace IZUMIClientes_.Models
{
    public class PagedResponseViewModel<T>
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
