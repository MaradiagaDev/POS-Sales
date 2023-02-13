namespace NeoCobranza.Paneles_Contrato
{
    partial class PnlPagoGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlPagoGeneral));
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecibo = new System.Windows.Forms.Label();
            this.txtCuotas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDolares = new System.Windows.Forms.TextBox();
            this.txtCordobas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCausa = new System.Windows.Forms.TextBox();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton2 = new NeoCobranza.Especiales.EspecialButton();
            this.btnGenerar = new NeoCobranza.Especiales.EspecialButton();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtFiltroId = new NeoCobranza.Controladores.LoginUserControl();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.label48 = new System.Windows.Forms.Label();
            this.llbTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(25, 127);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(686, 327);
            this.dgvStock.TabIndex = 94;
            this.dgvStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellDoubleClick);
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(33, 462);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(369, 24);
            this.label11.TabIndex = 179;
            this.label11.Text = "- El color \"Verde\" indica un contrato al dia. ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(33, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 24);
            this.label1.TabIndex = 180;
            this.label1.Text = "- El color \"Amarillo\" indica dia de cobro. ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(33, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 24);
            this.label2.TabIndex = 181;
            this.label2.Text = "- El color \"Rojo\" indica contrato en mora. ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(800, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 182;
            this.label3.Text = "Proximo recibo:  ";
            // 
            // txtRecibo
            // 
            this.txtRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecibo.AutoSize = true;
            this.txtRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtRecibo.Location = new System.Drawing.Point(943, 51);
            this.txtRecibo.Name = "txtRecibo";
            this.txtRecibo.Size = new System.Drawing.Size(20, 24);
            this.txtRecibo.TabIndex = 183;
            this.txtRecibo.Text = "x";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotas.Location = new System.Drawing.Point(905, 268);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(186, 26);
            this.txtCuotas.TabIndex = 193;
            this.txtCuotas.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(801, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 192;
            this.label4.Text = "NoCuotas:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(799, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 24);
            this.label5.TabIndex = 191;
            this.label5.Text = "Informacion de cuotas";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(818, 349);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(311, 105);
            this.txtObservaciones.TabIndex = 190;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(799, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 24);
            this.label6.TabIndex = 189;
            this.label6.Text = "Observaciones";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(799, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 24);
            this.label7.TabIndex = 188;
            this.label7.Text = "Monto recibido";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Location = new System.Drawing.Point(799, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 24);
            this.label9.TabIndex = 187;
            this.label9.Text = "Monto (C$):";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(801, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 24);
            this.label8.TabIndex = 186;
            this.label8.Text = "Monto ($):";
            // 
            // txtDolares
            // 
            this.txtDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDolares.Location = new System.Drawing.Point(928, 187);
            this.txtDolares.Name = "txtDolares";
            this.txtDolares.Size = new System.Drawing.Size(186, 26);
            this.txtDolares.TabIndex = 185;
            this.txtDolares.Text = "0";
            // 
            // txtCordobas
            // 
            this.txtCordobas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCordobas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCordobas.Location = new System.Drawing.Point(928, 148);
            this.txtCordobas.Name = "txtCordobas";
            this.txtCordobas.Size = new System.Drawing.Size(186, 26);
            this.txtCordobas.TabIndex = 184;
            this.txtCordobas.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label10.Location = new System.Drawing.Point(440, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 16);
            this.label10.TabIndex = 197;
            this.label10.Text = "Causa de retiro:";
            // 
            // txtCausa
            // 
            this.txtCausa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCausa.Location = new System.Drawing.Point(443, 476);
            this.txtCausa.Multiline = true;
            this.txtCausa.Name = "txtCausa";
            this.txtCausa.Size = new System.Drawing.Size(283, 38);
            this.txtCausa.TabIndex = 198;
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.especialButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BorderColor = System.Drawing.Color.Lime;
            this.especialButton1.BorderRadius = 5;
            this.especialButton1.BorderSize = 2;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(443, 520);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(283, 35);
            this.especialButton1.TabIndex = 196;
            this.especialButton1.Text = "Retirar contrato";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // especialButton2
            // 
            this.especialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.especialButton2.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton2.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton2.BorderColor = System.Drawing.Color.Lime;
            this.especialButton2.BorderRadius = 5;
            this.especialButton2.BorderSize = 2;
            this.especialButton2.FlatAppearance.BorderSize = 0;
            this.especialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton2.ForeColor = System.Drawing.Color.White;
            this.especialButton2.Image = ((System.Drawing.Image)(resources.GetObject("especialButton2.Image")));
            this.especialButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton2.Location = new System.Drawing.Point(831, 501);
            this.especialButton2.Name = "especialButton2";
            this.especialButton2.Size = new System.Drawing.Size(283, 35);
            this.especialButton2.TabIndex = 195;
            this.especialButton2.Text = "Generar Recibo";
            this.especialButton2.TextGroundColor = System.Drawing.Color.White;
            this.especialButton2.UseVisualStyleBackColor = false;
            this.especialButton2.Click += new System.EventHandler(this.especialButton2_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGenerar.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnGenerar.BorderColor = System.Drawing.Color.Lime;
            this.btnGenerar.BorderRadius = 5;
            this.btnGenerar.BorderSize = 2;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Location = new System.Drawing.Point(831, 460);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(283, 35);
            this.btnGenerar.TabIndex = 194;
            this.btnGenerar.Text = "Ingresar Pago";
            this.btnGenerar.TextGroundColor = System.Drawing.Color.White;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label41.Location = new System.Drawing.Point(268, 60);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 24);
            this.label41.TabIndex = 220;
            this.label41.Text = "Filtro:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label42.Location = new System.Drawing.Point(15, 61);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 24);
            this.label42.TabIndex = 219;
            this.label42.Text = "Id: ";
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltroId.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltroId.BorderRadius = 0;
            this.txtFiltroId.BorderSize = 2;
            this.txtFiltroId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroId.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltroId.Location = new System.Drawing.Point(57, 52);
            this.txtFiltroId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroId.Multilinea = false;
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltroId.PasswordChar = false;
            this.txtFiltroId.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltroId.PlaceHolderText = "Buscar ..";
            this.txtFiltroId.Size = new System.Drawing.Size(196, 39);
            this.txtFiltroId.TabIndex = 218;
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
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltro.Location = new System.Drawing.Point(349, 52);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar ..";
            this.txtFiltro.Size = new System.Drawing.Size(419, 39);
            this.txtFiltro.TabIndex = 217;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label48.Location = new System.Drawing.Point(14, 36);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(287, 16);
            this.label48.TabIndex = 222;
            this.label48.Text = "________________________________________";
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llbTitulo.Location = new System.Drawing.Point(12, 9);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(240, 25);
            this.llbTitulo.TabIndex = 221;
            this.llbTitulo.Text = "Pago general de cuotas";
            // 
            // PnlPagoGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.llbTitulo);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtFiltroId);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.txtCausa);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.especialButton2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtCuotas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDolares);
            this.Controls.Add(this.txtCordobas);
            this.Controls.Add(this.txtRecibo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlPagoGeneral";
            this.Text = "PnlPagoGeneral";
            this.Load += new System.EventHandler(this.PnlPagoGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtRecibo;
        private Especiales.EspecialButton especialButton2;
        private Especiales.EspecialButton btnGenerar;
        private System.Windows.Forms.TextBox txtCuotas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDolares;
        private System.Windows.Forms.TextBox txtCordobas;
        private Especiales.EspecialButton especialButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCausa;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private Controladores.LoginUserControl txtFiltroId;
        private Controladores.LoginUserControl txtFiltro;
        private System.Windows.Forms.Label label48;
        public System.Windows.Forms.Label llbTitulo;
    }
}