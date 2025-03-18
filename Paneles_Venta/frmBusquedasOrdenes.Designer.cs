namespace NeoCobranza.Paneles_Venta
{
    partial class frmBusquedasOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedasOrdenes));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.dgvCatalogoOrdenes = new System.Windows.Forms.DataGridView();
            this.CmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSucursal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PnlPaginado = new System.Windows.Forms.Panel();
            this.TxtPaginaDe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPaginaNo = new System.Windows.Forms.TextBox();
            this.BtnAnterior = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtColocado = new System.Windows.Forms.TextBox();
            this.TxtRecuperado = new System.Windows.Forms.TextBox();
            this.TxtRestante = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DtInicio = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.DtFin = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbFiltrarFecha = new System.Windows.Forms.ComboBox();
            this.CmbSegmentacion = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ChkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.TxtFiltrar = new NeoCobranza.Controladores.LoginUserControl();
            this.BtnPagarOrdenes = new NeoCobranza.Especiales.EspecialButton();
            this.BtnExcel = new NeoCobranza.Especiales.EspecialButton();
            this.BtnPdf = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoOrdenes)).BeginInit();
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
            this.PnlTitulo.Size = new System.Drawing.Size(1159, 44);
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
            this.llbTitulo.Size = new System.Drawing.Size(178, 33);
            this.llbTitulo.TabIndex = 1;
            this.llbTitulo.Text = "Crear Venta";
            // 
            // dgvCatalogoOrdenes
            // 
            this.dgvCatalogoOrdenes.AllowUserToAddRows = false;
            this.dgvCatalogoOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogoOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogoOrdenes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCatalogoOrdenes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCatalogoOrdenes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogoOrdenes.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogoOrdenes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogoOrdenes.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogoOrdenes.Location = new System.Drawing.Point(16, 111);
            this.dgvCatalogoOrdenes.Name = "dgvCatalogoOrdenes";
            this.dgvCatalogoOrdenes.ReadOnly = true;
            this.dgvCatalogoOrdenes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoOrdenes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogoOrdenes.RowHeadersWidth = 15;
            this.dgvCatalogoOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogoOrdenes.Size = new System.Drawing.Size(1116, 255);
            this.dgvCatalogoOrdenes.TabIndex = 148;
            this.dgvCatalogoOrdenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogoOrdenes_CellContentClick);
            // 
            // CmbBuscarPor
            // 
            this.CmbBuscarPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbBuscarPor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBuscarPor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBuscarPor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbBuscarPor.FormattingEnabled = true;
            this.CmbBuscarPor.Items.AddRange(new object[] {
            "Nombre Cliente",
            "No Orden",
            "No Factura",
            "Código"});
            this.CmbBuscarPor.Location = new System.Drawing.Point(676, 25);
            this.CmbBuscarPor.Name = "CmbBuscarPor";
            this.CmbBuscarPor.Size = new System.Drawing.Size(223, 29);
            this.CmbBuscarPor.TabIndex = 151;
            this.CmbBuscarPor.SelectedIndexChanged += new System.EventHandler(this.CmbBuscarPor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(679, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 150;
            this.label1.Text = "Buscar Por:";
            // 
            // CmbSucursal
            // 
            this.CmbSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSucursal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbSucursal.FormattingEnabled = true;
            this.CmbSucursal.Location = new System.Drawing.Point(905, 25);
            this.CmbSucursal.Name = "CmbSucursal";
            this.CmbSucursal.Size = new System.Drawing.Size(208, 29);
            this.CmbSucursal.TabIndex = 153;
            this.CmbSucursal.SelectedIndexChanged += new System.EventHandler(this.CmbSucursal_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(902, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 152;
            this.label5.Text = "Sucursal:";
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
            this.PnlPaginado.Location = new System.Drawing.Point(12, 449);
            this.PnlPaginado.Name = "PnlPaginado";
            this.PnlPaginado.Size = new System.Drawing.Size(545, 47);
            this.PnlPaginado.TabIndex = 154;
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(579, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Colocado:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(579, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 19);
            this.label6.TabIndex = 155;
            this.label6.Text = "Recuperado:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(880, 479);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 156;
            this.label7.Text = "Restante:";
            // 
            // TxtColocado
            // 
            this.TxtColocado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtColocado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColocado.Location = new System.Drawing.Point(694, 444);
            this.TxtColocado.Name = "TxtColocado";
            this.TxtColocado.ReadOnly = true;
            this.TxtColocado.Size = new System.Drawing.Size(180, 27);
            this.TxtColocado.TabIndex = 6;
            // 
            // TxtRecuperado
            // 
            this.TxtRecuperado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRecuperado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRecuperado.Location = new System.Drawing.Point(694, 479);
            this.TxtRecuperado.Name = "TxtRecuperado";
            this.TxtRecuperado.ReadOnly = true;
            this.TxtRecuperado.Size = new System.Drawing.Size(180, 27);
            this.TxtRecuperado.TabIndex = 157;
            // 
            // TxtRestante
            // 
            this.TxtRestante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRestante.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRestante.Location = new System.Drawing.Point(963, 475);
            this.TxtRestante.Name = "TxtRestante";
            this.TxtRestante.ReadOnly = true;
            this.TxtRestante.Size = new System.Drawing.Size(180, 27);
            this.TxtRestante.TabIndex = 158;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(15, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 159;
            this.label8.Text = "Filtro por fecha:";
            // 
            // DtInicio
            // 
            this.DtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtInicio.Location = new System.Drawing.Point(139, 73);
            this.DtInicio.Name = "DtInicio";
            this.DtInicio.Size = new System.Drawing.Size(118, 20);
            this.DtInicio.TabIndex = 160;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(277, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 161;
            this.label9.Text = "Hasta";
            // 
            // DtFin
            // 
            this.DtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFin.Location = new System.Drawing.Point(353, 74);
            this.DtFin.Name = "DtFin";
            this.DtFin.Size = new System.Drawing.Size(109, 20);
            this.DtFin.TabIndex = 162;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(487, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 163;
            this.label10.Text = "Filtrar por";
            // 
            // CmbFiltrarFecha
            // 
            this.CmbFiltrarFecha.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbFiltrarFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltrarFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltrarFecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbFiltrarFecha.FormattingEnabled = true;
            this.CmbFiltrarFecha.Items.AddRange(new object[] {
            "Fecha de Realización",
            "Fecha de Pago"});
            this.CmbFiltrarFecha.Location = new System.Drawing.Point(573, 68);
            this.CmbFiltrarFecha.Name = "CmbFiltrarFecha";
            this.CmbFiltrarFecha.Size = new System.Drawing.Size(249, 29);
            this.CmbFiltrarFecha.TabIndex = 164;
            this.CmbFiltrarFecha.SelectedIndexChanged += new System.EventHandler(this.CmbFiltrarFecha_SelectedIndexChanged);
            // 
            // CmbSegmentacion
            // 
            this.CmbSegmentacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSegmentacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmbSegmentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSegmentacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSegmentacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmbSegmentacion.FormattingEnabled = true;
            this.CmbSegmentacion.Items.AddRange(new object[] {
            "ID",
            "Nombre del Cliente",
            "Identificación"});
            this.CmbSegmentacion.Location = new System.Drawing.Point(695, 394);
            this.CmbSegmentacion.Name = "CmbSegmentacion";
            this.CmbSegmentacion.Size = new System.Drawing.Size(418, 29);
            this.CmbSegmentacion.TabIndex = 168;
            this.CmbSegmentacion.SelectedIndexChanged += new System.EventHandler(this.CmbSegmentacion_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(569, 401);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 167;
            this.label11.Text = "Segmentación:";
            // 
            // ChkSeleccionarTodo
            // 
            this.ChkSeleccionarTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkSeleccionarTodo.AutoSize = true;
            this.ChkSeleccionarTodo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkSeleccionarTodo.Location = new System.Drawing.Point(18, 372);
            this.ChkSeleccionarTodo.Name = "ChkSeleccionarTodo";
            this.ChkSeleccionarTodo.Size = new System.Drawing.Size(157, 22);
            this.ChkSeleccionarTodo.TabIndex = 170;
            this.ChkSeleccionarTodo.Text = "Seleccionar Todo";
            this.ChkSeleccionarTodo.UseVisualStyleBackColor = true;
            this.ChkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.ChkSeleccionarTodo_CheckedChanged);
            this.ChkSeleccionarTodo.Click += new System.EventHandler(this.ChkSeleccionarTodo_Click);
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
            this.TxtFiltrar.Location = new System.Drawing.Point(16, 11);
            this.TxtFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFiltrar.Multilinea = false;
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtFiltrar.PasswordChar = false;
            this.TxtFiltrar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.TxtFiltrar.PlaceHolderText = "Buscar...";
            this.TxtFiltrar.Size = new System.Drawing.Size(465, 36);
            this.TxtFiltrar.TabIndex = 147;
            this.TxtFiltrar.Texts = "";
            this.TxtFiltrar.UnderLineFlat = true;
            this.TxtFiltrar._TextChanged += new System.EventHandler(this.TxtFiltrar__TextChanged);
            // 
            // BtnPagarOrdenes
            // 
            this.BtnPagarOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPagarOrdenes.BackColor = System.Drawing.Color.Green;
            this.BtnPagarOrdenes.BackGroundColor = System.Drawing.Color.Green;
            this.BtnPagarOrdenes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnPagarOrdenes.BorderRadius = 5;
            this.BtnPagarOrdenes.BorderSize = 1;
            this.BtnPagarOrdenes.FlatAppearance.BorderSize = 0;
            this.BtnPagarOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPagarOrdenes.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BtnPagarOrdenes.ForeColor = System.Drawing.Color.White;
            this.BtnPagarOrdenes.Image = ((System.Drawing.Image)(resources.GetObject("BtnPagarOrdenes.Image")));
            this.BtnPagarOrdenes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPagarOrdenes.Location = new System.Drawing.Point(894, 68);
            this.BtnPagarOrdenes.Name = "BtnPagarOrdenes";
            this.BtnPagarOrdenes.Size = new System.Drawing.Size(238, 38);
            this.BtnPagarOrdenes.TabIndex = 169;
            this.BtnPagarOrdenes.Text = "Pagar Ordenes";
            this.BtnPagarOrdenes.TextGroundColor = System.Drawing.Color.White;
            this.BtnPagarOrdenes.UseVisualStyleBackColor = false;
            this.BtnPagarOrdenes.Click += new System.EventHandler(this.BtnPagarOrdenes_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExcel.BackColor = System.Drawing.Color.White;
            this.BtnExcel.BackGroundColor = System.Drawing.Color.White;
            this.BtnExcel.BorderColor = System.Drawing.Color.Green;
            this.BtnExcel.BorderRadius = 5;
            this.BtnExcel.BorderSize = 1;
            this.BtnExcel.FlatAppearance.BorderSize = 0;
            this.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BtnExcel.ForeColor = System.Drawing.Color.DimGray;
            this.BtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcel.Image")));
            this.BtnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcel.Location = new System.Drawing.Point(12, 399);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(238, 38);
            this.BtnExcel.TabIndex = 166;
            this.BtnExcel.Text = "Documento Excel";
            this.BtnExcel.TextGroundColor = System.Drawing.Color.DimGray;
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnPdf
            // 
            this.BtnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnPdf.BackColor = System.Drawing.Color.White;
            this.BtnPdf.BackGroundColor = System.Drawing.Color.White;
            this.BtnPdf.BorderColor = System.Drawing.Color.Red;
            this.BtnPdf.BorderRadius = 5;
            this.BtnPdf.BorderSize = 1;
            this.BtnPdf.FlatAppearance.BorderSize = 0;
            this.BtnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPdf.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BtnPdf.ForeColor = System.Drawing.Color.DimGray;
            this.BtnPdf.Image = ((System.Drawing.Image)(resources.GetObject("BtnPdf.Image")));
            this.BtnPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPdf.Location = new System.Drawing.Point(256, 399);
            this.BtnPdf.Name = "BtnPdf";
            this.BtnPdf.Size = new System.Drawing.Size(238, 38);
            this.BtnPdf.TabIndex = 165;
            this.BtnPdf.Text = "Documento Pdf";
            this.BtnPdf.TextGroundColor = System.Drawing.Color.DimGray;
            this.BtnPdf.UseVisualStyleBackColor = false;
            this.BtnPdf.Click += new System.EventHandler(this.BtnPdf_Click);
            // 
            // frmBusquedasOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1158, 555);
            this.Controls.Add(this.ChkSeleccionarTodo);
            this.Controls.Add(this.BtnPagarOrdenes);
            this.Controls.Add(this.CmbSegmentacion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.BtnPdf);
            this.Controls.Add(this.CmbFiltrarFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DtFin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DtInicio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtRestante);
            this.Controls.Add(this.TxtRecuperado);
            this.Controls.Add(this.TxtColocado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PnlPaginado);
            this.Controls.Add(this.CmbSucursal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbBuscarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCatalogoOrdenes);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBusquedasOrdenes";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Ventas";
            this.Load += new System.EventHandler(this.frmBusquedasOrdenes_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoOrdenes)).EndInit();
            this.PnlPaginado.ResumeLayout(false);
            this.PnlPaginado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label llbTitulo;
        public System.Windows.Forms.DataGridView dgvCatalogoOrdenes;
        public Controladores.LoginUserControl TxtFiltrar;
        public System.Windows.Forms.ComboBox CmbBuscarPor;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox CmbSucursal;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel PnlPaginado;
        public System.Windows.Forms.TextBox TxtPaginaDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TxtPaginaNo;
        public System.Windows.Forms.Button BtnAnterior;
        public System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox TxtColocado;
        public System.Windows.Forms.TextBox TxtRecuperado;
        public System.Windows.Forms.TextBox TxtRestante;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DtInicio;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DtFin;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox CmbFiltrarFecha;
        public Especiales.EspecialButton BtnExcel;
        public Especiales.EspecialButton BtnPdf;
        public System.Windows.Forms.ComboBox CmbSegmentacion;
        public System.Windows.Forms.Label label11;
        public Especiales.EspecialButton BtnPagarOrdenes;
        private System.Windows.Forms.CheckBox ChkSeleccionarTodo;
    }
}