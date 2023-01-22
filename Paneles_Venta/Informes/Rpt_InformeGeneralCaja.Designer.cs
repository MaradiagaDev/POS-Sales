namespace NeoCobranza.Paneles_Venta.Informes
{
    partial class Rpt_InformeGeneralCaja
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
            this.data_Facturacion = new NeoCobranza.Data_Facturacion();
            this.reporteriaVentasGeneralesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_Ventas_GeneralesTableAdapter = new NeoCobranza.Data_FacturacionTableAdapters.Reporteria_Ventas_GeneralesTableAdapter();
            this.Reporteria_Ventas_GeneralesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.data_Facturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaVentasGeneralesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_Ventas_GeneralesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ventas";
            reportDataSource1.Value = this.Reporteria_Ventas_GeneralesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Paneles_Venta.Informes.Rep_InformeGeneralVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(890, 497);
            this.reportViewer1.TabIndex = 0;
            // 
            // data_Facturacion
            // 
            this.data_Facturacion.DataSetName = "Data_Facturacion";
            this.data_Facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteriaVentasGeneralesBindingSource
            // 
            this.reporteriaVentasGeneralesBindingSource.DataMember = "Reporteria_Ventas_Generales";
            this.reporteriaVentasGeneralesBindingSource.DataSource = this.data_Facturacion;
            // 
            // reporteria_Ventas_GeneralesTableAdapter
            // 
            this.reporteria_Ventas_GeneralesTableAdapter.ClearBeforeFill = true;
            // 
            // Reporteria_Ventas_GeneralesBindingSource
            // 
            this.Reporteria_Ventas_GeneralesBindingSource.DataMember = "Reporteria_Ventas_Generales";
            this.Reporteria_Ventas_GeneralesBindingSource.DataSource = this.data_Facturacion;
            // 
            // Rpt_InformeGeneralCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 497);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Rpt_InformeGeneralCaja";
            this.Text = "Rpt_InformeGeneralCaja";
            this.Load += new System.EventHandler(this.Rpt_InformeGeneralCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_Facturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaVentasGeneralesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_Ventas_GeneralesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporteria_Ventas_GeneralesBindingSource;
        private Data_Facturacion data_Facturacion;
        private System.Windows.Forms.BindingSource reporteriaVentasGeneralesBindingSource;
        private Data_FacturacionTableAdapters.Reporteria_Ventas_GeneralesTableAdapter reporteria_Ventas_GeneralesTableAdapter;
    }
}