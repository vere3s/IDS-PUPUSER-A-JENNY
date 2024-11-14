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
    public partial class PermisosGestion : Form
    {
        private readonly BindingSource _datos = new BindingSource();
        private readonly PermisoService _permisoService;

        public PermisosGestion()
        {
            InitializeComponent();
            _permisoService = new PermisoService();
            CargarPermisos();
        }

        private void CargarPermisos()
        {
            try
            {
                DataTable permisos = _permisoService.ObtenerTodos();

                if (permisos == null || permisos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de permisos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPermisos.DataSource = null;  // Limpia el DataGridView si no hay datos.
                    return;
                }

                _datos.DataSource = permisos;
                dgvPermisos.AutoGenerateColumns = true;
                dgvPermisos.DataSource = _datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formEdicion = new PermisosEdicion())
            {
                formEdicion.ShowDialog();
                CargarPermisos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dgvPermisos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un permiso para editar.");
                return;
            }

            int idPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso"].Value);
            using (var formEdicion = new PermisosEdicion(idPermiso))
            {
                formEdicion.ShowDialog();
                CargarPermisos();
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvPermisos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un permiso para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este permiso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                int idPermiso = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["idPermiso"].Value);
                if (_permisoService.Eliminar(idPermiso))
                {
                    MessageBox.Show("Permiso eliminado correctamente.");
                    CargarPermisos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Permiso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el Permiso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void PermisosGestion_Load(object sender, EventArgs e)
        {

        }
    }
}
