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
    internal class ProveedorService
    {
        private readonly DBOperacion _operacion;

        public ProveedorService()
        {
            _operacion = new DBOperacion();
        }

        public bool Insertar(Proveedor proveedor)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Proveedor (nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor) ");
            sentencia.Append("VALUES (@nombreProveedor, @telefonoProveedor, @direccionProveedor, @emailProveedor);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProveedor", proveedor.Nombre },
                    { "@telefonoProveedor", proveedor.Telefono ?? (object)DBNull.Value },
                    { "@direccionProveedor", proveedor.Direccion ?? (object)DBNull.Value },
                    { "@emailProveedor", proveedor.Email ?? (object)DBNull.Value }
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

        public bool Actualizar(Proveedor proveedor)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Proveedor SET ");
            sentencia.Append("nombreProveedor = @nombreProveedor, ");
            sentencia.Append("telefonoProveedor = @telefonoProveedor, ");
            sentencia.Append("direccionProveedor = @direccionProveedor, ");
            sentencia.Append("emailProveedor = @emailProveedor ");
            sentencia.Append("WHERE idProveedor = @idProveedor;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProveedor", proveedor.Nombre },
                    { "@telefonoProveedor", proveedor.Telefono ?? (object)DBNull.Value },
                    { "@direccionProveedor", proveedor.Direccion ?? (object)DBNull.Value },
                    { "@emailProveedor", proveedor.Email ?? (object)DBNull.Value },
                    { "@idProveedor", proveedor.IdProveedor }
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

        public bool Eliminar(int idProveedor)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Proveedor WHERE idProveedor = @idProveedor;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", idProveedor }
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
        // obtener lista
        public List<Proveedor> ObtenerProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            string consulta = @"SELECT idProveedor, nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor 
                                FROM RG_Proveedor 
                                ORDER BY nombreProveedor ASC;";

            try
            {
                DataTable resultado = _operacion.Consultar(consulta);

                foreach (DataRow row in resultado.Rows)
                {
                    proveedores.Add(new Proveedor
                    {
                        IdProveedor = Convert.ToInt32(row["idProveedor"]),
                        Nombre = row["nombreProveedor"].ToString(),
                        Telefono = row["telefonoProveedor"] == DBNull.Value ? null : row["telefonoProveedor"].ToString(),
                        Direccion = row["direccionProveedor"] == DBNull.Value ? null : row["direccionProveedor"].ToString(),
                        Email = row["emailProveedor"] == DBNull.Value ? null : row["emailProveedor"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener proveedores: " + ex.Message);
            }

            return proveedores;
        }
        //obtener por ID
        public virtual Proveedor ObtenerPorId(int IdProveedor)
        {
            Proveedor proveedor = null;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idProveedor, nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor");
            sentencia.Append("FROM  RG_Proveedor ");
            sentencia.Append("WHERE idProveedor = @idProveedor;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", IdProveedor }
                };

                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    proveedor = new Proveedor
                    {
                        IdProveedor = Convert.ToInt32(fila["IdProveedor"]),
                        Nombre = fila["nombreProveedor"].ToString(),
                        Telefono = fila["telefonoProveedor"].ToString(),
                        Direccion = fila["direccionProveedor"].ToString(),
                        Email = fila["emailProveedor"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                proveedor = null;

                Console.WriteLine("Eliminar error es" + ex.Message);
            }

            return proveedor;
        }

        //Siguinete metodo
        public DataTable ObtenerTodos()
        {
            // Construcción de la sentencia SQL
            string sentencia = @"
        SELECT 
            e.idProveedor AS IdProveedor,
            e.nombreProveedor AS NombreProveedor,
            COALESCE(e.telefonoProveedor, 'No especificado') AS TelefonoProveedor,
            COALESCE(e.emailProveedor, 'No especificado') AS EmailProveedor,
        FROM 
            RG_Proveedor e  
        ORDER BY 
            e.nombreProveedor ASC;";
            try
            {
                // Consulta a la base de datos
                DataTable tabla = _operacion.Consultar(sentencia);

                // Verifica si la consulta devolvió datos
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron registros en la tabla de Proveedores.");
                    return null;
                }

                return tabla;
            }
            catch (Exception ex)
            {
                // Manejo de errores y log de la excepción
                Console.WriteLine("Error al obtener Proveedores: " + ex.Message);
                return null;
            }
        }


        public bool EliminarProveedor(int idProveedor)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Proveedor WHERE idProveedor = @idProveedor;");

            try
            {
                // Define los parámetros para la consulta
                var parametros = new Dictionary<string, object>
        {
            { "@idProveedor", idProveedor }
        };

                // Ejecuta la sentencia y verifica el resultado
                if (_operacion.EjecutarSentencia(sentencia.ToString(), parametros) >= 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, registra la excepción si es necesario
                Console.WriteLine("Error al eliminar el proveedor: " + ex.Message);
                resultado = false;
            }

            return resultado;
        }

    }
}
