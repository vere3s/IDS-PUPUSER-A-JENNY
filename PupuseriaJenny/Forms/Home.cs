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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnGtPersonal_Click(object sender, EventArgs e)
        {
            UsuariosGestion formUsuarios = new UsuariosGestion();
            formUsuarios.Show();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            SeleccionarVentasForm formVentas = new SeleccionarVentasForm();
            formVentas.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            Compras formCompras = new Compras();
            formCompras.Show();
        }

        private void btnGtProductos_Click(object sender, EventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            InventarioForm formInventario = new InventarioForm();
            formInventario.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }
    }
}
