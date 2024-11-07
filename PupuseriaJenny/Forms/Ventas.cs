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
        }
        private void CargarBotonesCategorias()
        {
            // Limpia cualquier botón previo en el FlowLayoutPanel
            flpCategorias.Controls.Clear();

            // Obtiene las categorías de productos desde la base de datos
            List<string> categoriasProductos = CategoriaService.CategoriasProductos();

            foreach (string categoria in categoriasProductos)
            {
                // Crea un nuevo botón RJButton
                RJButton btnCategoria = new RJButton
                {
                    Text = categoria,  // Establece el nombre de la categoría como texto del botón
                    Width = 104,
                    Height = 46,
                    BorderRadius = 20,
                    BackColor = Color.DodgerBlue,
                    ForeColor = Color.White
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
                string categoriaSeleccionada = btnCategoria.Tag.ToString();

                // Limpia productos previos en el FlowLayoutPanel
                flpProductos.Controls.Clear();

                // Obtiene los productos de la categoría seleccionada
                var productos = CategoriaService.ObtenerProductosPorCategoria(categoriaSeleccionada);

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
                        Image productoImagen = Image.FromFile("ruta_de_tu_imagen/" + row["nombreProducto"].ToString() + ".png");
                        btnProducto.Image = ResizeImage(productoImagen, 140, 90); 
                    }
                    catch (Exception)
                    {
                        // Si falla usa una imagen predeterminada
                        Image imagenPredeterminada = Properties.Resources.imagenPredeterminada;
                        btnProducto.Image = ResizeImage(imagenPredeterminada, 132, 80);
                    }

                    // Agrega el botón de producto al FlowLayoutPanel
                    flpProductos.Controls.Add(btnProducto);
                }
            }
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
    }
}
