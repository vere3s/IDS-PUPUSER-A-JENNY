using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    public class EmpleadoService
    {
        private readonly DBOperacion _operacion;

        public EmpleadoService(DBOperacion operacion = null) // Permitir la inyección opcional
        {
            _operacion = operacion ?? new DBOperacion();  // Si no se inyecta un mock, usar la implementación real.
        }


        public bool Insertar(Empleado empleado)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Empleado(nombreEmpleado, apellidoEmpleado, telefonoEmpleado, direccionEmpleado, emailEmpleado, fechaNacimientoEmpleado, idCargo) ");
            sentencia.Append("VALUES(@nombreEmpleado, @apellidoEmpleado, @telefonoEmpleado, @direccionEmpleado, @emailEmpleado, @fechaNacimientoEmpleado, @idCargo);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreEmpleado", empleado.NombreEmpleado },
                    { "@apellidoEmpleado", empleado.ApellidoEmpleado },
                    { "@telefonoEmpelado", empleado.TelefonoEmpleado },
                    { "@direccionEmpleado", empleado.DireccionEmpleado },
                    { "@emailEmpleado", empleado.EmailEmpleado },
                    { "@fechaNacimientoEmpleado", empleado.FechaNacimientoEmpleado.ToString("yyyy-MM-dd") },
                    { "@idCargo", empleado.IdCargo }
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

        public bool Actualizar(Empleado empleado)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Empleado SET ");
            sentencia.Append("nombreEmpleado = @nombreEmpleado, ");
            sentencia.Append("apellidoEmpleado = @apellidoEmpleado, ");
            sentencia.Append("telefonoEmpleado = @telefonoEmpleado, ");
            sentencia.Append("direccionEmpleado = @direccionEmpleado, ");
            sentencia.Append("emailEmpleado = @emailEmpleado, ");
            sentencia.Append("fechaNacimientoEmpleado = @fechaNacimientoEmpleado, ");
            sentencia.Append("idCargo = @idCargo ");
            sentencia.Append("WHERE idEmpleado = @idEmpleado;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreEmpleado", empleado.NombreEmpleado },
                    { "@apellidoEmpleado", empleado.ApellidoEmpleado },
                    { "@telefonoEmpleado", empleado.TelefonoEmpleado },
                    { "@direccionEmpleado", empleado.DireccionEmpleado },
                    { "@emailEmpleado", empleado.EmailEmpleado },
                    { "@fechaNacimientoEmpleado", empleado.FechaNacimientoEmpleado.ToString("yyyy-MM-dd") },
                    { "@idCargo", empleado.IdCargo },
                    { "@idEmpleado", empleado.IdEmpleado }
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

        public virtual Empleado ObtenerPorId(int idEmpleado)
        {
            Empleado empleado = null;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idEmpleado, nombreEmpleado, apellidoEmpleado, telefonoEmpleado, direccionEmpleado, emailEmpleado, fechaNacimientoEmpleado, idCargo ");
            sentencia.Append("FROM RG_Empleado ");
            sentencia.Append("WHERE idEmpleado = @idEmpleado;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", idEmpleado }
                };

                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    empleado = new Empleado
                    {
                        IdEmpleado = Convert.ToInt32(fila["idEmpleado"]),
                        NombreEmpleado = fila["nombreEmpleado"].ToString(),
                        ApellidoEmpleado = fila["apellidoEmpleado"].ToString(),
                        TelefonoEmpleado = fila["telefonoEmpleado"].ToString(),
                        DireccionEmpleado = fila["direccionEmpleado"].ToString(),
                        EmailEmpleado = fila["emailEmpleado"].ToString(),
                        FechaNacimientoEmpleado = Convert.ToDateTime(fila["fechaNacimientoEmpleado"]),
                        IdCargo = Convert.ToInt32(fila["idCargo"])
                    };
                }
            }
            catch (Exception ex)
            {
                empleado = null;

                Console.WriteLine("Eliminar error es"+ex.Message);
            }

            return empleado;
        }

        public DataTable ObtenerTodos()
        {
            // Construcción de la sentencia SQL
            string sentencia = "SELECT e.idEmpleado, e.nombreEmpleado, e.apellidoEmpleado, e.telefonoEmpleado,e.direccionEmpleado, e.emailEmpleado, e.fechaNacimientoEmpleado,e.idCargo, c.cargo FROM RG_Empleado e JOIN RG_Cargo c ON e.idCargo = c.idCargo"; 
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
                Console.WriteLine("Error al obtener empleados: " + ex.Message);
                return null;
            }
        }


        public bool Eliminar(int idEmpleado)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Empleado WHERE idEmpleado = @idEmpleado;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", idEmpleado }
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
