using PupuseriaJenny.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace PupuseriaJenny.Forms
{
    public partial class ProveedorGestion : Form
    {
        // Fuente de datos para enlazar al DataGridView
        private readonly BindingSource _datos = new BindingSource();

        // Servicio para manejar operaciones de proveedor
        private readonly ProveedorService _proveedorService;

        public ProveedorGestion()
        {
            InitializeComponent();
            _proveedorService = new ProveedorService();
            CargarProveedor(); // Cargar la lista de proveedores al inicializar
        }

      
        /// Carga la lista de proveedores desde la base de datos y la muestra en el DataGridView.
        
        private void CargarProveedor()
        {
            try
            {
                // Obtener datos de proveedores desde el servicio
                DataTable proveedor = _proveedorService.ObtenerProveedoresAsDataTable();

                if (proveedor == null || proveedor.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de proveedores para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewP.DataSource = null; // Limpia el DataGridView si no hay datos
                    return;
                }

                // Enlazar datos al DataGridView
                _datos.DataSource = proveedor;
                dataGridViewP.AutoGenerateColumns = true; // Generar columnas automáticamente
                dataGridViewP.DataSource = _datos;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre alguna excepción
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        /// Maneja el evento del botón Agregar.
        /// Abre un formulario para agregar un nuevo proveedor.
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var formEdicion = new EmpleadosEdicion())
            {
                formEdicion.ShowDialog(); // Mostrar formulario de edición
                CargarProveedor(); // Recargar lista de proveedores después de agregar
            }
        }

        /// Evento que se ejecuta al cargar el formulario.
        /// Inicializa la lista de proveedores.
        
        private void ProveedorGestion_Load(object sender, EventArgs e)
        {
            CargarProveedor();
        }

        
        /// Maneja el evento del botón Eliminar.
        /// Permite eliminar un proveedor seleccionado.
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar si hay un proveedor seleccionado
            if (dataGridViewP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para eliminar.");
                return;
            }

            // Confirmar acción de eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de eliminar este proveedor?",
                                                "Confirmación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                // Obtener el IdProveedor de la fila seleccionada
                int idProveedor = Convert.ToInt32(dataGridViewP.SelectedRows[0].Cells["IdProveedor"].Value);

                // Eliminar el proveedor a través del servicio
                if (_proveedorService.Eliminar(idProveedor))
                {
                    MessageBox.Show("Proveedor eliminado correctamente.");
                    CargarProveedor(); // Recargar lista de proveedores
                }
                else
                {
                    MessageBox.Show("Error al eliminar el proveedor. Verifique la información.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// Maneja el evento del botón Editar.
        /// Permite editar los datos de un proveedor seleccionado.
       
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewP.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para editar.");
                return;
            }

            // Obtener el IdProveedor de la fila seleccionada
            int idProveedor = Convert.ToInt32(dataGridViewP.CurrentRow.Cells["IdProveedor"].Value);

            // Abrir formulario de edición con el IdProveedor
            using (var formEdicion = new EmpleadosEdicion(idProveedor))
            {
                formEdicion.ShowDialog();
                CargarProveedor(); // Recargar lista de proveedores después de editar
            }
        }

       
       
    }
}
