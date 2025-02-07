namespace NeoCobranza.Paneles
{
    partial class PnlAgendaCambioUsuario
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
            this.CmbUsuarios = new System.Windows.Forms.ComboBox();
            this.DTFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTInicio = new System.Windows.Forms.DateTimePicker();
            this.TxtNombreCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnAgendar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtMotivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnCambiarCliente = new NeoCobranza.Especiales.EspecialButton();
            this.SuspendLayout();
            // 
            // CmbUsuarios
            // 
            this.CmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuarios.FormattingEnabled = true;
            this.CmbUsuarios.Location = new System.Drawing.Point(12, 52);
            this.CmbUsuarios.Name = "CmbUsuarios";
            this.CmbUsuarios.Size = new System.Drawing.Size(778, 28);
            this.CmbUsuarios.TabIndex = 162;
            // 
            // DTFin
            // 
            this.DTFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFin.Location = new System.Drawing.Point(165, 216);
            this.DTFin.Name = "DTFin";
            this.DTFin.Size = new System.Drawing.Size(127, 20);
            this.DTFin.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(165, 180);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 165;
            this.label2.Text = "Hora de Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(8, 180);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 164;
            this.label1.Text = "Hora de Inicio";
            // 
            // DTInicio
            // 
            this.DTInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTInicio.Location = new System.Drawing.Point(8, 217);
            this.DTInicio.Name = "DTInicio";
            this.DTInicio.Size = new System.Drawing.Size(127, 20);
            this.DTInicio.TabIndex = 163;
            // 
            // TxtNombreCliente
            // 
            this.TxtNombreCliente.AutoSize = true;
            this.TxtNombreCliente.BackColor = System.Drawing.Color.Transparent;
            this.TxtNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombreCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.TxtNombreCliente.ForeColor = System.Drawing.Color.Black;
            this.TxtNombreCliente.Location = new System.Drawing.Point(12, 139);
            this.TxtNombreCliente.Name = "TxtNombreCliente";
            this.TxtNombreCliente.Padding = new System.Windows.Forms.Padding(2);
            this.TxtNombreCliente.Size = new System.Drawing.Size(20, 24);
            this.TxtNombreCliente.TabIndex = 168;
            this.TxtNombreCliente.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(185, 29);
            this.label3.TabIndex = 167;
            this.label3.Text = "Cliente Seleccionado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(75, 29);
            this.label4.TabIndex = 169;
            this.label4.Text = "Usuario";
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
            this.BtnAgendar.Location = new System.Drawing.Point(649, 217);
            this.BtnAgendar.Name = "BtnAgendar";
            this.BtnAgendar.Size = new System.Drawing.Size(141, 28);
            this.BtnAgendar.TabIndex = 171;
            this.BtnAgendar.Text = "Actualizar Cita";
            this.BtnAgendar.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgendar.UseVisualStyleBackColor = false;
            this.BtnAgendar.Click += new System.EventHandler(this.BtnAgendar_Click);
            // 
            // TxtMotivo
            // 
            this.TxtMotivo.Location = new System.Drawing.Point(588, 139);
            this.TxtMotivo.Multiline = true;
            this.TxtMotivo.Name = "TxtMotivo";
            this.TxtMotivo.Size = new System.Drawing.Size(200, 55);
            this.TxtMotivo.TabIndex = 174;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(587, 99);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(70, 29);
            this.label5.TabIndex = 173;
            this.label5.Text = "Motivo";
            // 
            // BtnCambiarCliente
            // 
            this.BtnCambiarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCambiarCliente.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnCambiarCliente.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.BtnCambiarCliente.BorderColor = System.Drawing.Color.Transparent;
            this.BtnCambiarCliente.BorderRadius = 5;
            this.BtnCambiarCliente.BorderSize = 2;
            this.BtnCambiarCliente.FlatAppearance.BorderSize = 0;
            this.BtnCambiarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarCliente.ForeColor = System.Drawing.Color.White;
            this.BtnCambiarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCambiarCliente.Location = new System.Drawing.Point(217, 101);
            this.BtnCambiarCliente.Name = "BtnCambiarCliente";
            this.BtnCambiarCliente.Size = new System.Drawing.Size(176, 28);
            this.BtnCambiarCliente.TabIndex = 175;
            this.BtnCambiarCliente.Text = "Cambiar Cliente";
            this.BtnCambiarCliente.TextGroundColor = System.Drawing.Color.White;
            this.BtnCambiarCliente.UseVisualStyleBackColor = false;
            this.BtnCambiarCliente.Click += new System.EventHandler(this.BtnCambiarCliente_Click);
            // 
            // PnlAgendaCambioUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 255);
            this.Controls.Add(this.BtnCambiarCliente);
            this.Controls.Add(this.TxtMotivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnAgendar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNombreCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTInicio);
            this.Controls.Add(this.CmbUsuarios);
            this.MaximumSize = new System.Drawing.Size(816, 294);
            this.MinimumSize = new System.Drawing.Size(816, 294);
            this.Name = "PnlAgendaCambioUsuario";
            this.Text = "PnlAgendaCambioUsuario";
            this.Load += new System.EventHandler(this.PnlAgendaCambioUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox CmbUsuarios;
        private System.Windows.Forms.DateTimePicker DTFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTInicio;
        public System.Windows.Forms.Label TxtNombreCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Especiales.EspecialButton BtnAgendar;
        private System.Windows.Forms.TextBox TxtMotivo;
        private System.Windows.Forms.Label label5;
        private Especiales.EspecialButton BtnCambiarCliente;
    }
}