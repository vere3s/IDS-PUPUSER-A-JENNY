using System;
using System.Data;
using System.Windows.Forms;
using iText.Layout.Element;
using PupuseriaJenny.CLS;
using PupuseriaJenny.Services;
using PupuseriaJenny.Utils;

namespace PupuseriaJenny.Forms
{
    public partial class HistorialInventario : Form
    {
        private int idKardex;
        private bool cargarProductos;
        BindingSource Datos = new BindingSource();
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
                    Datos.DataSource = new InventarioService().ObtenerKardexPorProductoYPeriodo(idKardex, dtInicio.Value, dtFinal.Value);

                    dataGridView1.DataSource = Datos;

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
                    Datos.DataSource = new InventarioService().ObtenerKardexPorIngredienteYPeriodo(idKardex, dtInicio.Value, dtFinal.Value);  // Método hipotético

                    dataGridView1.DataSource = Datos;

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

        private void btnPDF_Click(object sender, EventArgs e)
        {
            CrearPDFDesdeDataTable crearPDFDesdeDataTable = new CrearPDFDesdeDataTable();
            string archivoDestino = CrearPDFDesdeDataTable.ObtenerRutaGuardado();

            if (!string.IsNullOrEmpty(archivoDestino))
            {
                var source = Datos.DataSource;
                while (source is BindingSource)
                {
                    source = ((BindingSource)source).DataSource;
                }
                if (source is DataTable)
                {
                    var table = (DataTable)source;
                    CrearPDFDesdeDataTable.GenerarPDFDesdeDataTable(table, archivoDestino);
                }
                DataTable dt = new DataTable();
               
                // Generar el PDF desde el DataTable
                
            }
            else
            {
                MessageBox.Show("No se seleccionó una ruta válida para guardar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

    }
}
