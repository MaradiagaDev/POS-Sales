namespace NeoCobranza.Paneles
{
    partial class PnlCatologoTiposServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlCatologoTiposServicios));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.dgvCatalogoTipos = new System.Windows.Forms.DataGridView();
            this.BtnBuscarCliente = new NeoCobranza.Especiales.EspecialButton();
            this.btnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtFiltrar = new NeoCobranza.Controladores.LoginUserControl();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoTipos)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-2, 518);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1144, 44);
            this.PnlTitulo.TabIndex = 113;
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
            this.TbTitulo.Size = new System.Drawing.Size(415, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Catálogo de Tipos de Servicio";
            // 
            // dgvCatalogoTipos
            // 
            this.dgvCatalogoTipos.AllowUserToAddRows = false;
            this.dgvCatalogoTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogoTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogoTipos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCatalogoTipos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCatalogoTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogoTipos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCatalogoTipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoTipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogoTipos.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogoTipos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogoTipos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogoTipos.Location = new System.Drawing.Point(12, 94);
            this.dgvCatalogoTipos.Name = "dgvCatalogoTipos";
            this.dgvCatalogoTipos.ReadOnly = true;
            this.dgvCatalogoTipos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoTipos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogoTipos.RowHeadersWidth = 15;
            this.dgvCatalogoTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogoTipos.Size = new System.Drawing.Size(1117, 363);
            this.dgvCatalogoTipos.TabIndex = 115;
            this.dgvCatalogoTipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogoTipos_CellContentClick);
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
            this.BtnBuscarCliente.Location = new System.Drawing.Point(512, 36);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(148, 38);
            this.BtnBuscarCliente.TabIndex = 120;
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
            this.btnActualizar.Location = new System.Drawing.Point(893, 476);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(238, 38);
            this.btnActualizar.TabIndex = 117;
            this.btnActualizar.Text = "Actualizar Tipo";
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
            this.btnAgregar.Location = new System.Drawing.Point(684, 476);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(203, 38);
            this.btnAgregar.TabIndex = 116;
            this.btnAgregar.Text = "Insertar Tipo";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.TxtFiltrar.Location = new System.Drawing.Point(16, 38);
            this.TxtFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFiltrar.Multilinea = false;
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtFiltrar.PasswordChar = false;
            this.TxtFiltrar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.TxtFiltrar.PlaceHolderText = "Buscar Tipo...";
            this.TxtFiltrar.Size = new System.Drawing.Size(465, 36);
            this.TxtFiltrar.TabIndex = 114;
            this.TxtFiltrar.Texts = "";
            this.TxtFiltrar.UnderLineFlat = true;
            // 
            // PnlCatologoTiposServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvCatalogoTipos);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCatologoTiposServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlCatologoTiposServicios";
            this.Load += new System.EventHandler(this.PnlCatologoTiposServicios_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoTipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        private Especiales.EspecialButton BtnBuscarCliente;
        private Especiales.EspecialButton btnActualizar;
        private Especiales.EspecialButton btnAgregar;
        public System.Windows.Forms.DataGridView dgvCatalogoTipos;
        public Controladores.LoginUserControl TxtFiltrar;
    }
}