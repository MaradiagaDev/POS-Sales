using Microsoft.Reporting.WinForms;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Informes.Informes_Formato_Ticket
{
    public partial class FrmFacturaTicket : Form
    {
        DataUtilities data = new DataUtilities();
        string _sucursal;
        decimal _orden;
        public FrmFacturaTicket(string sucursal, decimal orden)
        {
            _sucursal = sucursal;
            _orden = orden;
            InitializeComponent();
        }

        private void FrmFacturaTicket_Load(object sender, EventArgs e)
        {
            data.vGlobConnection.Open();
            this.vwFacturaTicketTableAdapter.Connection = data.vGlobConnection;
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataset.vwFacturaTicket' Puede moverla o quitarla según sea necesario.
            this.vwFacturaTicketTableAdapter.Fill(this.facturacionDataset.vwFacturaTicket,_sucursal,_orden);
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataset.vwFacturaTicket' Puede moverla o quitarla según sea necesario.
            //this.vwFacturaTicketTableAdapter.Fill(this.facturacionDataset.vwFacturaTicket);
            // TODO: esta línea de código carga datos en la tabla 'data_ReciboOficial.Reporteria_Total_Oficiales' Puede moverla o quitarla según sea necesario.

            //this.vwFacturaTicketTableAdapter.Connection = data.vGlobConnection;
            //data.vGlobConnection.Open();
            //this.vwFacturaTicketTableAdapter.Fill(this.facturacionDataset.vwFacturaTicket,_sucursal,_orden);


            //string basePath = Directory.GetParent(Application.StartupPath).Parent.FullName;
            //string reportPath = Path.Combine(basePath, "Informes", "Informes Formato Ticket", "XrpInformeFacturaTicket.rdlc");

            ////string reportPath = System.IO.Path.Combine(Application.StartupPath, "Informes\\Informes Formato Ticket\\XrpInformeFacturaTicket.rdlc");
            ////reportViewer1.LocalReport.ReportPath = reportPath;

            //if (!System.IO.File.Exists(reportPath))
            //{
            //    throw new FileNotFoundException($"El archivo de reporte no se encontró: {reportPath}");
            //}


            //reportViewer1.LocalReport.DataSources.Clear();

            //ReportDataSource dataSource = new ReportDataSource("NombreDelDataSet", facturacionDataset.vwFacturaTicket.CopyToDataTable());
            //reportViewer1.LocalReport.DataSources.Add(dataSource);

            //// Refrescar el reporte
            this.reportViewer1.RefreshReport();
        }
    }
}
