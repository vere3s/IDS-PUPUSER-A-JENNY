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
    public partial class OpcionesGestion : Form
    {
        BindingSource DATOS = new BindingSource();
        public OpcionesGestion()
        {
            InitializeComponent();
        }
        void Cargar()
        {
            OpcionService opcionesService = new OpcionService();
            DATOS.DataSource = opcionesService.ObtenerOpcions();
            dgvOpciones.AutoGenerateColumns = false;
            dgvOpciones.DataSource = DATOS;
        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (tbFiltro.Text.Trim().Length <= 0)
                {
                    DATOS.RemoveFilter();
                }
                else
                {
                    DATOS.Filter = "opcion LIKE '%" + tbFiltro.Text + "%'";

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete the selected role
                if (dgvOpciones.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idOpcion = Convert.ToInt32(dgvOpciones.SelectedRows[0].Cells["idOpcion"].Value);
                        Opciones oOpcion = new Opciones();
                        oOpcion.IdOpcion = idOpcion;
                        if (oOpcion.Eliminar())
                        {
                            MessageBox.Show("Opción eliminada correctamente.");
                            Cargar();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la opción.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una opción para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la opción: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvOpciones.SelectedRows.Count > 0)
                    {

                        OpcionesEdicion f = new OpcionesEdicion(); 
                        f.tbIDOpcion.Text = dgvOpciones.SelectedRows[0].Cells["idOpcion"].Value.ToString();
                        f.tbOpcion.Text = dgvOpciones.SelectedRows[0].Cells["opcion"].Value.ToString();
                        f.ShowDialog();
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione una opción para editar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                OpcionesEdicion  f = new OpcionesEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OpcionesGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
