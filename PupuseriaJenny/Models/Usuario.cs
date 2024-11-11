using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
   public class Usuario
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

        // Para los metodos insertar, eliminar y modificar 
      
        Int32 _IDEmpleado;
        Int32 _IDRol;
        public int IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }
        public int IDRol { get => _IDRol; set => _IDRol = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("INSERT INTO usuarios(Usuario, Contraseña, IDEmpleado, IDRol) VALUES(");
            Sentencia.Append("'" + UsuarioNombre + "', ");
            Sentencia.Append("'" + Usuario.ConvertirContraseña(Contraseña) + "', ");
            Sentencia.Append("'" + IDEmpleado + "', ");
            Sentencia.Append("'" + IDRol + "');");
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
        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("UPDATE usuarios SET ");
            Sentencia.Append("Usuario = '" + UsuarioNombre + "', ");
            Sentencia.Append("Contraseña = '" + Usuario.ConvertirContraseña(Contraseña) + "', ");
            Sentencia.Append("IDEmpleado = '" + _IDEmpleado + "', ");
            Sentencia.Append("IDRol = '" + _IDRol + "' ");
            Sentencia.Append("WHERE IDUsuario = " + IDUsuario + "; ");
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
        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion(); // Agregar referencias= Referencias-Agregar referencia
            StringBuilder Sentencia = new StringBuilder(); // Objeto para construir cadenas complejas
            Sentencia.Append("DELETE FROM usuarios ");
            Sentencia.Append("WHERE IDUsuario = " + IDUsuario + ";");
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
        public static string ConvertirContraseña(string cContraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create()) // 'using' asegura que el objeto SHA256 se libere. SHA256.Create() crea una instancia.
            {
                byte[] ConvertirBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cContraseña)); // Convierte la cadena en un arreglo de bytes. Procesa esos bytes y devuelve un arreglo de bytes.

                StringBuilder convertirCadena = new StringBuilder();
                for (int i = 0; i < ConvertirBytes.Length; i++)
                {
                    convertirCadena.Append(ConvertirBytes[i].ToString("x2")); // Convierte cada byte a una cadena hexadecimal usando "x2" que representa los bytes en formato hexadecimal de dos caracteres.
                }
                return convertirCadena.ToString();
            }
        }
        public static bool UsuarioExiste(string oUsuario)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT Usuario FROM Usuarios WHERE Usuario = '" + oUsuario + "';";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado.Rows.Count > 0;
        }

    }
}
