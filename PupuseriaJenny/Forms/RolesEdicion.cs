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
    public partial class RolesEdicion : Form
    {
        private readonly RolesService _rolesService;

        public RolesEdicion()
        {
            InitializeComponent();
            _rolesService = new RolesService(); // Instancia de RolesService para interactuar con la base de datos
        }

        // Método para validar la entrada de texto en el campo de Rol
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbRol.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbRol, "Este campo no puede estar vacío");
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
                    Roles rol = new Roles();

                    try
                    {
                        rol.idRol = Convert.ToInt32(tbIDRol.Text);
                    }
                    catch (Exception)
                    {
                        rol.idRol = 0;
                    }

                    rol.Rol = tbRol.Text;

                    // Proceder según si es una inserción o una actualización
                    if (rol.idRol == 0) // Si el ID es 0, es una inserción
                    {
                        if (_rolesService.Insertar(rol)) // Llamada al servicio para insertar
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
                        if (_rolesService.Actualizar(rol)) // Llamada al servicio para actualizar
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
