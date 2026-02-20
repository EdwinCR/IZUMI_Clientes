namespace IZUMIClientes_.Models
{
    public class ResponseViewModel<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public ResponseViewModel() { }

        public ResponseViewModel(T data)
        {
            this.Succeeded = true;
            this.Message = string.Empty;
            this.Errors = null;
            this.Data = data;
        }
    }
}
