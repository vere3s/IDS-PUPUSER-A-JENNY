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
    internal class RolesService
    {
        private readonly DBOperacion _operacion;

        public RolesService()
        {
            _operacion = new DBOperacion();
        }

        public List<Roles> ObtenerRoles()
        {
            List<Roles> listaRoles = new List<Roles>();
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("SELECT idRol, Rol FROM RG_Rol;");

            try
            {
                // Llama a Consultar en DBOperacion
                DataTable resultado = _operacion.Consultar(sentencia.ToString(), new Dictionary<string, object>());

                foreach (DataRow row in resultado.Rows)
                {
                    Roles rol = new Roles
                    {
                        idRol = Convert.ToInt32(row["idRol"]),
                        Rol = row["Rol"].ToString()
                    };
                    listaRoles.Add(rol);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener roles: " + ex.Message);
            }

            return listaRoles;
        }


        public bool Insertar(Roles rol)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("INSERT INTO RG_Rol(Rol) VALUES(@Rol);");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@Rol",rol.Rol }
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
        public bool Actualizar(Roles Rol)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("UPDATE RG_Rol SET ");
            sentencia.Append("rol = @rol ");
            sentencia.Append("WHERE idRol = @idRol;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@Rol", Rol.Rol },
                    { "@idRol", Rol.idRol }
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

        public bool Eliminar(int idRol)
        {
            bool resultado = false;
            StringBuilder sentencia = new StringBuilder();
            sentencia.Append("DELETE FROM RG_Rol WHERE idRol = @idRol;");

            try
            {
                var parametros = new Dictionary<string, object>
                {
                    { "@idRol", idRol }
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
