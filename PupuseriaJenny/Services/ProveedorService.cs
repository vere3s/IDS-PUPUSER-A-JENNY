using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace PupuseriaJenny.Services
{
    
    /// Servicio para gestionar las operaciones relacionadas con los proveedores.
    
    internal class ProveedorService
    {
        private readonly DBOperacion _operacion;

        
        /// Constructor que inicializa la conexión a la base de datos.
        
        public ProveedorService()
        {
            _operacion = new DBOperacion();
        }

        
        /// Inserta un nuevo proveedor en la base de datos.
        
        /// <param name="proveedor">Objeto de tipo Proveedor con los datos a insertar.</param>
        /// <returns>True si la operación fue exitosa; False en caso contrario.</returns>
        public bool Insertar(Proveedor proveedor)
        {
            string sentencia = @"
                INSERT INTO RG_Proveedor 
                (nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor) 
                VALUES 
                (@nombreProveedor, @telefonoProveedor, @direccionProveedor, @emailProveedor);";

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProveedor", proveedor.Nombre },
                    { "@telefonoProveedor", proveedor.Telefono ?? (object)DBNull.Value },
                    { "@direccionProveedor", proveedor.Direccion ?? (object)DBNull.Value },
                    { "@emailProveedor", proveedor.Email ?? (object)DBNull.Value }
                };

                return _operacion.EjecutarSentencia(sentencia, parametros) >= 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar proveedor: " + ex.Message);
                return false;
            }
        }

        
        /// Actualiza un proveedor existente en la base de datos.
       
        /// <param name="proveedor">Objeto de tipo Proveedor con los datos actualizados.</param>
        /// <returns>True si la operación fue exitosa; False en caso contrario.</returns>
        public bool Actualizar(Proveedor proveedor)
        {
            string sentencia = @"
                UPDATE RG_Proveedor 
                SET nombreProveedor = @nombreProveedor, 
                    telefonoProveedor = @telefonoProveedor, 
                    direccionProveedor = @direccionProveedor, 
                    emailProveedor = @emailProveedor 
                WHERE idProveedor = @idProveedor;";

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

                return _operacion.EjecutarSentencia(sentencia, parametros) >= 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar proveedor: " + ex.Message);
                return false;
            }
        }

        
        /// Elimina un proveedor de la base de datos según su ID.
        
        /// <param name="idProveedor">ID del proveedor a eliminar.</param>
        /// <returns>True si la operación fue exitosa; False en caso contrario.</returns>
        public bool Eliminar(int idProveedor)
        {
            string sentencia = "DELETE FROM RG_Proveedor WHERE idProveedor = @idProveedor;";
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", idProveedor }
                };

                return _operacion.EjecutarSentencia(sentencia, parametros) >= 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar proveedor: " + ex.Message);
                return false;
            }
        }

        
        /// Obtiene la lista de todos los proveedores de la base de datos.
        
        /// <returns>Lista de objetos Proveedor.</returns>
        public DataTable ObtenerProveedoresAsDataTable()
        {
            string consulta = @"
        SELECT idProveedor, nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor 
        FROM RG_Proveedor 
        ORDER BY nombreProveedor ASC;";

            try
            {
                // Devolver directamente el DataTable obtenido de la consulta
                return _operacion.Consultar(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener proveedores como DataTable: " + ex.Message);
                return null;
            }
        }


      
        /// Obtiene un proveedor específico por su ID.
        
        /// <param name="idProveedor">ID del proveedor a buscar.</param>
        /// <returns>Objeto Proveedor si se encuentra; null en caso contrario.</returns>
        public Proveedor ObtenerPorId(int idProveedor)
        {
            string sentencia = @"
                SELECT idProveedor, nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor 
                FROM RG_Proveedor 
                WHERE idProveedor = @idProveedor;";

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", idProveedor }
                };

                DataTable tabla = _operacion.Consultar(sentencia, parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    return new Proveedor
                    {
                        IdProveedor = Convert.ToInt32(fila["idProveedor"]),
                        Nombre = fila["nombreProveedor"].ToString(),
                        Telefono = fila["telefonoProveedor"]?.ToString(),
                        Direccion = fila["direccionProveedor"]?.ToString(),
                        Email = fila["emailProveedor"]?.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener proveedor por ID: " + ex.Message);
            }

            return null;
        }


        public DataTable ObtenerProveedor()
        {
            // Sentencia SQL corregida
            string sentencia = "SELECT idProveedor, nombreProveedor, telefonoProveedor, direccionProveedor, emailProveedor FROM RG_Proveedor";
            try
            {
                // Consulta a la base de datos
                DataTable tabla = _operacion.Consultar(sentencia);

                // Verifica si la consulta devolvió datos
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron registros en la tabla de proveedores.");
                    return null;
                }

                return tabla;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al obtener proveedores: " + ex.Message);
                return null;
            }
        }



    }
}
