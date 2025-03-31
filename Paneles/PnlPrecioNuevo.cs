using NeoCobranza.Paneles_Venta;
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
    public partial class PnlPrecioNuevo : Form
    {
        VMOrdenes auxVMOrdenes;
        frmAgregarProductosServicios auxFrm;
        public PnlPrecioNuevo(VMOrdenes vm ,frmAgregarProductosServicios frm )
        {
            InitializeComponent();
            this.auxVMOrdenes = vm;
            auxFrm = frm;
        }

        private void TxtTotalPagado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PnlPrecioNuevo_Load(object sender, EventArgs e)
        {
            TxtTotalPagado.Select();
            TxtTotalPagado.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if(!Decimal.TryParse(TxtTotalPagado.Text,out value ) || value == 0) {

                MessageBox.Show("Debe digitar el precio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(auxFrm == null)
            {
                auxVMOrdenes.TxtPrecioVariable = Convert.ToDecimal(value);
            }
            else
            {
                auxFrm.TxtPrecioVariable = value;
            }

          
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
