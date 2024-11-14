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
    public partial class RolesGestion : Form
    {
       
        BindingSource DATOS = new BindingSource();
        public RolesGestion()
        {
            InitializeComponent();
        }

        void Cargar()
        {
            RolesService rolesService = new RolesService();
            DATOS.DataSource = rolesService.ObtenerRoles();
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.DataSource = DATOS;
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
                    DATOS.Filter = "Rol LIKE '%" + tbFiltro.Text + "%'";

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                RolesEdicion f = new RolesEdicion();
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
                    if (dgvRoles.SelectedRows.Count > 0)
                    {

                        RolesEdicion f = new RolesEdicion(); // Pass the idRol to the RolesEdicion form
                        f.tbIDRol.Text = dgvRoles.SelectedRows[0].Cells["idRol"].Value.ToString();
                        f.tbRol.Text = dgvRoles.SelectedRows[0].Cells["Rol"].Value.ToString();
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
                // Delete the selected role
                if (dgvRoles.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idRol = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["idRol"].Value);
                        Roles oRol = new Roles();
                        oRol.idRol = idRol;
                        if (oRol.Eliminar())
                        {
                            MessageBox.Show("Rol eliminado correctamente.");
                            Cargar();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el rol.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un rol para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el rol: " + ex.Message);
            }

        }

        private void RolesGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            PermisosGestion formPermisos = new PermisosGestion();
            formPermisos.Show();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
           OpcionesGestion formOpciones = new OpcionesGestion();
            formOpciones.Show();
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            CargosGestion formCargos = new CargosGestion();
            formCargos.Show();

        }
    }
}
