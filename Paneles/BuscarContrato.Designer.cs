namespace NeoCobranza.Paneles
{
    partial class BuscarContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarContrato));
            this.dagvContrato = new System.Windows.Forms.DataGridView();
            this.btnActualizarProforma = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.btnGenerarProforma = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.especialButton2 = new NeoCobranza.Especiales.EspecialButton();
            this.label13 = new System.Windows.Forms.Label();
            this.llbTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dagvContrato)).BeginInit();
            this.SuspendLayout();
            // 
            // dagvContrato
            // 
            this.dagvContrato.AllowUserToAddRows = false;
            this.dagvContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dagvContrato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dagvContrato.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dagvContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dagvContrato.Location = new System.Drawing.Point(12, 109);
            this.dagvContrato.MultiSelect = false;
            this.dagvContrato.Name = "dagvContrato";
            this.dagvContrato.ReadOnly = true;
            this.dagvContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dagvContrato.Size = new System.Drawing.Size(1130, 423);
            this.dagvContrato.TabIndex = 7;
            // 
            // btnActualizarProforma
            // 
            this.btnActualizarProforma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarProforma.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActualizarProforma.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnActualizarProforma.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnActualizarProforma.BorderRadius = 15;
            this.btnActualizarProforma.BorderSize = 0;
            this.btnActualizarProforma.FlatAppearance.BorderSize = 0;
            this.btnActualizarProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarProforma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarProforma.ForeColor = System.Drawing.Color.White;
            this.btnActualizarProforma.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarProforma.Image")));
            this.btnActualizarProforma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarProforma.Location = new System.Drawing.Point(692, 540);
            this.btnActualizarProforma.Name = "btnActualizarProforma";
            this.btnActualizarProforma.Size = new System.Drawing.Size(222, 49);
            this.btnActualizarProforma.TabIndex = 89;
            this.btnActualizarProforma.Text = "Actualizar ";
            this.btnActualizarProforma.TextGroundColor = System.Drawing.Color.White;
            this.btnActualizarProforma.UseVisualStyleBackColor = false;
            this.btnActualizarProforma.Click += new System.EventHandler(this.btnActualizarProforma_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 15;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(539, 540);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 49);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGenerarProforma
            // 
            this.btnGenerarProforma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarProforma.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGenerarProforma.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnGenerarProforma.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnGenerarProforma.BorderRadius = 15;
            this.btnGenerarProforma.BorderSize = 0;
            this.btnGenerarProforma.FlatAppearance.BorderSize = 0;
            this.btnGenerarProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarProforma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarProforma.ForeColor = System.Drawing.Color.White;
            this.btnGenerarProforma.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarProforma.Image")));
            this.btnGenerarProforma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarProforma.Location = new System.Drawing.Point(922, 540);
            this.btnGenerarProforma.Name = "btnGenerarProforma";
            this.btnGenerarProforma.Size = new System.Drawing.Size(220, 49);
            this.btnGenerarProforma.TabIndex = 88;
            this.btnGenerarProforma.Text = "Generar ";
            this.btnGenerarProforma.TextGroundColor = System.Drawing.Color.White;
            this.btnGenerarProforma.UseVisualStyleBackColor = false;
            this.btnGenerarProforma.Click += new System.EventHandler(this.btnGenerarProforma_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltro.BorderRadius = 0;
            this.txtFiltro.BorderSize = 2;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltro.Location = new System.Drawing.Point(15, 63);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar Proforma";
            this.txtFiltro.Size = new System.Drawing.Size(718, 39);
            this.txtFiltro.TabIndex = 8;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
            // 
            // especialButton2
            // 
            this.especialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.especialButton2.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton2.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.especialButton2.BorderRadius = 15;
            this.especialButton2.BorderSize = 0;
            this.especialButton2.FlatAppearance.BorderSize = 0;
            this.especialButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton2.ForeColor = System.Drawing.Color.White;
            this.especialButton2.Image = ((System.Drawing.Image)(resources.GetObject("especialButton2.Image")));
            this.especialButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton2.Location = new System.Drawing.Point(15, 548);
            this.especialButton2.Name = "especialButton2";
            this.especialButton2.Size = new System.Drawing.Size(214, 41);
            this.especialButton2.TabIndex = 91;
            this.especialButton2.Text = "Eliminar ";
            this.especialButton2.TextGroundColor = System.Drawing.Color.White;
            this.especialButton2.UseVisualStyleBackColor = false;
            this.especialButton2.Click += new System.EventHandler(this.especialButton2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(9, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(287, 16);
            this.label13.TabIndex = 152;
            this.label13.Text = "________________________________________";
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llbTitulo.Location = new System.Drawing.Point(7, 9);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(290, 25);
            this.llbTitulo.TabIndex = 151;
            this.llbTitulo.Text = "Buscar Proforma de Contrato";
            // 
            // BuscarContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.llbTitulo);
            this.Controls.Add(this.especialButton2);
            this.Controls.Add(this.btnGenerarProforma);
            this.Controls.Add(this.btnActualizarProforma);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dagvContrato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarContrato";
            this.Text = "BuscarContrato";
            this.Load += new System.EventHandler(this.BuscarContrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dagvContrato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dagvContrato;
        private Controladores.LoginUserControl txtFiltro;
        private Especiales.EspecialButton btnActualizarProforma;
        private Especiales.EspecialButton btnCancelar;
        private Especiales.EspecialButton btnGenerarProforma;
        private Especiales.EspecialButton especialButton2;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label llbTitulo;
    }
}