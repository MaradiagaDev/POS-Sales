namespace NeoCobranza.Paneles_Auditorias
{
    partial class CreacionUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreacionUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnBuscar = new System.Windows.Forms.PictureBox();
            this.DGVUser = new System.Windows.Forms.DataGridView();
            this.IDUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbFiltro = new System.Windows.Forms.ComboBox();
            this.BtnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltroUsuario = new NeoCobranza.Controladores.LoginUserControl();
            this.BtnCambiarEstado = new NeoCobranza.Especiales.EspecialButton();
            this.BtnCrearUsuario = new NeoCobranza.Especiales.EspecialButton();
            this.BtnActualizar = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUser)).BeginInit();
            this.PnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.BtnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.BackgroundImage")));
            this.BtnBuscar.Location = new System.Drawing.Point(564, 18);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(34, 31);
            this.BtnBuscar.TabIndex = 44;
            this.BtnBuscar.TabStop = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // DGVUser
            // 
            this.DGVUser.AllowUserToAddRows = false;
            this.DGVUser.AllowUserToDeleteRows = false;
            this.DGVUser.AllowUserToResizeRows = false;
            this.DGVUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVUser.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDUser,
            this.User,
            this.PrimerNombre,
            this.PrimerApellido,
            this.Rol,
            this.Estado,
            this.Sucursal});
            this.DGVUser.EnableHeadersVisualStyles = false;
            this.DGVUser.Location = new System.Drawing.Point(13, 138);
            this.DGVUser.MultiSelect = false;
            this.DGVUser.Name = "DGVUser";
            this.DGVUser.ReadOnly = true;
            this.DGVUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVUser.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DGVUser.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVUser.Size = new System.Drawing.Size(1132, 391);
            this.DGVUser.TabIndex = 45;
            // 
            // IDUser
            // 
            this.IDUser.HeaderText = "ID";
            this.IDUser.Name = "IDUser";
            this.IDUser.ReadOnly = true;
            // 
            // User
            // 
            this.User.HeaderText = "Usuario";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // PrimerNombre
            // 
            this.PrimerNombre.HeaderText = "Primer Nombre";
            this.PrimerNombre.Name = "PrimerNombre";
            this.PrimerNombre.ReadOnly = true;
            // 
            // PrimerApellido
            // 
            this.PrimerApellido.HeaderText = "Primer Apellido";
            this.PrimerApellido.Name = "PrimerApellido";
            this.PrimerApellido.ReadOnly = true;
            // 
            // Rol
            // 
            this.Rol.DataPropertyName = "RolID";
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            this.Rol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Sucursal
            // 
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.ReadOnly = true;
            // 
            // CmbFiltro
            // 
            this.CmbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbFiltro.DisplayMember = "ID";
            this.CmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbFiltro.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFiltro.FormattingEnabled = true;
            this.CmbFiltro.Items.AddRange(new object[] {
            "ID",
            "USUARIO",
            "NOMBRE",
            "APELLIDO"});
            this.CmbFiltro.Location = new System.Drawing.Point(910, 18);
            this.CmbFiltro.Name = "CmbFiltro";
            this.CmbFiltro.Size = new System.Drawing.Size(222, 32);
            this.CmbFiltro.TabIndex = 47;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BackGroundColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCancelar.BorderRadius = 40;
            this.BtnCancelar.BorderSize = 0;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelar.Location = new System.Drawing.Point(615, 13);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(150, 40);
            this.BtnCancelar.TabIndex = 46;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextGroundColor = System.Drawing.Color.Black;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // txtFiltroUsuario
            // 
            this.txtFiltroUsuario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtFiltroUsuario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltroUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltroUsuario.BorderRadius = 15;
            this.txtFiltroUsuario.BorderSize = 1;
            this.txtFiltroUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltroUsuario.Location = new System.Drawing.Point(13, 13);
            this.txtFiltroUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltroUsuario.Multilinea = false;
            this.txtFiltroUsuario.Name = "txtFiltroUsuario";
            this.txtFiltroUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltroUsuario.PasswordChar = false;
            this.txtFiltroUsuario.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltroUsuario.PlaceHolderText = "Buscar...";
            this.txtFiltroUsuario.Size = new System.Drawing.Size(595, 40);
            this.txtFiltroUsuario.TabIndex = 7;
            this.txtFiltroUsuario.Texts = "";
            this.txtFiltroUsuario.UnderLineFlat = false;
            // 
            // BtnCambiarEstado
            // 
            this.BtnCambiarEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCambiarEstado.BackColor = System.Drawing.Color.Black;
            this.BtnCambiarEstado.BackGroundColor = System.Drawing.Color.Black;
            this.BtnCambiarEstado.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCambiarEstado.BorderRadius = 5;
            this.BtnCambiarEstado.BorderSize = 0;
            this.BtnCambiarEstado.FlatAppearance.BorderSize = 0;
            this.BtnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarEstado.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarEstado.ForeColor = System.Drawing.Color.White;
            this.BtnCambiarEstado.Location = new System.Drawing.Point(605, 75);
            this.BtnCambiarEstado.Name = "BtnCambiarEstado";
            this.BtnCambiarEstado.Size = new System.Drawing.Size(171, 40);
            this.BtnCambiarEstado.TabIndex = 48;
            this.BtnCambiarEstado.Text = "Cambiar Estado";
            this.BtnCambiarEstado.TextGroundColor = System.Drawing.Color.White;
            this.BtnCambiarEstado.UseVisualStyleBackColor = false;
            this.BtnCambiarEstado.Click += new System.EventHandler(this.BtnCambiarEstado_Click);
            // 
            // BtnCrearUsuario
            // 
            this.BtnCrearUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCrearUsuario.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCrearUsuario.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnCrearUsuario.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCrearUsuario.BorderRadius = 5;
            this.BtnCrearUsuario.BorderSize = 0;
            this.BtnCrearUsuario.FlatAppearance.BorderSize = 0;
            this.BtnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearUsuario.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.Location = new System.Drawing.Point(971, 75);
            this.BtnCrearUsuario.Name = "BtnCrearUsuario";
            this.BtnCrearUsuario.Size = new System.Drawing.Size(171, 40);
            this.BtnCrearUsuario.TabIndex = 49;
            this.BtnCrearUsuario.Text = "Crear Usuario";
            this.BtnCrearUsuario.TextGroundColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.UseVisualStyleBackColor = false;
            this.BtnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnActualizar.BackColor = System.Drawing.Color.Gray;
            this.BtnActualizar.BackGroundColor = System.Drawing.Color.Gray;
            this.BtnActualizar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnActualizar.BorderRadius = 5;
            this.BtnActualizar.BorderSize = 0;
            this.BtnActualizar.FlatAppearance.BorderSize = 0;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.ForeColor = System.Drawing.Color.White;
            this.BtnActualizar.Location = new System.Drawing.Point(781, 75);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(185, 40);
            this.BtnActualizar.TabIndex = 50;
            this.BtnActualizar.Text = "Actualizar Usuario";
            this.BtnActualizar.TextGroundColor = System.Drawing.Color.White;
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(0, 557);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1160, 44);
            this.PnlTitulo.TabIndex = 146;
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
            this.TbTitulo.Size = new System.Drawing.Size(275, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Gestión de Usuarios";
            // 
            // CreacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.PnlTitulo);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnCrearUsuario);
            this.Controls.Add(this.BtnCambiarEstado);
            this.Controls.Add(this.CmbFiltro);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.DGVUser);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.txtFiltroUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreacionUsuario";
            this.Text = "CreacionUsuario";
            this.Load += new System.EventHandler(this.CreacionUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUser)).EndInit();
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Controladores.LoginUserControl txtFiltroUsuario;
        private System.Windows.Forms.PictureBox BtnBuscar;
        private System.Windows.Forms.DataGridView DGVUser;
        private Especiales.EspecialButton BtnCancelar;
        public System.Windows.Forms.ComboBox CmbFiltro;
        private Especiales.EspecialButton BtnCambiarEstado;
        private Especiales.EspecialButton BtnCrearUsuario;
        private Especiales.EspecialButton BtnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
    }
}