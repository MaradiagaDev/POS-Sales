namespace NeoCobranza.Paneles_Contrato
{
    partial class PnlRetiroServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlRetiroServicios));
            this.panel4 = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvBeneficiarios = new System.Windows.Forms.DataGridView();
            this.txtMontoNominalB = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNombreServicio = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFallecimiento = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstadoB = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExtra = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSaldoAcum = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEstadoRetiro = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.dgvAtaudes = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbServicios = new System.Windows.Forms.ComboBox();
            this.TxtCantidadS = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAtaud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTipoF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mejora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCliente = new NeoCobranza.Especiales.EspecialButton();
            this.btnRetiro = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltroId = new NeoCobranza.Controladores.LoginUserControl();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficiarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtaudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidadS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel4.Controls.Add(this.llbTitulo);
            this.panel4.Location = new System.Drawing.Point(-9, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1158, 37);
            this.panel4.TabIndex = 83;
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.llbTitulo.Location = new System.Drawing.Point(12, 6);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(284, 24);
            this.llbTitulo.TabIndex = 0;
            this.llbTitulo.Text = "Retiro de Ataudes y Servicios";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(7, 102);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(703, 211);
            this.dgvStock.TabIndex = 98;
            this.dgvStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellDoubleClick);
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 18);
            this.label3.TabIndex = 185;
            this.label3.Text = "Seleccion de Contrato  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 18);
            this.label1.TabIndex = 187;
            this.label1.Text = "Id: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(250, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 188;
            this.label2.Text = "Filtro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(742, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 18);
            this.label4.TabIndex = 189;
            this.label4.Text = "Informacion economica";
            // 
            // txtSaldo
            // 
            this.txtSaldo.AutoSize = true;
            this.txtSaldo.BackColor = System.Drawing.Color.Transparent;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSaldo.Location = new System.Drawing.Point(742, 87);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(15, 18);
            this.txtSaldo.TabIndex = 197;
            this.txtSaldo.Text = "x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(11, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 20);
            this.label5.TabIndex = 198;
            this.label5.Text = "Lista de Beneficiarios:  ";
            // 
            // dgvBeneficiarios
            // 
            this.dgvBeneficiarios.AllowUserToAddRows = false;
            this.dgvBeneficiarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBeneficiarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBeneficiarios.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBeneficiarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBeneficiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeneficiarios.Location = new System.Drawing.Point(7, 347);
            this.dgvBeneficiarios.Name = "dgvBeneficiarios";
            this.dgvBeneficiarios.ReadOnly = true;
            this.dgvBeneficiarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBeneficiarios.Size = new System.Drawing.Size(419, 113);
            this.dgvBeneficiarios.TabIndex = 199;
            this.dgvBeneficiarios.SelectionChanged += new System.EventHandler(this.dgvBeneficiarios_SelectionChanged);
            // 
            // txtMontoNominalB
            // 
            this.txtMontoNominalB.AutoSize = true;
            this.txtMontoNominalB.BackColor = System.Drawing.Color.Transparent;
            this.txtMontoNominalB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoNominalB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtMontoNominalB.Location = new System.Drawing.Point(438, 444);
            this.txtMontoNominalB.Name = "txtMontoNominalB";
            this.txtMontoNominalB.Size = new System.Drawing.Size(13, 16);
            this.txtMontoNominalB.TabIndex = 212;
            this.txtMontoNominalB.Text = "x";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label17.Location = new System.Drawing.Point(436, 428);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 16);
            this.label17.TabIndex = 211;
            this.label17.Text = "Monto Nominal:  ";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.AutoSize = true;
            this.txtNombreServicio.BackColor = System.Drawing.Color.Transparent;
            this.txtNombreServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreServicio.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNombreServicio.Location = new System.Drawing.Point(438, 409);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(13, 16);
            this.txtNombreServicio.TabIndex = 210;
            this.txtNombreServicio.Text = "x";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label13.Location = new System.Drawing.Point(436, 392);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 16);
            this.label13.TabIndex = 209;
            this.label13.Text = "Nombre del Servicio:  ";
            // 
            // txtFallecimiento
            // 
            this.txtFallecimiento.AutoSize = true;
            this.txtFallecimiento.BackColor = System.Drawing.Color.Transparent;
            this.txtFallecimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFallecimiento.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtFallecimiento.Location = new System.Drawing.Point(438, 370);
            this.txtFallecimiento.Name = "txtFallecimiento";
            this.txtFallecimiento.Size = new System.Drawing.Size(13, 16);
            this.txtFallecimiento.TabIndex = 208;
            this.txtFallecimiento.Text = "x";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label10.Location = new System.Drawing.Point(436, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 16);
            this.label10.TabIndex = 207;
            this.label10.Text = "Fecha de fallecimiento:  ";
            // 
            // txtEstadoB
            // 
            this.txtEstadoB.AutoSize = true;
            this.txtEstadoB.BackColor = System.Drawing.Color.Transparent;
            this.txtEstadoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtEstadoB.Location = new System.Drawing.Point(438, 333);
            this.txtEstadoB.Name = "txtEstadoB";
            this.txtEstadoB.Size = new System.Drawing.Size(13, 16);
            this.txtEstadoB.TabIndex = 206;
            this.txtEstadoB.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(438, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 205;
            this.label6.Text = "Estado:  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(742, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 213;
            this.label7.Text = "Saldo:  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(910, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 18);
            this.label8.TabIndex = 215;
            this.label8.Text = "Extra por mejora ($):";
            // 
            // txtExtra
            // 
            this.txtExtra.AutoSize = true;
            this.txtExtra.BackColor = System.Drawing.Color.Transparent;
            this.txtExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtra.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtExtra.Location = new System.Drawing.Point(910, 87);
            this.txtExtra.Name = "txtExtra";
            this.txtExtra.Size = new System.Drawing.Size(15, 18);
            this.txtExtra.TabIndex = 214;
            this.txtExtra.Text = "x";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(742, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 18);
            this.label11.TabIndex = 217;
            this.label11.Text = "Saldo Acum";
            // 
            // txtSaldoAcum
            // 
            this.txtSaldoAcum.AutoSize = true;
            this.txtSaldoAcum.BackColor = System.Drawing.Color.Transparent;
            this.txtSaldoAcum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoAcum.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSaldoAcum.Location = new System.Drawing.Point(742, 147);
            this.txtSaldoAcum.Name = "txtSaldoAcum";
            this.txtSaldoAcum.Size = new System.Drawing.Size(15, 18);
            this.txtSaldoAcum.TabIndex = 216;
            this.txtSaldoAcum.Text = "x";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label14.Location = new System.Drawing.Point(910, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 18);
            this.label14.TabIndex = 219;
            this.label14.Text = "Estado del retiro";
            // 
            // txtEstadoRetiro
            // 
            this.txtEstadoRetiro.AutoSize = true;
            this.txtEstadoRetiro.BackColor = System.Drawing.Color.Transparent;
            this.txtEstadoRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoRetiro.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtEstadoRetiro.Location = new System.Drawing.Point(910, 147);
            this.txtEstadoRetiro.Name = "txtEstadoRetiro";
            this.txtEstadoRetiro.Size = new System.Drawing.Size(15, 18);
            this.txtEstadoRetiro.TabIndex = 218;
            this.txtEstadoRetiro.Text = "x";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label16.Location = new System.Drawing.Point(742, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(384, 18);
            this.label16.TabIndex = 220;
            this.label16.Text = "_______________________________________________";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label18.Location = new System.Drawing.Point(742, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 18);
            this.label18.TabIndex = 221;
            this.label18.Text = "Seleccion de ataudes";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DisplayMember = "NombreEstandar";
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(897, 192);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(232, 24);
            this.cmbCategoria.TabIndex = 222;
            this.cmbCategoria.ValueMember = "NombreEstandar";
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // dgvAtaudes
            // 
            this.dgvAtaudes.AllowUserToAddRows = false;
            this.dgvAtaudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAtaudes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAtaudes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAtaudes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAtaudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtaudes.Location = new System.Drawing.Point(745, 222);
            this.dgvAtaudes.Name = "dgvAtaudes";
            this.dgvAtaudes.ReadOnly = true;
            this.dgvAtaudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtaudes.Size = new System.Drawing.Size(384, 137);
            this.dgvAtaudes.TabIndex = 223;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(11, 482);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 20);
            this.label9.TabIndex = 225;
            this.label9.Text = "Lista de Servicios:  ";
            // 
            // cmbServicios
            // 
            this.cmbServicios.DisplayMember = "NombreEstandar";
            this.cmbServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServicios.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbServicios.FormattingEnabled = true;
            this.cmbServicios.Location = new System.Drawing.Point(10, 514);
            this.cmbServicios.Name = "cmbServicios";
            this.cmbServicios.Size = new System.Drawing.Size(290, 24);
            this.cmbServicios.TabIndex = 226;
            this.cmbServicios.ValueMember = "NombreEstandar";
            this.cmbServicios.SelectedIndexChanged += new System.EventHandler(this.cmbServicios_SelectedIndexChanged);
            // 
            // TxtCantidadS
            // 
            this.TxtCantidadS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadS.Location = new System.Drawing.Point(336, 514);
            this.TxtCantidadS.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.TxtCantidadS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtCantidadS.Name = "TxtCantidadS";
            this.TxtCantidadS.Size = new System.Drawing.Size(52, 26);
            this.TxtCantidadS.TabIndex = 227;
            this.TxtCantidadS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label12.Location = new System.Drawing.Point(4, 467);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(570, 12);
            this.label12.TabIndex = 228;
            this.label12.Text = "_________________________________________________________________________________" +
    "________________________________";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(440, 501);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 16);
            this.label15.TabIndex = 230;
            this.label15.Text = "x";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label19.Location = new System.Drawing.Point(438, 485);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 16);
            this.label19.TabIndex = 229;
            this.label19.Text = "Monto Nominal:  ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label20.Location = new System.Drawing.Point(734, 362);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(395, 12);
            this.label20.TabIndex = 231;
            this.label20.Text = "______________________________________________________________________________";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label21.Location = new System.Drawing.Point(648, 374);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(156, 18);
            this.label21.TabIndex = 232;
            this.label21.Text = "Retiros seleccionados";
            // 
            // dgvFactura
            // 
            this.dgvFactura.AllowUserToAddRows = false;
            this.dgvFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFactura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtId,
            this.idAtaud,
            this.Cantidad,
            this.txtTipoF,
            this.txtNombre,
            this.txtMonto,
            this.Mejora});
            this.dgvFactura.Location = new System.Drawing.Point(597, 395);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.ReadOnly = true;
            this.dgvFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFactura.Size = new System.Drawing.Size(529, 106);
            this.dgvFactura.TabIndex = 233;
            // 
            // txtId
            // 
            this.txtId.HeaderText = "Id";
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            // 
            // idAtaud
            // 
            this.idAtaud.HeaderText = "IdAtaud";
            this.idAtaud.Name = "idAtaud";
            this.idAtaud.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // txtTipoF
            // 
            this.txtTipoF.HeaderText = "Tipo";
            this.txtTipoF.Name = "txtTipoF";
            this.txtTipoF.ReadOnly = true;
            // 
            // txtNombre
            // 
            this.txtNombre.HeaderText = "Nombre";
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            // 
            // txtMonto
            // 
            this.txtMonto.HeaderText = "Monto";
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            // 
            // Mejora
            // 
            this.Mejora.HeaderText = "Mejora";
            this.Mejora.Name = "Mejora";
            this.Mejora.ReadOnly = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(440, 537);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(13, 16);
            this.label22.TabIndex = 237;
            this.label22.Text = "x";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label23.Location = new System.Drawing.Point(438, 522);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 16);
            this.label23.TabIndex = 236;
            this.label23.Text = "Disponibles:  ";
            // 
            // especialButton1
            // 
            this.especialButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BorderColor = System.Drawing.Color.Lime;
            this.especialButton1.BorderRadius = 15;
            this.especialButton1.BorderSize = 2;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Location = new System.Drawing.Point(564, 316);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(92, 31);
            this.especialButton1.TabIndex = 235;
            this.especialButton1.Text = "Seleccionar";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // BtnCliente
            // 
            this.BtnCliente.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnCliente.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnCliente.BorderColor = System.Drawing.Color.Lime;
            this.BtnCliente.BorderRadius = 15;
            this.BtnCliente.BorderSize = 2;
            this.BtnCliente.FlatAppearance.BorderSize = 0;
            this.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCliente.ForeColor = System.Drawing.Color.White;
            this.BtnCliente.Location = new System.Drawing.Point(564, 519);
            this.BtnCliente.Name = "BtnCliente";
            this.BtnCliente.Size = new System.Drawing.Size(92, 31);
            this.BtnCliente.TabIndex = 234;
            this.BtnCliente.Text = "Seleccionar";
            this.BtnCliente.TextGroundColor = System.Drawing.Color.White;
            this.BtnCliente.UseVisualStyleBackColor = false;
            this.BtnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // btnRetiro
            // 
            this.btnRetiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnRetiro.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRetiro.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnRetiro.BorderColor = System.Drawing.Color.Lime;
            this.btnRetiro.BorderRadius = 10;
            this.btnRetiro.BorderSize = 2;
            this.btnRetiro.FlatAppearance.BorderSize = 0;
            this.btnRetiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetiro.ForeColor = System.Drawing.Color.White;
            this.btnRetiro.Image = ((System.Drawing.Image)(resources.GetObject("btnRetiro.Image")));
            this.btnRetiro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetiro.Location = new System.Drawing.Point(955, 514);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(174, 36);
            this.btnRetiro.TabIndex = 224;
            this.btnRetiro.Text = "Realizar retiro";
            this.btnRetiro.TextGroundColor = System.Drawing.Color.White;
            this.btnRetiro.UseVisualStyleBackColor = false;
            this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltroId.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltroId.BorderRadius = 0;
            this.txtFiltroId.BorderSize = 2;
            this.txtFiltroId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroId.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltroId.Location = new System.Drawing.Point(41, 62);
            this.txtFiltroId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroId.Multilinea = false;
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltroId.PasswordChar = false;
            this.txtFiltroId.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltroId.PlaceHolderText = "Buscar ..";
            this.txtFiltroId.Size = new System.Drawing.Size(202, 33);
            this.txtFiltroId.TabIndex = 186;
            this.txtFiltroId.Texts = "";
            this.txtFiltroId.UnderLineFlat = true;
            this.txtFiltroId._TextChanged += new System.EventHandler(this.txtFiltroId__TextChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltro.BorderRadius = 0;
            this.txtFiltro.BorderSize = 2;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltro.Location = new System.Drawing.Point(336, 62);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar ..";
            this.txtFiltro.Size = new System.Drawing.Size(374, 33);
            this.txtFiltro.TabIndex = 99;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
            // 
            // PnlRetiroServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.BtnCliente);
            this.Controls.Add(this.dgvFactura);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtCantidadS);
            this.Controls.Add(this.cmbServicios);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnRetiro);
            this.Controls.Add(this.dgvAtaudes);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtEstadoRetiro);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSaldoAcum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtExtra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMontoNominalB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtNombreServicio);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtFallecimiento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEstadoB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvBeneficiarios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltroId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlRetiroServicios";
            this.Text = "PnlRetiroServicios";
            this.Load += new System.EventHandler(this.PnlRetiroServicios_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficiarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtaudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidadS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label llbTitulo;
        private Controladores.LoginUserControl txtFiltro;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label label3;
        private Controladores.LoginUserControl txtFiltroId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtSaldo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvBeneficiarios;
        private System.Windows.Forms.Label txtMontoNominalB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label txtNombreServicio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtFallecimiento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtEstadoB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtExtra;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtSaldoAcum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label txtEstadoRetiro;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.DataGridView dgvAtaudes;
        private Especiales.EspecialButton btnRetiro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbServicios;
        private System.Windows.Forms.NumericUpDown TxtCantidadS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgvFactura;
        private Especiales.EspecialButton BtnCliente;
        private Especiales.EspecialButton especialButton1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtId;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAtaud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTipoF;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mejora;
    }
}