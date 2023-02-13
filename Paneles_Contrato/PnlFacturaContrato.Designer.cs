namespace NeoCobranza.Paneles_Contrato
{
    partial class PnlFacturaContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlFacturaContrato));
            this.llbTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtFiltroId = new NeoCobranza.Controladores.LoginUserControl();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.btnGenerar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnAnular = new NeoCobranza.Especiales.EspecialButton();
            this.BtnRealizarVenta = new NeoCobranza.Especiales.EspecialButton();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llbTitulo.Location = new System.Drawing.Point(35, 9);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(237, 25);
            this.llbTitulo.TabIndex = 1;
            this.llbTitulo.Text = "Realizacion de facturas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(37, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 16);
            this.label2.TabIndex = 97;
            this.label2.Text = "________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(874, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 173;
            this.label1.Text = "Reporteria:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.lblFechaInicio);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(882, 284);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 60);
            this.flowLayoutPanel2.TabIndex = 172;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha de Inicio";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.CustomFormat = "dd-MM-yyyy";
            this.lblFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lblFechaInicio.Location = new System.Drawing.Point(3, 21);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(160, 24);
            this.lblFechaInicio.TabIndex = 37;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.lblFechaFinal);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(882, 364);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(171, 60);
            this.flowLayoutPanel1.TabIndex = 174;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha Final";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.CustomFormat = "dd-MM-yyyy";
            this.lblFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lblFechaFinal.Location = new System.Drawing.Point(3, 21);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(160, 24);
            this.lblFechaFinal.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(875, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 24);
            this.label3.TabIndex = 169;
            this.label3.Text = "Realizacion de factura: ";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label41.Location = new System.Drawing.Point(268, 79);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 24);
            this.label41.TabIndex = 224;
            this.label41.Text = "Filtro:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label42.Location = new System.Drawing.Point(15, 80);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 24);
            this.label42.TabIndex = 223;
            this.label42.Text = "Id: ";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(19, 132);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(749, 231);
            this.dgvStock.TabIndex = 225;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(15, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 226;
            this.label6.Text = "Detalles de la factura ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 409);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(524, 141);
            this.dataGridView1.TabIndex = 227;
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltroId.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltroId.BorderRadius = 0;
            this.txtFiltroId.BorderSize = 2;
            this.txtFiltroId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroId.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltroId.Location = new System.Drawing.Point(57, 71);
            this.txtFiltroId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroId.Multilinea = false;
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltroId.PasswordChar = false;
            this.txtFiltroId.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltroId.PlaceHolderText = "Buscar ..";
            this.txtFiltroId.Size = new System.Drawing.Size(196, 39);
            this.txtFiltroId.TabIndex = 222;
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
            this.txtFiltro.Location = new System.Drawing.Point(349, 71);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar ..";
            this.txtFiltro.Size = new System.Drawing.Size(419, 39);
            this.txtFiltro.TabIndex = 221;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.btnGenerar.Location = new System.Drawing.Point(867, 449);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(212, 35);
            this.btnGenerar.TabIndex = 175;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextGroundColor = System.Drawing.Color.White;
            this.btnGenerar.UseVisualStyleBackColor = false;
            // 
            // BtnAnular
            // 
            this.BtnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAnular.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnAnular.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnAnular.BorderColor = System.Drawing.Color.Lime;
            this.BtnAnular.BorderRadius = 10;
            this.BtnAnular.BorderSize = 2;
            this.BtnAnular.FlatAppearance.BorderSize = 0;
            this.BtnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnular.ForeColor = System.Drawing.Color.White;
            this.BtnAnular.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnular.Image")));
            this.BtnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAnular.Location = new System.Drawing.Point(853, 132);
            this.BtnAnular.Name = "BtnAnular";
            this.BtnAnular.Size = new System.Drawing.Size(260, 42);
            this.BtnAnular.TabIndex = 171;
            this.BtnAnular.Text = "Anular Retiro";
            this.BtnAnular.TextGroundColor = System.Drawing.Color.White;
            this.BtnAnular.UseVisualStyleBackColor = false;
            // 
            // BtnRealizarVenta
            // 
            this.BtnRealizarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnRealizarVenta.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnRealizarVenta.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.BtnRealizarVenta.BorderColor = System.Drawing.Color.Lime;
            this.BtnRealizarVenta.BorderRadius = 10;
            this.BtnRealizarVenta.BorderSize = 2;
            this.BtnRealizarVenta.FlatAppearance.BorderSize = 0;
            this.BtnRealizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRealizarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRealizarVenta.ForeColor = System.Drawing.Color.White;
            this.BtnRealizarVenta.Image = ((System.Drawing.Image)(resources.GetObject("BtnRealizarVenta.Image")));
            this.BtnRealizarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRealizarVenta.Location = new System.Drawing.Point(853, 68);
            this.BtnRealizarVenta.Name = "BtnRealizarVenta";
            this.BtnRealizarVenta.Size = new System.Drawing.Size(260, 42);
            this.BtnRealizarVenta.TabIndex = 170;
            this.BtnRealizarVenta.Text = "Realizar factura";
            this.BtnRealizarVenta.TextGroundColor = System.Drawing.Color.White;
            this.BtnRealizarVenta.UseVisualStyleBackColor = false;
            // 
            // PnlFacturaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtFiltroId);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.BtnAnular);
            this.Controls.Add(this.BtnRealizarVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.llbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlFacturaContrato";
            this.Text = "PnlFacturaContrato";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label llbTitulo;
        private System.Windows.Forms.Label label2;
        private Especiales.EspecialButton btnGenerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker lblFechaInicio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker lblFechaFinal;
        private Especiales.EspecialButton BtnAnular;
        private Especiales.EspecialButton BtnRealizarVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private Controladores.LoginUserControl txtFiltroId;
        private Controladores.LoginUserControl txtFiltro;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}