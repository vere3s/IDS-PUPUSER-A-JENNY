using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PupuseriaJenny.Services
{

    public class CargoService
    {
        private readonly DBOperacion _operacion;
       


        public bool Insertar(Cargos cargo)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Cargo(cargo) VALUES(@cargo);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@cargo", cargo.cargo }
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
        public bool Actualizar(Cargos cargo)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Cargo SET ");
            sentencia.Append("cargo = @cargo ");
            sentencia.Append("WHERE idCargo = @idCargo;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@cargo", cargo.cargo },
                    { "@idCargo", cargo.IdCargo }
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

        public bool Eliminar(int idCargo)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Cargo WHERE idCargo = @idCargo;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idCargo", idCargo }
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


        public CargoService(DBOperacion operacion = null)
        {
            _operacion = operacion ?? new DBOperacion();
        }

       
        public List<Cargos> ObtenerCargos()
        {
            List<Cargos> cargos = new List<Cargos>();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idCargo, cargo FROM RG_Cargo;"); // Ajusta los nombres de columnas y tablas si es necesario

            try
            {
                DataTable tabla = _operacion.Consultar(sentencia.ToString());
                foreach (DataRow fila in tabla.Rows)
                {
                    Cargos cargo = new Cargos
                    {
                        IdCargo = Convert.ToInt32(fila["idCargo"]),
                        cargo = fila["cargo"].ToString()
                    };
                    cargos.Add(cargo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener cargos: " + ex.Message);
                cargos = null;
            }

            return cargos;
        }

    }
}
