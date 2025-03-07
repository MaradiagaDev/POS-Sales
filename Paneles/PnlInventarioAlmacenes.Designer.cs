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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlInventarioAlmacenes));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbAlmacenes = new System.Windows.Forms.ComboBox();
            this.CmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnListaMermas = new NeoCobranza.Especiales.EspecialButton();
            this.BtnBuscarCliente = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.TxtFiltrar = new System.Windows.Forms.TextBox();
            this.BtnExcel = new NeoCobranza.Especiales.EspecialButton();
            this.flowLayoutPanelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlPaginado = new System.Windows.Forms.Panel();
            this.TxtPaginaDe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPaginaNo = new System.Windows.Forms.TextBox();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.PnlTitulo.SuspendLayout();
            this.PnlPaginado.SuspendLayout();
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
            this.BtnListaMermas.Location = new System.Drawing.Point(564, 461);
            this.BtnListaMermas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnListaMermas.Name = "BtnListaMermas";
            this.BtnListaMermas.Size = new System.Drawing.Size(185, 38);
            this.BtnListaMermas.TabIndex = 155;
            this.BtnListaMermas.Text = "Ajustes";
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
            // BtnExcel
            // 
            this.BtnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExcel.BackColor = System.Drawing.Color.White;
            this.BtnExcel.BackGroundColor = System.Drawing.Color.White;
            this.BtnExcel.BorderColor = System.Drawing.Color.Green;
            this.BtnExcel.BorderRadius = 5;
            this.BtnExcel.BorderSize = 1;
            this.BtnExcel.FlatAppearance.BorderSize = 0;
            this.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BtnExcel.ForeColor = System.Drawing.Color.DimGray;
            this.BtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcel.Image")));
            this.BtnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcel.Location = new System.Drawing.Point(756, 460);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(238, 38);
            this.BtnExcel.TabIndex = 160;
            this.BtnExcel.Text = "Documento Excel";
            this.BtnExcel.TextGroundColor = System.Drawing.Color.DimGray;
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click_1);
            // 
            // flowLayoutPanelProductos
            // 
            this.flowLayoutPanelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelProductos.Location = new System.Drawing.Point(12, 82);
            this.flowLayoutPanelProductos.Name = "flowLayoutPanelProductos";
            this.flowLayoutPanelProductos.Size = new System.Drawing.Size(1224, 370);
            this.flowLayoutPanelProductos.TabIndex = 161;
            this.flowLayoutPanelProductos.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelProductos_Paint);
            // 
            // PnlPaginado
            // 
            this.PnlPaginado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PnlPaginado.Controls.Add(this.TxtPaginaDe);
            this.PnlPaginado.Controls.Add(this.label4);
            this.PnlPaginado.Controls.Add(this.label3);
            this.PnlPaginado.Controls.Add(this.TxtPaginaNo);
            this.PnlPaginado.Controls.Add(this.BtnAnterior);
            this.PnlPaginado.Controls.Add(this.BtnSiguiente);
            this.PnlPaginado.Location = new System.Drawing.Point(12, 456);
            this.PnlPaginado.Name = "PnlPaginado";
            this.PnlPaginado.Size = new System.Drawing.Size(545, 47);
            this.PnlPaginado.TabIndex = 162;
            // 
            // TxtPaginaDe
            // 
            this.TxtPaginaDe.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaginaDe.Location = new System.Drawing.Point(468, 11);
            this.TxtPaginaDe.Name = "TxtPaginaDe";
            this.TxtPaginaDe.ReadOnly = true;
            this.TxtPaginaDe.Size = new System.Drawing.Size(62, 27);
            this.TxtPaginaDe.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(430, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "De";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(261, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pagina No:";
            // 
            // TxtPaginaNo
            // 
            this.TxtPaginaNo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaginaNo.Location = new System.Drawing.Point(362, 11);
            this.TxtPaginaNo.Name = "TxtPaginaNo";
            this.TxtPaginaNo.ReadOnly = true;
            this.TxtPaginaNo.Size = new System.Drawing.Size(62, 27);
            this.TxtPaginaNo.TabIndex = 2;
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.BackColor = System.Drawing.SystemColors.ControlText;
            this.BtnAnterior.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnterior.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAnterior.Location = new System.Drawing.Point(4, 3);
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.Size = new System.Drawing.Size(118, 41);
            this.BtnAnterior.TabIndex = 1;
            this.BtnAnterior.Text = "Anterior";
            this.BtnAnterior.UseVisualStyleBackColor = false;
            this.BtnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnSiguiente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSiguiente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSiguiente.Location = new System.Drawing.Point(127, 3);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(118, 41);
            this.BtnSiguiente.TabIndex = 0;
            this.BtnSiguiente.Text = "Siguiente";
            this.BtnSiguiente.UseVisualStyleBackColor = false;
            this.BtnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // PnlInventarioAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1250, 549);
            this.Controls.Add(this.PnlPaginado);
            this.Controls.Add(this.flowLayoutPanelProductos);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.especialButton1);
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
            this.PnlPaginado.ResumeLayout(false);
            this.PnlPaginado.PerformLayout();
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
        public Especiales.EspecialButton especialButton1;
        public System.Windows.Forms.TextBox TxtFiltrar;
        public Especiales.EspecialButton BtnExcel;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProductos;
        public System.Windows.Forms.Panel PnlPaginado;
        public System.Windows.Forms.TextBox TxtPaginaDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TxtPaginaNo;
        public System.Windows.Forms.Button BtnAnterior;
        public System.Windows.Forms.Button BtnSiguiente;
    }
}