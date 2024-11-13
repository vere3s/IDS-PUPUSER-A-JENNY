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
    public partial class EmpleadosGestion : Form
    {

        BindingSource DATOS = new BindingSource();
        private readonly EmpleadoService _empleadoService;
        public EmpleadosGestion()
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            CargarEmpleados();
        }
        private void CargarEmpleados()
        {
            var empleados = _empleadoService.ObtenerTodos();
            var empleadosConCargo = empleados.Select(e => new
            {
                e.IdEmpleado,
                e.NombreEmpleado,
                e.ApellidoEmpleado,
                e.TelefonoEmpelado,
                e.DireccionEmpleado,
                e.EmailEmpleado,
                e.FechaNacimientoEmpleado,
                Cargo = ObtenerNombreCargo(e.IdCargo)
            }).ToList();

            dgvEmpleados.DataSource = empleadosConCargo;
        }

        private string ObtenerNombreCargo(int idCargo)
        {
            var cargoService = new CargoService();
            var cargo = cargoService.ObtenerCargos().FirstOrDefault(c => c.IdCargo == idCargo);
            return cargo?.cargo ?? "Desconocido";
        }

        void Cargar()
        {


            Services.EmpleadoService empleadoService = new Services.EmpleadoService();
            DATOS.DataSource = empleadoService.ObtenerTodos();
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.DataSource = DATOS;

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadosEdicion formEdicion = new EmpleadosEdicion();
                formEdicion.ShowDialog();
                CargarEmpleados();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void EmpleadosGestion_Load(object sender, EventArgs e)
        {

            CargarEmpleados();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete the selected role
                if (dgvEmpleados.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                        Empleado oempleados = new Empleado();
                        oempleados.IdEmpleado = idEmpleado;
                        if (oempleados.Eliminar())
                        {
                            MessageBox.Show("Empleado eliminado correctamente.");
                            Cargar();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el rol.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un empleado para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Empleado: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
                EmpleadosEdicion formEdicion = new EmpleadosEdicion(idEmpleado);
                formEdicion.ShowDialog();
                CargarEmpleados();
            }
        }

      

    }
}
