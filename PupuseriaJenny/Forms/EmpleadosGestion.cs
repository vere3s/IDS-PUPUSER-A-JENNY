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
    public partial class EmpleadosGestion : Form
    {
        private readonly BindingSource _datos = new BindingSource();
        private readonly EmpleadoService _empleadoService;

        public EmpleadosGestion()
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable empleados = _empleadoService.ObtenerTodos();

                if (empleados == null || empleados.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de empleados para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;  // Limpia el DataGridView si no hay datos.
                    return;
                }

                _datos.DataSource = empleados;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = _datos;
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
                CargarEmpleados();
            }
        }

        private void EmpleadosGestion_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                int idEmpleado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idEmpleado"].Value);
                if (_empleadoService.Eliminar(idEmpleado))
                {
                    MessageBox.Show("Empleado eliminado correctamente.");
                    CargarEmpleados();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el empleado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado para editar.");
                return;
            }

            int idEmpleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value);
            using (var formEdicion = new EmpleadosEdicion(idEmpleado))
            {
                formEdicion.ShowDialog();
                CargarEmpleados();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CargosGestion formCargos = new CargosGestion();
            formCargos.Show();
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
                    _datos.Filter = "nombreEmpleado like '%" + tbFiltro.Text + "%'"; ;
                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _datos;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
