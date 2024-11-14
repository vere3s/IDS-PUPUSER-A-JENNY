using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PupuseriaJenny.Forms
{
    public partial class UsuarioEdicion : Form
    {

        private readonly UsuarioService _usuarioService;
        private readonly RolesService _rolService;
        private readonly EmpleadoService _empleadoService;
        private int? _idUsuario;

        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbUsuario.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbUsuario, "Este campo no puede estar vacio");
                    valido = false;
                }
                if (tbContraseña.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbContraseña, "Este campo no puede estar vacio");
                    valido = false;
                }
                if (Usuario.UsuarioExiste(tbUsuario.Text))
                {
                    MessageBox.Show("El usuario ya existe. Por favor, elija otro nombre de usuario.");
                    valido = false;
                }
            }
            catch (Exception)
            {

                valido = false;
            }
            return valido;
        }

        public UsuarioEdicion(int? idUsuario = null)
        {
            InitializeComponent();
          
            _usuarioService = new UsuarioService();
            _rolService = new RolesService();
            _empleadoService = new EmpleadoService();
       

            _idUsuario= idUsuario ;
            CargarRoles();
            CargarEmpleados();
            if (_idUsuario.HasValue)
            {
                CargarDatosUsuario(_idUsuario.Value);
            }

        }

        private void CargarRoles()
        {
            var roles = _rolService.ObtenerRoles();
            cbIDRol.DataSource = roles;
            cbIDRol.DisplayMember = "rol";
            cbIDRol.ValueMember = "IdRol";
        }

        private void CargarEmpleados()
        {
            var empleados = _empleadoService.ObtenerTodos();
            cbIDEmpleado.DataSource = empleados;
            cbIDEmpleado.DisplayMember = "apellidoEmpleado";
            cbIDEmpleado.ValueMember = "IdEmpleado";
        }

        private void CargarDatosUsuario(int idUsuario)
        {
            var usuario = _usuarioService.ObtenerPorId(idUsuario);
            if (usuario != null)
            {
                tbIDUsuario.Text = usuario.IDUsuario.ToString();
                tbUsuario.Text = usuario.UsuarioNombre;
                tbContraseña.Text = usuario.Contraseña;
                cbIDRol.SelectedValue = usuario.IDRol;
                cbIDEmpleado.SelectedValue = usuario.IDEmpleado;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    Usuario oUsuario = new Usuario();
                    // SINCRONIZAMOS EL OBJETO CON LA GUI
                    try
                    {
                        oUsuario.IDUsuario = Convert.ToInt32(tbIDUsuario.Text);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("No se puedo convertir ");
                        oUsuario.IDUsuario = 0;
                    }

                    oUsuario.UsuarioNombre = tbUsuario.Text;
                    oUsuario.Contraseña = tbContraseña.Text;
                    oUsuario.IDEmpleado = Convert.ToInt32(cbIDEmpleado.SelectedValue);
                    oUsuario.IDRol = Convert.ToInt32(cbIDRol.SelectedValue);
                    //PROCEDER
                    if (tbIDUsuario.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTRO
                        if (oUsuario.Insertar())
                        {
                            MessageBox.Show("Resgistro realizado con éxito");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el Usuario");
                            
                        }
                    }
                    else
                    {
                        // ACTUALIZAR NUEVO REGISTRO
                        if (oUsuario.Actualizar())
                        {
                            MessageBox.Show("Registro actualizado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser actualizado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
