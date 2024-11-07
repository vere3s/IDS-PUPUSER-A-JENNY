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
