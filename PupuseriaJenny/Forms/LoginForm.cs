﻿using System;
using System.Data;
using System.Windows.Forms;
using PupuseriaJenny.CLS;
using PupuseriaJenny.Services;

namespace PupuseriaJenny.Forms
{
    public partial class LoginForm : Form
    {
        private bool _autorizado;
        private UsuarioService usuarioService;

        public LoginForm()
        {
            InitializeComponent();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.errorProvider.ContainerControl = this;
            usuarioService = new UsuarioService(); // Instanciamos el servicio
        }

        public bool Autorizado { get => _autorizado; set => _autorizado = value; }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            // Limpiar cualquier error previo
            errorProvider.Clear();

            // Validar el usuario con el servicio
            if (usuarioService.ValidarUsuario(usuario, contraseña, out string mensajeError))
            {
                try
                {
                    // Usamos el servicio para autenticar al usuario
                    DataTable dt = usuarioService.AutenticarUsuario(usuario, contraseña);

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
            else
            {
                // Mostrar el mensaje de error en el ErrorProvider
                errorProvider.SetError(txtUsuario, mensajeError);
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
                email = row["email"].ToString(),
                fechaNacimiento = Convert.ToDateTime(row["fechaNacimiento"]),
                idCargo = Convert.ToInt32(row["idCargo"]),
                telefono = row["telefono"].ToString()
            };
        }
    }
}
