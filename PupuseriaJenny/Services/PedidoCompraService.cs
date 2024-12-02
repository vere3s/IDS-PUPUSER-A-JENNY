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
       
  
            private readonly DBOperacion _db;

            public PedidoCompraService()
            {
                _db = new DBOperacion();
            }

            // Método para insertar una nueva compra
            public int InsertarCompra(string proveedorId, DateTime fechaCompra, decimal totalCompra)
            {
                string query = @"
            INSERT INTO RG_Compra (idProveedor, fechaCompra, totalCompra)
            VALUES (@idProveedor, @fechaCompra, @totalCompra)";

                var parametros = new Dictionary<string, object>
        {
            { "@idProveedor", proveedorId },
            { "@fechaCompra", fechaCompra },
            { "@totalCompra", totalCompra }
        };

                return _db.EjecutarSentenciaYObtenerID(query, parametros);
            }

            // Método para insertar detalles de una compra
            public int InsertarDetalleCompra(int idCompra, int idProducto, int cantidad, decimal precioUnitario)
            {
                string query = @"
            INSERT INTO RG_DetalleCompra (idCompra, idProducto, cantidad, precioUnitario)
            VALUES (@idCompra, @idProducto, @cantidad, @precioUnitario)";

                var parametros = new Dictionary<string, object>
        {
            { "@idCompra", idCompra },
            { "@idProducto", idProducto },
            { "@cantidad", cantidad },
            { "@precioUnitario", precioUnitario }
        };

                return _db.EjecutarSentencia(query, parametros);
            }

            // Método para consultar compras
            public DataTable ConsultarCompras()
            {
                string query = @"
            SELECT c.idCompra, p.nombre AS proveedor, c.fechaCompra, c.totalCompra
            FROM RG_Compra c
            INNER JOIN RG_Proveedor p ON c.idProveedor = p.idProveedor
            ORDER BY c.fechaCompra DESC";

                return _db.Consultar(query);
            }

            // Método para consultar detalles de una compra específica
            public DataTable ConsultarDetalleCompra(int idCompra)
            {
                string query = @"
            SELECT dc.idDetalle, pr.nombre AS producto, dc.cantidad, dc.precioUnitario, (dc.cantidad * dc.precioUnitario) AS subtotal
            FROM RG_DetalleCompra dc
            INNER JOIN RG_Producto pr ON dc.idProducto = pr.idProducto
            WHERE dc.idCompra = @idCompra";

                var parametros = new Dictionary<string, object>
        {
            { "@idCompra", idCompra }
        };

                return _db.Consultar(query, parametros);
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
                _db.EjecutarSentencia(queryDetalle, parametros);

                // Luego eliminar la compra
                return _db.EjecutarSentencia(queryCompra, parametros);
            }

        public int Insertar(PedidoCompra pedidoCompra)
        {
            string query = @"
        INSERT INTO RG_PedidoCompra (IdProveedor, FechaPedidoCompra, EstadoPedidoCompra) 
        VALUES (@IdProveedor, @FechaPedidoCompra, @EstadoPedidoCompra)";

            var parametros = new Dictionary<string, object>
    {
        { "@IdProveedor", pedidoCompra.IdProveedor },
        { "@FechaPedidoCompra", pedidoCompra.FechaPedidoCompra },
        { "@EstadoPedidoCompra", pedidoCompra.EstadoPedidoCompra }
    };

            return _db.EjecutarSentenciaYObtenerID(query, parametros);
        }

        public int InsertarDetallePedidoProducto(DetallePedidoProducto detalleProducto)
        {
            string query = @"
        INSERT INTO RG_DetallePedidoProducto (IdPedidoCompra, IdProducto, CantidadDetallePedidoProducto, PrecioDetallePedidoProducto)
        VALUES (@IdPedidoCompra, @IdProducto, @CantidadDetallePedidoProducto, @PrecioDetallePedidoProducto)";

            var parametros = new Dictionary<string, object>
    {
        { "@IdPedidoCompra", detalleProducto.IdPedidoCompra },
        { "@IdProducto", detalleProducto.IdProducto },
        { "@CantidadDetallePedidoProducto", detalleProducto.CantidadDetallePedidoProducto },
        { "@PrecioDetallePedidoProducto", detalleProducto.PrecioDetallePedidoProducto }
    };

            return _db.EjecutarSentencia(query, parametros);
        }

        public int InsertarDetallePedidoIngrediente(DetallePedidoIngrediente detalleIngrediente)
        {
            string query = @"
        INSERT INTO RG_DetallePedidoIngrediente (IdPedidoCompra, IdIngrediente, CantidadDetallePedidoIngrediente, PrecioDetallePedidoIngrediente)
        VALUES (@IdPedidoCompra, @IdIngrediente, @CantidadDetallePedidoIngrediente, @PrecioDetallePedidoIngrediente)";

            var parametros = new Dictionary<string, object>
    {
        { "@IdPedidoCompra", detalleIngrediente.IdPedidoCompra },
        { "@IdIngrediente", detalleIngrediente.IdIngrediente },
        { "@CantidadDetallePedidoIngrediente", detalleIngrediente.CantidadDetallePedidoIngrediente },
        { "@PrecioDetallePedidoIngrediente", detalleIngrediente.PrecioDetallePedidoIngrediente }
    };

            return _db.EjecutarSentencia(query, parametros);
        }

        public int InsertarCompra(Compra compra)
        {
            string query = @"
        INSERT INTO RG_Compra (IdEmpleado, IdDetallePedidoProducto, IdDetallePedidoIngrediente, ComentarioCompra, TotalCompra, FechaCompra)
        VALUES (@IdEmpleado, @IdDetallePedidoProducto, @IdDetallePedidoIngrediente, @ComentarioCompra, @TotalCompra, @FechaCompra)";

            var parametros = new Dictionary<string, object>
    {
        { "@IdEmpleado", compra.IdEmpleado },
        { "@IdDetallePedidoProducto", compra.IdDetallePedidoProducto },
        { "@IdDetallePedidoIngrediente", compra.IdDetallePedidoIngrediente },
        { "@ComentarioCompra", compra.ComentarioCompra },
        { "@TotalCompra", compra.TotalCompra },
        { "@FechaCompra", compra.FechaCompra }
    };

            return _db.EjecutarSentenciaYObtenerID(query, parametros);
        }

        public int InsertarEntrada(Entrada entrada)
        {
            string query = @"
        INSERT INTO RG_Entrada (IdProducto, IdIngrediente, IdCompra, FechaEntrada, CantidadEntrada, CostoUnitarioEntrada)
        VALUES (@IdProducto, @IdIngrediente, @IdCompra, @FechaEntrada, @CantidadEntrada, @CostoUnitarioEntrada)";

            var parametros = new Dictionary<string, object>
    {
        { "@IdProducto", entrada.idProducto },
        { "@IdIngrediente", entrada.idIngrediente == 0 ? (object)DBNull.Value : entrada.idIngrediente },
        { "@IdCompra", entrada.idCompra },
        { "@FechaEntrada", entrada.fechaEntrada },
        { "@CantidadEntrada", entrada.cantidadEntrada },
        { "@CostoUnitarioEntrada", entrada.costoUnitarioEntrada }
    };

            return _db.EjecutarSentencia(query, parametros);
        }




    }



    /* public int Insertar(PedidoCompra pedidoCompra)
     {
         try
         {
             string query = "INSERT INTO RG_PedidoCompra (IdProveedor, FechaPedidoCompra, EstadoPedidoCompra) " +
                            "VALUES (@IdProveedor, @FechaPedidoCompra, @EstadoPedidoCompra); SELECT SCOPE_IDENTITY();";

             List<SqlParameter> parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdProveedor", SqlDbType.Int) { Value = pedidoCompra.IdProveedor },
                 new SqlParameter("@FechaPedidoCompra", SqlDbType.DateTime) { Value = pedidoCompra.FechaPedidoCompra },
                 new SqlParameter("@EstadoPedidoCompra", SqlDbType.NVarChar) { Value = pedidoCompra.EstadoPedidoCompra }
             };

             object result = _operacion.ExecuteScalar(query, parametros);
             return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID del pedido de compra generado
         }
         catch (Exception ex)
         {
             MessageBox.Show($"Error al insertar pedido de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return 0;
         }
     }

     public int InsertarDetallePedidoProducto(DetallePedidoProducto detalleProducto)
     {
         try
         {
             string query = "INSERT INTO RG_DetallePedidoProducto (IdPedidoCompra, IdProducto, CantidadDetallePedidoProducto, PrecioDetallePedidoProducto) " +
                            "VALUES (@IdPedidoCompra, @IdProducto, @CantidadDetallePedidoProducto, @PrecioDetallePedidoProducto); " +
                            "SELECT SCOPE_IDENTITY();";

             List<SqlParameter> parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdPedidoCompra", SqlDbType.Int) { Value = detalleProducto.IdPedidoCompra },
                 new SqlParameter("@IdProducto", SqlDbType.Int) { Value = detalleProducto.IdProducto },
                 new SqlParameter("@CantidadDetallePedidoProducto", SqlDbType.Int) { Value = detalleProducto.CantidadDetallePedidoProducto },
                 new SqlParameter("@PrecioDetallePedidoProducto", SqlDbType.Decimal) { Value = detalleProducto.PrecioDetallePedidoProducto }
             };

             object result = _operacion.ExecuteScalar(query, parametros);
             return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID del detalle de pedido de producto generado
         }
         catch (Exception ex)
         {
             MessageBox.Show($"Error al insertar detalle de producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return 0;
         }
     }

     public int InsertarDetallePedidoIngrediente(DetallePedidoIngrediente detalleIngrediente)
     {
         try
         {
             string query = "INSERT INTO RG_DetallePedidoIngrediente (IdPedidoCompra, IdIngrediente, CantidadDetallePedidoIngrediente, PrecioDetallePedidoIngrediente) " +
                            "VALUES (@IdPedidoCompra, @IdIngrediente, @CantidadDetallePedidoIngrediente, @PrecioDetallePedidoIngrediente); " +
                            "SELECT SCOPE_IDENTITY();";

             List<SqlParameter> parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdPedidoCompra", SqlDbType.Int) { Value = detalleIngrediente.IdPedidoCompra },
                 new SqlParameter("@IdIngrediente", SqlDbType.Int) { Value = detalleIngrediente.IdIngrediente },
                 new SqlParameter("@CantidadDetallePedidoIngrediente", SqlDbType.Int) { Value = detalleIngrediente.CantidadDetallePedidoIngrediente },
                 new SqlParameter("@PrecioDetallePedidoIngrediente", SqlDbType.Decimal) { Value = detalleIngrediente.PrecioDetallePedidoIngrediente }
             };

             object result = _operacion.ExecuteScalar(query, parametros);
             return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID del detalle de pedido de ingrediente generado
         }
         catch (Exception ex)
         {
             MessageBox.Show($"Error al insertar detalle de ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return 0;
         }
     }

     public int InsertarCompra(Compra compra)
     {
         try
         {
             string query = "INSERT INTO RG_Compra (IdEmpleado, IdDetallePedidoProducto, IdDetallePedidoIngrediente, ComentarioCompra, TotalCompra, FechaCompra) " +
                            "VALUES (@IdEmpleado, @IdDetallePedidoProducto, @IdDetallePedidoIngrediente, @ComentarioCompra, @TotalCompra, @FechaCompra); " +
                            "SELECT SCOPE_IDENTITY();";

             List<SqlParameter> parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdEmpleado", SqlDbType.Int) { Value = compra.IdEmpleado },
                 new SqlParameter("@IdDetallePedidoProducto", SqlDbType.Int) { Value = compra.IdDetallePedidoProducto },
                 new SqlParameter("@IdDetallePedidoIngrediente", SqlDbType.Int) { Value = compra.IdDetallePedidoIngrediente },
                 new SqlParameter("@ComentarioCompra", SqlDbType.NVarChar) { Value = compra.ComentarioCompra },
                 new SqlParameter("@TotalCompra", SqlDbType.Decimal) { Value = compra.TotalCompra },
                 new SqlParameter("@FechaCompra", SqlDbType.DateTime) { Value = compra.FechaCompra }
             };

             object result = _operacion.ExecuteScalar(query, parametros);
             return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID de la compra generado
         }
         catch (Exception ex)
         {
             MessageBox.Show($"Error al insertar compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return 0;
         }
     }

     public int InsertarEntrada(Entrada entrada)
     {
         try
         {
             string query = "INSERT INTO RG_Entrada (IdProducto, IdIngrediente, IdCompra, FechaEntrada, CantidadEntrada, CostoUnitarioEntrada) " +
                            "VALUES (@IdProducto, @IdIngrediente, @IdCompra, @FechaEntrada, @CantidadEntrada, @CostoUnitarioEntrada); " +
                            "SELECT SCOPE_IDENTITY();";

             List<SqlParameter> parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdProducto", SqlDbType.Int) { Value = entrada.idProducto },
                 new SqlParameter("@IdIngrediente", SqlDbType.Int)
{
 Value = (entrada.idIngrediente == 0) ? (object)DBNull.Value : entrada.idIngrediente
},
// Manejar si el ingrediente es nulo
                 new SqlParameter("@IdCompra", SqlDbType.Int) { Value = entrada.idCompra },
                 new SqlParameter("@FechaEntrada", SqlDbType.DateTime) { Value = entrada.fechaEntrada },
                 new SqlParameter("@CantidadEntrada", SqlDbType.Int) { Value = entrada.cantidadEntrada },
                 new SqlParameter("@CostoUnitarioEntrada", SqlDbType.Decimal) { Value = entrada.costoUnitarioEntrada }
             };

             object result = _operacion.ExecuteScalar(query, parametros);
             return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID de la entrada generado
         }
         catch (Exception ex)
         {
             MessageBox.Show($"Error al insertar entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return 0;
         }
     }



         public decimal CalcularTotales(int idPedidoCompra)
         {
             // Consulta para calcular el total de productos en el pedido
             string queryProductos = @"
         SELECT SUM(Cantidad * Precio) 
         FROM RG_DetallePedidoProducto 
         WHERE IdPedidoCompra = @IdPedidoCompra";

             decimal totalProductos = _operacion.EjecutarConsultaEscalar<decimal>(queryProductos, new { IdPedidoCompra = idPedidoCompra });

             // Consulta para calcular el total de ingredientes en el pedido
             string queryIngredientes = @"
         SELECT SUM(Cantidad * Precio) 
         FROM RG_DetallePedidoIngrediente 
         WHERE IdPedidoCompra = @IdPedidoCompra";

             decimal totalIngredientes = _operacion.EjecutarConsultaEscalar<decimal>(queryIngredientes, new { IdPedidoCompra = idPedidoCompra });

             // Sumar ambos totales
             decimal totalGeneral = totalProductos + totalIngredientes;

             return totalGeneral;
         } */
}










