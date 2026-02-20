namespace IZUMI.Clientes.Domain.Entities
{
    public class PagedResultEntity<T>
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; }
    }
}
