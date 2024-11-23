using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Services
{
    public class SalidaService
    {
        private readonly DBOperacion _operacion;

        public SalidaService()
        {
            _operacion = new DBOperacion();
        }
        public bool Insertar(Salidas salidas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Salida (idProducto, idIngrediente, fechaSalida, cantidadSalida, costoUnitarioSalida) VALUES (@idProducto, @idIngrediente, @fechaSalida, @cantidadSalida, @costoUnitarioSalida);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", salidas.IdProducto ?? (object)DBNull.Value },
                    { "@idIngrediente", salidas.IdIngrediente ?? (object)DBNull.Value },
                    { "@fechaSalida", salidas.FechaSalida.ToString("yyyy-MM-dd") },
                    { "@cantidadSalida", salidas.CantidadSalida },
                    { "@costoUnitarioSalida", salidas.CostoUnitarioSalida }
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
        public bool Actualizar(Salidas salidas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Salida SET ");
            sentencia.Append("idProducto = @idProducto ");
            sentencia.Append("idIngrediente = @idIngrediente ");
            sentencia.Append("fechaSalida = @fechaSalida ");
            sentencia.Append("cantidadSalida = @cantidadSalida ");
            sentencia.Append("costoUnitarioSalida = @costoUnitarioSalida ");
            sentencia.Append("WHERE idSalida = @idSalida;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", salidas.IdProducto },
                    { "@idIngrediente", salidas.IdIngrediente },
                    { "@fechaSalida", salidas.FechaSalida },
                    { "@cantidadSalida", salidas.CantidadSalida },
                    { "@costoUnitarioSalida", salidas.CostoUnitarioSalida }
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
