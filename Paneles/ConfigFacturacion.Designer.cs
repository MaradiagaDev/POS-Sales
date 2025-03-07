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
            this.TxtFacturaCancelar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCancelarFactura = new NeoCobranza.Especiales.EspecialButton();
            this.BtnGuardarConfiguracion = new NeoCobranza.Especiales.EspecialButton();
            this.ChkRetieneIva = new System.Windows.Forms.CheckBox();
            this.CmbImpresoraTicke = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtImpresoraTicket = new System.Windows.Forms.TextBox();
            this.TxtImpresora = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbImpresora = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtConsecutivoFacturaCredito = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtSerieCredito = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Chk80mm = new System.Windows.Forms.CheckBox();
            this.Chk58mm = new System.Windows.Forms.CheckBox();
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
            this.TxtSerie.Location = new System.Drawing.Point(12, 80);
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
            this.label7.Location = new System.Drawing.Point(8, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 18);
            this.label7.TabIndex = 150;
            this.label7.Text = "Serie Actual:";
            // 
            // TxtConsecutivoFactura
            // 
            this.TxtConsecutivoFactura.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtConsecutivoFactura.Location = new System.Drawing.Point(12, 151);
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
            this.label1.Location = new System.Drawing.Point(8, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 153;
            this.label1.Text = "Consecutivo Factura";
            // 
            // TxtConsecutivoOrden
            // 
            this.TxtConsecutivoOrden.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtConsecutivoOrden.Location = new System.Drawing.Point(12, 224);
            this.TxtConsecutivoOrden.Name = "TxtConsecutivoOrden";
            this.TxtConsecutivoOrden.Size = new System.Drawing.Size(133, 23);
            this.TxtConsecutivoOrden.TabIndex = 158;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(8, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 18);
            this.label4.TabIndex = 159;
            this.label4.Text = "Consecutivo Orden";
            // 
            // TxtFacturaCancelar
            // 
            this.TxtFacturaCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtFacturaCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtFacturaCancelar.Location = new System.Drawing.Point(474, 32);
            this.TxtFacturaCancelar.Name = "TxtFacturaCancelar";
            this.TxtFacturaCancelar.Size = new System.Drawing.Size(133, 23);
            this.TxtFacturaCancelar.TabIndex = 164;
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
            // BtnCancelarFactura
            // 
            this.BtnCancelarFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCancelarFactura.BackColor = System.Drawing.Color.Maroon;
            this.BtnCancelarFactura.BackGroundColor = System.Drawing.Color.Maroon;
            this.BtnCancelarFactura.BorderColor = System.Drawing.Color.Lime;
            this.BtnCancelarFactura.BorderRadius = 5;
            this.BtnCancelarFactura.BorderSize = 0;
            this.BtnCancelarFactura.FlatAppearance.BorderSize = 0;
            this.BtnCancelarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelarFactura.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnCancelarFactura.ForeColor = System.Drawing.Color.White;
            this.BtnCancelarFactura.Location = new System.Drawing.Point(656, 21);
            this.BtnCancelarFactura.Name = "BtnCancelarFactura";
            this.BtnCancelarFactura.Size = new System.Drawing.Size(199, 35);
            this.BtnCancelarFactura.TabIndex = 166;
            this.BtnCancelarFactura.Text = "Cancelar Factura";
            this.BtnCancelarFactura.TextGroundColor = System.Drawing.Color.White;
            this.BtnCancelarFactura.UseVisualStyleBackColor = false;
            this.BtnCancelarFactura.Click += new System.EventHandler(this.BtnCancelarFactura_Click);
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
            this.ChkRetieneIva.Location = new System.Drawing.Point(700, 316);
            this.ChkRetieneIva.Name = "ChkRetieneIva";
            this.ChkRetieneIva.Size = new System.Drawing.Size(117, 20);
            this.ChkRetieneIva.TabIndex = 167;
            this.ChkRetieneIva.Text = "Recauda IVA";
            this.ChkRetieneIva.UseVisualStyleBackColor = true;
            // 
            // CmbImpresoraTicke
            // 
            this.CmbImpresoraTicke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbImpresoraTicke.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbImpresoraTicke.FormattingEnabled = true;
            this.CmbImpresoraTicke.Location = new System.Drawing.Point(11, 316);
            this.CmbImpresoraTicke.Name = "CmbImpresoraTicke";
            this.CmbImpresoraTicke.Size = new System.Drawing.Size(248, 25);
            this.CmbImpresoraTicke.TabIndex = 168;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(8, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 169;
            this.label2.Text = "Impresora Tickets";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(279, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 18);
            this.label5.TabIndex = 170;
            this.label5.Text = "Impresora Seleccionada";
            // 
            // TxtImpresoraTicket
            // 
            this.TxtImpresoraTicket.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtImpresoraTicket.Location = new System.Drawing.Point(281, 318);
            this.TxtImpresoraTicket.Name = "TxtImpresoraTicket";
            this.TxtImpresoraTicket.ReadOnly = true;
            this.TxtImpresoraTicket.Size = new System.Drawing.Size(314, 23);
            this.TxtImpresoraTicket.TabIndex = 171;
            // 
            // TxtImpresora
            // 
            this.TxtImpresora.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtImpresora.Location = new System.Drawing.Point(281, 386);
            this.TxtImpresora.Name = "TxtImpresora";
            this.TxtImpresora.ReadOnly = true;
            this.TxtImpresora.Size = new System.Drawing.Size(314, 23);
            this.TxtImpresora.TabIndex = 175;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(279, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 18);
            this.label8.TabIndex = 174;
            this.label8.Text = "Impresora Seleccionada";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(8, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 18);
            this.label9.TabIndex = 173;
            this.label9.Text = "Impresora A4";
            // 
            // CmbImpresora
            // 
            this.CmbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbImpresora.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbImpresora.FormattingEnabled = true;
            this.CmbImpresora.Location = new System.Drawing.Point(11, 384);
            this.CmbImpresora.Name = "CmbImpresora";
            this.CmbImpresora.Size = new System.Drawing.Size(248, 25);
            this.CmbImpresora.TabIndex = 172;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(8, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 18);
            this.label10.TabIndex = 176;
            this.label10.Text = "Contado";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(238, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 18);
            this.label11.TabIndex = 183;
            this.label11.Text = "Crédito";
            // 
            // TxtConsecutivoFacturaCredito
            // 
            this.TxtConsecutivoFacturaCredito.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtConsecutivoFacturaCredito.Location = new System.Drawing.Point(242, 151);
            this.TxtConsecutivoFacturaCredito.Name = "TxtConsecutivoFacturaCredito";
            this.TxtConsecutivoFacturaCredito.Size = new System.Drawing.Size(133, 23);
            this.TxtConsecutivoFacturaCredito.TabIndex = 179;
            this.TxtConsecutivoFacturaCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConsecutivoFacturaCredito_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(238, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(159, 18);
            this.label13.TabIndex = 180;
            this.label13.Text = "Consecutivo Factura";
            // 
            // TxtSerieCredito
            // 
            this.TxtSerieCredito.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtSerieCredito.Location = new System.Drawing.Point(242, 80);
            this.TxtSerieCredito.MaxLength = 5;
            this.TxtSerieCredito.Name = "TxtSerieCredito";
            this.TxtSerieCredito.Size = new System.Drawing.Size(133, 23);
            this.TxtSerieCredito.TabIndex = 177;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(238, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 18);
            this.label14.TabIndex = 178;
            this.label14.Text = "Serie Actual:";
            // 
            // Chk80mm
            // 
            this.Chk80mm.AutoSize = true;
            this.Chk80mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk80mm.Location = new System.Drawing.Point(700, 126);
            this.Chk80mm.Name = "Chk80mm";
            this.Chk80mm.Size = new System.Drawing.Size(126, 20);
            this.Chk80mm.TabIndex = 184;
            this.Chk80mm.Text = "Factura 80 mm";
            this.Chk80mm.UseVisualStyleBackColor = true;
            this.Chk80mm.CheckedChanged += new System.EventHandler(this.Chk80mm_CheckedChanged);
            // 
            // Chk58mm
            // 
            this.Chk58mm.AutoSize = true;
            this.Chk58mm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk58mm.Location = new System.Drawing.Point(700, 154);
            this.Chk58mm.Name = "Chk58mm";
            this.Chk58mm.Size = new System.Drawing.Size(126, 20);
            this.Chk58mm.TabIndex = 185;
            this.Chk58mm.Text = "Factura 58 mm";
            this.Chk58mm.UseVisualStyleBackColor = true;
            this.Chk58mm.CheckedChanged += new System.EventHandler(this.Chk58mm_CheckedChanged);
            // 
            // ConfigFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.Chk58mm);
            this.Controls.Add(this.Chk80mm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtConsecutivoFacturaCredito);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TxtSerieCredito);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtImpresora);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbImpresora);
            this.Controls.Add(this.TxtImpresoraTicket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbImpresoraTicke);
            this.Controls.Add(this.ChkRetieneIva);
            this.Controls.Add(this.BtnCancelarFactura);
            this.Controls.Add(this.TxtFacturaCancelar);
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
        public Especiales.EspecialButton BtnCancelarFactura;
        public System.Windows.Forms.TextBox TxtFacturaCancelar;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkRetieneIva;
        private System.Windows.Forms.ComboBox CmbImpresoraTicke;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TxtImpresoraTicket;
        public System.Windows.Forms.TextBox TxtImpresora;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbImpresora;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox TxtConsecutivoFacturaCredito;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox TxtSerieCredito;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox Chk80mm;
        private System.Windows.Forms.CheckBox Chk58mm;
    }
}