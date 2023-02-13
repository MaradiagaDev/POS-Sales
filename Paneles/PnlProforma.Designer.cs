namespace NeoCobranza.Paneles
{
    partial class PnlProforma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlProforma));
            this.panel3 = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvBusquedas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnEliminarServicio = new NeoCobranza.Especiales.EspecialButton();
            this.DgvServicios = new System.Windows.Forms.DataGridView();
            this.IdServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCordoba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalDolar2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalCordoba2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVAD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescuentoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtnAtaud = new System.Windows.Forms.RadioButton();
            this.rbntServicios = new System.Windows.Forms.RadioButton();
            this.lblIvaC = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSubtotalC = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalD = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIvaD = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSubTotalD = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDescuentoC = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDescuentoD = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDescuentoN = new System.Windows.Forms.ComboBox();
            this.lblEstadoCliente = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblNombreColector = new System.Windows.Forms.Label();
            this.lblIdColector = new System.Windows.Forms.Label();
            this.BtnAgregarProforma = new NeoCobranza.Especiales.EspecialButton();
            this.btnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnVendd = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCliente = new NeoCobranza.Especiales.EspecialButton();
            this.BtnSeleccionar = new NeoCobranza.Especiales.EspecialButton();
            this.txtfiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvServicios)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.llbTitulo);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1158, 31);
            this.panel3.TabIndex = 4;
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.llbTitulo.Location = new System.Drawing.Point(12, 8);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(191, 20);
            this.llbTitulo.TabIndex = 0;
            this.llbTitulo.Text = "Creacion de proformas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(32, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Seleccion de :";
            // 
            // DgvBusquedas
            // 
            this.DgvBusquedas.AllowUserToAddRows = false;
            this.DgvBusquedas.AllowUserToDeleteRows = false;
            this.DgvBusquedas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvBusquedas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvBusquedas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvBusquedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBusquedas.Location = new System.Drawing.Point(13, 245);
            this.DgvBusquedas.MultiSelect = false;
            this.DgvBusquedas.Name = "DgvBusquedas";
            this.DgvBusquedas.ReadOnly = true;
            this.DgvBusquedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBusquedas.Size = new System.Drawing.Size(331, 238);
            this.DgvBusquedas.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(20, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Servicios Seleccionados";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.BtnEliminarServicio);
            this.panel1.Controls.Add(this.DgvServicios);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(397, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 303);
            this.panel1.TabIndex = 26;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnEliminarServicio
            // 
            this.BtnEliminarServicio.BackColor = System.Drawing.Color.Crimson;
            this.BtnEliminarServicio.BackGroundColor = System.Drawing.Color.Crimson;
            this.BtnEliminarServicio.BorderColor = System.Drawing.Color.Beige;
            this.BtnEliminarServicio.BorderRadius = 15;
            this.BtnEliminarServicio.BorderSize = 2;
            this.BtnEliminarServicio.FlatAppearance.BorderSize = 0;
            this.BtnEliminarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarServicio.ForeColor = System.Drawing.Color.White;
            this.BtnEliminarServicio.Location = new System.Drawing.Point(647, 269);
            this.BtnEliminarServicio.Name = "BtnEliminarServicio";
            this.BtnEliminarServicio.Size = new System.Drawing.Size(84, 31);
            this.BtnEliminarServicio.TabIndex = 36;
            this.BtnEliminarServicio.Text = "Eliminar";
            this.BtnEliminarServicio.TextGroundColor = System.Drawing.Color.White;
            this.BtnEliminarServicio.UseVisualStyleBackColor = false;
            this.BtnEliminarServicio.Click += new System.EventHandler(this.BtnEliminarServicio_Click);
            // 
            // DgvServicios
            // 
            this.DgvServicios.AllowUserToAddRows = false;
            this.DgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvServicios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvServicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdServicio,
            this.Servicio,
            this.PrecioDolar,
            this.PrecioCordoba,
            this.Cantidad,
            this.SubTotalDolar2,
            this.SubTotalCordoba2,
            this.IVAD,
            this.IVAD1,
            this.Descuento,
            this.DescuentoD});
            this.DgvServicios.Location = new System.Drawing.Point(18, 33);
            this.DgvServicios.Name = "DgvServicios";
            this.DgvServicios.ReadOnly = true;
            this.DgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvServicios.Size = new System.Drawing.Size(713, 230);
            this.DgvServicios.TabIndex = 26;
            // 
            // IdServicio
            // 
            this.IdServicio.HeaderText = "IdServicio";
            this.IdServicio.Name = "IdServicio";
            this.IdServicio.ReadOnly = true;
            this.IdServicio.Width = 79;
            // 
            // Servicio
            // 
            this.Servicio.HeaderText = "Servicio";
            this.Servicio.Name = "Servicio";
            this.Servicio.ReadOnly = true;
            this.Servicio.Width = 70;
            // 
            // PrecioDolar
            // 
            this.PrecioDolar.HeaderText = "PrecioDolar";
            this.PrecioDolar.Name = "PrecioDolar";
            this.PrecioDolar.ReadOnly = true;
            this.PrecioDolar.Width = 87;
            // 
            // PrecioCordoba
            // 
            this.PrecioCordoba.HeaderText = "PrecioCordoba";
            this.PrecioCordoba.Name = "PrecioCordoba";
            this.PrecioCordoba.ReadOnly = true;
            this.PrecioCordoba.Width = 102;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 74;
            // 
            // SubTotalDolar2
            // 
            this.SubTotalDolar2.HeaderText = "SubTotalDolar";
            this.SubTotalDolar2.Name = "SubTotalDolar2";
            this.SubTotalDolar2.ReadOnly = true;
            // 
            // SubTotalCordoba2
            // 
            this.SubTotalCordoba2.HeaderText = "SubTotalCordoba";
            this.SubTotalCordoba2.Name = "SubTotalCordoba2";
            this.SubTotalCordoba2.ReadOnly = true;
            this.SubTotalCordoba2.Width = 115;
            // 
            // IVAD
            // 
            this.IVAD.HeaderText = "IVA($)";
            this.IVAD.Name = "IVAD";
            this.IVAD.ReadOnly = true;
            this.IVAD.Width = 61;
            // 
            // IVAD1
            // 
            this.IVAD1.HeaderText = "IVA(C$)";
            this.IVAD1.Name = "IVAD1";
            this.IVAD1.ReadOnly = true;
            this.IVAD1.Width = 68;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento(%)";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 98;
            // 
            // DescuentoD
            // 
            this.DescuentoD.HeaderText = "Descuento($)";
            this.DescuentoD.Name = "DescuentoD";
            this.DescuentoD.ReadOnly = true;
            this.DescuentoD.Width = 96;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(10, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cantidad:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rbtnAtaud);
            this.flowLayoutPanel2.Controls.Add(this.rbntServicios);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(161, 169);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(178, 28);
            this.flowLayoutPanel2.TabIndex = 46;
            // 
            // rbtnAtaud
            // 
            this.rbtnAtaud.AutoSize = true;
            this.rbtnAtaud.Location = new System.Drawing.Point(3, 3);
            this.rbtnAtaud.Name = "rbtnAtaud";
            this.rbtnAtaud.Size = new System.Drawing.Size(70, 24);
            this.rbtnAtaud.TabIndex = 15;
            this.rbtnAtaud.TabStop = true;
            this.rbtnAtaud.Text = "Ataud";
            this.rbtnAtaud.UseVisualStyleBackColor = true;
            this.rbtnAtaud.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbntServicios
            // 
            this.rbntServicios.AutoSize = true;
            this.rbntServicios.Location = new System.Drawing.Point(79, 3);
            this.rbntServicios.Name = "rbntServicios";
            this.rbntServicios.Size = new System.Drawing.Size(90, 24);
            this.rbntServicios.TabIndex = 17;
            this.rbntServicios.TabStop = true;
            this.rbntServicios.Text = "Servicios";
            this.rbntServicios.UseVisualStyleBackColor = true;
            this.rbntServicios.CheckedChanged += new System.EventHandler(this.rbntServicios_CheckedChanged);
            // 
            // lblIvaC
            // 
            this.lblIvaC.AutoSize = true;
            this.lblIvaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIvaC.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblIvaC.Location = new System.Drawing.Point(846, 461);
            this.lblIvaC.Name = "lblIvaC";
            this.lblIvaC.Size = new System.Drawing.Size(18, 20);
            this.lblIvaC.TabIndex = 63;
            this.lblIvaC.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(767, 464);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 62;
            this.label14.Text = "IVA (C$):";
            // 
            // lblSubtotalC
            // 
            this.lblSubtotalC.AutoSize = true;
            this.lblSubtotalC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalC.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSubtotalC.Location = new System.Drawing.Point(846, 409);
            this.lblSubtotalC.Name = "lblSubtotalC";
            this.lblSubtotalC.Size = new System.Drawing.Size(18, 20);
            this.lblSubtotalC.TabIndex = 61;
            this.lblSubtotalC.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(736, 409);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 20);
            this.label11.TabIndex = 60;
            this.label11.Text = "SubTotal (C$):";
            // 
            // lblTotalC
            // 
            this.lblTotalC.AutoSize = true;
            this.lblTotalC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalC.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalC.Location = new System.Drawing.Point(846, 502);
            this.lblTotalC.Name = "lblTotalC";
            this.lblTotalC.Size = new System.Drawing.Size(18, 20);
            this.lblTotalC.TabIndex = 68;
            this.lblTotalC.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(758, 499);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Total (C$):";
            // 
            // lblTotalD
            // 
            this.lblTotalD.AutoSize = true;
            this.lblTotalD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalD.Location = new System.Drawing.Point(1072, 499);
            this.lblTotalD.Name = "lblTotalD";
            this.lblTotalD.Size = new System.Drawing.Size(18, 20);
            this.lblTotalD.TabIndex = 74;
            this.lblTotalD.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1000, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 73;
            this.label9.Text = "Total ($):";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblIvaD
            // 
            this.lblIvaD.AutoSize = true;
            this.lblIvaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIvaD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblIvaD.Location = new System.Drawing.Point(1073, 464);
            this.lblIvaD.Name = "lblIvaD";
            this.lblIvaD.Size = new System.Drawing.Size(18, 20);
            this.lblIvaD.TabIndex = 72;
            this.lblIvaD.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1005, 461);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 71;
            this.label12.Text = "IVA ($):";
            // 
            // lblSubTotalD
            // 
            this.lblSubTotalD.AutoSize = true;
            this.lblSubTotalD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSubTotalD.Location = new System.Drawing.Point(1072, 409);
            this.lblSubTotalD.Name = "lblSubTotalD";
            this.lblSubTotalD.Size = new System.Drawing.Size(18, 20);
            this.lblSubTotalD.TabIndex = 70;
            this.lblSubTotalD.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(966, 409);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 69;
            this.label15.Text = "SubTotal ($):";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(95, 492);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(125, 22);
            this.txtCantidad.TabIndex = 77;
            this.txtCantidad.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(824, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Valores de la Proforma";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(13, 530);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 79;
            this.label8.Text = "Descuento(%):";
            // 
            // lblDescuentoC
            // 
            this.lblDescuentoC.AutoSize = true;
            this.lblDescuentoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoC.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDescuentoC.Location = new System.Drawing.Point(846, 436);
            this.lblDescuentoC.Name = "lblDescuentoC";
            this.lblDescuentoC.Size = new System.Drawing.Size(18, 20);
            this.lblDescuentoC.TabIndex = 81;
            this.lblDescuentoC.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(730, 436);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 20);
            this.label13.TabIndex = 80;
            this.label13.Text = "Descuento(C$):";
            // 
            // lblDescuentoD
            // 
            this.lblDescuentoD.AutoSize = true;
            this.lblDescuentoD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDescuentoD.Location = new System.Drawing.Point(1072, 436);
            this.lblDescuentoD.Name = "lblDescuentoD";
            this.lblDescuentoD.Size = new System.Drawing.Size(18, 20);
            this.lblDescuentoD.TabIndex = 83;
            this.lblDescuentoD.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(956, 436);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 20);
            this.label16.TabIndex = 82;
            this.label16.Text = "Descuento($):";
            // 
            // lblDescuentoN
            // 
            this.lblDescuentoN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoN.FormattingEnabled = true;
            this.lblDescuentoN.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "15.38",
            "20"});
            this.lblDescuentoN.Location = new System.Drawing.Point(139, 532);
            this.lblDescuentoN.Name = "lblDescuentoN";
            this.lblDescuentoN.Size = new System.Drawing.Size(121, 24);
            this.lblDescuentoN.TabIndex = 84;
            this.lblDescuentoN.Text = "0";
            // 
            // lblEstadoCliente
            // 
            this.lblEstadoCliente.AutoSize = true;
            this.lblEstadoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoCliente.ForeColor = System.Drawing.Color.Red;
            this.lblEstadoCliente.Location = new System.Drawing.Point(241, 106);
            this.lblEstadoCliente.Name = "lblEstadoCliente";
            this.lblEstadoCliente.Size = new System.Drawing.Size(93, 18);
            this.lblEstadoCliente.TabIndex = 92;
            this.lblEstadoCliente.Text = "Sin Registrar";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label24.Location = new System.Drawing.Point(180, 106);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 18);
            this.label24.TabIndex = 91;
            this.label24.Text = "Estado:";
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCliente.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblIdCliente.Location = new System.Drawing.Point(102, 104);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(12, 18);
            this.lblIdCliente.TabIndex = 90;
            this.lblIdCliente.Text = ".";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(10, 79);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(12, 18);
            this.lblNombreCliente.TabIndex = 89;
            this.lblNombreCliente.Text = ".";
            this.lblNombreCliente.TextChanged += new System.EventHandler(this.lblNombreCliente_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label21.Location = new System.Drawing.Point(10, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 18);
            this.label21.TabIndex = 88;
            this.label21.Text = "Id Cliente:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label22.Location = new System.Drawing.Point(10, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 18);
            this.label22.TabIndex = 87;
            this.label22.Text = "Nombre del Cliente:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 18);
            this.label10.TabIndex = 85;
            this.label10.Text = "Informacion del Cliente ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(417, 346);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 20);
            this.label17.TabIndex = 93;
            this.label17.Text = "Observaciones Generales";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(415, 368);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(283, 61);
            this.txtObservaciones.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(429, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 18);
            this.label3.TabIndex = 95;
            this.label3.Text = "Informacion del vendedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(429, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 97;
            this.label5.Text = "Nombre:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label18.Location = new System.Drawing.Point(429, 503);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 18);
            this.label18.TabIndex = 98;
            this.label18.Text = "Id vendedor:";
            // 
            // lblNombreColector
            // 
            this.lblNombreColector.AutoSize = true;
            this.lblNombreColector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreColector.Location = new System.Drawing.Point(501, 476);
            this.lblNombreColector.Name = "lblNombreColector";
            this.lblNombreColector.Size = new System.Drawing.Size(12, 18);
            this.lblNombreColector.TabIndex = 99;
            this.lblNombreColector.Text = ".";
            // 
            // lblIdColector
            // 
            this.lblIdColector.AutoSize = true;
            this.lblIdColector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdColector.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblIdColector.Location = new System.Drawing.Point(521, 503);
            this.lblIdColector.Name = "lblIdColector";
            this.lblIdColector.Size = new System.Drawing.Size(12, 18);
            this.lblIdColector.TabIndex = 100;
            this.lblIdColector.Text = ".";
            // 
            // BtnAgregarProforma
            // 
            this.BtnAgregarProforma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAgregarProforma.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnAgregarProforma.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnAgregarProforma.BorderColor = System.Drawing.Color.Lime;
            this.BtnAgregarProforma.BorderRadius = 15;
            this.BtnAgregarProforma.BorderSize = 2;
            this.BtnAgregarProforma.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProforma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarProforma.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProforma.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarProforma.Image")));
            this.BtnAgregarProforma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarProforma.Location = new System.Drawing.Point(946, 563);
            this.BtnAgregarProforma.Name = "BtnAgregarProforma";
            this.BtnAgregarProforma.Size = new System.Drawing.Size(199, 32);
            this.BtnAgregarProforma.TabIndex = 19;
            this.BtnAgregarProforma.Text = "Crear Proforma";
            this.BtnAgregarProforma.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarProforma.UseVisualStyleBackColor = false;
            this.BtnAgregarProforma.Click += new System.EventHandler(this.BtnAgregarProforma_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnActualizar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActualizar.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnActualizar.BorderColor = System.Drawing.Color.Lime;
            this.btnActualizar.BorderRadius = 15;
            this.btnActualizar.BorderSize = 2;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(648, 564);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(154, 32);
            this.btnActualizar.TabIndex = 95;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextGroundColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 15;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(828, 564);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnVendd
            // 
            this.BtnVendd.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnVendd.BackGroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnVendd.BorderColor = System.Drawing.Color.Lime;
            this.BtnVendd.BorderRadius = 40;
            this.BtnVendd.BorderSize = 2;
            this.BtnVendd.FlatAppearance.BorderSize = 0;
            this.BtnVendd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVendd.ForeColor = System.Drawing.Color.White;
            this.BtnVendd.Image = ((System.Drawing.Image)(resources.GetObject("BtnVendd.Image")));
            this.BtnVendd.Location = new System.Drawing.Point(648, 517);
            this.BtnVendd.Name = "BtnVendd";
            this.BtnVendd.Size = new System.Drawing.Size(33, 31);
            this.BtnVendd.TabIndex = 96;
            this.BtnVendd.TextGroundColor = System.Drawing.Color.White;
            this.BtnVendd.UseVisualStyleBackColor = false;
            this.BtnVendd.Click += new System.EventHandler(this.especialButton2_Click);
            // 
            // BtnCliente
            // 
            this.BtnCliente.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnCliente.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnCliente.BorderColor = System.Drawing.Color.Lime;
            this.BtnCliente.BorderRadius = 40;
            this.BtnCliente.BorderSize = 2;
            this.BtnCliente.FlatAppearance.BorderSize = 0;
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.ForeColor = System.Drawing.Color.White;
            this.BtnCliente.Image = ((System.Drawing.Image)(resources.GetObject("BtnCliente.Image")));
            this.BtnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCliente.Location = new System.Drawing.Point(342, 129);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(32, 31);
            this.BtnCliente.TabIndex = 86;
            this.BtnCliente.TextGroundColor = System.Drawing.Color.White;
            this.BtnCliente.UseVisualStyleBackColor = false;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnSeleccionar.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnSeleccionar.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnSeleccionar.BorderColor = System.Drawing.Color.Lime;
            this.BtnSeleccionar.BorderRadius = 10;
            this.BtnSeleccionar.BorderSize = 2;
            this.BtnSeleccionar.FlatAppearance.BorderSize = 0;
            this.BtnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.BtnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("BtnSeleccionar.Image")));
            this.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSeleccionar.Location = new System.Drawing.Point(234, 487);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(160, 32);
            this.BtnSeleccionar.TabIndex = 24;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.TextGroundColor = System.Drawing.Color.White;
            this.BtnSeleccionar.UseVisualStyleBackColor = false;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // txtfiltro
            // 
            this.txtfiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtfiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtfiltro.BorderRadius = 0;
            this.txtfiltro.BorderSize = 2;
            this.txtfiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtfiltro.Location = new System.Drawing.Point(14, 205);
            this.txtfiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtfiltro.Multilinea = false;
            this.txtfiltro.Name = "txtfiltro";
            this.txtfiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfiltro.PasswordChar = false;
            this.txtfiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtfiltro.PlaceHolderText = "Buscar Servicio..";
            this.txtfiltro.Size = new System.Drawing.Size(331, 35);
            this.txtfiltro.TabIndex = 21;
            this.txtfiltro.Texts = "";
            this.txtfiltro.UnderLineFlat = true;
            this.txtfiltro._TextChanged += new System.EventHandler(this.txtfiltro__TextChanged);
            // 
            // PnlProforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.BtnAgregarProforma);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnVendd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblNombreColector);
            this.Controls.Add(this.lblIdColector);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblEstadoCliente);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblIdCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.BtnCliente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDescuentoN);
            this.Controls.Add(this.lblDescuentoD);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblDescuentoC);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblTotalD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblIvaD);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblSubTotalD);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblTotalC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblIvaC);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblSubtotalC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvBusquedas);
            this.Controls.Add(this.txtfiltro);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlProforma";
            this.Text = "PnlProforma";
            this.Load += new System.EventHandler(this.PnlProforma_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvServicios)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Especiales.EspecialButton BtnSeleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvBusquedas;
        private Controladores.LoginUserControl txtfiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvServicios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rbtnAtaud;
        private System.Windows.Forms.RadioButton rbntServicios;
        private System.Windows.Forms.Label lblIvaC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSubtotalC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTotalC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIvaD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSubTotalD;
        private System.Windows.Forms.Label label15;
        private Especiales.EspecialButton BtnAgregarProforma;
        private Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCordoba;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalDolar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalCordoba2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVAD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescuentoD;
        private System.Windows.Forms.Label lblDescuentoC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDescuentoD;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox lblDescuentoN;
        public System.Windows.Forms.Label lblEstadoCliente;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label lblIdCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private Especiales.EspecialButton BtnCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private Especiales.EspecialButton BtnEliminarServicio;
        private System.Windows.Forms.TextBox txtObservaciones;
        public System.Windows.Forms.Label llbTitulo;
        private Especiales.EspecialButton btnActualizar;
        private System.Windows.Forms.Label label3;
        private Especiales.EspecialButton BtnVendd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label lblNombreColector;
        public System.Windows.Forms.Label lblIdColector;
    }
}