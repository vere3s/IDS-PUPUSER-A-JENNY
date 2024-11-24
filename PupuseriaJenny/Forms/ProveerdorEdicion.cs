using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
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
    public partial class ProveerdorEdicion : Form
    {
        private readonly ProveedorService _proveedorservice;
        private int? _idProveedor;

        public ProveerdorEdicion()
        {
            InitializeComponent();
            _proveedorservice = new ProveedorService();
            

        }

        private void CargarDatosProveedor(int idProveedor)
        {
            var proveedor = _proveedorservice.ObtenerPorId(idProveedor);
            if (proveedor != null)
            {
                tbIdProveedor.Text = proveedor.IdProveedor.ToString();
                tbNombreP.Text = proveedor.Nombre;
                tbTelefonoP.Text = proveedor.Telefono;
                tbDireccionP.Text = proveedor.Direccion;
                tbEmailP.Text = proveedor.Email;
              
                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Proveedor proveedor = new Proveedor
            {
                Nombre = tbNombreP.Text,
                Telefono = tbTelefonoP.Text,
                Direccion = tbDireccionP.Text,
                Email = tbEmailP.Text
            };

            bool resultado;
            if (_idProveedor.HasValue)
            {
                proveedor.IdProveedor = _idProveedor.Value;
                resultado = _proveedorservice.Actualizar(proveedor);
            }
            else
            {
                resultado = _proveedorservice.Insertar(proveedor);
            }

            if (resultado)
            {
                MessageBox.Show("Proveedor guardado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el Proveedor.");
            }
        }

        

    }
}
