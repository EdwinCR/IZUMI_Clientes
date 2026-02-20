using System.ComponentModel.DataAnnotations;

namespace IZUMIClientes_.Models
{
    public class ClienteRequestViewModel
    {
        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]
        public int TipoDocumentoId { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Direccion { get; set; }

        public string Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|co)$", ErrorMessage = "El email no tiene un formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El plan es obligatorio.")]
        public int PlanId { get; set; }
    }
}
