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
    }
}
