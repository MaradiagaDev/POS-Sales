namespace NeoCobranza.Paneles
{
    partial class PnlAgendar
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
            this.DTInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombreCliente = new System.Windows.Forms.Label();
            this.BtnAgendar = new NeoCobranza.Especiales.EspecialButton();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtMotivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DTInicio
            // 
            this.DTInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTInicio.Location = new System.Drawing.Point(12, 46);
            this.DTInicio.Name = "DTInicio";
            this.DTInicio.Size = new System.Drawing.Size(127, 20);
            this.DTInicio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 137;
            this.label1.Text = "Hora de Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(169, 9);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 138;
            this.label2.Text = "Hora de Fin";
            // 
            // DTFin
            // 
            this.DTFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFin.Location = new System.Drawing.Point(169, 45);
            this.DTFin.Name = "DTFin";
            this.DTFin.Size = new System.Drawing.Size(127, 20);
            this.DTFin.TabIndex = 139;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(185, 29);
            this.label3.TabIndex = 140;
            this.label3.Text = "Cliente Seleccionado";
            // 
            // TxtNombreCliente
            // 
            this.TxtNombreCliente.AutoSize = true;
            this.TxtNombreCliente.BackColor = System.Drawing.Color.Transparent;
            this.TxtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombreCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.TxtNombreCliente.ForeColor = System.Drawing.Color.Black;
            this.TxtNombreCliente.Location = new System.Drawing.Point(12, 113);
            this.TxtNombreCliente.Name = "TxtNombreCliente";
            this.TxtNombreCliente.Padding = new System.Windows.Forms.Padding(2);
            this.TxtNombreCliente.Size = new System.Drawing.Size(20, 24);
            this.TxtNombreCliente.TabIndex = 141;
            this.TxtNombreCliente.Text = "-";
            // 
            // BtnAgendar
            // 
            this.BtnAgendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAgendar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAgendar.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAgendar.BorderColor = System.Drawing.Color.Transparent;
            this.BtnAgendar.BorderRadius = 5;
            this.BtnAgendar.BorderSize = 2;
            this.BtnAgendar.FlatAppearance.BorderSize = 0;
            this.BtnAgendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgendar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgendar.ForeColor = System.Drawing.Color.White;
            this.BtnAgendar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgendar.Location = new System.Drawing.Point(423, 134);
            this.BtnAgendar.Name = "BtnAgendar";
            this.BtnAgendar.Size = new System.Drawing.Size(141, 28);
            this.BtnAgendar.TabIndex = 170;
            this.BtnAgendar.Text = "Agendar";
            this.BtnAgendar.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgendar.UseVisualStyleBackColor = false;
            this.BtnAgendar.Click += new System.EventHandler(this.BtnAgendar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(348, 9);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(70, 29);
            this.label4.TabIndex = 171;
            this.label4.Text = "Motivo";
            // 
            // TxtMotivo
            // 
            this.TxtMotivo.Location = new System.Drawing.Point(349, 49);
            this.TxtMotivo.Multiline = true;
            this.TxtMotivo.Name = "TxtMotivo";
            this.TxtMotivo.Size = new System.Drawing.Size(200, 55);
            this.TxtMotivo.TabIndex = 172;
            // 
            // PnlAgendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 168);
            this.Controls.Add(this.TxtMotivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnAgendar);
            this.Controls.Add(this.TxtNombreCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTInicio);
            this.MaximumSize = new System.Drawing.Size(588, 207);
            this.MinimumSize = new System.Drawing.Size(588, 207);
            this.Name = "PnlAgendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendar Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTFin;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label TxtNombreCliente;
        private Especiales.EspecialButton BtnAgendar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtMotivo;
    }
}