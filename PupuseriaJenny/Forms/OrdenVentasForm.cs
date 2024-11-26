﻿using PupuseriaJenny.CLS;
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
    public partial class OrdenVentasForm : Form
    {
        private int _currentIdOrden;
        public string NumeroMesa { get; set; }
        private List<DetallesVentas> detallesDeOrden = new List<DetallesVentas>();
        // Diccionario para almacenar los identificadores por fila
        private Dictionary<int, (int idDetalleVenta, int idProducto)> identificadoresFila = new Dictionary<int, (int, int)>();

        public OrdenVentasForm(int idOrden)
        {
            InitializeComponent();
            _currentIdOrden = idOrden;
            ConfigurarFormulario();
        }
        private void ConfigurarFormulario()
        {
            tbOrden.Text = _currentIdOrden.ToString();
            CargarBotonesCategorias();
            flpProductos.Controls.Clear();
            dgvProductosDetalles.Rows.Clear();  // Limpia el DataGridView
            CargarProductosOrdenPendientes();
        }
        private void CargarBotonesCategorias()
        {
            CategoriaService categoriaService = new CategoriaService();

            // Obtiene las categorías de productos desde la base de datos
            List<string> categoriasProductos = categoriaService.CategoriasProductos();

            // Limpia cualquier botón previo en el FlowLayoutPanel
            flpCategorias.Controls.Clear();

            foreach (string categoria in categoriasProductos)
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
            // Limpia productos previos en el FlowLayoutPanel
            flpProductos.Controls.Clear();

            foreach (DataRow row in productos.Rows)
            {
                // Crea un botón para cada producto
                RJButton btnProducto = CrearBotonProducto(row);
                
                // Agrega el botón de producto al FlowLayoutPanel
                flpProductos.Controls.Add(btnProducto);
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
            btnProducto.Click += (s, ev) => DetallesProductosVenta(row);
            return btnProducto;

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
        // Método para mostrar los detalles del producto en el DataGridView
        private void DetallesProductosVenta(DataRow producto)
        {
            using (CantidadProductoForm cantidadProductoForm = new CantidadProductoForm())
            {
                if (cantidadProductoForm.ShowDialog() == DialogResult.OK)
                {
                    int cantidadSeleccionada = cantidadProductoForm.Cantidad;
                    AgregarProductoAOrden(producto, cantidadSeleccionada);
                }
            }
        }
        public bool HayStockDisponible(int idProducto, int cantidadSolicitada)
        {
            InventarioService inventarioService  = new InventarioService();
            // Se llama al método 
            DataTable inventario = inventarioService.ObtenerInventarioProductos();

            // Verifica si el DataTable no es nulo y tiene datos
            if (inventario != null && inventario.Rows.Count > 0)
            {
                // Recorre las filas del DataTable para buscar el producto con el idProducto
                foreach (DataRow row in inventario.Rows)
                {
                    // Comprueba si el idProducto coincide con el de la fila actual
                    if (Convert.ToInt32(row["id"]) == idProducto)
                    {
                        // Verifica si la cantidad disponible es mayor o igual a la cantidad solicitada
                        int cantidadDisponible = Convert.ToInt32(row["cantidadDisponible"]);
                        return cantidadDisponible >= cantidadSolicitada;
                    }
                }
            }

            // Si no se encuentra el producto o el inventario está vacío, devuelve false
            return false;
        }

        private void AgregarProductoAOrden(DataRow producto, int cantidad)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Error de cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(producto["idProducto"]);

            // Verificar si hay suficiente stock disponible para la cantidad solicitada
            if (!HayStockDisponible(idProducto, cantidad))
            {
                MessageBox.Show("No hay suficiente stock disponible para esta cantidad.", "Error de stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // No agregar el producto a la orden si no hay suficiente stock
            }

            if (decimal.TryParse(producto["precioProducto"].ToString(), out decimal precioProducto) && precioProducto > 0)
            {
                decimal totalPrecio = precioProducto * cantidad;

                
                // Crea el objeto DetallesVentas para guardar en la base de datos
                DetallesVentas nuevoDetalle = new DetallesVentas
                {
                    IdOrden = _currentIdOrden,
                    IdProducto = Convert.ToInt32(producto["idProducto"]),
                    CantidadDetalleVenta = cantidad,
                    SubTotalDetalleVenta = totalPrecio
                };

                DetalleVentaService detalleVentaService = new DetalleVentaService();
                // Inserta el detalle en la base de datos y obtener el idDetalleVenta generado
                int idDetalleVentaGenerado = detalleVentaService.Insertar(nuevoDetalle);

                // Crear el objeto Salidas para registrar la salida de producto
                Salidas nuevaSalida = new Salidas
                {
                    IdProducto = idProducto,
                    IdIngrediente = null,
                    FechaSalida = DateTime.Now,  
                    CantidadSalida = cantidad,
                    CostoUnitarioSalida = precioProducto  
                };

                // Crea el objeto Ventas para guardar en la base de datos
                Ventas nuevaVenta = new Ventas
                {
                    IdEmpleado = 2,
                    IdDetalleVenta = idDetalleVentaGenerado,
                    TotalVenta = totalPrecio
                };

                VentaService ventaService = new VentaService();

                // Inserta la venta en la base de datos
                if (idDetalleVentaGenerado > 0 && ventaService.Insertar(nuevaVenta))
                {
                    SalidaService salidaService = new SalidaService();
                    // Llamada al método Insertar() para registrar la salida del producto
                    if (!salidaService.Insertar(nuevaSalida))
                    {
                        MessageBox.Show("Hubo un problema al registrar la salida de productos del inventario.", "Error al registrar salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Agrega el producto a la vista
                        int rowIndex = dgvProductosDetalles.Rows.Add();
                        DataGridViewRow newRow = dgvProductosDetalles.Rows[rowIndex];

                        newRow.Cells["idProducto"].Value = producto["idProducto"].ToString();
                        newRow.Cells["nombreProducto"].Value = producto["nombreProducto"].ToString();
                        newRow.Cells["Cantidad"].Value = cantidad.ToString();
                        newRow.Cells["precioProducto"].Value = precioProducto.ToString("0.00");
                        newRow.Cells["totalPrecio"].Value = totalPrecio.ToString("0.00");

                        // Asigna el idDetalleVenta generado en el Tag de la fila
                        newRow.Tag = idDetalleVentaGenerado;

                        // Recalcula los totales de la orden después de agregar el producto
                        CalcularTotales();
                    }
                }
                else
                {
                    MessageBox.Show("Hubo un problema al agregar el producto a la orden.", "Error al agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El precio del producto no tiene un formato válido o es incorrecto.", "Error de formato de precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal descuento = 0;
            decimal total = 0;
            decimal cortesia = 0;

            // Se recorren las filas del DataGridView para calcular el subtotal
            foreach (DataGridViewRow row in dgvProductosDetalles.Rows)
            {
                if (row.Cells["totalPrecio"].Value != null)
                {
                    decimal precioProducto = Convert.ToDecimal(row.Cells["totalPrecio"].Value);
                    subtotal += precioProducto;
                }
            }
            descuento = CalcularDescuento(subtotal);
            
            // Calcula el total con descuento
            total = subtotal - descuento;

            MostrarTotales(subtotal, descuento, total);
        }
        private decimal CalcularDescuento(decimal subtotal)
        {
            // Obtiene el valor del descuento si existe (ejemplo: 10% = 0.10m)
            return decimal.TryParse(tbDescuento.Text, out decimal descuentoPorcentaje) ? subtotal * (descuentoPorcentaje / 100) : 0;
        }
        private void MostrarTotales(decimal subtotal, decimal descuento, decimal total)
        {
            // Muestra los valores en los controles del TableLayoutPanel
            tbSubTotal.Text = subtotal.ToString("C");
            tbDescuento.Text = descuento.ToString("C");
            tbTotal.Text = cbCortesia.Checked ? "0.00" : total.ToString("C");
            tbCortesia.Text = cbCortesia.Checked ? total.ToString("C") : "0.00";
        }
        private void tbDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void cbCortesia_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }
        
        private void CargarProductosOrdenPendientes()
        {
            DetalleVentaService detalleVentaService = new DetalleVentaService();
            DataTable productosOrden = detalleVentaService.ObtenerDetallesPorOrdenPendiente(_currentIdOrden);

            foreach (DataRow row in productosOrden.Rows)
            {
                int rowIndex = dgvProductosDetalles.Rows.Add(
                    row["idDetalleVenta"].ToString(),
                    row["idProducto"].ToString(),
                    row["nombreProducto"].ToString(),
                    row["cantidadDetalleVenta"].ToString(),
                    row["precioProducto"].ToString(),
                    row["subTotalDetalleVenta"].ToString()
                );

                // Asigna el idDetalleVenta al Tag de la fila para referencia en eliminaciones
                dgvProductosDetalles.Rows[rowIndex].Tag = Convert.ToInt32(row["idDetalleVenta"]);
            }
            // Calcula los totales después de cargar los productos
            CalcularTotales();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dgvProductosDetalles.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el producto seleccionado?",
                                                      "Confirmar Eliminación",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvProductosDetalles.SelectedRows)
                    {
                        // Acceder al idProducto y cantidad desde las celdas de la fila
                        int idProducto = Convert.ToInt32(row.Cells["idProducto"].Value);
                        int cantidadProducto = Convert.ToInt32(row.Cells["Cantidad"].Value);

                        // Acceder al idDetalleVenta desde el Tag de la fila
                        if (row.Tag is int idDetalleVenta)
                        {
                            DetalleVentaService detalleVentaService = new DetalleVentaService();
                            if (detalleVentaService.Eliminar(idDetalleVenta))
                            {
                                // Eliminar la salida correspondiente del inventario
                                SalidaService salidaService = new SalidaService();
                                if (salidaService.RevertirSalida(idProducto, cantidadProducto))
                                {
                                    dgvProductosDetalles.Rows.Remove(row);
                                    // Recalcular los totales después de eliminar el producto
                                    CalcularTotales();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar la salida del inventario.", "Eliminar Salida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el producto", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            else
            {
                // Muestra un mensaje si no se seleccionó ninguna fila
                MessageBox.Show("Seleccione un producto para eliminar", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (dgvProductosDetalles.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("La orden quedará en estado de Pendiente, ¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("La orden se eliminará porque no hay productos, ¿Está seguro que desea salir?", "Sin productos seleccionados", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
               
                if (result == DialogResult.OK)
                {
                    OrdenService ordenService = new OrdenService();
                    if (ordenService.Eliminar(_currentIdOrden))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubieron problema al eliminar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }
        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (dgvProductosDetalles.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea cancelar la venta?", "Confirmar cancelación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    string estado = "Cancelada";

                    OrdenService ordenService = new OrdenService();
                    if (ordenService.EstadoOrden(_currentIdOrden, estado))
                    {
                        // Revertir las salidas de productos
                        SalidaService salidaService = new SalidaService();
                        foreach (DataGridViewRow row in dgvProductosDetalles.Rows)
                        {
                            int idProducto = Convert.ToInt32(row.Cells["idProducto"].Value);
                            int cantidadProducto = Convert.ToInt32(row.Cells["Cantidad"].Value); // Asegúrate de que esta columna exista

                            // Llamar a la función RevertirSalida para revertir las salidas
                            if (salidaService.RevertirSalida(idProducto, cantidadProducto))
                            {
                                // Si la salida se revertió correctamente, continuar con el siguiente producto
                                continue;
                            }
                            else
                            {
                                MessageBox.Show("Hubo un error al revertir la salida del producto con ID: " + idProducto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Detener el proceso si hubo un error
                            }
                        }

                        MessageBox.Show("La orden ha sido cancelada con éxito.", "Orden Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al cancelar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("No puede cancelar una orden sin productos", "Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void OrdenVentasForm_Load(object sender, EventArgs e)
        {
            tbMesa.Text = NumeroMesa;
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            string estado = "Pagada";

            OrdenService ordenService = new OrdenService();
            if (ordenService.EstadoOrden(_currentIdOrden, estado))
            {
                MessageBox.Show("La orden ha sido pagada exitosamente.", "Orden Pagada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un problema al actualizar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPedidosAbiertos_Click(object sender, EventArgs e)
        {
            if (dgvProductosDetalles.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("La orden quedará en estado de Pendiente, ¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    MostrarOrdenesPendientesForm mostrarOrdenesForm = new MostrarOrdenesPendientesForm();
                    this.Dispose();
                    this.Close();
                    mostrarOrdenesForm.ShowDialog();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("La orden se eliminará porque no hay productos, ¿Está seguro que desea salir?", "Sin productos seleccionados", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    OrdenService ordenService = new OrdenService();
                    if (ordenService.Eliminar(_currentIdOrden))
                    {
                        MostrarOrdenesPendientesForm mostrarOrdenesForm = new MostrarOrdenesPendientesForm();
                        this.Dispose();
                        this.Close();
                        mostrarOrdenesForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Hubieron problemas al eliminar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
