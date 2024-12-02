using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PupuseriaJenny.Services
{
    internal class EntradaService
    {
        private readonly DBOperacion _operacion;

        public EntradaService()
        {
            _operacion = new DBOperacion();
        }

        public int InsertarEntrada(Entrada entrada)
        {
            int idEntrada = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Entrada (idProducto, idIngrediente, idCompra, cantidadEntrada, costoUnitarioEntrada, fechaEntrada) ");
            sentencia.Append("VALUES (@idProducto, @idIngrediente, @idCompra, @cantidadEntrada, @costoUnitarioEntrada, @fechaEntrada); ");
            sentencia.Append("SELECT LAST_INSERT_ID();");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", entrada.idProducto ?? (object)DBNull.Value },
                    { "@idIngrediente", entrada.idIngrediente ?? (object)DBNull.Value },
                    { "@idCompra", entrada.idCompra },
                    { "@cantidadEntrada", entrada.cantidadEntrada },
                    { "@costoUnitarioEntrada", entrada.costoUnitarioEntrada },
                    { "@fechaEntrada", entrada.fechaEntrada }
                };
                // Ejecutar la sentencia y capturar el ID insertado
                idEntrada = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idEntrada = -1;
            }

            return idEntrada;
        }

        public bool EliminarEntrada(int idEntrada)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Entrada WHERE idEntrada = @idEntrada");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEntrada", idEntrada }
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

        public bool InsertarEntradaProducto(int idProducto, decimal cantidad)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Entrada (IdProducto, CantidadEntrada) VALUES (@IdProducto, @Cantidad)");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdProducto", idProducto },
                    { "@Cantidad", cantidad }
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

        // Insertar entrada de ingrediente
        public bool InsertarEntradaIngrediente(int idIngrediente, decimal cantidad)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Entrada (IdIngrediente, CantidadEntrada) VALUES (@IdIngrediente, @Cantidad)");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdIngrediente", idIngrediente },
                    { "@Cantidad", cantidad }
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
        public bool ActualizarEntrada(int idEntrada, int idProducto, int idIngrediente, int idCompra, DateTime fechaEntrada, int cantidadEntrada, decimal costoUnitarioEntrada)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append(@"UPDATE RG_Entrada SET ");
            sentencia.Append("idProducto = @idProducto, ");
            sentencia.Append("idIngrediente = @idIngrediente, ");
            sentencia.Append("idCompra = @idCompra, ");
            sentencia.Append("fechaEntrada = @fechaEntrada, ");
            sentencia.Append("cantidadEntrada = @cantidadEntrada, ");
            sentencia.Append("costoUnitarioEntrada = @costoUnitarioEntrada ");
            sentencia.Append("WHERE idEntrada = @idEntrada;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto },
                    { "@idIngrediente", idIngrediente },
                    { "@idCompra", idCompra },
                    { "@fechaEntrada", fechaEntrada },
                    { "@cantidadEntrada", cantidadEntrada },
                    { "@costoUnitarioEntrada", costoUnitarioEntrada },
                    { "@idEntrada", idEntrada }
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
        public List<Compra> ObtenerEntradasPorEmpleado(int idEmpleado)
        {
            List<Compra> lista = new List<Compra>();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append(@"SELECT e.idEntrada, e.cantidadEntrada, c.totalCompra, c.fechaCompra");
            sentencia.Append("FROM RG_Entrada e ");
            sentencia.Append("INNER JOIN RG_Compra c ON e.idCompra = c.idCompra ");
            sentencia.Append("WHERE c.idEmpleado = @idEmpleado ");
            sentencia.Append("ORDER BY e.fechaEntrada DESC;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", idEmpleado }
                };

                // Llama a Consultar en DBOperacion
                DataTable resultado = _operacion.Consultar(sentencia.ToString(), new Dictionary<string, object>());

                foreach (DataRow row in resultado.Rows)
                {
                    lista.Add(new Compra
                    {
                        IdCompra = Convert.ToInt32(row["idEntrada"]),
                        TotalCompra = Convert.ToDecimal(row["totalCompra"]),
                        FechaCompra = Convert.ToDateTime(row["fechaCompra"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener roles: " + ex.Message);
            }

            return lista;
        }
    }
}
