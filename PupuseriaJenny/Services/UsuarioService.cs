using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    public class UsuarioService
    {
        private readonly DBOperacion _operacion;

        public UsuarioService(DBOperacion operacion = null) // Permitir la inyección opcional
        {
            _operacion = operacion ?? new DBOperacion();  // Si no se inyecta un mock, usar la implementación real.
        }


        public DataTable AutenticarUsuario(string usuario, string contraseña)
        {
            string query = @"
                SELECT 
                  u.IDUsuario, u.Usuario, 
                  e.IDEmpleado, e.nombreEmpleado, e.apellidoEmpleado, e.telefonoEmpleado, e.direccionEmpleado, e.fechaNacimientoEmpleado, e.emailEmpleado, e.idCargo,
                  r.rol, r.idRol
              FROM 
                  rg_usuario u
              INNER JOIN 
                  rg_empleado e ON u.IDEmpleado = e.IDEmpleado
              INNER JOIN 
                  rg_cargo c ON c.idCargo = e.idCargo
              INNER JOIN 
                  rg_rol r ON u.idRol =  r.idRol
                WHERE 
                    u.Usuario = @Usuario AND 
                    u.contraseniaUsuario = @Contraseña;";


            var oOperacion = new DBOperacion();
            var parameters = new Dictionary<string, object>
            {
                { "@Usuario", usuario },
                { "@Contraseña", contraseña }
            };

            try
            {
                // Llamar al método Consultar y obtener el DataTable
                return oOperacion.Consultar(query, parameters);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: devolver un DataTable vacío en caso de error
                throw new Exception("Error al autenticar usuario", ex);
            }
        }

        public bool ValidarUsuario(string usuario, string contraseña, out string mensajeError)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(usuario))
            {
                mensajeError = "El nombre de usuario es obligatorio.";
                return false;
            }

            if (usuario.Contains(" "))
            {
                mensajeError = "El nombre de usuario no puede contener espacios.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                mensajeError = "La contraseña es obligatoria.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }


        public DataTable ObtenerTodos()
        {
            // Construcción de la sentencia SQL
            string sentencia = "SELECT e.idUsuario, e.usuario, e.contraseniaUsuario, e.idRol,e.idEmpleado, r.rol, c.nombreEmpleado FROM RG_Usuario e JOIN RG_Rol r INNER JOIN RG_Empleado c ON e.idRol = r.idRol and e.idEmpleado = c.idEmpleado";
            try
            {
                // Consulta a la base de datos
                DataTable tabla = _operacion.Consultar(sentencia);

                // Verifica si la consulta devolvió datos
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron registros en la tabla de empleados.");
                    return null;
                }

                return tabla;
            }
            catch (Exception ex)
            {
                // Manejo de errores y log de la excepción
                Console.WriteLine("Error al obtener Usuarios: " + ex.Message);
                return null;
            }
        }

        //Obtenemos el usuario por ID 

        public virtual Usuario ObtenerPorId(int idUsuario)
        {
            Usuario usuario = null;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idUsuario, usuario, contraseniaUsuario, idRol, idEmpleado ");
            sentencia.Append("FROM RG_Usuario ");
            sentencia.Append("WHERE idUsuario = @idUsuario;");

            try
            {
                var parametros = new Dictionary<string, object>
        {
            { "@idUsuario", idUsuario }
        };

                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    usuario = new Usuario
                    {
                        IDUsuario = Convert.ToInt32(fila["idUsuario"]),
                        UsuarioNombre = fila["usuario"].ToString(),
                        Contraseña = fila["contraseniaUsuario"].ToString(),
                        IDRol = Convert.ToInt32(fila["idRol"]),
                        IDEmpleado = Convert.ToInt32(fila["idEmpleado"])
                    };
                }
            }
            catch (Exception ex)
            {
                usuario = null;
                Console.WriteLine("Eliminar error es: " + ex.Message);
            }

            return usuario;
        }






        public bool Eliminar(int idUsuario)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Usuario WHERE idUsuario = @idUsuario;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idUsuario", idUsuario }
                };

                if (_operacion.EjecutarSentencia(sentencia.ToString(), parametros) >= 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                resultado = false;
            }

            return resultado;
        }





    }
}
