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
    public partial class CargosGestion : Form
    {

       private readonly BindingSource DATOS = new BindingSource();

        public CargosGestion()
        {
            InitializeComponent();
        }

        void Cargar() //Metodo para cargar los datos C: 
        {
            CargoService rolesService = new CargoService();
            DATOS.DataSource = rolesService.ObtenerCargos();
            dgvCargos.AutoGenerateColumns = false;
            dgvCargos.DataSource = DATOS;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                CargosEdicion f = new CargosEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvCargos.SelectedRows.Count > 0)
                    {


                        CargosEdicion f = new CargosEdicion();
                        f.tbIDCargo.Text = dgvCargos.SelectedRows[0].Cells["idCargo"].Value.ToString();
                        f.tbCargo.Text = dgvCargos.SelectedRows[0].Cells["cargo"].Value.ToString();
                        f.ShowDialog();
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un rol para editar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                // Delete the selected
                if (dgvCargos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este cargo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idCargo = Convert.ToInt32(dgvCargos.SelectedRows[0].Cells["idCargo"].Value);
                        Cargos oCargo = new Cargos();
                        oCargo.IdCargo = idCargo;
                        if (oCargo.Eliminar())
                        {
                            MessageBox.Show("Cargo eliminado correctamente.");
                            Cargar();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el cargo.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un Cargo para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Cargo: " + ex.Message);
            }

        }

        private void CargosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void FiltrarLocalmente()
        {
            try
            {
                if (DATOS.DataSource is DataTable dt)
                {
                    // Verificar si la columna 'cargo' existe en el DataTable
                    if (!dt.Columns.Contains("cargo"))
                    {
                        MessageBox.Show("La columna 'cargo' no existe.");
                        return;
                    }

                    // Aplicar el filtro sobre el DataTable
                    if (tbFiltro.Text.Trim().Length > 0)
                    {
                        string filterExpression = "cargo LIKE '%" + tbFiltro.Text + "%'";
                        // Filtrar los datos
                        dt.DefaultView.RowFilter = filterExpression;
                    }
                    else
                    {
                        // Eliminar el filtro
                        dt.DefaultView.RowFilter = string.Empty;
                    }

                    // Actualizar el DataGridView
                    dgvCargos.AutoGenerateColumns = false;
                    dgvCargos.DataSource = DATOS;
                }
                else
                {
                    MessageBox.Show("El origen de datos no es un DataTable.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();    
           
        }
    }
}
