using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;

namespace PupuseriaJenny.Services
{
    internal class DetallePedidoCompraService
    {
        private readonly DBOperacion _dbOperacion;

        public DetallePedidoCompraService()
        {
            _dbOperacion = new DBOperacion();
        }

        public int InsertarDetallePedidoProducto(DetallePedidoProducto detalle)
        {
            string query = "INSERT INTO RG_DetallePedidoProducto (idPedidoCompra, idProducto, cantidadDetallePedidoProducto, precioDetallePedidoProducto) " +
                           "VALUES (@IdPedidoCompra, @IdProducto, @Cantidad, @Precio); SELECT LAST_INSERT_ID();";

            var parametros = new Dictionary<string, object>
    {
        { "@IdPedidoCompra", detalle.IdPedidoCompra },
        { "@IdProducto", detalle.IdProducto },
        { "@Cantidad", detalle.CantidadDetallePedidoProducto },
        { "@Precio", detalle.PrecioDetallePedidoProducto }
    };

            // Ejecutar la sentencia de inserción y obtener el ID insertado
            var resultado = _dbOperacion.Consultar(query, parametros);
            if (resultado.Rows.Count > 0)
            {
                return Convert.ToInt32(resultado.Rows[0][0]); // Retornar el ID insertado
            }

            return 0; // Si no se obtuvo el ID, retornar 0
        }

        public List<DetallePedidoProducto> ObtenerDetallesPedidoProducto(int idPedidoCompra)
        {
            string query = "SELECT * FROM RG_DetallePedidoProducto WHERE idPedidoCompra = @idPedidoCompra";

            var parametros = new Dictionary<string, object>
    {
        { "@idPedidoCompra", idPedidoCompra }
    };

            var detalles = new List<DetallePedidoProducto>();
            var resultado = _dbOperacion.Consultar(query, parametros);

            foreach (DataRow row in resultado.Rows)
            {
                detalles.Add(new DetallePedidoProducto
                {
                    Id = Convert.ToInt32(row["idDetallePedidoProducto"]),
                    IdPedidoCompra = Convert.ToInt32(row["idPedidoCompra"]),
                    IdProducto = Convert.ToInt32(row["idProducto"]),
                    CantidadDetallePedidoProducto = Convert.ToInt32(row["cantidadDetallePedidoProducto"]),
                    PrecioDetallePedidoProducto = Convert.ToDecimal(row["precioDetallePedidoProducto"])
                });
            }

            return detalles;
        }

        public bool EliminarDetallePedidoProducto(int idDetallePedidoProducto)
        {
            string query = "DELETE FROM RG_DetallePedidoProducto WHERE idDetallePedidoProducto = @IdDetalle";

            var parametros = new Dictionary<string, object>
    {
        { "@IdDetalle", idDetallePedidoProducto }
    };

            // Ejecutar la sentencia y devolver true si la cantidad de filas afectadas es mayor a 0
            return _dbOperacion.EjecutarSentencia(query, parametros) > 0;
        }

        /*public int InsertarDetallePedidoIngrediente(DetallePedidoIngrediente detalle)
        {
            string query = "INSERT INTO RG_DetallePedidoIngrediente (idPedidoCompra, idIngrediente, cantidadDetallePedidoIngrediente, precioDetallePedidoIngrediente) " +
                           "VALUES (@IdPedidoCompra, @IdIngrediente, @Cantidad, @Precio); SELECT LAST_INSERT_ID();";

            var parametros = new Dictionary<string, object>
    {
        { "@IdPedidoCompra", detalle.IdPedidoCompra },
        { "@IdIngrediente", detalle.IdIngrediente },
        { "@Cantidad", detalle.CantidadDetallePedidoIngrediente },
        { "@Precio", detalle.PrecioDetallePedidoIngrediente }
    };

            // Ejecutar la sentencia de inserción y obtener el ID insertado
            var resultado = _dbOperacion.Consultar(query, parametros);
            if (resultado.Rows.Count > 0)
            {
                return Convert.ToInt32(resultado.Rows[0][0]); // Retornar el ID insertado
            }

            return 0; // Si no se obtuvo el ID, retornar 0
        }

        public List<DetallePedidoIngrediente> ObtenerDetallesPedidoIngrediente(int idPedidoCompra)
        {
            string query = "SELECT * FROM RG_DetallePedidoIngrediente WHERE idPedidoCompra = @idPedidoCompra";

            var parametros = new Dictionary<string, object>
    {
        { "@idPedidoCompra", idPedidoCompra }
    };

            var detalles = new List<DetallePedidoIngrediente>();
            var resultado = _dbOperacion.Consultar(query, parametros);

            foreach (DataRow row in resultado.Rows)
            {
                detalles.Add(new DetallePedidoIngrediente
                {
                    
                    IdPedidoCompra = Convert.ToInt32(row["idPedidoCompra"]),
                    IdIngrediente = Convert.ToInt32(row["idIngrediente"]),
                    CantidadDetallePedidoIngrediente = Convert.ToInt32(row["cantidadDetallePedidoIngrediente"]),
                    PrecioDetallePedidoIngrediente = Convert.ToDecimal(row["precioDetallePedidoIngrediente"])
                });
            }

            return detalles;
        } */
        public void InsertarDetallePedidoProducto(int idPedidoCompra, int idProducto, decimal cantidad, decimal precio)
        {
            string sentencia = "INSERT INTO RG_DetallePedidoProducto (IdPedidoCompra, IdProducto, CantidadDetallePedidoProducto, PrecioDetallePedidoProducto) " +
                               "VALUES (@IdPedidoCompra, @IdProducto, @Cantidad, @Precio)";

            var parametros = new Dictionary<string, object>
        {
            { "@IdPedidoCompra", idPedidoCompra },
            { "@IdProducto", idProducto },
            { "@Cantidad", cantidad },
            { "@Precio", precio }
        };

            _dbOperacion.EjecutarSentencia(sentencia, parametros);
        }

        // Insertar detalle de ingrediente en el pedido de compra
        public int InsertarDetallePedidoIngrediente(DetallePedidoIngrediente detalleIngrediente)
        {
            string sentencia = "INSERT INTO RG_DetallePedidoIngrediente (idPedidoCompra, idIngrediente, cantidadDetallePedidoIngrediente, precioDetallePedidoIngrediente) " +
                               "VALUES (@IdPedidoCompra, @IdIngrediente, @Cantidad, @Precio)";

            var parametros = new Dictionary<string, object>
    {
        { "@IdPedidoCompra", detalleIngrediente.IdPedidoCompra },
        { "@IdIngrediente", detalleIngrediente.IdIngrediente },
        { "@Cantidad", detalleIngrediente.CantidadDetallePedidoIngrediente },
        { "@Precio", detalleIngrediente.PrecioDetallePedidoIngrediente }
    };

            return _dbOperacion.EjecutarSentencia(sentencia, parametros);
        }


        public bool EliminarDetallePedidoIngrediente(int idDetallePedidoIngrediente)
        {
            string query = "DELETE FROM RG_DetallePedidoIngrediente WHERE idDetallePedidoIngrediente = @IdDetalle";

            var parametros = new Dictionary<string, object>
    {
        { "@IdDetalle", idDetallePedidoIngrediente }
    };

            // Ejecutar la sentencia y devolver true si la cantidad de filas afectadas es mayor a 0
            return _dbOperacion.EjecutarSentencia(query, parametros) > 0;
        }


        // Método para insertar detalle de pedido de producto
        /*ublic int InsertarDetallePedidoProducto(DetallePedidoProducto detalle)
         {
             string query = "INSERT INTO RG_DetallePedidoProducto (idPedidoCompra, idProducto, cantidadDetallePedidoProducto, precioDetallePedidoProducto) " +
                            "VALUES (@IdPedidoCompra, @IdProducto, @Cantidad, @Precio); SELECT LAST_INSERT_ID();";

             var parametros = new List<SqlParameter>
     {
         new SqlParameter("@IdPedidoCompra", SqlDbType.Int) { Value = detalle.IdPedidoCompra },
         new SqlParameter("@IdProducto", SqlDbType.Int) { Value = detalle.IdProducto },
         new SqlParameter("@Cantidad", SqlDbType.Int) { Value = detalle.CantidadDetallePedidoProducto },
         new SqlParameter("@Precio", SqlDbType.Decimal) { Value = detalle.PrecioDetallePedidoProducto }
     };

             return (int)_dbOperacion.EjecutarEscalar(query, parametros); // Asegúrate de que `EjecutarEscalar` devuelva el resultado como `int`.
         }


         // Método para obtener todos los detalles de productos en un pedido
         public List<DetallePedidoProducto> ObtenerDetallesPedidoProducto(int idPedidoCompra)
         {
             string query = "SELECT * FROM RG_DetallePedidoProducto WHERE idPedidoCompra = @idPedidoCompra";

             List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@idPedidoCompra", SqlDbType.Int) { Value = idPedidoCompra }
             };

             // Ejecuta la consulta y devuelve una lista de objetos de tipo RG_DetallePedidoProducto
             return _dbOperacion.ObtenerLista<DetallePedidoProducto>(query, parameters);
         }

         // Método para obtener todos los detalles de ingredientes en un pedido
         public List<DetallePedidoIngrediente> ObtenerDetallesPedidoIngrediente(int idPedidoCompra)
         {
             string query = "SELECT * FROM RG_DetallePedidoIngrediente WHERE idPedidoCompra = @idPedidoCompra";

             List<SqlParameter> parameters = new List<SqlParameter>
             {
                 new SqlParameter("@idPedidoCompra", SqlDbType.Int) { Value = idPedidoCompra }
             };

             // Ejecuta la consulta y devuelve una lista de objetos de tipo RG_DetallePedidoIngrediente
             return _dbOperacion.ObtenerLista<DetallePedidoIngrediente>(query, parameters);
         }

         public bool EliminarDetallePedidoProducto(int idDetallePedidoProducto)
         {
             string query = "DELETE FROM RG_DetallePedidoProducto WHERE idDetallePedidoProducto = @IdDetalle";

             var parametros = new List<SqlParameter>
         {
             new SqlParameter("@IdDetalle", SqlDbType.Int) { Value = idDetallePedidoProducto }
         };

             return _dbOperacion.EjecutarEscalar(query, parametros) > 0;
         }

         public int InsertarDetallePedidoIngrediente(DetallePedidoIngrediente detalle)
         {
             string query = "INSERT INTO RG_DetallePedidoIngrediente (idPedidoCompra, idIngrediente, cantidadDetallePedidoIngrediente, precioDetallePedidoIngrediente) " +
                            "VALUES (@IdPedidoCompra, @IdIngrediente, @Cantidad, @Precio); SELECT LAST_INSERT_ID();";

             var parametros = new List<SqlParameter>
         {
             new SqlParameter("@IdPedidoCompra", SqlDbType.Int) { Value = detalle.IdPedidoCompra },
             new SqlParameter("@IdIngrediente", SqlDbType.Int) { Value = detalle.IdIngrediente },
             new SqlParameter("@Cantidad", SqlDbType.Int) { Value = detalle.CantidadDetallePedidoIngrediente },
             new SqlParameter("@Precio", SqlDbType.Decimal) { Value = detalle.PrecioDetallePedidoIngrediente }
         };

             return (int)_dbOperacion.EjecutarEscalar(query, parametros);
         }

         public bool EliminarDetallePedidoIngrediente(int idDetallePedidoIngrediente)
         {
             string query = "DELETE FROM RG_DetallePedidoIngrediente WHERE idDetallePedidoIngrediente = @IdDetalle";

             var parametros = new List<SqlParameter>
         {
             new SqlParameter("@IdDetalle", SqlDbType.Int) { Value = idDetallePedidoIngrediente }
         };

             return _dbOperacion.EjecutarEscalar(query, parametros) > 0;
         }*/

    }
}
