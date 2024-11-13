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
    public partial class UsuariosGestion : Form
    {
        public UsuariosGestion()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnRoles_Click(object sender, EventArgs e)
        {

            RolesGestion formRoles = new RolesGestion();
            formRoles.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {

            EmpleadosGestion formEmpleado = new EmpleadosGestion();
            formEmpleado.Show();
        }
    }
}
