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
    public partial class IngredientesEdicion : Form
    {

        private readonly IngredienteService _ingredienteService;
        private readonly CategoriaService _categoriaService;
        private int? _idIngrediente;
        public IngredientesEdicion(int? idIngrediente = null)
        {
            InitializeComponent();
            _ingredienteService = new IngredienteService();
            _categoriaService = new CategoriaService();
            _idIngrediente = idIngrediente;
            CargarCategorias();
            if (_idIngrediente.HasValue)
            {
                CargarDatosIngredientes(_idIngrediente.Value);
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

            Ingredientes ingredientes = new Ingredientes
            {
                NombreIngrediente = tbNombre.Text,
                PrecioIngrediente = Convert.ToDecimal(tbPrecio.Text),
                IdCategoria = (int)cbCategorias.SelectedValue,
                ImagenIngrediente = tbImagen.Text
            };

            bool resultado;
            if (_idIngrediente.HasValue)
            {
                ingredientes.IdIngrediente = _idIngrediente.Value;
                resultado = _ingredienteService.Actualizar(ingredientes);
            }
            else
            {
                resultado = _ingredienteService.Insertar(ingredientes);
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


        private void CargarDatosIngredientes(int idIngrediente)
        {
            var ingrediente = _ingredienteService.ObtenerPorId(idIngrediente);
            if (ingrediente != null)
            {
                tbIDIngrediente.Text = ingrediente.IdIngrediente.ToString();
                tbNombre.Text = ingrediente.NombreIngrediente;
                tbPrecio.Text = ingrediente.PrecioIngrediente.ToString();
                cbCategorias.SelectedValue = ingrediente.IdCategoria;
                tbImagen.Text = ingrediente.ImagenIngrediente;
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void IngredientesEdicion_Load(object sender, EventArgs e)
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
