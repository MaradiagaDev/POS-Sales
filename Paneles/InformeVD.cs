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
    public partial class InformeVD : Form
    {
        public int id;
        public Conexion conexion;
        public InformeVD(int id,Conexion conexion)
        {
            this.id = id;
            InitializeComponent();
            this.conexion = conexion;
        }

        private void InformeVD_Load(object sender, EventArgs e)
        {
            this.filtrar_ReporteServicioTableAdapter.Connection = conexion.connect;
            dataSetVD.EnforceConstraints = false;
            this.filtrar_ReporteServicioTableAdapter.Fill(dataSetVD.filtrar_ReporteServicio,id);
            this.reportViewer1.RefreshReport();
        }
    }
}
