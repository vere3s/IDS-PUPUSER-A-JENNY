using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;

namespace PupuseriaJenny.Services
{
    public class ProductoService
    {
        private readonly DBOperacion _operacion;

        public ProductoService()
        {
            _operacion = new DBOperacion();
        }
        public Productos BuscarPorId(int idProducto)
        {
            Productos producto = null;
            //MessageBox.Show(idProducto.ToString());
            // Actualizamos la consulta SQL para incluir idProveedor
            string sentencia = "SELECT idProducto, nombreProducto, costoUnitarioProducto, precioProducto, idCategoria FROM RG_Producto WHERE idProducto = @idProducto;";

            try
            {
                // Parámetros para la consulta
                var parametros = new Dictionary<string, object>
        {
            { "@idProducto", idProducto }
        };

                // Ejecutar la consulta y recuperar el resultado
                var resultado = _operacion.Consultar(sentencia, parametros);

                // Si se obtiene un resultado, mapearlo al objeto Producto
                if (resultado != null && resultado.Rows.Count > 0)
                {
                    var fila = resultado.Rows[0]; // Asumimos que solo hay un producto con ese ID

                    producto = new Productos
                    {
                        // Convertimos los valores de la fila a los tipos correspondientes
                        IdProducto = Convert.ToInt32(fila["idProducto"]),
                        NombreProducto = fila["nombreProducto"].ToString(),
                        CostoUnitarioProducto = fila["costoUnitarioProducto"] != DBNull.Value ? Convert.ToDecimal(fila["costoUnitarioProducto"]) : 0,
                        PrecioProducto = fila["precioProducto"] != DBNull.Value ? Convert.ToDecimal(fila["precioProducto"]) : 0
                        // IdCategoria = Convert.ToInt32(fila["idCategoria"]), // Agregado para que sea consistente con la consulta

                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                Console.WriteLine($"Error al buscar producto: {ex.Message}");
            }

            return producto;
        }

        public bool Insertar(Productos productos)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Producto(nombreProducto, costoUnitarioProducto, precioProducto, idCategoria, idProveedor) VALUES(@nombreProducto, @costoUnitarioProducto, @precioProducto, @idCategoria, @idProveedor);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProducto", productos.NombreProducto },
                    { "@costoUnitarioProducto", productos.CostoUnitarioProducto },
                    { "@precioProducto", productos.PrecioProducto },
                    { "@idCategoria", productos.IdCategoria },
                    { "@idProveedor", productos.IdProveedor }
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
                             "idProveedor = @idProveedor, ");
            sentencia.Append("WHERE idProducto = @idProducto;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProducto", productos.NombreProducto },
                    { "@costoUnitarioProducto", productos.CostoUnitarioProducto },
                    { "@precioProducto", productos.PrecioProducto },
                    { "@idCategoria", productos.IdCategoria },
                    { "@idProveedor", productos.IdProveedor },
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
