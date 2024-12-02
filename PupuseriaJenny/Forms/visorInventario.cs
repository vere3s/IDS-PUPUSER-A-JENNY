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
    public partial class visorInventario : Form
    {
        public visorInventario()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.InventarioIngrediente rInventarioIngrediente = new Reports.InventarioIngrediente();
                rInventarioIngrediente.SetDataSource(Services.SalidaService.SEGUN_PERIODO_INVENTARIO_INGREDIENTES(dpInicio.Text, dpFinal.Text));
                crvVisorCompras.ReportSource = rInventarioIngrediente;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
