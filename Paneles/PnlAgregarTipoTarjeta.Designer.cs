namespace NeoCobranza.Paneles
{
    partial class PnlAgregarTipoTarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlAgregarTipoTarjeta));
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblNombreDinamico = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSucursalesProductos = new System.Windows.Forms.DataGridView();
            this.CmbBancos = new System.Windows.Forms.ComboBox();
            this.BtnAgregarBanco = new NeoCobranza.Especiales.EspecialButton();
            this.BtnQuitarBanco = new NeoCobranza.Especiales.EspecialButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursalesProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNombre.Location = new System.Drawing.Point(12, 40);
            this.TxtNombre.MaxLength = 100;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(323, 23);
            this.TxtNombre.TabIndex = 100;
            // 
            // LblNombreDinamico
            // 
            this.LblNombreDinamico.AutoSize = true;
            this.LblNombreDinamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblNombreDinamico.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblNombreDinamico.Location = new System.Drawing.Point(8, 14);
            this.LblNombreDinamico.Name = "LblNombreDinamico";
            this.LblNombreDinamico.Size = new System.Drawing.Size(207, 18);
            this.LblNombreDinamico.TabIndex = 101;
            this.LblNombreDinamico.Text = "Nombre del Tipo de Tarjeta";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.dgvSucursalesProductos);
            this.panel1.Controls.Add(this.CmbBancos);
            this.panel1.Controls.Add(this.BtnAgregarBanco);
            this.panel1.Controls.Add(this.BtnQuitarBanco);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 328);
            this.panel1.TabIndex = 115;
            // 
            // dgvSucursalesProductos
            // 
            this.dgvSucursalesProductos.AllowUserToAddRows = false;
            this.dgvSucursalesProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSucursalesProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSucursalesProductos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSucursalesProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSucursalesProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSucursalesProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSucursalesProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSucursalesProductos.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSucursalesProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSucursalesProductos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSucursalesProductos.Location = new System.Drawing.Point(12, 119);
            this.dgvSucursalesProductos.Name = "dgvSucursalesProductos";
            this.dgvSucursalesProductos.ReadOnly = true;
            this.dgvSucursalesProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSucursalesProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSucursalesProductos.RowHeadersWidth = 15;
            this.dgvSucursalesProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSucursalesProductos.Size = new System.Drawing.Size(300, 199);
            this.dgvSucursalesProductos.TabIndex = 130;
            // 
            // CmbBancos
            // 
            this.CmbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBancos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbBancos.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.CmbBancos.FormattingEnabled = true;
            this.CmbBancos.Location = new System.Drawing.Point(12, 44);
            this.CmbBancos.Name = "CmbBancos";
            this.CmbBancos.Size = new System.Drawing.Size(297, 25);
            this.CmbBancos.TabIndex = 116;
            // 
            // BtnAgregarBanco
            // 
            this.BtnAgregarBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAgregarBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnAgregarBanco.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnAgregarBanco.BorderColor = System.Drawing.Color.Lime;
            this.BtnAgregarBanco.BorderRadius = 5;
            this.BtnAgregarBanco.BorderSize = 0;
            this.BtnAgregarBanco.FlatAppearance.BorderSize = 0;
            this.BtnAgregarBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarBanco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarBanco.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarBanco.Location = new System.Drawing.Point(149, 76);
            this.BtnAgregarBanco.Name = "BtnAgregarBanco";
            this.BtnAgregarBanco.Size = new System.Drawing.Size(77, 35);
            this.BtnAgregarBanco.TabIndex = 115;
            this.BtnAgregarBanco.Text = "Agregar";
            this.BtnAgregarBanco.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarBanco.UseVisualStyleBackColor = false;
            this.BtnAgregarBanco.Click += new System.EventHandler(this.BtnAgregarBanco_Click);
            // 
            // BtnQuitarBanco
            // 
            this.BtnQuitarBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnQuitarBanco.BackColor = System.Drawing.Color.Maroon;
            this.BtnQuitarBanco.BackGroundColor = System.Drawing.Color.Maroon;
            this.BtnQuitarBanco.BorderColor = System.Drawing.Color.Lime;
            this.BtnQuitarBanco.BorderRadius = 5;
            this.BtnQuitarBanco.BorderSize = 0;
            this.BtnQuitarBanco.FlatAppearance.BorderSize = 0;
            this.BtnQuitarBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuitarBanco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnQuitarBanco.ForeColor = System.Drawing.Color.White;
            this.BtnQuitarBanco.Location = new System.Drawing.Point(235, 76);
            this.BtnQuitarBanco.Name = "BtnQuitarBanco";
            this.BtnQuitarBanco.Size = new System.Drawing.Size(77, 35);
            this.BtnQuitarBanco.TabIndex = 114;
            this.BtnQuitarBanco.Text = "Quitar";
            this.BtnQuitarBanco.TextGroundColor = System.Drawing.Color.White;
            this.BtnQuitarBanco.UseVisualStyleBackColor = false;
            this.BtnQuitarBanco.Click += new System.EventHandler(this.BtnQuitarBanco_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(14, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 18);
            this.label6.TabIndex = 114;
            this.label6.Text = "Seleccione los Bancos";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.btnAgregar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.btnAgregar.BorderColor = System.Drawing.Color.Lime;
            this.btnAgregar.BorderRadius = 5;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(874, 556);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(173, 35);
            this.btnAgregar.TabIndex = 116;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(691, 556);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 35);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PnlAgregarTipoTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1056, 600);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblNombreDinamico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1072, 639);
            this.MinimumSize = new System.Drawing.Size(1072, 639);
            this.Name = "PnlAgregarTipoTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Tarjetas";
            this.Load += new System.EventHandler(this.PnlAgregarTipoTarjeta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursalesProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TxtNombre;
        public System.Windows.Forms.Label LblNombreDinamico;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvSucursalesProductos;
        private System.Windows.Forms.ComboBox CmbBancos;
        public Especiales.EspecialButton BtnAgregarBanco;
        public Especiales.EspecialButton BtnQuitarBanco;
        public System.Windows.Forms.Label label6;
        public Especiales.EspecialButton btnAgregar;
        public Especiales.EspecialButton btnCancelar;
    }
}