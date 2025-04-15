namespace NeoCobranza.Paneles
{
    partial class PnlAgregarVencimientosProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFiltro = new System.Windows.Forms.TextBox();
            this.DgvProveedor = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvDescontado = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.TxtFaltante = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCantidadDescontar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDescontado)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(20, 7);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4);
            this.label2.Size = new System.Drawing.Size(331, 28);
            this.label2.TabIndex = 167;
            this.label2.Text = "INVENTARIO DISTRIBUIDO POR PROVEEDOR";
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFiltro.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtFiltro.Location = new System.Drawing.Point(20, 41);
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.Size = new System.Drawing.Size(922, 23);
            this.TxtFiltro.TabIndex = 166;
            this.TxtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
            // 
            // DgvProveedor
            // 
            this.DgvProveedor.AllowUserToAddRows = false;
            this.DgvProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvProveedor.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvProveedor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvProveedor.ColumnHeadersHeight = 30;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProveedor.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvProveedor.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvProveedor.Location = new System.Drawing.Point(20, 66);
            this.DgvProveedor.Name = "DgvProveedor";
            this.DgvProveedor.ReadOnly = true;
            this.DgvProveedor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvProveedor.RowHeadersWidth = 15;
            this.DgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProveedor.Size = new System.Drawing.Size(922, 231);
            this.DgvProveedor.TabIndex = 165;
            this.DgvProveedor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProveedor_CellContentClick);
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
            this.btnCancelar.Location = new System.Drawing.Point(768, 453);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 34);
            this.btnCancelar.TabIndex = 168;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(20, 300);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4);
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 169;
            this.label1.Text = "SELECCIONADO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DgvDescontado
            // 
            this.DgvDescontado.AllowUserToAddRows = false;
            this.DgvDescontado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvDescontado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvDescontado.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvDescontado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvDescontado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDescontado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvDescontado.ColumnHeadersHeight = 30;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvDescontado.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvDescontado.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvDescontado.Location = new System.Drawing.Point(20, 331);
            this.DgvDescontado.Name = "DgvDescontado";
            this.DgvDescontado.ReadOnly = true;
            this.DgvDescontado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDescontado.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvDescontado.RowHeadersWidth = 15;
            this.DgvDescontado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDescontado.Size = new System.Drawing.Size(922, 117);
            this.DgvDescontado.TabIndex = 170;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlText;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(432, 7);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4);
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 171;
            this.label3.Text = "CANTIDAD";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidad.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.ForeColor = System.Drawing.Color.Black;
            this.TxtCantidad.Location = new System.Drawing.Point(532, 7);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(157, 28);
            this.TxtCantidad.TabIndex = 172;
            // 
            // TxtFaltante
            // 
            this.TxtFaltante.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtFaltante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFaltante.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFaltante.ForeColor = System.Drawing.Color.Black;
            this.TxtFaltante.Location = new System.Drawing.Point(783, 7);
            this.TxtFaltante.Name = "TxtFaltante";
            this.TxtFaltante.Size = new System.Drawing.Size(157, 28);
            this.TxtFaltante.TabIndex = 174;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlText;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(695, 7);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(4);
            this.label4.Size = new System.Drawing.Size(82, 28);
            this.label4.TabIndex = 173;
            this.label4.Text = "FALTANTE";
            // 
            // TxtCantidadDescontar
            // 
            this.TxtCantidadDescontar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtCantidadDescontar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidadDescontar.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidadDescontar.ForeColor = System.Drawing.Color.Black;
            this.TxtCantidadDescontar.Location = new System.Drawing.Point(226, 453);
            this.TxtCantidadDescontar.Name = "TxtCantidadDescontar";
            this.TxtCantidadDescontar.Size = new System.Drawing.Size(157, 28);
            this.TxtCantidadDescontar.TabIndex = 176;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlText;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(20, 453);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(4);
            this.label5.Size = new System.Drawing.Size(200, 28);
            this.label5.TabIndex = 175;
            this.label5.Text = "CANTIDAD A DESCONTAR";
            // 
            // PnlAgregarVencimientosProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 490);
            this.Controls.Add(this.TxtCantidadDescontar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtFaltante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DgvDescontado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFiltro);
            this.Controls.Add(this.DgvProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(978, 515);
            this.Name = "PnlAgregarVencimientosProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELECCIONAR PROVEEDOR";
            this.Load += new System.EventHandler(this.PnlAgregarVencimientosProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDescontado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TxtFiltro;
        public System.Windows.Forms.DataGridView DgvProveedor;
        public Especiales.EspecialButton btnCancelar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView DgvDescontado;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TxtCantidad;
        public System.Windows.Forms.TextBox TxtFaltante;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox TxtCantidadDescontar;
        public System.Windows.Forms.Label label5;
    }
}