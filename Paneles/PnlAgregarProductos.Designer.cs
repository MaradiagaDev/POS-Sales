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
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.label10 = new System.Windows.Forms.Label();
            this.PBImagenProducto = new System.Windows.Forms.PictureBox();
            this.BtnSeleccionarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.BtnInventarioInicial = new NeoCobranza.Especiales.EspecialButton();
            this.ChkPrecioVariable = new System.Windows.Forms.CheckBox();
            this.BtnAdiciones = new NeoCobranza.Especiales.EspecialButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagenProducto)).BeginInit();
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
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // LblTipoProducto
            // 
            this.LblTipoProducto.AutoSize = true;
            this.LblTipoProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblTipoProducto.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblTipoProducto.Location = new System.Drawing.Point(13, 353);
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
            this.CmbTipoProducto.Location = new System.Drawing.Point(16, 379);
            this.CmbTipoProducto.Name = "CmbTipoProducto";
            this.CmbTipoProducto.Size = new System.Drawing.Size(297, 25);
            this.CmbTipoProducto.TabIndex = 117;
            // 
            // TxtPrecioVenta
            // 
            this.TxtPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtPrecioVenta.Location = new System.Drawing.Point(15, 309);
            this.TxtPrecioVenta.MaxLength = 100;
            this.TxtPrecioVenta.Name = "TxtPrecioVenta";
            this.TxtPrecioVenta.Size = new System.Drawing.Size(298, 23);
            this.TxtPrecioVenta.TabIndex = 134;
            this.TxtPrecioVenta.Text = "0";
            this.TxtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioVenta_KeyPress_1);
            // 
            // LblPrecioVenta
            // 
            this.LblPrecioVenta.AutoSize = true;
            this.LblPrecioVenta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblPrecioVenta.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblPrecioVenta.Location = new System.Drawing.Point(12, 281);
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
            this.btnAgregar.Location = new System.Drawing.Point(742, 457);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 39);
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
            this.btnCancelar.Location = new System.Drawing.Point(559, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(177, 39);
            this.btnCancelar.TabIndex = 140;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(645, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 18);
            this.label10.TabIndex = 185;
            this.label10.Text = "Imagen Representativa";
            // 
            // PBImagenProducto
            // 
            this.PBImagenProducto.Location = new System.Drawing.Point(632, 146);
            this.PBImagenProducto.Name = "PBImagenProducto";
            this.PBImagenProducto.Size = new System.Drawing.Size(211, 186);
            this.PBImagenProducto.TabIndex = 184;
            this.PBImagenProducto.TabStop = false;
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
            this.BtnSeleccionarImagen.Location = new System.Drawing.Point(632, 349);
            this.BtnSeleccionarImagen.Name = "BtnSeleccionarImagen";
            this.BtnSeleccionarImagen.Size = new System.Drawing.Size(211, 38);
            this.BtnSeleccionarImagen.TabIndex = 183;
            this.BtnSeleccionarImagen.Text = "Seleccionar imagen ...";
            this.BtnSeleccionarImagen.TextGroundColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.UseVisualStyleBackColor = false;
            this.BtnSeleccionarImagen.Click += new System.EventHandler(this.BtnSeleccionarImagen_Click);
            // 
            // BtnInventarioInicial
            // 
            this.BtnInventarioInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnInventarioInicial.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnInventarioInicial.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnInventarioInicial.BorderColor = System.Drawing.Color.LavenderBlush;
            this.BtnInventarioInicial.BorderRadius = 5;
            this.BtnInventarioInicial.BorderSize = 0;
            this.BtnInventarioInicial.FlatAppearance.BorderSize = 0;
            this.BtnInventarioInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInventarioInicial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnInventarioInicial.ForeColor = System.Drawing.Color.White;
            this.BtnInventarioInicial.Image = ((System.Drawing.Image)(resources.GetObject("BtnInventarioInicial.Image")));
            this.BtnInventarioInicial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInventarioInicial.Location = new System.Drawing.Point(7, 465);
            this.BtnInventarioInicial.Name = "BtnInventarioInicial";
            this.BtnInventarioInicial.Size = new System.Drawing.Size(259, 31);
            this.BtnInventarioInicial.TabIndex = 186;
            this.BtnInventarioInicial.Text = "INVENTARIO INICIAL";
            this.BtnInventarioInicial.TextGroundColor = System.Drawing.Color.White;
            this.BtnInventarioInicial.UseVisualStyleBackColor = false;
            this.BtnInventarioInicial.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // ChkPrecioVariable
            // 
            this.ChkPrecioVariable.AutoSize = true;
            this.ChkPrecioVariable.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.ChkPrecioVariable.Location = new System.Drawing.Point(370, 315);
            this.ChkPrecioVariable.Name = "ChkPrecioVariable";
            this.ChkPrecioVariable.Size = new System.Drawing.Size(142, 22);
            this.ChkPrecioVariable.TabIndex = 187;
            this.ChkPrecioVariable.Text = "Precio Variable";
            this.ChkPrecioVariable.UseVisualStyleBackColor = true;
            // 
            // BtnAdiciones
            // 
            this.BtnAdiciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAdiciones.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnAdiciones.BackGroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnAdiciones.BorderColor = System.Drawing.Color.LavenderBlush;
            this.BtnAdiciones.BorderRadius = 5;
            this.BtnAdiciones.BorderSize = 0;
            this.BtnAdiciones.FlatAppearance.BorderSize = 0;
            this.BtnAdiciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdiciones.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnAdiciones.ForeColor = System.Drawing.Color.White;
            this.BtnAdiciones.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdiciones.Image")));
            this.BtnAdiciones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdiciones.Location = new System.Drawing.Point(7, 428);
            this.BtnAdiciones.Name = "BtnAdiciones";
            this.BtnAdiciones.Size = new System.Drawing.Size(259, 31);
            this.BtnAdiciones.TabIndex = 188;
            this.BtnAdiciones.Text = "ADICIONES";
            this.BtnAdiciones.TextGroundColor = System.Drawing.Color.White;
            this.BtnAdiciones.UseVisualStyleBackColor = false;
            this.BtnAdiciones.Click += new System.EventHandler(this.BtnAdiciones_Click);
            // 
            // PnlAgregarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(911, 508);
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
    }
}