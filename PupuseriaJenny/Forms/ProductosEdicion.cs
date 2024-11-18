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
    public partial class ProductosEdicion : Form
    {
        private readonly ProductoService _productoService;
        private readonly CategoriaService _categoriaService;
        private int? _idProducto;

        public ProductosEdicion(int? idProducto = null)
        {
            InitializeComponent();
            _productoService = new ProductoService();
            _categoriaService = new CategoriaService();
            _idProducto = idProducto;
            CargarCategorias();
            if (_idProducto.HasValue)
            {
                CargarDatosProducto(_idProducto.Value);
            }
        }
        private void CargarCategorias()
        {
            var categoria = _categoriaService.ObtenerCategorias();
            cbCategorias.DataSource = categoria;
            cbCategorias.DisplayMember = "categoria";
            cbCategorias.ValueMember = "idCategoria";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos
            {
                NombreProducto = tbNombre.Text,
                CostoUnitarioProducto = Convert.ToDecimal(tbCostoUnitario.Text),
                PrecioProducto = Convert.ToDecimal(tbPrecio.Text),
                IdCategoria = (int)cbCategorias.SelectedValue,
                ImagenProducto = tbImagen.Text
            };

            bool resultado;
            if (_idProducto.HasValue)
            {
                productos.IdProducto = _idProducto.Value;
                resultado = _productoService.Actualizar(productos);
            }
            else
            {
                resultado = _productoService.Insertar(productos);
            }

            if (resultado)
            {
                MessageBox.Show("Producto guardado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el producto.");
            }
        }
        private void CargarDatosProducto(int idProducto)
        {
            var producto = _productoService.ObtenerPorId(idProducto);
            if (producto != null)
            {
                tbIDProducto.Text = producto.IdProducto.ToString();
                tbNombre.Text = producto.NombreProducto;
                tbCostoUnitario.Text = producto.CostoUnitarioProducto.ToString();
                tbPrecio.Text = producto.PrecioProducto.ToString();
                cbCategorias.SelectedValue = producto.IdCategoria;
                tbImagen.Text = producto.ImagenProducto;
            }
        }

        private void ProductosEdicion_Load(object sender, EventArgs e)
        {
            List<Categorias> categorias = _categoriaService.ObtenerCategorias();

            if (categorias != null && categorias.Count > 0)
            {
                cbCategorias.DataSource = categorias;
                cbCategorias.DisplayMember = "categoria"; // Propiedad que deseas mostrar
                cbCategorias.ValueMember = "idCategoria";       // Valor asociado al item
            }
            else
            {
                MessageBox.Show("No se encontraron categorias para mostrar en el ComboBox.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configura las opciones del OpenFileDialog
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // Carpeta predeterminada
                openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos (*.*)|*.*"; // Filtro
                openFileDialog.Title = "Seleccionar imagen";

                // Muestra el diálogo y verifica si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene la ruta seleccionada
                    string rutaImagen = openFileDialog.FileName;

                    // Asigna la ruta al campo de texto
                    tbImagen.Text = rutaImagen;

                    // Opcional: Muestra una vista previa de la imagen en un PictureBox
                    pbImagen.Image = Image.FromFile(rutaImagen);
                }
            }
        }
    }
}
