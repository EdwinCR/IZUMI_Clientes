using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZUMI.Clientes.Infrastructure.Models
{
    [Table("Planes")]
    public class PlanModel
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("Nombre", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Column("Descripcion", TypeName = "varchar(250)")]
        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Column("Precio", TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; } = true;
    }
}
