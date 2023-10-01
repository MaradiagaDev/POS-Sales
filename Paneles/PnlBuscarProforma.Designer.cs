namespace NeoCobranza.Paneles
{
    partial class PnlBuscarProforma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlBuscarProforma));
            this.label10 = new System.Windows.Forms.Label();
            this.DgvBusquedas = new System.Windows.Forms.DataGridView();
            this.especialButton2 = new NeoCobranza.Especiales.EspecialButton();
            this.especialButton1 = new NeoCobranza.Especiales.EspecialButton();
            this.btnActualizarProforma = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.txtFiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.label48 = new System.Windows.Forms.Label();
            this.llbTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(296, 24);
            this.label10.TabIndex = 86;
            this.label10.Text = "Digite informacion de la proforma: ";
            // 
            // DgvBusquedas
            // 
            this.DgvBusquedas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvBusquedas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvBusquedas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvBusquedas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvBusquedas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvBusquedas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvBusquedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBusquedas.Location = new System.Drawing.Point(27, 140);
            this.DgvBusquedas.MultiSelect = false;
            this.DgvBusquedas.Name = "DgvBusquedas";
            this.DgvBusquedas.ReadOnly = true;
            this.DgvBusquedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBusquedas.Size = new System.Drawing.Size(1102, 349);
            this.DgvBusquedas.TabIndex = 87;
            // 
            // especialButton2
            // 
            this.especialButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.especialButton2.Location = new System.Drawing.Point(57, 545);
            this.especialButton2.Name = "especialButton2";
            this.especialButton2.Size = new System.Drawing.Size(214, 41);
            this.especialButton2.TabIndex = 90;
            this.especialButton2.Text = "Eliminar ";
            this.especialButton2.TextGroundColor = System.Drawing.Color.White;
            this.especialButton2.UseVisualStyleBackColor = false;
            this.especialButton2.Click += new System.EventHandler(this.especialButton2_Click);
            // 
            // especialButton1
            // 
            this.especialButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.especialButton1.BackColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.especialButton1.BorderColor = System.Drawing.Color.LimeGreen;
            this.especialButton1.BorderRadius = 15;
            this.especialButton1.BorderSize = 0;
            this.especialButton1.FlatAppearance.BorderSize = 0;
            this.especialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.especialButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialButton1.ForeColor = System.Drawing.Color.White;
            this.especialButton1.Image = ((System.Drawing.Image)(resources.GetObject("especialButton1.Image")));
            this.especialButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.especialButton1.Location = new System.Drawing.Point(929, 545);
            this.especialButton1.Name = "especialButton1";
            this.especialButton1.Size = new System.Drawing.Size(216, 41);
            this.especialButton1.TabIndex = 88;
            this.especialButton1.Text = "Generar Reporte";
            this.especialButton1.TextGroundColor = System.Drawing.Color.White;
            this.especialButton1.UseVisualStyleBackColor = false;
            this.especialButton1.Click += new System.EventHandler(this.especialButton1_Click);
            // 
            // btnActualizarProforma
            // 
            this.btnActualizarProforma.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.btnActualizarProforma.Location = new System.Drawing.Point(696, 545);
            this.btnActualizarProforma.Name = "btnActualizarProforma";
            this.btnActualizarProforma.Size = new System.Drawing.Size(214, 41);
            this.btnActualizarProforma.TabIndex = 89;
            this.btnActualizarProforma.Text = "Actualizar Proforma";
            this.btnActualizarProforma.TextGroundColor = System.Drawing.Color.White;
            this.btnActualizarProforma.UseVisualStyleBackColor = false;
            this.btnActualizarProforma.Click += new System.EventHandler(this.btnActualizarProforma_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 15;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(502, 545);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 41);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtFiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtFiltro.BorderRadius = 0;
            this.txtFiltro.BorderSize = 2;
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtFiltro.Location = new System.Drawing.Point(17, 82);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Multilinea = false;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFiltro.PasswordChar = false;
            this.txtFiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.PlaceHolderText = "Buscar Proforma";
            this.txtFiltro.Size = new System.Drawing.Size(1112, 35);
            this.txtFiltro.TabIndex = 6;
            this.txtFiltro.Texts = "";
            this.txtFiltro.UnderLineFlat = true;
            this.txtFiltro._TextChanged += new System.EventHandler(this.txtFiltro__TextChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label48.Location = new System.Drawing.Point(5, 23);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(287, 16);
            this.label48.TabIndex = 222;
            this.label48.Text = "________________________________________";
            // 
            // llbTitulo
            // 
            this.llbTitulo.AutoSize = true;
            this.llbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llbTitulo.Location = new System.Drawing.Point(3, -1);
            this.llbTitulo.Name = "llbTitulo";
            this.llbTitulo.Size = new System.Drawing.Size(259, 25);
            this.llbTitulo.TabIndex = 221;
            this.llbTitulo.Text = "Buscar proforma de venta";
            // 
            // PnlBuscarProforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.llbTitulo);
            this.Controls.Add(this.especialButton2);
            this.Controls.Add(this.especialButton1);
            this.Controls.Add(this.btnActualizarProforma);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.DgvBusquedas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlBuscarProforma";
            this.Text = "PnlBuscarProforma";
            this.Load += new System.EventHandler(this.PnlBuscarProforma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controladores.LoginUserControl txtFiltro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView DgvBusquedas;
        private Especiales.EspecialButton especialButton1;
        private Especiales.EspecialButton btnCancelar;
        private Especiales.EspecialButton especialButton2;
        private System.Windows.Forms.Label label48;
        public System.Windows.Forms.Label llbTitulo;
        public Especiales.EspecialButton btnActualizarProforma;
    }
}