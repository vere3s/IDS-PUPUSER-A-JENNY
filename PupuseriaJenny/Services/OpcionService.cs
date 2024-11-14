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
    internal class OpcionService
    {

        private readonly DBOperacion _operacion;

        public OpcionService()
        {
            _operacion = new DBOperacion();
        }



        public bool Insertar(Opciones opcion)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Opcion(opcion) VALUES(@opcion);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@opcion", opcion.opcion }
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
        public bool Actualizar(Opciones opcion)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Opcion SET ");
            sentencia.Append("opcion = @opcion ");
            sentencia.Append("WHERE idOpcion = @idOpcion;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@opcion", opcion.opcion },
                    { "@idOpcion", opcion.IdOpcion }
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

        public bool Eliminar(int idOpcion)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Opcion WHERE idOpcion = @idOpcion;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idOpcion", idOpcion }
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

        public List<Opciones> ObtenerOpcions()
        {
            List<Opciones> listaOpciones = new List<Opciones>();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idOpcion, opcion FROM RG_Opcion;");

            try
            {
                // Llama a Consultar en DBOperacion
                DataTable resultado = _operacion.Consultar(sentencia.ToString(), new Dictionary<string, object>());

                foreach (DataRow row in resultado.Rows)
                {
                     Opciones opcion = new Opciones
                    {
                        IdOpcion = Convert.ToInt32(row["idOpcion"]),
                        opcion = row["opcion"].ToString()
                    };
                    listaOpciones.Add(opcion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener roles: " + ex.Message);
            }

            return listaOpciones;
        }


    }
}
