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
    public partial class IngredienteGestion : Form
    {
        private readonly BindingSource _datos = new BindingSource();
        private readonly IngredienteService _ingredienteService;

        public IngredienteGestion()
        {
            InitializeComponent();
            _ingredienteService = new IngredienteService();
            CargarIngredientes();
        }
        private void CargarIngredientes()
        {
            try
            {
                DataTable ingredientes = _ingredienteService.ObtenerTodos();

                if (ingredientes == null || ingredientes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de ingredientes para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductos.DataSource = null;  // Limpia el DataGridView si no hay datos.
                    return;
                }

                _datos.DataSource = ingredientes;
                dgvIngrediente.AutoGenerateColumns = true;
                dgvIngrediente.DataSource = _datos;
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
                    _datos.Filter = "nombreIngrediente like '%" + tbFiltro.Text + "%'"; ;
                }
                dgvIngrediente.AutoGenerateColumns = false;
                dgvIngrediente.DataSource = _datos;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formEdicion = new IngredientesEdicion())
            {
                formEdicion.ShowDialog();
                CargarIngredientes();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvIngrediente.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un ingrediente para editar.");
                return;
            }

            int idIngrediente = Convert.ToInt32(dgvIngrediente.CurrentRow.Cells["idIngrediente"].Value);
            using (var formEdicion = new IngredientesEdicion(idIngrediente))
            {
                formEdicion.ShowDialog();
                CargarIngredientes();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un Ingrediente para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este Ingrediente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                int idIngrediente = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["idIngrediente"].Value);
                if (_ingredienteService.Eliminar(idIngrediente))
                {
                    MessageBox.Show("Ingrediente eliminado correctamente.");
                    CargarIngredientes();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Ingrediente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el Ingrediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbFiltro_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            CategoriasGestion formCategoria = new CategoriasGestion();
            formCategoria.Show();
        }
    }
}
