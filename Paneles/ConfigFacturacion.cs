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

                TxtConsecutivoFacturaCredito.Text = dtResponse.Rows[0]["ConsecutivoFacturaCredito"] is DBNull
                ? ""
                : Convert.ToString(dtResponse.Rows[0]["ConsecutivoFacturaCredito"]);

                TxtSerieCredito.Text = dtResponse.Rows[0]["SerieCredito"] is DBNull
                    ? ""
                    : Convert.ToString(dtResponse.Rows[0]["SerieCredito"]);


                CmbImpresora.Text = TxtImpresora.Text == "" ? CmbImpresora.Text : TxtImpresora.Text;
                CmbImpresoraTicke.Text = TxtImpresoraTicket.Text == "" ? CmbImpresoraTicke.Text : TxtImpresoraTicket.Text;

                Chk80mm.Checked = dtResponse.Rows[0]["Bit80mm"] is DBNull
              ? false
              : Convert.ToBoolean(dtResponse.Rows[0]["Bit80mm"]);

                Chk58mm.Checked = dtResponse.Rows[0]["Bit58mm"] is DBNull
              ? false
              : Convert.ToBoolean(dtResponse.Rows[0]["Bit58mm"]);
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

            if (dtResponse.Rows.Count > 0)
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
                dataUtilities.SetColumns("ConsecutivoFacturaCredito", TxtConsecutivoFacturaCredito.Text.Trim());
                dataUtilities.SetColumns("SerieCredito", TxtSerieCredito.Text.Trim());
                dataUtilities.SetColumns("Bit58mm", Chk58mm.Checked);
                dataUtilities.SetColumns("Bit80mm", Chk80mm.Checked);

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
                dataUtilities.SetColumns("ConsecutivoFacturaCredito", TxtConsecutivoFacturaCredito.Text.Trim());
                dataUtilities.SetColumns("SerieCredito", TxtSerieCredito.Text.Trim());
                dataUtilities.SetColumns("Bit58mm", Chk58mm.Checked);
                dataUtilities.SetColumns("Bit80mm", Chk80mm.Checked);

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

        private void BtnCancelarFactura_Click(object sender, EventArgs e)
        {
            dataUtilities.SetParameter("@SucursalId", Utilidades.SucursalId);
            dataUtilities.SetParameter("@Factura", TxtFacturaCancelar.Text.Trim());

            DataTable dtNoFactura = dataUtilities.ExecuteStoredProcedure("sp_BuscarOrdenPorFactura");

            if (Convert.ToString(dtNoFactura.Rows[0]["OrdenId"]) == "0")
            {
                MessageBox.Show("La factura digitada no existe en la sucursal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden(Convert.ToString(dtNoFactura.Rows[0]["OrdenId"]), null,Utilidades.SucursalId);
                pnlCancelarOrden.ShowDialog();
            }
        }

        private void TxtConsecutivoFacturaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void Chk80mm_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk80mm.Checked)
            {
                Chk58mm.CheckedChanged -= Chk58mm_CheckedChanged; // Desactiva el evento temporalmente
                Chk58mm.Checked = false;
                Chk58mm.CheckedChanged += Chk58mm_CheckedChanged; // Lo reactiva
            }
        }

        private void Chk58mm_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk58mm.Checked)
            {
                Chk80mm.CheckedChanged -= Chk80mm_CheckedChanged;
                Chk80mm.Checked = false;
                Chk80mm.CheckedChanged += Chk80mm_CheckedChanged;
            }
        }

    }
}
