namespace NeoCobranza.PnlInventario
{
    partial class Pnl_InformeInventario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Reporte_Inventario_DisponiblesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data_Inventario = new NeoCobranza.Data_Inventario();
            this.Reporte_InventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Nuevo_listar_SinInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_DisponiblesxUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_ReservadoxUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nuevolistarSinInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporteInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_InventarioTableAdapter = new NeoCobranza.Data_InventarioTableAdapters.Reporte_InventarioTableAdapter();
            this.reporteInventarioDisponiblesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_Inventario_DisponiblesTableAdapter = new NeoCobranza.Data_InventarioTableAdapters.Reporte_Inventario_DisponiblesTableAdapter();
            this.reporteInventarioBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.nuevo_listar_SinInventarioTableAdapter = new NeoCobranza.Data_InventarioTableAdapters.Nuevo_listar_SinInventarioTableAdapter();
            this.reporteriaDisponiblesxUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_DisponiblesxUbicacionTableAdapter = new NeoCobranza.Data_InventarioTableAdapters.Reporteria_DisponiblesxUbicacionTableAdapter();
            this.reporteriaDisponiblesxUbicacionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reporteriaReservadoxUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReservadoxUbicacionTableAdapter = new NeoCobranza.Data_InventarioTableAdapters.Reporteria_ReservadoxUbicacionTableAdapter();
            this.reporteriaReservadoModeloxUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReservadoModeloxUbicacionTableAdapter = new NeoCobranza.Data_InventarioTableAdapters.Reporteria_ReservadoModeloxUbicacionTableAdapter();
            this.Reporteria_ReservadoModeloxUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Inventario_DisponiblesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Inventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_InventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nuevo_listar_SinInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_DisponiblesxUbicacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReservadoxUbicacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevolistarSinInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioDisponiblesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaDisponiblesxUbicacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaDisponiblesxUbicacionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReservadoxUbicacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReservadoModeloxUbicacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReservadoModeloxUbicacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_Inventario_DisponiblesBindingSource
            // 
            this.Reporte_Inventario_DisponiblesBindingSource.DataMember = "Reporte_Inventario_Disponibles";
            this.Reporte_Inventario_DisponiblesBindingSource.DataSource = this.data_Inventario;
            // 
            // data_Inventario
            // 
            this.data_Inventario.DataSetName = "Data_Inventario";
            this.data_Inventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Reporte_InventarioBindingSource
            // 
            this.Reporte_InventarioBindingSource.DataMember = "Reporte_Inventario";
            this.Reporte_InventarioBindingSource.DataSource = this.data_Inventario;
            // 
            // Nuevo_listar_SinInventarioBindingSource
            // 
            this.Nuevo_listar_SinInventarioBindingSource.DataMember = "Nuevo_listar_SinInventario";
            this.Nuevo_listar_SinInventarioBindingSource.DataSource = this.data_Inventario;
            // 
            // Reporteria_DisponiblesxUbicacionBindingSource
            // 
            this.Reporteria_DisponiblesxUbicacionBindingSource.DataMember = "Reporteria_DisponiblesxUbicacion";
            this.Reporteria_DisponiblesxUbicacionBindingSource.DataSource = this.data_Inventario;
            // 
            // Reporteria_ReservadoxUbicacionBindingSource
            // 
            this.Reporteria_ReservadoxUbicacionBindingSource.DataMember = "Reporteria_ReservadoxUbicacion";
            this.Reporteria_ReservadoxUbicacionBindingSource.DataSource = this.data_Inventario;
            // 
            // nuevolistarSinInventarioBindingSource
            // 
            this.nuevolistarSinInventarioBindingSource.DataMember = "Nuevo_listar_SinInventario";
            this.nuevolistarSinInventarioBindingSource.DataSource = this.data_Inventario;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte_Inventario_DisponiblesBindingSource;
            reportDataSource2.Name = "Inventario";
            reportDataSource2.Value = this.Reporte_InventarioBindingSource;
            reportDataSource3.Name = "DataSet2";
            reportDataSource3.Value = this.Nuevo_listar_SinInventarioBindingSource;
            reportDataSource4.Name = "DataSet3";
            reportDataSource4.Value = this.Reporteria_DisponiblesxUbicacionBindingSource;
            reportDataSource5.Name = "DisponiblesXUbicacion";
            reportDataSource5.Value = this.Reporteria_DisponiblesxUbicacionBindingSource;
            reportDataSource6.Name = "ReservadosXUbicacion";
            reportDataSource6.Value = this.Reporteria_ReservadoxUbicacionBindingSource;
            reportDataSource7.Name = "DataSet4";
            reportDataSource7.Value = this.Reporteria_ReservadoModeloxUbicacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.PnlInventario.Informes.Rpt_Inventario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(852, 483);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporteInventarioBindingSource
            // 
            this.reporteInventarioBindingSource.DataMember = "Reporte_Inventario";
            this.reporteInventarioBindingSource.DataSource = this.data_Inventario;
            // 
            // reporte_InventarioTableAdapter
            // 
            this.reporte_InventarioTableAdapter.ClearBeforeFill = true;
            // 
            // reporteInventarioDisponiblesBindingSource
            // 
            this.reporteInventarioDisponiblesBindingSource.DataMember = "Reporte_Inventario_Disponibles";
            this.reporteInventarioDisponiblesBindingSource.DataSource = this.data_Inventario;
            // 
            // reporte_Inventario_DisponiblesTableAdapter
            // 
            this.reporte_Inventario_DisponiblesTableAdapter.ClearBeforeFill = true;
            // 
            // reporteInventarioBindingSource1
            // 
            this.reporteInventarioBindingSource1.DataMember = "Reporte_Inventario";
            this.reporteInventarioBindingSource1.DataSource = this.data_Inventario;
            // 
            // nuevo_listar_SinInventarioTableAdapter
            // 
            this.nuevo_listar_SinInventarioTableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaDisponiblesxUbicacionBindingSource
            // 
            this.reporteriaDisponiblesxUbicacionBindingSource.DataMember = "Reporteria_DisponiblesxUbicacion";
            this.reporteriaDisponiblesxUbicacionBindingSource.DataSource = this.data_Inventario;
            // 
            // reporteria_DisponiblesxUbicacionTableAdapter
            // 
            this.reporteria_DisponiblesxUbicacionTableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaDisponiblesxUbicacionBindingSource1
            // 
            this.reporteriaDisponiblesxUbicacionBindingSource1.DataMember = "Reporteria_DisponiblesxUbicacion";
            this.reporteriaDisponiblesxUbicacionBindingSource1.DataSource = this.data_Inventario;
            // 
            // reporteriaReservadoxUbicacionBindingSource
            // 
            this.reporteriaReservadoxUbicacionBindingSource.DataMember = "Reporteria_ReservadoxUbicacion";
            this.reporteriaReservadoxUbicacionBindingSource.DataSource = this.data_Inventario;
            // 
            // reporteria_ReservadoxUbicacionTableAdapter
            // 
            this.reporteria_ReservadoxUbicacionTableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaReservadoModeloxUbicacionBindingSource
            // 
            this.reporteriaReservadoModeloxUbicacionBindingSource.DataMember = "Reporteria_ReservadoModeloxUbicacion";
            this.reporteriaReservadoModeloxUbicacionBindingSource.DataSource = this.data_Inventario;
            // 
            // reporteria_ReservadoModeloxUbicacionTableAdapter
            // 
            this.reporteria_ReservadoModeloxUbicacionTableAdapter.ClearBeforeFill = true;
            // 
            // Reporteria_ReservadoModeloxUbicacionBindingSource
            // 
            this.Reporteria_ReservadoModeloxUbicacionBindingSource.DataMember = "Reporteria_ReservadoModeloxUbicacion";
            this.Reporteria_ReservadoModeloxUbicacionBindingSource.DataSource = this.data_Inventario;
            // 
            // Pnl_InformeInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 483);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Pnl_InformeInventario";
            this.Text = "Pnl_InformeInventario";
            this.Load += new System.EventHandler(this.Pnl_InformeInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Inventario_DisponiblesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_Inventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_InventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nuevo_listar_SinInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_DisponiblesxUbicacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReservadoxUbicacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevolistarSinInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioDisponiblesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaDisponiblesxUbicacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaDisponiblesxUbicacionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReservadoxUbicacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReservadoModeloxUbicacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReservadoModeloxUbicacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Data_Inventario data_Inventario;
        private System.Windows.Forms.BindingSource reporteInventarioBindingSource;
        private Data_InventarioTableAdapters.Reporte_InventarioTableAdapter reporte_InventarioTableAdapter;
        private System.Windows.Forms.BindingSource Reporte_InventarioBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporte_Inventario_DisponiblesBindingSource;
        private System.Windows.Forms.BindingSource reporteInventarioDisponiblesBindingSource;
        private Data_InventarioTableAdapters.Reporte_Inventario_DisponiblesTableAdapter reporte_Inventario_DisponiblesTableAdapter;
        private System.Windows.Forms.BindingSource reporteInventarioBindingSource1;
        private System.Windows.Forms.BindingSource nuevolistarSinInventarioBindingSource;
        private Data_InventarioTableAdapters.Nuevo_listar_SinInventarioTableAdapter nuevo_listar_SinInventarioTableAdapter;
        private System.Windows.Forms.BindingSource reporteriaDisponiblesxUbicacionBindingSource;
        private Data_InventarioTableAdapters.Reporteria_DisponiblesxUbicacionTableAdapter reporteria_DisponiblesxUbicacionTableAdapter;
        private System.Windows.Forms.BindingSource Nuevo_listar_SinInventarioBindingSource;
        private System.Windows.Forms.BindingSource Reporteria_DisponiblesxUbicacionBindingSource;
        private System.Windows.Forms.BindingSource reporteriaDisponiblesxUbicacionBindingSource1;
        private System.Windows.Forms.BindingSource reporteriaReservadoxUbicacionBindingSource;
        private Data_InventarioTableAdapters.Reporteria_ReservadoxUbicacionTableAdapter reporteria_ReservadoxUbicacionTableAdapter;
        private System.Windows.Forms.BindingSource Reporteria_ReservadoxUbicacionBindingSource;
        private System.Windows.Forms.BindingSource reporteriaReservadoModeloxUbicacionBindingSource;
        private Data_InventarioTableAdapters.Reporteria_ReservadoModeloxUbicacionTableAdapter reporteria_ReservadoModeloxUbicacionTableAdapter;
        private System.Windows.Forms.BindingSource Reporteria_ReservadoModeloxUbicacionBindingSource;
    }
}