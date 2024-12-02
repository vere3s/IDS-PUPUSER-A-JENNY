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
    public partial class visorCompras : Form
    {
        public visorCompras()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.ComprasIngredientes rCompras = new Reports.ComprasIngredientes();
                rCompras.SetDataSource(Services.CompraService.SEGUN_PERIODO_COMPRAS_INGREDIENTES(dpInicio.Text, dpFinal.Text));
                crvVisorCompras.ReportSource = rCompras;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
