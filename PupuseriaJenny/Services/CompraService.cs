using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PupuseriaJenny.Forms;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    public class CompraService
    {
        private readonly DBOperacion _operacion;

        public CompraService()
        {
            _operacion = new DBOperacion();
        }

        public bool Insertar(Compra compra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Compra (idEmpleado, idPedidoCompra, comentario, total, fecha) ");
            sentencia.Append("VALUES (@idEmpleado, @idPedidoCompra, @comentario, @total, @fecha);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", compra.IdEmpleado },
                    { "@idPedidoCompra", compra.IdPedidoCompra },
                    { "@comentario", compra.Comentario },
                    { "@total", compra.Total },
                    { "@fecha", compra.Fecha }
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

        public bool Actualizar(Compra compra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Compra SET ");
            sentencia.Append("idEmpleado = @idEmpleado, ");
            sentencia.Append("idPedidoCompra = @idPedidoCompra, ");
            sentencia.Append("comentario = @comentario, ");
            sentencia.Append("total = @total, ");
            sentencia.Append("fecha = @fecha ");
            sentencia.Append("WHERE idCompra = @idCompra;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", compra.IdEmpleado },
                    { "@idPedidoCompra", compra.IdPedidoCompra },
                    { "@comentario", compra.Comentario },
                    { "@total", compra.Total },
                    { "@fecha", compra.Fecha },
                    { "@idCompra", compra.IdCompra }
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

        public bool Eliminar(int idCompra)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Compra WHERE idCompra = @idCompra;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idCompra", idCompra }
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

        public List<Compra> ObtenerComprasPorEmpleado(int idEmpleado)
        {
            List<Compra> compras = new List<Compra>();
            string consulta = @"SELECT idCompra, idPedidoCompra, comentario, total, fecha 
                                FROM RG_Compra 
                                WHERE idEmpleado = @idEmpleado
                                ORDER BY fecha DESC;";

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", idEmpleado }
                };

                DataTable resultado = _operacion.Consultar(consulta, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    compras.Add(new Compra
                    {
                        IdCompra = Convert.ToInt32(row["idCompra"]),
                        IdPedidoCompra = Convert.ToInt32(row["idPedidoCompra"]),
                        Comentario = row["comentario"].ToString(),
                        Total = Convert.ToDecimal(row["total"]),
                        Fecha = Convert.ToDateTime(row["fecha"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener compras: " + ex.Message);
            }

            return compras;
        }
    }
}
