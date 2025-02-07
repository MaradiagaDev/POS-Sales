namespace NeoCobranza.Paneles_Auditorias
{
    partial class GestionPermisos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridPermisos = new System.Windows.Forms.SplitContainer();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TIBuscar = new System.Windows.Forms.TabPage();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.BtnConfigurar = new System.Windows.Forms.Button();
            this.LvRol = new System.Windows.Forms.DataGridView();
            this.TbTituloGenerales = new System.Windows.Forms.Label();
            this.TICrearRol = new System.Windows.Forms.TabPage();
            this.BtnGuardarRol = new System.Windows.Forms.Button();
            this.BtnCancelarRol = new System.Windows.Forms.Button();
            this.TxtNombrePermiso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DTLvlUno = new System.Windows.Forms.DataGridView();
            this.DtLvlDos = new System.Windows.Forms.DataGridView();
            this.DtLvlTres = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridPermisos)).BeginInit();
            this.GridPermisos.Panel1.SuspendLayout();
            this.GridPermisos.Panel2.SuspendLayout();
            this.GridPermisos.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.TIBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LvRol)).BeginInit();
            this.TICrearRol.SuspendLayout();
            this.PnlTitulo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTLvlUno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtLvlDos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtLvlTres)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPermisos
            // 
            this.GridPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPermisos.Location = new System.Drawing.Point(0, 0);
            this.GridPermisos.Name = "GridPermisos";
            this.GridPermisos.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // GridPermisos.Panel1
            // 
            this.GridPermisos.Panel1.Controls.Add(this.TCMain);
            // 
            // GridPermisos.Panel2
            // 
            this.GridPermisos.Panel2.Controls.Add(this.PnlTitulo);
            this.GridPermisos.Size = new System.Drawing.Size(1157, 601);
            this.GridPermisos.SplitterDistance = 554;
            this.GridPermisos.TabIndex = 0;
            // 
            // TCMain
            // 
            this.TCMain.Controls.Add(this.TIBuscar);
            this.TCMain.Controls.Add(this.TICrearRol);
            this.TCMain.Controls.Add(this.tabPage1);
            this.TCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCMain.Location = new System.Drawing.Point(0, 0);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(1157, 554);
            this.TCMain.TabIndex = 1;
            // 
            // TIBuscar
            // 
            this.TIBuscar.Controls.Add(this.BtnModificar);
            this.TIBuscar.Controls.Add(this.BtnCrear);
            this.TIBuscar.Controls.Add(this.BtnConfigurar);
            this.TIBuscar.Controls.Add(this.LvRol);
            this.TIBuscar.Controls.Add(this.TbTituloGenerales);
            this.TIBuscar.Location = new System.Drawing.Point(4, 22);
            this.TIBuscar.Name = "TIBuscar";
            this.TIBuscar.Padding = new System.Windows.Forms.Padding(3);
            this.TIBuscar.Size = new System.Drawing.Size(1149, 528);
            this.TIBuscar.TabIndex = 1;
            this.TIBuscar.Text = "Buscar";
            this.TIBuscar.UseVisualStyleBackColor = true;
            // 
            // BtnModificar
            // 
            this.BtnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModificar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnModificar.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Italic);
            this.BtnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnModificar.Location = new System.Drawing.Point(793, 153);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(146, 42);
            this.BtnModificar.TabIndex = 57;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCrear.BackColor = System.Drawing.Color.Green;
            this.BtnCrear.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Italic);
            this.BtnCrear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCrear.Location = new System.Drawing.Point(793, 98);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(146, 42);
            this.BtnCrear.TabIndex = 56;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = false;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // BtnConfigurar
            // 
            this.BtnConfigurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfigurar.BackColor = System.Drawing.Color.Black;
            this.BtnConfigurar.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Italic);
            this.BtnConfigurar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnConfigurar.Location = new System.Drawing.Point(793, 212);
            this.BtnConfigurar.Name = "BtnConfigurar";
            this.BtnConfigurar.Size = new System.Drawing.Size(146, 42);
            this.BtnConfigurar.TabIndex = 55;
            this.BtnConfigurar.Text = "Configurar";
            this.BtnConfigurar.UseVisualStyleBackColor = false;
            this.BtnConfigurar.Click += new System.EventHandler(this.BtnConfigurar_Click);
            // 
            // LvRol
            // 
            this.LvRol.AllowUserToAddRows = false;
            this.LvRol.AllowUserToDeleteRows = false;
            this.LvRol.AllowUserToResizeRows = false;
            this.LvRol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvRol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LvRol.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.LvRol.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.LvRol.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LvRol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.LvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LvRol.EnableHeadersVisualStyles = false;
            this.LvRol.Location = new System.Drawing.Point(38, 98);
            this.LvRol.MultiSelect = false;
            this.LvRol.Name = "LvRol";
            this.LvRol.ReadOnly = true;
            this.LvRol.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LvRol.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SlateGray;
            this.LvRol.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.LvRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LvRol.Size = new System.Drawing.Size(738, 394);
            this.LvRol.TabIndex = 53;
            // 
            // TbTituloGenerales
            // 
            this.TbTituloGenerales.AutoSize = true;
            this.TbTituloGenerales.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Italic);
            this.TbTituloGenerales.Location = new System.Drawing.Point(33, 42);
            this.TbTituloGenerales.Name = "TbTituloGenerales";
            this.TbTituloGenerales.Size = new System.Drawing.Size(244, 28);
            this.TbTituloGenerales.TabIndex = 0;
            this.TbTituloGenerales.Text = "Permisos de Usuario";
            // 
            // TICrearRol
            // 
            this.TICrearRol.Controls.Add(this.BtnGuardarRol);
            this.TICrearRol.Controls.Add(this.BtnCancelarRol);
            this.TICrearRol.Controls.Add(this.TxtNombrePermiso);
            this.TICrearRol.Controls.Add(this.label1);
            this.TICrearRol.Location = new System.Drawing.Point(4, 22);
            this.TICrearRol.Name = "TICrearRol";
            this.TICrearRol.Padding = new System.Windows.Forms.Padding(3);
            this.TICrearRol.Size = new System.Drawing.Size(1149, 528);
            this.TICrearRol.TabIndex = 2;
            this.TICrearRol.Text = "CrearRol";
            this.TICrearRol.UseVisualStyleBackColor = true;
            // 
            // BtnGuardarRol
            // 
            this.BtnGuardarRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardarRol.BackColor = System.Drawing.Color.Black;
            this.BtnGuardarRol.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic);
            this.BtnGuardarRol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnGuardarRol.Location = new System.Drawing.Point(1028, 480);
            this.BtnGuardarRol.Name = "BtnGuardarRol";
            this.BtnGuardarRol.Size = new System.Drawing.Size(112, 42);
            this.BtnGuardarRol.TabIndex = 58;
            this.BtnGuardarRol.Text = "Guardar";
            this.BtnGuardarRol.UseVisualStyleBackColor = false;
            this.BtnGuardarRol.Click += new System.EventHandler(this.BtnGuardarRol_Click);
            // 
            // BtnCancelarRol
            // 
            this.BtnCancelarRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelarRol.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic);
            this.BtnCancelarRol.Location = new System.Drawing.Point(858, 480);
            this.BtnCancelarRol.Name = "BtnCancelarRol";
            this.BtnCancelarRol.Size = new System.Drawing.Size(112, 42);
            this.BtnCancelarRol.TabIndex = 57;
            this.BtnCancelarRol.Text = "Cancelar";
            this.BtnCancelarRol.UseVisualStyleBackColor = true;
            this.BtnCancelarRol.Click += new System.EventHandler(this.BtnCancelarRol_Click);
            // 
            // TxtNombrePermiso
            // 
            this.TxtNombrePermiso.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic);
            this.TxtNombrePermiso.Location = new System.Drawing.Point(35, 96);
            this.TxtNombrePermiso.Name = "TxtNombrePermiso";
            this.TxtNombrePermiso.Size = new System.Drawing.Size(384, 30);
            this.TxtNombrePermiso.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del Permiso";
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PnlTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1157, 43);
            this.PnlTitulo.TabIndex = 0;
            // 
            // TbTitulo
            // 
            this.TbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbTitulo.AutoSize = true;
            this.TbTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbTitulo.Location = new System.Drawing.Point(33, 5);
            this.TbTitulo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TbTitulo.Name = "TbTitulo";
            this.TbTitulo.Size = new System.Drawing.Size(86, 33);
            this.TbTitulo.TabIndex = 0;
            this.TbTitulo.Text = "Titulo";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtLvlTres);
            this.tabPage1.Controls.Add(this.DtLvlDos);
            this.tabPage1.Controls.Add(this.DTLvlUno);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1149, 528);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Permisos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DTLvlUno
            // 
            this.DTLvlUno.AllowUserToAddRows = false;
            this.DTLvlUno.AllowUserToDeleteRows = false;
            this.DTLvlUno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DTLvlUno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTLvlUno.Location = new System.Drawing.Point(35, 23);
            this.DTLvlUno.Name = "DTLvlUno";
            this.DTLvlUno.Size = new System.Drawing.Size(346, 477);
            this.DTLvlUno.TabIndex = 0;
            this.DTLvlUno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTLvlUno_CellContentClick);
            // 
            // DtLvlDos
            // 
            this.DtLvlDos.AllowUserToAddRows = false;
            this.DtLvlDos.AllowUserToDeleteRows = false;
            this.DtLvlDos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DtLvlDos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtLvlDos.Location = new System.Drawing.Point(407, 23);
            this.DtLvlDos.Name = "DtLvlDos";
            this.DtLvlDos.Size = new System.Drawing.Size(346, 477);
            this.DtLvlDos.TabIndex = 1;
            // 
            // DtLvlTres
            // 
            this.DtLvlTres.AllowUserToAddRows = false;
            this.DtLvlTres.AllowUserToDeleteRows = false;
            this.DtLvlTres.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DtLvlTres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtLvlTres.Location = new System.Drawing.Point(783, 23);
            this.DtLvlTres.Name = "DtLvlTres";
            this.DtLvlTres.Size = new System.Drawing.Size(346, 477);
            this.DtLvlTres.TabIndex = 2;
            // 
            // GestionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(86)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.GridPermisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionPermisos";
            this.Load += new System.EventHandler(this.GestionPermisos_Load);
            this.GridPermisos.Panel1.ResumeLayout(false);
            this.GridPermisos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridPermisos)).EndInit();
            this.GridPermisos.ResumeLayout(false);
            this.TCMain.ResumeLayout(false);
            this.TIBuscar.ResumeLayout(false);
            this.TIBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LvRol)).EndInit();
            this.TICrearRol.ResumeLayout(false);
            this.TICrearRol.PerformLayout();
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DTLvlUno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtLvlDos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtLvlTres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer GridPermisos;
        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.TabControl TCMain;
        public System.Windows.Forms.TabPage TIBuscar;
        private System.Windows.Forms.Label TbTituloGenerales;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.DataGridView LvRol;
        private System.Windows.Forms.Button BtnConfigurar;
        private System.Windows.Forms.TabPage TICrearRol;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardarRol;
        private System.Windows.Forms.Button BtnCancelarRol;
        public System.Windows.Forms.TextBox TxtNombrePermiso;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView DtLvlTres;
        public System.Windows.Forms.DataGridView DtLvlDos;
        public System.Windows.Forms.DataGridView DTLvlUno;
    }
}