namespace NeoCobranza.Paneles_Contrato
{
    partial class PnlReciboColector
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.data_ReciboOficial = new NeoCobranza.Data_ReciboOficial();
            this.reporteriaReciboColector1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReciboColector1TableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Reporteria_ReciboColector1TableAdapter();
            this.reporteriaReciboColector2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReciboColector2TableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Reporteria_ReciboColector2TableAdapter();
            this.reporteriaReciboColector3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReciboColector3TableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Reporteria_ReciboColector3TableAdapter();
            this.reporteriaReciboColector4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReciboColector4TableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Reporteria_ReciboColector4TableAdapter();
            this.reporteriaReciboColector5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteria_ReciboColector5TableAdapter = new NeoCobranza.Data_ReciboOficialTableAdapters.Reporteria_ReciboColector5TableAdapter();
            this.Reporteria_ReciboColector1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_ReciboColector2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_ReciboColector3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_ReciboColector4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Reporteria_ReciboColector5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.data_ReciboOficial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector5BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InfoGeneral";
            reportDataSource1.Value = this.Reporteria_ReciboColector1BindingSource;
            reportDataSource2.Name = "Especifico";
            reportDataSource2.Value = this.Reporteria_ReciboColector2BindingSource;
            reportDataSource3.Name = "Cuotas";
            reportDataSource3.Value = this.Reporteria_ReciboColector3BindingSource;
            reportDataSource4.Name = "Tasa";
            reportDataSource4.Value = this.Reporteria_ReciboColector4BindingSource;
            reportDataSource5.Name = "Recibo";
            reportDataSource5.Value = this.Reporteria_ReciboColector5BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NeoCobranza.Paneles_Contrato.ReciboColector.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(882, 492);
            this.reportViewer1.TabIndex = 0;
            // 
            // data_ReciboOficial
            // 
            this.data_ReciboOficial.DataSetName = "Data_ReciboOficial";
            this.data_ReciboOficial.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteriaReciboColector1BindingSource
            // 
            this.reporteriaReciboColector1BindingSource.DataMember = "Reporteria_ReciboColector1";
            this.reporteriaReciboColector1BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // reporteria_ReciboColector1TableAdapter
            // 
            this.reporteria_ReciboColector1TableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaReciboColector2BindingSource
            // 
            this.reporteriaReciboColector2BindingSource.DataMember = "Reporteria_ReciboColector2";
            this.reporteriaReciboColector2BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // reporteria_ReciboColector2TableAdapter
            // 
            this.reporteria_ReciboColector2TableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaReciboColector3BindingSource
            // 
            this.reporteriaReciboColector3BindingSource.DataMember = "Reporteria_ReciboColector3";
            this.reporteriaReciboColector3BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // reporteria_ReciboColector3TableAdapter
            // 
            this.reporteria_ReciboColector3TableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaReciboColector4BindingSource
            // 
            this.reporteriaReciboColector4BindingSource.DataMember = "Reporteria_ReciboColector4";
            this.reporteriaReciboColector4BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // reporteria_ReciboColector4TableAdapter
            // 
            this.reporteria_ReciboColector4TableAdapter.ClearBeforeFill = true;
            // 
            // reporteriaReciboColector5BindingSource
            // 
            this.reporteriaReciboColector5BindingSource.DataMember = "Reporteria_ReciboColector5";
            this.reporteriaReciboColector5BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // reporteria_ReciboColector5TableAdapter
            // 
            this.reporteria_ReciboColector5TableAdapter.ClearBeforeFill = true;
            // 
            // Reporteria_ReciboColector1BindingSource
            // 
            this.Reporteria_ReciboColector1BindingSource.DataMember = "Reporteria_ReciboColector1";
            this.Reporteria_ReciboColector1BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // Reporteria_ReciboColector2BindingSource
            // 
            this.Reporteria_ReciboColector2BindingSource.DataMember = "Reporteria_ReciboColector2";
            this.Reporteria_ReciboColector2BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // Reporteria_ReciboColector3BindingSource
            // 
            this.Reporteria_ReciboColector3BindingSource.DataMember = "Reporteria_ReciboColector3";
            this.Reporteria_ReciboColector3BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // Reporteria_ReciboColector4BindingSource
            // 
            this.Reporteria_ReciboColector4BindingSource.DataMember = "Reporteria_ReciboColector4";
            this.Reporteria_ReciboColector4BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // Reporteria_ReciboColector5BindingSource
            // 
            this.Reporteria_ReciboColector5BindingSource.DataMember = "Reporteria_ReciboColector5";
            this.Reporteria_ReciboColector5BindingSource.DataSource = this.data_ReciboOficial;
            // 
            // PnlReciboColector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 492);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PnlReciboColector";
            this.Text = "PnlReciboColector";
            this.Load += new System.EventHandler(this.PnlReciboColector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_ReciboOficial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaReciboColector5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporteria_ReciboColector5BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Data_ReciboOficial data_ReciboOficial;
        private System.Windows.Forms.BindingSource reporteriaReciboColector1BindingSource;
        private Data_ReciboOficialTableAdapters.Reporteria_ReciboColector1TableAdapter reporteria_ReciboColector1TableAdapter;
        private System.Windows.Forms.BindingSource reporteriaReciboColector2BindingSource;
        private Data_ReciboOficialTableAdapters.Reporteria_ReciboColector2TableAdapter reporteria_ReciboColector2TableAdapter;
        private System.Windows.Forms.BindingSource reporteriaReciboColector3BindingSource;
        private Data_ReciboOficialTableAdapters.Reporteria_ReciboColector3TableAdapter reporteria_ReciboColector3TableAdapter;
        private System.Windows.Forms.BindingSource reporteriaReciboColector4BindingSource;
        private Data_ReciboOficialTableAdapters.Reporteria_ReciboColector4TableAdapter reporteria_ReciboColector4TableAdapter;
        private System.Windows.Forms.BindingSource Reporteria_ReciboColector1BindingSource;
        private System.Windows.Forms.BindingSource Reporteria_ReciboColector2BindingSource;
        private System.Windows.Forms.BindingSource Reporteria_ReciboColector3BindingSource;
        private System.Windows.Forms.BindingSource Reporteria_ReciboColector4BindingSource;
        private System.Windows.Forms.BindingSource Reporteria_ReciboColector5BindingSource;
        private System.Windows.Forms.BindingSource reporteriaReciboColector5BindingSource;
        private Data_ReciboOficialTableAdapters.Reporteria_ReciboColector5TableAdapter reporteria_ReciboColector5TableAdapter;
    }
}