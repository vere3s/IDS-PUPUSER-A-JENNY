using PupuseriaJenny.Custom;
using PupuseriaJenny.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PupuseriaJenny.Forms
{
    public partial class Compras : Form
    {
       
        /// Constructor principal. Inicializa el formulario y sus componentes.
        public Compras()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        
        /// Inicializa los elementos del formulario, incluyendo categorías y productos.
        private void InicializarFormulario()
        {
            CargarBotonesCategorias();
            flpProductos.Controls.Clear();
            dgvComprasDetalles.Rows.Clear();
        }

       
        /// Carga las categorías de productos en el FlowLayoutPanel como botones.
        private void CargarBotonesCategorias()
        {
            CategoriaService categoriaService = new CategoriaService();
            flpCategorias.Controls.Clear(); // Limpia botones previos

            List<string> categoriasProductos = categoriaService.CategoriasProductos();

            foreach (string categoria in categoriasProductos)
            {
                // Crea un botón RJButton para cada categoría
                RJButton btnCategoria = new RJButton
                {
                    Text = categoria,
                    Width = 120,
                    Height = 62,
                    BorderRadius = 20,
                    BackColor = Color.DodgerBlue,
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 12),
                    Tag = categoria
                };

                // Asocia el evento de clic
                btnCategoria.Click += BtnCategoria_Click;

                // Agrega el botón al FlowLayoutPanel
                flpCategorias.Controls.Add(btnCategoria);
            }
        }

        
        /// Evento que se ejecuta al hacer clic en un botón de categoría.
        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            if (sender is RJButton btnCategoria)
            {
                string categoriaSeleccionada = btnCategoria.Tag.ToString();
                CargarProductosPorCategoria(categoriaSeleccionada);
            }
        }

        
        /// Carga los productos de una categoría específica en el FlowLayoutPanel.
        /// <param name="categoria">Nombre de la categoría seleccionada.</param>
        
        private void CargarProductosPorCategoria(string categoria)
        {
            CategoriaService categoriaService = new CategoriaService();
            flpProductos.Controls.Clear(); // Limpia productos previos

            var productos = categoriaService.ObtenerProductosPorCategoria(categoria);

            foreach (DataRow row in productos.Rows)
            {
                RJButton btnProducto = CrearBotonProducto(row);
                flpProductos.Controls.Add(btnProducto);
            }
        }

       
        /// Crea un botón para un producto específico.
        private RJButton CrearBotonProducto(DataRow producto)
        {
            RJButton btnProducto = new RJButton
            {
                Text = producto["nombreProducto"].ToString(),
                Width = 143,
                Height = 107,
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderRadius = 8,
                TextImageRelation = TextImageRelation.ImageAboveText,
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.TopCenter,
                Padding = new Padding(0)
            };

            // Intenta cargar la imagen del producto
            try
            {
                string imagePath = "/" + producto["nombreProducto"] + ".png";
                Image productoImagen = Image.FromFile(imagePath);
                btnProducto.Image = ResizeImage(productoImagen, 140, 90);
            }
            catch (Exception)
            {
                // Usa una imagen predeterminada si falla
                btnProducto.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
            }

            // Evento para manejar clics en productos
            btnProducto.Click += (s, ev) => AgregarProductoACompra(producto);

            return btnProducto;
        }

        
        /// Redimensiona una imagen a un tamaño específico.
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

      
        /// Agrega un producto al detalle de la compra.
        private void AgregarProductoACompra(DataRow producto)
        {
            dgvComprasDetalles.Rows.Add(
                producto["nombreProducto"].ToString(),
                producto["cantidadProducto"].ToString(),
                producto["precioProducto"].ToString()
            );

            // Calcula el total después de agregar un producto
            CalcularTotal();
        }


        /// Calcula y actualiza el total de la compra.
        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvComprasDetalles.Rows)
            {
                if (row.Cells["precioProducto"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["precioProducto"].Value.ToString(), out decimal precioProducto))
                    {
                        total += precioProducto;
                    }
                }
            }

            // Muestra el total en el control correspondiente
            tbTotal.Text = total.ToString("C");
        }

       
    }
}
