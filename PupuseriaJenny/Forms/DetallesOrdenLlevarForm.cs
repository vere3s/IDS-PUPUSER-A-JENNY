using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PupuseriaJenny.Forms
{
    public partial class DetallesOrdenLlevarForm : Form
    {
        private readonly OrdenService _ordenService; // Instancia de OrdenService
        private readonly string _tipoOrden;

        public DetallesOrdenLlevarForm(string tipoOrden)
        {
            InitializeComponent();
            _ordenService = new OrdenService();
            _tipoOrden = tipoOrden;
            this.FormClosed += (s, e) => this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CrearOrden();
        }
        private void CrearOrden()
        {
            Ordenes nuevaOrden = new Ordenes
            {
                ClienteOrden = tbCliente.Text,
                FechaOrden = DateTime.Now,
                TipoOrden = _tipoOrden,
                EstadoOrden = "Pendiente",
                ComentarioOrden = tbComentario.Text,
                IdMesa = 0
            };

            // Llama al método Insertar y captura el ID generado 
            int idOrden = _ordenService.Insertar(nuevaOrden);

            if (idOrden > 0)
            {
                // Abre el formulario de ventas
                AbrirOrdenVentasForm(idOrden);

                // Cierra el formulario de detalles
                this.Close();
                this.Dispose();
                new SeleccionarVentasForm().Close();
                //MessageBox.Show("Orden creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al crear la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirOrdenVentasForm(int idOrden)
        {
            OrdenVentasForm ordenVentasForm = new OrdenVentasForm(idOrden);
            ordenVentasForm.ShowDialog();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
