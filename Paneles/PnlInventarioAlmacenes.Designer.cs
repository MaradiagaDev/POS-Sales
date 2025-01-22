namespace NeoCobranza.Paneles
{
    partial class PnlInventarioAlmacenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlInventarioAlmacenes));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbAlmacenes = new System.Windows.Forms.ComboBox();
            this.CmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.BtnListaMermas = new NeoCobranza.Especiales.EspecialButton();
            this.BtnBuscarCliente = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.TxtFiltrar = new System.Windows.Forms.TextBox();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-17, 506);
            this.PnlTitulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1281, 43);
            this.PnlTitulo.TabIndex = 139;
            // 
            // TbTitulo
            // 
            this.TbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbTitulo.AutoSize = true;
            this.TbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbTitulo.Location = new System.Drawing.Point(23, 3);
            this.TbTitulo.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.TbTitulo.Name = "TbTitulo";
            this.TbTitulo.Size = new System.Drawing.Size(350, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Inventario de Almacenes";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(939, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 154;
            this.label2.Text = "Almacenes:";
            // 
            // CmbAlmacenes
            // 
            this.CmbAlmacenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbAlmacenes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbAlmacenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAlmacenes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAlmacenes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbAlmacenes.FormattingEnabled = true;
            this.CmbAlmacenes.Location = new System.Drawing.Point(942, 40);
            this.CmbAlmacenes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmbAlmacenes.Name = "CmbAlmacenes";
            this.CmbAlmacenes.Size = new System.Drawing.Size(294, 29);
            this.CmbAlmacenes.TabIndex = 153;
            this.CmbAlmacenes.SelectedIndexChanged += new System.EventHandler(this.CmbAlmacenes_SelectedIndexChanged);
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
            this.CmbBuscarPor.Location = new System.Drawing.Point(613, 40);
            this.CmbBuscarPor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmbBuscarPor.Name = "CmbBuscarPor";
            this.CmbBuscarPor.Size = new System.Drawing.Size(286, 29);
            this.CmbBuscarPor.TabIndex = 152;
            this.CmbBuscarPor.SelectedIndexChanged += new System.EventHandler(this.CmbBuscarPor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(610, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 151;
            this.label1.Text = "Tipo Producto:";
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCatalogo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogo.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogo.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogo.Location = new System.Drawing.Point(4, 93);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogo.RowHeadersWidth = 15;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(1241, 360);
            this.dgvCatalogo.TabIndex = 156;
            this.dgvCatalogo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogo_CellContentClick_1);
            // 
            // BtnListaMermas
            // 
            this.BtnListaMermas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnListaMermas.BackColor = System.Drawing.Color.Green;
            this.BtnListaMermas.BackGroundColor = System.Drawing.Color.Green;
            this.BtnListaMermas.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnListaMermas.BorderRadius = 5;
            this.BtnListaMermas.BorderSize = 0;
            this.BtnListaMermas.FlatAppearance.BorderSize = 0;
            this.BtnListaMermas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListaMermas.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnListaMermas.ForeColor = System.Drawing.Color.White;
            this.BtnListaMermas.Image = ((System.Drawing.Image)(resources.GetObject("BtnListaMermas.Image")));
            this.BtnListaMermas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnListaMermas.Location = new System.Drawing.Point(16, 460);
            this.BtnListaMermas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnListaMermas.Name = "BtnListaMermas";
            this.BtnListaMermas.Size = new System.Drawing.Size(282, 38);
            this.BtnListaMermas.TabIndex = 155;
            this.BtnListaMermas.Text = "Lista de Ajustes";
            this.BtnListaMermas.TextGroundColor = System.Drawing.Color.White;
            this.BtnListaMermas.UseVisualStyleBackColor = false;
            this.BtnListaMermas.Click += new System.EventHandler(this.BtnListaMermas_Click);
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
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscarCliente.Image")));
            this.BtnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscarCliente.Location = new System.Drawing.Point(414, 37);
            this.BtnBuscarCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(176, 34);
            this.BtnBuscarCliente.TabIndex = 144;
            this.BtnBuscarCliente.Text = "Buscar";
            this.BtnBuscarCliente.TextGroundColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.UseVisualStyleBackColor = false;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
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
            this.especialButton1.Location = new System.Drawing.Point(1000, 460);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(238, 38);
            this.especialButton1.TabIndex = 158;
            this.especialButton1.Text = "Documento Pdf";
            this.especialButton1.TextGroundColor = System.Drawing.Color.DimGray;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // TxtFiltrar
            // 
            this.TxtFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFiltrar.Location = new System.Drawing.Point(12, 40);
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Size = new System.Drawing.Size(380, 27);
            this.TxtFiltrar.TabIndex = 159;
            // 
            // PnlInventarioAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1250, 549);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.dgvCatalogo);
            this.Controls.Add(this.BtnListaMermas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbAlmacenes);
            this.Controls.Add(this.CmbBuscarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.PnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PnlInventarioAlmacenes";
            this.Text = "PnlInventarioAlmacenes";
            this.Load += new System.EventHandler(this.PnlInventarioAlmacenes_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Especiales.EspecialButton BtnBuscarCliente;
        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CmbAlmacenes;
        public System.Windows.Forms.ComboBox CmbBuscarPor;
        public System.Windows.Forms.Label label1;
        public Especiales.EspecialButton BtnListaMermas;
        public System.Windows.Forms.DataGridView dgvCatalogo;
        public Especiales.EspecialButton especialButton1;
        public System.Windows.Forms.TextBox TxtFiltrar;
    }
}