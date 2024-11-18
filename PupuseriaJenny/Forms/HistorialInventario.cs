using System;
using System.Windows.Forms;
using PupuseriaJenny.CLS;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;

namespace PupuseriaJenny.Forms
{
    public partial class HistorialInventario : Form
    {
        private int idKardex;

        // Eliminamos el BindingSource innecesario, ya que no es necesario para esta operación
        public HistorialInventario(int id)
        {
            this.idKardex = id;
            InitializeComponent();
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                // Crear una instancia del servicio de productos y buscar el producto por ID
                ProductoService productoService = new ProductoService();
                Productos productos = productoService.BuscarPorId(idKardex);

                // Crear una instancia del servicio de inventario
                InventarioService inventarioService = new InventarioService();

                // Asegurarse de que las fechas seleccionadas no sean nulas
               

                // Obtener los registros de Kardex por producto y por periodo
                var kardexList = inventarioService.ObtenerKardexPorProductoYPeriodo(idKardex, dtInicio.Value, dtFinal.Value);

                // Asignar los resultados al DataGridView
                dataGridView1.DataSource = kardexList;

                // Verificar si el producto fue encontrado
                if (productos != null)
                {
                    // Si el producto no es nulo, asignar el nombre del producto al TextBox
                    txtTitulo.Text = "Historial de " + productos.NombreProducto;
                }
                else
                {
                    // Si el producto no se encuentra, mostrar el ID y un mensaje de error
                    txtTitulo.Text = "Producto con ID: " + idKardex.ToString();
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cargar();  // Actualizar el historial al hacer clic en el botón de actualización
        }
    }
}
