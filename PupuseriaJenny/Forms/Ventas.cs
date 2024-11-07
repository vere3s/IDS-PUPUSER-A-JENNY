using PupuseriaJenny.CLS;
using PupuseriaJenny.Custom;
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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            CargarBotonesCategorias();
            flpProductos.Controls.Clear();
            dgvProductosDetalles.Rows.Clear();  // Limpia el DataGridView
        }
        private void CargarBotonesCategorias()
        {
            CategoriaService categoriaService = new CategoriaService();
            // Limpia cualquier botón previo en el FlowLayoutPanel
            flpCategorias.Controls.Clear();

            // Obtiene las categorías de productos desde la base de datos
            List<string> categoriasProductos = categoriaService.CategoriasProductos();

            foreach (string categoria in categoriasProductos)
            {
                // Crea un nuevo botón RJButton
                RJButton btnCategoria = new RJButton
                {
                    Text = categoria,  // Establece el nombre de la categoría como texto del botón
                    Width = 120,
                    Height = 62,
                    BorderRadius = 20,
                    BackColor = Color.DodgerBlue,
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 12)
                };
                btnCategoria.Tag = categoria;
                // Evento de clic
                btnCategoria.Click += BtnCategoria_Click;

                // Se agrega el botón al FlowLayoutPanel
                flpCategorias.Controls.Add(btnCategoria);
            }
        }
        // Evento de clic para los botones RJButton
        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            RJButton btnCategoria = sender as RJButton;
            if (btnCategoria != null)
            {
                CategoriaService categoriaService = new CategoriaService();
                string categoriaSeleccionada = btnCategoria.Tag.ToString();

                // Limpia productos previos en el FlowLayoutPanel
                flpProductos.Controls.Clear();

                // Obtiene los productos de la categoría seleccionada
                var productos = categoriaService.ObtenerProductosPorCategoria(categoriaSeleccionada);

                foreach (DataRow row in productos.Rows)
                {
                    // Crea un botón para cada producto
                    RJButton btnProducto = new RJButton
                    {
                        Text = row["nombreProducto"].ToString(),  // Establece el nombre del producto
                        Width = 143,
                        Height = 107,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                        BorderRadius = 8,
                        TextImageRelation = TextImageRelation.ImageAboveText,
                        TextAlign = ContentAlignment.MiddleCenter,  
                        ImageAlign = ContentAlignment.TopCenter,  
                        Padding = new Padding(0),
                    };
                    try
                    {
                        Image productoImagen = Image.FromFile("/" + row["nombreProducto"].ToString() + ".png");
                        btnProducto.Image = ResizeImage(productoImagen, 140, 90); 
                    }
                    catch (Exception)
                    {
                        // Si falla usa una imagen predeterminada
                        Image imagenPredeterminada = Properties.Resources.imagenPredeterminada;
                        btnProducto.Image = ResizeImage(imagenPredeterminada, 132, 80);
                    }
                    // Agrega el evento Click al botón del producto
                    btnProducto.Click += (s, ev) => DetallesProductosVenta(row);

                    // Agrega el botón de producto al FlowLayoutPanel
                    flpProductos.Controls.Add(btnProducto);
                }
            }
        }
        // Método para mostrar los detalles del producto en el DataGridView
        private void DetallesProductosVenta(DataRow producto)
        {

            dgvProductosDetalles.Rows.Add(
                producto["nombreProducto"].ToString(),
                producto["costoUnitarioProducto"].ToString(),
                producto["precioProducto"].ToString()
            );

            // Agrega los detalles del producto
            //dgvProductosDetalles.Rows.Add("idProducto", producto["idProducto"]);
            //dgvProductosDetalles.Rows.Add("nombreProducto", producto["nombreProducto"]);
            //dgvProductosDetalles.Rows.Add("costoUnitarioProducto", producto["costoUnitarioProducto"]);
            //dgvProductosDetalles.Rows.Add("precioProducto", producto["precioProducto"]);
            //dgvProductosDetalles.Rows.Add("idCategoria", producto["idCategoria"]);
            //dgvProductosDetalles.Rows.Add("idProveedor", producto["idProveedor"]);

            // Llama al método para actualizar los totales
            CalcularTotales();
        }

        // Método para redimensionar la imagen
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
        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal descuento = 0;
            decimal total = 0;
            decimal cortesia = 0;

            // Se recorren las filas del DataGridView para calcular el subtotal
            foreach (DataGridViewRow row in dgvProductosDetalles.Rows)
            {
                if (row.Cells["precioProducto"].Value != null)
                {
                    decimal precioProducto = Convert.ToDecimal(row.Cells["precioProducto"].Value);
                    subtotal += precioProducto;
                }
            }

            // Obtiene el valor del descuento si existe (ejemplo: 10% = 0.10m)
            if (decimal.TryParse(tbDescuento.Text, out decimal descuentoPorcentaje))
            {
                descuento = subtotal * (descuentoPorcentaje / 100);
            }

            // Calcula el total con descuento
            total = subtotal - descuento;

            // Verifica si está activado el CheckBox de cortesía
            if (cbCortesia.Checked)
            {
                tbCortesia.Text = total.ToString("C");
                tbTotal.Text = cortesia.ToString("C");
            } else
            {
                // Muestra los valores en los controles del TableLayoutPanel
                tbSubTotal.Text = subtotal.ToString("C");
                tbDescuento.Text = descuento.ToString("C");
                tbTotal.Text = total.ToString("C");
                tbCortesia.Text = cortesia.ToString("C");
            }
        }

        private void tbDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void cbCortesia_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }
    }
}
