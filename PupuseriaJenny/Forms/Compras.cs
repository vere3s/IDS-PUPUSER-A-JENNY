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
            ConfigurarDataGridView();
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
        /// SUMARY
        /// <param name="categoria">Nombre de la categoría seleccionada.</param>
        /// <SUMARY>

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


        /// Agrega un producto al detalle de la compra, excluyendo las categorías "Apupusa de Arroz" y "Maíz",
        /// y agrega una columna de ingredientes.
        private void AgregarProductoACompra(DataRow producto)
        {
            // Verificar si la categoría del producto es excluida
            if (producto.Table.Columns.Contains("categoriaProducto"))
            {
                string categoria = producto["categoriaProducto"].ToString();

                if (categoria.Equals("Apupusa de Arroz", StringComparison.OrdinalIgnoreCase) ||
                    categoria.Equals("Maíz", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"El producto '{producto["nombreProducto"]}' pertenece a una categoría excluida.",
                                    "Producto no permitido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Salir del método si es una categoría excluida
                }
            }

            // Verificar si la columna "Ingredientes" existe y obtener su valor
            string ingredientes = producto.Table.Columns.Contains("ingredientes")
                                  ? producto["ingredientes"].ToString()
                                  : "No especificados";

            // Agregar producto al DataGridView
            dgvComprasDetalles.Rows.Add(
                producto["nombreProducto"].ToString(),
                producto["cantidadProducto"].ToString(),
                producto["precioProducto"].ToString(),
                ingredientes // Agregar la información de los ingredientes
            );

            // Actualizar el total
            CalcularTotal();
        }

        private void ConfigurarDataGridView()
        {
            dgvComprasDetalles.Columns.Clear();
            dgvComprasDetalles.Columns.Add("nombreProducto", "Nombre del Producto");
            dgvComprasDetalles.Columns.Add("cantidadProducto", "Cantidad");
            dgvComprasDetalles.Columns.Add("precioProducto", "Precio");
            dgvComprasDetalles.Columns.Add("ingredientes", "Ingredientes"); // Nueva columna para ingredientes
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvComprasDetalles.Rows)
            {
                if (row.Cells["precioProducto"].Value != null &&
                    row.Cells["cantidadProducto"].Value != null &&
                    decimal.TryParse(row.Cells["precioProducto"].Value.ToString(), out decimal precio) &&
                    int.TryParse(row.Cells["cantidadProducto"].Value.ToString(), out int cantidad))
                {
                    total += precio * cantidad;
                }
            }

            tbTotal.Text = total.ToString("C");
        }
        // Funcionalidad para el botón "Pagar"
        private void rjBtnPagar_Click(object sender, EventArgs e)
        {
            // Aquí deberías agregar la lógica de pago, por ejemplo:
            // - Validar que la compra no esté vacía
            // - Registrar la compra
            // - Redirigir a una ventana de confirmación o generar factura

            if (dgvComprasDetalles.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito para pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Simulando el proceso de pago y confirmación
            MessageBox.Show("Pago realizado exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        // Funcionalidad para el botón "Salir"
        private void rjButton1_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario de compras
            this.Close();
        }

        // Funcionalidad para el botón "Eliminar Compra"
        private void rjButton2_Click(object sender, EventArgs e)
        {
            // Eliminar los productos del DataGridView
            dgvComprasDetalles.Rows.Clear();
            tbTotal.Clear();
            MessageBox.Show("La compra ha sido eliminada.", "Compra Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LimpiarFormulario()
        {
            dgvComprasDetalles.Rows.Clear();
            tbTotal.Clear();
        }

    }
}
