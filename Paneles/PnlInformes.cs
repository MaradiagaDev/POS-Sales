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
    public partial class PnlInformes : Form
    {
        public PnlInformes()
        {
            InitializeComponent();
        }

        private void especialButton8_Click(object sender, EventArgs e)
        {

        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("ReporteVentas");
            frm.ShowDialog();
        }
    }
}
