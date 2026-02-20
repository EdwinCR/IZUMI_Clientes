namespace IZUMI.Clientes.Domain.Entities
{
    public class TipoDocumentoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; } = true;
    }
}
