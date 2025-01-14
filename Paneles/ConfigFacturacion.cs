using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace NeoCobranza.Paneles
{
    public partial class ConfigFacturacion : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public ConfigFacturacion()
        {
            InitializeComponent();

            UIUtilities.EstablecerFondo(this);
        }

        private void ConfigFacturacion_Load(object sender, EventArgs e)
        {
            LoadPrintersIntoComboBox(CmbImpresora);
            LoadPrintersIntoComboBox(CmbImpresoraTicke);

          DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            if (dtResponse.Rows.Count != 0)
            {
                TxtSerie.Text = Convert.ToString(dtResponse.Rows[0]["Serie"]);
                TxtConsecutivoFactura.Text = Convert.ToString(dtResponse.Rows[0]["ConsecutivoFactura"]);
                TxtConsecutivoOrden.Text = Convert.ToString(dtResponse.Rows[0]["ConsecutivoOrden"]);
                ChkRetieneIva.Checked = Convert.ToBoolean(dtResponse.Rows[0]["RetieneIvaBit"]);
                TxtImpresora.Text = Convert.ToString(dtResponse.Rows[0]["Impresora"]);
                TxtImpresoraTicket.Text = Convert.ToString(dtResponse.Rows[0]["ImpresoraTicket"]);
            }
        }

        private void TxtConsecutivoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como retroceso
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir solo números
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtRangoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como retroceso
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir solo números
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtRangoOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como retroceso
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir solo números
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            int varPrueba;

            if (!int.TryParse(TxtConsecutivoFactura.Text.Trim(), out varPrueba))
            {
                MessageBox.Show("La cantidad digitada en Consecutivo Factura no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TxtConsecutivoOrden.Text.Trim(), out varPrueba))
            {
                MessageBox.Show("La cantidad digitada en Consecutivo Orden no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.Parse(TxtConsecutivoFactura.Text.Trim()) == 0)
            {
                MessageBox.Show("El Consecutivo en factura debe ser al menos 1.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(TxtConsecutivoOrden.Text.Trim()) == 0)
            {
                MessageBox.Show("El Consecutivo en orden debe ser al menos 1.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TxtImpresoraTicket.Text = CmbImpresoraTicke.Text;
            TxtImpresora.Text = CmbImpresora.Text;

            DataTable dtResponse = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            if(dtResponse.Rows.Count > 0)
            {
                dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                dataUtilities.SetColumns("Serie", TxtSerie.Text.Trim());
                dataUtilities.SetColumns("ConsecutivoFactura", TxtConsecutivoFactura.Text.Trim());
                dataUtilities.SetColumns("RangoFactura",0);
                dataUtilities.SetColumns("ConsecutivoOrden", TxtConsecutivoOrden.Text.Trim());
                dataUtilities.SetColumns("RangoOrden", 0);
                dataUtilities.SetColumns("RetieneIvaBit", ChkRetieneIva.Checked);
                dataUtilities.SetColumns("ImpresoraTicket", TxtImpresoraTicket.Text);
                dataUtilities.SetColumns("Impresora", TxtImpresora.Text);

                dataUtilities.UpdateRecordByPrimaryKey("ConfigFacturacion", Convert.ToString(dtResponse.Rows[0][0]));
            }
            else
            {
                dataUtilities.SetColumns("SucursalId", Utilidades.SucursalId);
                dataUtilities.SetColumns("Serie", TxtSerie.Text.Trim());
                dataUtilities.SetColumns("ConsecutivoFactura", TxtConsecutivoFactura.Text.Trim());
                dataUtilities.SetColumns("RangoFactura", 0);
                dataUtilities.SetColumns("ConsecutivoOrden", TxtConsecutivoOrden.Text.Trim());
                dataUtilities.SetColumns("RangoOrden", 0);
                dataUtilities.SetColumns("RetieneIvaBit", ChkRetieneIva.Checked);
                dataUtilities.SetColumns("ImpresoraTicket", TxtImpresoraTicket.Text);
                dataUtilities.SetColumns("Impresora", TxtImpresora.Text);

                dataUtilities.InsertRecord("ConfigFacturacion");
            }


            MessageBox.Show("Cambios guardados correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
        }

        private void LoadPrintersIntoComboBox(ComboBox comboBox)
        {
            // Limpiar el ComboBox antes de agregar nuevos elementos
            comboBox.Items.Clear();

            // Obtener la lista de impresoras instaladas en el sistema
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBox.Items.Add(printer);
            }

            // Si hay impresoras, seleccionar la primera por defecto
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0; // Selecciona la primera impresora por defecto
            }
        }
    }
}
