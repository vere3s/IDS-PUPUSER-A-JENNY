using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using RestauranteGestion.Core.DataAccess;
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
    public partial class EmpleadosEdicion : Form
    {
        private readonly EmpleadoService _empleadoService;
        private readonly CargoService _cargoService;
        private int? _idEmpleado;
        

        public EmpleadosEdicion(int? idEmpleado = null)
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            _cargoService = new CargoService();
            _idEmpleado = idEmpleado;
            CargarCargos();
            if (_idEmpleado.HasValue)
            {
                CargarDatosEmpleado(_idEmpleado.Value);
            }
        }


        private void CargarCargos()
        {
            var cargo = _cargoService.ObtenerCargos();
            cbCargos.DataSource = cargo;
            cbCargos.DisplayMember = "cargo";
            cbCargos.ValueMember = "IdCargo";
        }

        private void CargarDatosEmpleado(int idEmpleado)
        {
            var empleado = _empleadoService.ObtenerPorId(idEmpleado);
            if (empleado != null)
            {
                tbNombre.Text = empleado.NombreEmpleado;
                tbApellido.Text = empleado.ApellidoEmpleado;
                tbTelefono.Text = empleado.TelefonoEmpelado;
                tbDireccion.Text = empleado.DireccionEmpleado;
                tbEmail.Text = empleado.EmailEmpleado;
                dtpFechaNacimiento.Value = empleado.FechaNacimientoEmpleado;
                cbCargos.SelectedValue = empleado.IdCargo;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Empleado empleado = new Empleado
            {
                NombreEmpleado = tbNombre.Text,
                ApellidoEmpleado = tbApellido.Text,
                TelefonoEmpelado = tbTelefono.Text,
                DireccionEmpleado = tbDireccion.Text,
                EmailEmpleado = tbEmail.Text,
                FechaNacimientoEmpleado = dtpFechaNacimiento.Value,
                IdCargo = (int)cbCargos.SelectedValue
            };

            bool resultado;
            if (_idEmpleado.HasValue)
            {
                empleado.IdEmpleado = _idEmpleado.Value;
                resultado = _empleadoService.Actualizar(empleado);
            }
            else
            {
                resultado = _empleadoService.Insertar(empleado);
            }

            if (resultado)
            {
                MessageBox.Show("Empleado guardado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el empleado.");
            }
        }

        private void EmpleadosEdicion_Load(object sender, EventArgs e)
        {
            List<Cargos> cargos = _cargoService.ObtenerCargos();

            if (cargos != null && cargos.Count > 0)
            {
                cbCargos.DataSource = cargos;
                cbCargos.DisplayMember = "cargo"; // Propiedad que deseas mostrar
                cbCargos.ValueMember = "IdCargo";       // Valor asociado al item
            }
            else
            {
                MessageBox.Show("No se encontraron cargos para mostrar en el ComboBox.");
            }
        }
    }
    
}
