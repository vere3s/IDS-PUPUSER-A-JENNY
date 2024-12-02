using PupuseriaJenny.Models;
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
    public partial class Home : Form
    {
        SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
        public Home()
        {
            InitializeComponent();
        }

        private void btnGtPersonal_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Gestion Personal" && p.Acceso.ToString() == "lectura"))
            {
                UsuariosGestion formUsuarios = new UsuariosGestion();
                formUsuarios.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Gestion Ventas" && p.Acceso.ToString() == "lectura"))
            {
                SeleccionarVentasForm formVentas = new SeleccionarVentasForm();
                formVentas.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Gestion Compras" && p.Acceso.ToString() == "lectura"))
            {
                Compras formCompras = new Compras();
                formCompras.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGtProductos_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Gestion Productos" && p.Acceso.ToString() == "lectura"))
            {
                ProductosGestion formProductos = new ProductosGestion();
                formProductos.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Gestion Inventario" && p.Acceso.ToString() == "lectura"))
            {
                InventarioForm formInventario = new InventarioForm();
                formInventario.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Reportes" && p.Acceso.ToString() == "lectura"))
            {
                SeleccionarReporteForm formReporte = new SeleccionarReporteForm();
                formReporte.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            if (oSesion.Permisos.Any(p => p.Opcion == "Ver Gestion Ingredientes" && p.Acceso.ToString() == "lectura"))
            {
                IngredienteGestion formIngrediente = new IngredienteGestion();
                formIngrediente.Show();
            }
            else
            {
                MessageBox.Show("No tienes permisos para acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void acercaDe_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesionTsmi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editarTsmi_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            usuarioTsmi.Text = oSesion.Usuario;

            // Configura restricciones según permisos
            ConfigurarAcceso();
        }
        private void ConfigurarAcceso()
        {
            List<Permiso> permisos = oSesion.Permisos;

            // Deshabilitar botones si no hay permisos
            btnGtProductos.Enabled = permisos.Any(p => p.IDOpcion == 1 && p.Acceso.ToString() == "lectura");
            btnGtPersonal.Enabled = permisos.Any(p => p.IDOpcion == 2 && p.Acceso.ToString() == "lectura");
            btnVenta.Enabled = permisos.Any(p => p.IDOpcion == 3 && p.Acceso.ToString() == "lectura");
            btnCompras.Enabled = permisos.Any(p => p.IDOpcion == 4 && p.Acceso.ToString() == "lectura");
            btnInventario.Enabled = permisos.Any(p => p.IDOpcion == 5 && p.Acceso.ToString() == "lectura");
            btnReportes.Enabled = permisos.Any(p => p.IDOpcion == 6 && p.Acceso.ToString() == "lectura");
            btnIngredientes.Enabled = permisos.Any(p => p.IDOpcion == 7 && p.Acceso.ToString() == "lectura");
        }
    }
}
