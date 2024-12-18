namespace NeoCobranza.Paneles_Venta
{
    partial class PnlVentasCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlVentasCredito));
            this.DtFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMontoCredito = new System.Windows.Forms.TextBox();
            this.TxtCantidadPagos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFrecuenciaPagos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnActualizarDescuento = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DtFechaPago
            // 
            this.DtFechaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFechaPago.Location = new System.Drawing.Point(12, 65);
            this.DtFechaPago.Name = "DtFechaPago";
            this.DtFechaPago.Size = new System.Drawing.Size(322, 22);
            this.DtFechaPago.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(12, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(199, 19);
            this.label17.TabIndex = 178;
            this.label17.Text = "Fecha del Próximo Pago";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 19);
            this.label1.TabIndex = 179;
            this.label1.Text = "Monto por Crédito (NIO):";
            // 
            // TxtMontoCredito
            // 
            this.TxtMontoCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMontoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoCredito.Location = new System.Drawing.Point(12, 295);
            this.TxtMontoCredito.Name = "TxtMontoCredito";
            this.TxtMontoCredito.Size = new System.Drawing.Size(322, 26);
            this.TxtMontoCredito.TabIndex = 180;
            this.TxtMontoCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoCredito_KeyPress);
            // 
            // TxtCantidadPagos
            // 
            this.TxtCantidadPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidadPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadPagos.Location = new System.Drawing.Point(12, 126);
            this.TxtCantidadPagos.Name = "TxtCantidadPagos";
            this.TxtCantidadPagos.Size = new System.Drawing.Size(322, 26);
            this.TxtCantidadPagos.TabIndex = 183;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 19);
            this.label2.TabIndex = 182;
            this.label2.Text = "Cantidad de Pagos:";
            // 
            // TxtFrecuenciaPagos
            // 
            this.TxtFrecuenciaPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFrecuenciaPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFrecuenciaPagos.Location = new System.Drawing.Point(12, 192);
            this.TxtFrecuenciaPagos.Name = "TxtFrecuenciaPagos";
            this.TxtFrecuenciaPagos.Size = new System.Drawing.Size(322, 26);
            this.TxtFrecuenciaPagos.TabIndex = 185;
            this.TxtFrecuenciaPagos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(8, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 19);
            this.label3.TabIndex = 184;
            this.label3.Text = "Frecuencia de Pagos:";
            // 
            // BtnActualizarDescuento
            // 
            this.BtnActualizarDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnActualizarDescuento.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnActualizarDescuento.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.BtnActualizarDescuento.BorderColor = System.Drawing.Color.Transparent;
            this.BtnActualizarDescuento.BorderRadius = 5;
            this.BtnActualizarDescuento.BorderSize = 2;
            this.BtnActualizarDescuento.FlatAppearance.BorderSize = 0;
            this.BtnActualizarDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizarDescuento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizarDescuento.ForeColor = System.Drawing.Color.White;
            this.BtnActualizarDescuento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizarDescuento.Location = new System.Drawing.Point(531, 327);
            this.BtnActualizarDescuento.Name = "BtnActualizarDescuento";
            this.BtnActualizarDescuento.Size = new System.Drawing.Size(141, 28);
            this.BtnActualizarDescuento.TabIndex = 186;
            this.BtnActualizarDescuento.Text = "Guardar";
            this.BtnActualizarDescuento.TextGroundColor = System.Drawing.Color.White;
            this.BtnActualizarDescuento.UseVisualStyleBackColor = false;
            this.BtnActualizarDescuento.Click += new System.EventHandler(this.BtnActualizarDescuento_Click);
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.especialButton1.BackColor = System.Drawing.Color.DarkRed;
            this.especialButton1.BackGroundColor = System.Drawing.Color.DarkRed;
            this.especialButton1.BorderColor = System.Drawing.Color.Transparent;
            this.especialButton1.BorderRadius = 5;
            this.especialButton1.BorderSize = 2;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.especialButton1.Location = new System.Drawing.Point(483, 12);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(189, 28);
            this.especialButton1.TabIndex = 187;
            this.especialButton1.Text = "Eliminar Crédito";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(399, 18);
            this.label4.TabIndex = 188;
            this.label4.Text = "*Datos Solo Informativos (No condicionan la orden)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(7, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 18);
            this.label5.TabIndex = 189;
            this.label5.Text = "*Se puede dejar en cero ";
            // 
            // PnlVentasCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 367);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.BtnActualizarDescuento);
            this.Controls.Add(this.TxtFrecuenciaPagos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtCantidadPagos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMontoCredito);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.DtFechaPago);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 406);
            this.MinimumSize = new System.Drawing.Size(700, 406);
            this.Name = "PnlVentasCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crédito-Venta";
            this.Load += new System.EventHandler(this.PnlVentasCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtFechaPago;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMontoCredito;
        private System.Windows.Forms.TextBox TxtCantidadPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFrecuenciaPagos;
        private System.Windows.Forms.Label label3;
        private Especiales.EspecialButton BtnActualizarDescuento;
        private Especiales.EspecialButton especialButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}