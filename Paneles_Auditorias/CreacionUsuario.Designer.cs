namespace NeoCobranza.Paneles_Auditorias
{
    partial class CreacionUsuario
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCrearUsuario = new NeoCobranza.Especiales.EspecialButton();
            this.txtContra = new NeoCobranza.Controladores.LoginUserControl();
            this.txtUsuario = new NeoCobranza.Controladores.LoginUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmar = new NeoCobranza.Controladores.LoginUserControl();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1158, 31);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Creacion de Usuarios";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(447, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "Digite el nuevo nombre del usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(447, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "Digite la nueva contraseña:";
            // 
            // BtnCrearUsuario
            // 
            this.BtnCrearUsuario.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnCrearUsuario.BackGroundColor = System.Drawing.Color.RoyalBlue;
            this.BtnCrearUsuario.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCrearUsuario.BorderRadius = 40;
            this.BtnCrearUsuario.BorderSize = 0;
            this.BtnCrearUsuario.FlatAppearance.BorderSize = 0;
            this.BtnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.Location = new System.Drawing.Point(450, 518);
            this.BtnCrearUsuario.Name = "BtnCrearUsuario";
            this.BtnCrearUsuario.Size = new System.Drawing.Size(241, 40);
            this.BtnCrearUsuario.TabIndex = 9;
            this.BtnCrearUsuario.Text = "CrearUsuario";
            this.BtnCrearUsuario.TextGroundColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.UseVisualStyleBackColor = false;
            this.BtnCrearUsuario.UseWaitCursor = true;
            this.BtnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            // 
            // txtContra
            // 
            this.txtContra.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtContra.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtContra.BorderRadius = 0;
            this.txtContra.BorderSize = 2;
            this.txtContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.ForeColor = System.Drawing.Color.DimGray;
            this.txtContra.Location = new System.Drawing.Point(450, 208);
            this.txtContra.Margin = new System.Windows.Forms.Padding(4);
            this.txtContra.Multilinea = false;
            this.txtContra.Name = "txtContra";
            this.txtContra.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtContra.PasswordChar = true;
            this.txtContra.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtContra.PlaceHolderText = "";
            this.txtContra.Size = new System.Drawing.Size(250, 31);
            this.txtContra.TabIndex = 8;
            this.txtContra.Texts = "";
            this.txtContra.UnderLineFlat = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtUsuario.BorderRadius = 0;
            this.txtUsuario.BorderSize = 2;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Location = new System.Drawing.Point(450, 102);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Multilinea = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsuario.PasswordChar = false;
            this.txtUsuario.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtUsuario.PlaceHolderText = "";
            this.txtUsuario.Size = new System.Drawing.Size(250, 31);
            this.txtUsuario.TabIndex = 7;
            this.txtUsuario.Texts = "";
            this.txtUsuario.UnderLineFlat = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(447, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Confirme la nueva Contraseña:";
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtConfirmar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtConfirmar.BorderRadius = 0;
            this.txtConfirmar.BorderSize = 2;
            this.txtConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmar.Location = new System.Drawing.Point(450, 307);
            this.txtConfirmar.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmar.Multilinea = false;
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConfirmar.PasswordChar = true;
            this.txtConfirmar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtConfirmar.PlaceHolderText = "";
            this.txtConfirmar.Size = new System.Drawing.Size(250, 31);
            this.txtConfirmar.TabIndex = 40;
            this.txtConfirmar.Texts = "";
            this.txtConfirmar.UnderLineFlat = false;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "Vendedor",
            "Gerente",
            "Contador",
            "Secretario",
            "Informatico"});
            this.cmbRol.Location = new System.Drawing.Point(450, 404);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(240, 21);
            this.cmbRol.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(447, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 18);
            this.label4.TabIndex = 43;
            this.label4.Text = "Rol del nuevo Usuario:";
            // 
            // CreacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnCrearUsuario);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreacionUsuario";
            this.Text = "CreacionUsuario";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private Controladores.LoginUserControl txtUsuario;
        private Controladores.LoginUserControl txtContra;
        private Especiales.EspecialButton BtnCrearUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controladores.LoginUserControl txtConfirmar;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label4;
    }
}