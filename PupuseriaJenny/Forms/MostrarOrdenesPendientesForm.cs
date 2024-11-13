using PupuseriaJenny.Custom;
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
    public partial class MostrarOrdenesPendientesForm : Form
    {
        public MostrarOrdenesPendientesForm()
        {
            InitializeComponent();
            CargarOrdenesPendientes();
        }
        private void CargarOrdenesPendientes()
        {
            // Limpiar el panel de órdenes
            flpOrdenesPendientes.Controls.Clear();

            OrdenService ordenService = new OrdenService();
            // Obtiene las órdenes pendientes de la base de datos
            DataTable ordenesPendientes = ordenService.ObtenerOrdenesPendientes();

            // Crear un botón para cada orden pendiente
            foreach (DataRow row in ordenesPendientes.Rows)
            {
                Button btnOrden = CrearBotonOrden(row);
                flpOrdenesPendientes.Controls.Add(btnOrden);
            }
        }

        private RJButton CrearBotonOrden(DataRow orden)
        {
            int idOrden = Convert.ToInt32(orden["idOrden"]);
            RJButton btnOrden = new RJButton
            {
                Text = "Orden #" + idOrden.ToString(),
                Width = 173,
                Height = 167,
                BackColor = Color.LightGray,
                Tag = idOrden // Guarda el ID de la orden en el Tag del botón
            };

            btnOrden.Click += (s, e) => AbrirOrden(idOrden);
            return btnOrden;
        }

        private void AbrirOrden(int idOrden)
        {
            // Abre el formulario de OrdenVentas para editar la orden seleccionada
            OrdenVentasForm ordenVentasForm = new OrdenVentasForm(idOrden);
            ordenVentasForm.ShowDialog();

            // Recarga las órdenes pendientes al cerrar OrdenVentasForm
            CargarOrdenesPendientes();
        }
    }
}
