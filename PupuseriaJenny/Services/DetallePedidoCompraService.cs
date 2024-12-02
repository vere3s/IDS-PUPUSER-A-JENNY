using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;
using System.Web.Services.Description;

namespace PupuseriaJenny.Services
{
    internal class DetallePedidoCompraService
    {
        private readonly DBOperacion _operacion;

        public DetallePedidoCompraService()
        {
            _operacion = new DBOperacion();
        }

        public int InsertarDetallePedidoProducto(DetallePedidoProducto detalle)
        {
            int idDetalleProducto = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_DetallePedidoProducto (idPedidoCompra, idProducto, cantidadDetallePedidoProducto, precioDetallePedidoProducto) ");
            sentencia.Append("VALUES (@IdPedidoCompra, @IdProducto, @Cantidad, @Precio);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdPedidoCompra", detalle.IdPedidoCompra },
                    { "@IdProducto", detalle.IdProducto },
                    { "@Cantidad", detalle.CantidadDetallePedidoProducto },
                    { "@Precio", detalle.PrecioDetallePedidoProducto }
                };
                // Ejecutar la sentencia y capturar el ID insertado
                idDetalleProducto = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idDetalleProducto = -1;
            }

            return idDetalleProducto;
        }

        public List<DetallePedidoProducto> ObtenerDetallesPedidoProducto(int idPedidoCompra)
        {
            List<DetallePedidoProducto> lista = new List<DetallePedidoProducto>();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT * FROM RG_DetallePedidoProducto WHERE idPedidoCompra = @idPedidoCompra");

            try
            {
                DataTable resultado = _operacion.Consultar(sentencia.ToString(), new Dictionary<string, object>());

                foreach (DataRow row in resultado.Rows)
                {
                    lista.Add(new DetallePedidoProducto
                    {
                        Id = Convert.ToInt32(row["idDetallePedidoProducto"]),
                        IdPedidoCompra = Convert.ToInt32(row["idPedidoCompra"]),
                        IdProducto = Convert.ToInt32(row["idProducto"]),
                        CantidadDetallePedidoProducto = Convert.ToInt32(row["cantidadDetallePedidoProducto"]),
                        PrecioDetallePedidoProducto = Convert.ToDecimal(row["precioDetallePedidoProducto"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener roles: " + ex.Message);
            }

            return lista;
        }

        public bool EliminarDetallePedidoProducto(int idDetallePedidoProducto)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_DetallePedidoProducto WHERE idDetallePedidoProducto = @IdDetalle");

            // Ejecutar la sentencia y devolver true si la cantidad de filas afectadas es mayor a 0
            
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdDetalle", idDetallePedidoProducto }
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

        public bool InsertarDetallePedidoProducto(int idPedidoCompra, int idProducto, decimal cantidad, decimal precio)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_DetallePedidoProducto (IdPedidoCompra, IdProducto, CantidadDetallePedidoProducto, PrecioDetallePedidoProducto) ");
            sentencia.Append("VALUES (@IdPedidoCompra, @IdProducto, @Cantidad, @Precio)");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdPedidoCompra", idPedidoCompra },
                    { "@IdProducto", idProducto },
                    { "@Cantidad", cantidad },
                    { "@Precio", precio }
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

        // Insertar detalle de ingrediente en el pedido de compra
        public int InsertarDetallePedidoIngrediente(DetallePedidoIngrediente detalleIngrediente)
        {
            int idPedidoIngrediente = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_DetallePedidoIngrediente (idPedidoCompra, idIngrediente, cantidadDetallePedidoIngrediente, precioDetallePedidoIngrediente) ");
            sentencia.Append("VALUES (@IdPedidoCompra, @IdIngrediente, @Cantidad, @Precio)");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdPedidoCompra", detalleIngrediente.IdPedidoCompra },
                    { "@IdIngrediente", detalleIngrediente.IdIngrediente },
                    { "@Cantidad", detalleIngrediente.CantidadDetallePedidoIngrediente },
                    { "@Precio", detalleIngrediente.PrecioDetallePedidoIngrediente }
                };

                idPedidoIngrediente = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idPedidoIngrediente = -1;
            }

            return idPedidoIngrediente;
        }


        public bool EliminarDetallePedidoIngrediente(int idDetallePedidoIngrediente)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_DetallePedidoIngrediente WHERE idDetallePedidoIngrediente = @IdDetalle");

            // Ejecutar la sentencia y devolver true si la cantidad de filas afectadas es mayor a 0
           
            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@IdDetalle", idDetallePedidoIngrediente }
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
