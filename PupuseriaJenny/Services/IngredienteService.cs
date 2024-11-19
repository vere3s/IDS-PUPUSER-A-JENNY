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
    public class IngredienteService
    {
        private readonly DBOperacion _operacion;
        public IngredienteService()
        {
            _operacion= new DBOperacion();
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

    }
}
