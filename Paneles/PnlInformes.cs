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
            PnlGenerarInforme frm = new PnlGenerarInforme("Anuladas");
            frm.ShowDialog();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("ReporteVentas");
            frm.ShowDialog();
        }

        private void BtnCuentasCobrar_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("CuentasCobrar");
            frm.ShowDialog();
        }

        private void BtnAsistencias_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("Asistencias");
            frm.ShowDialog();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("Productos");
            frm.ShowDialog();
        }

        private void especialButton12_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("Limites");
            frm.ShowDialog();
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("Cortes");
            frm.ShowDialog();
        }

        private void especialButton13_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("Compras");
            frm.ShowDialog();
        }

        private void especialButton14_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("Ajustes");
            frm.ShowDialog();
        }

        private void BtnReporteVentasDiarias_Click(object sender, EventArgs e)
        {
            PnlGenerarInforme frm = new PnlGenerarInforme("SoloVentas");
            frm.ShowDialog();
        }
    }
}
