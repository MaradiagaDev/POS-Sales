using NeoCobranza.ModelsCobranza;
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
    public partial class ConfigFacturacion : Form
    {
        public ConfigFacturacion()
        {
            InitializeComponent();
        }

        private void ConfigFacturacion_Load(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ModelsCobranza.ConfigFacturacion config = db.ConfigFacturacion.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).FirstOrDefault();

                if (config != null)
                {
                    TxtSerie.Text = config.Serie;
                    TxtConsecutivoFactura.Text = config.ConsecutivoFactura.ToString();
                    TxtRangoFactura.Text = config.RangoFactura.ToString();
                    TxtConsecutivoOrden.Text = config.ConsecutivoOrden.ToString();
                    TxtRangoOrden.Text = config.RangoOrden.ToString();
                }
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

            if(!int.TryParse(TxtConsecutivoFactura.Text.Trim(), out varPrueba))
            {
                MessageBox.Show("La cantidad digitada en Consecutivo Factura no es valida.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TxtRangoFactura.Text.Trim(), out varPrueba))
            {
                MessageBox.Show("La cantidad digitada en Rango Factura no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TxtConsecutivoOrden.Text.Trim(), out varPrueba))
            {
                MessageBox.Show("La cantidad digitada en Consecutivo Orden no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TxtRangoOrden.Text.Trim(), out varPrueba))
            {
                MessageBox.Show("La cantidad digitada en Rango Orden no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(int.Parse(TxtConsecutivoFactura.Text.Trim()) == 0)
            {
                MessageBox.Show("El Consecutivo en factura debe ser al menos 1.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(TxtConsecutivoOrden.Text.Trim()) == 0)
            {
                MessageBox.Show("El Consecutivo en orden debe ser al menos 1.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(int.Parse(TxtRangoFactura.Text) < int.Parse(TxtConsecutivoFactura.Text))
            {
                MessageBox.Show("El Rango no puede ser menor al consecutivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.Parse(TxtRangoOrden.Text) < int.Parse(TxtConsecutivoOrden.Text))
            {
                MessageBox.Show("El Rango no puede ser menor al consecutivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ModelsCobranza.ConfigFacturacion config = db.ConfigFacturacion.Where(s => s.SucursalId == int.Parse(Utilidades.SucursalId)).FirstOrDefault();

                if (config != null)
                {
                    config.Serie = TxtSerie.Text.Trim();
                    config.RangoFactura = int.Parse(TxtRangoFactura.Text.Trim());
                    config.ConsecutivoFactura = int.Parse(TxtConsecutivoFactura.Text.Trim());
                    config.ConsecutivoOrden = int.Parse(TxtConsecutivoOrden.Text.Trim());
                    config.RangoOrden = int.Parse(TxtRangoOrden.Text.Trim());

                    db.Update(config);
                    db.SaveChanges();

                    MessageBox.Show("Cambios guardados correctamente","Correcto", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}
