namespace NeoCobranza.ViewGestionUsuario
{
    partial class PnlCMUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlCMUsuario));
            this.label1 = new System.Windows.Forms.Label();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.TxtUsuario = new NeoCobranza.Controladores.LoginUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new NeoCobranza.Controladores.LoginUserControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtApellido = new NeoCobranza.Controladores.LoginUserControl();
            this.CmbRol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtContraseñaConfirmar = new NeoCobranza.Controladores.LoginUserControl();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtContraseña = new NeoCobranza.Controladores.LoginUserControl();
            this.BtnCrearUsuario = new NeoCobranza.Especiales.EspecialButton();
            this.CHKMostrar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión de usuario";
            // 
            // especialButton1
            // 
            this.especialButton1.BackColor = System.Drawing.Color.Transparent;
            this.especialButton1.BackGroundColor = System.Drawing.Color.Transparent;
            this.especialButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("especialButton1.BackgroundImage")));
            this.especialButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton1.BorderRadius = 40;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.ForeColor = System.Drawing.Color.Transparent;
            this.especialButton1.Location = new System.Drawing.Point(755, 6);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(33, 33);
            this.especialButton1.TabIndex = 1;
            this.especialButton1.TextGroundColor = System.Drawing.Color.Transparent;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtUsuario.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtUsuario.BorderRadius = 15;
            this.TxtUsuario.BorderSize = 1;
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.Color.Black;
            this.TxtUsuario.Location = new System.Drawing.Point(54, 141);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.Multilinea = false;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtUsuario.PasswordChar = false;
            this.TxtUsuario.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtUsuario.PlaceHolderText = "Nombre de usuario ...";
            this.TxtUsuario.Size = new System.Drawing.Size(328, 39);
            this.TxtUsuario.TabIndex = 2;
            this.TxtUsuario.Texts = "";
            this.TxtUsuario.UnderLineFlat = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre de Usuario";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtNombre.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtNombre.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtNombre.BorderRadius = 15;
            this.TxtNombre.BorderSize = 1;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(54, 215);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNombre.Multilinea = false;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtNombre.PasswordChar = false;
            this.TxtNombre.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtNombre.PlaceHolderText = "Nombre ...";
            this.TxtNombre.Size = new System.Drawing.Size(328, 39);
            this.TxtNombre.TabIndex = 4;
            this.TxtNombre.Texts = "";
            this.TxtNombre.UnderLineFlat = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Primer Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Primer Apellido";
            // 
            // TxtApellido
            // 
            this.TxtApellido.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtApellido.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtApellido.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtApellido.BorderRadius = 15;
            this.TxtApellido.BorderSize = 1;
            this.TxtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApellido.ForeColor = System.Drawing.Color.Black;
            this.TxtApellido.Location = new System.Drawing.Point(54, 285);
            this.TxtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.TxtApellido.Multilinea = false;
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtApellido.PasswordChar = false;
            this.TxtApellido.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtApellido.PlaceHolderText = "Apellido ...";
            this.TxtApellido.Size = new System.Drawing.Size(328, 39);
            this.TxtApellido.TabIndex = 6;
            this.TxtApellido.Texts = "";
            this.TxtApellido.UnderLineFlat = false;
            // 
            // CmbRol
            // 
            this.CmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRol.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRol.FormattingEnabled = true;
            this.CmbRol.Location = new System.Drawing.Point(54, 357);
            this.CmbRol.Name = "CmbRol";
            this.CmbRol.Size = new System.Drawing.Size(328, 32);
            this.CmbRol.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rol del usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(135, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Información General";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(537, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nueva Contraseña";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(450, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Repita la Contraseña";
            // 
            // TxtContraseñaConfirmar
            // 
            this.TxtContraseñaConfirmar.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtContraseñaConfirmar.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtContraseñaConfirmar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtContraseñaConfirmar.BorderRadius = 15;
            this.TxtContraseñaConfirmar.BorderSize = 1;
            this.TxtContraseñaConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContraseñaConfirmar.ForeColor = System.Drawing.Color.Black;
            this.TxtContraseñaConfirmar.Location = new System.Drawing.Point(442, 215);
            this.TxtContraseñaConfirmar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtContraseñaConfirmar.Multilinea = false;
            this.TxtContraseñaConfirmar.Name = "TxtContraseñaConfirmar";
            this.TxtContraseñaConfirmar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtContraseñaConfirmar.PasswordChar = true;
            this.TxtContraseñaConfirmar.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtContraseñaConfirmar.PlaceHolderText = "";
            this.TxtContraseñaConfirmar.Size = new System.Drawing.Size(328, 39);
            this.TxtContraseñaConfirmar.TabIndex = 14;
            this.TxtContraseñaConfirmar.Texts = "";
            this.TxtContraseñaConfirmar.UnderLineFlat = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(450, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Digite la Contraseña";
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtContraseña.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtContraseña.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtContraseña.BorderRadius = 15;
            this.TxtContraseña.BorderSize = 1;
            this.TxtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContraseña.ForeColor = System.Drawing.Color.Black;
            this.TxtContraseña.Location = new System.Drawing.Point(442, 141);
            this.TxtContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.TxtContraseña.Multilinea = false;
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtContraseña.PasswordChar = true;
            this.TxtContraseña.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtContraseña.PlaceHolderText = "";
            this.TxtContraseña.Size = new System.Drawing.Size(328, 39);
            this.TxtContraseña.TabIndex = 12;
            this.TxtContraseña.Texts = "";
            this.TxtContraseña.UnderLineFlat = false;
            // 
            // BtnCrearUsuario
            // 
            this.BtnCrearUsuario.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCrearUsuario.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnCrearUsuario.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCrearUsuario.BorderRadius = 15;
            this.BtnCrearUsuario.BorderSize = 0;
            this.BtnCrearUsuario.FlatAppearance.BorderSize = 0;
            this.BtnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearUsuario.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.Location = new System.Drawing.Point(617, 398);
            this.BtnCrearUsuario.Name = "BtnCrearUsuario";
            this.BtnCrearUsuario.Size = new System.Drawing.Size(171, 40);
            this.BtnCrearUsuario.TabIndex = 50;
            this.BtnCrearUsuario.Text = "Guardar";
            this.BtnCrearUsuario.TextGroundColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.UseVisualStyleBackColor = false;
            this.BtnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            // 
            // CHKMostrar
            // 
            this.CHKMostrar.AutoSize = true;
            this.CHKMostrar.Location = new System.Drawing.Point(708, 263);
            this.CHKMostrar.Name = "CHKMostrar";
            this.CHKMostrar.Size = new System.Drawing.Size(61, 17);
            this.CHKMostrar.TabIndex = 51;
            this.CHKMostrar.Text = "Mostrar";
            this.CHKMostrar.UseVisualStyleBackColor = true;
            this.CHKMostrar.CheckedChanged += new System.EventHandler(this.CHKMostrar_CheckedChanged);
            // 
            // PnlCMUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CHKMostrar);
            this.Controls.Add(this.BtnCrearUsuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtContraseñaConfirmar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtContraseña);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbRol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCMUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlCMUsuario";
            this.Load += new System.EventHandler(this.PnlCMUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Especiales.EspecialButton especialButton1;
        private Controladores.LoginUserControl TxtUsuario;
        private System.Windows.Forms.Label label2;
        private Controladores.LoginUserControl TxtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controladores.LoginUserControl TxtApellido;
        private System.Windows.Forms.ComboBox CmbRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controladores.LoginUserControl TxtContraseñaConfirmar;
        private System.Windows.Forms.Label label9;
        private Controladores.LoginUserControl TxtContraseña;
        private Especiales.EspecialButton BtnCrearUsuario;
        private System.Windows.Forms.CheckBox CHKMostrar;
    }
}