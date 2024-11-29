using iText.Layout.Borders;
using PupuseriaJenny.Custom;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PupuseriaJenny.Forms
{
    public partial class DescargarInventarioForm : Form
    {
        public DescargarInventarioForm()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }
        private void ConfigurarFormulario()
        {
            CargarBotonesCategorias();
            flpIngredientes.Controls.Clear();
            dgvIngredientesDetalles.Rows.Clear();  // Limpia el DataGridView
        }
        private void CargarBotonesCategorias()
        {
            CategoriaService categoriaService = new CategoriaService();

            // Obtiene las categorías de productos desde la base de datos
            List<string> categoriasIngredientes = categoriaService.CategoriasIngredientes();

            // Limpia cualquier botón previo en el FlowLayoutPanel
            flpCategorias.Controls.Clear();

            foreach (string categoria in categoriasIngredientes)
            {
                // Crea un nuevo botón RJButton
                RJButton btnCategoria = CrearBotonCategoria(categoria);

                // Se agrega el botón al FlowLayoutPanel
                flpCategorias.Controls.Add(btnCategoria);
            }
        }
        private RJButton CrearBotonCategoria(string categoria)
        {
            RJButton btnCategoria = new RJButton
            {
                Text = categoria, // Establece el nombre de la categoría como texto del botón
                Width = 120,
                Height = 62,
                BorderRadius = 20,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 12),
                Tag = categoria
            };
            // Evento de clic
            btnCategoria.Click += BtnCategoria_Click;
            return btnCategoria;
        }
        // Evento de clic para los botones RJButton
        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            RJButton btnCategoria = sender as RJButton;
            if (btnCategoria != null)
            {
                string categoriaSeleccionada = btnCategoria.Tag.ToString();
                CargarIngredientesPorCategoria(categoriaSeleccionada);
            }
        }
        private void CargarIngredientesPorCategoria(string categoria)
        {
            CategoriaService categoriaService = new CategoriaService();
            // Obtiene los ingredientes de la categoría seleccionada
            DataTable ingredientes = categoriaService.ObtenerIngredientesPorCategoria(categoria);
            // Limpia ingredientes previos en el FlowLayoutPanel
            flpIngredientes.Controls.Clear();

            foreach (DataRow row in ingredientes.Rows)
            {
                // Crea un botón para cada ingrediente
                RJButton btnIngrediente = CrearBotonIngrediente(row);

                // Agrega el botón de producto al FlowLayoutPanel
                flpIngredientes.Controls.Add(btnIngrediente);
            }
        }
        private RJButton CrearBotonIngrediente(DataRow row)
        {
            RJButton btnIngrediente = new RJButton
            {
                Text = row["nombreIngrediente"].ToString(),  // Establece el nombre del ingrediente
                Width = 143,
                Height = 107,
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderRadius = 8,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                TextImageRelation = TextImageRelation.ImageAboveText,
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.TopCenter,
                Padding = new Padding(0),
            };

            try
            {
                // Verifica si el campo 'imageProducto' contiene una ruta válida
                if (row["imagenProducto"] != DBNull.Value && !string.IsNullOrEmpty(row["imagenProducto"].ToString()))
                {
                    string imagePath = row["imagenProducto"].ToString();

                    // Verifica si el archivo existe en la ruta especificada
                    if (File.Exists(imagePath))
                    {
                        Image ingredienteImagen = Image.FromFile(imagePath); // Carga la imagen desde la ruta
                        btnIngrediente.Image = ResizeImage(ingredienteImagen, 132, 80);
                    }
                    else
                    {
                        // Si el archivo no existe, usa la imagen predeterminada
                        btnIngrediente.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
                    }
                }
                else
                {
                    // Si no hay enlace, usa una imagen predeterminada
                    btnIngrediente.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
                }
            }
            catch (Exception)
            {
                // Si ocurre algún error (descarga fallida, enlace no válido, etc.), usa una imagen predeterminada
                btnIngrediente.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
            }

            // Agrega el evento Click al botón del ingrediente
            btnIngrediente.Click += (s, ev) => DetallesIngredientes(row);
            return btnIngrediente;

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
        // Método para mostrar los detalles del ingrediente en el DataGridView
        private void DetallesIngredientes(DataRow ingrediente)
        {
            using (CantidadProductoForm cantidadProductoForm = new CantidadProductoForm())
            {
                if (cantidadProductoForm.ShowDialog() == DialogResult.OK)
                {
                    int cantidadSeleccionada = cantidadProductoForm.Cantidad;
                    AgregarIngrediente(ingrediente, cantidadSeleccionada);
                }
            }
        }
        private void AgregarIngrediente(DataRow ingrediente, int cantidad)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Error de cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Agrega el ingrediente a la vista
            int rowIndex = dgvIngredientesDetalles.Rows.Add(
                ingrediente["idIngrediente"].ToString(),
                ingrediente["nombreIngrediente"].ToString(),
                ingrediente["precioDetallePedidoIngrediente"].ToString(),
                cantidad.ToString()
                );
        }

        private void btnEliminarIngrediente_Click(object sender, EventArgs e)
        {

            // Verifica si hay una fila seleccionada en el DataGridView
            if (dgvIngredientesDetalles.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el ingrediente seleccionado?",
                                                      "Confirmar Eliminación",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    // Obtiene el índice de la fila seleccionada
                    int rowIndex = dgvIngredientesDetalles.SelectedRows[0].Index;

                    // Elimina la fila del DataGridView
                    dgvIngredientesDetalles.Rows.RemoveAt(rowIndex);

                    MessageBox.Show("Ingrediente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Muestra un mensaje si no se seleccionó ninguna fila
                MessageBox.Show("Seleccione un ingrediente para eliminar", "Eliminar Ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDescargarIngredientes_Click(object sender, EventArgs e)
        {
            if (dgvIngredientesDetalles.Rows.Count == 0)
            {
                MessageBox.Show("No hay ingredientes para descargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool registroExitoso = true;
            List<Salidas> salidasList = new List<Salidas>();

            foreach (DataGridViewRow row in dgvIngredientesDetalles.Rows)
            {
                try
                {
                    int idIngrediente = Convert.ToInt32(row.Cells["idIngrediente"].Value);
                    decimal precioDetallePedidoIngrediente = Convert.ToDecimal(row.Cells["precioDetallePedidoIngrediente"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);

                    // Crear objeto Salidas
                    Salidas salida = new Salidas
                    {
                        IdProducto = null,
                        IdIngrediente = idIngrediente,
                        FechaSalida = DateTime.Now,
                        CantidadSalida = cantidad,
                        CostoUnitarioSalida = precioDetallePedidoIngrediente
                    };

                    salidasList.Add(salida);
                }
                catch (Exception ex)
                {
                    registroExitoso = false;
                    MessageBox.Show($"Error al procesar la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (registroExitoso)
            {
                SalidaService salidaService = new SalidaService();
                foreach (var salida in salidasList)
                {
                    int idSalidaGenerado = salidaService.Insertar(salida);
                    if (idSalidaGenerado <= 0)
                    {
                        registroExitoso = false;
                        MessageBox.Show("Error al registrar una salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (registroExitoso)
            {
                MessageBox.Show("Todos los ingredientes se descargaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvIngredientesDetalles.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Hubo errores al registrar algunas salidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
