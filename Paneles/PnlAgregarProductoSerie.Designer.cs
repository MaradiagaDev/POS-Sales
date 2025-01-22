namespace NeoCobranza.Paneles
{
    partial class PnlAgregarProductoSerie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgregarProductoSerie));
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblDinamico = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.TxtRazon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtIdentificador = new System.Windows.Forms.TextBox();
            this.LblIdentificadorAjuste = new System.Windows.Forms.Label();
            this.BtnGuardar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbTipoAjuste = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.LblDinamico);
            this.panel3.Location = new System.Drawing.Point(-2, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1165, 33);
            this.panel3.TabIndex = 96;
            // 
            // LblDinamico
            // 
            this.LblDinamico.AutoSize = true;
            this.LblDinamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDinamico.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblDinamico.Location = new System.Drawing.Point(22, 9);
            this.LblDinamico.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.LblDinamico.Name = "LblDinamico";
            this.LblDinamico.Size = new System.Drawing.Size(155, 18);
            this.LblDinamico.TabIndex = 1;
            this.LblDinamico.Text = "Merma de Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(-162, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 159;
            this.label1.Text = "Cantidad:";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtCantidad.Location = new System.Drawing.Point(27, 255);
            this.TxtCantidad.MaxLength = 100;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(226, 23);
            this.TxtCantidad.TabIndex = 158;
            // 
            // TxtRazon
            // 
            this.TxtRazon.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtRazon.Location = new System.Drawing.Point(26, 156);
            this.TxtRazon.MaxLength = 100;
            this.TxtRazon.Multiline = true;
            this.TxtRazon.Name = "TxtRazon";
            this.TxtRazon.Size = new System.Drawing.Size(943, 54);
            this.TxtRazon.TabIndex = 156;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(-162, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 157;
            this.label4.Text = "Razón:";
            // 
            // TxtIdentificador
            // 
            this.TxtIdentificador.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtIdentificador.Location = new System.Drawing.Point(23, 85);
            this.TxtIdentificador.MaxLength = 100;
            this.TxtIdentificador.Name = "TxtIdentificador";
            this.TxtIdentificador.Size = new System.Drawing.Size(946, 23);
            this.TxtIdentificador.TabIndex = 155;
            // 
            // LblIdentificadorAjuste
            // 
            this.LblIdentificadorAjuste.AutoSize = true;
            this.LblIdentificadorAjuste.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblIdentificadorAjuste.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblIdentificadorAjuste.Location = new System.Drawing.Point(21, 50);
            this.LblIdentificadorAjuste.Name = "LblIdentificadorAjuste";
            this.LblIdentificadorAjuste.Size = new System.Drawing.Size(279, 18);
            this.LblIdentificadorAjuste.TabIndex = 154;
            this.LblIdentificadorAjuste.Text = "Nombre o Identificador del Ajuste (*)";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardar.BorderColor = System.Drawing.Color.Lime;
            this.BtnGuardar.BorderRadius = 5;
            this.BtnGuardar.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(796, 325);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(173, 35);
            this.BtnGuardar.TabIndex = 152;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 5;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(613, 325);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 35);
            this.btnCancelar.TabIndex = 153;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(24, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 160;
            this.label2.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(24, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 161;
            this.label3.Text = "Cantidad: (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(24, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 162;
            this.label5.Text = "Tipo Ajuste: (*)";
            // 
            // CmbTipoAjuste
            // 
            this.CmbTipoAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoAjuste.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbTipoAjuste.FormattingEnabled = true;
            this.CmbTipoAjuste.Items.AddRange(new object[] {
            "Disminuir",
            "Aumentar"});
            this.CmbTipoAjuste.Location = new System.Drawing.Point(26, 329);
            this.CmbTipoAjuste.Name = "CmbTipoAjuste";
            this.CmbTipoAjuste.Size = new System.Drawing.Size(227, 25);
            this.CmbTipoAjuste.TabIndex = 163;
            // 
            // PnlAgregarProductoSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(990, 372);
            this.Controls.Add(this.CmbTipoAjuste);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.TxtRazon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtIdentificador);
            this.Controls.Add(this.LblIdentificadorAjuste);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1006, 411);
            this.MinimumSize = new System.Drawing.Size(1006, 411);
            this.Name = "PnlAgregarProductoSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merma de Producto";
            this.Load += new System.EventHandler(this.PnlAgregarProductoSerie_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label LblDinamico;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtCantidad;
        public System.Windows.Forms.TextBox TxtRazon;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtIdentificador;
        public System.Windows.Forms.Label LblIdentificadorAjuste;
        public Especiales.EspecialButton BtnGuardar;
        public Especiales.EspecialButton btnCancelar;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbTipoAjuste;
    }
}