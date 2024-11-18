using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;
using System.Data;

namespace PupuseriaJenny.Services
{
    public class ProductoService
    {
        private readonly DBOperacion _operacion;

        public ProductoService()
        {
            _operacion = new DBOperacion();
        }
        public DataTable ObtenerTodos()
        {
            // Construcción de la sentencia SQL
            string sentencia = "SELECT p.idProducto, p.nombreProducto, p.costoUnitarioProducto, p.precioProducto, p.idCategoria, c.categoria, p.imagenProducto FROM rg_producto p JOIN RG_Categoria c ON p.idCategoria = c.idCategoria;";
            try
            {
                // Consulta a la base de datos
                DataTable tabla = _operacion.Consultar(sentencia);

                // Verifica si la consulta devolvió datos
                if (tabla == null || tabla.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron registros en la tabla de productos.");
                    return null;
                }

                return tabla;
            }
            catch (Exception ex)
            {
                // Manejo de errores y log de la excepción
                Console.WriteLine("Error al obtener productos: " + ex.Message);
                return null;
            }
        }
        public virtual Productos ObtenerPorId(int idProducto)
        {
            Productos productos = null;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idProducto, nombreProducto, costoUnitarioProducto, precioProducto, idCategoria, imagenProducto ");
            sentencia.Append("FROM RG_Producto ");
            sentencia.Append("WHERE idProducto = @idProducto;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto }
                };

                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    productos = new Productos
                    {
                        IdProducto = Convert.ToInt32(fila["idProducto"]),
                        NombreProducto = fila["nombreProducto"].ToString(),
                        CostoUnitarioProducto =Convert.ToDecimal(fila["costoUnitarioProducto"]),
                        PrecioProducto = Convert.ToDecimal(fila["precioProducto"]),
                        IdCategoria = Convert.ToInt32(fila["idCategoria"]),
                        ImagenProducto = fila["imagenProducto"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                productos = null;

                Console.WriteLine("Eliminar error es" + ex.Message);
            }

            return productos;
        }
        public bool Insertar(Productos productos)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Producto(nombreProducto, costoUnitarioProducto, precioProducto, idCategoria, imagenProducto) VALUES(@nombreProducto, @costoUnitarioProducto, @precioProducto, @idCategoria, @imagenProducto);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProducto", productos.NombreProducto },
                    { "@costoUnitarioProducto", productos.CostoUnitarioProducto },
                    { "@precioProducto", productos.PrecioProducto },
                    { "@idCategoria", productos.IdCategoria },
                    { "@imagenProducto", productos.ImagenProducto }
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

        public bool Actualizar(Productos productos)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Producto SET ");
            sentencia.Append("nombreProducto = @nombreProducto, " +
                             "costoUnitarioProducto = @costoUnitarioProducto, " +
                             "precioProducto = @precioProducto, " +
                             "idCategoria = @idCategoria, " +
                             "imagenProducto = @imagenProducto ");
            sentencia.Append("WHERE idProducto = @idProducto;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProducto", productos.NombreProducto },
                    { "@costoUnitarioProducto", productos.CostoUnitarioProducto },
                    { "@precioProducto", productos.PrecioProducto },
                    { "@idCategoria", productos.IdCategoria },
                    { "@imagenProducto", productos.ImagenProducto },
                    { "@idProducto", productos.IdProducto }
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

        public bool Eliminar(int idProducto)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Producto WHERE idProducto = @idProducto;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto }
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
