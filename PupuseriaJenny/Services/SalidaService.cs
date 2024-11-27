using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PupuseriaJenny.Services
{
    public class SalidaService
    {
        private readonly DBOperacion _operacion;

        public SalidaService()
        {
            _operacion = new DBOperacion();
        }

        // Método para insertar una nueva salida
        public int Insertar(Salidas salidas)
        {
            int idSalida = -1;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Salida (idProducto, idIngrediente, fechaSalida, cantidadSalida, costoUnitarioSalida) ");
            sentencia.Append("VALUES (@idProducto, @idIngrediente, @fechaSalida, @cantidadSalida, @costoUnitarioSalida);");

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

                idSalida = _operacion.EjecutarSentenciaYObtenerID(sentencia.ToString(), parametros);
            }
            catch (Exception)
            {
                idSalida = -1;
            }
            return idSalida;
        }

        // Método para actualizar una salida existente
        public bool Actualizar(Salidas salidas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Salida SET ");
            sentencia.Append("idProducto = @idProducto, ");
            sentencia.Append("idIngrediente = @idIngrediente, ");
            sentencia.Append("fechaSalida = @fechaSalida, ");
            sentencia.Append("cantidadSalida = @cantidadSalida, ");
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
        public bool Eliminar(int idSalida)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Salida WHERE idSalida = @idSalida;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idSalida", idSalida }
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
