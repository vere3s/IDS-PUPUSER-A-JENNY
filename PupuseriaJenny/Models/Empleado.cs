using RestauranteGestion.Core.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PupuseriaJenny.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El nombre del empleado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del empleado no puede superar los 50 caracteres.")]
        public string NombreEmpleado { get; set; }  // Cambio a 'NombreEmpleado' para coincidir con la columna

        [Required(ErrorMessage = "El apellido del empleado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido del empleado no puede superar los 50 caracteres.")]
        public string ApellidoEmpleado { get; set; }  // Cambio a 'ApellidoEmpleado' para coincidir con la columna

        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        public string TelefonoEmpelado { get; set; }  // Cambio a 'TelefonoEmpelado' para coincidir con la columna

        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
        public string DireccionEmpleado { get; set; }  // Cambio a 'DireccionEmpleado' para coincidir con la columna

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede superar los 50 caracteres.")]
        public string EmailEmpleado { get; set; }  // Cambio a 'EmailEmpleado' para coincidir con la columna

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no es válida.")]
        public DateTime FechaNacimientoEmpleado { get; set; }  // Cambio a 'FechaNacimientoEmpleado' para coincidir con la columna

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public int IdCargo { get; set; }  // Coincide con 'idCargo' en la base de datos
        string cargo { get; set; }

        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion(); // Agregar referencias= Referencias-Agregar referencia
            StringBuilder Sentencia = new StringBuilder(); // Objeto para construir cadenas complejas
            Sentencia.Append("DELETE FROM RG_Empleado ");
            Sentencia.Append("WHERE idEmpleado = " + IdEmpleado + ";");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }

    }
}
