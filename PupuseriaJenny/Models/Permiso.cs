using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public enum AccesoPermiso
    {
        lectura,
        escritura,
        modificacion,
        eliminacion
    }
    internal class Permiso
    {
        public int IDPermiso { get; set; }
        public int IDRol {  get; set; }
        public int IDOpcion {  get; set; }
        public AccesoPermiso Acceso { get; set; }
        public string Opcion { get; set; }
        public string  Rol { get; set;}

        // Para los metodos insertar, eliminar y modificar
        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("INSERT INTO RG_Permiso(idRol, idOpcion, accesoPermiso) VALUES(");
            Sentencia.Append("'" + IDRol + "', ");
            Sentencia.Append("'" + IDOpcion + "', ");
            Sentencia.Append("'" + Acceso.ToString() + "');"); // Convertir enum a string

            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("UPDATE RG_Permiso SET ");
            Sentencia.Append("idRol = '" + IDRol + "', ");
            Sentencia.Append("idOpcion = '" + IDOpcion + "', ");
            Sentencia.Append("accesoPermiso = '" + Acceso.ToString() + "' ");
            Sentencia.Append("WHERE idPermiso = " + IDPermiso + ";");

            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion(); // Agregar referencias= Referencias-Agregar referencia
            StringBuilder Sentencia = new StringBuilder(); // Objeto para construir cadenas complejas
            Sentencia.Append("DELETE FROM RG_Permiso ");
            Sentencia.Append("WHERE idPermiso = " + IDPermiso + ";");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public static bool PermisoExiste(string oAcceso)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT accesoPermiso FROM RG_Permiso WHERE accesoPermiso = '" + oAcceso + "';";

            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado.Rows.Count > 0;
        }

    }
}
