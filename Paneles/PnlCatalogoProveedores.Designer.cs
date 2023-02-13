namespace NeoCobranza.Paneles
{
    partial class PnlCatalogoProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlCatalogoProveedores));
            this.dgvCatalogoClientes = new System.Windows.Forms.DataGridView();
            this.txtFiltrar = new NeoCobranza.Controladores.LoginUserControl();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.btnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton2 = new NeoCobranza.Especiales.EspecialButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.llbTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCatalogoClientes
            // 
            this.dgvCatalogoClientes.AllowUserToAddRows = false;
            this.dgvCatalogoClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCatalogoClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCatalogoClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCatalogoClientes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCatalogoClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogoClientes.Location = new System.Drawing.Point(16, 96);
            this.dgvCatalogoClientes.Name = "dgvCatalogoClientes";
            this.dgvCatalogoClientes.ReadOnly = true;
            this.dgvCatalogoClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogoClientes.Size = new System.Drawing.Size(1081, 386);
            this.dgvCatalogoClientes.TabIndex = 68;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltrar.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltrar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltrar.BorderRadius = 0;
            this.txtFiltrar.BorderSize = 2;
            this.txtFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrar.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltrar.Location = new System.Drawing.Point(20, 48);
            this.txtFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltrar.Multilinea = false;
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltrar.PasswordChar = false;
            this.txtFiltrar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltrar.PlaceHolderText = "Buscar Proveedor";
            this.txtFiltrar.Size = new System.Drawing.Size(1081, 35);
            this.txtFiltrar.TabIndex = 67;
            this.txtFiltrar.Texts = "";
            this.txtFiltrar.UnderLineFlat = true;
            this.txtFiltrar._TextChanged += new System.EventHandler(this.txtFiltrar__TextChanged);
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.especialButton1.BackColor = System.Drawing.Color.DarkCyan;
            this.especialButton1.BackGroundColor = System.Drawing.Color.DarkCyan;
            this.especialButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton1.BorderRadius = 20;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Location = new System.Drawing.Point(474, 506);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(139, 44);
            this.especialButton1.TabIndex = 71;
            this.especialButton1.Text = "Salir";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActualizar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActualizar.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnActualizar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnActualizar.BorderRadius = 20;
            this.btnActualizar.BorderSize = 0;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(890, 506);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(211, 44);
            this.btnActualizar.TabIndex = 70;
            this.btnActualizar.Text = "Actualizar Proveedor";
            this.btnActualizar.TextGroundColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAgregar.BorderRadius = 20;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(658, 506);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(215, 44);
            this.btnAgregar.TabIndex = 69;
            this.btnAgregar.Text = "Insertar Provedor";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // especialButton2
            // 
            this.especialButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.especialButton2.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton2.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton2.BorderRadius = 20;
            this.especialButton2.BorderSize = 0;
            this.especialButton2.FlatAppearance.BorderSize = 0;
            this.especialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton2.ForeColor = System.Drawing.Color.White;
            this.especialButton2.Image = ((System.Drawing.Image)(resources.GetObject("especialButton2.Image")));
            this.especialButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton2.Location = new System.Drawing.Point(16, 506);
            this.especialButton2.Name = "especialButton2";
            this.especialButton2.Size = new System.Drawing.Size(156, 44);
            this.especialButton2.TabIndex = 72;
            this.especialButton2.Text = "Refrescar";
            this.especialButton2.TextGroundColor = System.Drawing.Color.White;
            this.especialButton2.UseVisualStyleBackColor = false;
            this.especialButton2.Click += new System.EventHandler(this.especialButton2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1094, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 25);
            this.pictureBox4.TabIndex = 103;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(13, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "________________________________________";
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llbTitulo.Location = new System.Drawing.Point(11, 9);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(256, 25);
            this.llbTitulo.TabIndex = 101;
            this.llbTitulo.Text = "Catalogo de Proveedores";
            // 
            // PnlCatalogoProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1141, 562);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.llbTitulo);
            this.Controls.Add(this.especialButton2);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvCatalogoClientes);
            this.Controls.Add(this.txtFiltrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCatalogoProveedores";
            this.Text = "PnlCatalogoProveedores";
            this.Load += new System.EventHandler(this.PnlCatalogoProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCatalogoClientes;
        private Controladores.LoginUserControl txtFiltrar;
        private Especiales.EspecialButton especialButton1;
        private Especiales.EspecialButton btnActualizar;
        private Especiales.EspecialButton btnAgregar;
        private Especiales.EspecialButton especialButton2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label llbTitulo;
    }
}