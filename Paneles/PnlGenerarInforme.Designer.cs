namespace NeoCobranza.Paneles
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
            this.DtInicial = new System.Windows.Forms.DateTimePicker();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.CmbSucursal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnConfirmar = new NeoCobranza.Especiales.EspecialButton();
            this.SuspendLayout();
            // 
            // DtInicial
            // 
            this.DtInicial.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtInicial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicial.Location = new System.Drawing.Point(12, 39);
            this.DtInicial.Name = "DtInicial";
            this.DtInicial.Size = new System.Drawing.Size(309, 27);
            this.DtInicial.TabIndex = 238;
            // 
            // DtFinal
            // 
            this.DtFinal.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFinal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(13, 110);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(309, 27);
            this.DtFinal.TabIndex = 237;
            // 
            // CmbSucursal
            // 
            this.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursal.FormattingEnabled = true;
            this.CmbSucursal.Location = new System.Drawing.Point(13, 181);
            this.CmbSucursal.Name = "CmbSucursal";
            this.CmbSucursal.Size = new System.Drawing.Size(311, 29);
            this.CmbSucursal.TabIndex = 236;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 22);
            this.label4.TabIndex = 235;
            this.label4.Text = "Sucursal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 22);
            this.label3.TabIndex = 234;
            this.label3.Text = "Fecha Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 233;
            this.label2.Text = "Fecha Inicial";
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnConfirmar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnConfirmar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnConfirmar.BorderRadius = 5;
            this.BtnConfirmar.BorderSize = 0;
            this.BtnConfirmar.FlatAppearance.BorderSize = 0;
            this.BtnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirmar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmar.ForeColor = System.Drawing.Color.White;
            this.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConfirmar.Location = new System.Drawing.Point(356, 172);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(129, 46);
            this.BtnConfirmar.TabIndex = 232;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.TextGroundColor = System.Drawing.Color.White;
            this.BtnConfirmar.UseVisualStyleBackColor = false;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // PnlGenerarInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 230);
            this.Controls.Add(this.DtInicial);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.CmbSucursal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnConfirmar);
            this.MaximumSize = new System.Drawing.Size(513, 269);
            this.MinimumSize = new System.Drawing.Size(513, 269);
            this.Name = "PnlGenerarInforme";
            this.Text = "Generar Informe";
            this.Load += new System.EventHandler(this.PnlGenerarInforme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Especiales.EspecialButton BtnConfirmar;
        private System.Windows.Forms.DateTimePicker DtInicial;
        private System.Windows.Forms.DateTimePicker DtFinal;
        public System.Windows.Forms.ComboBox CmbSucursal;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
    }
}