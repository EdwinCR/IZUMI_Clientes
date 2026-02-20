namespace IZUMI.Clientes.Application.DTO
{
    public class ResponseDTO<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public ResponseDTO() { }

        public ResponseDTO(T data)
        {
            this.Succeeded = true;
            this.Message = string.Empty;
            this.Errors = null;
            this.Data = data;
        }
    }
}
