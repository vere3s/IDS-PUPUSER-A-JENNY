using RestauranteGestion.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupuseriaJenny.Models
{
    public class Cargos
    {
        public int IdCargo { get; set; }
        [Required(ErrorMessage = "El nombre del cargo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de la categoria no puede superar los 50 caracteres.")]
        public string cargo { get; set; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("INSERT INTO RG_Cargo(cargo) VALUES(");
            Sentencia.Append("'" + cargo + "');");
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
            Sentencia.Append("UPDATE RG_Cargo SET ");
            Sentencia.Append("Cargo = '" + cargo + "' ");
            Sentencia.Append("WHERE idCargo = " + IdCargo + "; ");
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
            Sentencia.Append("DELETE FROM RG_Cargo ");
            Sentencia.Append("WHERE idCargo = " + IdCargo + ";");
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
