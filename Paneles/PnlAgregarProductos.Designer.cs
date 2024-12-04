namespace NeoCobranza.Paneles
{
    partial class PnlAgregarProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgregarProductos));
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblNombreDinamico = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblDynamico = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.PnlImagenes = new System.Windows.Forms.Panel();
            this.ImgProducto = new System.Windows.Forms.PictureBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LblTipoProducto = new System.Windows.Forms.Label();
            this.CmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.TxtPrecioVenta = new System.Windows.Forms.TextBox();
            this.LblPrecioVenta = new System.Windows.Forms.Label();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.PnlProveedores = new System.Windows.Forms.Panel();
            this.DgvProveedor = new System.Windows.Forms.DataGridView();
            this.CmbProveedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAgregarProveedor = new NeoCobranza.Especiales.EspecialButton();
            this.BtnQuitarProveedor = new NeoCobranza.Especiales.EspecialButton();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnSeleccionarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.panel3.SuspendLayout();
            this.PnlImagenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProducto)).BeginInit();
            this.PnlProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNombre.Location = new System.Drawing.Point(16, 69);
            this.TxtNombre.MaxLength = 100;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(412, 23);
            this.TxtNombre.TabIndex = 98;
            // 
            // LblNombreDinamico
            // 
            this.LblNombreDinamico.AutoSize = true;
            this.LblNombreDinamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblNombreDinamico.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblNombreDinamico.Location = new System.Drawing.Point(12, 43);
            this.LblNombreDinamico.Name = "LblNombreDinamico";
            this.LblNombreDinamico.Size = new System.Drawing.Size(72, 18);
            this.LblNombreDinamico.TabIndex = 99;
            this.LblNombreDinamico.Text = "Nombre ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.LblDynamico);
            this.panel3.Location = new System.Drawing.Point(-5, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 33);
            this.panel3.TabIndex = 95;
            // 
            // LblDynamico
            // 
            this.LblDynamico.AutoSize = true;
            this.LblDynamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDynamico.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblDynamico.Location = new System.Drawing.Point(22, 9);
            this.LblDynamico.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.LblDynamico.Name = "LblDynamico";
            this.LblDynamico.Size = new System.Drawing.Size(144, 18);
            this.LblDynamico.TabIndex = 1;
            this.LblDynamico.Text = "Nombre Dinamico";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtDescripcion.Location = new System.Drawing.Point(17, 134);
            this.TxtDescripcion.MaxLength = 500;
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(410, 136);
            this.TxtDescripcion.TabIndex = 110;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblDescripcion.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblDescripcion.Location = new System.Drawing.Point(14, 102);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(97, 18);
            this.LblDescripcion.TabIndex = 111;
            this.LblDescripcion.Text = "Descripción";
            // 
            // PnlImagenes
            // 
            this.PnlImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlImagenes.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PnlImagenes.Controls.Add(this.ImgProducto);
            this.PnlImagenes.Controls.Add(this.BtnSeleccionarImagen);
            this.PnlImagenes.Location = new System.Drawing.Point(510, 163);
            this.PnlImagenes.Name = "PnlImagenes";
            this.PnlImagenes.Size = new System.Drawing.Size(215, 178);
            this.PnlImagenes.TabIndex = 112;
            this.PnlImagenes.Visible = false;
            // 
            // ImgProducto
            // 
            this.ImgProducto.Location = new System.Drawing.Point(32, 13);
            this.ImgProducto.Name = "ImgProducto";
            this.ImgProducto.Size = new System.Drawing.Size(150, 113);
            this.ImgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgProducto.TabIndex = 90;
            this.ImgProducto.TabStop = false;
            this.ImgProducto.Click += new System.EventHandler(this.ImgProducto_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // LblTipoProducto
            // 
            this.LblTipoProducto.AutoSize = true;
            this.LblTipoProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblTipoProducto.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblTipoProducto.Location = new System.Drawing.Point(13, 401);
            this.LblTipoProducto.Name = "LblTipoProducto";
            this.LblTipoProducto.Size = new System.Drawing.Size(87, 18);
            this.LblTipoProducto.TabIndex = 115;
            this.LblTipoProducto.Text = "Categoría:";
            // 
            // CmbTipoProducto
            // 
            this.CmbTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbTipoProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbTipoProducto.FormattingEnabled = true;
            this.CmbTipoProducto.Location = new System.Drawing.Point(16, 427);
            this.CmbTipoProducto.Name = "CmbTipoProducto";
            this.CmbTipoProducto.Size = new System.Drawing.Size(297, 25);
            this.CmbTipoProducto.TabIndex = 117;
            // 
            // TxtPrecioVenta
            // 
            this.TxtPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtPrecioVenta.Location = new System.Drawing.Point(192, 287);
            this.TxtPrecioVenta.MaxLength = 100;
            this.TxtPrecioVenta.Name = "TxtPrecioVenta";
            this.TxtPrecioVenta.Size = new System.Drawing.Size(236, 23);
            this.TxtPrecioVenta.TabIndex = 134;
            this.TxtPrecioVenta.Text = "0";
            this.TxtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioVenta_KeyPress_1);
            // 
            // LblPrecioVenta
            // 
            this.LblPrecioVenta.AutoSize = true;
            this.LblPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblPrecioVenta.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblPrecioVenta.Location = new System.Drawing.Point(12, 288);
            this.LblPrecioVenta.Name = "LblPrecioVenta";
            this.LblPrecioVenta.Size = new System.Drawing.Size(174, 18);
            this.LblPrecioVenta.TabIndex = 133;
            this.LblPrecioVenta.Text = "Precio en Venta (NIO):";
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblCodigo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblCodigo.Location = new System.Drawing.Point(464, 43);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(68, 18);
            this.LblCodigo.TabIndex = 135;
            this.LblCodigo.Text = "Codigo:";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtCodigo.Location = new System.Drawing.Point(467, 68);
            this.TxtCodigo.MaxLength = 30;
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(321, 23);
            this.TxtCodigo.TabIndex = 136;
            // 
            // PnlProveedores
            // 
            this.PnlProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlProveedores.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PnlProveedores.Controls.Add(this.DgvProveedor);
            this.PnlProveedores.Controls.Add(this.CmbProveedor);
            this.PnlProveedores.Controls.Add(this.BtnAgregarProveedor);
            this.PnlProveedores.Controls.Add(this.BtnQuitarProveedor);
            this.PnlProveedores.Controls.Add(this.label1);
            this.PnlProveedores.Location = new System.Drawing.Point(465, 111);
            this.PnlProveedores.Name = "PnlProveedores";
            this.PnlProveedores.Size = new System.Drawing.Size(323, 328);
            this.PnlProveedores.TabIndex = 141;
            // 
            // DgvProveedor
            // 
            this.DgvProveedor.AllowUserToAddRows = false;
            this.DgvProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvProveedor.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvProveedor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProveedor.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProveedor.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvProveedor.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvProveedor.Location = new System.Drawing.Point(12, 119);
            this.DgvProveedor.Name = "DgvProveedor";
            this.DgvProveedor.ReadOnly = true;
            this.DgvProveedor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvProveedor.RowHeadersWidth = 15;
            this.DgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProveedor.Size = new System.Drawing.Size(300, 199);
            this.DgvProveedor.TabIndex = 130;
            // 
            // CmbProveedor
            // 
            this.CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbProveedor.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbProveedor.FormattingEnabled = true;
            this.CmbProveedor.Location = new System.Drawing.Point(12, 44);
            this.CmbProveedor.Name = "CmbProveedor";
            this.CmbProveedor.Size = new System.Drawing.Size(297, 25);
            this.CmbProveedor.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 114;
            this.label1.Text = "Proveedores";
            // 
            // BtnAgregarProveedor
            // 
            this.BtnAgregarProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAgregarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnAgregarProveedor.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnAgregarProveedor.BorderColor = System.Drawing.Color.Lime;
            this.BtnAgregarProveedor.BorderRadius = 5;
            this.BtnAgregarProveedor.BorderSize = 0;
            this.BtnAgregarProveedor.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProveedor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarProveedor.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProveedor.Location = new System.Drawing.Point(149, 76);
            this.BtnAgregarProveedor.Name = "BtnAgregarProveedor";
            this.BtnAgregarProveedor.Size = new System.Drawing.Size(77, 35);
            this.BtnAgregarProveedor.TabIndex = 115;
            this.BtnAgregarProveedor.Text = "Agregar";
            this.BtnAgregarProveedor.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarProveedor.UseVisualStyleBackColor = false;
            this.BtnAgregarProveedor.Click += new System.EventHandler(this.BtnAgregarProveedor_Click);
            // 
            // BtnQuitarProveedor
            // 
            this.BtnQuitarProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnQuitarProveedor.BackColor = System.Drawing.Color.Maroon;
            this.BtnQuitarProveedor.BackGroundColor = System.Drawing.Color.Maroon;
            this.BtnQuitarProveedor.BorderColor = System.Drawing.Color.Lime;
            this.BtnQuitarProveedor.BorderRadius = 5;
            this.BtnQuitarProveedor.BorderSize = 0;
            this.BtnQuitarProveedor.FlatAppearance.BorderSize = 0;
            this.BtnQuitarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuitarProveedor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnQuitarProveedor.ForeColor = System.Drawing.Color.White;
            this.BtnQuitarProveedor.Location = new System.Drawing.Point(235, 76);
            this.BtnQuitarProveedor.Name = "BtnQuitarProveedor";
            this.BtnQuitarProveedor.Size = new System.Drawing.Size(77, 35);
            this.BtnQuitarProveedor.TabIndex = 114;
            this.BtnQuitarProveedor.Text = "Quitar";
            this.BtnQuitarProveedor.TextGroundColor = System.Drawing.Color.White;
            this.BtnQuitarProveedor.UseVisualStyleBackColor = false;
            this.BtnQuitarProveedor.Click += new System.EventHandler(this.BtnQuitarProveedor_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.btnAgregar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.btnAgregar.BorderColor = System.Drawing.Color.Lime;
            this.btnAgregar.BorderRadius = 5;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(615, 457);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(173, 30);
            this.btnAgregar.TabIndex = 139;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 5;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(432, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 30);
            this.btnCancelar.TabIndex = 140;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnSeleccionarImagen
            // 
            this.BtnSeleccionarImagen.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSeleccionarImagen.BackGroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSeleccionarImagen.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSeleccionarImagen.BorderRadius = 0;
            this.BtnSeleccionarImagen.BorderSize = 0;
            this.BtnSeleccionarImagen.FlatAppearance.BorderSize = 0;
            this.BtnSeleccionarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionarImagen.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnSeleccionarImagen.ForeColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.Location = new System.Drawing.Point(11, 134);
            this.BtnSeleccionarImagen.Name = "BtnSeleccionarImagen";
            this.BtnSeleccionarImagen.Size = new System.Drawing.Size(193, 28);
            this.BtnSeleccionarImagen.TabIndex = 0;
            this.BtnSeleccionarImagen.Text = "Seleccionar imagen";
            this.BtnSeleccionarImagen.TextGroundColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.UseVisualStyleBackColor = false;
            this.BtnSeleccionarImagen.Click += new System.EventHandler(this.BtnSeleccionarImagen_Click);
            // 
            // PnlAgregarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.PnlProveedores);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.LblCodigo);
            this.Controls.Add(this.TxtPrecioVenta);
            this.Controls.Add(this.LblPrecioVenta);
            this.Controls.Add(this.CmbTipoProducto);
            this.Controls.Add(this.LblTipoProducto);
            this.Controls.Add(this.PnlImagenes);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblNombreDinamico);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PnlAgregarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos - Servicios";
            this.Load += new System.EventHandler(this.PnlAgregarProductos_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PnlImagenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgProducto)).EndInit();
            this.PnlProveedores.ResumeLayout(false);
            this.PnlProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox TxtNombre;
        public System.Windows.Forms.Label LblNombreDinamico;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label LblDynamico;
        public System.Windows.Forms.TextBox TxtDescripcion;
        public System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Panel PnlImagenes;
        private System.Windows.Forms.PictureBox ImgProducto;
        private Especiales.EspecialButton BtnSeleccionarImagen;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        public System.Windows.Forms.Label LblTipoProducto;
        private System.Windows.Forms.ComboBox CmbTipoProducto;
        public System.Windows.Forms.TextBox TxtPrecioVenta;
        public System.Windows.Forms.Label LblPrecioVenta;
        public System.Windows.Forms.Label LblCodigo;
        public System.Windows.Forms.TextBox TxtCodigo;
        public Especiales.EspecialButton btnAgregar;
        public Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Panel PnlProveedores;
        public System.Windows.Forms.DataGridView DgvProveedor;
        private System.Windows.Forms.ComboBox CmbProveedor;
        public Especiales.EspecialButton BtnAgregarProveedor;
        public Especiales.EspecialButton BtnQuitarProveedor;
        public System.Windows.Forms.Label label1;
    }
}