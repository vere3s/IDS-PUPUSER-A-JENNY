using PupuseriaJenny.Custom;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
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
    public partial class DetallesOrdenMesaForm : Form
    {
        private readonly OrdenService _ordenService; // Instancia de OrdenService
        private string _tipoOrden;
        public DetallesOrdenMesaForm(string tipoOrden)
        {
            InitializeComponent();
            _ordenService = new OrdenService();
            _tipoOrden = tipoOrden;
            mostrarMesas();
        }
        private void mostrarMesas()
        {
            MesaService mesaService = new MesaService();
            // Obtiene las mesas de la categoría seleccionada
            var mesas = mesaService.Mesa();

            foreach (DataRow row in mesas.Rows)
            {
                // Crea un botón para cada mesa
                RJButton btnMesa = CrearBotonMesa(row);
                flpMesas.Controls.Add(btnMesa);
            }
        }
        private RJButton CrearBotonMesa(DataRow row)
        {
            // Crea un botón para cada mesa
            RJButton btnMesa = new RJButton
            {
                Text = row["numeroMesa"].ToString(),
                Width = 193,
                Height = 147,
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderRadius = 8,
                Font = new Font("Microsoft Sans Serif", 14),
                TextImageRelation = TextImageRelation.ImageAboveText,
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.TopCenter,
                Padding = new Padding(0),
                Margin = new Padding(30),
            };
            Image imagenPredeterminada = Properties.Resources.imageTable;
            btnMesa.Image = ResizeImage(imagenPredeterminada, 152, 110);
            btnMesa.Click += (s, ev) => DetallesOrdenMesa(row);
            return btnMesa;
        }
        public void DetallesOrdenMesa(DataRow mesa)
        {
            tbMesa.Text = mesa["numeroMesa"].ToString();
            
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CrearOrden();
        }
        private void CrearOrden()
        {
            // Se crea una nueva orden con los datos del formulario
            Ordenes nuevaOrden = new Ordenes
            {
                ClienteOrden = tbCliente.Text,
                FechaOrden = DateTime.Now,
                TipoOrden = _tipoOrden,
                EstadoOrden = "Pendiente",
                ComentarioOrden = tbComentario.Text,
                IdMesa = int.Parse(tbMesa.Text)
            };

            // Llama al método Insertar y captura el ID generado
            int idOrden = _ordenService.Insertar(nuevaOrden);

            if (idOrden > 0)
            {
                this.Close();
                //this.Dispose();
                // Abre el formulario de ventas
                AbrirOrdenVentasForm(idOrden);
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
            ordenVentasForm.NumeroMesa = tbMesa.Text;  // Pasa el número de mesa
            ordenVentasForm.ShowDialog();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
            AbrirSeleccionarVentasForm();
        }
        private void AbrirSeleccionarVentasForm()
        {
            SeleccionarVentasForm seleccionarVentasForm = new SeleccionarVentasForm();
            seleccionarVentasForm.ShowDialog();
        }
    }
}
