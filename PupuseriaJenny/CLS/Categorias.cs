using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.CLS
{
    internal class Categorias
    {
        Int32 _idCategoria;
        string _categoria;

        public int idCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string categoria { get => _categoria; set => _categoria = value; }

        public Boolean Insertar()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Categoria(categoria) VALUES(@categoria);");

            try
            {
             var parametros = new Dictionary<string, object>
            {
                { "@categoria", categoria }
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
        public Boolean Actualizar()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Categoria SET ");
            sentencia.Append("categoria = @categoria ");
            sentencia.Append("WHERE idCategoria = @idCategoria;");

            try
            {
            var parametros = new Dictionary<string, object>
            {
                 { "@categoria", categoria },
                 { "@idCategoria", idCategoria }
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

        public Boolean Eliminar()
        {
            bool resultado = false;
            DBOperacion operacion = new DBOperacion();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Categoria WHERE idCategoria = @idCategoria;");

            try
            {
            var parametros = new Dictionary<string, object>
            {
                { "@idCategoria", idCategoria }
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
