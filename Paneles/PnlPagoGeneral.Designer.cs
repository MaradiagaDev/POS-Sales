namespace NeoCobranza.Paneles
{
    partial class PnlPagoGeneral
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
            this.BtnPagarOrdenes = new NeoCobranza.Especiales.EspecialButton();
            this.ChkTarjeta = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbBanco = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnPagarOrdenes
            // 
            this.BtnPagarOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPagarOrdenes.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnPagarOrdenes.BackGroundColor = System.Drawing.Color.DarkGreen;
            this.BtnPagarOrdenes.BorderColor = System.Drawing.Color.Transparent;
            this.BtnPagarOrdenes.BorderRadius = 0;
            this.BtnPagarOrdenes.BorderSize = 0;
            this.BtnPagarOrdenes.FlatAppearance.BorderSize = 0;
            this.BtnPagarOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPagarOrdenes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagarOrdenes.ForeColor = System.Drawing.Color.White;
            this.BtnPagarOrdenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPagarOrdenes.Location = new System.Drawing.Point(15, 260);
            this.BtnPagarOrdenes.Name = "BtnPagarOrdenes";
            this.BtnPagarOrdenes.Size = new System.Drawing.Size(474, 49);
            this.BtnPagarOrdenes.TabIndex = 203;
            this.BtnPagarOrdenes.Text = "PAGAR ORDENES";
            this.BtnPagarOrdenes.TextGroundColor = System.Drawing.Color.White;
            this.BtnPagarOrdenes.UseVisualStyleBackColor = false;
            this.BtnPagarOrdenes.Click += new System.EventHandler(this.BtnPagarOrdenes_Click);
            // 
            // ChkTarjeta
            // 
            this.ChkTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkTarjeta.AutoSize = true;
            this.ChkTarjeta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkTarjeta.Location = new System.Drawing.Point(16, 83);
            this.ChkTarjeta.Name = "ChkTarjeta";
            this.ChkTarjeta.Size = new System.Drawing.Size(182, 22);
            this.ChkTarjeta.TabIndex = 202;
            this.ChkTarjeta.Text = "Pago Tarjeta - Minuta";
            this.ChkTarjeta.UseVisualStyleBackColor = true;
            this.ChkTarjeta.Click += new System.EventHandler(this.ChkTarjeta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(208, 29);
            this.label1.TabIndex = 201;
            this.label1.Text = "Pago General de Ventas";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(11, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 19);
            this.label5.TabIndex = 200;
            this.label5.Text = "Cuentas Banco";
            // 
            // CmbBanco
            // 
            this.CmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBanco.Enabled = false;
            this.CmbBanco.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBanco.FormattingEnabled = true;
            this.CmbBanco.Location = new System.Drawing.Point(14, 148);
            this.CmbBanco.Name = "CmbBanco";
            this.CmbBanco.Size = new System.Drawing.Size(476, 31);
            this.CmbBanco.TabIndex = 199;
            // 
            // PnlPagoGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 322);
            this.Controls.Add(this.BtnPagarOrdenes);
            this.Controls.Add(this.ChkTarjeta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbBanco);
            this.Name = "PnlPagoGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago General";
            this.Load += new System.EventHandler(this.PnlPagoGeneral_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Especiales.EspecialButton BtnPagarOrdenes;
        private System.Windows.Forms.CheckBox ChkTarjeta;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbBanco;
    }
}