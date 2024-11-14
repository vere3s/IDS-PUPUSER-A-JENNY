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
    public partial class OpcionesEdicion : Form
    {
        private readonly OpcionService _opcionesService;

        public OpcionesEdicion()
        {
            InitializeComponent();
            _opcionesService = new OpcionService();
        }

        //Validación de entrada de opciones 
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbOpcion.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbOpcion, "Este campo no puede estar vacío");
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
                    Opciones opcion = new Opciones();

                    try
                    {
                        opcion.IdOpcion = Convert.ToInt32(tbIDOpcion.Text);
                    }
                    catch (Exception)
                    {
                        opcion.IdOpcion = 0;
                    }

                    opcion.opcion = tbOpcion.Text;

                    // Proceder según si es una inserción o una actualización
                    if (opcion.IdOpcion == 0) // Si el ID es 0, es una inserción
                    {
                        if (_opcionesService.Insertar(opcion)) // Llamada al servicio para insertar
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
                        if (_opcionesService.Actualizar(opcion)) // Llamada al servicio para actualizar
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
