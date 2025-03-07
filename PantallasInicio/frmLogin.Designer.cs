namespace NeoCobranza
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.ChkMostrarContra = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblContra = new System.Windows.Forms.Label();
            this.BtnSalir = new NeoCobranza.Especiales.EspecialButton();
            this.btnLogin = new NeoCobranza.Especiales.EspecialButton();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.PnlCentral = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ChkMostrarContra
            // 
            this.ChkMostrarContra.AutoSize = true;
            this.ChkMostrarContra.BackColor = System.Drawing.Color.Transparent;
            this.ChkMostrarContra.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMostrarContra.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ChkMostrarContra.Location = new System.Drawing.Point(248, 351);
            this.ChkMostrarContra.Name = "ChkMostrarContra";
            this.ChkMostrarContra.Size = new System.Drawing.Size(81, 22);
            this.ChkMostrarContra.TabIndex = 5;
            this.ChkMostrarContra.Text = "Mostrar";
            this.ChkMostrarContra.UseVisualStyleBackColor = false;
            this.ChkMostrarContra.CheckedChanged += new System.EventHandler(this.ChkMostrarContra_CheckedChanged);
            this.ChkMostrarContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChkMostrarContra_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(19, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "SYSADMIN - DM SOLUCIONES";
            // 
            // LblContra
            // 
            this.LblContra.AutoSize = true;
            this.LblContra.BackColor = System.Drawing.Color.Transparent;
            this.LblContra.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContra.ForeColor = System.Drawing.Color.Black;
            this.LblContra.Location = new System.Drawing.Point(20, 275);
            this.LblContra.Name = "LblContra";
            this.LblContra.Size = new System.Drawing.Size(119, 22);
            this.LblContra.TabIndex = 3;
            this.LblContra.Text = "Contraseña";
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSalir.BackGroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSalir.BorderColor = System.Drawing.Color.Black;
            this.BtnSalir.BorderRadius = 0;
            this.BtnSalir.BorderSize = 2;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnSalir.Location = new System.Drawing.Point(24, 450);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(305, 49);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.TextGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Green;
            this.btnLogin.BackGroundColor = System.Drawing.Color.Green;
            this.btnLogin.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnLogin.BorderRadius = 0;
            this.btnLogin.BorderSize = 2;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(24, 392);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(305, 49);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.TextGroundColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LblUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.ForeColor = System.Drawing.Color.Black;
            this.LblUsuario.Location = new System.Drawing.Point(20, 198);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(75, 22);
            this.LblUsuario.TabIndex = 2;
            this.LblUsuario.Text = "Usuario";
            // 
            // TxtPass
            // 
            this.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass.Location = new System.Drawing.Point(24, 303);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.PasswordChar = '●';
            this.TxtPass.Size = new System.Drawing.Size(305, 27);
            this.TxtPass.TabIndex = 1;
            this.TxtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPass_KeyPress);
            // 
            // TxtUser
            // 
            this.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUser.Location = new System.Drawing.Point(24, 226);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(305, 27);
            this.TxtUser.TabIndex = 0;
            this.TxtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUser_KeyPress);
            // 
            // PnlCentral
            // 
            this.PnlCentral.BackColor = System.Drawing.Color.Transparent;
            this.PnlCentral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlCentral.BackgroundImage")));
            this.PnlCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlCentral.Location = new System.Drawing.Point(106, 12);
            this.PnlCentral.Name = "PnlCentral";
            this.PnlCentral.Size = new System.Drawing.Size(131, 119);
            this.PnlCentral.TabIndex = 12;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 511);
            this.Controls.Add(this.LblContra);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PnlCentral);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkMostrarContra);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.TxtUser);
            this.Controls.Add(this.TxtPass);
            this.Controls.Add(this.btnLogin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Especiales.EspecialButton btnLogin;
        private Especiales.EspecialButton BtnSalir;
        private System.Windows.Forms.CheckBox ChkMostrarContra;
        private System.Windows.Forms.Label LblContra;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.TextBox TxtUser;
        public System.Windows.Forms.Panel PnlCentral;
        private System.Windows.Forms.Label label2;
    }
}

