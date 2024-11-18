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
    public partial class CategoriasEdicion : Form
    {
        private readonly CategoriaService _categoriasService;
        public CategoriasEdicion()
        {
            InitializeComponent();
            _categoriasService = new CategoriaService();
        }
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbCategoria.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbCategoria, "Este campo no puede estar vacío");
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
                    Categorias categoria = new Categorias();

                    try
                    {
                        categoria.IdCategoria = Convert.ToInt32(tbIDCategoria.Text);
                    }
                    catch (Exception)
                    {
                        categoria.IdCategoria = 0;
                    }

                    categoria.Categoria = tbCategoria.Text;

                    // Proceder según si es una inserción o una actualización
                    if (categoria.IdCategoria == 0) // Si el ID es 0, es una inserción
                    {
                        if (_categoriasService.Insertar(categoria)) // Llamada al servicio para insertar
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
                        if (_categoriasService.Actualizar(categoria)) // Llamada al servicio para actualizar
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
