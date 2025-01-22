namespace NeoCobranza.Paneles_Venta
{
    partial class frmAgregarProductosServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.TxtCantidadProducto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DgvProductos = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.CmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.BtnVolver = new NeoCobranza.Especiales.EspecialButton();
            this.TxtBuscarProductos = new NeoCobranza.Controladores.LoginUserControl();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.llbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(0, 511);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1161, 44);
            this.PnlTitulo.TabIndex = 138;
            // 
            // llbTitulo
            // 
            this.llbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.llbTitulo.Location = new System.Drawing.Point(12, 5);
            this.llbTitulo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(22, 33);
            this.llbTitulo.TabIndex = 1;
            this.llbTitulo.Text = ".";
            // 
            // TxtCantidadProducto
            // 
            this.TxtCantidadProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCantidadProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidadProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadProducto.Location = new System.Drawing.Point(1029, 84);
            this.TxtCantidadProducto.MaxLength = 6;
            this.TxtCantidadProducto.Name = "TxtCantidadProducto";
            this.TxtCantidadProducto.Size = new System.Drawing.Size(100, 26);
            this.TxtCantidadProducto.TabIndex = 152;
            this.TxtCantidadProducto.Text = "1";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(856, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 19);
            this.label8.TabIndex = 148;
            this.label8.Text = "Cantidad a Agregar";
            // 
            // DgvProductos
            // 
            this.DgvProductos.AllowUserToAddRows = false;
            this.DgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProductos.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvProductos.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.DgvProductos.Location = new System.Drawing.Point(14, 139);
            this.DgvProductos.MultiSelect = false;
            this.DgvProductos.Name = "DgvProductos";
            this.DgvProductos.ReadOnly = true;
            this.DgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvProductos.RowHeadersWidth = 15;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProductos.Size = new System.Drawing.Size(1132, 352);
            this.DgvProductos.TabIndex = 150;
            this.DgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductos_CellContentClick);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(77)))), ((int)(((byte)(97)))));
            this.panel9.Controls.Add(this.CmbTipoServicio);
            this.panel9.Controls.Add(this.label30);
            this.panel9.Location = new System.Drawing.Point(5, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1148, 56);
            this.panel9.TabIndex = 147;
            // 
            // CmbTipoServicio
            // 
            this.CmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoServicio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoServicio.FormattingEnabled = true;
            this.CmbTipoServicio.Location = new System.Drawing.Point(258, 15);
            this.CmbTipoServicio.Name = "CmbTipoServicio";
            this.CmbTipoServicio.Size = new System.Drawing.Size(411, 27);
            this.CmbTipoServicio.TabIndex = 138;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label30.Location = new System.Drawing.Point(10, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(242, 19);
            this.label30.TabIndex = 137;
            this.label30.Text = "Seleccione el Tipo de Servicio:";
            // 
            // BtnVolver
            // 
            this.BtnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnVolver.BackColor = System.Drawing.Color.Gray;
            this.BtnVolver.BackGroundColor = System.Drawing.Color.Gray;
            this.BtnVolver.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnVolver.BorderRadius = 5;
            this.BtnVolver.BorderSize = 0;
            this.BtnVolver.FlatAppearance.BorderSize = 0;
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.ForeColor = System.Drawing.Color.White;
            this.BtnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVolver.Location = new System.Drawing.Point(692, 74);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(148, 38);
            this.BtnVolver.TabIndex = 151;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.TextGroundColor = System.Drawing.Color.White;
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // TxtBuscarProductos
            // 
            this.TxtBuscarProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBuscarProductos.BorderColor = System.Drawing.Color.Silver;
            this.TxtBuscarProductos.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtBuscarProductos.BorderRadius = 0;
            this.TxtBuscarProductos.BorderSize = 2;
            this.TxtBuscarProductos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscarProductos.ForeColor = System.Drawing.Color.DimGray;
            this.TxtBuscarProductos.Location = new System.Drawing.Point(30, 77);
            this.TxtBuscarProductos.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBuscarProductos.Multilinea = false;
            this.TxtBuscarProductos.Name = "TxtBuscarProductos";
            this.TxtBuscarProductos.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtBuscarProductos.PasswordChar = false;
            this.TxtBuscarProductos.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.TxtBuscarProductos.PlaceHolderText = "Buscar...";
            this.TxtBuscarProductos.Size = new System.Drawing.Size(627, 36);
            this.TxtBuscarProductos.TabIndex = 149;
            this.TxtBuscarProductos.Texts = "";
            this.TxtBuscarProductos.UnderLineFlat = true;
            this.TxtBuscarProductos._TextChanged += new System.EventHandler(this.TxtBuscarProductos__TextChanged);
            // 
            // frmAgregarProductosServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1158, 555);
            this.Controls.Add(this.TxtCantidadProducto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DgvProductos);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.BtnVolver);
            this.Controls.Add(this.TxtBuscarProductos);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarProductosServicios";
            this.Text = "frmAgregarProductosServicios";
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label llbTitulo;
        private System.Windows.Forms.TextBox TxtCantidadProducto;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView DgvProductos;
        private System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.ComboBox CmbTipoServicio;
        private System.Windows.Forms.Label label30;
        public Especiales.EspecialButton BtnVolver;
        public Controladores.LoginUserControl TxtBuscarProductos;
    }
}