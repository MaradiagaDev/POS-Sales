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
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.TxtCantidadProducto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.CmbAlmacen = new System.Windows.Forms.ComboBox();
            this.LblAlmacen = new System.Windows.Forms.Label();
            this.CmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.BtnVolver = new NeoCobranza.Especiales.EspecialButton();
            this.TxtBuscarProductos = new NeoCobranza.Controladores.LoginUserControl();
            this.flowLayoutPanelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.PnlPaginado = new System.Windows.Forms.Panel();
            this.TxtPaginaDe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPaginaNo = new System.Windows.Forms.TextBox();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.PnlTitulo.SuspendLayout();
            this.panel9.SuspendLayout();
            this.PnlPaginado.SuspendLayout();
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
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(77)))), ((int)(((byte)(97)))));
            this.panel9.Controls.Add(this.CmbAlmacen);
            this.panel9.Controls.Add(this.LblAlmacen);
            this.panel9.Controls.Add(this.CmbTipoServicio);
            this.panel9.Controls.Add(this.label30);
            this.panel9.Location = new System.Drawing.Point(5, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1148, 56);
            this.panel9.TabIndex = 147;
            // 
            // CmbAlmacen
            // 
            this.CmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAlmacen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAlmacen.FormattingEnabled = true;
            this.CmbAlmacen.Location = new System.Drawing.Point(667, 16);
            this.CmbAlmacen.Name = "CmbAlmacen";
            this.CmbAlmacen.Size = new System.Drawing.Size(457, 27);
            this.CmbAlmacen.TabIndex = 140;
            this.CmbAlmacen.Visible = false;
            this.CmbAlmacen.SelectedIndexChanged += new System.EventHandler(this.CmbAlmacen_SelectedIndexChanged);
            // 
            // LblAlmacen
            // 
            this.LblAlmacen.AutoSize = true;
            this.LblAlmacen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlmacen.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.LblAlmacen.Location = new System.Drawing.Point(566, 19);
            this.LblAlmacen.Name = "LblAlmacen";
            this.LblAlmacen.Size = new System.Drawing.Size(86, 19);
            this.LblAlmacen.TabIndex = 139;
            this.LblAlmacen.Text = "Almacén:";
            this.LblAlmacen.Visible = false;
            // 
            // CmbTipoServicio
            // 
            this.CmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoServicio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoServicio.FormattingEnabled = true;
            this.CmbTipoServicio.Location = new System.Drawing.Point(107, 16);
            this.CmbTipoServicio.Name = "CmbTipoServicio";
            this.CmbTipoServicio.Size = new System.Drawing.Size(421, 27);
            this.CmbTipoServicio.TabIndex = 138;
            this.CmbTipoServicio.SelectedIndexChanged += new System.EventHandler(this.CmbTipoServicio_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label30.Location = new System.Drawing.Point(10, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(91, 19);
            this.label30.TabIndex = 137;
            this.label30.Text = "Categoría:";
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
            // flowLayoutPanelProductos
            // 
            this.flowLayoutPanelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelProductos.Location = new System.Drawing.Point(5, 120);
            this.flowLayoutPanelProductos.Name = "flowLayoutPanelProductos";
            this.flowLayoutPanelProductos.Size = new System.Drawing.Size(1148, 335);
            this.flowLayoutPanelProductos.TabIndex = 153;
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
            this.PnlPaginado.Location = new System.Drawing.Point(5, 461);
            this.PnlPaginado.Name = "PnlPaginado";
            this.PnlPaginado.Size = new System.Drawing.Size(545, 47);
            this.PnlPaginado.TabIndex = 155;
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
            // frmAgregarProductosServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1158, 555);
            this.Controls.Add(this.PnlPaginado);
            this.Controls.Add(this.flowLayoutPanelProductos);
            this.Controls.Add(this.TxtCantidadProducto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.BtnVolver);
            this.Controls.Add(this.TxtBuscarProductos);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarProductosServicios";
            this.Text = "frmAgregarProductosServicios";
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.PnlPaginado.ResumeLayout(false);
            this.PnlPaginado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label llbTitulo;
        private System.Windows.Forms.TextBox TxtCantidadProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.ComboBox CmbTipoServicio;
        private System.Windows.Forms.Label label30;
        public Especiales.EspecialButton BtnVolver;
        public Controladores.LoginUserControl TxtBuscarProductos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProductos;
        public System.Windows.Forms.ComboBox CmbAlmacen;
        private System.Windows.Forms.Label LblAlmacen;
        public System.Windows.Forms.Panel PnlPaginado;
        public System.Windows.Forms.TextBox TxtPaginaDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TxtPaginaNo;
        public System.Windows.Forms.Button BtnAnterior;
        public System.Windows.Forms.Button BtnSiguiente;
    }
}