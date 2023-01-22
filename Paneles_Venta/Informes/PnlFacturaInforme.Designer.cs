namespace NeoCobranza.Paneles_Venta.Informes
{
    partial class PnlFacturaInforme
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
            this.data_Facturacion = new NeoCobranza.Data_Facturacion();
            this.nuevoListarAtaudesPorVenta2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nuevo_ListarAtaudesPorVenta2TableAdapter = new NeoCobranza.Data_FacturacionTableAdapters.Nuevo_ListarAtaudesPorVenta2TableAdapter();
            this.nuevoListarAServiciosPorVenta2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nuevo_ListarAServiciosPorVenta2TableAdapter = new NeoCobranza.Data_FacturacionTableAdapters.Nuevo_ListarAServiciosPorVenta2TableAdapter();
            this.reporteriaVentasGeneral2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_VentasGeneral2TableAdapter = new NeoCobranza.Data_FacturacionTableAdapters.Reporteria_VentasGeneral2TableAdapter();
            this.Nuevo_ListarAtaudesPorVenta2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Nuevo_ListarAServiciosPorVenta2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_VentasGeneral2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.data_Facturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevoListarAtaudesPorVenta2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevoListarAServiciosPorVenta2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaVentasGeneral2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nuevo_ListarAtaudesPorVenta2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nuevo_ListarAServiciosPorVenta2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_VentasGeneral2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ataudes";
            reportDataSource1.Value = this.Nuevo_ListarAtaudesPorVenta2BindingSource;
            reportDataSource2.Name = "Servicios";
            reportDataSource2.Value = this.Nuevo_ListarAServiciosPorVenta2BindingSource;
            reportDataSource3.Name = "General";
            reportDataSource3.Value = this.Reporteria_VentasGeneral2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Paneles_Venta.Informes.RptFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(965, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // data_Facturacion
            // 
            this.data_Facturacion.DataSetName = "Data_Facturacion";
            this.data_Facturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nuevoListarAtaudesPorVenta2BindingSource
            // 
            this.nuevoListarAtaudesPorVenta2BindingSource.DataMember = "Nuevo_ListarAtaudesPorVenta2";
            this.nuevoListarAtaudesPorVenta2BindingSource.DataSource = this.data_Facturacion;
            // 
            // nuevo_ListarAtaudesPorVenta2TableAdapter
            // 
            this.nuevo_ListarAtaudesPorVenta2TableAdapter.ClearBeforeFill = true;
            // 
            // nuevoListarAServiciosPorVenta2BindingSource
            // 
            this.nuevoListarAServiciosPorVenta2BindingSource.DataMember = "Nuevo_ListarAServiciosPorVenta2";
            this.nuevoListarAServiciosPorVenta2BindingSource.DataSource = this.data_Facturacion;
            // 
            // nuevo_ListarAServiciosPorVenta2TableAdapter
            // 
            this.nuevo_ListarAServiciosPorVenta2TableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaVentasGeneral2BindingSource
            // 
            this.reporteriaVentasGeneral2BindingSource.DataMember = "Reporteria_VentasGeneral2";
            this.reporteriaVentasGeneral2BindingSource.DataSource = this.data_Facturacion;
            // 
            // reporteria_VentasGeneral2TableAdapter
            // 
            this.reporteria_VentasGeneral2TableAdapter.ClearBeforeFill = true;
            // 
            // Nuevo_ListarAtaudesPorVenta2BindingSource
            // 
            this.Nuevo_ListarAtaudesPorVenta2BindingSource.DataMember = "Nuevo_ListarAtaudesPorVenta2";
            this.Nuevo_ListarAtaudesPorVenta2BindingSource.DataSource = this.data_Facturacion;
            // 
            // Nuevo_ListarAServiciosPorVenta2BindingSource
            // 
            this.Nuevo_ListarAServiciosPorVenta2BindingSource.DataMember = "Nuevo_ListarAServiciosPorVenta2";
            this.Nuevo_ListarAServiciosPorVenta2BindingSource.DataSource = this.data_Facturacion;
            // 
            // Reporteria_VentasGeneral2BindingSource
            // 
            this.Reporteria_VentasGeneral2BindingSource.DataMember = "Reporteria_VentasGeneral2";
            this.Reporteria_VentasGeneral2BindingSource.DataSource = this.data_Facturacion;
            // 
            // PnlFacturaInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 476);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PnlFacturaInforme";
            this.Text = "PnlFacturaInforme";
            this.Load += new System.EventHandler(this.PnlFacturaInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_Facturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevoListarAtaudesPorVenta2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevoListarAServiciosPorVenta2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaVentasGeneral2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nuevo_ListarAtaudesPorVenta2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nuevo_ListarAServiciosPorVenta2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_VentasGeneral2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource nuevoListarAtaudesPorVenta2BindingSource;
        private Data_Facturacion data_Facturacion;
        private System.Windows.Forms.BindingSource nuevoListarAServiciosPorVenta2BindingSource;
        private System.Windows.Forms.BindingSource reporteriaVentasGeneral2BindingSource;
        private Data_FacturacionTableAdapters.Nuevo_ListarAtaudesPorVenta2TableAdapter nuevo_ListarAtaudesPorVenta2TableAdapter;
        private Data_FacturacionTableAdapters.Nuevo_ListarAServiciosPorVenta2TableAdapter nuevo_ListarAServiciosPorVenta2TableAdapter;
        private Data_FacturacionTableAdapters.Reporteria_VentasGeneral2TableAdapter reporteria_VentasGeneral2TableAdapter;
        private System.Windows.Forms.BindingSource Nuevo_ListarAtaudesPorVenta2BindingSource;
        private System.Windows.Forms.BindingSource Nuevo_ListarAServiciosPorVenta2BindingSource;
        private System.Windows.Forms.BindingSource Reporteria_VentasGeneral2BindingSource;
    }
}