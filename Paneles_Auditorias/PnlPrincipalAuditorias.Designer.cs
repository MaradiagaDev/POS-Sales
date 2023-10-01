namespace NeoCobranza.Paneles_Auditorias
{
    partial class PnlPrincipalAuditorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlPrincipalAuditorias));
            this.DGVAuditoria = new System.Windows.Forms.DataGridView();
            this.BtnBuscar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbUsuarios = new System.Windows.Forms.ComboBox();
            this.DtInicio = new System.Windows.Forms.DateTimePicker();
            this.DtFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbSector = new System.Windows.Forms.ComboBox();
            this.BtnTodos = new NeoCobranza.Especiales.EspecialButton();
            this.BtnReporte = new NeoCobranza.Especiales.EspecialButton();
            this.BtnBuscarUser = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltroUsuario = new NeoCobranza.Controladores.LoginUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAuditoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVAuditoria
            // 
            this.DGVAuditoria.AllowUserToAddRows = false;
            this.DGVAuditoria.AllowUserToDeleteRows = false;
            this.DGVAuditoria.AllowUserToResizeRows = false;
            this.DGVAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVAuditoria.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVAuditoria.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAuditoria.EnableHeadersVisualStyles = false;
            this.DGVAuditoria.Location = new System.Drawing.Point(11, 167);
            this.DGVAuditoria.MultiSelect = false;
            this.DGVAuditoria.Name = "DGVAuditoria";
            this.DGVAuditoria.ReadOnly = true;
            this.DGVAuditoria.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVAuditoria.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DGVAuditoria.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVAuditoria.Size = new System.Drawing.Size(1132, 410);
            this.DGVAuditoria.TabIndex = 46;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.BtnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.BackgroundImage")));
            this.BtnBuscar.Location = new System.Drawing.Point(562, 18);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(34, 31);
            this.BtnBuscar.TabIndex = 48;
            this.BtnBuscar.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(923, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 53;
            this.label1.Text = "Sector:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(924, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 55;
            this.label2.Text = "Usuario:";
            // 
            // CmbUsuarios
            // 
            this.CmbUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbUsuarios.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbUsuarios.DisplayMember = "ID";
            this.CmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbUsuarios.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUsuarios.FormattingEnabled = true;
            this.CmbUsuarios.Items.AddRange(new object[] {
            "ID",
            "USUARIO",
            "NOMBRE",
            "APELLIDO"});
            this.CmbUsuarios.Location = new System.Drawing.Point(918, 80);
            this.CmbUsuarios.Name = "CmbUsuarios";
            this.CmbUsuarios.Size = new System.Drawing.Size(222, 32);
            this.CmbUsuarios.TabIndex = 54;
            // 
            // DtInicio
            // 
            this.DtInicio.CalendarFont = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtInicio.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicio.Location = new System.Drawing.Point(18, 80);
            this.DtInicio.Name = "DtInicio";
            this.DtInicio.Size = new System.Drawing.Size(200, 33);
            this.DtInicio.TabIndex = 56;
            // 
            // DtFinal
            // 
            this.DtFinal.CalendarFont = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFinal.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFinal.Location = new System.Drawing.Point(254, 80);
            this.DtFinal.Name = "DtFinal";
            this.DtFinal.Size = new System.Drawing.Size(200, 33);
            this.DtFinal.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 58;
            this.label3.Text = "Fecha Inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(258, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 59;
            this.label4.Text = "Fecha Final:";
            // 
            // CmbSector
            // 
            this.CmbSector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSector.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbSector.DisplayMember = "ID";
            this.CmbSector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbSector.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSector.FormattingEnabled = true;
            this.CmbSector.Items.AddRange(new object[] {
            "Catalogos",
            "Contratos ",
            "Ventas",
            "Inventario",
            "Caja",
            "Personal",
            "Seguridad",
            "Opciones"});
            this.CmbSector.Location = new System.Drawing.Point(918, 27);
            this.CmbSector.Name = "CmbSector";
            this.CmbSector.Size = new System.Drawing.Size(222, 32);
            this.CmbSector.TabIndex = 60;
            this.CmbSector.Text = "Catalogos";
            // 
            // BtnTodos
            // 
            this.BtnTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTodos.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnTodos.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnTodos.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnTodos.BorderRadius = 15;
            this.BtnTodos.BorderSize = 0;
            this.BtnTodos.FlatAppearance.BorderSize = 0;
            this.BtnTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTodos.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTodos.ForeColor = System.Drawing.Color.White;
            this.BtnTodos.Location = new System.Drawing.Point(784, 118);
            this.BtnTodos.Name = "BtnTodos";
            this.BtnTodos.Size = new System.Drawing.Size(171, 40);
            this.BtnTodos.TabIndex = 61;
            this.BtnTodos.Text = "Mostrar Todos";
            this.BtnTodos.TextGroundColor = System.Drawing.Color.White;
            this.BtnTodos.UseVisualStyleBackColor = false;
            this.BtnTodos.Click += new System.EventHandler(this.BtnTodos_Click);
            // 
            // BtnReporte
            // 
            this.BtnReporte.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnReporte.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnReporte.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnReporte.BorderRadius = 15;
            this.BtnReporte.BorderSize = 0;
            this.BtnReporte.FlatAppearance.BorderSize = 0;
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporte.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReporte.ForeColor = System.Drawing.Color.White;
            this.BtnReporte.Location = new System.Drawing.Point(12, 120);
            this.BtnReporte.Name = "BtnReporte";
            this.BtnReporte.Size = new System.Drawing.Size(206, 40);
            this.BtnReporte.TabIndex = 51;
            this.BtnReporte.Text = "Reporte Detallado";
            this.BtnReporte.TextGroundColor = System.Drawing.Color.White;
            this.BtnReporte.UseVisualStyleBackColor = false;
            // 
            // BtnBuscarUser
            // 
            this.BtnBuscarUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscarUser.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnBuscarUser.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnBuscarUser.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnBuscarUser.BorderRadius = 15;
            this.BtnBuscarUser.BorderSize = 0;
            this.BtnBuscarUser.FlatAppearance.BorderSize = 0;
            this.BtnBuscarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarUser.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarUser.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarUser.Location = new System.Drawing.Point(970, 118);
            this.BtnBuscarUser.Name = "BtnBuscarUser";
            this.BtnBuscarUser.Size = new System.Drawing.Size(171, 40);
            this.BtnBuscarUser.TabIndex = 50;
            this.BtnBuscarUser.Text = "Buscar";
            this.BtnBuscarUser.TextGroundColor = System.Drawing.Color.White;
            this.BtnBuscarUser.UseVisualStyleBackColor = false;
            this.BtnBuscarUser.Click += new System.EventHandler(this.BtnBuscarUser_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BackGroundColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCancelar.BorderRadius = 40;
            this.BtnCancelar.BorderSize = 0;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelar.Location = new System.Drawing.Point(613, 13);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(150, 40);
            this.BtnCancelar.TabIndex = 49;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextGroundColor = System.Drawing.Color.Black;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // txtFiltroUsuario
            // 
            this.txtFiltroUsuario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtFiltroUsuario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltroUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltroUsuario.BorderRadius = 15;
            this.txtFiltroUsuario.BorderSize = 1;
            this.txtFiltroUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltroUsuario.Location = new System.Drawing.Point(11, 13);
            this.txtFiltroUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroUsuario.Multilinea = false;
            this.txtFiltroUsuario.Name = "txtFiltroUsuario";
            this.txtFiltroUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltroUsuario.PasswordChar = false;
            this.txtFiltroUsuario.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltroUsuario.PlaceHolderText = "Buscar...";
            this.txtFiltroUsuario.Size = new System.Drawing.Size(595, 40);
            this.txtFiltroUsuario.TabIndex = 47;
            this.txtFiltroUsuario.Texts = "";
            this.txtFiltroUsuario.UnderLineFlat = false;
            // 
            // PnlPrincipalAuditorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.BtnTodos);
            this.Controls.Add(this.CmbSector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtFinal);
            this.Controls.Add(this.DtInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbUsuarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnReporte);
            this.Controls.Add(this.BtnBuscarUser);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.txtFiltroUsuario);
            this.Controls.Add(this.DGVAuditoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlPrincipalAuditorias";
            this.Text = " cfvc";
            this.Load += new System.EventHandler(this.PnlPrincipalAuditorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAuditoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVAuditoria;
        private Especiales.EspecialButton BtnCancelar;
        private System.Windows.Forms.PictureBox BtnBuscar;
        private Controladores.LoginUserControl txtFiltroUsuario;
        private Especiales.EspecialButton BtnBuscarUser;
        private Especiales.EspecialButton BtnReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CmbUsuarios;
        private System.Windows.Forms.DateTimePicker DtInicio;
        private System.Windows.Forms.DateTimePicker DtFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox CmbSector;
        private Especiales.EspecialButton BtnTodos;
    }
}