
using System.ComponentModel.DataAnnotations;
namespace tallerconfiable.Models
{
    public class VehiculoModelo
    {
        public int Idvehiculo { get; set; }
        public int Idpropietario { get; set; }
        public int Identificacion { get; set; }
        
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Placa { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Marca { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Capacidad { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Cilindraje { get; set; }
        public string? Ciudadorigen { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }







    }
}
