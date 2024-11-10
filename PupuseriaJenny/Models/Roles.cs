using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    internal class Roles
    {


        public int idRol { get; set; }
        public string Rol { get; set; }
   
    public Boolean Insertar()
    {
        Boolean Resultado = false;
        DBOperacion Operacion = new DBOperacion();
        StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
        Sentencia.Append("INSERT INTO RG_Rol(Rol) VALUES(");
        Sentencia.Append("'" + Rol + "');");
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
        Sentencia.Append("UPDATE RG_Rol SET ");
        Sentencia.Append("Rol = '" + Rol + "' ");
        Sentencia.Append("WHERE idRol = " + idRol + "; ");
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
        Sentencia.Append("DELETE FROM RG_Rol ");
        Sentencia.Append("WHERE idRol = " + idRol + ";");
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
}
}
