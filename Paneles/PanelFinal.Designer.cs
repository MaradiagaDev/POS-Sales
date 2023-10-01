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
            this.datosContrato = new NeoCobranza.DatosContrato();
            this.reporteProformaContratoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteProformaContratoTableAdapter = new NeoCobranza.DatosContratoTableAdapters.ReporteProformaContratoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.datosContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProformaContratoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Datos";
            reportDataSource1.Value = this.reporteProformaContratoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Informes.ProformaContrato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // datosContrato
            // 
            this.datosContrato.DataSetName = "DatosContrato";
            this.datosContrato.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteProformaContratoBindingSource
            // 
            this.reporteProformaContratoBindingSource.DataMember = "ReporteProformaContrato";
            this.reporteProformaContratoBindingSource.DataSource = this.datosContrato;
            // 
            // reporteProformaContratoTableAdapter
            // 
            this.reporteProformaContratoTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.datosContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProformaContratoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteProformaContratoBindingSource;
        private DatosContrato datosContrato;
        private DatosContratoTableAdapters.ReporteProformaContratoTableAdapter reporteProformaContratoTableAdapter;
    }
}