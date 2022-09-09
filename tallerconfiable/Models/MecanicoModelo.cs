
using System.ComponentModel.DataAnnotations;
namespace tallerconfiable.Models
{
    public class MecanicoModelo
    {
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public int Idpersona { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? anacimiento { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Niveleducativo { get; set; }

    }
}
