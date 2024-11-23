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


    internal class IngredienteService
    {
        private readonly DBOperacion _operacion;
        public IngredienteService()
        {
            _operacion = new DBOperacion();
        }

        public DataTable ObtenerTodos()
        {
            // Construcción de la sentencia SQL
            string sentencia = "SELECT p.idIngrediente, p.nombreIngrediente, p.precioIngrediente, p.idCategoria, c.categoria, p.imagenIngrediente FROM rg_Ingrediente p JOIN RG_Categoria c ON p.idCategoria = c.idCategoria;";
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
        public virtual Ingredientes ObtenerPorId(int idIngrediente)
        {
            Ingredientes Ingrediente = null;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idIngrediente, nombreIngrediente, precioIngrediente, idCategoria, imagenIngrediente ");
            sentencia.Append("FROM RG_Ingrediente ");
            sentencia.Append("WHERE idIngrediente = @idIngrediente;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idIngrediente", idIngrediente }
                };

                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    Ingrediente = new Ingredientes
                    {
                        IdIngrediente = Convert.ToInt32(fila["idIngrediente"]),
                        NombreIngrediente = fila["nombreIngrediente"].ToString(),
                        PrecioIngrediente = Convert.ToDecimal(fila["precioIngrediente"]),
                        IdCategoria = Convert.ToInt32(fila["idCategoria"]),
                        ImagenIngrediente = fila["imagenIngrediente"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Ingrediente = null;

                Console.WriteLine("Eliminar error es" + ex.Message);
            }

            return Ingrediente;
        }
        public DataTable ObtenerIngredientePorId(int idIngrediente)
        {
            StringBuilder sentencia = new StringBuilder();
            // Consulta SQL para obtener el ingrediente por su ID
            sentencia.Append("SELECT idIngrediente, nombreIngrediente, idCategoria ");
            sentencia.Append("FROM rg_ingrediente ");  // Asegúrate de que la tabla sea 'rg_ingrediente'
            sentencia.Append("WHERE idIngrediente = @idIngrediente;");
            try
            {
                var parametros = new Dictionary<string, object>
        {
            { "@idIngrediente", idIngrediente }  // Parámetro para la consulta
        };
                // Ejecutar la consulta y obtener el resultado en un DataTable
                DataTable tabla = _operacion.Consultar(sentencia.ToString(), parametros);
                // Si la tabla está vacía, puedes devolver null o una tabla vacía
                if (tabla.Rows.Count == 0)
                {
                    return null;  // O retornar new DataTable() si prefieres una tabla vacía
                }
                return tabla;  // Retorna el DataTable con el ingrediente encontrado
            }
            catch (Exception ex)
            {
                // En caso de error, retornamos null y mostramos el mensaje en consola para depuración
                Console.WriteLine("Error al obtener el ingrediente: " + ex.Message);
                return null;  // Devolver null en caso de error
            }
        }
        public bool Insertar(Ingredientes Ingredientes)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Ingrediente(nombreIngrediente, precioIngrediente, idCategoria, imagenIngrediente) VALUES(@nombreIngrediente, @precioIngrediente, @idCategoria, @imagenIngrediente);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreIngrediente", Ingredientes.NombreIngrediente },
                    { "@precioIngrediente", Ingredientes.PrecioIngrediente },
                    { "@idCategoria", Ingredientes.IdCategoria },
                    { "@imagenIngrediente", Ingredientes.ImagenIngrediente }
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

        public bool Actualizar(Ingredientes ingredientes)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Ingrediente SET ");
            sentencia.Append("nombreIngrediente = @nombreIngrediente, " +
                             "precioIngrediente = @precioIngrediente, " +
                             "idCategoria = @idCategoria, " +
                             "imagenIngrediente = @imagenIngrediente ");
            sentencia.Append("WHERE idIngrediente = @idIngrediente;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@nombreIngrediente", ingredientes.NombreIngrediente },
                    { "@precioIngrediente", ingredientes.PrecioIngrediente },
                    { "@idCategoria", ingredientes.IdCategoria },
                    { "@imagenIngrediente", ingredientes.ImagenIngrediente },
                    { "@idIngrediente", ingredientes.IdIngrediente}
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

        public bool Eliminar(int idIngrediente)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Ingrediente WHERE idIngrediente = @idIngrediente;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idIngrediente", idIngrediente }
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
