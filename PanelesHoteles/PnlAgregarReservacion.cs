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
        public decimal auxCantidadDias = 0;
        public DataTable dynamicDetalle = new DataTable();

        public PnlAgregarReservacion()
        {
            InitializeComponent();
            UIUtilities.PersonalizarDataGridViewPequeñosPlus(DgvItemsPaquete);
            dynamicDetalle.Columns.Add("idConjunto", typeof(string));
            dynamicDetalle.Columns.Add("idPaquete", typeof(string));
            dynamicDetalle.Columns.Add("Nombre Habitaciones", typeof(string));
            dynamicDetalle.Columns.Add("No de Habitación", typeof(string));
            dynamicDetalle.Columns.Add("Precio", typeof(string));
            dynamicDetalle.Columns.Add("Costo de Reservación", typeof(string));
            dynamicDetalle.Columns.Add("Paquete", typeof(string));

            DgvItemsPaquete.DataSource = dynamicDetalle;

            DgvItemsPaquete.Columns[0].Visible = false;
            DgvItemsPaquete.Columns[1].Visible = false;
        }

        public void ActualizarDatosItems()
        {
            decimal totalReservas = 0;
            decimal total = 0;

            foreach(DataRow row in dynamicDetalle.Rows)
            {
                totalReservas += Convert.ToDecimal(row[5]);
                total += Convert.ToDecimal(row[4]);
            }

            TxtPagoInicial.Text = totalReservas.ToString();
            TxtTotalPago.Text = total.ToString();

            if(dynamicDetalle.Rows.Count > 0) 
            { 
                TxtCantidadPersonas.Enabled = false;
                TxtDiasReservados.Enabled = false;
                DtFechaFin.Enabled = false;
                DtFechaInicio.Enabled = false;
                BtnCliente.Enabled = false;
                BtnAddClientes.Enabled = false;
            }
            else
            {
                TxtCantidadPersonas.Enabled = true;
                TxtDiasReservados.Enabled = true;
                DtFechaFin.Enabled = true;
                DtFechaInicio.Enabled = true;
                BtnCliente.Enabled = true;
                BtnAddClientes.Enabled = true;
            }
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
            if(auxIdCliente == "0")
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal cantDias = 0;

            if(Decimal.TryParse(TxtDiasReservados.Text, out cantDias) == false || cantDias == 0)
            {
                MessageBox.Show("La cantidad de días reservados no es valida.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            auxCantidadDias = cantDias;

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

        private void DtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularDiasReservados();
        }

        private void DtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CalcularDiasReservados();
        }

        private void CalcularDiasReservados()
        {
            // Se asume que DtFechaInicio y DtFechaFin son controles DateTimePicker
            DateTime inicio = DtFechaInicio.Value;
            DateTime fin = DtFechaFin.Value;

            // Asegurarse de que la fecha de fin sea mayor o igual que la de inicio
            if (fin >= inicio)
            {
                // Calcula la diferencia en días
                int dias = (fin - inicio).Days;
                TxtDiasReservados.Text = dias.ToString();
            }
            else
            {
                // Si la fecha final es menor, se puede limpiar o mostrar 0
                TxtDiasReservados.Text = "0";
            }
        }

        private void TxtDiasReservados_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir controles (Backspace, etc.), dígitos y punto.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir el punto solo si no existe ya uno en el TextBox.
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt != null && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void DtFechaInicio_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularDiasReservados();
        }

        private void DtFechaFin_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularDiasReservados();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            if(DgvItemsPaquete.SelectedRows.Count > 0)
            {
                dynamicDetalle.Rows.RemoveAt(DgvItemsPaquete.SelectedRows[0].Index);
                ActualizarDatosItems();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un ítem en la lista de habitaciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
