using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.IO.Image.Jpeg2000ImageData;

namespace PupuseriaJenny.Services
{
    public class VentaService
    {
        private readonly DBOperacion _operacion;

        public VentaService()
        {
            _operacion = new DBOperacion();
        }
        public bool Insertar(Ventas ventas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Venta(idEmpleado, idDetalleVenta, totalVenta) VALUES(@idEmpleado, @idDetalleVenta, @totalVenta);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", ventas.IdEmpleado },
                    { "@idDetalleVenta", ventas.IdDetalleVenta },
                    { "@totalVenta", ventas.TotalVenta }
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
        public bool Actualizar(Ventas ventas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Venta SET ");
            sentencia.Append("idEmpleado = @idEmpleado ");
            sentencia.Append("idDetalleVenta = @idDetalleVenta ");
            sentencia.Append("totalVenta = @totalVenta ");
            sentencia.Append("WHERE idVenta = @idVenta;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idEmpleado", ventas.IdEmpleado },
                    { "@idDetalleVenta", ventas.IdDetalleVenta },
                    { "@totalVenta", ventas.TotalVenta },
                    { "@idVenta", ventas.IdVenta }
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

        public bool Eliminar(int idVenta)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Venta WHERE idVenta = @idVenta;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idVenta", idVenta }
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
        public int ObtenerIdVentaPorDetalle(int idDetalleVenta)
        {
            int idVenta = -1;  // Valor por defecto en caso de no encontrar la venta

            // Consulta para obtener el idVenta asociado al idDetalleVenta
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idVenta FROM RG_Venta WHERE idDetalleVenta = @idDetalleVenta");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idDetalleVenta", idDetalleVenta }
                };

                // Ejecuta la consulta
                object resultado = _operacion.EjecutarSentenciaEscalar(sentencia.ToString(), parametros);

                if (resultado != null && int.TryParse(resultado.ToString(), out int venta))
                {
                    idVenta = venta;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el idVenta: {ex.Message}");
                idVenta = -1;
            }
            return idVenta;
        }
        public static DataTable SEGUN_PERIODO_VENTAS(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT o.fechaOrden, o.tipoOrden, e.nombreEmpleado, p.nombreProducto, v.totalVenta
                                FROM RG_Venta v
                                JOIN RG_DetalleVenta dv ON dv.idDetalleVenta = v.idDetalleVenta
                                JOIN RG_Orden o ON o.idOrden = dv.idOrden
                                JOIN RG_Empleado e ON e.idEmpleado = v.idEmpleado
                                JOIN RG_Producto p ON p.idProducto = dv.idProducto
                                WHERE CAST(o.fechaOrden AS DATE) between '"+ pFechaInicio + "' AND '" + pFechaFinal + @"';";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado;
        }

    }
}
