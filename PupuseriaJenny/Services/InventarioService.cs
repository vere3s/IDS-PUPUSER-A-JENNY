using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.CLS
{
    public class InventarioService
    {
        public InventarioService()
        {
            _operacion = new DBOperacion();
        }
        private readonly DBOperacion _operacion;
        public int idInventario { get; set; }
        public int idProducto { get; set; }
        public int idIngrediente { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public string tipoMovimiento { get; set; } // "Entrada" o "Salida"
        public int cantidad { get; set; }
        public decimal costoUnitario { get; set; }
        public int saldoCantidad { get; set; }
        public decimal saldoValor { get; set; }
        public List<Kardex> ObtenerKardexPorProductoYPeriodo(int idProducto, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Kardex> kardexList = new List<Kardex>();

            // Consulta SQL para obtener los registros de Kardex por idProducto y entre un rango de fechas
            string sentencia = @"
        SELECT 
            k.idKardex,
            k.idProducto,
            k.idIngrediente,
            k.fechaMovimientoKardex,
            k.tipoMovimientoKardex,
            k.cantidadKardex,
            k.costoUnitarioKardex,
            k.saldoCantidadKardex,
            k.saldoValorKardex
        FROM 
            RG_Kardex k
        WHERE 
            k.idProducto = @idProducto
            AND k.fechaMovimientoKardex BETWEEN @fechaInicio AND @fechaFin
        ORDER BY 
            k.fechaMovimientoKardex DESC
        LIMIT 300;";

            try
            {
                // Parámetros para la consulta
                var parametros = new Dictionary<string, object>
        {
            { "@idProducto", idProducto },
            { "@fechaInicio", fechaInicio.ToString("yyyy-MM-dd")  },
            { "@fechaFin", fechaFin .ToString("yyyy-MM-dd")}
        };

                DBOperacion operacion = new DBOperacion();
                // Ejecutar la consulta y obtener el resultado
                var resultado = operacion.Consultar(sentencia, parametros);

                // Si la consulta devuelve resultados
                if (resultado != null && resultado.Rows.Count > 0)
                {
                    foreach (DataRow fila in resultado.Rows)
                    {
                        var kardex = new Kardex
                        {
                            // Asegúrate de que la fila es una fila válida de la base de datos
                            IdKardex = Convert.ToInt32(fila["idKardex"]),
                            IdProducto = fila["idProducto"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["idProducto"]),
                            IdIngrediente = fila["idIngrediente"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["idIngrediente"]),
                            FechaMovimientoKardex = Convert.ToDateTime(fila["fechaMovimientoKardex"]),
                            TipoMovimientoKardex = fila["tipoMovimientoKardex"].ToString(),
                            CantidadKardex = fila["cantidadKardex"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["cantidadKardex"]),
                            CostoUnitarioKardex = fila["costoUnitarioKardex"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["costoUnitarioKardex"]),
                            SaldoCantidadKardex = fila["saldoCantidadKardex"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["saldoCantidadKardex"]),
                            SaldoValorKardex = fila["saldoValorKardex"] == DBNull.Value ? 0 : Convert.ToDecimal(fila["saldoValorKardex"])

                        };

                        kardexList.Add(kardex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al obtener Kardex: {ex.Message}");
            }

            return kardexList;
        }

        public async Task<bool> InsertarEntradaAsync()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO Entrada (idProducto, idIngrediente, fecha, cantidadEntrada, costoUnitario) ");
            sentencia.Append("VALUES (@idProducto, @idIngrediente, @fecha, @cantidadEntrada, @costoUnitario);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto },
                    { "@idIngrediente", idIngrediente },
                    { "@fecha", fechaMovimiento.ToString("yyyy-MM-dd") },
                    { "@cantidadEntrada", cantidad },
                    { "@costoUnitario", costoUnitario }
                };

                resultado = await operacion.EjecutarSentenciaAsync(sentencia.ToString(), parametros) >= 0;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public async Task<bool> InsertarSalidaAsync()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO Salida (idProducto, idIngrediente, fecha, cantidadSalida, costoUnitario) ");
            sentencia.Append("VALUES (@idProducto, @idIngrediente, @fecha, @cantidadSalida, @costoUnitario);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto },
                    { "@idIngrediente", idIngrediente },
                    { "@fecha", fechaMovimiento.ToString("yyyy-MM-dd") },
                    { "@cantidadSalida", cantidad },
                    { "@costoUnitario", costoUnitario }
                };

                resultado = await operacion.EjecutarSentenciaAsync(sentencia.ToString(), parametros) >= 0;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public async Task<bool> ActualizarEntradaAsync()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE Entrada SET ");
            sentencia.Append("idProducto = @idProducto, idIngrediente = @idIngrediente, fecha = @fecha, ");
            sentencia.Append("cantidadEntrada = @cantidadEntrada, costoUnitario = @costoUnitario ");
            sentencia.Append("WHERE idEntrada = @idInventario;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto },
                    { "@idIngrediente", idIngrediente },
                    { "@fecha", fechaMovimiento.ToString("yyyy-MM-dd") },
                    { "@cantidadEntrada", cantidad },
                    { "@costoUnitario", costoUnitario },
                    { "@idInventario", idInventario }
                };

                resultado = await operacion.EjecutarSentenciaAsync(sentencia.ToString(), parametros) >= 0;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public async Task<bool> EliminarEntradaAsync()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM Entrada WHERE idEntrada = @idInventario;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idInventario", idInventario }
                };

                resultado = await operacion.EjecutarSentenciaAsync(sentencia.ToString(), parametros) >= 0;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
        /**public DataTable ObtenerInventarioProductosAsync()
        {
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();

            // Consulta SQL para obtener id, nombre y cantidad disponible de productos
            sentencia.Append(@"
        SELECT p.idProducto AS idItem, p.nombre,
            COALESCE(SUM(e.cantidadEntrada), 0) - COALESCE(SUM(s.cantidadSalida), 0) AS cantidadDisponible
        FROM Producto p
        LEFT JOIN Entrada e ON p.idProducto = e.idProducto
        LEFT JOIN Salida s ON p.idProducto = s.idProducto
        GROUP BY p.idProducto, p.nombre;
    ");

            try
            {
                // Ejecutar la consulta y obtener un DataTable
                DataTable resultado = operacion.EjecutarConsultaAsync(sentencia.ToString());
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // O manejar el error según sea necesario
            }
        }
        */
        public DataTable ObtenerInventarioProductos()
        {
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();

            // Consulta SQL para obtener id, nombre y cantidad disponible de productos
            sentencia.Append(@"
       SELECT 
    p.idProducto, 
    p.nombreProducto, 
    COALESCE(SUM(e.cantidadEntrada), 0) - COALESCE(SUM(s.cantidadSalida), 0) AS cantidadDisponible, 
    c.categoria
FROM 
    RG_Producto p
LEFT JOIN 
    RG_Categoria c ON p.idCategoria = c.idCategoria
LEFT JOIN 
    RG_Entrada e ON p.idProducto = e.idProducto
LEFT JOIN 
    RG_Salida s ON p.idProducto = s.idProducto
GROUP BY 
    p.idProducto, p.nombreProducto, c.categoria
LIMIT 0, 300;
    ");

            try
            {
                // Ejecutar la consulta y obtener un DataTable
                DataTable resultado = operacion.Consultar(sentencia.ToString());
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // O manejar el error según sea necesario
            }
        }

        public DataTable ObtenerInventarioProductosEIngredientes()
        {
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();

            // Consulta SQL para obtener id, nombre, tipo (Producto o Ingrediente) y cantidad disponible
            sentencia.Append(@"
        SELECT 'Producto' AS tipo, p.idProducto AS idItem, p.nombre,
            COALESCE(SUM(e.cantidadEntrada), 0) - COALESCE(SUM(s.cantidadSalida), 0) AS cantidadDisponible
        FROM Producto p
        LEFT JOIN Entrada e ON p.idProducto = e.idProducto
        LEFT JOIN Salida s ON p.idProducto = s.idProducto
        GROUP BY p.idProducto, p.nombre
        UNION ALL
        SELECT 'Ingrediente' AS tipo, i.idIngrediente AS idItem, i.nombre,
            COALESCE(SUM(e.cantidadEntrada), 0) - COALESCE(SUM(s.cantidadSalida), 0) AS cantidadDisponible
        FROM Ingrediente i
        LEFT JOIN Entrada e ON i.idIngrediente = e.idIngrediente
        LEFT JOIN Salida s ON i.idIngrediente = s.idIngrediente
        GROUP BY i.idIngrediente, i.nombre;
    ");

            try
            {
                // Ejecutar la consulta y obtener un DataTable
                DataTable resultado = operacion.Consultar(sentencia.ToString());
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // O manejar el error según sea necesario
            }
        }

    }
}
