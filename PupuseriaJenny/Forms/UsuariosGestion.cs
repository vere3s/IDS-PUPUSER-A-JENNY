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
    public partial class UsuariosGestion : Form
    {
        private readonly BindingSource _datos = new BindingSource();
        private readonly UsuarioService _usuarioService;
        public UsuariosGestion()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                DataTable usuarios = _usuarioService.ObtenerTodos();

                if (usuarios == null || usuarios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de usuarios para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUsuarios.DataSource = null;  // Limpia el DataGridView si no hay datos.
                    return;
                }

                _datos.DataSource = usuarios;
                dgvUsuarios.AutoGenerateColumns = true;
                dgvUsuarios.DataSource = _datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["idUsuario"].Value);
                if (_usuarioService.Eliminar(idUsuario))
                {
                    MessageBox.Show("Empleado eliminado correctamente.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el empleado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el Usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRoles_Click(object sender, EventArgs e)
        {

            RolesGestion formRoles = new RolesGestion();
            formRoles.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {

            EmpleadosGestion formEmpleado = new EmpleadosGestion();
            formEmpleado.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formEdicion = new UsuarioEdicion())
            {
                formEdicion.ShowDialog();
                CargarUsuarios();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un usario para editar.");
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdEmpleado"].Value);
            using (var formEdicion = new UsuarioEdicion(idUsuario))
            {
                formEdicion.ShowDialog();
                CargarUsuarios();
            }

        }
    }
}
