namespace NeoCobranza.Paneles
{
    partial class ConfigFacturacion
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
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSerie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtConsecutivoFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtConsecutivoOrden = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.especialButton5 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnGuardarConfiguracion = new NeoCobranza.Especiales.EspecialButton();
            this.ChkRetieneIva = new System.Windows.Forms.CheckBox();
            this.PnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-1, 479);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1127, 44);
            this.PnlTitulo.TabIndex = 135;
            // 
            // TbTitulo
            // 
            this.TbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbTitulo.AutoSize = true;
            this.TbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbTitulo.Location = new System.Drawing.Point(12, 3);
            this.TbTitulo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TbTitulo.Name = "TbTitulo";
            this.TbTitulo.Size = new System.Drawing.Size(415, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Configuración de Facturación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(12, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 16);
            this.label3.TabIndex = 148;
            this.label3.Text = "Esta configuración es individual por sucursal.";
            // 
            // TxtSerie
            // 
            this.TxtSerie.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtSerie.Location = new System.Drawing.Point(12, 32);
            this.TxtSerie.MaxLength = 5;
            this.TxtSerie.Name = "TxtSerie";
            this.TxtSerie.Size = new System.Drawing.Size(133, 23);
            this.TxtSerie.TabIndex = 149;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(8, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 18);
            this.label7.TabIndex = 150;
            this.label7.Text = "Serie Actual:";
            // 
            // TxtConsecutivoFactura
            // 
            this.TxtConsecutivoFactura.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtConsecutivoFactura.Location = new System.Drawing.Point(12, 111);
            this.TxtConsecutivoFactura.Name = "TxtConsecutivoFactura";
            this.TxtConsecutivoFactura.Size = new System.Drawing.Size(133, 23);
            this.TxtConsecutivoFactura.TabIndex = 152;
            this.TxtConsecutivoFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConsecutivoFactura_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(8, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 153;
            this.label1.Text = "Consecutivo Factura";
            // 
            // TxtConsecutivoOrden
            // 
            this.TxtConsecutivoOrden.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtConsecutivoOrden.Location = new System.Drawing.Point(12, 184);
            this.TxtConsecutivoOrden.Name = "TxtConsecutivoOrden";
            this.TxtConsecutivoOrden.Size = new System.Drawing.Size(133, 23);
            this.TxtConsecutivoOrden.TabIndex = 158;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(8, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 18);
            this.label4.TabIndex = 159;
            this.label4.Text = "Consecutivo Orden";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBox5.Location = new System.Drawing.Point(474, 32);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(133, 23);
            this.textBox5.TabIndex = 164;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(470, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 18);
            this.label6.TabIndex = 165;
            this.label6.Text = "Cancelar Factura:";
            // 
            // especialButton5
            // 
            this.especialButton5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.especialButton5.BackColor = System.Drawing.Color.Maroon;
            this.especialButton5.BackGroundColor = System.Drawing.Color.Maroon;
            this.especialButton5.BorderColor = System.Drawing.Color.Lime;
            this.especialButton5.BorderRadius = 5;
            this.especialButton5.BorderSize = 0;
            this.especialButton5.FlatAppearance.BorderSize = 0;
            this.especialButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.especialButton5.ForeColor = System.Drawing.Color.White;
            this.especialButton5.Location = new System.Drawing.Point(656, 21);
            this.especialButton5.Name = "especialButton5";
            this.especialButton5.Size = new System.Drawing.Size(199, 35);
            this.especialButton5.TabIndex = 166;
            this.especialButton5.Text = "Cancelar Factura";
            this.especialButton5.TextGroundColor = System.Drawing.Color.White;
            this.especialButton5.UseVisualStyleBackColor = false;
            // 
            // BtnGuardarConfiguracion
            // 
            this.BtnGuardarConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardarConfiguracion.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardarConfiguracion.BorderColor = System.Drawing.Color.Lime;
            this.BtnGuardarConfiguracion.BorderRadius = 5;
            this.BtnGuardarConfiguracion.BorderSize = 0;
            this.BtnGuardarConfiguracion.FlatAppearance.BorderSize = 0;
            this.BtnGuardarConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarConfiguracion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnGuardarConfiguracion.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarConfiguracion.Location = new System.Drawing.Point(905, 429);
            this.BtnGuardarConfiguracion.Name = "BtnGuardarConfiguracion";
            this.BtnGuardarConfiguracion.Size = new System.Drawing.Size(199, 35);
            this.BtnGuardarConfiguracion.TabIndex = 163;
            this.BtnGuardarConfiguracion.Text = "Guardar Configuración";
            this.BtnGuardarConfiguracion.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardarConfiguracion.UseVisualStyleBackColor = false;
            this.BtnGuardarConfiguracion.Click += new System.EventHandler(this.BtnGuardarConfiguracion_Click);
            // 
            // ChkRetieneIva
            // 
            this.ChkRetieneIva.AutoSize = true;
            this.ChkRetieneIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRetieneIva.Location = new System.Drawing.Point(11, 233);
            this.ChkRetieneIva.Name = "ChkRetieneIva";
            this.ChkRetieneIva.Size = new System.Drawing.Size(117, 20);
            this.ChkRetieneIva.TabIndex = 167;
            this.ChkRetieneIva.Text = "Recauda IVA";
            this.ChkRetieneIva.UseVisualStyleBackColor = true;
            // 
            // ConfigFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.ChkRetieneIva);
            this.Controls.Add(this.especialButton5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnGuardarConfiguracion);
            this.Controls.Add(this.TxtConsecutivoOrden);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtConsecutivoFactura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSerie);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigFacturacion";
            this.Text = "ConfigFacturacion";
            this.Load += new System.EventHandler(this.ConfigFacturacion_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TxtSerie;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TxtConsecutivoFactura;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtConsecutivoOrden;
        public System.Windows.Forms.Label label4;
        public Especiales.EspecialButton BtnGuardarConfiguracion;
        public Especiales.EspecialButton especialButton5;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkRetieneIva;
    }
}