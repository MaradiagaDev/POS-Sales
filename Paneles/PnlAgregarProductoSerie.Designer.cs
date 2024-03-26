namespace NeoCobranza.Paneles
{
    partial class PnlAgregarProductoSerie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgregarProductoSerie));
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblDinamico = new System.Windows.Forms.Label();
            this.DgvLotes = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGuardar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.TxtRazon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtIdentificador = new System.Windows.Forms.TextBox();
            this.LblIdentificadorAjuste = new System.Windows.Forms.Label();
            this.CmbOrdenarPor = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.LblDinamico);
            this.panel3.Location = new System.Drawing.Point(-2, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1358, 33);
            this.panel3.TabIndex = 96;
            // 
            // LblDinamico
            // 
            this.LblDinamico.AutoSize = true;
            this.LblDinamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDinamico.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblDinamico.Location = new System.Drawing.Point(22, 9);
            this.LblDinamico.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.LblDinamico.Name = "LblDinamico";
            this.LblDinamico.Size = new System.Drawing.Size(155, 18);
            this.LblDinamico.TabIndex = 1;
            this.LblDinamico.Text = "Merma de Producto";
            // 
            // DgvLotes
            // 
            this.DgvLotes.AllowUserToAddRows = false;
            this.DgvLotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvLotes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DgvLotes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvLotes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvLotes.ColumnHeadersHeight = 60;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLotes.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvLotes.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvLotes.Location = new System.Drawing.Point(16, 80);
            this.DgvLotes.Name = "DgvLotes";
            this.DgvLotes.ReadOnly = true;
            this.DgvLotes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLotes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvLotes.RowHeadersWidth = 15;
            this.DgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLotes.Size = new System.Drawing.Size(1316, 282);
            this.DgvLotes.TabIndex = 136;
            this.DgvLotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrarProducto_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(15, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(744, 18);
            this.label6.TabIndex = 135;
            this.label6.Text = "Seleccione el lote al que desea realizarle el ajuste (Solo aparecen lotes con pro" +
    "ductos disponibles)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardar.BorderColor = System.Drawing.Color.Lime;
            this.BtnGuardar.BorderRadius = 5;
            this.BtnGuardar.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(1160, 685);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(173, 35);
            this.BtnGuardar.TabIndex = 139;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(977, 685);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 35);
            this.btnCancelar.TabIndex = 140;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(16, 567);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 151;
            this.label1.Text = "Cantidad:";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtCantidad.Location = new System.Drawing.Point(19, 597);
            this.TxtCantidad.MaxLength = 100;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(226, 23);
            this.TxtCantidad.TabIndex = 150;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // TxtRazon
            // 
            this.TxtRazon.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtRazon.Location = new System.Drawing.Point(18, 498);
            this.TxtRazon.MaxLength = 100;
            this.TxtRazon.Multiline = true;
            this.TxtRazon.Name = "TxtRazon";
            this.TxtRazon.Size = new System.Drawing.Size(957, 54);
            this.TxtRazon.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(16, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 149;
            this.label4.Text = "Razón:";
            // 
            // TxtIdentificador
            // 
            this.TxtIdentificador.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtIdentificador.Location = new System.Drawing.Point(15, 427);
            this.TxtIdentificador.MaxLength = 100;
            this.TxtIdentificador.Name = "TxtIdentificador";
            this.TxtIdentificador.Size = new System.Drawing.Size(960, 23);
            this.TxtIdentificador.TabIndex = 147;
            // 
            // LblIdentificadorAjuste
            // 
            this.LblIdentificadorAjuste.AutoSize = true;
            this.LblIdentificadorAjuste.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblIdentificadorAjuste.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LblIdentificadorAjuste.Location = new System.Drawing.Point(13, 392);
            this.LblIdentificadorAjuste.Name = "LblIdentificadorAjuste";
            this.LblIdentificadorAjuste.Size = new System.Drawing.Size(203, 18);
            this.LblIdentificadorAjuste.TabIndex = 146;
            this.LblIdentificadorAjuste.Text = "Nombre o Identificador (*)";
            // 
            // CmbOrdenarPor
            // 
            this.CmbOrdenarPor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbOrdenarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOrdenarPor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOrdenarPor.FormattingEnabled = true;
            this.CmbOrdenarPor.Location = new System.Drawing.Point(779, 49);
            this.CmbOrdenarPor.Name = "CmbOrdenarPor";
            this.CmbOrdenarPor.Size = new System.Drawing.Size(454, 25);
            this.CmbOrdenarPor.TabIndex = 152;
            this.CmbOrdenarPor.SelectedIndexChanged += new System.EventHandler(this.CmbOrdenarPor_SelectedIndexChanged);
            // 
            // PnlAgregarProductoSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1356, 742);
            this.Controls.Add(this.CmbOrdenarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.TxtRazon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtIdentificador);
            this.Controls.Add(this.LblIdentificadorAjuste);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.DgvLotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1372, 781);
            this.MinimumSize = new System.Drawing.Size(1372, 781);
            this.Name = "PnlAgregarProductoSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merma de Producto";
            this.Load += new System.EventHandler(this.PnlAgregarProductoSerie_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label LblDinamico;
        public System.Windows.Forms.DataGridView DgvLotes;
        public System.Windows.Forms.Label label6;
        public Especiales.EspecialButton BtnGuardar;
        public Especiales.EspecialButton btnCancelar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TxtCantidad;
        public System.Windows.Forms.TextBox TxtRazon;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtIdentificador;
        public System.Windows.Forms.Label LblIdentificadorAjuste;
        private System.Windows.Forms.ComboBox CmbOrdenarPor;
    }
}