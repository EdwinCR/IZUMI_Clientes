using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IZUMI.Clientes.Infrastructure.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        [Column("Id", TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column("TipoDocumentoId", TypeName = "int")]
        public int TipoDocumentoId { get; set; }

        [Column("NumeroDocumento", TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string NumeroDocumento { get; set; }

        [Column("FechaNacimiento", TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column("PrimerNombre", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string PrimerNombre { get; set; }

        [Column("SegundoNombre", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string SegundoNombre { get; set; }

        [Column("PrimerApellido", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string PrimerApellido { get; set; }

        [Column("SegundoApellido", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string SegundoApellido { get; set; }

        [Column("Direccion", TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Direccion { get; set; }

        [Column("Celular", TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Column("Email", TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Column("PlanId", TypeName = "int")]
        public int PlanId { get; set; }

        [Column("FechaCreacion", TypeName = "datetime2")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [Column("Activo", TypeName = "bit")]
        public bool Activo { get; set; } = true;


        [ForeignKey("TipoDocumentoId")]
        public TipoDocumentoModel TipoDocumento { get; set; }

        [ForeignKey("PlanId")]
        public PlanModel Plan { get; set; }
    }
}
