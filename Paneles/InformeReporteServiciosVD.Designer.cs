namespace NeoCobranza.Paneles
{
    partial class InformeReporteServiciosVD
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.REPORTERIA_VentasProformasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data_VentaProforma = new NeoCobranza.Data_VentaProforma();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rEPORTERIAVentasProformasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rEPORTERIA_VentasProformasTableAdapter = new NeoCobranza.Data_VentaProformaTableAdapters.REPORTERIA_VentasProformasTableAdapter();
            this.cajaTramitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caja_TramitesTableAdapter = new NeoCobranza.Data_VentaProformaTableAdapters.Caja_TramitesTableAdapter();
            this.Caja_TramitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.REPORTERIA_VentasProformasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_VentaProforma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEPORTERIAVentasProformasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaTramitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caja_TramitesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // REPORTERIA_VentasProformasBindingSource
            // 
            this.REPORTERIA_VentasProformasBindingSource.DataMember = "REPORTERIA_VentasProformas";
            this.REPORTERIA_VentasProformasBindingSource.DataSource = this.data_VentaProforma;
            // 
            // data_VentaProforma
            // 
            this.data_VentaProforma.DataSetName = "Data_VentaProforma";
            this.data_VentaProforma.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.REPORTERIA_VentasProformasBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.Caja_TramitesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Informes.Informe_VentaProforma.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // rEPORTERIAVentasProformasBindingSource
            // 
            this.rEPORTERIAVentasProformasBindingSource.DataMember = "REPORTERIA_VentasProformas";
            this.rEPORTERIAVentasProformasBindingSource.DataSource = this.data_VentaProforma;
            // 
            // rEPORTERIA_VentasProformasTableAdapter
            // 
            this.rEPORTERIA_VentasProformasTableAdapter.ClearBeforeFill = true;
            // 
            // cajaTramitesBindingSource
            // 
            this.cajaTramitesBindingSource.DataMember = "Caja_Tramites";
            this.cajaTramitesBindingSource.DataSource = this.data_VentaProforma;
            // 
            // caja_TramitesTableAdapter
            // 
            this.caja_TramitesTableAdapter.ClearBeforeFill = true;
            // 
            // Caja_TramitesBindingSource
            // 
            this.Caja_TramitesBindingSource.DataMember = "Caja_Tramites";
            this.Caja_TramitesBindingSource.DataSource = this.data_VentaProforma;
            // 
            // InformeReporteServiciosVD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "InformeReporteServiciosVD";
            this.Text = "InformeReporteServiciosVD";
            this.Load += new System.EventHandler(this.InformeReporteServiciosVD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.REPORTERIA_VentasProformasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_VentaProforma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEPORTERIAVentasProformasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaTramitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caja_TramitesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rEPORTERIAVentasProformasBindingSource;
        private Data_VentaProforma data_VentaProforma;
        private Data_VentaProformaTableAdapters.REPORTERIA_VentasProformasTableAdapter rEPORTERIA_VentasProformasTableAdapter;
        private System.Windows.Forms.BindingSource REPORTERIA_VentasProformasBindingSource;
        private System.Windows.Forms.BindingSource Caja_TramitesBindingSource;
        private System.Windows.Forms.BindingSource cajaTramitesBindingSource;
        private Data_VentaProformaTableAdapters.Caja_TramitesTableAdapter caja_TramitesTableAdapter;
    }
}