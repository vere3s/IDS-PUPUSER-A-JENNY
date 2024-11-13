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
    internal class MesaService
    {
        private readonly DBOperacion _operacion;

        public MesaService()
        {
            _operacion = new DBOperacion();
        }
        public DataTable Mesa()
        {
            DataTable resultado = new DataTable();
            string consulta = @"SELECT idMesa, numeroMesa
                        FROM RG_Mesa
                        ORDER BY numeroMesa ASC;";

            try
            {
                resultado = _operacion.Consultar(consulta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener mesas: " + ex.Message);
            }

            return resultado;
        }
        public bool Insertar(Mesas mesas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Mesa(numeroMesa) VALUES(@numeroMesa);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@numeroMesa", mesas.NumeroMesa }
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
        public bool Actualizar(Mesas mesas)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Mesa SET ");
            sentencia.Append("numeroMesa = @numeroMesa ");
            sentencia.Append("WHERE idMesa = @idMesa;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@numeroMesa", mesas.NumeroMesa },
                    { "@idMesa", mesas.IdMesa }
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

        public bool Eliminar(int idMesa)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Mesa WHERE idMesa = @idMesa;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idMesa", idMesa }
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
