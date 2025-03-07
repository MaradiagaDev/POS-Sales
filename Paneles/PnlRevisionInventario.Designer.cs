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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlRevisionInventario));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.CmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSucursales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFiltrar = new System.Windows.Forms.TextBox();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnBuscarCliente = new NeoCobranza.Especiales.EspecialButton();
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
            // TxtFiltrar
            // 
            this.TxtFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFiltrar.Location = new System.Drawing.Point(12, 19);
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Size = new System.Drawing.Size(354, 20);
            this.TxtFiltrar.TabIndex = 158;
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
            this.especialButton1.Location = new System.Drawing.Point(874, 434);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(238, 38);
            this.especialButton1.TabIndex = 147;
            this.especialButton1.Text = "Documento Pdf";
            this.especialButton1.TextGroundColor = System.Drawing.Color.DimGray;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
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
            this.BtnExcel.Location = new System.Drawing.Point(630, 435);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(238, 38);
            this.BtnExcel.TabIndex = 159;
            this.BtnExcel.Text = "Documento Excel";
            this.BtnExcel.TextGroundColor = System.Drawing.Color.DimGray;
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // flowLayoutPanelProductos
            // 
            this.flowLayoutPanelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelProductos.Location = new System.Drawing.Point(14, 66);
            this.flowLayoutPanelProductos.Name = "flowLayoutPanelProductos";
            this.flowLayoutPanelProductos.Size = new System.Drawing.Size(1098, 361);
            this.flowLayoutPanelProductos.TabIndex = 162;
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
            this.PnlPaginado.Location = new System.Drawing.Point(14, 430);
            this.PnlPaginado.Name = "PnlPaginado";
            this.PnlPaginado.Size = new System.Drawing.Size(545, 47);
            this.PnlPaginado.TabIndex = 163;
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
            // PnlRevisionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.PnlPaginado);
            this.Controls.Add(this.flowLayoutPanelProductos);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbSucursales);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.CmbBuscarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlRevisionInventario";
            this.Text = "PnlRevisionInventario";
            this.Load += new System.EventHandler(this.PnlRevisionInventario_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PnlRevisionInventario_KeyPress);
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
        public System.Windows.Forms.ComboBox CmbBuscarPor;
        public System.Windows.Forms.Label label1;
        public Especiales.EspecialButton especialButton1;
        public System.Windows.Forms.ComboBox CmbSucursales;
        public System.Windows.Forms.Label label2;
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