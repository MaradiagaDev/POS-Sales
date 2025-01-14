
namespace NeoCobranza.Informes.Informes_Formato_Ticket
{
    partial class FrmFacturaTicket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.facturacionDataset = new NeoCobranza.Dataset.FacturacionDataset();
            this.vwFacturaTicketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vwFacturaTicketTableAdapter = new NeoCobranza.Dataset.FacturacionDatasetTableAdapters.vwFacturaTicketTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.facturacionDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwFacturaTicketBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtFact";
            reportDataSource1.Value = this.vwFacturaTicketBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Informes.FacturaTck.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(271, 450);
            this.reportViewer1.TabIndex = 1;
            // 
            // facturacionDataset
            // 
            this.facturacionDataset.DataSetName = "FacturacionDataset";
            this.facturacionDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwFacturaTicketBindingSource
            // 
            this.vwFacturaTicketBindingSource.DataMember = "vwFacturaTicket";
            this.vwFacturaTicketBindingSource.DataSource = this.facturacionDataset;
            // 
            // vwFacturaTicketTableAdapter
            // 
            this.vwFacturaTicketTableAdapter.ClearBeforeFill = true;
            // 
            // FrmFacturaTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmFacturaTicket";
            this.Text = "FrmFacturaTicket";
            this.Load += new System.EventHandler(this.FrmFacturaTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturacionDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwFacturaTicketBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vwFacturaTicketBindingSource;
        private Dataset.FacturacionDataset facturacionDataset;
        private Dataset.FacturacionDatasetTableAdapters.vwFacturaTicketTableAdapter vwFacturaTicketTableAdapter;
    }
}