namespace NeoCobranza.Paneles
{
    partial class PnlRespaldos
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
            this.TxtRutaRespaldo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnExaminar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnGenerarRespaldo = new NeoCobranza.Especiales.EspecialButton();
            this.ChkRespaldoAuto = new System.Windows.Forms.CheckBox();
            this.BtnGuardarConfiguracion = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-1, 479);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1127, 44);
            this.PnlTitulo.TabIndex = 136;
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
            this.TbTitulo.Size = new System.Drawing.Size(149, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Respaldos";
            // 
            // TxtRutaRespaldo
            // 
            this.TxtRutaRespaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRutaRespaldo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRutaRespaldo.Location = new System.Drawing.Point(17, 52);
            this.TxtRutaRespaldo.Name = "TxtRutaRespaldo";
            this.TxtRutaRespaldo.ReadOnly = true;
            this.TxtRutaRespaldo.Size = new System.Drawing.Size(1050, 33);
            this.TxtRutaRespaldo.TabIndex = 173;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(15, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 172;
            this.label5.Text = "Ruta de Respaldos";
            // 
            // BtnExaminar
            // 
            this.BtnExaminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnExaminar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnExaminar.BorderColor = System.Drawing.Color.Lime;
            this.BtnExaminar.BorderRadius = 5;
            this.BtnExaminar.BorderSize = 0;
            this.BtnExaminar.FlatAppearance.BorderSize = 0;
            this.BtnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExaminar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnExaminar.ForeColor = System.Drawing.Color.White;
            this.BtnExaminar.Location = new System.Drawing.Point(15, 102);
            this.BtnExaminar.Name = "BtnExaminar";
            this.BtnExaminar.Size = new System.Drawing.Size(142, 57);
            this.BtnExaminar.TabIndex = 174;
            this.BtnExaminar.Text = "EXAMINAR";
            this.BtnExaminar.TextGroundColor = System.Drawing.Color.White;
            this.BtnExaminar.UseVisualStyleBackColor = false;
            this.BtnExaminar.Click += new System.EventHandler(this.BtnExaminar_Click);
            // 
            // BtnGenerarRespaldo
            // 
            this.BtnGenerarRespaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnGenerarRespaldo.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnGenerarRespaldo.BorderColor = System.Drawing.Color.Lime;
            this.BtnGenerarRespaldo.BorderRadius = 5;
            this.BtnGenerarRespaldo.BorderSize = 0;
            this.BtnGenerarRespaldo.FlatAppearance.BorderSize = 0;
            this.BtnGenerarRespaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarRespaldo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnGenerarRespaldo.ForeColor = System.Drawing.Color.White;
            this.BtnGenerarRespaldo.Location = new System.Drawing.Point(163, 102);
            this.BtnGenerarRespaldo.Name = "BtnGenerarRespaldo";
            this.BtnGenerarRespaldo.Size = new System.Drawing.Size(228, 57);
            this.BtnGenerarRespaldo.TabIndex = 175;
            this.BtnGenerarRespaldo.Text = "GENERAR RESPALDO";
            this.BtnGenerarRespaldo.TextGroundColor = System.Drawing.Color.White;
            this.BtnGenerarRespaldo.UseVisualStyleBackColor = false;
            this.BtnGenerarRespaldo.Click += new System.EventHandler(this.BtnGenerarRespaldo_Click);
            // 
            // ChkRespaldoAuto
            // 
            this.ChkRespaldoAuto.AutoSize = true;
            this.ChkRespaldoAuto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.ChkRespaldoAuto.Location = new System.Drawing.Point(17, 201);
            this.ChkRespaldoAuto.Name = "ChkRespaldoAuto";
            this.ChkRespaldoAuto.Size = new System.Drawing.Size(282, 22);
            this.ChkRespaldoAuto.TabIndex = 176;
            this.ChkRespaldoAuto.Text = "Hacer Respaldo en Cierre de Caja";
            this.ChkRespaldoAuto.UseVisualStyleBackColor = true;
            // 
            // BtnGuardarConfiguracion
            // 
            this.BtnGuardarConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardarConfiguracion.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardarConfiguracion.BorderColor = System.Drawing.Color.Lime;
            this.BtnGuardarConfiguracion.BorderRadius = 5;
            this.BtnGuardarConfiguracion.BorderSize = 0;
            this.BtnGuardarConfiguracion.FlatAppearance.BorderSize = 0;
            this.BtnGuardarConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarConfiguracion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnGuardarConfiguracion.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarConfiguracion.Location = new System.Drawing.Point(868, 421);
            this.BtnGuardarConfiguracion.Name = "BtnGuardarConfiguracion";
            this.BtnGuardarConfiguracion.Size = new System.Drawing.Size(199, 35);
            this.BtnGuardarConfiguracion.TabIndex = 177;
            this.BtnGuardarConfiguracion.Text = "Guardar Configuración";
            this.BtnGuardarConfiguracion.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardarConfiguracion.UseVisualStyleBackColor = false;
            this.BtnGuardarConfiguracion.Click += new System.EventHandler(this.BtnGuardarConfiguracion_Click);
            // 
            // PnlRespaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.BtnGuardarConfiguracion);
            this.Controls.Add(this.ChkRespaldoAuto);
            this.Controls.Add(this.BtnGenerarRespaldo);
            this.Controls.Add(this.BtnExaminar);
            this.Controls.Add(this.TxtRutaRespaldo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlRespaldos";
            this.Text = "PnlRespaldos";
            this.Load += new System.EventHandler(this.PnlRespaldos_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.TextBox TxtRutaRespaldo;
        public System.Windows.Forms.Label label5;
        public Especiales.EspecialButton BtnExaminar;
        public Especiales.EspecialButton BtnGenerarRespaldo;
        private System.Windows.Forms.CheckBox ChkRespaldoAuto;
        public Especiales.EspecialButton BtnGuardarConfiguracion;
    }
}