namespace NeoCobranza.Paneles
{
    partial class PnlRevisionInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlRevisionInventario));
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.CmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSucursales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.especialButton2 = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnBuscarCliente = new NeoCobranza.Especiales.EspecialButton();
            this.btnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtFiltrar = new NeoCobranza.Controladores.LoginUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.PnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCatalogo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogo.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogo.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogo.Location = new System.Drawing.Point(4, 81);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogo.RowHeadersWidth = 15;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(1117, 343);
            this.dgvCatalogo.TabIndex = 141;
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-1, 479);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1129, 44);
            this.PnlTitulo.TabIndex = 139;
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
            this.TbTitulo.Size = new System.Drawing.Size(265, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Inventario General";
            // 
            // CmbBuscarPor
            // 
            this.CmbBuscarPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbBuscarPor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbBuscarPor.DisplayMember = "Descripcion";
            this.CmbBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBuscarPor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBuscarPor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbBuscarPor.FormattingEnabled = true;
            this.CmbBuscarPor.Location = new System.Drawing.Point(550, 31);
            this.CmbBuscarPor.Name = "CmbBuscarPor";
            this.CmbBuscarPor.Size = new System.Drawing.Size(272, 29);
            this.CmbBuscarPor.TabIndex = 146;
            this.CmbBuscarPor.SelectedIndexChanged += new System.EventHandler(this.CmbBuscarPor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(547, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 145;
            this.label1.Text = "Tipo Producto:";
            // 
            // CmbSucursales
            // 
            this.CmbSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSucursales.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursales.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbSucursales.FormattingEnabled = true;
            this.CmbSucursales.Location = new System.Drawing.Point(841, 31);
            this.CmbSucursales.Name = "CmbSucursales";
            this.CmbSucursales.Size = new System.Drawing.Size(272, 29);
            this.CmbSucursales.TabIndex = 149;
            this.CmbSucursales.SelectedIndexChanged += new System.EventHandler(this.CmbSucursales_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(838, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 150;
            this.label2.Text = "Sucursal:";
            // 
            // especialButton2
            // 
            this.especialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.especialButton2.BackColor = System.Drawing.Color.White;
            this.especialButton2.BackGroundColor = System.Drawing.Color.White;
            this.especialButton2.BorderColor = System.Drawing.Color.Red;
            this.especialButton2.BorderRadius = 5;
            this.especialButton2.BorderSize = 1;
            this.especialButton2.FlatAppearance.BorderSize = 0;
            this.especialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.especialButton2.ForeColor = System.Drawing.Color.DimGray;
            this.especialButton2.Image = ((System.Drawing.Image)(resources.GetObject("especialButton2.Image")));
            this.especialButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton2.Location = new System.Drawing.Point(372, 435);
            this.especialButton2.Name = "especialButton2";
            this.especialButton2.Size = new System.Drawing.Size(238, 38);
            this.especialButton2.TabIndex = 148;
            this.especialButton2.Text = "Ticket Pdf";
            this.especialButton2.TextGroundColor = System.Drawing.Color.DimGray;
            this.especialButton2.UseVisualStyleBackColor = false;
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.especialButton1.BackColor = System.Drawing.Color.White;
            this.especialButton1.BackGroundColor = System.Drawing.Color.White;
            this.especialButton1.BorderColor = System.Drawing.Color.Red;
            this.especialButton1.BorderRadius = 5;
            this.especialButton1.BorderSize = 1;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.especialButton1.ForeColor = System.Drawing.Color.DimGray;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(625, 435);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(238, 38);
            this.especialButton1.TabIndex = 147;
            this.especialButton1.Text = "Documento Pdf";
            this.especialButton1.TextGroundColor = System.Drawing.Color.DimGray;
            this.especialButton1.UseVisualStyleBackColor = false;
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnBuscarCliente.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnBuscarCliente.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnBuscarCliente.BorderRadius = 5;
            this.BtnBuscarCliente.BorderSize = 0;
            this.BtnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.BtnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscarCliente.Image")));
            this.BtnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscarCliente.Location = new System.Drawing.Point(372, 15);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(148, 38);
            this.BtnBuscarCliente.TabIndex = 144;
            this.BtnBuscarCliente.Text = "Buscar";
            this.BtnBuscarCliente.TextGroundColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.UseVisualStyleBackColor = false;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnActualizar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnActualizar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnActualizar.BorderRadius = 5;
            this.btnActualizar.BorderSize = 0;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(875, 435);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(238, 38);
            this.btnActualizar.TabIndex = 143;
            this.btnActualizar.Text = "Exportar a Excel";
            this.btnActualizar.TextGroundColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // TxtFiltrar
            // 
            this.TxtFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFiltrar.BorderColor = System.Drawing.Color.Silver;
            this.TxtFiltrar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtFiltrar.BorderRadius = 0;
            this.TxtFiltrar.BorderSize = 2;
            this.TxtFiltrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltrar.ForeColor = System.Drawing.Color.DimGray;
            this.TxtFiltrar.Location = new System.Drawing.Point(8, 17);
            this.TxtFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFiltrar.Multilinea = false;
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtFiltrar.PasswordChar = false;
            this.TxtFiltrar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.TxtFiltrar.PlaceHolderText = "Buscar...";
            this.TxtFiltrar.Size = new System.Drawing.Size(349, 36);
            this.TxtFiltrar.TabIndex = 140;
            this.TxtFiltrar.Texts = "";
            this.TxtFiltrar.UnderLineFlat = true;
            // 
            // PnlRevisionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbSucursales);
            this.Controls.Add(this.especialButton2);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.CmbBuscarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvCatalogo);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlRevisionInventario";
            this.Text = "PnlRevisionInventario";
            this.Load += new System.EventHandler(this.PnlRevisionInventario_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PnlRevisionInventario_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Especiales.EspecialButton BtnBuscarCliente;
        public Especiales.EspecialButton btnActualizar;
        public System.Windows.Forms.DataGridView dgvCatalogo;
        public Controladores.LoginUserControl TxtFiltrar;
        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.ComboBox CmbBuscarPor;
        public System.Windows.Forms.Label label1;
        public Especiales.EspecialButton especialButton1;
        public Especiales.EspecialButton especialButton2;
        public System.Windows.Forms.ComboBox CmbSucursales;
        public System.Windows.Forms.Label label2;
    }
}