namespace NeoCobranza.Paneles
{
    partial class PnlAgregarProductosOrden
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvItemsOrden = new System.Windows.Forms.DataGridView();
            this.TxtAlmacen = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCodigoProducto = new System.Windows.Forms.TextBox();
            this.TxtCantidad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCantidadAgregar = new System.Windows.Forms.TextBox();
            this.PnlPaginado = new System.Windows.Forms.Panel();
            this.TxtPaginaDe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPaginaNo = new System.Windows.Forms.TextBox();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.PnlProducto = new System.Windows.Forms.Panel();
            this.PBProducto = new System.Windows.Forms.PictureBox();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemsOrden)).BeginInit();
            this.PnlPaginado.SuspendLayout();
            this.PnlProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvItemsOrden
            // 
            this.DgvItemsOrden.AllowUserToAddRows = false;
            this.DgvItemsOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvItemsOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvItemsOrden.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvItemsOrden.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItemsOrden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvItemsOrden.ColumnHeadersHeight = 30;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvItemsOrden.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvItemsOrden.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.DgvItemsOrden.Location = new System.Drawing.Point(9, 128);
            this.DgvItemsOrden.Name = "DgvItemsOrden";
            this.DgvItemsOrden.ReadOnly = true;
            this.DgvItemsOrden.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItemsOrden.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvItemsOrden.RowHeadersWidth = 15;
            this.DgvItemsOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvItemsOrden.Size = new System.Drawing.Size(557, 276);
            this.DgvItemsOrden.TabIndex = 158;
            this.DgvItemsOrden.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItemsOrden_CellContentClick_1);
            // 
            // TxtAlmacen
            // 
            this.TxtAlmacen.AutoSize = true;
            this.TxtAlmacen.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TxtAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAlmacen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TxtAlmacen.Location = new System.Drawing.Point(2, 2);
            this.TxtAlmacen.Name = "TxtAlmacen";
            this.TxtAlmacen.Padding = new System.Windows.Forms.Padding(10);
            this.TxtAlmacen.Size = new System.Drawing.Size(141, 44);
            this.TxtAlmacen.TabIndex = 161;
            this.TxtAlmacen.Text = "TxtAlmacen";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.AutoSize = true;
            this.TxtPrecio.BackColor = System.Drawing.Color.Transparent;
            this.TxtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecio.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TxtPrecio.Location = new System.Drawing.Point(7, 307);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Padding = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.TxtPrecio.Size = new System.Drawing.Size(84, 44);
            this.TxtPrecio.TabIndex = 162;
            this.TxtPrecio.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(356, 19);
            this.label4.TabIndex = 185;
            this.label4.Text = "Buscar (Código de Barra / Nombre Producto)";
            // 
            // TxtCodigoProducto
            // 
            this.TxtCodigoProducto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtCodigoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCodigoProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.TxtCodigoProducto.ForeColor = System.Drawing.Color.Black;
            this.TxtCodigoProducto.Location = new System.Drawing.Point(12, 95);
            this.TxtCodigoProducto.Name = "TxtCodigoProducto";
            this.TxtCodigoProducto.Size = new System.Drawing.Size(547, 27);
            this.TxtCodigoProducto.TabIndex = 184;
            this.TxtCodigoProducto.TextChanged += new System.EventHandler(this.TxtCodigoProducto_TextChanged);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.AutoSize = true;
            this.TxtCantidad.BackColor = System.Drawing.Color.Transparent;
            this.TxtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TxtCantidad.Location = new System.Drawing.Point(7, 350);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Padding = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.TxtCantidad.Size = new System.Drawing.Size(99, 44);
            this.TxtCantidad.TabIndex = 188;
            this.TxtCantidad.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(15, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 25);
            this.label6.TabIndex = 190;
            this.label6.Text = "Cantidad a Agregar";
            // 
            // TxtCantidadAgregar
            // 
            this.TxtCantidadAgregar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtCantidadAgregar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidadAgregar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadAgregar.ForeColor = System.Drawing.Color.Black;
            this.TxtCantidadAgregar.Location = new System.Drawing.Point(16, 498);
            this.TxtCantidadAgregar.Name = "TxtCantidadAgregar";
            this.TxtCantidadAgregar.Size = new System.Drawing.Size(244, 33);
            this.TxtCantidadAgregar.TabIndex = 189;
            this.TxtCantidadAgregar.Text = "1";
            this.TxtCantidadAgregar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PnlPaginado
            // 
            this.PnlPaginado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PnlPaginado.Controls.Add(this.TxtPaginaDe);
            this.PnlPaginado.Controls.Add(this.label1);
            this.PnlPaginado.Controls.Add(this.label2);
            this.PnlPaginado.Controls.Add(this.TxtPaginaNo);
            this.PnlPaginado.Controls.Add(this.BtnAnterior);
            this.PnlPaginado.Controls.Add(this.BtnSiguiente);
            this.PnlPaginado.Location = new System.Drawing.Point(9, 409);
            this.PnlPaginado.Name = "PnlPaginado";
            this.PnlPaginado.Size = new System.Drawing.Size(557, 47);
            this.PnlPaginado.TabIndex = 192;
            // 
            // TxtPaginaDe
            // 
            this.TxtPaginaDe.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaginaDe.Location = new System.Drawing.Point(473, 11);
            this.TxtPaginaDe.Name = "TxtPaginaDe";
            this.TxtPaginaDe.ReadOnly = true;
            this.TxtPaginaDe.Size = new System.Drawing.Size(76, 27);
            this.TxtPaginaDe.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pagina No:";
            // 
            // TxtPaginaNo
            // 
            this.TxtPaginaNo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaginaNo.Location = new System.Drawing.Point(334, 11);
            this.TxtPaginaNo.Name = "TxtPaginaNo";
            this.TxtPaginaNo.ReadOnly = true;
            this.TxtPaginaNo.Size = new System.Drawing.Size(76, 27);
            this.TxtPaginaNo.TabIndex = 2;
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.BackColor = System.Drawing.SystemColors.ControlText;
            this.BtnAnterior.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnterior.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAnterior.Location = new System.Drawing.Point(4, 3);
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.Size = new System.Drawing.Size(100, 41);
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
            this.BtnSiguiente.Location = new System.Drawing.Point(101, 3);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(100, 41);
            this.BtnSiguiente.TabIndex = 0;
            this.BtnSiguiente.Text = "Siguiente";
            this.BtnSiguiente.UseVisualStyleBackColor = false;
            this.BtnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // PnlProducto
            // 
            this.PnlProducto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlProducto.Controls.Add(this.PBProducto);
            this.PnlProducto.Controls.Add(this.TxtCantidad);
            this.PnlProducto.Controls.Add(this.TxtPrecio);
            this.PnlProducto.Location = new System.Drawing.Point(575, 52);
            this.PnlProducto.Name = "PnlProducto";
            this.PnlProducto.Size = new System.Drawing.Size(318, 404);
            this.PnlProducto.TabIndex = 193;
            // 
            // PBProducto
            // 
            this.PBProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBProducto.Location = new System.Drawing.Point(-1, -1);
            this.PBProducto.Name = "PBProducto";
            this.PBProducto.Size = new System.Drawing.Size(318, 213);
            this.PBProducto.TabIndex = 189;
            this.PBProducto.TabStop = false;
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.especialButton1.BackColor = System.Drawing.Color.Maroon;
            this.especialButton1.BackGroundColor = System.Drawing.Color.Maroon;
            this.especialButton1.BorderColor = System.Drawing.Color.Transparent;
            this.especialButton1.BorderRadius = 0;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.especialButton1.Location = new System.Drawing.Point(852, 8);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(41, 38);
            this.especialButton1.TabIndex = 191;
            this.especialButton1.Text = "X";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnCancelar.BorderColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BorderRadius = 0;
            this.BtnCancelar.BorderSize = 0;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(489, 482);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(199, 49);
            this.BtnCancelar.TabIndex = 187;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAgregar.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnAgregar.BackGroundColor = System.Drawing.Color.DarkGreen;
            this.BtnAgregar.BorderColor = System.Drawing.Color.Transparent;
            this.BtnAgregar.BorderRadius = 0;
            this.BtnAgregar.BorderSize = 0;
            this.BtnAgregar.FlatAppearance.BorderSize = 0;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.Color.White;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(694, 482);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(199, 49);
            this.BtnAgregar.TabIndex = 186;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(583, 273);
            this.TxtNombre.Multiline = true;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(305, 74);
            this.TxtNombre.TabIndex = 194;
            // 
            // PnlAgregarProductosOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 543);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.PnlProducto);
            this.Controls.Add(this.PnlPaginado);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtCantidadAgregar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtCodigoProducto);
            this.Controls.Add(this.TxtAlmacen);
            this.Controls.Add(this.DgvItemsOrden);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(905, 543);
            this.MinimumSize = new System.Drawing.Size(905, 543);
            this.Name = "PnlAgregarProductosOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlAgregarProductosOrden";
            this.Load += new System.EventHandler(this.PnlAgregarProductosOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvItemsOrden)).EndInit();
            this.PnlPaginado.ResumeLayout(false);
            this.PnlPaginado.PerformLayout();
            this.PnlProducto.ResumeLayout(false);
            this.PnlProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DgvItemsOrden;
        private System.Windows.Forms.Label TxtAlmacen;
        private System.Windows.Forms.Label TxtPrecio;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtCodigoProducto;
        private Especiales.EspecialButton BtnAgregar;
        private Especiales.EspecialButton BtnCancelar;
        private System.Windows.Forms.Label TxtCantidad;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TxtCantidadAgregar;
        private Especiales.EspecialButton especialButton1;
        public System.Windows.Forms.Panel PnlPaginado;
        public System.Windows.Forms.TextBox TxtPaginaDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TxtPaginaNo;
        public System.Windows.Forms.Button BtnAnterior;
        public System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.Panel PnlProducto;
        private System.Windows.Forms.PictureBox PBProducto;
        public System.Windows.Forms.TextBox TxtNombre;
    }
}