using PupuseriaJenny.Custom;
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
    public partial class MostrarOrdenesPendientesForm : Form
    {
        public MostrarOrdenesPendientesForm()
        {
            InitializeComponent();
            CargarOrdenesPendientes();
        }
        private void CargarOrdenesPendientes()
        {
            // Limpia el panel de órdenes
            flpOrdenesPendientes.Controls.Clear();

            OrdenService ordenService = new OrdenService();

            // Obtiene las órdenes pendientes de la base de datos
            DataTable ordenesPendientesConMesa = ordenService.ObtenerOrdenesPendientesConMesa();
            DataTable ordenesPendientesSinMesa = ordenService.ObtenerOrdenesPendientesSinMesa();

            // Combina ambos DataTables en uno solo
            DataTable ordenesPendientes = ordenesPendientesConMesa.Clone(); // Clonar estructura
            ordenesPendientes.Merge(ordenesPendientesConMesa);
            ordenesPendientes.Merge(ordenesPendientesSinMesa);

            // Ordena por idOrden
            DataView vistaOrdenada = ordenesPendientes.DefaultView;
            vistaOrdenada.Sort = "idOrden ASC";
            DataTable ordenesOrdenadas = vistaOrdenada.ToTable();

            // Crea un botón para cada orden pendiente en orden
            foreach (DataRow row in ordenesOrdenadas.Rows)
            {
                Button btnOrden;
                if (row["idMesa"] == DBNull.Value) // Si idMesa es NULL, crear botón sin mesa
                {
                    btnOrden = CrearBotonOrdenSinMesa(row);
                }
                else // Si tiene mesa, crear botón con mesa
                {
                    btnOrden = CrearBotonOrdenConMesa(row);
                }
                flpOrdenesPendientes.Controls.Add(btnOrden);
            }
        }

        private RJButton CrearBotonOrdenSinMesa(DataRow orden)
        {
            int idOrden = Convert.ToInt32(orden["idOrden"]);
            string cliente = orden["clienteOrden"].ToString();
            string fecha = orden["fechaOrden"].ToString();
            string tipo = orden["tipoOrden"].ToString();

            RJButton btnOrden = new RJButton
            {
                Text = $"Orden {idOrden}\nCliente: {cliente}\n {fecha}\n {tipo}",
                Width = 223,
                Height = 197,
                TextColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 16),
                BackColor = Color.FromArgb(255, 128, 0),
                Margin = new Padding(30),
                BorderRadius = 30,
                Tag = idOrden // Guarda el ID de la orden en el Tag del botón
            };

            btnOrden.Click += (s, e) => AbrirOrden(idOrden, null);
            return btnOrden;
        }
        private RJButton CrearBotonOrdenConMesa(DataRow orden)
        {
            int idOrden = Convert.ToInt32(orden["idOrden"]);
            string cliente = orden["clienteOrden"].ToString();
            string fecha = orden["fechaOrden"].ToString();
            string tipo = orden["tipoOrden"].ToString();
            int mesa = Convert.ToInt32(orden["idMesa"]);

            RJButton btnOrden = new RJButton
            {
                Text = $"Orden {idOrden}\nCliente: {cliente}\nMesa: {mesa}\n {fecha}\n {tipo}",
                Width = 223,
                Height = 197,
                TextColor = Color.Black,
                Font = new Font("Microsoft Sans Serif", 16),
                BackColor = Color.Cyan,
                Margin = new Padding(30),
                BorderRadius = 30,
                Tag = idOrden // Guarda el ID de la orden en el Tag del botón
            };

            btnOrden.Click += (s, e) => AbrirOrden(idOrden, mesa);
            return btnOrden;
        }

        private void AbrirOrden(int idOrden, int? mesa)
        {
            // Abre el formulario de OrdenVentas para editar la orden seleccionada
            OrdenVentasForm ordenVentasForm = new OrdenVentasForm(idOrden);
            ordenVentasForm.NumeroMesa = mesa.ToString();
            ordenVentasForm.ShowDialog();

            // Recarga las órdenes pendientes al cerrar OrdenVentasForm
            CargarOrdenesPendientes();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            SeleccionarVentasForm seleccionarVentasForm = new SeleccionarVentasForm();
            seleccionarVentasForm.ShowDialog();
        }
    }
}
