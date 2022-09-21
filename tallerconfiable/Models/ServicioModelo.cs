using System.ComponentModel.DataAnnotations;

namespace tallerconfiable.Models
{
    public class ServicioModelo
    {
        public int Idservicio { get; set; }
        public int Idpropietario { get; set; }
        public int Idvehiculo { get; set; }
        public int Idmecanico { get; set; }
        public string? Placa { get; set; }

        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Nivelaceite { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Nivelfrenos { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Niveldireccion { get; set; }
        [Required(ErrorMessage = "EL campo es obligatorio")]//obligatoria
        public string? Repuestos { get; set; }
       
        public string? Fecha { get; set; }
       


    }
}
