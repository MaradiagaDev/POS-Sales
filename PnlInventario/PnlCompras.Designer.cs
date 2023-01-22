namespace NeoCobranza.PnlInventario
{
    partial class PnlCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlCompras));
            this.panel3 = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.PnlPrincipal = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemision = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnNuevoProducto = new NeoCobranza.Especiales.EspecialButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMejora = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.txtPrecioContrato = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.BtnAgregarModelo = new NeoCobranza.Especiales.EspecialButton();
            this.txtNombreProveedor = new System.Windows.Forms.Label();
            this.txtEstadoProveedor = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtIdProveedor = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.BtnProveedor = new NeoCobranza.Especiales.EspecialButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreServicio = new NeoCobranza.Controladores.LoginUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMargenContrato = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMargen = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNoRemisionReal = new System.Windows.Forms.TextBox();
            this.txtTraslado = new NeoCobranza.Especiales.EspecialButton();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMostrarMejora = new System.Windows.Forms.TextBox();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnFijarPrecio = new NeoCobranza.Especiales.EspecialButton();
            this.BtnAnularCompra = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.PnlPrincipal.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.llbTitulo);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1158, 37);
            this.panel3.TabIndex = 77;
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.llbTitulo.Location = new System.Drawing.Point(12, 8);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(310, 24);
            this.llbTitulo.TabIndex = 0;
            this.llbTitulo.Text = "Compra de Inventario Comercial";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(308, 24);
            this.label10.TabIndex = 86;
            this.label10.Text = "Seleccione la accion a realizar: ";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(12, 150);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(390, 237);
            this.dgvStock.TabIndex = 87;
            // 
            // PnlPrincipal
            // 
            this.PnlPrincipal.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PnlPrincipal.Controls.Add(this.label3);
            this.PnlPrincipal.Controls.Add(this.txtNoSerie);
            this.PnlPrincipal.Controls.Add(this.label5);
            this.PnlPrincipal.Controls.Add(this.txtColor);
            this.PnlPrincipal.Controls.Add(this.label9);
            this.PnlPrincipal.Controls.Add(this.txtRemision);
            this.PnlPrincipal.Controls.Add(this.label11);
            this.PnlPrincipal.Controls.Add(this.btnNuevoProducto);
            this.PnlPrincipal.Location = new System.Drawing.Point(421, 315);
            this.PnlPrincipal.Name = "PnlPrincipal";
            this.PnlPrincipal.Size = new System.Drawing.Size(724, 199);
            this.PnlPrincipal.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 147;
            this.label3.Text = "NoSerie: ";
            // 
            // txtNoSerie
            // 
            this.txtNoSerie.Location = new System.Drawing.Point(151, 146);
            this.txtNoSerie.Name = "txtNoSerie";
            this.txtNoSerie.Size = new System.Drawing.Size(236, 20);
            this.txtNoSerie.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(31, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = "Color: ";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(151, 70);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(236, 20);
            this.txtColor.TabIndex = 144;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 143;
            this.label9.Text = "NoFactura: ";
            // 
            // txtRemision
            // 
            this.txtRemision.Location = new System.Drawing.Point(151, 107);
            this.txtRemision.Name = "txtRemision";
            this.txtRemision.Size = new System.Drawing.Size(236, 20);
            this.txtRemision.TabIndex = 142;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(8, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(318, 24);
            this.label11.TabIndex = 141;
            this.label11.Text = "Digite la informacion de compra: ";
            // 
            // btnNuevoProducto
            // 
            this.btnNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnNuevoProducto.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNuevoProducto.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnNuevoProducto.BorderColor = System.Drawing.Color.Lime;
            this.btnNuevoProducto.BorderRadius = 10;
            this.btnNuevoProducto.BorderSize = 2;
            this.btnNuevoProducto.FlatAppearance.BorderSize = 0;
            this.btnNuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoProducto.ForeColor = System.Drawing.Color.White;
            this.btnNuevoProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoProducto.Image")));
            this.btnNuevoProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoProducto.Location = new System.Drawing.Point(479, 149);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Size = new System.Drawing.Size(231, 36);
            this.btnNuevoProducto.TabIndex = 96;
            this.btnNuevoProducto.Text = "Comprar Producto";
            this.btnNuevoProducto.TextGroundColor = System.Drawing.Color.White;
            this.btnNuevoProducto.UseVisualStyleBackColor = false;
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.txtMejora);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.cmbTipoServicio);
            this.panel6.Controls.Add(this.txtPrecioContrato);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.txtPrecioVenta);
            this.panel6.Controls.Add(this.BtnAgregarModelo);
            this.panel6.Controls.Add(this.txtNombreProveedor);
            this.panel6.Controls.Add(this.txtEstadoProveedor);
            this.panel6.Controls.Add(this.label24);
            this.panel6.Controls.Add(this.txtIdProveedor);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.BtnProveedor);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.txtNombreServicio);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(421, 44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(724, 266);
            this.panel6.TabIndex = 117;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label17.Location = new System.Drawing.Point(354, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(135, 20);
            this.label17.TabIndex = 146;
            this.label17.Text = "Precio de Mejora: ";
            // 
            // txtMejora
            // 
            this.txtMejora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMejora.Location = new System.Drawing.Point(507, 108);
            this.txtMejora.Name = "txtMejora";
            this.txtMejora.Size = new System.Drawing.Size(116, 26);
            this.txtMejora.TabIndex = 145;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label16.Location = new System.Drawing.Point(506, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 20);
            this.label16.TabIndex = 144;
            this.label16.Text = "Tipo de  Servicio: ";
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Items.AddRange(new object[] {
            "Ataud",
            "Servicio"});
            this.cmbTipoServicio.Location = new System.Drawing.Point(499, 34);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(139, 26);
            this.cmbTipoServicio.TabIndex = 143;
            // 
            // txtPrecioContrato
            // 
            this.txtPrecioContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioContrato.Location = new System.Drawing.Point(507, 71);
            this.txtPrecioContrato.Name = "txtPrecioContrato";
            this.txtPrecioContrato.Size = new System.Drawing.Size(116, 26);
            this.txtPrecioContrato.TabIndex = 141;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(354, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 20);
            this.label12.TabIndex = 142;
            this.label12.Text = "Precio de Contrato: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label13.Location = new System.Drawing.Point(19, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(185, 20);
            this.label13.TabIndex = 140;
            this.label13.Text = "Precio de Venta Directa: ";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(207, 86);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(116, 26);
            this.txtPrecioVenta.TabIndex = 139;
            // 
            // BtnAgregarModelo
            // 
            this.BtnAgregarModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAgregarModelo.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnAgregarModelo.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnAgregarModelo.BorderColor = System.Drawing.Color.Lime;
            this.BtnAgregarModelo.BorderRadius = 10;
            this.BtnAgregarModelo.BorderSize = 2;
            this.BtnAgregarModelo.FlatAppearance.BorderSize = 0;
            this.BtnAgregarModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarModelo.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarModelo.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarModelo.Image")));
            this.BtnAgregarModelo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarModelo.Location = new System.Drawing.Point(479, 225);
            this.BtnAgregarModelo.Name = "BtnAgregarModelo";
            this.BtnAgregarModelo.Size = new System.Drawing.Size(231, 32);
            this.BtnAgregarModelo.TabIndex = 119;
            this.BtnAgregarModelo.Text = "Ingresar Nuevo Modelo";
            this.BtnAgregarModelo.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarModelo.UseVisualStyleBackColor = false;
            this.BtnAgregarModelo.Click += new System.EventHandler(this.BtnAgregarModelo_Click);
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.AutoSize = true;
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNombreProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombreProveedor.Location = new System.Drawing.Point(194, 182);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(13, 20);
            this.txtNombreProveedor.TabIndex = 138;
            this.txtNombreProveedor.Text = ".";
            // 
            // txtEstadoProveedor
            // 
            this.txtEstadoProveedor.AutoSize = true;
            this.txtEstadoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEstadoProveedor.ForeColor = System.Drawing.Color.Red;
            this.txtEstadoProveedor.Location = new System.Drawing.Point(94, 236);
            this.txtEstadoProveedor.Name = "txtEstadoProveedor";
            this.txtEstadoProveedor.Size = new System.Drawing.Size(101, 20);
            this.txtEstadoProveedor.TabIndex = 137;
            this.txtEstadoProveedor.Text = "Sin Registrar";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label24.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label24.Location = new System.Drawing.Point(19, 236);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 20);
            this.label24.TabIndex = 136;
            this.label24.Text = "Estado:";
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.AutoSize = true;
            this.txtIdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtIdProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtIdProveedor.Location = new System.Drawing.Point(126, 209);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(13, 20);
            this.txtIdProveedor.TabIndex = 135;
            this.txtIdProveedor.Text = ".";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label21.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label21.Location = new System.Drawing.Point(17, 209);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 20);
            this.label21.TabIndex = 134;
            this.label21.Text = "Id Proveedor:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label22.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label22.Location = new System.Drawing.Point(18, 182);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(170, 20);
            this.label22.TabIndex = 133;
            this.label22.Text = "Nombre del Proveedor:";
            // 
            // BtnProveedor
            // 
            this.BtnProveedor.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnProveedor.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnProveedor.BorderColor = System.Drawing.Color.Lime;
            this.BtnProveedor.BorderRadius = 40;
            this.BtnProveedor.BorderSize = 2;
            this.BtnProveedor.FlatAppearance.BorderSize = 0;
            this.BtnProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProveedor.ForeColor = System.Drawing.Color.White;
            this.BtnProveedor.Image = ((System.Drawing.Image)(resources.GetObject("BtnProveedor.Image")));
            this.BtnProveedor.Location = new System.Drawing.Point(316, 225);
            this.BtnProveedor.Name = "BtnProveedor";
            this.BtnProveedor.Size = new System.Drawing.Size(34, 29);
            this.BtnProveedor.TabIndex = 132;
            this.BtnProveedor.TextGroundColor = System.Drawing.Color.White;
            this.BtnProveedor.UseVisualStyleBackColor = false;
            this.BtnProveedor.Click += new System.EventHandler(this.BtnProveedor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(11, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 18);
            this.label4.TabIndex = 131;
            this.label4.Text = "Seleccion de Proveedor: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(8, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 24);
            this.label8.TabIndex = 119;
            this.label8.Text = "Ingresar Nuevo Producto";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtNombreServicio.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNombreServicio.BorderRadius = 10;
            this.txtNombreServicio.BorderSize = 2;
            this.txtNombreServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombreServicio.Location = new System.Drawing.Point(13, 34);
            this.txtNombreServicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreServicio.Multilinea = false;
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNombreServicio.PasswordChar = false;
            this.txtNombreServicio.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtNombreServicio.PlaceHolderText = "Nuevo Producto..";
            this.txtNombreServicio.Size = new System.Drawing.Size(461, 35);
            this.txtNombreServicio.TabIndex = 3;
            this.txtNombreServicio.Texts = "";
            this.txtNombreServicio.UnderLineFlat = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(47, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 130;
            this.label6.Text = "Precio de Contrato: ";
            // 
            // txtMargenContrato
            // 
            this.txtMargenContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMargenContrato.Location = new System.Drawing.Point(201, 494);
            this.txtMargenContrato.Name = "txtMargenContrato";
            this.txtMargenContrato.Size = new System.Drawing.Size(116, 26);
            this.txtMargenContrato.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label7.Location = new System.Drawing.Point(13, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 20);
            this.label7.TabIndex = 128;
            this.label7.Text = "Precio de Venta Directa: ";
            // 
            // txtMargen
            // 
            this.txtMargen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMargen.Location = new System.Drawing.Point(201, 462);
            this.txtMargen.Name = "txtMargen";
            this.txtMargen.Size = new System.Drawing.Size(116, 26);
            this.txtMargen.TabIndex = 127;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DisplayMember = "NombreEstandar";
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(17, 73);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(385, 24);
            this.cmbCategoria.TabIndex = 2;
            this.cmbCategoria.ValueMember = "NombreEstandar";
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione el Modelo";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Items.AddRange(new object[] {
            "Managua",
            "Boaco",
            "Carazo",
            "Chinandega",
            "Chontales",
            "Esteli",
            "Granada",
            "Jinotega",
            "Leon",
            "Madriz",
            "Masaya",
            "Matagalpa",
            "Nueva Segovia",
            "Rio San Juan",
            "Rivas",
            "RAAS",
            "RAAN"});
            this.cmbDepartamento.Location = new System.Drawing.Point(213, 10);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(192, 28);
            this.cmbDepartamento.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtNoRemisionReal);
            this.panel1.Controls.Add(this.cmbDepartamento);
            this.panel1.Controls.Add(this.txtTraslado);
            this.panel1.Location = new System.Drawing.Point(421, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 74);
            this.panel1.TabIndex = 134;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(78, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 20);
            this.label14.TabIndex = 149;
            this.label14.Text = "NoRemision: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(8, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(176, 24);
            this.label15.TabIndex = 148;
            this.label15.Text = "Realizar traslado: ";
            // 
            // txtNoRemisionReal
            // 
            this.txtNoRemisionReal.Location = new System.Drawing.Point(213, 46);
            this.txtNoRemisionReal.Name = "txtNoRemisionReal";
            this.txtNoRemisionReal.Size = new System.Drawing.Size(192, 20);
            this.txtNoRemisionReal.TabIndex = 148;
            // 
            // txtTraslado
            // 
            this.txtTraslado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtTraslado.BackColor = System.Drawing.Color.ForestGreen;
            this.txtTraslado.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.txtTraslado.BorderColor = System.Drawing.Color.Lime;
            this.txtTraslado.BorderRadius = 10;
            this.txtTraslado.BorderSize = 2;
            this.txtTraslado.FlatAppearance.BorderSize = 0;
            this.txtTraslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraslado.ForeColor = System.Drawing.Color.White;
            this.txtTraslado.Image = ((System.Drawing.Image)(resources.GetObject("txtTraslado.Image")));
            this.txtTraslado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtTraslado.Location = new System.Drawing.Point(423, 41);
            this.txtTraslado.Name = "txtTraslado";
            this.txtTraslado.Size = new System.Drawing.Size(188, 32);
            this.txtTraslado.TabIndex = 131;
            this.txtTraslado.Text = "Traslado";
            this.txtTraslado.TextGroundColor = System.Drawing.Color.White;
            this.txtTraslado.UseVisualStyleBackColor = false;
            this.txtTraslado.Click += new System.EventHandler(this.txtTraslado_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label18.Location = new System.Drawing.Point(61, 527);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 20);
            this.label18.TabIndex = 148;
            this.label18.Text = "Precio de Mejora: ";
            // 
            // txtMostrarMejora
            // 
            this.txtMostrarMejora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMostrarMejora.Location = new System.Drawing.Point(202, 525);
            this.txtMostrarMejora.Name = "txtMostrarMejora";
            this.txtMostrarMejora.Size = new System.Drawing.Size(116, 26);
            this.txtMostrarMejora.TabIndex = 147;
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.especialButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BorderColor = System.Drawing.Color.Lime;
            this.especialButton1.BorderRadius = 10;
            this.especialButton1.BorderSize = 2;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(201, 417);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(188, 32);
            this.especialButton1.TabIndex = 145;
            this.especialButton1.Text = "Realizar Informe";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 40;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(1050, 567);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 34);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnFijarPrecio
            // 
            this.BtnFijarPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnFijarPrecio.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnFijarPrecio.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnFijarPrecio.BorderColor = System.Drawing.Color.Lime;
            this.BtnFijarPrecio.BorderRadius = 10;
            this.BtnFijarPrecio.BorderSize = 2;
            this.BtnFijarPrecio.FlatAppearance.BorderSize = 0;
            this.BtnFijarPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFijarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFijarPrecio.ForeColor = System.Drawing.Color.White;
            this.BtnFijarPrecio.Image = ((System.Drawing.Image)(resources.GetObject("BtnFijarPrecio.Image")));
            this.BtnFijarPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFijarPrecio.Location = new System.Drawing.Point(227, 561);
            this.BtnFijarPrecio.Name = "BtnFijarPrecio";
            this.BtnFijarPrecio.Size = new System.Drawing.Size(175, 32);
            this.BtnFijarPrecio.TabIndex = 118;
            this.BtnFijarPrecio.Text = "Fijacion de Precio";
            this.BtnFijarPrecio.TextGroundColor = System.Drawing.Color.White;
            this.BtnFijarPrecio.UseVisualStyleBackColor = false;
            this.BtnFijarPrecio.Click += new System.EventHandler(this.BtnFijarPrecio_Click);
            // 
            // BtnAnularCompra
            // 
            this.BtnAnularCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAnularCompra.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnAnularCompra.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnAnularCompra.BorderColor = System.Drawing.Color.Lime;
            this.BtnAnularCompra.BorderRadius = 10;
            this.BtnAnularCompra.BorderSize = 2;
            this.BtnAnularCompra.FlatAppearance.BorderSize = 0;
            this.BtnAnularCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAnularCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnularCompra.ForeColor = System.Drawing.Color.White;
            this.BtnAnularCompra.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnularCompra.Image")));
            this.BtnAnularCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAnularCompra.Location = new System.Drawing.Point(10, 416);
            this.BtnAnularCompra.Name = "BtnAnularCompra";
            this.BtnAnularCompra.Size = new System.Drawing.Size(188, 32);
            this.BtnAnularCompra.TabIndex = 97;
            this.BtnAnularCompra.Text = "Anular Compra";
            this.BtnAnularCompra.TextGroundColor = System.Drawing.Color.White;
            this.BtnAnularCompra.UseVisualStyleBackColor = false;
            this.BtnAnularCompra.Click += new System.EventHandler(this.BtnProductoExistente_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltro.BorderRadius = 0;
            this.txtFiltro.BorderSize = 2;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltro.Location = new System.Drawing.Point(12, 104);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar ataud..";
            this.txtFiltro.Size = new System.Drawing.Size(390, 39);
            this.txtFiltro.TabIndex = 88;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
            // 
            // PnlCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtMostrarMejora);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.BtnFijarPrecio);
            this.Controls.Add(this.BtnAnularCompra);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.PnlPrincipal);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMargenContrato);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMargen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCompras";
            this.Text = "PnlCompras";
            this.Load += new System.EventHandler(this.PnlCompras_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.PnlPrincipal.ResumeLayout(false);
            this.PnlPrincipal.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label llbTitulo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvStock;
        private Controladores.LoginUserControl txtFiltro;
        private Especiales.EspecialButton btnNuevoProducto;
        private Especiales.EspecialButton BtnAnularCompra;
        private System.Windows.Forms.Panel PnlPrincipal;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controladores.LoginUserControl txtNombreServicio;
        private Especiales.EspecialButton BtnFijarPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMargenContrato;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtMargen;
        private Especiales.EspecialButton BtnAgregarModelo;
        public System.Windows.Forms.Label txtNombreProveedor;
        public System.Windows.Forms.Label txtEstadoProveedor;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label txtIdProveedor;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private Especiales.EspecialButton BtnProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtNoSerie;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtRemision;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtPrecioContrato;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtPrecioVenta;
        private Especiales.EspecialButton txtTraslado;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Panel panel1;
        private Especiales.EspecialButton especialButton1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtNoRemisionReal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtMejora;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtMostrarMejora;
    }
}