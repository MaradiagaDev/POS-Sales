namespace NeoCobranza.Paneles
{
    partial class PnlTasaCambio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LBTasaActual = new System.Windows.Forms.Label();
            this.LBTasa = new System.Windows.Forms.Label();
            this.LBEstado = new System.Windows.Forms.Label();
            this.LBDinEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVTasas = new System.Windows.Forms.DataGridView();
            this.BtnAgregarArchivo = new NeoCobranza.Especiales.EspecialButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTasas)).BeginInit();
            this.SuspendLayout();
            // 
            // LBTasaActual
            // 
            this.LBTasaActual.AutoSize = true;
            this.LBTasaActual.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F);
            this.LBTasaActual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LBTasaActual.Location = new System.Drawing.Point(175, 19);
            this.LBTasaActual.Name = "LBTasaActual";
            this.LBTasaActual.Size = new System.Drawing.Size(21, 24);
            this.LBTasaActual.TabIndex = 67;
            this.LBTasaActual.Text = "0";
            // 
            // LBTasa
            // 
            this.LBTasa.AutoSize = true;
            this.LBTasa.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F);
            this.LBTasa.Location = new System.Drawing.Point(33, 19);
            this.LBTasa.Name = "LBTasa";
            this.LBTasa.Size = new System.Drawing.Size(133, 24);
            this.LBTasa.TabIndex = 66;
            this.LBTasa.Text = "Tasa ACTUAL:";
            // 
            // LBEstado
            // 
            this.LBEstado.AutoSize = true;
            this.LBEstado.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F);
            this.LBEstado.Location = new System.Drawing.Point(33, 73);
            this.LBEstado.Name = "LBEstado";
            this.LBEstado.Size = new System.Drawing.Size(74, 24);
            this.LBEstado.TabIndex = 80;
            this.LBEstado.Text = "Estado:";
            // 
            // LBDinEstado
            // 
            this.LBDinEstado.AutoSize = true;
            this.LBDinEstado.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F);
            this.LBDinEstado.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LBDinEstado.Location = new System.Drawing.Point(113, 73);
            this.LBDinEstado.Name = "LBDinEstado";
            this.LBDinEstado.Size = new System.Drawing.Size(14, 24);
            this.LBDinEstado.TabIndex = 81;
            this.LBDinEstado.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F);
            this.label1.Location = new System.Drawing.Point(585, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 24);
            this.label1.TabIndex = 82;
            this.label1.Text = "Listado de Tasas del Mes (BANCO CENTRAL ON LINE)";
            // 
            // DGVTasas
            // 
            this.DGVTasas.AllowUserToAddRows = false;
            this.DGVTasas.AllowUserToDeleteRows = false;
            this.DGVTasas.AllowUserToResizeRows = false;
            this.DGVTasas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTasas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVTasas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVTasas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTasas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVTasas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTasas.EnableHeadersVisualStyles = false;
            this.DGVTasas.Location = new System.Drawing.Point(591, 41);
            this.DGVTasas.MultiSelect = false;
            this.DGVTasas.Name = "DGVTasas";
            this.DGVTasas.ReadOnly = true;
            this.DGVTasas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVTasas.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DGVTasas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVTasas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTasas.Size = new System.Drawing.Size(471, 495);
            this.DGVTasas.TabIndex = 83;
            // 
            // BtnAgregarArchivo
            // 
            this.BtnAgregarArchivo.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAgregarArchivo.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnAgregarArchivo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAgregarArchivo.BorderRadius = 15;
            this.BtnAgregarArchivo.BorderSize = 0;
            this.BtnAgregarArchivo.FlatAppearance.BorderSize = 0;
            this.BtnAgregarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarArchivo.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarArchivo.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarArchivo.Location = new System.Drawing.Point(25, 129);
            this.BtnAgregarArchivo.Name = "BtnAgregarArchivo";
            this.BtnAgregarArchivo.Size = new System.Drawing.Size(267, 40);
            this.BtnAgregarArchivo.TabIndex = 78;
            this.BtnAgregarArchivo.Text = "Agregar Tasas del Mes";
            this.BtnAgregarArchivo.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarArchivo.UseVisualStyleBackColor = false;
            this.BtnAgregarArchivo.Click += new System.EventHandler(this.BtnAgregarArchivo_Click);
            // 
            // PnlTasaCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.DGVTasas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBDinEstado);
            this.Controls.Add(this.LBEstado);
            this.Controls.Add(this.BtnAgregarArchivo);
            this.Controls.Add(this.LBTasaActual);
            this.Controls.Add(this.LBTasa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlTasaCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlTasaCambio";
            this.Load += new System.EventHandler(this.PnlTasaCambio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTasas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBTasaActual;
        private System.Windows.Forms.Label LBTasa;
        private Especiales.EspecialButton BtnAgregarArchivo;
        private System.Windows.Forms.Label LBEstado;
        private System.Windows.Forms.Label LBDinEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVTasas;
    }
}