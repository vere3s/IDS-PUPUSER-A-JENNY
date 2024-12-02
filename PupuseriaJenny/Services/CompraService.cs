using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    /// Servicio para gestionar las compras y entradas en el sistema.
    public class CompraService
    {
        private readonly DBOperacion _operacion;

        /// Constructor que inicializa la conexión con la base de datos.
        public CompraService()
        {
            _operacion = new DBOperacion();
        }

        public int InsertarCompra(Compra compra)
        {
            int idCompra = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Compra (IdEmpleado, idDetallePedidoProducto, idDetallePedidoIngrediente, TotalCompra, FechaCompra) ");
            sentencia.Append("VALUES (@IdEmpleado, @IdDetallePedidoProducto, @IdDetallePedidoIngrediente, @TotalCompra, @FechaCompra); ");
            sentencia.Append("SELECT LAST_INSERT_ID();");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdEmpleado", compra.IdEmpleado },
                    { "@IdDetallePedidoProducto", compra.IdDetallePedidoProducto },
                    { "@IdDetallePedidoIngrediente", compra.IdDetallePedidoIngrediente },
                    { "@TotalCompra", compra.TotalCompra },
                    { "@FechaCompra", compra.FechaCompra }
                };
                // Ejecutar la sentencia y capturar el ID insertado
                idCompra = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idCompra = -1;
            }

            return idCompra;
        }

        public bool Eliminar(int idCompra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Compra WHERE IdCompra = @IdCompra;");
            
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdCompra", idCompra }
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

        /// Obtiene las entradas para llenar el DataGridView, excluyendo ciertas categorías.
        public DataTable ObtenerEntradasParaDataGrid()
        {
            string consulta = @"SELECT e.idEntrada, e.idPedidoCompra, e.comentario, e.total, e.fecha
                                FROM RG_Entrada e
                                INNER JOIN RG_Producto p ON e.idProducto = p.idProducto
                                INNER JOIN RG_Categoria c ON p.idCategoria = c.idCategoria
                                WHERE c.nombreCategoria NOT IN ('Pupusa de Arroz', 'Pupusa de Maíz');";
            try
            {
                return _operacion.Consultar(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener entradas para el DataGridView: " + ex.Message);
                return null;
            }
        }
        public static DataTable SEGUN_PERIODO_COMPRAS_INGREDIENTES(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT c.fechaCompra, e.nombreEmpleado, i.nombreIngrediente, c.totalCompra
                                FROM RG_Compra c
                                JOIN RG_DetallePedidoIngrediente dpi ON dpi.idDetallePedidoIngrediente = c.idDetallePedidoIngrediente
                                JOIN RG_Empleado e ON e.idEmpleado = c.idEmpleado
                                JOIN RG_Ingrediente i ON i.idIngrediente = dpi.idIngrediente
                                JOIN RG_PedidoCompra pc ON pc.idPedidoCompra = dpi.idPedidoCompra
                                WHERE CAST(c.fechaCompra AS DATE) between '" + pFechaInicio + "' AND '" + pFechaFinal + @"';";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado;
        }
        public static DataTable SEGUN_PERIODO_COMPRAS_PRODUCTOS(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT c.fechaCompra, e.nombreEmpleado, p.nombreProducto, c.totalCompra
                                FROM RG_Compra c
                                JOIN RG_DetallePedidoProducto dpp ON dpp.idDetallePedidoProducto = c.idDetallePedidoProducto
                                JOIN RG_Empleado e ON e.idEmpleado = c.idEmpleado
                                JOIN RG_Producto p ON p.idProducto = dpp.idProducto
                                JOIN RG_PedidoCompra pc ON pc.idPedidoCompra = dpp.idPedidoCompra
                                WHERE CAST(c.fechaCompra AS DATE) between '" + pFechaInicio + "' AND '" + pFechaFinal + @"';";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado;
        }


    }
}
