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
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.");
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

        private void FiltrarLocalmente()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbFiltro.Text))
                {
                    // Si el filtro está vacío, eliminamos el filtro
                    _datos.Filter = string.Empty;
                }
                else
                {
                    // Aplicamos el filtro con el texto introducido en el TextBox
                    _datos.Filter = "usuario LIKE '%" + tbFiltro.Text + "%'";
                }
                // El DataGridView se actualizará automáticamente debido a que el BindingSource se actualiza.
                dgvUsuarios.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el filtro: {ex.Message}");
            }
        }

        // Llamar a FiltrarLocalmente en el evento TextChanged del TextBox (tbFiltro)
        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }


        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
