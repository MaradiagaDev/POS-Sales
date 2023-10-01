using Microsoft.Reporting.WinForms;
using NeoCobranza.Clases_de_Contrato;
using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PanelFinal : Form
    {
        public int id;
        public Conexion conexion;
        public string descripcion;
        public ProformaContrato proformaContrato;
        public PanelFinal(int id,Conexion conexion)
        {
            InitializeComponent();
            this.id = id;
            this.conexion = conexion;
            this.proformaContrato = new ProformaContrato(conexion);
        }

        private void PanelFinal_Load(object sender, EventArgs e)
        {
            
            datosContrato.EnforceConstraints = false;
            this.reporteProformaContratoTableAdapter.Connection = conexion.connect;
            ReportParameter parametros = new ReportParameter("Descripcion", proformaContrato.Obtener_Descripcion(id));
            this.reporteProformaContratoTableAdapter.Fill(datosContrato.ReporteProformaContrato,id);
            reportViewer1.LocalReport.SetParameters(parametros);
            this.reportViewer1.RefreshReport();
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
