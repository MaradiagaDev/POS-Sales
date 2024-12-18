namespace NeoCobranza.Paneles
{
    partial class PnlCatalogoClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlCatalogoClientes));
            this.dgvCatalogoClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.PnlPaginado = new System.Windows.Forms.Panel();
            this.TxtPaginaDe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPaginaNo = new System.Windows.Forms.TextBox();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.TxtFiltrar = new System.Windows.Forms.TextBox();
            this.CmbSucursal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnBuscarCliente = new NeoCobranza.Especiales.EspecialButton();
            this.btnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoClientes)).BeginInit();
            this.PnlTitulo.SuspendLayout();
            this.PnlPaginado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCatalogoClientes
            // 
            this.dgvCatalogoClientes.AllowUserToAddRows = false;
            this.dgvCatalogoClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogoClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogoClientes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCatalogoClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogoClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCatalogoClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogoClientes.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogoClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogoClientes.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogoClientes.Location = new System.Drawing.Point(12, 86);
            this.dgvCatalogoClientes.Name = "dgvCatalogoClientes";
            this.dgvCatalogoClientes.ReadOnly = true;
            this.dgvCatalogoClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogoClientes.RowHeadersWidth = 15;
            this.dgvCatalogoClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogoClientes.Size = new System.Drawing.Size(1117, 358);
            this.dgvCatalogoClientes.TabIndex = 1;
            this.dgvCatalogoClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogoClientes_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(499, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 101;
            this.label1.Text = "Buscar Por:";
            // 
            // CmbBuscarPor
            // 
            this.CmbBuscarPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbBuscarPor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBuscarPor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBuscarPor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbBuscarPor.FormattingEnabled = true;
            this.CmbBuscarPor.Location = new System.Drawing.Point(502, 38);
            this.CmbBuscarPor.Name = "CmbBuscarPor";
            this.CmbBuscarPor.Size = new System.Drawing.Size(223, 29);
            this.CmbBuscarPor.TabIndex = 102;
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-1, 518);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1144, 44);
            this.PnlTitulo.TabIndex = 104;
            // 
            // TbTitulo
            // 
            this.TbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbTitulo.AutoSize = true;
            this.TbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbTitulo.Location = new System.Drawing.Point(4, 3);
            this.TbTitulo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TbTitulo.Name = "TbTitulo";
            this.TbTitulo.Size = new System.Drawing.Size(305, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Catálogo de Clientes";
            // 
            // PnlPaginado
            // 
            this.PnlPaginado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PnlPaginado.Controls.Add(this.TxtPaginaDe);
            this.PnlPaginado.Controls.Add(this.label4);
            this.PnlPaginado.Controls.Add(this.label2);
            this.PnlPaginado.Controls.Add(this.TxtPaginaNo);
            this.PnlPaginado.Controls.Add(this.BtnAnterior);
            this.PnlPaginado.Controls.Add(this.BtnSiguiente);
            this.PnlPaginado.Location = new System.Drawing.Point(16, 454);
            this.PnlPaginado.Name = "PnlPaginado";
            this.PnlPaginado.Size = new System.Drawing.Size(545, 47);
            this.PnlPaginado.TabIndex = 106;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pagina No:";
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
            // TxtFiltrar
            // 
            this.TxtFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFiltrar.Location = new System.Drawing.Point(9, 40);
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Size = new System.Drawing.Size(483, 20);
            this.TxtFiltrar.TabIndex = 107;
            // 
            // CmbSucursal
            // 
            this.CmbSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSucursal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbSucursal.FormattingEnabled = true;
            this.CmbSucursal.Location = new System.Drawing.Point(731, 38);
            this.CmbSucursal.Name = "CmbSucursal";
            this.CmbSucursal.Size = new System.Drawing.Size(208, 29);
            this.CmbSucursal.TabIndex = 109;
            this.CmbSucursal.SelectedIndexChanged += new System.EventHandler(this.CmbSucursal_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(728, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 108;
            this.label5.Text = "Sucursal:";
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
            this.BtnBuscarCliente.Location = new System.Drawing.Point(954, 32);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(148, 38);
            this.BtnBuscarCliente.TabIndex = 103;
            this.BtnBuscarCliente.Text = "Buscar";
            this.BtnBuscarCliente.TextGroundColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.UseVisualStyleBackColor = false;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.btnActualizar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.btnActualizar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnActualizar.BorderRadius = 5;
            this.btnActualizar.BorderSize = 0;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(935, 463);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(193, 38);
            this.btnActualizar.TabIndex = 67;
            this.btnActualizar.Text = "Actualizar Cliente";
            this.btnActualizar.TextGroundColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.BackGroundColor = System.Drawing.Color.Green;
            this.btnAgregar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAgregar.BorderRadius = 5;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(715, 463);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(203, 38);
            this.btnAgregar.TabIndex = 66;
            this.btnAgregar.Text = "Insertar Cliente";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // PnlCatalogoClientes
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.CmbSucursal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.PnlPaginado);
            this.Controls.Add(this.PnlTitulo);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.CmbBuscarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvCatalogoClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCatalogoClientes";
            this.Load += new System.EventHandler(this.PnlCatalogoClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoClientes)).EndInit();
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.PnlPaginado.ResumeLayout(false);
            this.PnlPaginado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvCliente;
        private Controladores.LoginUserControl txtFiltro;
        private Especiales.EspecialButton btnAgregar;
        private Especiales.EspecialButton btnActualizar;
        public System.Windows.Forms.DataGridView dgvCatalogoClientes;
        public System.Windows.Forms.Label label1;
        private Especiales.EspecialButton BtnBuscarCliente;
        public System.Windows.Forms.ComboBox CmbBuscarPor;
        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.Panel PnlPaginado;
        public System.Windows.Forms.TextBox TxtPaginaDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TxtPaginaNo;
        public System.Windows.Forms.Button BtnAnterior;
        public System.Windows.Forms.Button BtnSiguiente;
        public System.Windows.Forms.TextBox TxtFiltrar;
        public System.Windows.Forms.ComboBox CmbSucursal;
        public System.Windows.Forms.Label label5;
    }
}