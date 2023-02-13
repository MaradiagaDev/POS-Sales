namespace NeoCobranza.Paneles_Contrato
{
    partial class PnlRetirado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlRetirado));
            this.label11 = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSaldoActual = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.Label();
            this.txtContratoIncial = new System.Windows.Forms.TextBox();
            this.txtContratoFinal = new System.Windows.Forms.TextBox();
            this.txtFiltroId = new NeoCobranza.Controladores.LoginUserControl();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.btnImprimir = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(19, 456);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 24);
            this.label11.TabIndex = 180;
            this.label11.Text = "Traslado de saldo:";
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
            this.dgvStock.Location = new System.Drawing.Point(33, 103);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(1024, 327);
            this.dgvStock.TabIndex = 181;
            this.dgvStock.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellContentDoubleClick);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label41.Location = new System.Drawing.Point(267, 66);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 24);
            this.label41.TabIndex = 216;
            this.label41.Text = "Filtro:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label42.Location = new System.Drawing.Point(19, 66);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 24);
            this.label42.TabIndex = 215;
            this.label42.Text = "Id: ";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label48.Location = new System.Drawing.Point(14, 36);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(287, 16);
            this.label48.TabIndex = 224;
            this.label48.Text = "________________________________________";
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llbTitulo.Location = new System.Drawing.Point(12, 9);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(195, 25);
            this.llbTitulo.TabIndex = 223;
            this.llbTitulo.Text = "Contratos retirados";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(19, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 20);
            this.label1.TabIndex = 225;
            this.label1.Text = "- Solo si el contrato cuenta con algun saldo.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(19, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 20);
            this.label2.TabIndex = 226;
            this.label2.Text = "- Se tiene que trasladar a un contrato nuevo (Sin saldo).";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(19, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(528, 20);
            this.label3.TabIndex = 227;
            this.label3.Text = "- No se pueden seleccionar contratos: Cancelados / Con saldo / Retirados";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(606, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 228;
            this.label4.Text = "Contrato inicial";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(775, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 229;
            this.label5.Text = "Contrato final";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(737, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 20);
            this.label6.TabIndex = 230;
            this.label6.Text = "→";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(606, 500);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 231;
            this.label7.Text = "Saldo:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(606, 533);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 232;
            this.label8.Text = "Estado:";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoActual.AutoSize = true;
            this.txtSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoActual.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSaldoActual.Location = new System.Drawing.Point(666, 500);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.Size = new System.Drawing.Size(16, 20);
            this.txtSaldoActual.TabIndex = 233;
            this.txtSaldoActual.Text = "x";
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEstado.AutoSize = true;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtEstado.Location = new System.Drawing.Point(666, 533);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(16, 20);
            this.txtEstado.TabIndex = 234;
            this.txtEstado.Text = "x";
            // 
            // txtContratoIncial
            // 
            this.txtContratoIncial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtContratoIncial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContratoIncial.Location = new System.Drawing.Point(610, 459);
            this.txtContratoIncial.Name = "txtContratoIncial";
            this.txtContratoIncial.Size = new System.Drawing.Size(109, 22);
            this.txtContratoIncial.TabIndex = 235;
            this.txtContratoIncial.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtContratoFinal
            // 
            this.txtContratoFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtContratoFinal.Enabled = false;
            this.txtContratoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContratoFinal.Location = new System.Drawing.Point(779, 459);
            this.txtContratoFinal.Name = "txtContratoFinal";
            this.txtContratoFinal.Size = new System.Drawing.Size(109, 22);
            this.txtContratoFinal.TabIndex = 236;
            this.txtContratoFinal.TextChanged += new System.EventHandler(this.txtContratoFinal_TextChanged);
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltroId.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltroId.BorderRadius = 0;
            this.txtFiltroId.BorderSize = 2;
            this.txtFiltroId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroId.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltroId.Location = new System.Drawing.Point(61, 57);
            this.txtFiltroId.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroId.Multilinea = false;
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltroId.PasswordChar = false;
            this.txtFiltroId.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltroId.PlaceHolderText = "Buscar ..";
            this.txtFiltroId.Size = new System.Drawing.Size(196, 39);
            this.txtFiltroId.TabIndex = 214;
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
            this.txtFiltro.Location = new System.Drawing.Point(330, 57);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar ..";
            this.txtFiltro.Size = new System.Drawing.Size(419, 39);
            this.txtFiltro.TabIndex = 213;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged_1);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.ForestGreen;
            this.btnImprimir.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnImprimir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnImprimir.BorderRadius = 5;
            this.btnImprimir.BorderSize = 0;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(919, 443);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(210, 38);
            this.btnImprimir.TabIndex = 237;
            this.btnImprimir.Text = "Anular retiro";
            this.btnImprimir.TextGroundColor = System.Drawing.Color.White;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.especialButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton1.BorderRadius = 5;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(919, 490);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(210, 38);
            this.especialButton1.TabIndex = 238;
            this.especialButton1.Text = "Trasladar Saldo";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            // 
            // PnlRetirado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtContratoFinal);
            this.Controls.Add(this.txtContratoIncial);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtSaldoActual);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.llbTitulo);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtFiltroId);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlRetirado";
            this.Text = "PnlRetirado";
            this.Load += new System.EventHandler(this.PnlRetirado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private Controladores.LoginUserControl txtFiltroId;
        private Controladores.LoginUserControl txtFiltro;
        private System.Windows.Forms.Label label48;
        public System.Windows.Forms.Label llbTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtSaldoActual;
        private System.Windows.Forms.Label txtEstado;
        private System.Windows.Forms.TextBox txtContratoIncial;
        private System.Windows.Forms.TextBox txtContratoFinal;
        private Especiales.EspecialButton btnImprimir;
        private Especiales.EspecialButton especialButton1;
    }
}