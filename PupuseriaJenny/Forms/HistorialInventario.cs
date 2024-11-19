using System;
using System.Windows.Forms;
using PupuseriaJenny.CLS;
using PupuseriaJenny.Services;

namespace PupuseriaJenny.Forms
{
    public partial class HistorialInventario : Form
    {
        private int idKardex;
        private bool cargarProductos;

        public HistorialInventario(int id, bool cargarProductos = true)
        {
            this.idKardex = id;
            this.cargarProductos = cargarProductos;  // Determina si cargar productos o ingredientes
            InitializeComponent();
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                if (cargarProductos)
                {
                    // Cargar productos
                    var productoService = new ProductoService();
                    var producto = productoService.ObtenerPorId(idKardex);
                    var kardexList = new InventarioService().ObtenerKardexPorProductoYPeriodo(idKardex, dtInicio.Value, dtFinal.Value);
                    dataGridView1.DataSource = kardexList;

                    if (producto != null)
                    {
                        txtTitulo.Text = "Historial de " + producto.NombreProducto;
                    }
                    else
                    {
                        txtTitulo.Text = "Producto con ID: " + idKardex;
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Cargar ingredientes
                    var ingredienteService = new IngredienteService();  // Asumiendo que existe un servicio IngredienteService
                    var ingrediente = ingredienteService.ObtenerIngredientePorId(idKardex);  // Método hipotético
                    var kardexList = new InventarioService().ObtenerKardexPorIngredienteYPeriodo(idKardex, dtInicio.Value, dtFinal.Value);  // Método hipotético

                    dataGridView1.DataSource = kardexList;

                    if (ingrediente != null)
                    {
                        string nombreIngrediente = ingrediente.Rows[0]["nombreIngrediente"].ToString();
                        txtTitulo.Text = "Historial de " + nombreIngrediente;  // Asignamos el nombre al TextBox
                    }
                    else
                    {
                        txtTitulo.Text = "Ingrediente con ID: " + idKardex;
                        MessageBox.Show("Ingrediente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cargar();  // Actualizar historial al hacer clic en el botón
        }
    }
}
