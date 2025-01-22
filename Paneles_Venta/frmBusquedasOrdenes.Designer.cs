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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.llbTitulo = new System.Windows.Forms.Label();
            this.dgvCatalogoOrdenes = new System.Windows.Forms.DataGridView();
            this.especialButton2 = new NeoCobranza.Especiales.EspecialButton();
            this.TxtFiltrar = new NeoCobranza.Controladores.LoginUserControl();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoOrdenes)).BeginInit();
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCatalogoOrdenes.ColumnHeadersHeight = 30;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogoOrdenes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCatalogoOrdenes.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCatalogoOrdenes.Location = new System.Drawing.Point(16, 62);
            this.dgvCatalogoOrdenes.Name = "dgvCatalogoOrdenes";
            this.dgvCatalogoOrdenes.ReadOnly = true;
            this.dgvCatalogoOrdenes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogoOrdenes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCatalogoOrdenes.RowHeadersWidth = 15;
            this.dgvCatalogoOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogoOrdenes.Size = new System.Drawing.Size(1116, 437);
            this.dgvCatalogoOrdenes.TabIndex = 148;
            this.dgvCatalogoOrdenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogoOrdenes_CellContentClick);
            // 
            // especialButton2
            // 
            this.especialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.especialButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.especialButton2.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.especialButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton2.BorderRadius = 5;
            this.especialButton2.BorderSize = 0;
            this.especialButton2.FlatAppearance.BorderSize = 0;
            this.especialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton2.ForeColor = System.Drawing.Color.White;
            this.especialButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton2.Location = new System.Drawing.Point(504, 9);
            this.especialButton2.Name = "especialButton2";
            this.especialButton2.Size = new System.Drawing.Size(148, 38);
            this.especialButton2.TabIndex = 149;
            this.especialButton2.Text = "Buscar";
            this.especialButton2.TextGroundColor = System.Drawing.Color.White;
            this.especialButton2.UseVisualStyleBackColor = false;
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
            // 
            // frmBusquedasOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1158, 555);
            this.Controls.Add(this.especialButton2);
            this.Controls.Add(this.dgvCatalogoOrdenes);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBusquedasOrdenes";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label llbTitulo;
        public Especiales.EspecialButton especialButton2;
        public System.Windows.Forms.DataGridView dgvCatalogoOrdenes;
        public Controladores.LoginUserControl TxtFiltrar;
    }
}