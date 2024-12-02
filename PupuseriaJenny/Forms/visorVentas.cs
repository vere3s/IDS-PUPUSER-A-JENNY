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
    public partial class visorVentas : Form
    {
        public visorVentas()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.Ventas rVentas = new Reports.Ventas();
                rVentas.SetDataSource(Services.VentaService.SEGUN_PERIODO_VENTAS(dpInicio.Text, dpFinal.Text));
                crvVisorVentas.ReportSource = rVentas;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
