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

        public bool InsertarEntrada(int idProducto, int idIngrediente, int idCompra, DateTime fechaEntrada, int cantidadEntrada, decimal costoUnitarioEntrada)
        {
            string sentencia = @"INSERT INTO RG_Entrada (idProducto, idIngrediente, idCompra, fechaEntrada, cantidadEntrada, costoUnitarioEntrada)
                         VALUES (@idProducto, @idIngrediente, @idCompra, @fechaEntrada, @cantidadEntrada, @costoUnitarioEntrada);";
            var parametros = new Dictionary<string, object>
    {
        { "@idProducto", idProducto },
        { "@idIngrediente", idIngrediente },
        { "@idCompra", idCompra },
        { "@fechaEntrada", fechaEntrada },
        { "@cantidadEntrada", cantidadEntrada },
        { "@costoUnitarioEntrada", costoUnitarioEntrada }
    };

            return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
        }

        public int InsertarCompra(Compra compra)
        {
            string sentencia = "INSERT INTO RG_Compra (IdEmpleado, TotalCompra, FechaCompra) " +
                "VALUES (@IdEmpleado, @TotalCompra, @FechaCompra); " +
                "SELECT LAST_INSERT_ID();";

            var parametros = new Dictionary<string, object>
    {
        { "@IdEmpleado", compra.IdEmpleado },
        { "@TotalCompra", compra.TotalCompra },
        { "@FechaCompra", compra.FechaCompra }
    };

            return _operacion.EjecutarSentenciaYObtenerID(sentencia, parametros);
        }

        public bool Eliminar(int idCompra)
        {
            string sentencia = "DELETE FROM RG_Compra WHERE IdCompra = @IdCompra;";
            var parametros = new Dictionary<string, object>
    {
        { "@IdCompra", idCompra }
    };

            return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
        }

        public bool ActualizarEntrada(int idEntrada, int idProducto, int idIngrediente, int idCompra, DateTime fechaEntrada, int cantidadEntrada, decimal costoUnitarioEntrada)
        {
            string sentencia = @"UPDATE RG_Entrada 
                         SET idProducto = @idProducto,
                             idIngrediente = @idIngrediente,
                             idCompra = @idCompra,
                             fechaEntrada = @fechaEntrada,
                             cantidadEntrada = @cantidadEntrada,
                             costoUnitarioEntrada = @costoUnitarioEntrada
                         WHERE idEntrada = @idEntrada;";

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

            return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
        }
        public List<Compra> ObtenerEntradasPorEmpleado(int idEmpleado)
        {
            string consulta = @"SELECT e.idEntrada, e.cantidadEntrada, c.totalCompra, c.fechaCompra
                        FROM RG_Entrada e
                        INNER JOIN RG_Compra c ON e.idCompra = c.idCompra
                        WHERE c.idEmpleado = @idEmpleado
                        ORDER BY e.fechaEntrada DESC;";

            var parametros = new Dictionary<string, object>
    {
        { "@idEmpleado", idEmpleado }
    };

            var entradas = new List<Compra>();
            DataTable resultado = _operacion.Consultar(consulta, parametros);

            foreach (DataRow row in resultado.Rows)
            {
                entradas.Add(new Compra
                {
                    IdCompra = Convert.ToInt32(row["idEntrada"]),
                    TotalCompra = Convert.ToDecimal(row["totalCompra"]),
                    FechaCompra = Convert.ToDateTime(row["fechaCompra"])
                });
            }

            return entradas;
        }


        public void InsertarCompra(int idPedidoCompra, DateTime fechaCompra)
        {
            string sentencia = "INSERT INTO RG_Compra (IdPedidoCompra, FechaCompra) VALUES (@IdPedidoCompra, @FechaCompra)";

            var parametros = new Dictionary<string, object>
        {
            { "@IdPedidoCompra", idPedidoCompra },
            { "@FechaCompra", fechaCompra }
        };

            _operacion.EjecutarSentencia(sentencia, parametros);
        }


        /// Inserta una nueva entrada de compra en la tabla RG_Entrada.
        /*ublic bool InsertarEntrada(int idProducto, int idIngrediente, int idCompra, DateTime fechaEntrada, int cantidadEntrada, decimal costoUnitarioEntrada)
         {
             string sentencia = @"INSERT INTO RG_Entrada (idProducto, idIngrediente, idCompra, fechaEntrada, cantidadEntrada, costoUnitarioEntrada)
                                  VALUES (@idProducto, @idIngrediente, @idCompra, @fechaEntrada, @cantidadEntrada, @costoUnitarioEntrada);";
             var parametros = new Dictionary<string, object>
             {
                 { "@idProducto", idProducto },
                 { "@idIngrediente", idIngrediente },
                 { "@idCompra", idCompra },
                 { "@fechaEntrada", fechaEntrada },
                 { "@cantidadEntrada", cantidadEntrada },
                 { "@costoUnitarioEntrada", costoUnitarioEntrada }
             };

             try
             {
                 return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al insertar entrada: " + ex.Message);
                 return false;
             }
         }



         public int InsertarCompra(Compra compra)
         {
             string query = @"INSERT INTO RG_Compra (IdEmpleado, TotalCompra, FechaCompra) 
                              OUTPUT INSERTED.IdCompra
                              VALUES (@IdEmpleado, @TotalCompra, @FechaCompra)";

             var parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdEmpleado", compra.IdEmpleado),
                 new SqlParameter("@TotalCompra", compra.TotalCompra),
                 new SqlParameter("@FechaCompra", compra.FechaCompra)
             };

             return _operacion.EjecutarEscalar(query, parametros);
         }

         public bool Eliminar(int idCompra)
         {
             string query = "DELETE FROM RG_Compra WHERE IdCompra = @IdCompra";
             var parametros = new List<SqlParameter>
             {
                 new SqlParameter("@IdCompra", idCompra)
             };

             return _operacion.EjecutarEscalar(query, parametros) > 0;
         }

         /// Actualiza una entrada existente en la tabla RG_Entrada.
         public bool ActualizarEntrada(int idEntrada, int idProducto, int idIngrediente, int idCompra, DateTime fechaEntrada, int cantidadEntrada, decimal costoUnitarioEntrada)
         {
             string sentencia = @"UPDATE RG_Entrada 
                                  SET idProducto = @idProducto, 
                                      idIngrediente = @idIngrediente, 
                                      idCompra = @idCompra, 
                                      fechaEntrada = @fechaEntrada, 
                                      cantidadEntrada = @cantidadEntrada, 
                                      costoUnitarioEntrada = @costoUnitarioEntrada 
                                  WHERE idEntrada = @idEntrada;";
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

             try
             {
                 return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al actualizar entrada: " + ex.Message);
                 return false;
             }
         }

         /// Elimina una entrada de la tabla RG_Entrada.
         public bool EliminarEntrada(int idEntrada)
         {
             string sentencia = "DELETE FROM RG_Entrada WHERE idEntrada = @idEntrada;";
             var parametros = new Dictionary<string, object>
             {
                 { "@idEntrada", idEntrada }
             };

             try
             {
                 return _operacion.EjecutarSentencia(sentencia, parametros) > 0;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al eliminar entrada: " + ex.Message);
                 return false;
             }
         }

         /// Obtiene una lista de entradas realizadas por un empleado específico.
         public List<Compra> ObtenerEntradasPorEmpleado(int idEmpleado)
         {
             string consulta = @"SELECT e.idEntrada, e.idPedidoCompra, e.comentario, e.total, e.fecha 
                                 FROM RG_Entrada e
                                 INNER JOIN RG_Compra c ON e.idCompra = c.idCompra
                                 WHERE c.idEmpleado = @idEmpleado
                                 ORDER BY e.fechaEntrada DESC;";
             var parametros = new Dictionary<string, object> { { "@idEmpleado", idEmpleado } };
             List<Compra> entradas = new List<Compra>();

             try
             {
                 DataTable resultado = _operacion.Consultar(consulta, parametros);
                 foreach (DataRow row in resultado.Rows)
                 {
                     entradas.Add(new Compra
                     {
                         IdCompra = Convert.ToInt32(row["idEntrada"]),

                          TotalCompra = Convert.ToDecimal(row["total"]),
                          FechaCompra = Convert.ToDateTime(row["fecha"])
                     });
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al obtener entradas: " + ex.Message);
             }

             return entradas;
         }

         public int InsertarCompra(int idProveedor,
                                   DateTime fechaCompra,
                                   List<DetalleCompras> detallesCompra)
         {
             // Sentencia SQL para insertar en RG_Compra
             string sentenciaCompra = "INSERT INTO RG_Compra (idProveedor, fechaCompra) VALUES (@idProveedor, @fechaCompra)";

             var parametrosCompra = new Dictionary<string, object>
     {
         { "@idProveedor", idProveedor },
         { "@fechaCompra", fechaCompra }
     }; 

        // Ejecutar la sentencia para insertar la compra y obtener el ID de la compra recién insertada
        int idCompra = _operacion.EjecutarSentenciaYObtenerID(sentenciaCompra, parametrosCompra);

            if (idCompra > 0) // Si la compra fue insertada correctamente
            {
                // Insertar los detalles de la compra en RG_DetallePedidoProducto y RG_DetallePedidoIngrediente
                foreach (var detalle in detallesCompra)
                {
                    // Insertar en la tabla RG_DetallePedidoProducto (Si es un producto)
                    if (detalle.Tipo == "Producto")
                    {
                        string sentenciaProducto = "INSERT INTO RG_DetallePedidoProducto (idCompra, idProducto, cantidadProducto, costoUnitarioProducto) " +
                                                   "VALUES (@idCompra, @idProducto, @cantidadProducto, @costoUnitarioProducto)";
                        var parametrosProducto = new Dictionary<string, object>
                {
                    { "@idCompra", idCompra },
                    { "@idProducto", detalle.IdProducto },
                    { "@cantidadProducto", detalle.Cantidad },
                    { "@costoUnitarioProducto", detalle.CostoUnitario }
                };
                        _operacion.EjecutarSentencia(sentenciaProducto, parametrosProducto);

                        // Actualizar el Kardex con la entrada de los productos
                        string sentenciaKardexProducto = "INSERT INTO RG_Kardex (idProducto, fechaMovimientoKardex, idEntrada, cantidadKardex, costoUnitarioKardex, saldoCantidadKardex, saldoValorKardex) " +
                                                         "VALUES (@idProducto, @fechaCompra, @idCompra, @cantidad, @costoUnitario, @cantidad, (@cantidad * @costoUnitario))";
                        var parametrosKardexProducto = new Dictionary<string, object>
                {
                    { "@idProducto", detalle.IdProducto },
                    { "@fechaCompra", fechaCompra },
                    { "@idCompra", idCompra },
                    { "@cantidad", detalle.Cantidad },
                    { "@costoUnitario", detalle.CostoUnitario }
                };
                        _operacion.EjecutarSentencia(sentenciaKardexProducto, parametrosKardexProducto);
                    }

                    // Insertar en la tabla RG_DetallePedidoIngrediente (Si es un ingrediente)
                    if (detalle.Tipo == "Ingrediente")
                    {
                        string sentenciaIngrediente = "INSERT INTO RG_DetallePedidoIngrediente (idCompra, idIngrediente, cantidadIngrediente, costoUnitarioIngrediente) " +
                                                      "VALUES (@idCompra, @idIngrediente, @cantidadIngrediente, @costoUnitarioIngrediente)";
                        var parametrosIngrediente = new Dictionary<string, object>
                {
                    { "@idCompra", idCompra },
                    { "@idIngrediente", detalle.IdIngrediente },
                    { "@cantidadIngrediente", detalle.Cantidad },
                    { "@costoUnitarioIngrediente", detalle.CostoUnitario }
                };
                        _operacion.EjecutarSentencia(sentenciaIngrediente, parametrosIngrediente);

                        // Actualizar el Kardex con la entrada de los ingredientes
                        string sentenciaKardexIngrediente = "INSERT INTO RG_Kardex (idIngrediente, fechaMovimientoKardex, idEntrada, cantidadKardex, costoUnitarioKardex, saldoCantidadKardex, saldoValorKardex) " +
                                                            "VALUES (@idIngrediente, @fechaCompra, @idCompra, @cantidad, @costoUnitario, @cantidad, (@cantidad * @costoUnitario))";
                        var parametrosKardexIngrediente = new Dictionary<string, object>
                {
                    { "@idIngrediente", detalle.IdIngrediente },
                    { "@fechaCompra", fechaCompra },
                    { "@idCompra", idCompra },
                    { "@cantidad", detalle.Cantidad },
                    { "@costoUnitario", detalle.CostoUnitario }
                };
                        _operacion.EjecutarSentencia(sentenciaKardexIngrediente, parametrosKardexIngrediente);
                    }
                }

                return idCompra; // Retorna el ID de la compra insertada
            }

            return -1; // Si no se pudo insertar la compra
        }
        */

        public int InsertarCompra(int idProveedor, DateTime fechaCompra, List<DetalleCompras> detallesCompra)
        {
            string sentenciaCompra = @"INSERT INTO RG_Compra (idProveedor, fechaCompra)
                               OUTPUT INSERTED.IdCompra
                               VALUES (@idProveedor, @fechaCompra);";

            var parametrosCompra = new Dictionary<string, object>
    {
        { "@idProveedor", idProveedor },
        { "@fechaCompra", fechaCompra }
    };

            int idCompra = _operacion.EjecutarSentenciaYObtenerID(sentenciaCompra, parametrosCompra);

            if (idCompra > 0)
            {
                foreach (var detalle in detallesCompra)
                {
                    string sentenciaDetalle = @"INSERT INTO RG_DetalleCompra (idCompra, idProducto, cantidad, precio)
                                        VALUES (@idCompra, @idProducto, @cantidad, @precio);";

                    var parametrosDetalle = new Dictionary<string, object>
            {
                { "@idCompra", idCompra },
                { "@idProducto", detalle.IdProducto },
                { "@cantidad", detalle.Cantidad },
                { "@precio", detalle.precioDetalle }
            };

                    if (_operacion.EjecutarSentencia(sentenciaDetalle, parametrosDetalle) <= 0)
                    {
                        throw new Exception("Error al insertar detalle de la compra.");
                    }
                }
            }

            return idCompra;
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

       
    }
}
