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
    }
}
