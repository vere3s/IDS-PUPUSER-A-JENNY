using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PupuseriaJenny.CLS;
using PupuseriaJenny.Services;

namespace PupuseriaJenny.Forms
{
    public partial class InventarioForm : Form
    {
        private bool esProducto = true;

        BindingSource Datos = new BindingSource();
        public InventarioForm()
        {
            InitializeComponent();
            InventarioService inventario = new InventarioService();
            Datos.DataSource = inventario.ObtenerInventarioProductos();
            dataGridView1.DataSource = Datos;
            this.Text = "Inventario de Productos";
            CargarCategorias();
        }


        private void CargarCategorias()
        {
            var operacion = new CategoriaService();

            // Simulación de una consulta que trae datos de categorías (ahora es una lista de strings)
            List<string> categorias = new List<string>();
            if (esProducto)
            {
                categorias = operacion.CategoriasProductos(); // Cargar categorías de productos
            }
            else
            {
                categorias = operacion.CategoriasIngredientes(); // Cargar categorías de ingredientes
            }
            panelBotones.Controls.Clear();
            panelBotones.AutoScroll = true;
            panelBotones.BorderStyle = BorderStyle.None;
            int xPosition = 0;

            // Crear el botón "Todo" para mostrar todas las categorías
            Button botonTodo = new Button
            {
                Width = 80,
                Height = 40,
                Location = new Point(xPosition, 10),
                Text = "Todo",
                Name = "Todo"
            };

            // Agregar el evento de clic para mostrar todas las categorías (sin filtro)
            botonTodo.Click += (s, e) =>
            {
                // Aquí, asumo que "Datos" es un BindingSource que se usa para filtrar los datos
                Datos.Filter = string.Empty;  // Limpia el filtro para mostrar todos los registros
            };

            // Agregar el botón "Todo" al panel
            panelBotones.Controls.Add(botonTodo);
            xPosition += 90; // Ajusta la distancia entre botones

            // Recorre las categorías y crea los botones
            foreach (string nombreCategoria in categorias)
            {
                // Crear un botón por cada categoría
                Button boton = new Button
                {
                    Width = 80,
                    Height = 40,
                    Location = new Point(xPosition, 10),
                    Text = nombreCategoria,
                    Name = nombreCategoria
                };

                // Agregar el evento de clic para filtrar los datos
                boton.Click += (s, e) =>
                {
                    // Aquí, asumo que "Datos" es un BindingSource que se usa para filtrar los datos
                    Datos.Filter = $"Categoria LIKE '%{nombreCategoria}%'";
                };

                // Agregar el botón al panel
                panelBotones.Controls.Add(boton);
                xPosition += 90; // Ajusta la distancia entre botones
            }

            // Ajustar el ancho del panel de botones según la cantidad de botones agregados
            panelBotones.Width = xPosition;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic haya sido en una fila válida (e.RowIndex >= 0)
           
        }
        private void AlternarVista(bool esProducto)
        {
            this.esProducto = esProducto;

            // Cargar productos o ingredientes según la selección
            if (esProducto)
            {
                InventarioService inventario = new InventarioService();
                Datos.DataSource = inventario.ObtenerInventarioProductos(); // Cambiar según el servicio para productos
                this.Text = "Inventario de Productos"; // Cambiar el título a "Productos"
            }
            else
            {
                InventarioService inventario = new InventarioService();
                Datos.DataSource = inventario.ObtenerInventarioIngredientes(); // Cambiar según el servicio para ingredientes
                this.Text = "Inventario de Ingredientes"; // Cambiar el título a "Ingredientes"
            }
            CargarCategorias();
            dataGridView1.DataSource = Datos;
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada (solo una fila seleccionada)
                    var filaSeleccionada = dataGridView1.SelectedRows[0];

                    // Obtener el valor de la celda en la primera columna (suponiendo que el ID está en la columna 0)
                    var valorCelda = filaSeleccionada.Cells[0].Value;
                    int id = Int32.TryParse(valorCelda.ToString(), out int idProducto) ? idProducto : 0;
                    // Verificar si el valor de la celda es válido y convertirlo a entero
                    // Si el valor es válido, pasar el ID al formulario HistorialInventario

                    HistorialInventario historial;
                    if (esProducto) {
                historial = new HistorialInventario(id,true);
                        //   historial.IdKardex = Int32.TryParse(valorCelda.ToString());  // Asumiendo que tienes una propiedad 'IdKardex' en el formulario HistorialInventario
                        // Intentar convertir el valor de la celda a int y asignarlo directamente a IdKardex
                    }
                    else
                    {
                        historial = new HistorialInventario(id, false);

                    }

                    historial.Show();

                   
                   

                }
                else
                {
                    // Si no hay filas seleccionadas, mostrar un mensaje de error
                    MessageBox.Show("No se ha seleccionado ninguna fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
              MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            if (!esProducto) { AlternarVista(true);

                btnIngredientes.Text = "Ingredientes";
            }
              // Mostrar productos
              else { AlternarVista(false);
                btnIngredientes.Text = "Productos";
            }
        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {
           string text = rjTextBox1.Texts;
            Datos.Filter = $"nombre LIKE '%{text}%'";
        }
    }
}
