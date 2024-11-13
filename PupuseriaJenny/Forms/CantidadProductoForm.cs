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
    public partial class CantidadProductoForm : Form
    {
        public int Cantidad { get; private set; }
        public CantidadProductoForm()
        {
            InitializeComponent();
            numCantidad.Minimum = 1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Cantidad = (int)numCantidad.Value;  // Almacena la cantidad seleccionada
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
