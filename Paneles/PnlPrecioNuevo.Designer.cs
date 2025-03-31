namespace NeoCobranza.Paneles
{
    partial class PnlPrecioNuevo
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
            this.TxtTotalPagado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.SuspendLayout();
            // 
            // TxtTotalPagado
            // 
            this.TxtTotalPagado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTotalPagado.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtTotalPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotalPagado.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalPagado.ForeColor = System.Drawing.Color.Black;
            this.TxtTotalPagado.Location = new System.Drawing.Point(55, 127);
            this.TxtTotalPagado.Name = "TxtTotalPagado";
            this.TxtTotalPagado.Size = new System.Drawing.Size(565, 37);
            this.TxtTotalPagado.TabIndex = 177;
            this.TxtTotalPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotalPagado_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(50, 44);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(326, 38);
            this.label1.TabIndex = 178;
            this.label1.Text = "Precio Producto / Servicio:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnGuardar.BackGroundColor = System.Drawing.Color.DarkGreen;
            this.BtnGuardar.BorderColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.BorderRadius = 0;
            this.BtnGuardar.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(446, 213);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(174, 49);
            this.BtnGuardar.TabIndex = 179;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnCancelar.BorderColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BorderRadius = 0;
            this.BtnCancelar.BorderSize = 0;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(256, 213);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(174, 49);
            this.BtnCancelar.TabIndex = 180;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // PnlPrecioNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 284);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTotalPagado);
            this.MaximumSize = new System.Drawing.Size(676, 323);
            this.MinimumSize = new System.Drawing.Size(676, 323);
            this.Name = "PnlPrecioNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digite la información:";
            this.Load += new System.EventHandler(this.PnlPrecioNuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TxtTotalPagado;
        private System.Windows.Forms.Label label1;
        private Especiales.EspecialButton BtnGuardar;
        private Especiales.EspecialButton BtnCancelar;
    }
}