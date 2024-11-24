using PupuseriaJenny.Custom;
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
        }
        private void AbrirDetallesOrdenForm(string tipoOrden)
        {
            // Crea una instancia del formulario de detalles y pasa el tipo de orden
            DetallesOrdenLlevarForm detallesOrdenForm = new DetallesOrdenLlevarForm(tipoOrden);
            detallesOrdenForm.Owner = this; // Establece SeleccionarVentasForm como padre
            detallesOrdenForm.ShowDialog();
            this.Show();
        }
        private void AbrirDetallesMesaForm(string tipoOrden)
        {
            // Crea una instancia del formulario de detalles y pasa el tipo de orden
            DetallesOrdenMesaForm detallesOrdenForm = new DetallesOrdenMesaForm(tipoOrden);
            this.Hide(); // Oculta el formulario actual
            detallesOrdenForm.ShowDialog();
            this.Show();
        }

        private void btnPedidosAbiertos_Click(object sender, EventArgs e)
        {
            MostrarOrdenesPendientesForm mostrarOrdenesForm = new MostrarOrdenesPendientesForm();
            this.Hide();
            mostrarOrdenesForm.ShowDialog();
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
