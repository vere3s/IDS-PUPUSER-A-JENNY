using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Services
{
    public class CategoriaService
    {
        private readonly DBOperacion _operacion;

        public CategoriaService()
        {
            _operacion = new DBOperacion();
        }
        public bool Insertar(Categorias categorias)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Categoria(categoria) VALUES(@categoria);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@categoria", categorias.Categoria }
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
        public bool Actualizar(Categorias categorias)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Categoria SET ");
            sentencia.Append("categoria = @categoria ");
            sentencia.Append("WHERE idCategoria = @idCategoria;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@categoria", categorias.Categoria },
                    { "@idCategoria", categorias.IdCategoria }
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

        public bool Eliminar(int idCategoria)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Categoria WHERE idCategoria = @idCategoria;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idCategoria", idCategoria }
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
        public List<string> CategoriasProductos()
        {
            List<string> categorias = new List<string>();
            string consulta = @"SELECT DISTINCT c.categoria 
                                FROM RG_Categoria c 
                                JOIN RG_Producto p ON c.idCategoria = p.idCategoria 
                                ORDER BY c.categoria ASC;";

            try
            {
                DataTable resultado = _operacion.Consultar(consulta);

                foreach (DataRow row in resultado.Rows)
                {
                    categorias.Add(row["categoria"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener categorías: " + ex.Message);
            }

            return categorias;
        }
        public List<string> CategoriasIngredientes()
        {
            List<string> categorias = new List<string>();
            string consulta = @"SELECT DISTINCT c.categoria 
                                FROM RG_Categoria c 
                                JOIN rg_ingrediente i ON c.idCategoria = i.idCategoria 
                                ORDER BY c.categoria ASC;";

            try
            {
                DataTable resultado = _operacion.Consultar(consulta);

                foreach (DataRow row in resultado.Rows)
                {
                    categorias.Add(row["categoria"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener categorías: " + ex.Message);
            }


            return categorias;
        }
        public DataTable ObtenerProductosPorCategoria(string categoria)
        {
            DataTable resultado = new DataTable();
            string consulta = @"SELECT p.idProducto, p.nombreProducto, p.costoUnitarioProducto, p.precioProducto, p.imagenProducto
                            FROM RG_Producto p
                            JOIN RG_Categoria c ON p.idCategoria = c.idCategoria
                            WHERE c.categoria = @categoria
                            ORDER BY p.nombreProducto ASC;";

            try
            {
                // Agregar parámetro
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    { "@categoria", categoria }
                };

                resultado = _operacion.Consultar(consulta, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }
            Console.WriteLine("Columnas obtenidas para productos:");
            foreach (DataColumn columna in resultado.Columns)
            {
                Console.WriteLine($"- {columna.ColumnName}");
            }

            Console.WriteLine("Número de filas obtenidas: " + resultado.Rows.Count);

            return resultado;
        }
        public DataTable ObtenerIngredientesPorCategoria(string categoria)
        {
            DataTable resultado = new DataTable();
            string consulta = @"SELECT i.idIngrediente, i.nombreIngrediente, i.precioIngrediente, i.imagenIngrediente
                         FROM RG_Ingrediente i
                         JOIN RG_Categoria c ON i.idCategoria = c.idCategoria
                         WHERE c.categoria = @categoria
                         ORDER BY i.nombreIngrediente ASC;";

            try
            {
                if (string.IsNullOrEmpty(categoria))
                {
                    throw new ArgumentException("La categoría no puede ser nula o vacía.");
                }

                // Depuración de la consulta y los parámetros
                Console.WriteLine("Consulta SQL: " + consulta);
                Console.WriteLine("Parámetro categoría: " + categoria);

                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    { "@categoria", categoria }
                };

                resultado = _operacion.Consultar(consulta, parametros);

                if (resultado.Rows.Count == 0)
                {
                    Console.WriteLine("No se encontraron ingredientes para la categoría: " + categoria);
                }
                else
                {
                    Console.WriteLine("Ingredientes encontrados: " + resultado.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener ingredientes: " + ex.Message);
            }
            Console.WriteLine("Columnas obtenidas para productos:");
            foreach (DataColumn columna in resultado.Columns)
            {
                Console.WriteLine($"- {columna.ColumnName}");
            }

            Console.WriteLine("Número de filas obtenidas: " + resultado.Rows.Count);

            return resultado;
        }

        public CategoriaService(DBOperacion operacion = null)
        {
            _operacion = operacion ?? new DBOperacion();
        }

        public List<Categorias> ObtenerCategorias()
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idCategoria, categoria FROM RG_Categoria;");

            try
            {
                // Llama a Consultar en DBOperacion
                DataTable resultado = _operacion.Consultar(sentencia.ToString(), new Dictionary<string, object>());

                foreach (DataRow row in resultado.Rows)
                {
                    Categorias categoria = new Categorias
                    {
                        
                        IdCategoria= Convert.ToInt32(row["idCategoria"]),
                        Categoria = row["Categoria"].ToString()
                    };
                    listaCategorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener roles: " + ex.Message);
            }

            return listaCategorias;
        }
       

    }
}
