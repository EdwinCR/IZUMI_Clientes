namespace IZUMI.Clientes.Application.DTO
{
    public class PagedResponseDTO<T>
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
