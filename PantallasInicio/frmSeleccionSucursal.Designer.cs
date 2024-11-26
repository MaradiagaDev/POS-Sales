namespace NeoCobranza.PantallasInicio
{
    partial class frmSeleccionSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionSucursal));
            this.label2 = new System.Windows.Forms.Label();
            this.LblTituloPrincipal = new System.Windows.Forms.Label();
            this.CmbSucursal = new System.Windows.Forms.ComboBox();
            this.btnIngresarSucursal = new NeoCobranza.Especiales.EspecialButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(601, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "SYSADMIN - IDEV";
            // 
            // LblTituloPrincipal
            // 
            this.LblTituloPrincipal.AutoSize = true;
            this.LblTituloPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.LblTituloPrincipal.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloPrincipal.ForeColor = System.Drawing.Color.Black;
            this.LblTituloPrincipal.Location = new System.Drawing.Point(21, 98);
            this.LblTituloPrincipal.Name = "LblTituloPrincipal";
            this.LblTituloPrincipal.Size = new System.Drawing.Size(223, 24);
            this.LblTituloPrincipal.TabIndex = 10;
            this.LblTituloPrincipal.Text = "Seleccionar sucursal:";
            // 
            // CmbSucursal
            // 
            this.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbSucursal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursal.FormattingEnabled = true;
            this.CmbSucursal.Location = new System.Drawing.Point(260, 98);
            this.CmbSucursal.Name = "CmbSucursal";
            this.CmbSucursal.Size = new System.Drawing.Size(493, 29);
            this.CmbSucursal.TabIndex = 149;
            // 
            // btnIngresarSucursal
            // 
            this.btnIngresarSucursal.BackColor = System.Drawing.Color.Black;
            this.btnIngresarSucursal.BackGroundColor = System.Drawing.Color.Black;
            this.btnIngresarSucursal.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnIngresarSucursal.BorderRadius = 0;
            this.btnIngresarSucursal.BorderSize = 2;
            this.btnIngresarSucursal.FlatAppearance.BorderSize = 0;
            this.btnIngresarSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarSucursal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarSucursal.ForeColor = System.Drawing.Color.White;
            this.btnIngresarSucursal.Location = new System.Drawing.Point(620, 180);
            this.btnIngresarSucursal.Name = "btnIngresarSucursal";
            this.btnIngresarSucursal.Size = new System.Drawing.Size(168, 35);
            this.btnIngresarSucursal.TabIndex = 150;
            this.btnIngresarSucursal.Text = "Ingresar";
            this.btnIngresarSucursal.TextGroundColor = System.Drawing.Color.White;
            this.btnIngresarSucursal.UseVisualStyleBackColor = false;
            this.btnIngresarSucursal.Click += new System.EventHandler(this.btnIngresarSucursal_Click);
            // 
            // frmSeleccionSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 227);
            this.Controls.Add(this.btnIngresarSucursal);
            this.Controls.Add(this.CmbSucursal);
            this.Controls.Add(this.LblTituloPrincipal);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 266);
            this.MinimumSize = new System.Drawing.Size(816, 266);
            this.Name = "frmSeleccionSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Sucursal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTituloPrincipal;
        private System.Windows.Forms.ComboBox CmbSucursal;
        private Especiales.EspecialButton btnIngresarSucursal;
    }
}