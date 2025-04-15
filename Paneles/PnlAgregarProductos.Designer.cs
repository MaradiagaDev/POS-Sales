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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgregarProductos));
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblNombreDinamico = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblDynamico = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LblTipoProducto = new System.Windows.Forms.Label();
            this.CmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.TxtPrecioVenta = new System.Windows.Forms.TextBox();
            this.LblPrecioVenta = new System.Windows.Forms.Label();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PBImagenProducto = new System.Windows.Forms.PictureBox();
            this.ChkPrecioVariable = new System.Windows.Forms.CheckBox();
            this.TxtMejorPrecio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkCobraIVA = new System.Windows.Forms.CheckBox();
            this.ChkVencimiento = new System.Windows.Forms.CheckBox();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnAdiciones = new NeoCobranza.Especiales.EspecialButton();
            this.BtnInventarioInicial = new NeoCobranza.Especiales.EspecialButton();
            this.BtnSeleccionarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtUnidadMedida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNombre.Location = new System.Drawing.Point(7, 68);
            this.TxtNombre.MaxLength = 100;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(412, 23);
            this.TxtNombre.TabIndex = 98;
            // 
            // LblNombreDinamico
            // 
            this.LblNombreDinamico.AutoSize = true;
            this.LblNombreDinamico.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreDinamico.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblNombreDinamico.Location = new System.Drawing.Point(3, 43);
            this.LblNombreDinamico.Name = "LblNombreDinamico";
            this.LblNombreDinamico.Size = new System.Drawing.Size(153, 22);
            this.LblNombreDinamico.TabIndex = 99;
            this.LblNombreDinamico.Text = "IDENTIFICADOR";
            this.LblNombreDinamico.Click += new System.EventHandler(this.LblNombreDinamico_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.LblDynamico);
            this.panel3.Location = new System.Drawing.Point(-5, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(915, 33);
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
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescripcion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtDescripcion.Location = new System.Drawing.Point(7, 120);
            this.TxtDescripcion.MaxLength = 500;
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(410, 95);
            this.TxtDescripcion.TabIndex = 110;
            this.TxtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.LblDescripcion.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblDescripcion.Location = new System.Drawing.Point(3, 94);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(137, 22);
            this.LblDescripcion.TabIndex = 111;
            this.LblDescripcion.Text = "DESCRIPCIÓN";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // LblTipoProducto
            // 
            this.LblTipoProducto.AutoSize = true;
            this.LblTipoProducto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoProducto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblTipoProducto.Location = new System.Drawing.Point(4, 332);
            this.LblTipoProducto.Name = "LblTipoProducto";
            this.LblTipoProducto.Size = new System.Drawing.Size(109, 22);
            this.LblTipoProducto.TabIndex = 115;
            this.LblTipoProducto.Text = "Categoría:";
            // 
            // CmbTipoProducto
            // 
            this.CmbTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbTipoProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoProducto.FormattingEnabled = true;
            this.CmbTipoProducto.Location = new System.Drawing.Point(6, 358);
            this.CmbTipoProducto.Name = "CmbTipoProducto";
            this.CmbTipoProducto.Size = new System.Drawing.Size(492, 29);
            this.CmbTipoProducto.TabIndex = 117;
            // 
            // TxtPrecioVenta
            // 
            this.TxtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioVenta.Location = new System.Drawing.Point(6, 244);
            this.TxtPrecioVenta.MaxLength = 100;
            this.TxtPrecioVenta.Name = "TxtPrecioVenta";
            this.TxtPrecioVenta.Size = new System.Drawing.Size(298, 27);
            this.TxtPrecioVenta.TabIndex = 134;
            this.TxtPrecioVenta.Text = "0";
            this.TxtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioVenta_KeyPress_1);
            // 
            // LblPrecioVenta
            // 
            this.LblPrecioVenta.AutoSize = true;
            this.LblPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.LblPrecioVenta.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblPrecioVenta.Location = new System.Drawing.Point(3, 218);
            this.LblPrecioVenta.Name = "LblPrecioVenta";
            this.LblPrecioVenta.Size = new System.Drawing.Size(135, 22);
            this.LblPrecioVenta.TabIndex = 133;
            this.LblPrecioVenta.Text = "PRECIO (NIO)";
            this.LblPrecioVenta.Click += new System.EventHandler(this.LblPrecioVenta_Click);
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblCodigo.Location = new System.Drawing.Point(431, 43);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(74, 20);
            this.LblCodigo.TabIndex = 135;
            this.LblCodigo.Text = "CÓDIGO";
            this.LblCodigo.Click += new System.EventHandler(this.LblCodigo_Click);
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCodigo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtCodigo.Location = new System.Drawing.Point(435, 66);
            this.TxtCodigo.MaxLength = 30;
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(215, 23);
            this.TxtCodigo.TabIndex = 136;
            this.TxtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(717, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 185;
            this.label10.Text = "IMAGEN";
            // 
            // PBImagenProducto
            // 
            this.PBImagenProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBImagenProducto.Location = new System.Drawing.Point(644, 134);
            this.PBImagenProducto.Name = "PBImagenProducto";
            this.PBImagenProducto.Size = new System.Drawing.Size(211, 186);
            this.PBImagenProducto.TabIndex = 184;
            this.PBImagenProducto.TabStop = false;
            // 
            // ChkPrecioVariable
            // 
            this.ChkPrecioVariable.AutoSize = true;
            this.ChkPrecioVariable.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPrecioVariable.Location = new System.Drawing.Point(315, 306);
            this.ChkPrecioVariable.Name = "ChkPrecioVariable";
            this.ChkPrecioVariable.Size = new System.Drawing.Size(137, 21);
            this.ChkPrecioVariable.TabIndex = 187;
            this.ChkPrecioVariable.Text = "PRECIO VARIABLE";
            this.ChkPrecioVariable.UseVisualStyleBackColor = true;
            this.ChkPrecioVariable.CheckedChanged += new System.EventHandler(this.ChkPrecioVariable_CheckedChanged);
            // 
            // TxtMejorPrecio
            // 
            this.TxtMejorPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMejorPrecio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMejorPrecio.Location = new System.Drawing.Point(7, 302);
            this.TxtMejorPrecio.MaxLength = 100;
            this.TxtMejorPrecio.Name = "TxtMejorPrecio";
            this.TxtMejorPrecio.Size = new System.Drawing.Size(298, 27);
            this.TxtMejorPrecio.TabIndex = 190;
            this.TxtMejorPrecio.Text = "0";
            this.TxtMejorPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMejorPrecio_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(4, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 22);
            this.label1.TabIndex = 189;
            this.label1.Text = "PRECIO EN DESCUENTO (NIO)";
            // 
            // ChkCobraIVA
            // 
            this.ChkCobraIVA.AutoSize = true;
            this.ChkCobraIVA.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkCobraIVA.Location = new System.Drawing.Point(315, 244);
            this.ChkCobraIVA.Name = "ChkCobraIVA";
            this.ChkCobraIVA.Size = new System.Drawing.Size(84, 21);
            this.ChkCobraIVA.TabIndex = 191;
            this.ChkCobraIVA.Text = "TIENE IVA";
            this.ChkCobraIVA.UseVisualStyleBackColor = true;
            this.ChkCobraIVA.CheckedChanged += new System.EventHandler(this.ChkCobraIVA_CheckedChanged);
            // 
            // ChkVencimiento
            // 
            this.ChkVencimiento.AutoSize = true;
            this.ChkVencimiento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkVencimiento.Location = new System.Drawing.Point(315, 274);
            this.ChkVencimiento.Name = "ChkVencimiento";
            this.ChkVencimiento.Size = new System.Drawing.Size(181, 21);
            this.ChkVencimiento.TabIndex = 193;
            this.ChkVencimiento.Text = "FECHA DE VENCIMIENTO";
            this.ChkVencimiento.UseVisualStyleBackColor = true;
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.especialButton1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.especialButton1.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.especialButton1.BorderColor = System.Drawing.Color.LavenderBlush;
            this.especialButton1.BorderRadius = 5;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(8, 401);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(296, 31);
            this.especialButton1.TabIndex = 192;
            this.especialButton1.Text = "PROVEEDORES";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click_1);
            // 
            // BtnAdiciones
            // 
            this.BtnAdiciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAdiciones.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAdiciones.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAdiciones.BorderColor = System.Drawing.Color.LavenderBlush;
            this.BtnAdiciones.BorderRadius = 5;
            this.BtnAdiciones.BorderSize = 0;
            this.BtnAdiciones.FlatAppearance.BorderSize = 0;
            this.BtnAdiciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdiciones.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnAdiciones.ForeColor = System.Drawing.Color.White;
            this.BtnAdiciones.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdiciones.Image")));
            this.BtnAdiciones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdiciones.Location = new System.Drawing.Point(8, 470);
            this.BtnAdiciones.Name = "BtnAdiciones";
            this.BtnAdiciones.Size = new System.Drawing.Size(296, 31);
            this.BtnAdiciones.TabIndex = 188;
            this.BtnAdiciones.Text = "ADICIONES";
            this.BtnAdiciones.TextGroundColor = System.Drawing.Color.White;
            this.BtnAdiciones.UseVisualStyleBackColor = false;
            this.BtnAdiciones.Click += new System.EventHandler(this.BtnAdiciones_Click);
            // 
            // BtnInventarioInicial
            // 
            this.BtnInventarioInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnInventarioInicial.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnInventarioInicial.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.BtnInventarioInicial.BorderColor = System.Drawing.Color.LavenderBlush;
            this.BtnInventarioInicial.BorderRadius = 5;
            this.BtnInventarioInicial.BorderSize = 0;
            this.BtnInventarioInicial.FlatAppearance.BorderSize = 0;
            this.BtnInventarioInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInventarioInicial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnInventarioInicial.ForeColor = System.Drawing.Color.White;
            this.BtnInventarioInicial.Image = ((System.Drawing.Image)(resources.GetObject("BtnInventarioInicial.Image")));
            this.BtnInventarioInicial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInventarioInicial.Location = new System.Drawing.Point(8, 435);
            this.BtnInventarioInicial.Name = "BtnInventarioInicial";
            this.BtnInventarioInicial.Size = new System.Drawing.Size(296, 31);
            this.BtnInventarioInicial.TabIndex = 186;
            this.BtnInventarioInicial.Text = "INVENTARIO INICIAL";
            this.BtnInventarioInicial.TextGroundColor = System.Drawing.Color.White;
            this.BtnInventarioInicial.UseVisualStyleBackColor = false;
            this.BtnInventarioInicial.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // BtnSeleccionarImagen
            // 
            this.BtnSeleccionarImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnSeleccionarImagen.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnSeleccionarImagen.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSeleccionarImagen.BorderRadius = 5;
            this.BtnSeleccionarImagen.BorderSize = 0;
            this.BtnSeleccionarImagen.FlatAppearance.BorderSize = 0;
            this.BtnSeleccionarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionarImagen.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BtnSeleccionarImagen.ForeColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSeleccionarImagen.Location = new System.Drawing.Point(644, 337);
            this.BtnSeleccionarImagen.Name = "BtnSeleccionarImagen";
            this.BtnSeleccionarImagen.Size = new System.Drawing.Size(211, 38);
            this.BtnSeleccionarImagen.TabIndex = 183;
            this.BtnSeleccionarImagen.Text = "Seleccionar imagen ...";
            this.BtnSeleccionarImagen.TextGroundColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.UseVisualStyleBackColor = false;
            this.BtnSeleccionarImagen.Click += new System.EventHandler(this.BtnSeleccionarImagen_Click);
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
            this.btnAgregar.Location = new System.Drawing.Point(777, 457);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(131, 39);
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
            this.btnCancelar.Location = new System.Drawing.Point(624, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 39);
            this.btnCancelar.TabIndex = 140;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // TxtUnidadMedida
            // 
            this.TxtUnidadMedida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUnidadMedida.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtUnidadMedida.Location = new System.Drawing.Point(434, 192);
            this.TxtUnidadMedida.MaxLength = 30;
            this.TxtUnidadMedida.Name = "TxtUnidadMedida";
            this.TxtUnidadMedida.Size = new System.Drawing.Size(183, 23);
            this.TxtUnidadMedida.TabIndex = 195;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(431, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 194;
            this.label2.Text = "UNIDAD DE MEDIDA";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(332, 401);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(166, 21);
            this.checkBox1.TabIndex = 196;
            this.checkBox1.Text = "INVENTARIO SENCILLO";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(332, 450);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(185, 21);
            this.checkBox2.TabIndex = 197;
            this.checkBox2.Text = "INVENTARIO PROVEEDOR";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(332, 475);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(193, 21);
            this.checkBox3.TabIndex = 198;
            this.checkBox3.Text = "INVENTARIO VENCIMIENTO";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(332, 425);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(179, 21);
            this.checkBox4.TabIndex = 199;
            this.checkBox4.Text = "INVENTARIO DETALLADO";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // PnlAgregarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(911, 508);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TxtUnidadMedida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkVencimiento);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.ChkCobraIVA);
            this.Controls.Add(this.TxtMejorPrecio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAdiciones);
            this.Controls.Add(this.ChkPrecioVariable);
            this.Controls.Add(this.BtnInventarioInicial);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PBImagenProducto);
            this.Controls.Add(this.BtnSeleccionarImagen);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.LblCodigo);
            this.Controls.Add(this.TxtPrecioVenta);
            this.Controls.Add(this.LblPrecioVenta);
            this.Controls.Add(this.CmbTipoProducto);
            this.Controls.Add(this.LblTipoProducto);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblNombreDinamico);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(927, 547);
            this.MinimumSize = new System.Drawing.Size(927, 547);
            this.Name = "PnlAgregarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos - Servicios";
            this.Load += new System.EventHandler(this.PnlAgregarProductos_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).EndInit();
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
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        public System.Windows.Forms.Label LblTipoProducto;
        private System.Windows.Forms.ComboBox CmbTipoProducto;
        public System.Windows.Forms.TextBox TxtPrecioVenta;
        public System.Windows.Forms.Label LblPrecioVenta;
        public System.Windows.Forms.Label LblCodigo;
        public System.Windows.Forms.TextBox TxtCodigo;
        public Especiales.EspecialButton btnAgregar;
        public Especiales.EspecialButton btnCancelar;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox PBImagenProducto;
        public Especiales.EspecialButton BtnSeleccionarImagen;
        public Especiales.EspecialButton BtnInventarioInicial;
        public System.Windows.Forms.CheckBox ChkPrecioVariable;
        public Especiales.EspecialButton BtnAdiciones;
        public System.Windows.Forms.TextBox TxtMejorPrecio;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox ChkCobraIVA;
        public Especiales.EspecialButton especialButton1;
        public System.Windows.Forms.CheckBox ChkVencimiento;
        public System.Windows.Forms.TextBox TxtUnidadMedida;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox4;
    }
}