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
        public bool Insertar(Salidas salidas)
        {
            bool resultado = false;
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

        // Método para revertir la salida cuando la orden se cancela
        public bool RevertirSalida(int idProducto, int cantidadSalida)
        {
            bool resultado = false;

            // Iniciar una transacción para asegurar que las operaciones se realicen correctamente
            StringBuilder sentenciaEliminar = new StringBuilder();
            sentenciaEliminar.Append("DELETE FROM RG_Salida WHERE idProducto = @idProducto AND cantidadSalida = @cantidadSalida;");

            try
            {
                var parametrosEliminar = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto },
                    { "@cantidadSalida", cantidadSalida }
                };

                // Eliminar la salida registrada
                if (_operacion.EjecutarSentencia(sentenciaEliminar.ToString(), parametrosEliminar) >= 0)
                {
                    // Luego, incrementar el stock del producto
                    IncrementarStockProducto(idProducto, cantidadSalida);
                    resultado = true;
                }
            }
            catch (Exception)
            {
                resultado = false;
            }

            return resultado;
        }

        // Método para incrementar el stock de un producto
        private void IncrementarStockProducto(int idProducto, int cantidad)
        {
            StringBuilder sentenciaActualizarStock = new StringBuilder();
            sentenciaActualizarStock.Append("UPDATE Productos SET cantidadStock = cantidadStock + @cantidad WHERE idProducto = @idProducto;");

            var parametrosActualizarStock = new Dictionary<string, object>
            {
                { "@idProducto", idProducto },
                { "@cantidad", cantidad }
            };

            // Ejecutar la actualización del stock
            _operacion.EjecutarSentencia(sentenciaActualizarStock.ToString(), parametrosActualizarStock);
        }
    }
}
