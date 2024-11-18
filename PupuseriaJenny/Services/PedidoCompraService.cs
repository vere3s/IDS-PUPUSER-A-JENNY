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
    internal class PedidoCompraService
    {
        private readonly DBOperacion _operacion;

        public PedidoCompraService()
        {
            _operacion = new DBOperacion();
        }

        public bool Insertar(PedidoCompra pedidoCompra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_PedidoCompra (idProveedor, fechaPedidoCompra, estadoPedidoCompra) ");
            sentencia.Append("VALUES (@idProveedor, @fechaPedidoCompra, @estadoPedidoCompra);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", pedidoCompra.IdProveedor },
                    { "@fechaPedidoCompra", pedidoCompra.FechaPedidoCompra },
                    { "@estadoPedidoCompra", pedidoCompra.EstadoPedidoCompra }
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

        public bool Actualizar(PedidoCompra pedidoCompra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_PedidoCompra SET ");
            sentencia.Append("idProveedor = @idProveedor, ");
            sentencia.Append("fechaPedidoCompra = @fechaPedidoCompra, ");
            sentencia.Append("estadoPedidoCompra = @estadoPedidoCompra ");
            sentencia.Append("WHERE idPedidoCompra = @idPedidoCompra;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", pedidoCompra.IdProveedor },
                    { "@fechaPedidoCompra", pedidoCompra.FechaPedidoCompra },
                    { "@estadoPedidoCompra", pedidoCompra.EstadoPedidoCompra },
                    { "@idPedidoCompra", pedidoCompra.IdPedidoCompra }
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

        public List<PedidoCompra> ObtenerPedidosPorProveedor(int idProveedor)
        {
            List<PedidoCompra> pedidos = new List<PedidoCompra>();
            string consulta = @"SELECT idPedidoCompra, fechaPedidoCompra, estadoPedidoCompra 
                                FROM RG_PedidoCompra 
                                WHERE idProveedor = @idProveedor
                                ORDER BY fechaPedidoCompra DESC;";

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProveedor", idProveedor }
                };

                DataTable resultado = _operacion.Consultar(consulta, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    pedidos.Add(new PedidoCompra
                    {
                        IdPedidoCompra = Convert.ToInt32(row["idPedidoCompra"]),
                        FechaPedidoCompra = Convert.ToDateTime(row["fechaPedidoCompra"]),
                        EstadoPedidoCompra = row["estadoPedidoCompra"].ToString(),
                        IdProveedor = idProveedor
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener pedidos: " + ex.Message);
            }

            return pedidos;
        }
    }
}
