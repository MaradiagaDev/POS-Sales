using Microsoft.Reporting.WinForms;
using NeoCobranza.Data;
using NeoCobranza.ModelsCobranza;
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
    public partial class InformeReporteServiciosVD : Form
    {
        public int id;
        public Conexion conexion_;
        public InformeReporteServiciosVD(int id,Conexion conexion)
        {
            InitializeComponent();
            this.id = id;
            this.conexion_ = conexion;
        }

        private void InformeReporteServiciosVD_Load(object sender, EventArgs e)
        {
            this.caja_TramitesTableAdapter.Connection = conexion_.connect;
            this.rEPORTERIA_VentasProformasTableAdapter.Connection = conexion_.connect;


            // TODO: esta línea de código carga datos en la tabla 'data_VentaProforma.Caja_Tramites' Puede moverla o quitarla según sea necesario.
            this.caja_TramitesTableAdapter.Fill(this.data_VentaProforma.Caja_Tramites,id);
            data_VentaProforma.EnforceConstraints = false;
            // TODO: esta línea de código carga datos en la tabla 'data_VentaProforma.REPORTERIA_VentasProformas' Puede moverla o quitarla según sea necesario.
            this.rEPORTERIA_VentasProformasTableAdapter.Fill(this.data_VentaProforma.REPORTERIA_VentasProformas,id);

            this.reportViewer1.RefreshReport();
        }
    }
}
