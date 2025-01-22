namespace NeoCobranza.Paneles
{
    partial class ComprasInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprasInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSucursales = new System.Windows.Forms.ComboBox();
            this.BtnBuscar = new NeoCobranza.Especiales.EspecialButton();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.DgvCatalogo = new System.Windows.Forms.DataGridView();
            this.TxtFiltrar = new NeoCobranza.Controladores.LoginUserControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbAlmacen = new System.Windows.Forms.ComboBox();
            this.LblTipoProducto = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFiltroProducto = new System.Windows.Forms.TextBox();
            this.DgvProductos = new System.Windows.Forms.DataGridView();
            this.TxtCosto = new System.Windows.Forms.TextBox();
            this.BtnAgregarProducto = new NeoCobranza.Especiales.EspecialButton();
            this.LblPrecioVenta = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.TxtMontoTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvCompra = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnAgregarCompra = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCatalogo)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCompra)).BeginInit();
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
            this.PnlTitulo.TabIndex = 122;
            // 
            // TbTitulo
            // 
            this.TbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbTitulo.AutoSize = true;
            this.TbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbTitulo.Location = new System.Drawing.Point(4, 6);
            this.TbTitulo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TbTitulo.Name = "TbTitulo";
            this.TbTitulo.Size = new System.Drawing.Size(309, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Compras de Producto";
            // 
            // TCMain
            // 
            this.TCMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCMain.Controls.Add(this.tabPage1);
            this.TCMain.Controls.Add(this.tabPage2);
            this.TCMain.Location = new System.Drawing.Point(-2, 0);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(1144, 525);
            this.TCMain.TabIndex = 123;
            this.TCMain.SelectedIndexChanged += new System.EventHandler(this.TCMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CmbSucursales);
            this.tabPage1.Controls.Add(this.BtnBuscar);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Controls.Add(this.DgvCatalogo);
            this.tabPage1.Controls.Add(this.TxtFiltrar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1136, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Buscar";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(875, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 157;
            this.label2.Text = "Sucursal:";
            // 
            // CmbSucursales
            // 
            this.CmbSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSucursales.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursales.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbSucursales.FormattingEnabled = true;
            this.CmbSucursales.Location = new System.Drawing.Point(874, 26);
            this.CmbSucursales.Name = "CmbSucursales";
            this.CmbSucursales.Size = new System.Drawing.Size(238, 29);
            this.CmbSucursales.TabIndex = 156;
            this.CmbSucursales.SelectedIndexChanged += new System.EventHandler(this.CmbSucursales_SelectedIndexChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnBuscar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnBuscar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnBuscar.BorderRadius = 5;
            this.BtnBuscar.BorderSize = 0;
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.White;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.Location = new System.Drawing.Point(477, 17);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(148, 38);
            this.BtnBuscar.TabIndex = 155;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextGroundColor = System.Drawing.Color.White;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnAgregar.Location = new System.Drawing.Point(633, 17);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(203, 38);
            this.btnAgregar.TabIndex = 153;
            this.btnAgregar.Text = "Crear Compra";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // DgvCatalogo
            // 
            this.DgvCatalogo.AllowUserToAddRows = false;
            this.DgvCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvCatalogo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvCatalogo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvCatalogo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DgvCatalogo.ColumnHeadersHeight = 30;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCatalogo.DefaultCellStyle = dataGridViewCellStyle17;
            this.DgvCatalogo.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvCatalogo.Location = new System.Drawing.Point(9, 69);
            this.DgvCatalogo.Name = "DgvCatalogo";
            this.DgvCatalogo.ReadOnly = true;
            this.DgvCatalogo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.DgvCatalogo.RowHeadersWidth = 15;
            this.DgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCatalogo.Size = new System.Drawing.Size(1117, 421);
            this.DgvCatalogo.TabIndex = 152;
            this.DgvCatalogo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCatalogo_CellContentClick);
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
            this.TxtFiltrar.Location = new System.Drawing.Point(13, 19);
            this.TxtFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFiltrar.Multilinea = false;
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtFiltrar.PasswordChar = false;
            this.TxtFiltrar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.TxtFiltrar.PlaceHolderText = "Buscar...";
            this.TxtFiltrar.Size = new System.Drawing.Size(440, 36);
            this.TxtFiltrar.TabIndex = 151;
            this.TxtFiltrar.Texts = "";
            this.TxtFiltrar.UnderLineFlat = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.TxtMontoTotal);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DgvCompra);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.BtnAgregarCompra);
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1136, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Crear";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.CmbAlmacen);
            this.panel3.Controls.Add(this.LblTipoProducto);
            this.panel3.Controls.Add(this.TxtDescripcion);
            this.panel3.Controls.Add(this.LblDescripcion);
            this.panel3.Location = new System.Drawing.Point(508, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(622, 122);
            this.panel3.TabIndex = 167;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 168;
            this.label1.Text = "DATOS GENERALES";
            // 
            // CmbAlmacen
            // 
            this.CmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbAlmacen.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbAlmacen.FormattingEnabled = true;
            this.CmbAlmacen.Location = new System.Drawing.Point(44, 62);
            this.CmbAlmacen.Name = "CmbAlmacen";
            this.CmbAlmacen.Size = new System.Drawing.Size(292, 25);
            this.CmbAlmacen.TabIndex = 145;
            this.CmbAlmacen.SelectedIndexChanged += new System.EventHandler(this.CmbAlmacen_SelectedIndexChanged);
            // 
            // LblTipoProducto
            // 
            this.LblTipoProducto.AutoSize = true;
            this.LblTipoProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblTipoProducto.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblTipoProducto.Location = new System.Drawing.Point(41, 41);
            this.LblTipoProducto.Name = "LblTipoProducto";
            this.LblTipoProducto.Size = new System.Drawing.Size(76, 18);
            this.LblTipoProducto.TabIndex = 144;
            this.LblTipoProducto.Text = "Almacén";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescripcion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtDescripcion.Location = new System.Drawing.Point(367, 62);
            this.TxtDescripcion.MaxLength = 500;
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(238, 44);
            this.TxtDescripcion.TabIndex = 114;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblDescripcion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblDescripcion.Location = new System.Drawing.Point(364, 41);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(97, 18);
            this.LblDescripcion.TabIndex = 115;
            this.LblDescripcion.Text = "Descripción";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TxtFiltroProducto);
            this.panel2.Controls.Add(this.DgvProductos);
            this.panel2.Controls.Add(this.TxtCosto);
            this.panel2.Controls.Add(this.BtnAgregarProducto);
            this.panel2.Controls.Add(this.LblPrecioVenta);
            this.panel2.Controls.Add(this.LblCantidad);
            this.panel2.Controls.Add(this.TxtCantidad);
            this.panel2.Location = new System.Drawing.Point(11, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 488);
            this.panel2.TabIndex = 166;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(163, 26);
            this.label4.TabIndex = 169;
            this.label4.Text = "AGREGAR PRODUCTOS";
            // 
            // TxtFiltroProducto
            // 
            this.TxtFiltroProducto.Enabled = false;
            this.TxtFiltroProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltroProducto.Location = new System.Drawing.Point(3, 46);
            this.TxtFiltroProducto.MaxLength = 100;
            this.TxtFiltroProducto.Name = "TxtFiltroProducto";
            this.TxtFiltroProducto.Size = new System.Drawing.Size(477, 27);
            this.TxtFiltroProducto.TabIndex = 152;
            this.TxtFiltroProducto.TextChanged += new System.EventHandler(this.TxtFiltroProducto_TextChanged);
            // 
            // DgvProductos
            // 
            this.DgvProductos.AllowUserToAddRows = false;
            this.DgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvProductos.ColumnHeadersHeight = 30;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProductos.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvProductos.Enabled = false;
            this.DgvProductos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvProductos.Location = new System.Drawing.Point(3, 79);
            this.DgvProductos.Name = "DgvProductos";
            this.DgvProductos.ReadOnly = true;
            this.DgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvProductos.RowHeadersWidth = 15;
            this.DgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProductos.Size = new System.Drawing.Size(477, 349);
            this.DgvProductos.TabIndex = 149;
            // 
            // TxtCosto
            // 
            this.TxtCosto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtCosto.Enabled = false;
            this.TxtCosto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCosto.Location = new System.Drawing.Point(163, 456);
            this.TxtCosto.MaxLength = 100;
            this.TxtCosto.Name = "TxtCosto";
            this.TxtCosto.Size = new System.Drawing.Size(159, 27);
            this.TxtCosto.TabIndex = 113;
            this.TxtCosto.Text = "0";
            this.TxtCosto.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            this.TxtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCosto_KeyPress);
            // 
            // BtnAgregarProducto
            // 
            this.BtnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAgregarProducto.BackColor = System.Drawing.Color.Green;
            this.BtnAgregarProducto.BackGroundColor = System.Drawing.Color.Green;
            this.BtnAgregarProducto.BorderColor = System.Drawing.Color.Lime;
            this.BtnAgregarProducto.BorderRadius = 5;
            this.BtnAgregarProducto.BorderSize = 0;
            this.BtnAgregarProducto.Enabled = false;
            this.BtnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarProducto.Image")));
            this.BtnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarProducto.Location = new System.Drawing.Point(341, 446);
            this.BtnAgregarProducto.Name = "BtnAgregarProducto";
            this.BtnAgregarProducto.Size = new System.Drawing.Size(128, 35);
            this.BtnAgregarProducto.TabIndex = 158;
            this.BtnAgregarProducto.Text = "Agregar";
            this.BtnAgregarProducto.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarProducto.UseVisualStyleBackColor = false;
            this.BtnAgregarProducto.Click += new System.EventHandler(this.BtnAgregarProducto_Click);
            // 
            // LblPrecioVenta
            // 
            this.LblPrecioVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblPrecioVenta.AutoSize = true;
            this.LblPrecioVenta.Enabled = false;
            this.LblPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblPrecioVenta.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblPrecioVenta.Location = new System.Drawing.Point(160, 430);
            this.LblPrecioVenta.Name = "LblPrecioVenta";
            this.LblPrecioVenta.Size = new System.Drawing.Size(136, 18);
            this.LblPrecioVenta.TabIndex = 112;
            this.LblPrecioVenta.Text = "Costo Total (NIO):";
            // 
            // LblCantidad
            // 
            this.LblCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Enabled = false;
            this.LblCantidad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblCantidad.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblCantidad.Location = new System.Drawing.Point(7, 430);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(81, 18);
            this.LblCantidad.TabIndex = 120;
            this.LblCantidad.Text = "Cantidad:";
            this.LblCantidad.Click += new System.EventHandler(this.LblCantidad_Click);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtCantidad.Enabled = false;
            this.TxtCantidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.Location = new System.Drawing.Point(10, 456);
            this.TxtCantidad.MaxLength = 100;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(147, 27);
            this.TxtCantidad.TabIndex = 121;
            this.TxtCantidad.Text = "0";
            this.TxtCantidad.TextChanged += new System.EventHandler(this.TxtCantidad_TextChanged);
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // TxtMontoTotal
            // 
            this.TxtMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtMontoTotal.AutoSize = true;
            this.TxtMontoTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TxtMontoTotal.Location = new System.Drawing.Point(565, 413);
            this.TxtMontoTotal.Name = "TxtMontoTotal";
            this.TxtMontoTotal.Size = new System.Drawing.Size(75, 23);
            this.TxtMontoTotal.TabIndex = 164;
            this.TxtMontoTotal.Text = "0 (NIO)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(504, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 163;
            this.label3.Text = "Total: ";
            // 
            // DgvCompra
            // 
            this.DgvCompra.AllowUserToAddRows = false;
            this.DgvCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCompra.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvCompra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvCompra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DgvCompra.ColumnHeadersHeight = 30;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCompra.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvCompra.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvCompra.Location = new System.Drawing.Point(508, 176);
            this.DgvCompra.Name = "DgvCompra";
            this.DgvCompra.ReadOnly = true;
            this.DgvCompra.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DgvCompra.RowHeadersWidth = 15;
            this.DgvCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCompra.Size = new System.Drawing.Size(619, 211);
            this.DgvCompra.TabIndex = 160;
            this.DgvCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCompra_CellContentClick);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(738, 145);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5);
            this.label8.Size = new System.Drawing.Size(200, 28);
            this.label8.TabIndex = 159;
            this.label8.Text = "DETALLES DE LA COMPRA";
            // 
            // BtnAgregarCompra
            // 
            this.BtnAgregarCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAgregarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnAgregarCompra.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnAgregarCompra.BorderColor = System.Drawing.Color.Lime;
            this.BtnAgregarCompra.BorderRadius = 5;
            this.BtnAgregarCompra.BorderSize = 0;
            this.BtnAgregarCompra.FlatAppearance.BorderSize = 0;
            this.BtnAgregarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarCompra.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarCompra.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarCompra.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarCompra.Image")));
            this.BtnAgregarCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarCompra.Location = new System.Drawing.Point(948, 454);
            this.BtnAgregarCompra.Name = "BtnAgregarCompra";
            this.BtnAgregarCompra.Size = new System.Drawing.Size(173, 35);
            this.BtnAgregarCompra.TabIndex = 150;
            this.BtnAgregarCompra.Text = "Guardar";
            this.BtnAgregarCompra.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarCompra.UseVisualStyleBackColor = false;
            this.BtnAgregarCompra.Click += new System.EventHandler(this.BtnAgregarCompra_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 5;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(765, 455);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 35);
            this.btnCancelar.TabIndex = 151;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ComprasInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.TCMain);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ComprasInventario";
            this.Text = "ComprasInventario";
            this.Load += new System.EventHandler(this.ComprasInventario_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.TCMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCatalogo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public Especiales.EspecialButton BtnBuscar;
        public Especiales.EspecialButton btnAgregar;
        public System.Windows.Forms.DataGridView DgvCatalogo;
        public Controladores.LoginUserControl TxtFiltrar;
        public System.Windows.Forms.Label LblDescripcion;
        public System.Windows.Forms.TextBox TxtDescripcion;
        public System.Windows.Forms.TextBox TxtCosto;
        public System.Windows.Forms.Label LblPrecioVenta;
        public System.Windows.Forms.TextBox TxtCantidad;
        public System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.ComboBox CmbAlmacen;
        public System.Windows.Forms.Label LblTipoProducto;
        public System.Windows.Forms.DataGridView DgvProductos;
        public Especiales.EspecialButton BtnAgregarCompra;
        public Especiales.EspecialButton btnCancelar;
        public Especiales.EspecialButton BtnAgregarProducto;
        public System.Windows.Forms.DataGridView DgvCompra;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label TxtMontoTotal;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CmbSucursales;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtFiltroProducto;
    }
}