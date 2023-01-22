using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Venta.Informes
{
    public partial class Rpt_InformeGeneralCaja : Form
    {
        public string FechaI,FechaF;

        public Rpt_InformeGeneralCaja(string fechaI,string fechaF)
        {
            InitializeComponent();
            this.FechaI = fechaI;
            this.FechaF = fechaF;

        }

        private void Rpt_InformeGeneralCaja_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'data_Facturacion.Reporteria_Ventas_Generales' Puede moverla o quitarla según sea necesario.
            this.reporteria_Ventas_GeneralesTableAdapter.Fill(this.data_Facturacion.Reporteria_Ventas_Generales,FechaI,FechaF);

            this.reportViewer1.RefreshReport();
        }
    }
}
