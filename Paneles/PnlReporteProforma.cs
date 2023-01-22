using NeoCobranza.Data;
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
    public partial class PnlReporteProforma : Form
    {
        public int idProforma;
        public Conexion conexion;
        public PnlReporteProforma(int idProform, Conexion conexion)
        {
            InitializeComponent();
            this.idProforma = idProform;
            this.conexion = conexion;
        }

        private void PnlReporteProforma_Load(object sender, EventArgs e)
        {
            this.filtrar_ReporteServicioTableAdapter.Connection = conexion.connect;

            MessageBox.Show("Conectado con exito");
            this.filtrar_ReporteServicioTableAdapter.Fill(this.dataSetP.filtrar_ReporteServicio, idProforma);
            this.reportViewer1.RefreshReport();
        }
    }
}
