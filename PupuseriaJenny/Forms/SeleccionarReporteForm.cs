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
    public partial class SeleccionarReporteForm : Form
    {
        public SeleccionarReporteForm()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                visorVentas visorVentas = new visorVentas();
                this.Close();
                visorVentas.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                visorCompras visorCompras = new visorCompras();
                this.Close();
                visorCompras.Show();
            }
            catch (Exception)
            {


            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                visorInventario visorInventario = new visorInventario();
                this.Close();
                visorInventario.Show();
            }
            catch (Exception)
            {


            }
        }
    }
}
