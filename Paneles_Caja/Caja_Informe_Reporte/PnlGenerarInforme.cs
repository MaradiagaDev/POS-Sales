using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Caja.Caja_Informe_Reporte
{
    public partial class PnlGenerarInforme : Form
    {
        public string fechaI;
        public string fechaF;
        public PnlGenerarInforme(string fechai,string fechaf)
        {
            InitializeComponent();
            this.fechaI = fechai;
            this.fechaF = fechaf;
        }

        private void PnlGenerarInforme_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_Total_Oficiales' Puede moverla o quitarla según sea necesario.
            this.reporteria_Total_OficialesTableAdapter.Fill(this.data_ReciboOficial.Reporteria_Total_Oficiales,fechaI,fechaF);

            this.reportViewer1.RefreshReport();
        }
    }
}
