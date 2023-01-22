namespace NeoCobranza.Paneles
{
    partial class PnlInsertarAgencia
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.loginUserControl1 = new NeoCobranza.Controladores.LoginUserControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.especialButton1);
            this.panel1.Location = new System.Drawing.Point(2, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 40;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(110, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 35);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // especialButton1
            // 
            this.especialButton1.BackColor = System.Drawing.Color.DodgerBlue;
            this.especialButton1.BackGroundColor = System.Drawing.Color.DodgerBlue;
            this.especialButton1.BorderColor = System.Drawing.Color.Lime;
            this.especialButton1.BorderRadius = 40;
            this.especialButton1.BorderSize = 2;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Location = new System.Drawing.Point(254, 0);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(122, 35);
            this.especialButton1.TabIndex = 0;
            this.especialButton1.Text = "Insertar";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agregar Agencia";
            // 
            // loginUserControl1
            // 
            this.loginUserControl1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.loginUserControl1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.loginUserControl1.BorderRadius = 8;
            this.loginUserControl1.BorderSize = 2;
            this.loginUserControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUserControl1.ForeColor = System.Drawing.Color.DimGray;
            this.loginUserControl1.Location = new System.Drawing.Point(38, 80);
            this.loginUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.loginUserControl1.Multilinea = false;
            this.loginUserControl1.Name = "loginUserControl1";
            this.loginUserControl1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.loginUserControl1.PasswordChar = false;
            this.loginUserControl1.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.loginUserControl1.PlaceHolderText = "";
            this.loginUserControl1.Size = new System.Drawing.Size(312, 31);
            this.loginUserControl1.TabIndex = 1;
            this.loginUserControl1.Texts = "";
            this.loginUserControl1.UnderLineFlat = false;
            // 
            // PnlInsertarAgencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginUserControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlInsertarAgencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlInsertarAgencia";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Especiales.EspecialButton especialButton1;
        private Controladores.LoginUserControl loginUserControl1;
        private Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Label label1;
    }
}