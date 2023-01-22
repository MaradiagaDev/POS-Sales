namespace NeoCobranza.Paneles_Contrato
{
    partial class PnlInformeEconomico
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
            this.Contrato_Informacion_EconomicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.neoCobranzaDataSet = new NeoCobranza.NeoCobranzaDataSet();
            this.Contrato_Reporte_Datos_GeneralesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tasa2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.neoCobranzaDataSet1 = new NeoCobranza.NeoCobranzaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TasaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contratoInformacionEconomicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contrato_Informacion_EconomicaTableAdapter = new NeoCobranza.NeoCobranzaDataSetTableAdapters.Contrato_Informacion_EconomicaTableAdapter();
            this.tasaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.contratoReporteDatosGeneralesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contrato_Reporte_Datos_GeneralesTableAdapter = new NeoCobranza.NeoCobranzaDataSetTableAdapters.Contrato_Reporte_Datos_GeneralesTableAdapter();
            this.tasa2TableAdapter = new NeoCobranza.NeoCobranzaDataSetTableAdapters.Tasa2TableAdapter();
            this.contratoVerValoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contrato_Ver_ValoresTableAdapter = new NeoCobranza.NeoCobranzaDataSetTableAdapters.Contrato_Ver_ValoresTableAdapter();
            this.Contrato_Ver_ValoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Contrato_Informacion_EconomicaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neoCobranzaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrato_Reporte_Datos_GeneralesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasa2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neoCobranzaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TasaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoInformacionEconomicaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoReporteDatosGeneralesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoVerValoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrato_Ver_ValoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Contrato_Informacion_EconomicaBindingSource
            // 
            this.Contrato_Informacion_EconomicaBindingSource.DataMember = "Contrato_Informacion_Economica";
            this.Contrato_Informacion_EconomicaBindingSource.DataSource = this.neoCobranzaDataSet;
            // 
            // neoCobranzaDataSet
            // 
            this.neoCobranzaDataSet.DataSetName = "NeoCobranzaDataSet";
            this.neoCobranzaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Contrato_Reporte_Datos_GeneralesBindingSource
            // 
            this.Contrato_Reporte_Datos_GeneralesBindingSource.DataMember = "Contrato_Reporte_Datos_Generales";
            this.Contrato_Reporte_Datos_GeneralesBindingSource.DataSource = this.neoCobranzaDataSet;
            // 
            // tasa2BindingSource
            // 
            this.tasa2BindingSource.DataMember = "Tasa2";
            this.tasa2BindingSource.DataSource = this.neoCobranzaDataSet1;
            // 
            // neoCobranzaDataSet1
            // 
            this.neoCobranzaDataSet1.DataSetName = "NeoCobranzaDataSet";
            this.neoCobranzaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "General";
            reportDataSource1.Value = this.Contrato_Informacion_EconomicaBindingSource;
            reportDataSource2.Name = "DatosG";
            reportDataSource2.Value = this.Contrato_Reporte_Datos_GeneralesBindingSource;
            reportDataSource3.Name = "tasa";
            reportDataSource3.Value = this.tasa2BindingSource;
            reportDataSource4.Name = "Valores";
            reportDataSource4.Value = this.Contrato_Ver_ValoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Paneles_Contrato.InformeEconomicoContrato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(819, 492);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // contratoInformacionEconomicaBindingSource
            // 
            this.contratoInformacionEconomicaBindingSource.DataMember = "Contrato_Informacion_Economica";
            this.contratoInformacionEconomicaBindingSource.DataSource = this.neoCobranzaDataSet;
            // 
            // contrato_Informacion_EconomicaTableAdapter
            // 
            this.contrato_Informacion_EconomicaTableAdapter.ClearBeforeFill = true;
            // 
            // tasaBindingSource1
            // 
            this.tasaBindingSource1.DataMember = "Tasa";
            this.tasaBindingSource1.DataSource = this.neoCobranzaDataSet;
            // 
            // contratoReporteDatosGeneralesBindingSource
            // 
            this.contratoReporteDatosGeneralesBindingSource.DataMember = "Contrato_Reporte_Datos_Generales";
            this.contratoReporteDatosGeneralesBindingSource.DataSource = this.neoCobranzaDataSet;
            // 
            // contrato_Reporte_Datos_GeneralesTableAdapter
            // 
            this.contrato_Reporte_Datos_GeneralesTableAdapter.ClearBeforeFill = true;
            // 
            // tasa2TableAdapter
            // 
            this.tasa2TableAdapter.ClearBeforeFill = true;
            // 
            // contratoVerValoresBindingSource
            // 
            this.contratoVerValoresBindingSource.DataMember = "Contrato_Ver_Valores";
            this.contratoVerValoresBindingSource.DataSource = this.neoCobranzaDataSet;
            // 
            // contrato_Ver_ValoresTableAdapter
            // 
            this.contrato_Ver_ValoresTableAdapter.ClearBeforeFill = true;
            // 
            // Contrato_Ver_ValoresBindingSource
            // 
            this.Contrato_Ver_ValoresBindingSource.DataMember = "Contrato_Ver_Valores";
            this.Contrato_Ver_ValoresBindingSource.DataSource = this.neoCobranzaDataSet;
            // 
            // PnlInformeEconomico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 492);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PnlInformeEconomico";
            this.Text = "PnlInformeEconomico";
            this.Load += new System.EventHandler(this.PnlInformeEconomico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Contrato_Informacion_EconomicaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neoCobranzaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrato_Reporte_Datos_GeneralesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasa2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neoCobranzaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TasaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoInformacionEconomicaBindingSource)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.contratoReporteDatosGeneralesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoVerValoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrato_Ver_ValoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TasaBindingSource;
        private NeoCobranzaDataSet neoCobranzaDataSet;
        private System.Windows.Forms.BindingSource contratoInformacionEconomicaBindingSource;
        private NeoCobranzaDataSetTableAdapters.Contrato_Informacion_EconomicaTableAdapter contrato_Informacion_EconomicaTableAdapter;
        private System.Windows.Forms.BindingSource tasaBindingSource1;
        private System.Windows.Forms.BindingSource Contrato_Informacion_EconomicaBindingSource;
        private System.Windows.Forms.BindingSource Contrato_Reporte_Datos_GeneralesBindingSource;
        private System.Windows.Forms.BindingSource contratoReporteDatosGeneralesBindingSource;
        private NeoCobranzaDataSetTableAdapters.Contrato_Reporte_Datos_GeneralesTableAdapter contrato_Reporte_Datos_GeneralesTableAdapter;
        private NeoCobranzaDataSet neoCobranzaDataSet1;
        private System.Windows.Forms.BindingSource tasa2BindingSource;
        private NeoCobranzaDataSetTableAdapters.Tasa2TableAdapter tasa2TableAdapter;
        private System.Windows.Forms.BindingSource Contrato_Ver_ValoresBindingSource;
        private System.Windows.Forms.BindingSource contratoVerValoresBindingSource;
        private NeoCobranzaDataSetTableAdapters.Contrato_Ver_ValoresTableAdapter contrato_Ver_ValoresTableAdapter;
    }
}