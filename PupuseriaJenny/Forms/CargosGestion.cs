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

        BindingSource DATOS = new BindingSource();

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
    }
}
