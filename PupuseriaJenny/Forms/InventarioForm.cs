using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PupuseriaJenny.CLS;

namespace PupuseriaJenny.Forms
{
    public partial class InventarioForm : Form
    {


        BindingSource Datos = new BindingSource();
        public InventarioForm()
        {
            InitializeComponent();
            Inventario inventario = new Inventario();
            Datos.DataSource = inventario.ObtenerInventarioProductos();
            dataGridView1.DataSource = Datos;
   
            CargarCategorias();
        }


        private void CargarCategorias()
        {
            // Simulación de una consulta que trae datos de categorías
            DataTable categorias = ObtenerCategoriasDeBaseDeDatos();
            panelBotones.AutoScroll = true;
            panelBotones.BorderStyle = BorderStyle.None;
            int xPosition = 0;
            foreach (DataRow row in categorias.Rows)
            {
                string nombreCategoria = row["NombreCategoria"].ToString();
                //MessageBox.Show(nombreCategoria);

                // Crear un botón por cada categoría
                Button boton = new Button
                {
                    Width = 80,
                    Height = 40,
                    Location = new Point(xPosition, 10),
                 
                    Text = nombreCategoria,Name = nombreCategoria,
                };
                boton.Click += (s, e) => {
                    Datos.Filter = $"Categoria LIKE '%{nombreCategoria}%'";
                };
                panelBotones.Controls.Add(boton);
                xPosition += 90; // Ajusta la distancia entre botones
            }

            // Ajustar el ancho del panel de botones según la cantidad de botones agregados
            panelBotones.Width = xPosition;
            
        }

        private DataTable ObtenerCategoriasDeBaseDeDatos()
        {
            // Simulación de datos de una consulta a base de datos
            DataTable table = new DataTable();
            table.Columns.Add("IdCategoria", typeof(int));
            table.Columns.Add("NombreCategoria", typeof(string));

            // Ejemplo de datos de categorías
            table.Rows.Add(1, "Bebidas");
            table.Rows.Add(2, "Comidas");
            table.Rows.Add(3, "Postres");
            table.Rows.Add(4, "Entradas");
            table.Rows.Add(5, "Especialidades");

            return table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que el índice de la fila sea válido
            
        }
    }
}
