using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    internal class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del proveedor no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        public string Telefono { get; set; }

        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
        public string Direccion { get; set; }

        [StringLength(50, ErrorMessage = "El correo electrónico no puede superar los 50 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }
    }
}
