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

namespace NeoCobranza.Paneles_Venta
{
    public partial class PnlVentasCredito : Form
    {
        PnlVentas auxFrm;
        DataUtilities dataUtilities = new DataUtilities();

        public PnlVentasCredito(PnlVentas frmVentas)
        {
            InitializeComponent();
            auxFrm = frmVentas;
            CmbFrecuencia.SelectedIndex = 0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];

            if (Convert.ToString(item["NoFactura"]) != "0")
            {
                MessageBox.Show("Una vez generada la factura, no es posible eliminar la condición de crédito.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

                dataUtilities.SetColumns("FechaCredito",DateTime.Now);
            dataUtilities.SetColumns("CantidadPagos","");
            dataUtilities.SetColumns("FrecuenciaPagos","");
            dataUtilities.SetColumns("MontoCredito",0);
            dataUtilities.SetColumns("BitEsCredito",false);

            dataUtilities.UpdateRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux);

            auxFrm.vMOrdenes.CalcularTotales(auxFrm, auxFrm.TxtDescuento.Text);
            auxFrm.lblCredito.Visible = false;

            this.Close();
        }

        private void BtnActualizarDescuento_Click(object sender, EventArgs e)
        {
            TxtMontoCredito.Text = decimal.TryParse(TxtMontoCredito.Text, out decimal monto) == true ? TxtMontoCredito.Text : "0";

            dataUtilities.SetColumns("FechaCredito", DtFechaPago.Value);
            dataUtilities.SetColumns("CantidadPagos", TxtCantidadPagos.Text);
            dataUtilities.SetColumns("FrecuenciaPagos" ,CmbFrecuencia.Text);
            dataUtilities.SetColumns("MontoCredito", TxtMontoCredito.Text);
            dataUtilities.SetColumns("BitEsCredito", true);

            dataUtilities.UpdateRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux);

            auxFrm.vMOrdenes.CalcularTotales(auxFrm, auxFrm.TxtDescuento.Text);
            auxFrm.lblCredito.Visible = true;

            this.Close();
        }

        private void TxtMontoCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, la tecla de retroceso y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es un número, un punto decimal ni una tecla de control, ignorar la entrada
                e.Handled = true;
            }

            // Verificar si ya hay un punto decimal en el texto
            if (e.KeyChar == '.' && ((sender as System.Windows.Forms.TextBox)?.Text.IndexOf('.') > -1))
            {
                // Si ya hay un punto decimal, ignorar la entrada
                e.Handled = true;
            }
        }

        private void PnlVentasCredito_Load(object sender, EventArgs e)
        {
            DataTable dtResponseOrden = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux);
            DataRow orden = dtResponseOrden.Rows[0];

            if (Convert.ToBoolean(orden["BitEsCredito"]))
            {
                TxtCantidadPagos.Text = Convert.ToString(orden["CantidadPagos"]);
                DtFechaPago.Value = Convert.ToDateTime(orden["FechaCredito"]);
                CmbFrecuencia.Text = Convert.ToString(orden["FrecuenciaPagos"]);
                TxtMontoCredito.Text = Convert.ToString(orden["MontoCredito"]);
            }
        }
    }
}
