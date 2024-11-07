using System;
using System.Collections.Generic;
using System.Data;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    public class UsuarioService
    {
        public DataTable AutenticarUsuario(string usuario, string contraseña)
        {
            string query = @"
                SELECT 
                    u.IDUsuario, u.Usuario, 
                    e.IDEmpleado, e.Nombre, e.Cargo, e.Telefono, e.Email
                FROM 
                    usuarios u
                INNER JOIN 
                    empleados e ON u.IDEmpleado = e.IDEmpleado
                WHERE 
                    u.Usuario = @Usuario AND 
                    u.Contraseña = @Contraseña;";

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
    }
}
