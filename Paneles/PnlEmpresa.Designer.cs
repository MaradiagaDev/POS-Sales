namespace NeoCobranza.Paneles
{
    partial class PnlEmpresa
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
            this.BtnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.LblNombreDinamico = new System.Windows.Forms.Label();
            this.TxtNombreComercial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNoRuc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-10, 480);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1144, 44);
            this.PnlTitulo.TabIndex = 152;
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
            this.TbTitulo.Size = new System.Drawing.Size(287, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Datos de la Empresa";
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnActualizar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnActualizar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnActualizar.BorderRadius = 5;
            this.BtnActualizar.BorderSize = 0;
            this.BtnActualizar.FlatAppearance.BorderSize = 0;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BtnActualizar.ForeColor = System.Drawing.Color.White;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.Location = new System.Drawing.Point(940, 431);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(173, 38);
            this.BtnActualizar.TabIndex = 156;
            this.BtnActualizar.Text = "Guardar";
            this.BtnActualizar.TextGroundColor = System.Drawing.Color.White;
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // TxtNombreEmpresa
            // 
            this.TxtNombreEmpresa.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNombreEmpresa.Location = new System.Drawing.Point(12, 39);
            this.TxtNombreEmpresa.MaxLength = 100;
            this.TxtNombreEmpresa.Name = "TxtNombreEmpresa";
            this.TxtNombreEmpresa.Size = new System.Drawing.Size(412, 23);
            this.TxtNombreEmpresa.TabIndex = 157;
            // 
            // LblNombreDinamico
            // 
            this.LblNombreDinamico.AutoSize = true;
            this.LblNombreDinamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblNombreDinamico.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblNombreDinamico.Location = new System.Drawing.Point(8, 13);
            this.LblNombreDinamico.Name = "LblNombreDinamico";
            this.LblNombreDinamico.Size = new System.Drawing.Size(177, 18);
            this.LblNombreDinamico.TabIndex = 158;
            this.LblNombreDinamico.Text = "Nombre de la Empresa";
            // 
            // TxtNombreComercial
            // 
            this.TxtNombreComercial.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNombreComercial.Location = new System.Drawing.Point(12, 101);
            this.TxtNombreComercial.MaxLength = 100;
            this.TxtNombreComercial.Name = "TxtNombreComercial";
            this.TxtNombreComercial.Size = new System.Drawing.Size(412, 23);
            this.TxtNombreComercial.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(8, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 160;
            this.label1.Text = "Nombre Comercial";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtTelefono.Location = new System.Drawing.Point(12, 158);
            this.TxtTelefono.MaxLength = 100;
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(226, 23);
            this.TxtTelefono.TabIndex = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(8, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 162;
            this.label2.Text = "Telefono";
            // 
            // TxtNoRuc
            // 
            this.TxtNoRuc.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNoRuc.Location = new System.Drawing.Point(12, 224);
            this.TxtNoRuc.MaxLength = 100;
            this.TxtNoRuc.Name = "TxtNoRuc";
            this.TxtNoRuc.Size = new System.Drawing.Size(226, 23);
            this.TxtNoRuc.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(8, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 164;
            this.label3.Text = "RUC";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtEmail.Location = new System.Drawing.Point(12, 284);
            this.TxtEmail.MaxLength = 100;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(226, 23);
            this.TxtEmail.TabIndex = 165;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(8, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 166;
            this.label4.Text = "Email";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtDireccion.Location = new System.Drawing.Point(12, 344);
            this.TxtDireccion.MaxLength = 100;
            this.TxtDireccion.Multiline = true;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(412, 85);
            this.TxtDireccion.TabIndex = 167;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(8, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 168;
            this.label5.Text = "Dirección";
            // 
            // PnlEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNoRuc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNombreComercial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNombreEmpresa);
            this.Controls.Add(this.LblNombreDinamico);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlEmpresa";
            this.Text = "PnlEmpresa";
            this.Load += new System.EventHandler(this.PnlEmpresa_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public Especiales.EspecialButton BtnActualizar;
        public System.Windows.Forms.TextBox TxtNombreEmpresa;
        public System.Windows.Forms.Label LblNombreDinamico;
        public System.Windows.Forms.TextBox TxtNombreComercial;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtTelefono;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TxtNoRuc;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TxtEmail;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtDireccion;
        public System.Windows.Forms.Label label5;
    }
}