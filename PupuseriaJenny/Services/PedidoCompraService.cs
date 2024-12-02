using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PupuseriaJenny.Services
{
    internal class PedidoCompraService
    {
        private readonly DBOperacion _operacion;

        public PedidoCompraService()
        {
            _operacion = new DBOperacion();
        }

        // Método para insertar detalles de una compra
        public int InsertarDetalleCompra(int idCompra, int idProducto, int cantidad, decimal precioUnitario)
        {
            int idDetalleCompra = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_DetalleCompra (idCompra, idProducto, cantidad, precioUnitario) ");
            sentencia.Append("VALUES(@idCompra, @idProducto, @cantidad, @precioUnitario)");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idCompra", idCompra },
                    { "@idProducto", idProducto },
                    { "@cantidad", cantidad },
                    { "@precioUnitario", precioUnitario }
                };
                // Ejecutar la sentencia y capturar el ID insertado
                idDetalleCompra = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idDetalleCompra = -1;
            }

            return idDetalleCompra;
        }

        // Método para consultar compras
        public DataTable ConsultarCompras()
        {
            string query = @"ELECT c.idCompra, p.nombre AS proveedor, c.fechaCompra, c.totalCompra
                            FROM RG_Compra c
                            INNER JOIN RG_Proveedor p ON c.idProveedor = p.idProveedor
                            ORDER BY c.fechaCompra DESC";

            return _operacion.Consultar(query);
        }

        // Método para consultar detalles de una compra específica
        public DataTable ConsultarDetalleCompra(int idCompra)
        {
            string query = @"SELECT dc.idDetalle, pr.nombre AS producto, dc.cantidad, dc.precioUnitario, (dc.cantidad * dc.precioUnitario) AS subtotal
                            FROM RG_DetalleCompra dc
                            INNER JOIN RG_Producto pr ON dc.idProducto = pr.idProducto
                            WHERE dc.idCompra = @idCompra";

            var parametros = new Dictionary<string, object>
            {
                { "@idCompra", idCompra }
            };

            return _operacion.Consultar(query, parametros);
        }

        // Método para eliminar una compra y sus detalles asociados
        public int EliminarCompra(int idCompra)
        {
            string queryDetalle = "DELETE FROM RG_DetalleCompra WHERE idCompra = @idCompra";
            string queryCompra = "DELETE FROM RG_Compra WHERE idCompra = @idCompra";

            var parametros = new Dictionary<string, object>
            {
                { "@idCompra", idCompra }
            };

            // Eliminar primero los detalles
            _operacion.EjecutarSentencia(queryDetalle, parametros);

            // Luego eliminar la compra
            return _operacion.EjecutarSentencia(queryCompra, parametros);
        }

        public int Insertar(PedidoCompra pedidoCompra)
        {
            int idPedidoCompra = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_PedidoCompra (IdProveedor, FechaPedidoCompra, EstadoPedidoCompra) ");
            sentencia.Append("VALUES (@IdProveedor, @FechaPedidoCompra, @EstadoPedidoCompra)");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdProveedor", pedidoCompra.IdProveedor },
                    { "@FechaPedidoCompra", pedidoCompra.FechaPedidoCompra },
                    { "@EstadoPedidoCompra", pedidoCompra.EstadoPedidoCompra }
                };
                // Ejecutar la sentencia y capturar el ID insertado
                idPedidoCompra = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idPedidoCompra = -1;
            }

            return idPedidoCompra;
        }
        public bool EstadoPedido(int idPedidoCompra, string estado)
        {
            string sentencia = "UPDATE RG_PedidoCompra SET estadoPedidoCompra = @estado WHERE idPedidoCompra = @idPedidoCompra;";
            var parametros = new Dictionary<string, object>
            {
                { "@estado", estado },
                { "@idPedidoCompra", idPedidoCompra }
            };

            return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
        }
        public bool Eliminar(int idPedidoCompra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_PedidoCompra WHERE idPedidoCompra = @idPedidoCompra;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idPedidoCompra", idPedidoCompra }
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










