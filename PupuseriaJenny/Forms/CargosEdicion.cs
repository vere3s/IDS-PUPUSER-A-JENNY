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
    public partial class CargosEdicion : Form
    {
        private readonly CargoService _cargosService;

        public CargosEdicion()
        {
            InitializeComponent();
            _cargosService = new CargoService();
        }

        // Método para validar la entrada de texto en el campo de Cargo
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbCargo.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbCargo, "Este campo no puede estar vacío");
                    valido = false;
                }
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // Crear un objeto de tipo Roles y sincronizarlo con la GUI
                   Cargos cargo = new Cargos();

                    try
                    {
                        cargo.IdCargo = Convert.ToInt32(tbIDCargo.Text);
                    }
                    catch (Exception)
                    {
                        cargo.IdCargo = 0;
                    }

                    cargo.cargo = tbCargo.Text;

                    // Proceder según si es una inserción o una actualización
                    if (cargo.IdCargo == 0) // Si el ID es 0, es una inserción
                    {
                        if (_cargosService.Insertar(cargo)) // Llamada al servicio para insertar
                        {
                            MessageBox.Show("Registro guardado con éxito");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser almacenado");
                        }
                    }
                    else // Si tiene un ID válido, se actualiza
                    {
                        if (_cargosService.Actualizar(cargo)) // Llamada al servicio para actualizar
                        {
                            MessageBox.Show("Registro actualizado con éxito");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser actualizado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
