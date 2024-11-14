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
    public partial class PermisosEdicion : Form
    {
        private readonly PermisoService _permisoService;
        private readonly RolesService _rolService;
        private readonly OpcionService _opcionService;
        private int? _idPermiso;



        public PermisosEdicion(int? idPermiso = null)
        {
            InitializeComponent();
            _opcionService = new OpcionService();
            _rolService = new RolesService();
            _permisoService = new PermisoService();


            _idPermiso = idPermiso;
            CargarAccesos();
            CargarRoles();
            CargarOpciones();
            if (_idPermiso.HasValue)
            {
                CargarDatosPermisos(_idPermiso.Value);
            }

        }
        private void CargarAccesos()
        {
            cbAcceso.DataSource = Enum.GetValues(typeof(AccesoPermiso));
        }
        private void CargarRoles()
        {
            var roles = _rolService.ObtenerRoles();
            cbIDRol.DataSource = roles;
            cbIDRol.DisplayMember = "rol";
            cbIDRol.ValueMember = "IdRol";
        }

        private void CargarOpciones()
        {
            var opcion = _opcionService.ObtenerOpcions();
            cbOpcion.DataSource = opcion;
            cbOpcion.DisplayMember = "opcion";
            cbOpcion.ValueMember = "IdOpcion";
        }

        private void CargarDatosPermisos(int idPermiso)
        {
            var permiso = _permisoService.ObtenerPorId(idPermiso);
            if (permiso != null)
            {
                tbIDPermiso.Text = permiso.IDPermiso.ToString();
                cbAcceso.SelectedValue = permiso.Acceso;
                cbIDRol.SelectedValue = permiso.IDRol;
                cbOpcion.SelectedValue = permiso.IDOpcion;

            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                Permiso oPermiso = new Permiso();

                try
                {
                    oPermiso.IDPermiso = Convert.ToInt32(tbIDPermiso.Text);
                }
                catch (Exception)
                {
                    oPermiso.IDPermiso = 0;
                }

                oPermiso.Acceso = (AccesoPermiso)cbAcceso.SelectedItem; // Obtiene el valor del ComboBox como enum
                oPermiso.IDOpcion = Convert.ToInt32(cbOpcion.SelectedValue);
                oPermiso.IDRol = Convert.ToInt32(cbIDRol.SelectedValue);

                //PROCEDER
                if (tbIDPermiso.Text.Trim().Length == 0)
                {
                    // GUARDAR NUEVO REGISTRO
                    if (oPermiso.Insertar())
                    {
                        MessageBox.Show("Registro realizado con éxito");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el permiso");
                    }
                }
                else
                {
                    // ACTUALIZAR REGISTRO
                    if (oPermiso.Actualizar())
                    {
                        MessageBox.Show("Registro actualizado");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser actualizado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
