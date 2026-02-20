using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZUMI.Clientes.Infrastructure.Models
{
    [Table("TipoDocumento")]
    public class TipoDocumentoModel
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("Nombre", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; } = true;
    }
}
