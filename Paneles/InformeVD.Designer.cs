namespace NeoCobranza.Paneles
{
    partial class InformeVD
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
            this.dataSetVD = new NeoCobranza.DataSetVD();
            this.filtrarReporteServicioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filtrar_ReporteServicioTableAdapter = new NeoCobranza.DataSetVDTableAdapters.filtrar_ReporteServicioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtrarReporteServicioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetVD";
            reportDataSource1.Value = this.filtrarReporteServicioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Informes.InformeVD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetVD
            // 
            this.dataSetVD.DataSetName = "DataSetVD";
            this.dataSetVD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // filtrarReporteServicioBindingSource
            // 
            this.filtrarReporteServicioBindingSource.DataMember = "filtrar_ReporteServicio";
            this.filtrarReporteServicioBindingSource.DataSource = this.dataSetVD;
            // 
            // filtrar_ReporteServicioTableAdapter
            // 
            this.filtrar_ReporteServicioTableAdapter.ClearBeforeFill = true;
            // 
            // InformeVD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "InformeVD";
            this.Text = "InformeVD";
            this.Load += new System.EventHandler(this.InformeVD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtrarReporteServicioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource filtrarReporteServicioBindingSource;
        private DataSetVD dataSetVD;
        private DataSetVDTableAdapters.filtrar_ReporteServicioTableAdapter filtrar_ReporteServicioTableAdapter;
    }
}