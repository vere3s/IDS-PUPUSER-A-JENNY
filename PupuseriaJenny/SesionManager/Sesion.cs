using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using PupuseriaJenny.CLS;
using PupuseriaJenny.Models;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.SesionManager
{
    public class Sesion
    {
        private static Sesion _instance;
        private static readonly object _lock = new object();
        public Empleado empleado;
        String _Usuario;
        String _Contraseña;
        public List<Permiso> Permisos = new List<Permiso>();

        public string Usuario
        {
            get => _Usuario;
            set => _Usuario = value;
        }
        public string Contraseña
        {
            get => _Contraseña;
            set => _Contraseña = value;
        }

        public static Sesion ObtenerInstancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Sesion();
                    }
                }
            }
            return _instance;
        }
        private Sesion() { }
        public Boolean ValidarPermiso(Int32 pIDOpcion)
        {
            Boolean Resultado = false;
            DataTable Result = new DataTable();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append(@"select a.IDOpcion, c.Opcion from rg_permiso a ");
            Sentencia.Append("INNER JOIN rg_usuario b on b.IDRol = a.IDRol ");
            Sentencia.Append("inner join rg_opcion c on c.IDOpcion = a.IDOpcion ");
            Sentencia.Append("where b.Usuario = '" + _Usuario + "'");
            Sentencia.Append("AND a.IDOpcion=" + pIDOpcion.ToString() + ";");
          RestauranteGestion.Core.DataAccess.DBOperacion oOperacion = new DBOperacion();
            Result = oOperacion.Consultar(Sentencia.ToString());
            if (Result.Rows.Count > 0)
            {
                Resultado = true;
            }
            if (!Resultado)
            {
                MessageBox.Show("Acceso denegado");
            }

            return Resultado;
        }
    }
}
