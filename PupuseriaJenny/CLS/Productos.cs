using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PupuseriaJenny.CLS
{
    internal class Productos
    {
        Int32 _idProducto;
        string _nombreProducto;
        decimal _costoUnitarioProducto;
        decimal _precioProducto;
        Int32 _idCategoria;
        Int32 _idProveedor;

        public int idProducto { get => _idProducto; set => _idProducto = value; }
        public string nombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public decimal costoUnitarioProducto { get => _costoUnitarioProducto; set => _costoUnitarioProducto = value; }
        public decimal precioProducto { get => _precioProducto; set => _precioProducto = value; }
        public int idCategoria { get => _idCategoria; set => _idCategoria = value; }
        public int idProveedor { get => _idProveedor; set => _idProveedor = value; }

        public bool Insertar()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Producto(nombreProducto, costoUnitarioProducto, precioProducto, idCategoria, idProveedor) VALUES(@nombreProducto, @costoUnitarioProducto, @precioProducto, @idCategoria, @idProveedor);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreProducto", nombreProducto },
                    { "@costoUnitarioProducto", costoUnitarioProducto },
                    { "@precioProducto", precioProducto },
                    { "@idCategoria", idCategoria },
                    { "@idProveedor", idProveedor }
                };

                if (operacion.EjecutarSentencia(sentencia.ToString(), parametros) >= 0)
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

        public bool Actualizar()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
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
                    { "@nombreProducto", nombreProducto },
                    { "@costoUnitarioProducto", costoUnitarioProducto },
                    { "@precioProducto", precioProducto },
                    { "@idCategoria", idCategoria },
                    { "@idProveedor", idProveedor },
                    { "@idProducto", idProducto }
                };

                if (operacion.EjecutarSentencia(sentencia.ToString(), parametros) >= 0)
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

        public bool Eliminar()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Producto WHERE idProducto = @idProducto;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", idProducto }
                };

                if (operacion.EjecutarSentencia(sentencia.ToString(), parametros) >= 0)
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
