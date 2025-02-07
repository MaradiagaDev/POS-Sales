namespace NeoCobranza.Paneles_Venta
{
    partial class PnlAgenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgenda));
            this.CalendarCitas = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbUsuarios = new System.Windows.Forms.ComboBox();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.DgvItemsCitas = new System.Windows.Forms.DataGridView();
            this.BtnCitaCumplida = new NeoCobranza.Especiales.EspecialButton();
            this.BtnPagarOrden = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCancelarOrden = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCambioUsuario = new NeoCobranza.Especiales.EspecialButton();
            this.BtnAgregarServicio = new NeoCobranza.Especiales.EspecialButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemsCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarCitas
            // 
            this.CalendarCitas.Location = new System.Drawing.Point(6, 12);
            this.CalendarCitas.Name = "CalendarCitas";
            this.CalendarCitas.TabIndex = 0;
            this.CalendarCitas.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.CalendarCitas_DateChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.CmbUsuarios);
            this.panel1.Controls.Add(this.LblUsuario);
            this.panel1.Controls.Add(this.DgvItemsCitas);
            this.panel1.Location = new System.Drawing.Point(265, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 587);
            this.panel1.TabIndex = 1;
            // 
            // CmbUsuarios
            // 
            this.CmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuarios.FormattingEnabled = true;
            this.CmbUsuarios.Location = new System.Drawing.Point(99, 11);
            this.CmbUsuarios.Name = "CmbUsuarios";
            this.CmbUsuarios.Size = new System.Drawing.Size(758, 28);
            this.CmbUsuarios.TabIndex = 160;
            this.CmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.CmbUsuarios_SelectedIndexChanged);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(17, 14);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(76, 20);
            this.LblUsuario.TabIndex = 159;
            this.LblUsuario.Text = "Usuario:";
            // 
            // DgvItemsCitas
            // 
            this.DgvItemsCitas.AllowUserToAddRows = false;
            this.DgvItemsCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvItemsCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvItemsCitas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvItemsCitas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItemsCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvItemsCitas.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvItemsCitas.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvItemsCitas.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.DgvItemsCitas.Location = new System.Drawing.Point(3, 50);
            this.DgvItemsCitas.Name = "DgvItemsCitas";
            this.DgvItemsCitas.ReadOnly = true;
            this.DgvItemsCitas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItemsCitas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvItemsCitas.RowHeadersWidth = 15;
            this.DgvItemsCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvItemsCitas.Size = new System.Drawing.Size(874, 537);
            this.DgvItemsCitas.TabIndex = 158;
            // 
            // BtnCitaCumplida
            // 
            this.BtnCitaCumplida.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnCitaCumplida.BackGroundColor = System.Drawing.Color.RoyalBlue;
            this.BtnCitaCumplida.BorderColor = System.Drawing.Color.White;
            this.BtnCitaCumplida.BorderRadius = 0;
            this.BtnCitaCumplida.BorderSize = 0;
            this.BtnCitaCumplida.FlatAppearance.BorderSize = 0;
            this.BtnCitaCumplida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCitaCumplida.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCitaCumplida.ForeColor = System.Drawing.Color.White;
            this.BtnCitaCumplida.Image = ((System.Drawing.Image)(resources.GetObject("BtnCitaCumplida.Image")));
            this.BtnCitaCumplida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCitaCumplida.Location = new System.Drawing.Point(6, 360);
            this.BtnCitaCumplida.Name = "BtnCitaCumplida";
            this.BtnCitaCumplida.Size = new System.Drawing.Size(256, 52);
            this.BtnCitaCumplida.TabIndex = 140;
            this.BtnCitaCumplida.Text = "Dar Cita Cumplida";
            this.BtnCitaCumplida.TextGroundColor = System.Drawing.Color.White;
            this.BtnCitaCumplida.UseVisualStyleBackColor = false;
            this.BtnCitaCumplida.Click += new System.EventHandler(this.BtnCitaCumplida_Click);
            // 
            // BtnPagarOrden
            // 
            this.BtnPagarOrden.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnPagarOrden.BackGroundColor = System.Drawing.Color.DarkGreen;
            this.BtnPagarOrden.BorderColor = System.Drawing.Color.White;
            this.BtnPagarOrden.BorderRadius = 0;
            this.BtnPagarOrden.BorderSize = 0;
            this.BtnPagarOrden.FlatAppearance.BorderSize = 0;
            this.BtnPagarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPagarOrden.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagarOrden.ForeColor = System.Drawing.Color.White;
            this.BtnPagarOrden.Image = ((System.Drawing.Image)(resources.GetObject("BtnPagarOrden.Image")));
            this.BtnPagarOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPagarOrden.Location = new System.Drawing.Point(6, 302);
            this.BtnPagarOrden.Name = "BtnPagarOrden";
            this.BtnPagarOrden.Size = new System.Drawing.Size(256, 52);
            this.BtnPagarOrden.TabIndex = 97;
            this.BtnPagarOrden.Text = "Agregar/Abrir Venta";
            this.BtnPagarOrden.TextGroundColor = System.Drawing.Color.White;
            this.BtnPagarOrden.UseVisualStyleBackColor = false;
            this.BtnPagarOrden.Click += new System.EventHandler(this.BtnPagarOrden_Click);
            // 
            // BtnCancelarOrden
            // 
            this.BtnCancelarOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancelarOrden.BackColor = System.Drawing.Color.DarkRed;
            this.BtnCancelarOrden.BackGroundColor = System.Drawing.Color.DarkRed;
            this.BtnCancelarOrden.BorderColor = System.Drawing.Color.White;
            this.BtnCancelarOrden.BorderRadius = 0;
            this.BtnCancelarOrden.BorderSize = 0;
            this.BtnCancelarOrden.FlatAppearance.BorderSize = 0;
            this.BtnCancelarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelarOrden.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelarOrden.ForeColor = System.Drawing.Color.White;
            this.BtnCancelarOrden.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelarOrden.Image")));
            this.BtnCancelarOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelarOrden.Location = new System.Drawing.Point(6, 547);
            this.BtnCancelarOrden.Name = "BtnCancelarOrden";
            this.BtnCancelarOrden.Size = new System.Drawing.Size(248, 52);
            this.BtnCancelarOrden.TabIndex = 96;
            this.BtnCancelarOrden.Text = "Cancelar Cita";
            this.BtnCancelarOrden.TextGroundColor = System.Drawing.Color.White;
            this.BtnCancelarOrden.UseVisualStyleBackColor = false;
            this.BtnCancelarOrden.Click += new System.EventHandler(this.BtnCancelarOrden_Click);
            // 
            // BtnCambioUsuario
            // 
            this.BtnCambioUsuario.BackColor = System.Drawing.Color.Gray;
            this.BtnCambioUsuario.BackGroundColor = System.Drawing.Color.Gray;
            this.BtnCambioUsuario.BorderColor = System.Drawing.Color.White;
            this.BtnCambioUsuario.BorderRadius = 0;
            this.BtnCambioUsuario.BorderSize = 0;
            this.BtnCambioUsuario.FlatAppearance.BorderSize = 0;
            this.BtnCambioUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambioUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambioUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnCambioUsuario.Image = ((System.Drawing.Image)(resources.GetObject("BtnCambioUsuario.Image")));
            this.BtnCambioUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCambioUsuario.Location = new System.Drawing.Point(6, 244);
            this.BtnCambioUsuario.Name = "BtnCambioUsuario";
            this.BtnCambioUsuario.Size = new System.Drawing.Size(256, 52);
            this.BtnCambioUsuario.TabIndex = 95;
            this.BtnCambioUsuario.Text = "Configurar Cita";
            this.BtnCambioUsuario.TextGroundColor = System.Drawing.Color.White;
            this.BtnCambioUsuario.UseVisualStyleBackColor = false;
            this.BtnCambioUsuario.Click += new System.EventHandler(this.BtnCambioUsuario_Click);
            // 
            // BtnAgregarServicio
            // 
            this.BtnAgregarServicio.BackColor = System.Drawing.Color.Gray;
            this.BtnAgregarServicio.BackGroundColor = System.Drawing.Color.Gray;
            this.BtnAgregarServicio.BorderColor = System.Drawing.Color.White;
            this.BtnAgregarServicio.BorderRadius = 0;
            this.BtnAgregarServicio.BorderSize = 0;
            this.BtnAgregarServicio.FlatAppearance.BorderSize = 0;
            this.BtnAgregarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarServicio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarServicio.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarServicio.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarServicio.Image")));
            this.BtnAgregarServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregarServicio.Location = new System.Drawing.Point(6, 186);
            this.BtnAgregarServicio.Name = "BtnAgregarServicio";
            this.BtnAgregarServicio.Size = new System.Drawing.Size(256, 52);
            this.BtnAgregarServicio.TabIndex = 94;
            this.BtnAgregarServicio.Text = "Agendar Cliente";
            this.BtnAgregarServicio.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarServicio.UseVisualStyleBackColor = false;
            this.BtnAgregarServicio.Click += new System.EventHandler(this.BtnAgregarServicio_Click);
            // 
            // PnlAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1157, 611);
            this.Controls.Add(this.BtnCitaCumplida);
            this.Controls.Add(this.BtnPagarOrden);
            this.Controls.Add(this.BtnCancelarOrden);
            this.Controls.Add(this.BtnCambioUsuario);
            this.Controls.Add(this.BtnAgregarServicio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CalendarCitas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlAgenda";
            this.Text = "PnlAgenda";
            this.Load += new System.EventHandler(this.PnlAgenda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemsCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public Especiales.EspecialButton BtnAgregarServicio;
        private Especiales.EspecialButton BtnCambioUsuario;
        public Especiales.EspecialButton BtnCancelarOrden;
        public Especiales.EspecialButton BtnPagarOrden;
        public System.Windows.Forms.DataGridView DgvItemsCitas;
        private System.Windows.Forms.Label LblUsuario;
        private Especiales.EspecialButton BtnCitaCumplida;
        public System.Windows.Forms.ComboBox CmbUsuarios;
        public System.Windows.Forms.MonthCalendar CalendarCitas;
    }
}