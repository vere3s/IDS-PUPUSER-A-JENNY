using System;
using System.Collections.Generic;
using System.Data;
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

        /// Inserta una nueva entrada de compra en la tabla RG_Entrada.
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
                        IdPedidoCompra = Convert.ToInt32(row["idPedidoCompra"]),
                        Comentario = row["comentario"].ToString(),
                        Total = Convert.ToDecimal(row["total"]),
                        Fecha = Convert.ToDateTime(row["fecha"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener entradas: " + ex.Message);
            }

            return entradas;
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
