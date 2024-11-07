using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PupuseriaJenny.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El nombre del empleado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del empleado no puede superar los 50 caracteres.")]
        public string NombresEmpleado { get; set; }

        [Required(ErrorMessage = "El apellido del empleado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido del empleado no puede superar los 50 caracteres.")]
        public string ApellidosEmpleado { get; set; }

        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        public string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede superar los 50 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no es válida.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public int IdCargo { get; set; }
    }
}
