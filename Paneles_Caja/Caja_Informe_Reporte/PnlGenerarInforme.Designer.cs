namespace NeoCobranza.Paneles_Caja.Caja_Informe_Reporte
{
    partial class PnlGenerarInforme
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
            this.data_ReciboOficial = new NeoCobranza.Data_ReciboOficial();
            this.reporteriaTotalOficialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_Total_OficialesTableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Reporteria_Total_OficialesTableAdapter();
            this.Reporteria_Total_OficialesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.data_ReciboOficial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaTotalOficialesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_Total_OficialesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Oficiales";
            reportDataSource1.Value = this.Reporteria_Total_OficialesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Paneles_Caja.Caja_Informe_Reporte.Reporte_Generar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1074, 518);
            this.reportViewer1.TabIndex = 0;
            // 
            // data_ReciboOficial
            // 
            this.data_ReciboOficial.DataSetName = "Data_ReciboOficial";
            this.data_ReciboOficial.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteriaTotalOficialesBindingSource
            // 
            this.reporteriaTotalOficialesBindingSource.DataMember = "Reporteria_Total_Oficiales";
            this.reporteriaTotalOficialesBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // reporteria_Total_OficialesTableAdapter
            // 
            this.reporteria_Total_OficialesTableAdapter.ClearBeforeFill = true;
            // 
            // Reporteria_Total_OficialesBindingSource
            // 
            this.Reporteria_Total_OficialesBindingSource.DataMember = "Reporteria_Total_Oficiales";
            this.Reporteria_Total_OficialesBindingSource.DataSource = this.data_ReciboOficial;
            // 
            // PnlGenerarInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 518);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PnlGenerarInforme";
            this.Text = "PnlGenerarInforme";
            this.Load += new System.EventHandler(this.PnlGenerarInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_ReciboOficial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaTotalOficialesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_Total_OficialesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporteria_Total_OficialesBindingSource;
        private Data_ReciboOficial data_ReciboOficial;
        private System.Windows.Forms.BindingSource reporteriaTotalOficialesBindingSource;
        private Data_ReciboOficialTableAdapters.Reporteria_Total_OficialesTableAdapter reporteria_Total_OficialesTableAdapter;
    }
}