namespace NeoCobranza.Paneles
{
    partial class PnlTrasladoProduco
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlTrasladoProduco));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbAlmacenEntrado = new System.Windows.Forms.ComboBox();
            this.CmbAlmacenSalida = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DgvProducto = new System.Windows.Forms.DataGridView();
            this.TxtFiltroProducto = new System.Windows.Forms.TextBox();
            this.BtnBuscarProducto = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.BtnGuardar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnAgregarProducto = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(-10, 479);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1144, 44);
            this.PnlTitulo.TabIndex = 148;
            // 
            // TbTitulo
            // 
            this.TbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbTitulo.AutoSize = true;
            this.TbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbTitulo.Location = new System.Drawing.Point(12, 3);
            this.TbTitulo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TbTitulo.Name = "TbTitulo";
            this.TbTitulo.Size = new System.Drawing.Size(319, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Traslados de Productos";
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCatalogo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCatalogo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogo.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogo.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCatalogo.Location = new System.Drawing.Point(600, 65);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogo.RowHeadersWidth = 15;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCatalogo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(514, 361);
            this.dgvCatalogo.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(724, 13);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.label1.Size = new System.Drawing.Size(390, 42);
            this.label1.TabIndex = 150;
            this.label1.Text = "Lista de Productos Trasladados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.label2.Size = new System.Drawing.Size(277, 42);
            this.label2.TabIndex = 151;
            this.label2.Text = "Datos del Traslado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 22);
            this.label3.TabIndex = 152;
            this.label3.Text = "Almacén Entrada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 22);
            this.label4.TabIndex = 153;
            this.label4.Text = "Almacén Salida:";
            // 
            // CmbAlmacenEntrado
            // 
            this.CmbAlmacenEntrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAlmacenEntrado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAlmacenEntrado.FormattingEnabled = true;
            this.CmbAlmacenEntrado.Location = new System.Drawing.Point(16, 103);
            this.CmbAlmacenEntrado.Name = "CmbAlmacenEntrado";
            this.CmbAlmacenEntrado.Size = new System.Drawing.Size(534, 29);
            this.CmbAlmacenEntrado.TabIndex = 155;
            // 
            // CmbAlmacenSalida
            // 
            this.CmbAlmacenSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAlmacenSalida.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAlmacenSalida.FormattingEnabled = true;
            this.CmbAlmacenSalida.Location = new System.Drawing.Point(16, 183);
            this.CmbAlmacenSalida.Name = "CmbAlmacenSalida";
            this.CmbAlmacenSalida.Size = new System.Drawing.Size(534, 29);
            this.CmbAlmacenSalida.TabIndex = 156;
            this.CmbAlmacenSalida.SelectedIndexChanged += new System.EventHandler(this.CmbAlmacenSalida_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(12, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 22);
            this.label5.TabIndex = 160;
            this.label5.Text = "Seleccione el Producto";
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvProducto.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgvProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvProducto.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvProducto.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvProducto.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DgvProducto.Location = new System.Drawing.Point(16, 294);
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.ReadOnly = true;
            this.DgvProducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvProducto.RowHeadersWidth = 15;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.DgvProducto.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProducto.Size = new System.Drawing.Size(534, 115);
            this.DgvProducto.TabIndex = 161;
            // 
            // TxtFiltroProducto
            // 
            this.TxtFiltroProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFiltroProducto.Location = new System.Drawing.Point(16, 261);
            this.TxtFiltroProducto.MaxLength = 100;
            this.TxtFiltroProducto.Name = "TxtFiltroProducto";
            this.TxtFiltroProducto.Size = new System.Drawing.Size(400, 27);
            this.TxtFiltroProducto.TabIndex = 162;
            // 
            // BtnBuscarProducto
            // 
            this.BtnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnBuscarProducto.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(43)))));
            this.BtnBuscarProducto.BorderColor = System.Drawing.Color.Lime;
            this.BtnBuscarProducto.BorderRadius = 5;
            this.BtnBuscarProducto.BorderSize = 0;
            this.BtnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.BtnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.BtnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscarProducto.Image")));
            this.BtnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscarProducto.Location = new System.Drawing.Point(422, 261);
            this.BtnBuscarProducto.Name = "BtnBuscarProducto";
            this.BtnBuscarProducto.Size = new System.Drawing.Size(128, 27);
            this.BtnBuscarProducto.TabIndex = 163;
            this.BtnBuscarProducto.Text = "Buscar";
            this.BtnBuscarProducto.TextGroundColor = System.Drawing.Color.White;
            this.BtnBuscarProducto.UseVisualStyleBackColor = false;
            this.BtnBuscarProducto.Click += new System.EventHandler(this.BtnBuscarProducto_Click);
            // 
            // especialButton1
            // 
            this.especialButton1.BackColor = System.Drawing.Color.Maroon;
            this.especialButton1.BackGroundColor = System.Drawing.Color.Maroon;
            this.especialButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton1.BorderRadius = 5;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(291, 13);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(158, 39);
            this.especialButton1.TabIndex = 159;
            this.especialButton1.Text = "Limpiar";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnGuardar.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnGuardar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnGuardar.BorderRadius = 5;
            this.BtnGuardar.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuardar.Image")));
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.Location = new System.Drawing.Point(888, 435);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(226, 38);
            this.BtnGuardar.TabIndex = 158;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            // 
            // BtnAgregarProducto
            // 
            this.BtnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAgregarProducto.BackColor = System.Drawing.Color.Green;
            this.BtnAgregarProducto.BackGroundColor = System.Drawing.Color.Green;
            this.BtnAgregarProducto.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnAgregarProducto.BorderRadius = 5;
            this.BtnAgregarProducto.BorderSize = 0;
            this.BtnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarProducto.Image")));
            this.BtnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarProducto.Location = new System.Drawing.Point(326, 433);
            this.BtnAgregarProducto.Name = "BtnAgregarProducto";
            this.BtnAgregarProducto.Size = new System.Drawing.Size(226, 38);
            this.BtnAgregarProducto.TabIndex = 157;
            this.BtnAgregarProducto.Text = "Agregar Producto";
            this.BtnAgregarProducto.TextGroundColor = System.Drawing.Color.White;
            this.BtnAgregarProducto.UseVisualStyleBackColor = false;
            this.BtnAgregarProducto.Click += new System.EventHandler(this.BtnAgregarProducto_Click);
            // 
            // PnlTrasladoProduco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.BtnBuscarProducto);
            this.Controls.Add(this.TxtFiltroProducto);
            this.Controls.Add(this.DgvProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnAgregarProducto);
            this.Controls.Add(this.CmbAlmacenSalida);
            this.Controls.Add(this.CmbAlmacenEntrado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCatalogo);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlTrasladoProduco";
            this.Text = "PnlTrasladoProduco";
            this.Load += new System.EventHandler(this.PnlTrasladoProduco_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.DataGridView dgvCatalogo;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbAlmacenEntrado;
        private System.Windows.Forms.ComboBox CmbAlmacenSalida;
        public Especiales.EspecialButton BtnAgregarProducto;
        public Especiales.EspecialButton BtnGuardar;
        public Especiales.EspecialButton especialButton1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView DgvProducto;
        public Especiales.EspecialButton BtnBuscarProducto;
        public System.Windows.Forms.TextBox TxtFiltroProducto;
    }
}