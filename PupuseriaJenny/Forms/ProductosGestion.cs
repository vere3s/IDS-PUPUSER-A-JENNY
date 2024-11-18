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
    public partial class ProductosGestion : Form
    {
        private readonly BindingSource _datos = new BindingSource();
        private readonly ProductoService _productoService;

        public ProductosGestion()
        {
            InitializeComponent();
            _productoService = new ProductoService();
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                DataTable productos = _productoService.ObtenerTodos();

                if (productos == null || productos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de productos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductos.DataSource = null;  // Limpia el DataGridView si no hay datos.
                    return;
                }

                _datos.DataSource = productos;
                dgvProductos.AutoGenerateColumns = true;
                dgvProductos.DataSource = _datos;
                lbRegistros.Text = _datos.Count.ToString();
                FiltrarLocalmente();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (tbFiltro.Text.Trim().Length <= 0)
                {
                    _datos.RemoveFilter();
                }
                else
                {
                    _datos.Filter = "Nombre like '%" + tbFiltro.Text + "%'"; ;
                }
                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.DataSource = _datos;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formEdicion = new ProductosEdicion())
            {
                formEdicion.ShowDialog();
                CargarProductos();
            }
        }

        private void ProductosGestion_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                int idProducto = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["idProducto"].Value);
                if (_productoService.Eliminar(idProducto))
                {
                    MessageBox.Show("Producto eliminado correctamente.");
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un producto para editar.");
                return;
            }

            int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["idProducto"].Value);
            using (var formEdicion = new ProductosEdicion(idProducto))
            {
                formEdicion.ShowDialog();
                CargarProductos();
            }
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
