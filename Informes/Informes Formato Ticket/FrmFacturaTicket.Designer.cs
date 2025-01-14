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
            this.vwFacturaTicketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturacionDataset = new NeoCobranza.Dataset.FacturacionDataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vwFacturaTicketTableAdapter = new NeoCobranza.Dataset.FacturacionDatasetTableAdapters.vwFacturaTicketTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vwFacturaTicketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacionDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // vwFacturaTicketBindingSource
            // 
            this.vwFacturaTicketBindingSource.DataMember = "vwFacturaTicket";
            this.vwFacturaTicketBindingSource.DataSource = this.facturacionDataset;
            // 
            // facturacionDataset
            // 
            this.facturacionDataset.DataSetName = "FacturacionDataset";
            this.facturacionDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtFacturaTicket";
            reportDataSource1.Value = this.vwFacturaTicketBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Informes.Informes Formato Ticket.XrpInformeFacturaTicket.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(395, 708);
            this.reportViewer1.TabIndex = 0;
            // 
            // vwFacturaTicketTableAdapter
            // 
            this.vwFacturaTicketTableAdapter.ClearBeforeFill = true;
            // 
            // FrmFacturaTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 708);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmFacturaTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFacturaTicket";
            this.Load += new System.EventHandler(this.FrmFacturaTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vwFacturaTicketBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturacionDataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vwFacturaTicketBindingSource;
        private Dataset.FacturacionDataset facturacionDataset;
        private Dataset.FacturacionDatasetTableAdapters.vwFacturaTicketTableAdapter vwFacturaTicketTableAdapter;
    }
}