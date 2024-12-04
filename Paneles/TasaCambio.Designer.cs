namespace NeoCobranza.Paneles
{
    partial class TasaCambio
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
            this.LblTasaActual = new System.Windows.Forms.Label();
            this.TxtTasaCambio = new System.Windows.Forms.TextBox();
            this.LblTasa = new System.Windows.Forms.Label();
            this.BtnGuardar = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-10, 479);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1144, 44);
            this.PnlTitulo.TabIndex = 146;
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
            this.TbTitulo.Size = new System.Drawing.Size(335, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Establecer Tasa Cambio";
            // 
            // LblTasaActual
            // 
            this.LblTasaActual.AutoSize = true;
            this.LblTasaActual.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTasaActual.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblTasaActual.Location = new System.Drawing.Point(25, 33);
            this.LblTasaActual.Name = "LblTasaActual";
            this.LblTasaActual.Size = new System.Drawing.Size(58, 19);
            this.LblTasaActual.TabIndex = 147;
            this.LblTasaActual.Text = "label1";
            // 
            // TxtTasaCambio
            // 
            this.TxtTasaCambio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTasaCambio.Location = new System.Drawing.Point(196, 99);
            this.TxtTasaCambio.Name = "TxtTasaCambio";
            this.TxtTasaCambio.Size = new System.Drawing.Size(175, 27);
            this.TxtTasaCambio.TabIndex = 148;
            this.TxtTasaCambio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTasaCambio_KeyPress);
            // 
            // LblTasa
            // 
            this.LblTasa.AutoSize = true;
            this.LblTasa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTasa.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblTasa.Location = new System.Drawing.Point(25, 102);
            this.LblTasa.Name = "LblTasa";
            this.LblTasa.Size = new System.Drawing.Size(168, 19);
            this.LblTasa.TabIndex = 149;
            this.LblTasa.Text = "Agregar tasa nueva:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardar.BorderColor = System.Drawing.Color.Lime;
            this.BtnGuardar.BorderRadius = 5;
            this.BtnGuardar.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(945, 438);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(173, 35);
            this.BtnGuardar.TabIndex = 150;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TasaCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblTasa);
            this.Controls.Add(this.TxtTasaCambio);
            this.Controls.Add(this.LblTasaActual);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TasaCambio";
            this.Text = "TasaCambio";
            this.Load += new System.EventHandler(this.TasaCambio_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        private System.Windows.Forms.Label LblTasaActual;
        private System.Windows.Forms.TextBox TxtTasaCambio;
        private System.Windows.Forms.Label LblTasa;
        public Especiales.EspecialButton BtnGuardar;
    }
}