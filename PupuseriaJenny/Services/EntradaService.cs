using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Services
{
    internal class EntradaService
    {
        private DBOperacion db;

        public EntradaService()
        {
            db = new DBOperacion();
        }

        public int InsertarEntrada(Entrada entrada)
        {
            string query = "INSERT INTO RG_Entrada (idProducto, cantidadEntrada, costoUnitarioEntrada, fechaEntrada) " +
                           "VALUES (@idProducto, @cantidadEntrada, @costoUnitarioEntrada, @fechaEntrada); " +
                           "SELECT LAST_INSERT_ID();";

            var parameters = new Dictionary<string, object>
    {
        { "@idProducto", entrada.idProducto },
        { "@cantidadEntrada", entrada.cantidadEntrada },
        { "@costoUnitarioEntrada", entrada.costoUnitarioEntrada },
        { "@fechaEntrada", entrada.fechaEntrada }
    };

            // Ejecutar la consulta y obtener el ID de la entrada insertada
            var result = db.Consultar(query, parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0][0]); // Retornar el ID insertado
            }

            return 0; // Si no se obtiene el ID, retornar 0
        }

        public void EliminarEntrada(int idEntrada)
        {
            string query = "DELETE FROM RG_Entrada WHERE idEntrada = @idEntrada";

            var parameters = new Dictionary<string, object>
    {
        { "@idEntrada", idEntrada }
    };

            // Ejecutar la sentencia de eliminación
            db.EjecutarSentencia(query, parameters);
        }

        public void InsertarEntradaProducto(int idProducto, decimal cantidad)
        {
            string sentencia = "INSERT INTO RG_Entrada (IdProducto, CantidadEntrada) VALUES (@IdProducto, @Cantidad)";

            var parametros = new Dictionary<string, object>
        {
            { "@IdProducto", idProducto },
            { "@Cantidad", cantidad }
        };

            db.EjecutarSentencia(sentencia, parametros);
        }

        // Insertar entrada de ingrediente
        public void InsertarEntradaIngrediente(int idIngrediente, decimal cantidad)
        {
            string sentencia = "INSERT INTO RG_Entrada (IdIngrediente, CantidadEntrada) VALUES (@IdIngrediente, @Cantidad)";

            var parametros = new Dictionary<string, object>
        {
            { "@IdIngrediente", idIngrediente },
            { "@Cantidad", cantidad }
        };

            db.EjecutarSentencia(sentencia, parametros);
        }


    }
}
