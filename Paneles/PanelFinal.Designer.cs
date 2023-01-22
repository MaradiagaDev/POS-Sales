namespace NeoCobranza.Paneles
{
    partial class PanelFinal
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
            this.reporteVentasContratoData = new NeoCobranza.ReporteVentasContratoData();
            this.reporteProformaContratoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteProformaContratoTableAdapter = new NeoCobranza.ReporteVentasContratoDataTableAdapters.ReporteProformaContratoTableAdapter();
            this.reporteProformaContratoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasContratoData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProformaContratoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProformaContratoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteProformaContratoBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Informes.ReporteVentasContrato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporteVentasContratoData
            // 
            this.reporteVentasContratoData.DataSetName = "ReporteVentasContratoData";
            this.reporteVentasContratoData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteProformaContratoBindingSource
            // 
            this.reporteProformaContratoBindingSource.DataMember = "ReporteProformaContrato";
            this.reporteProformaContratoBindingSource.DataSource = this.reporteVentasContratoData;
            // 
            // reporteProformaContratoTableAdapter
            // 
            this.reporteProformaContratoTableAdapter.ClearBeforeFill = true;
            // 
            // reporteProformaContratoBindingSource1
            // 
            this.reporteProformaContratoBindingSource1.DataMember = "ReporteProformaContrato";
            this.reporteProformaContratoBindingSource1.DataSource = this.reporteVentasContratoData;
            // 
            // PanelFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PanelFinal";
            this.Text = "PanelFinal";
            this.Load += new System.EventHandler(this.PanelFinal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasContratoData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProformaContratoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProformaContratoBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteProformaContratoBindingSource1;
        private ReporteVentasContratoData reporteVentasContratoData;
        private System.Windows.Forms.BindingSource reporteProformaContratoBindingSource;
        private ReporteVentasContratoDataTableAdapters.ReporteProformaContratoTableAdapter reporteProformaContratoTableAdapter;
    }
}