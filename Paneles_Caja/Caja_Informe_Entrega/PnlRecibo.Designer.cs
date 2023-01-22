namespace NeoCobranza.Paneles_Caja.Caja_Informe_Entrega
{
    partial class PnlRecibo
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Caja_Reporte_EntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data_ReciboOficial = new NeoCobranza.Data_ReciboOficial();
            this.Caja_OtrosPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cajaReporteEntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caja_Reporte_EntregaTableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Caja_Reporte_EntregaTableAdapter();
            this.cajaOtrosPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caja_OtrosPagosTableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Caja_OtrosPagosTableAdapter();
            this.cajaCordobaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caja_CordobaTableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Caja_CordobaTableAdapter();
            this.Caja_CordobaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Caja_Reporte_EntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_ReciboOficial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caja_OtrosPagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaReporteEntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaOtrosPagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaCordobaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caja_CordobaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Oficial";
            reportDataSource1.Value = this.Caja_Reporte_EntregaBindingSource;
            reportDataSource2.Name = "Otros";
            reportDataSource2.Value = this.Caja_OtrosPagosBindingSource;
            reportDataSource3.Name = "total";
            reportDataSource3.Value = this.Caja_CordobaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Paneles_Caja.Caja_Informe_Entrega.Rpt_ReciboOficial.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Caja_Reporte_EntregaBindingSource
            // 
            this.Caja_Reporte_EntregaBindingSource.DataMember = "Caja_Reporte_Entrega";
            this.Caja_Reporte_EntregaBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // data_ReciboOficial
            // 
            this.data_ReciboOficial.DataSetName = "Data_ReciboOficial";
            this.data_ReciboOficial.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Caja_OtrosPagosBindingSource
            // 
            this.Caja_OtrosPagosBindingSource.DataMember = "Caja_OtrosPagos";
            this.Caja_OtrosPagosBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // cajaReporteEntregaBindingSource
            // 
            this.cajaReporteEntregaBindingSource.DataMember = "Caja_Reporte_Entrega";
            this.cajaReporteEntregaBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // caja_Reporte_EntregaTableAdapter
            // 
            this.caja_Reporte_EntregaTableAdapter.ClearBeforeFill = true;
            // 
            // cajaOtrosPagosBindingSource
            // 
            this.cajaOtrosPagosBindingSource.DataMember = "Caja_OtrosPagos";
            this.cajaOtrosPagosBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // caja_OtrosPagosTableAdapter
            // 
            this.caja_OtrosPagosTableAdapter.ClearBeforeFill = true;
            // 
            // cajaCordobaBindingSource
            // 
            this.cajaCordobaBindingSource.DataMember = "Caja_Cordoba";
            this.cajaCordobaBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // caja_CordobaTableAdapter
            // 
            this.caja_CordobaTableAdapter.ClearBeforeFill = true;
            // 
            // Caja_CordobaBindingSource
            // 
            this.Caja_CordobaBindingSource.DataMember = "Caja_Cordoba";
            this.Caja_CordobaBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // PnlRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PnlRecibo";
            this.Text = "PnlRecibo";
            this.Load += new System.EventHandler(this.PnlRecibo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Caja_Reporte_EntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_ReciboOficial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caja_OtrosPagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaReporteEntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaOtrosPagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaCordobaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Caja_CordobaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Caja_Reporte_EntregaBindingSource;
        private Data_ReciboOficial data_ReciboOficial;
        private System.Windows.Forms.BindingSource cajaReporteEntregaBindingSource;
        private Data_ReciboOficialTableAdapters.Caja_Reporte_EntregaTableAdapter caja_Reporte_EntregaTableAdapter;
        private System.Windows.Forms.BindingSource Caja_OtrosPagosBindingSource;
        private System.Windows.Forms.BindingSource cajaOtrosPagosBindingSource;
        private Data_ReciboOficialTableAdapters.Caja_OtrosPagosTableAdapter caja_OtrosPagosTableAdapter;
        private System.Windows.Forms.BindingSource Caja_CordobaBindingSource;
        private System.Windows.Forms.BindingSource cajaCordobaBindingSource;
        private Data_ReciboOficialTableAdapters.Caja_CordobaTableAdapter caja_CordobaTableAdapter;
    }
}