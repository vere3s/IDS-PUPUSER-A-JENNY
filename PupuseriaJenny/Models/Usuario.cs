using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.CLS
{
    internal class Usuario
    {
        public int IDUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder los 50 caracteres.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "El nombre de usuario no puede contener espacios.")]
        public string UsuarioNombre { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Contraseña { get; set; }

        // Constructor para crear el usuario
        public Usuario(int idUsuario, string usuarioNombre, string contraseña)
        {
            IDUsuario = idUsuario;
            UsuarioNombre = usuarioNombre;
            Contraseña = contraseña;
        }
        public bool EsValido(out string mensajeError)
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();

            bool esValido = Validator.TryValidateObject(this, validationContext, validationResults, true);

            mensajeError = esValido ? null : string.Join("\n", validationResults.Select(vr => vr.ErrorMessage));
            return esValido;
        }
    }
}
