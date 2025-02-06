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

namespace NeoCobranza.Paneles
{
    public partial class PnlIngresosPagosCaja : Form
    {
        public PnlIngresosPagosCaja()
        {
            InitializeComponent();

            CmbTipo.SelectedIndex = 0;
            TxtTotal.Focus();
        }

        private void TxtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, el punto decimal y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla no permitida
            }

            // Evitar múltiples puntos decimales
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void BtnPagarEfectivo_Click(object sender, EventArgs e)
        {
            try
            {
                bool EsIngreso = CmbTipo.SelectedIndex == 0 ? true : false;

                if (Decimal.TryParse(TxtTotal.Text.ToString(), out decimal total))
                {
                    DataUtilities dataUtilities = new DataUtilities();
                    dataUtilities.SetColumns("SucursaId", Utilidades.SucursalId);
                    dataUtilities.SetColumns("Pagado", TxtTotal.Text);
                    dataUtilities.SetColumns("Total", 0);
                    dataUtilities.SetColumns("Referencia", TxtReferencia.Text);
                    dataUtilities.SetColumns("FechaPago", DateTime.Now);
                    dataUtilities.SetColumns("BitEsIngreso", EsIngreso);
                    dataUtilities.SetColumns("BitCierreCaja", false);
                    dataUtilities.InsertRecord("PagosIngresoGasto");

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Debe digitar la cantidad en el total", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtTotal.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en el momento de la ejecución","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
