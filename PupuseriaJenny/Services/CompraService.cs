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

        
        /// Inserta una nueva entrada de compra en la tabla Entradas.
        
        /// <param name="compra">Objeto de tipo Compra que contiene los detalles de la compra.</param>
        /// <returns>True si la inserción fue exitosa; de lo contrario, False.</returns>
        public bool InsertarEntrada(Compra compra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO Entradas (idEmpleado, idPedidoCompra, comentario, total, fecha) ");
            sentencia.Append("VALUES (@idEmpleado, @idPedidoCompra, @comentario, @total, @fecha);");

            try
            {
                // Parámetros para la consulta
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", compra.IdEmpleado },
                    { "@idPedidoCompra", compra.IdPedidoCompra },
                    { "@comentario", compra.Comentario },
                    { "@total", compra.Total },
                    { "@fecha", compra.Fecha }
                };

                // Ejecuta la sentencia y verifica el resultado
                if (_operacion.EjecutarSentencia(sentencia.ToString(), parametros) > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar entrada: " + ex.Message);
            }

            return resultado;
        }

        
        /// Actualiza una entrada existente en la tabla Entradas.
        
        /// <param name="compra">Objeto de tipo Compra con los detalles actualizados.</param>
        /// <returns>True si la actualización fue exitosa; de lo contrario, False.</returns>
        public bool ActualizarEntrada(Compra compra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE Entradas SET ");
            sentencia.Append("idEmpleado = @idEmpleado, ");
            sentencia.Append("idPedidoCompra = @idPedidoCompra, ");
            sentencia.Append("comentario = @comentario, ");
            sentencia.Append("total = @total, ");
            sentencia.Append("fecha = @fecha ");
            sentencia.Append("WHERE idEntrada = @idEntrada;");

            try
            {
                // Parámetros para la consulta
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", compra.IdEmpleado },
                    { "@idPedidoCompra", compra.IdPedidoCompra },
                    { "@comentario", compra.Comentario },
                    { "@total", compra.Total },
                    { "@fecha", compra.Fecha },
                    { "@idEntrada", compra.IdCompra } // idCompra ahora se usa como idEntrada
                };

                // Ejecuta la sentencia y verifica el resultado
                if (_operacion.EjecutarSentencia(sentencia.ToString(), parametros) > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar entrada: " + ex.Message);
            }

            return resultado;
        }

       
        /// Elimina una entrada de la tabla Entradas.
       
        /// <param name="idEntrada">ID de la entrada a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; de lo contrario, False.</returns>
        public bool EliminarEntrada(int idEntrada)
        {
            bool resultado = false;
            string sentencia = "DELETE FROM Entradas WHERE idEntrada = @idEntrada;";

            try
            {
                // Parámetros para la consulta
                var parametros = new Dictionary<string, object>
                {
                    { "@idEntrada", idEntrada }
                };

                // Ejecuta la sentencia y verifica el resultado
                if (_operacion.EjecutarSentencia(sentencia, parametros) > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar entrada: " + ex.Message);
            }

            return resultado;
        }

        
        /// Obtiene una lista de entradas realizadas por un empleado específico.
        
        /// <param name="idEmpleado">ID del empleado.</param>
        /// <returns>Lista de entradas realizadas por el empleado.</returns>
        public List<Compra> ObtenerEntradasPorEmpleado(int idEmpleado)
        {
            List<Compra> entradas = new List<Compra>();
            string consulta = @"SELECT idEntrada, idPedidoCompra, comentario, total, fecha 
                                FROM Entradas 
                                WHERE idEmpleado = @idEmpleado
                                ORDER BY fecha DESC;";

            try
            {
                // Parámetros para la consulta
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", idEmpleado }
                };

                // Ejecuta la consulta y convierte los resultados
                DataTable resultado = _operacion.Consultar(consulta, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    entradas.Add(new Compra
                    {
                        IdCompra = Convert.ToInt32(row["idEntrada"]), // idEntrada mapeado a IdCompra
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
    }
}
