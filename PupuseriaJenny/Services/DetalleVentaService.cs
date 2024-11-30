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
    public class DetalleVentaService
    {
        private readonly DBOperacion _operacion;

        public DetalleVentaService()
        {
            _operacion = new DBOperacion();
        }

        public int Insertar(DetallesVentas detallesVentas)
        {
            int idDetalleVenta = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_DetalleVenta(idOrden, idProducto, cantidadDetalleVenta, subTotalDetalleVenta) ");
            sentencia.Append("VALUES(@idOrden, @idProducto, @cantidadDetalleVenta, @subTotalDetalleVenta);");
            sentencia.Append("SELECT LAST_INSERT_ID();");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idOrden", detallesVentas.IdOrden },
                    { "@idProducto", detallesVentas.IdProducto },
                    { "@cantidadDetalleVenta", detallesVentas.CantidadDetalleVenta },
                    { "@subTotalDetalleVenta", detallesVentas.SubTotalDetalleVenta }
                };
                // Ejecutar la sentencia y capturar el ID insertado
                idDetalleVenta = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idDetalleVenta = -1;
            }

            return idDetalleVenta;
        }

        public bool Actualizar(DetallesVentas detallesVentas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_DetalleVenta SET ");
            sentencia.Append("idOrden = @idOrden, ");
            sentencia.Append("idProducto = @idProducto, ");
            sentencia.Append("cantidadDetalleVenta = @cantidadDetalleVenta, ");
            sentencia.Append("subTotalDetalleVenta = @subTotalDetalleVenta ");
            sentencia.Append("WHERE idDetalleVenta = @idDetalleVenta;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idOrden", detallesVentas.IdOrden },
                    { "@idProducto", detallesVentas.IdProducto },
                    { "@cantidadDetalleVenta", detallesVentas.CantidadDetalleVenta },
                    { "@subTotalDetalleVenta", detallesVentas.SubTotalDetalleVenta },
                    { "@idDetalleVenta", detallesVentas.IdDetalleVenta }
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

        public bool Eliminar(int idDetalleVenta)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_DetalleVenta WHERE idDetalleVenta = @idDetalleVenta;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idDetalleVenta", idDetalleVenta }
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
        public DataTable ObtenerDetallesPorOrdenPendiente(int idOrden)
        {
            DataTable resultado = new DataTable();
            string consulta = @"SELECT dv.idDetalleVenta, s.idSalida, dv.idProducto, p.nombreProducto, dv.cantidadDetalleVenta, p.precioProducto, dv.subTotalDetalleVenta
                            FROM RG_DetalleVenta dv
                            JOIN RG_Producto p ON p.idProducto = dv.idProducto
                            JOIN RG_Salida s ON s.idSalida = dv.idDetalleVenta
                            WHERE dv.idOrden = @idOrden;";

            try
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    { "@idOrden", idOrden }
                };

                resultado = _operacion.Consultar(consulta, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los productos de la orden pendiente: " + ex.Message);
            }

            return resultado;
        }
    }
}
