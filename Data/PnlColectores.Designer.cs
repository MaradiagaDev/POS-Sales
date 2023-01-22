namespace NeoCobranza.Data
{
    partial class PnlColectores
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
            this.DgvColector = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSeleccionar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.loginUserControl1 = new NeoCobranza.Controladores.LoginUserControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvColector)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvColector
            // 
            this.DgvColector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvColector.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvColector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvColector.Location = new System.Drawing.Point(32, 186);
            this.DgvColector.Name = "DgvColector";
            this.DgvColector.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvColector.Size = new System.Drawing.Size(801, 296);
            this.DgvColector.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(29, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = " Informacion de Colector";
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnSeleccionar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSeleccionar.BackGroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnSeleccionar.BorderColor = System.Drawing.Color.Lime;
            this.BtnSeleccionar.BorderRadius = 40;
            this.BtnSeleccionar.BorderSize = 2;
            this.BtnSeleccionar.FlatAppearance.BorderSize = 0;
            this.BtnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.BtnSeleccionar.Location = new System.Drawing.Point(672, 0);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(132, 32);
            this.BtnSeleccionar.TabIndex = 20;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.TextGroundColor = System.Drawing.Color.White;
            this.BtnSeleccionar.UseVisualStyleBackColor = false;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
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
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(534, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // loginUserControl1
            // 
            this.loginUserControl1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.loginUserControl1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.loginUserControl1.BorderRadius = 0;
            this.loginUserControl1.BorderSize = 2;
            this.loginUserControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUserControl1.ForeColor = System.Drawing.Color.DimGray;
            this.loginUserControl1.Location = new System.Drawing.Point(32, 138);
            this.loginUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.loginUserControl1.Multilinea = false;
            this.loginUserControl1.Name = "loginUserControl1";
            this.loginUserControl1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.loginUserControl1.PasswordChar = false;
            this.loginUserControl1.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.loginUserControl1.PlaceHolderText = "Buscar Colector..";
            this.loginUserControl1.Size = new System.Drawing.Size(801, 31);
            this.loginUserControl1.TabIndex = 0;
            this.loginUserControl1.Texts = "";
            this.loginUserControl1.UnderLineFlat = true;
            this.loginUserControl1._TextChanged += new System.EventHandler(this.loginUserControl1__TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.BtnSeleccionar);
            this.panel1.Location = new System.Drawing.Point(1, 527);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 38);
            this.panel1.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 31);
            this.panel3.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleccion de Colector";
            // 
            // PnlColectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(875, 562);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvColector);
            this.Controls.Add(this.loginUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlColectores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DgvColector)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controladores.LoginUserControl loginUserControl1;
        private System.Windows.Forms.DataGridView DgvColector;
        private System.Windows.Forms.Label label1;
        private Especiales.EspecialButton btnCancelar;
        private Especiales.EspecialButton BtnSeleccionar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
    }
}