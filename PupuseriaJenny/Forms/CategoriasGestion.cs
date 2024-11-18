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
    public partial class CategoriasGestion : Form
    {
        BindingSource DATOS = new BindingSource();

        public CategoriasGestion()
        {
            InitializeComponent();
        }

        void Cargar() //Metodo para cargar los datos C: 
        {
            CategoriaService categoriaService = new CategoriaService();
            DATOS.DataSource = categoriaService.ObtenerCategorias();
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.DataSource = DATOS;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriasEdicion f = new CategoriasEdicion();
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
                    if (dgvCategorias.SelectedRows.Count > 0)
                    {


                        CategoriasEdicion f = new CategoriasEdicion();
                        f.tbIDCategoria.Text = dgvCategorias.SelectedRows[0].Cells["idCategoria"].Value.ToString();
                        f.tbCategoria.Text = dgvCategorias.SelectedRows[0].Cells["categoria"].Value.ToString();
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
                if (dgvCategorias.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este cargo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idCategoria = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["idCategoria"].Value);
                        Categorias oCategorias = new Categorias();
                        oCategorias.IdCategoria = idCategoria;
                        if (oCategorias.Eliminar())
                        {
                            MessageBox.Show("Categoria eliminada correctamente.");
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

        private void CategoriasGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
