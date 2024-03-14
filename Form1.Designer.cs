namespace NeoCobranza
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.PnlImgLoginj = new System.Windows.Forms.Panel();
            this.ChkMostrarContra = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblTituloPrincipal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblContra = new System.Windows.Forms.Label();
            this.BtnSalir = new NeoCobranza.Especiales.EspecialButton();
            this.btnLogin = new NeoCobranza.Especiales.EspecialButton();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.LblTituloLogin = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // PnlImgLoginj
            // 
            this.PnlImgLoginj.BackColor = System.Drawing.Color.Transparent;
            this.PnlImgLoginj.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlImgLoginj.BackgroundImage")));
            this.PnlImgLoginj.Location = new System.Drawing.Point(10, 175);
            this.PnlImgLoginj.Name = "PnlImgLoginj";
            this.PnlImgLoginj.Size = new System.Drawing.Size(408, 104);
            this.PnlImgLoginj.TabIndex = 8;
            // 
            // ChkMostrarContra
            // 
            this.ChkMostrarContra.AutoSize = true;
            this.ChkMostrarContra.BackColor = System.Drawing.Color.Transparent;
            this.ChkMostrarContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMostrarContra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChkMostrarContra.Location = new System.Drawing.Point(230, 277);
            this.ChkMostrarContra.Name = "ChkMostrarContra";
            this.ChkMostrarContra.Size = new System.Drawing.Size(79, 22);
            this.ChkMostrarContra.TabIndex = 5;
            this.ChkMostrarContra.Text = "Mostrar";
            this.ChkMostrarContra.UseVisualStyleBackColor = false;
            this.ChkMostrarContra.CheckedChanged += new System.EventHandler(this.ChkMostrarContra_CheckedChanged);
            this.ChkMostrarContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChkMostrarContra_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.LblTituloPrincipal);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LblContra);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Controls.Add(this.ChkMostrarContra);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.LblUsuario);
            this.panel2.Controls.Add(this.TxtPass);
            this.panel2.Controls.Add(this.TxtUser);
            this.panel2.Location = new System.Drawing.Point(426, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 494);
            this.panel2.TabIndex = 9;
            // 
            // LblTituloPrincipal
            // 
            this.LblTituloPrincipal.AutoSize = true;
            this.LblTituloPrincipal.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloPrincipal.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblTituloPrincipal.Location = new System.Drawing.Point(60, 76);
            this.LblTituloPrincipal.Name = "LblTituloPrincipal";
            this.LblTituloPrincipal.Size = new System.Drawing.Size(252, 25);
            this.LblTituloPrincipal.TabIndex = 7;
            this.LblTituloPrincipal.Text = "Bienvenido a Cobranza";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Controls.Add(this.LblVersion);
            this.panel3.Location = new System.Drawing.Point(1, 470);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 23);
            this.panel3.TabIndex = 6;
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblVersion.Location = new System.Drawing.Point(16, 4);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(15, 16);
            this.LblVersion.TabIndex = 0;
            this.LblVersion.Text = "  ";
            this.LblVersion.Click += new System.EventHandler(this.LblVersion_Click);
            // 
            // LblContra
            // 
            this.LblContra.AutoSize = true;
            this.LblContra.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContra.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblContra.Location = new System.Drawing.Point(65, 213);
            this.LblContra.Name = "LblContra";
            this.LblContra.Size = new System.Drawing.Size(124, 22);
            this.LblContra.TabIndex = 3;
            this.LblContra.Text = "Contraseña:";
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSalir.BackGroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSalir.BorderColor = System.Drawing.Color.SlateGray;
            this.BtnSalir.BorderRadius = 10;
            this.BtnSalir.BorderSize = 0;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.SlateGray;
            this.BtnSalir.Location = new System.Drawing.Point(69, 360);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(234, 35);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.TextGroundColor = System.Drawing.Color.SlateGray;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.BackGroundColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(69, 319);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(234, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.TextGroundColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblUsuario.Location = new System.Drawing.Point(65, 141);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(80, 22);
            this.LblUsuario.TabIndex = 2;
            this.LblUsuario.Text = "Usuario:";
            // 
            // TxtPass
            // 
            this.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass.Location = new System.Drawing.Point(67, 244);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.PasswordChar = '●';
            this.TxtPass.Size = new System.Drawing.Size(236, 20);
            this.TxtPass.TabIndex = 1;
            this.TxtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPass_KeyPress);
            // 
            // TxtUser
            // 
            this.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUser.Location = new System.Drawing.Point(67, 171);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(236, 20);
            this.TxtUser.TabIndex = 0;
            this.TxtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUser_KeyPress);
            // 
            // LblTituloLogin
            // 
            this.LblTituloLogin.AutoSize = true;
            this.LblTituloLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloLogin.Location = new System.Drawing.Point(116, 326);
            this.LblTituloLogin.Name = "LblTituloLogin";
            this.LblTituloLogin.Size = new System.Drawing.Size(201, 19);
            this.LblTituloLogin.TabIndex = 10;
            this.LblTituloLogin.Text = "Programa Administrativo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(794, 521);
            this.Controls.Add(this.LblTituloLogin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnlImgLoginj);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Especiales.EspecialButton btnLogin;
        private Especiales.EspecialButton BtnSalir;
        private System.Windows.Forms.Panel PnlImgLoginj;
        private System.Windows.Forms.CheckBox ChkMostrarContra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblContra;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label LblTituloPrincipal;
        private System.Windows.Forms.Label LblTituloLogin;
    }
}

