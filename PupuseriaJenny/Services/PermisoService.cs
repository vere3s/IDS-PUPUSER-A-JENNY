using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Services
{

    internal class PermisoService
    {
        private readonly DBOperacion _operacion;

        public PermisoService(DBOperacion operacion = null) // Permitir la inyección opcional
        {
            _operacion = operacion ?? new DBOperacion();  // Si no se inyecta un mock, usar la implementación real.
        }

        public DataTable ObtenerTodos()
        {
            // Construcción de la sentencia SQL
            string sentencia = "SELECT e.idPermiso, e.idRol, e.idOpcion, e.accesoPermiso, o.opcion, r.rol FROM RG_Permiso e JOIN RG_Rol r INNER JOIN RG_Opcion o ON e.idRol = r.idRol and e.idOpcion = o.idOpcion";
            try
            {
                // Consulta a la base de datos
                DataTable tabla = _operacion.Consultar(sentencia);

                // Verifica si la consulta devolvió datos
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron registros en la tabla de Permisos.");
                    return null;
                }

                return tabla;
            }
            catch (Exception ex)
            {
                // Manejo de errores y log de la excepción
                Console.WriteLine("Error al obtener Permisos: " + ex.Message);
                return null;
            }
        }

        //Obtenemos el usuario por ID 

        public virtual Permiso ObtenerPorId(int idPermiso)
        {
            Permiso permiso = null;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idPermiso, idRol, idOpcion, accesoPermiso ");
            sentencia.Append("FROM RG_Permiso ");
            sentencia.Append("WHERE idPermiso = @idPermiso;");

            try
            {
                var parametros = new Dictionary<string, object> { { "@idPermiso", idPermiso } };
                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    permiso = new Permiso
                    {
                        IDPermiso = Convert.ToInt32(fila["idPermiso"]),
                        IDOpcion = Convert.ToInt32(fila["idOpcion"]),
                        IDRol = Convert.ToInt32(fila["idRol"]),
                        Acceso = (AccesoPermiso)Enum.Parse(typeof(AccesoPermiso), fila["accesoPermiso"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                permiso = null;
                Console.WriteLine("Error: " + ex.Message);
            }
            return permiso;
        }

        public bool Eliminar(int idPermiso)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Permiso WHERE idPermiso = @idPermiso;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idPermiso", idPermiso }
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
