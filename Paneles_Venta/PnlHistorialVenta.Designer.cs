namespace NeoCobranza.Paneles_Venta
{
    partial class PnlHistorialVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlHistorialVenta));
            this.panel3 = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbntFuturos = new System.Windows.Forms.RadioButton();
            this.rbtnReservados = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAtaudes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvServcios = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPagoDolar = new System.Windows.Forms.Label();
            this.lblAnticipoDolar = new System.Windows.Forms.Label();
            this.lblTotalDolar = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblPagoCordoba = new System.Windows.Forms.Label();
            this.lblAnticipoCordoba = new System.Windows.Forms.Label();
            this.lblTotalCordoba = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnRetiro = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtaudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvServcios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.llbTitulo);
            this.panel3.Location = new System.Drawing.Point(-1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1158, 37);
            this.panel3.TabIndex = 79;
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.llbTitulo.Location = new System.Drawing.Point(12, 8);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(297, 24);
            this.llbTitulo.TabIndex = 0;
            this.llbTitulo.Text = "Retiros/Cancelacion de Ventas";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(31, 135);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(797, 354);
            this.dgvStock.TabIndex = 91;
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rbntFuturos);
            this.flowLayoutPanel2.Controls.Add(this.rbtnReservados);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(872, 93);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(161, 64);
            this.flowLayoutPanel2.TabIndex = 93;
            // 
            // rbntFuturos
            // 
            this.rbntFuturos.AutoSize = true;
            this.rbntFuturos.Checked = true;
            this.rbntFuturos.Location = new System.Drawing.Point(3, 3);
            this.rbntFuturos.Name = "rbntFuturos";
            this.rbntFuturos.Size = new System.Drawing.Size(141, 24);
            this.rbntFuturos.TabIndex = 17;
            this.rbntFuturos.TabStop = true;
            this.rbntFuturos.Text = "Ventas  Futuras";
            this.rbntFuturos.UseVisualStyleBackColor = true;
            this.rbntFuturos.CheckedChanged += new System.EventHandler(this.rbntFuturos_CheckedChanged);
            // 
            // rbtnReservados
            // 
            this.rbtnReservados.AutoSize = true;
            this.rbtnReservados.Location = new System.Drawing.Point(3, 33);
            this.rbtnReservados.Name = "rbtnReservados";
            this.rbtnReservados.Size = new System.Drawing.Size(112, 24);
            this.rbtnReservados.TabIndex = 18;
            this.rbtnReservados.Text = "Reservados";
            this.rbtnReservados.UseVisualStyleBackColor = true;
            this.rbtnReservados.CheckedChanged += new System.EventHandler(this.rbtnReservados_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(859, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.label4.TabIndex = 139;
            this.label4.Text = "Ataudes Reservados:";
            // 
            // dgvAtaudes
            // 
            this.dgvAtaudes.AllowUserToAddRows = false;
            this.dgvAtaudes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAtaudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtaudes.Location = new System.Drawing.Point(847, 216);
            this.dgvAtaudes.Name = "dgvAtaudes";
            this.dgvAtaudes.ReadOnly = true;
            this.dgvAtaudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtaudes.Size = new System.Drawing.Size(300, 159);
            this.dgvAtaudes.TabIndex = 140;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(859, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 18);
            this.label1.TabIndex = 141;
            this.label1.Text = "Servicios Reservados:";
            // 
            // DgvServcios
            // 
            this.DgvServcios.AllowUserToAddRows = false;
            this.DgvServcios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvServcios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvServcios.Location = new System.Drawing.Point(848, 424);
            this.DgvServcios.Name = "DgvServcios";
            this.DgvServcios.ReadOnly = true;
            this.DgvServcios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvServcios.Size = new System.Drawing.Size(300, 159);
            this.DgvServcios.TabIndex = 142;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(8, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(516, 18);
            this.label2.TabIndex = 143;
            this.label2.Text = "* Para ver los servicios y ataudes reservados tiene que cambiar de seleccion.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(859, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 144;
            this.label3.Text = "Tipo de venta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(580, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 145;
            this.label5.Text = "Informacion de pago";
            // 
            // lblPagoDolar
            // 
            this.lblPagoDolar.AutoSize = true;
            this.lblPagoDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagoDolar.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblPagoDolar.Location = new System.Drawing.Point(607, 573);
            this.lblPagoDolar.Name = "lblPagoDolar";
            this.lblPagoDolar.Size = new System.Drawing.Size(13, 16);
            this.lblPagoDolar.TabIndex = 189;
            this.lblPagoDolar.Text = "x";
            // 
            // lblAnticipoDolar
            // 
            this.lblAnticipoDolar.AutoSize = true;
            this.lblAnticipoDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnticipoDolar.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblAnticipoDolar.Location = new System.Drawing.Point(606, 549);
            this.lblAnticipoDolar.Name = "lblAnticipoDolar";
            this.lblAnticipoDolar.Size = new System.Drawing.Size(13, 16);
            this.lblAnticipoDolar.TabIndex = 188;
            this.lblAnticipoDolar.Text = "x";
            // 
            // lblTotalDolar
            // 
            this.lblTotalDolar.AutoSize = true;
            this.lblTotalDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDolar.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTotalDolar.Location = new System.Drawing.Point(605, 524);
            this.lblTotalDolar.Name = "lblTotalDolar";
            this.lblTotalDolar.Size = new System.Drawing.Size(13, 16);
            this.lblTotalDolar.TabIndex = 187;
            this.lblTotalDolar.Text = "x";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label34.Location = new System.Drawing.Point(534, 573);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 16);
            this.label34.TabIndex = 186;
            this.label34.Text = "Pago $:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label35.Location = new System.Drawing.Point(532, 549);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(68, 16);
            this.label35.TabIndex = 185;
            this.label35.Text = "Anticipo $:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label36.Location = new System.Drawing.Point(531, 524);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(51, 16);
            this.label36.TabIndex = 184;
            this.label36.Text = "Total $:";
            // 
            // lblPagoCordoba
            // 
            this.lblPagoCordoba.AutoSize = true;
            this.lblPagoCordoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagoCordoba.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblPagoCordoba.Location = new System.Drawing.Point(758, 573);
            this.lblPagoCordoba.Name = "lblPagoCordoba";
            this.lblPagoCordoba.Size = new System.Drawing.Size(13, 16);
            this.lblPagoCordoba.TabIndex = 195;
            this.lblPagoCordoba.Text = "x";
            // 
            // lblAnticipoCordoba
            // 
            this.lblAnticipoCordoba.AutoSize = true;
            this.lblAnticipoCordoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnticipoCordoba.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblAnticipoCordoba.Location = new System.Drawing.Point(757, 549);
            this.lblAnticipoCordoba.Name = "lblAnticipoCordoba";
            this.lblAnticipoCordoba.Size = new System.Drawing.Size(13, 16);
            this.lblAnticipoCordoba.TabIndex = 194;
            this.lblAnticipoCordoba.Text = "x";
            // 
            // lblTotalCordoba
            // 
            this.lblTotalCordoba.AutoSize = true;
            this.lblTotalCordoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCordoba.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTotalCordoba.Location = new System.Drawing.Point(756, 524);
            this.lblTotalCordoba.Name = "lblTotalCordoba";
            this.lblTotalCordoba.Size = new System.Drawing.Size(13, 16);
            this.lblTotalCordoba.TabIndex = 193;
            this.lblTotalCordoba.Text = "x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Location = new System.Drawing.Point(685, 573);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 192;
            this.label9.Text = "Pago C$:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label10.Location = new System.Drawing.Point(683, 549);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.TabIndex = 191;
            this.label10.Text = "Anticipo C$:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(682, 524);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 16);
            this.label11.TabIndex = 190;
            this.label11.Text = "Total C$:";
            // 
            // BtnRetiro
            // 
            this.BtnRetiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnRetiro.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnRetiro.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnRetiro.BorderColor = System.Drawing.Color.Lime;
            this.BtnRetiro.BorderRadius = 10;
            this.BtnRetiro.BorderSize = 2;
            this.BtnRetiro.FlatAppearance.BorderSize = 0;
            this.BtnRetiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRetiro.ForeColor = System.Drawing.Color.White;
            this.BtnRetiro.Image = ((System.Drawing.Image)(resources.GetObject("BtnRetiro.Image")));
            this.BtnRetiro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRetiro.Location = new System.Drawing.Point(31, 493);
            this.BtnRetiro.Name = "BtnRetiro";
            this.BtnRetiro.Size = new System.Drawing.Size(354, 37);
            this.BtnRetiro.TabIndex = 120;
            this.BtnRetiro.Text = "Cancelacion de venta  (VF/Reservados)";
            this.BtnRetiro.TextGroundColor = System.Drawing.Color.White;
            this.BtnRetiro.UseVisualStyleBackColor = false;
            this.BtnRetiro.Click += new System.EventHandler(this.BtnRetiro_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltro.BorderRadius = 0;
            this.txtFiltro.BorderSize = 2;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltro.Location = new System.Drawing.Point(31, 72);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar ..";
            this.txtFiltro.Size = new System.Drawing.Size(797, 39);
            this.txtFiltro.TabIndex = 92;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
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
            this.especialButton1.Location = new System.Drawing.Point(31, 533);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(354, 32);
            this.especialButton1.TabIndex = 196;
            this.especialButton1.Text = "Actualizar Venta";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // PnlHistorialVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.lblPagoCordoba);
            this.Controls.Add(this.lblAnticipoCordoba);
            this.Controls.Add(this.lblTotalCordoba);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPagoDolar);
            this.Controls.Add(this.lblAnticipoDolar);
            this.Controls.Add(this.lblTotalDolar);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DgvServcios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAtaudes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnRetiro);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlHistorialVenta";
            this.Text = "PnlHistorialVenta";
            this.Load += new System.EventHandler(this.PnlHistorialVenta_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtaudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvServcios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label llbTitulo;
        private Controladores.LoginUserControl txtFiltro;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rbntFuturos;
        private System.Windows.Forms.RadioButton rbtnReservados;
        private Especiales.EspecialButton BtnRetiro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvAtaudes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvServcios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPagoDolar;
        private System.Windows.Forms.Label lblAnticipoDolar;
        private System.Windows.Forms.Label lblTotalDolar;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblPagoCordoba;
        private System.Windows.Forms.Label lblAnticipoCordoba;
        private System.Windows.Forms.Label lblTotalCordoba;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Especiales.EspecialButton especialButton1;
    }
}