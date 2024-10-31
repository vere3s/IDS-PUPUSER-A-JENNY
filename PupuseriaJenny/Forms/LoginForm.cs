using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PupuseriaJenny.CLS;
using RestauranteGestion.Core.DataAccess;

namespace PupuseriaJenny.Forms
{
    public partial class LoginForm : Form
    {
        private bool _autorizado;
        public LoginForm()
        {
            InitializeComponent();
        }

        public bool Autorizado { get => _autorizado; set => _autorizado = value; }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            try
            {
                DataTable dt = AutenticarUsuario(usuario, contraseña);

                if (dt.Rows.Count == 1)

                {
                    ConfigurarSesion(dt.Rows[0]);
                    Autorizado = true;

                    Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DataTable AutenticarUsuario(string usuario, string contraseña)
        {
            string query = @"
                SELECT 
                    u.IDUsuario, u.Usuario, 
                    e.IDEmpleado, e.Nombre, e.Cargo, e.Telefono, e.Email
                FROM 
                    usuarios u
                INNER JOIN 
                    empleados e ON u.IDEmpleado = e.IDEmpleado
                WHERE 
                    u.Usuario = @Usuario AND 
                    u.Contraseña = @Contraseña;";

            var oOperacion = new DBOperacion();
            var parameters = new Dictionary<string, object>
    {
        { "@Usuario", usuario },
        { "@Contraseña", contraseña }
    };

            try
            {
                // Llamar al método Consultar y obtener el DataTable
                return oOperacion.Consultar(query, parameters);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: mostrar un mensaje de error o loguear el error
                MessageBox.Show($"Error al consultar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); // Retornar un DataTable vacío en caso de error
            }
        }

        private void ConfigurarSesion(DataRow row)
        {
            SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
            oSesion.Usuario = txtUsuario.Text;
            oSesion.Contraseña = txtContraseña.Text.ToString();
            oSesion.empleado = new Empleados
            {
                idEmpleados = Convert.ToInt32(row["idEmpleados"]),
                nombresEmpleado = row["nombresEmpleado"].ToString(),
                apellidosEmpleado = row["apellidosEmpleado"].ToString(),
                direccion = row["direccion"].ToString(),
                email= row["email"].ToString(),
                fechaNacimiento = Convert.ToDateTime(row["fechaNacimiento"]),
                idCargo = Convert.ToInt32(row["idEmpleados"]),
                telefono = row["direccion"].ToString()
            };
        }
    }

}
