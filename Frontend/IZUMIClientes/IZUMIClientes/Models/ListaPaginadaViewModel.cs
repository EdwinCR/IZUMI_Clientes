namespace IZUMIClientes_.Models
{
    public class ListaPaginadaViewModel<T>
    {
        public List<T> Items { get; set; }
        public int TotalPaginas { get; set; }
        public int NumeroPagina { get; set; }
        public int PaginaActual { get; set; }
    }
}
