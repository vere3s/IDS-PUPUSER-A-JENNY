using PupuseriaJenny.Custom;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Windows.Forms;

namespace PupuseriaJenny.Forms
{
    public partial class Compras : Form
    {
        private int _currentIdPedidoCompra;
        SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();

        private List<DetallesVentas> detallesDeOrden = new List<DetallesVentas>();
        // Diccionario para almacenar los identificadores por fila
        private Dictionary<int, (int idDetalleVenta, int idProducto)> identificadoresFila = new Dictionary<int, (int, int)>();


        /// Constructor principal. Inicializa el formulario y sus componentes.
        public Compras()
        {
            InitializeComponent();
            //ConfigurarDataGridView();
            InicializarFormulario();
        }

        /// Inicializa los elementos del formulario, incluyendo categorías y productos.
        private void InicializarFormulario()
        {
            CargarBotonesCategorias();
            flpProductos.Controls.Clear();
            dgvComprasDetalles.Rows.Clear();
        }

        // BOTONES, CREACIÓN Y EXCLUSIÓN DE CATEGORIAS 
        private void CargarBotonesCategorias()
        {
            CategoriaService categoriaService = new CategoriaService();

            // Obtiene las categorías de productos e ingredientes desde la base de datos
            List<string> categoriasProductos = categoriaService.CategoriasProductos();
            List<string> categoriasIngredientes = categoriaService.CategoriasIngredientes();

            // Combina ambas listas de categorías
            List<string> categorias = categoriasProductos.Concat(categoriasIngredientes).ToList();

            // Filtra las categorías excluyendo "Pupusas de Maíz" y "Pupusas de Arroz"
            categorias = categorias.Where(c => c != "Pupusa de Maíz" && c != "Pupusa de Arroz").ToList();

            // Limpia cualquier botón previo en el FlowLayoutPanel
            flpCategorias.Controls.Clear();

            foreach (string categoria in categorias)
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
                CargarProductosPorCategoria(categoriaSeleccionada);
            }
        }
        private void CargarProductosPorCategoria(string categoria)
        {
            CategoriaService categoriaService = new CategoriaService();

            // Obtiene los productos de la categoría seleccionada
            DataTable productos = categoriaService.ObtenerProductosPorCategoria(categoria);

            // Obtiene los ingredientes de todas las categorías, no solo la seleccionada
            DataTable ingredientes = categoriaService.ObtenerIngredientesPorCategoria(categoria);

            // Verifica si se han encontrado productos y ingredientes
            if (productos.Rows.Count == 0)
            {
                Console.WriteLine("No se encontraron productos para la categoría: " + categoria);
            }

            if (ingredientes.Rows.Count == 0)
            {
                Console.WriteLine("No se encontraron ingredientes para la categoría: " + categoria);
            }

            // Limpia los controles de productos e ingredientes previos en el FlowLayoutPanel
            flpProductos.Controls.Clear();

            // Agrega los productos al FlowLayoutPanel
            foreach (DataRow row in productos.Rows)
            {
                RJButton btnProducto = CrearBotonProducto(row);
                flpProductos.Controls.Add(btnProducto);
            }

            // Agrega los ingredientes al FlowLayoutPanel si están disponibles
            foreach (DataRow row in ingredientes.Rows)
            {
                RJButton btnIngrediente = CrearBotonIngrediente(row);
                flpProductos.Controls.Add(btnIngrediente);
            }
        }

        private RJButton CrearBotonProducto(DataRow row)
        {
            RJButton btnProducto = new RJButton
            {
                Text = row["nombreProducto"].ToString(),  // Establece el nombre del producto
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
                        Image productoImagen = Image.FromFile(imagePath); // Carga la imagen desde la ruta
                        btnProducto.Image = ResizeImage(productoImagen, 132, 80);
                    }
                    else
                    {
                        // Si el archivo no existe, usa la imagen predeterminada
                        btnProducto.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
                    }
                }
                else
                {
                    // Si no hay enlace, usa una imagen predeterminada
                    btnProducto.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
                }
            }
            catch (Exception)
            {
                // Si ocurre algún error (descarga fallida, enlace no válido, etc.), usa una imagen predeterminada
                btnProducto.Image = ResizeImage(Properties.Resources.imagenPredeterminada, 132, 80);
            }

            // Agrega el evento Click al botón del producto
            btnProducto.Click += (s, ev) => DetallesComprasM(row, true);
            return btnProducto;

        }

        private RJButton CrearBotonIngrediente(DataRow row)
        {
            RJButton btnIngrediente = new RJButton
            {
                Text = row["nombreIngrediente"].ToString(),
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
                // Verifica si el campo 'imagenIngrediente' contiene una ruta válida
                if (row["imagenIngrediente"] != DBNull.Value && !string.IsNullOrEmpty(row["imagenIngrediente"].ToString()))
                {
                    string imagePath = row["imagenIngrediente"].ToString();

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
            btnIngrediente.Click += (s, ev) => DetallesComprasM(row, false);
            return btnIngrediente;
        }
        private void DetallesComprasM(DataRow producto, bool estado)
        {
            using (CantidadProductoForm cantidadProductoForm = new CantidadProductoForm())
            {
                if (cantidadProductoForm.ShowDialog() == DialogResult.OK)
                {
                    int cantidadSeleccionada = cantidadProductoForm.Cantidad;
                    AgregarArticuloAOrden(producto, cantidadSeleccionada, estado);  // true para productos
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
      
        // Funcionalidad para el botón "Salir"
        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (dgvComprasDetalles.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("El pedido quedará en estado de Pendiente, ¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("El pedido se eliminará porque no hay articulos, ¿Está seguro que desea salir?", "Sin articulos seleccionados", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    PedidoCompraService pedidoCompra = new PedidoCompraService();
                    if (pedidoCompra.Eliminar(_currentIdPedidoCompra))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo problemas al eliminar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        // Funcionalidad para el botón "Eliminar Compra"
        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Eliminar Gestion Compras" && p.Acceso.ToString() == "Eliminacion"))
            {
                MessageBox.Show("Compra eliminada.", "Existoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("No tiene permisos para eliminar compras.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LimpiarFormulario()
        {
            dgvComprasDetalles.Rows.Clear();
            tbTotal.Clear();
        }

        //LOGICA DE COMPRAS , ARRIBA  SON LOS BOTONES 

        private void AgregarArticuloAOrden(DataRow articulo, int cantidad, bool esProducto)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Error de cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determinar los nombres de las columnas según el tipo de artículo
            string nombreCampoId = esProducto ? "idProducto" : "idIngrediente";
            string nombreCampoPrecio = esProducto ? "precioProducto" : "precioIngrediente";

            foreach (DataColumn col in articulo.Table.Columns)
            {
                Console.WriteLine($"Columna: {col.ColumnName}, Valor: {articulo[col.ColumnName]}");
            }
            foreach (DataColumn col in articulo.Table.Columns)
            {
                Console.WriteLine($"Columna: {col.ColumnName}, Valor: {articulo[col.ColumnName]}");
            }

            // Validar existencia de las columnas en los datos del DataRow
            if (!articulo.Table.Columns.Contains(nombreCampoId))
            {
                MessageBox.Show($"No se encontró la columna '{nombreCampoId}' en los datos del artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!articulo.Table.Columns.Contains(nombreCampoPrecio))
            {
                MessageBox.Show($"No se encontró la columna '{nombreCampoPrecio}' en los datos del artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Obtener los valores del artículo
                int idArticulo = Convert.ToInt32(articulo[nombreCampoId]);
                if (decimal.TryParse(articulo[nombreCampoPrecio].ToString(), out decimal precioArticulo) && precioArticulo > 0)
                {
                    decimal totalPrecio = precioArticulo * cantidad;

                    // Crear un nuevo pedido de compra
                    PedidoCompra nuevoPedidoCompra = new PedidoCompra
                    {
                        IdProveedor = Convert.ToInt32(cbProveedores.SelectedValue),
                        FechaPedidoCompra = DateTime.Now,
                        EstadoPedidoCompra = "Pendiente"
                    };

                    PedidoCompraService pedidoCompraService = new PedidoCompraService();
                    int idPedidoCompraGenerado = pedidoCompraService.Insertar(nuevoPedidoCompra);
                    _currentIdPedidoCompra = idPedidoCompraGenerado;

                    if (idPedidoCompraGenerado > 0)
                    {
                        // Insertar detalle según el tipo de artículo
                        if (esProducto)
                        {
                            ManejarProducto(articulo, idPedidoCompraGenerado, cantidad, precioArticulo, totalPrecio, idArticulo);
                        }
                        else
                        {
                            ManejarIngrediente(articulo, idPedidoCompraGenerado, cantidad, precioArticulo, totalPrecio, idArticulo);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al registrar el pedido de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El precio del artículo no tiene un formato válido o es incorrecto.", "Error de formato de precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al procesar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarProducto(DataRow producto, int idPedidoCompra, int cantidad, decimal precioProducto, decimal totalPrecio, int idProducto)
        {
            DetallePedidoProducto detalleProducto = new DetallePedidoProducto
            {
                IdPedidoCompra = idPedidoCompra,
                IdProducto = idProducto,
                CantidadDetallePedidoProducto = cantidad,
                PrecioDetallePedidoProducto = precioProducto
            };

            DetallePedidoCompraService detalleService = new DetallePedidoCompraService();
            int idDetalleProductoGenerado = detalleService.InsertarDetallePedidoProducto(detalleProducto);

            if (idDetalleProductoGenerado > 0)
            {
                Compra nuevaCompra = new Compra
                {
                    IdEmpleado = oSesion.empleado.IdEmpleado,
                    IdDetallePedidoProducto = idDetalleProductoGenerado,
                    TotalCompra = totalPrecio,
                    FechaCompra = DateTime.Now
                };

                CompraService compraService = new CompraService();
                int idCompraGenerado = compraService.InsertarCompra(nuevaCompra);

                if (idCompraGenerado > 0)
                {
                    RegistrarEntradaProducto(idProducto, cantidad, precioProducto, idCompraGenerado, idDetalleProductoGenerado, totalPrecio, producto);
                }
                else
                {
                    detalleService.EliminarDetallePedidoProducto(idDetalleProductoGenerado);
                    MessageBox.Show("Hubo un problema al registrar la compra del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hubo un problema al registrar el detalle del pedido del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarIngrediente(DataRow ingrediente, int idPedidoCompra, int cantidad, decimal precioIngrediente, decimal totalPrecio, int idIngrediente)
        {
            DetallePedidoIngrediente detalleIngrediente = new DetallePedidoIngrediente
            {
                IdPedidoCompra = idPedidoCompra,
                IdIngrediente = idIngrediente,
                CantidadDetallePedidoIngrediente = cantidad,
                PrecioDetallePedidoIngrediente = precioIngrediente
            };

            DetallePedidoCompraService detalleService = new DetallePedidoCompraService();
            int idDetalleIngredienteGenerado = detalleService.InsertarDetallePedidoIngrediente(detalleIngrediente);

            if (idDetalleIngredienteGenerado > 0)
            {
                Compra nuevaCompra = new Compra
                {
                    IdEmpleado = oSesion.empleado.IdEmpleado,
                    IdDetallePedidoIngrediente = idDetalleIngredienteGenerado,
                    TotalCompra = totalPrecio,
                    FechaCompra = DateTime.Now
                };

                CompraService compraService = new CompraService();
                int idCompraGenerado = compraService.InsertarCompra(nuevaCompra);

                if (idCompraGenerado > 0)
                {
                    RegistrarEntradaIngrediente(idIngrediente, cantidad, precioIngrediente, idCompraGenerado, idDetalleIngredienteGenerado, totalPrecio, ingrediente);
                }
                else
                {
                    detalleService.EliminarDetallePedidoIngrediente(idDetalleIngredienteGenerado);
                    MessageBox.Show("Hubo un problema al registrar la compra del ingrediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hubo un problema al registrar el detalle del pedido del ingrediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarEntradaProducto(int idProducto, int cantidad, decimal precioProducto, int idCompra, int idDetalle, decimal totalPrecio, DataRow producto)
        {
            DetallePedidoCompraService detalleService = new DetallePedidoCompraService();
            CompraService compraService = new CompraService();
            Entrada nuevaEntrada = new Entrada
            {
                idProducto = idProducto,
                idIngrediente = null,
                fechaEntrada = DateTime.Now,
                cantidadEntrada = cantidad,
                costoUnitarioEntrada = precioProducto,
                idCompra = idCompra
            };

            EntradaService entradaService = new EntradaService();
            int idEntradaGenerado = entradaService.InsertarEntrada(nuevaEntrada);

            if (idEntradaGenerado > 0)
            {
                AgregarProductoAlGrid(producto, cantidad, precioProducto, totalPrecio, idEntradaGenerado, idDetalle, idCompra);
            }
            else
            {
                compraService.Eliminar(idCompra);
                detalleService.EliminarDetallePedidoProducto(idDetalle);
                MessageBox.Show("Hubo un problema al registrar la entrada del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarEntradaIngrediente(int idIngrediente, int cantidad, decimal precioIngrediente, int idCompra, int idDetalle, decimal totalPrecio, DataRow ingrediente)
        {
            DetallePedidoCompraService detalleService = new DetallePedidoCompraService();
            CompraService compraService = new CompraService();
            Entrada nuevaEntrada = new Entrada
            {
                idIngrediente = idIngrediente,
                fechaEntrada = DateTime.Now,
                cantidadEntrada = cantidad,
                costoUnitarioEntrada = precioIngrediente,
                idCompra = idCompra
            };

            EntradaService entradaService = new EntradaService();
            int idEntradaGenerado = entradaService.InsertarEntrada(nuevaEntrada);

            if (idEntradaGenerado > 0)
            {
                AgregarIngredienteAlGrid(ingrediente, cantidad, precioIngrediente, totalPrecio, idEntradaGenerado, idDetalle, idCompra);
            }
            else
            {
                compraService.Eliminar(idCompra);
                detalleService.EliminarDetallePedidoIngrediente(idDetalle);
                MessageBox.Show("Hubo un problema al registrar la entrada del ingrediente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarProductoAlGrid(DataRow producto, int cantidad, decimal precioProducto, decimal totalPrecio, int idEntrada, int idDetalle, int idCompra)
        {
            int rowIndex = dgvComprasDetalles.Rows.Add();
            DataGridViewRow newRow = dgvComprasDetalles.Rows[rowIndex];

            newRow.Cells["idProducto"].Value = producto["idProducto"].ToString();
            newRow.Cells["nombreProducto"].Value = producto["nombreProducto"].ToString();
            newRow.Cells["Cantidad"].Value = cantidad.ToString();
            newRow.Cells["precioProducto"].Value = precioProducto.ToString("0.00");
            newRow.Cells["totalPrecio"].Value = totalPrecio.ToString("0.00");

            // Almacenas ambos idDetalle y idSalida en el Tag de la fila
            var detalles = new Tuple<int, int, int>(idDetalle, idEntrada, idCompra);
            newRow.Tag = detalles;

            CalcularTotales();
        }

        private void AgregarIngredienteAlGrid(DataRow ingrediente, int cantidad, decimal precioIngrediente, decimal totalPrecio, int idEntrada, int idDetalle, int idCompra)
        {
            int rowIndex = dgvComprasDetalles.Rows.Add();
            DataGridViewRow newRow = dgvComprasDetalles.Rows[rowIndex];

            newRow.Cells["idIngrediente"].Value = ingrediente["idIngrediente"].ToString();
            newRow.Cells["nombreIngrediente"].Value = ingrediente["nombreIngrediente"].ToString();
            newRow.Cells["Cantidad"].Value = cantidad.ToString();
            newRow.Cells["precioIngrediente"].Value = precioIngrediente.ToString("0.00");
            newRow.Cells["totalPrecio"].Value = totalPrecio.ToString("0.00");

            // Almacenas ambos idDetalle y idSalida en el Tag de la fila
            var detalles = new Tuple<int, int, int>(idDetalle, idEntrada, idCompra);
            newRow.Tag = detalles;

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal totalCompra = 0;

            foreach (DataGridViewRow row in dgvComprasDetalles.Rows)
            {
                if (row.Cells["Cantidad"].Value != null && row.Cells["totalPrecio"].Value != null)
                {
                    decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                    decimal totalFila = Convert.ToDecimal(row.Cells["totalPrecio"].Value);
                    totalCompra += totalFila;
                }
            }

            tbTotal.Text = totalCompra.ToString("0.00");

        }
            // Para que salgan los proveedores en el comboBox c: 
        private void CargarProveedores()
        {
            // Instancia de ProveedorService
            ProveedorService proveedorService = new ProveedorService();
            DataTable proveedoresTable = proveedorService.ObtenerProveedor();

            if (proveedoresTable == null || proveedoresTable.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron proveedores.");
                return;
            }

            // Asigna la fuente de datos al ComboBox
            cbProveedores.DataSource = proveedoresTable;
            cbProveedores.DisplayMember = "nombreProveedor"; // El nombre que se mostrará en el ComboBox
            cbProveedores.ValueMember = "idProveedor"; // El valor que se almacenará al seleccionar
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            tbNombre.Text = oSesion.empleado.NombreEmpleado;
            CargarProveedores();    
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvComprasDetalles.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el producto seleccionado?",
                                                      "Confirmar Eliminación",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvComprasDetalles.SelectedRows)
                    {
                        int idDetalle = 0;
                        int idEntrada = 0;
                        int idCompra = 0;
                        if (row.Tag is Tuple<int, int, int> detalles)
                        {
                            // Usa el Tag para obtener los valores
                            idDetalle = detalles.Item1;
                            idEntrada = detalles.Item2;
                            idCompra = detalles.Item3;

                            int idProducto = Convert.ToInt32(row.Cells["idProducto"].Value);
                            int idIngrediente = Convert.ToInt32(row.Cells["idIngrediente"].Value);

                            if (idProducto != null)
                            {
                                EntradaService entradaService = new EntradaService();
                                if (entradaService.EliminarEntrada(idEntrada))
                                {
                                    CompraService compraService = new CompraService();
                                    if (compraService.Eliminar(idCompra))
                                    {
                                        DetallePedidoCompraService detalleService = new DetallePedidoCompraService();
                                        if (detalleService.EliminarDetallePedidoProducto(idDetalle))
                                        {
                                            dgvComprasDetalles.Rows.Remove(row);
                                            CalcularTotales();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo eliminar el detalle de pedido compra y la entrada.", "Eliminar Pedido Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo eliminar la compra asociada al producto.", "Eliminar Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                
                            }
                            else if(idIngrediente != null)
                            {
                                EntradaService entradaService = new EntradaService();
                                if (entradaService.EliminarEntrada(idEntrada))
                                {
                                    CompraService compraService = new CompraService();
                                    if (compraService.Eliminar(idCompra))
                                    {
                                        DetallePedidoCompraService detalleService = new DetallePedidoCompraService();
                                        if (detalleService.EliminarDetallePedidoIngrediente(idDetalle))
                                        {
                                            dgvComprasDetalles.Rows.Remove(row);
                                            CalcularTotales();
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo eliminar el detalle del pedido compra y la entrada.", "Eliminar Pedido Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo eliminar la compra asociada al producto.", "Eliminar Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para eliminar.", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                }
            }

        private void rjBtnPagar_Click_1(object sender, EventArgs e)
        {
            if (dgvComprasDetalles.Rows.Count == 0)
            {
                DialogResult result = MessageBox.Show("¡Necesita seleccionar un producto o ingrediente para pagar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea pagar el pedido?", "Pagar Pedido", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    string estado = "Pagada";

                    PedidoCompraService pedidoCompra = new PedidoCompraService();
                    if (pedidoCompra.EstadoPedido(_currentIdPedidoCompra, estado))
                    {
                        MessageBox.Show("El pedido ha sido pagado exitosamente.", "Orden Pagada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al actualizar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
