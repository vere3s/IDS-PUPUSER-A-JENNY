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
    public partial class ProveedorGestion : Form
    {
        private readonly BindingSource _datos = new BindingSource();
        private readonly ProveedorService _proveedorService;
        public ProveedorGestion()
        {
            InitializeComponent();
            _proveedorService = new ProveedorService();
            CargarProveedor();

        }

        private void CargarProveedor()
        {
            try
            {
                DataTable proveedor = _proveedorService.ObtenerTodos();

                if (proveedor == null || proveedor.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de proveedores para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewP.DataSource = null;  // Limpia el DataGridView si no hay datos.
                    return;
                }

                _datos.DataSource = proveedor;
                dataGridViewP.AutoGenerateColumns = true;
                dataGridViewP.DataSource = _datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formEdicion = new EmpleadosEdicion())
            {
                formEdicion.ShowDialog();
                CargarProveedor();
            }
        }

        private void ProveedorGestion_Load(object sender, EventArgs e)
        {
            CargarProveedor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya un proveedor seleccionado
            if (dataGridViewP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para eliminar.");
                return;
            }

            // Confirmar eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este proveedor?",
                                                "Confirmación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                // Obtener el IdProveedor de la fila seleccionada
                int idProveedor = Convert.ToInt32(dataGridViewP.SelectedRows[0].Cells["IdProveedor"].Value);

                // Llamar al servicio para eliminar el proveedor
                if (_proveedorService.EliminarProveedor(idProveedor))
                {
                    MessageBox.Show("Proveedor eliminado correctamente.");

                    // Recargar datos del DataGridView
                    CargarProveedor();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el proveedor. Verifique la información.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewP.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un Proveedor para editar.");
                return;
            }

            int idEmpleado = Convert.ToInt32(dataGridViewP.CurrentRow.Cells["IdProveedor"].Value);
            using (var formEdicion = new EmpleadosEdicion(idEmpleado))
            {
                formEdicion.ShowDialog();
                CargarProveedor();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CargosGestion formCargos = new CargosGestion();
            formCargos.Show();
        }
    }
}
