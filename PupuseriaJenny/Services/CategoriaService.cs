using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Services
{
    internal class CategoriaService
    {
        public static List<string> CategoriasProductos()
        {
            List<string> categorias = new List<string>();
            string consulta = @"SELECT DISTINCT c.categoria 
                                FROM RG_Categoria c 
                                JOIN RG_Producto p ON c.idCategoria = p.idCategoria 
                                ORDER BY c.categoria ASC;";

            DBOperacion operacion = new DBOperacion();
            try
            {
                DataTable resultado = operacion.Consultar(consulta);

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

        public static DataTable ObtenerProductosPorCategoria(string categoria)
        {
            DataTable resultado = new DataTable();
            string consulta = @"SELECT p.nombreProducto 
                        FROM RG_Producto p
                        JOIN RG_Categoria c ON p.idCategoria = c.idCategoria
                        WHERE c.categoria = @categoria
                        ORDER BY p.nombreProducto ASC;";

            DBOperacion operacion = new DBOperacion();
            try
            {
                // Agregar parámetro
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    { "@categoria", categoria }
                };

                resultado = operacion.Consultar(consulta, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }

            return resultado;
        }
    }
}
