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
    public partial class SeleccionarVentasForm : Form
    {
        public SeleccionarVentasForm()
        {
            InitializeComponent();
        }
        private void btnOpcionLlevar_Click(object sender, EventArgs e)
        {
            AbrirDetallesOrdenForm("Llevar");
        }

        private void btnOpcionRestaurante_Click(object sender, EventArgs e)
        {
            AbrirDetallesMesaForm("Comer en Restaurante");
            this.Close();
            this.Dispose();
        }
        private void AbrirDetallesOrdenForm(string tipoOrden)
        {
            // Crea una instancia del formulario de detalles y pasa el tipo de orden
            DetallesOrdenLlevarForm detallesOrdenForm = new DetallesOrdenLlevarForm(tipoOrden);
            detallesOrdenForm.ShowDialog();
        }
        private void AbrirDetallesMesaForm(string tipoOrden)
        {
            // Crea una instancia del formulario de detalles y pasa el tipo de orden
            DetallesOrdenMesaForm detallesOrdenForm = new DetallesOrdenMesaForm(tipoOrden);
            detallesOrdenForm.ShowDialog();
        }

        private void btnPedidosAbiertos_Click(object sender, EventArgs e)
        {
            MostrarOrdenesPendientesForm mostrarOrdenesForm = new MostrarOrdenesPendientesForm();
            mostrarOrdenesForm.ShowDialog();
            this.Close();
        }
    }
}
