using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    public class EmpleadoService
    {
        private readonly DBOperacion _operacion;

        public EmpleadoService()
        {
            _operacion = new DBOperacion();
        }

        public bool Insertar(Empleado empleado)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO Empleados(nombresEmpleado, apellidosEmpleado, telefono, direccion, email, fechaNacimiento, idCargo) ");
            sentencia.Append("VALUES(@nombresEmpleado, @apellidosEmpleado, @telefono, @direccion, @email, @fechaNacimiento, @idCargo);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombresEmpleado", empleado.NombresEmpleado },
                    { "@apellidosEmpleado", empleado.ApellidosEmpleado },
                    { "@telefono", empleado.Telefono },
                    { "@direccion", empleado.Direccion },
                    { "@email", empleado.Email },
                    { "@fechaNacimiento", empleado.FechaNacimiento.ToString("yyyy-MM-dd") },
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
            sentencia.Append("UPDATE Empleados SET ");
            sentencia.Append("nombresEmpleado = @nombresEmpleado, ");
            sentencia.Append("apellidosEmpleado = @apellidosEmpleado, ");
            sentencia.Append("telefono = @telefono, ");
            sentencia.Append("direccion = @direccion, ");
            sentencia.Append("email = @email, ");
            sentencia.Append("fechaNacimiento = @fechaNacimiento, ");
            sentencia.Append("idCargo = @idCargo ");
            sentencia.Append("WHERE idEmpleados = @idEmpleados;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombresEmpleado", empleado.NombresEmpleado },
                    { "@apellidosEmpleado", empleado.ApellidosEmpleado },
                    { "@telefono", empleado.Telefono },
                    { "@direccion", empleado.Direccion },
                    { "@email", empleado.Email },
                    { "@fechaNacimiento", empleado.FechaNacimiento.ToString("yyyy-MM-dd") },
                    { "@idCargo", empleado.IdCargo },
                    { "@idEmpleados", empleado.IdEmpleado }
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

        public bool Eliminar(int idEmpleado)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM Empleados WHERE idEmpleados = @idEmpleados;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleados", idEmpleado }
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