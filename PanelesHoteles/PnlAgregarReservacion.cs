using iText.StyledXmlParser.Jsoup.Helper;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.PanelesHoteles
{
    public partial class PnlAgregarReservacion : Form
    {
        DataUtilities dataUtilities  = new DataUtilities();
        public string auxIdCliente = "0";
        public DataTable dynamicDetalle = new DataTable();

        public PnlAgregarReservacion()
        {
            InitializeComponent();
            UIUtilities.PersonalizarDataGridViewPequeñosPlus(DgvItemsPaquete);
            dynamicDetalle.Columns.Add("Nombre Habitaciones", typeof(string));
            dynamicDetalle.Columns.Add("No de Habitación", typeof(string));
            dynamicDetalle.Columns.Add("Precio", typeof(string));
            dynamicDetalle.Columns.Add("Costo de Reservación", typeof(string));
            dynamicDetalle.Columns.Add("Paquete", typeof(string));

            DgvItemsPaquete.DataSource = dynamicDetalle;
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            Panel_Cliente_Contrato panelCliente = new Panel_Cliente_Contrato("Reserva");
            AddOwnedForm(panelCliente);
            panelCliente.ShowDialog();
        }

        private void BtnAddClientes_Click(object sender, EventArgs e)
        {
            PanelModificarCliente frm = new PanelModificarCliente(null, auxIdCliente, null);
            AddOwnedForm(frm);
            frm.vMCatalogoCliente.auxKeyUsuario = (auxIdCliente == "0" || auxIdCliente == "") ? "Crear" : "Modificar";
            frm.ShowDialog();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            PnlSeleccionarHabitaciones frm = new PnlSeleccionarHabitaciones(DtFechaInicio.Value,DtFechaFin.Value,this);
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtCantidadPersonas_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PnlAgregarReservacion_Load(object sender, EventArgs e)
        {

        }
    }
}
