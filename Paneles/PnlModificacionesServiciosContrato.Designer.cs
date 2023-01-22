namespace NeoCobranza.Paneles
{
    partial class PnlModificacionesServiciosContrato
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvBusquedas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.PnlImagenes = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Me = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Me2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PnlVer = new System.Windows.Forms.Panel();
            this.BtnAdd = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.BtnGuardarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.BtnSeleccionarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.txtfiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).BeginInit();
            this.PnlInfo.SuspendLayout();
            this.PnlImagenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Me)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Me2)).BeginInit();
            this.PnlVer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1155, 31);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Modificaciones de Tipo de Producto";
            // 
            // DgvBusquedas
            // 
            this.DgvBusquedas.AllowUserToAddRows = false;
            this.DgvBusquedas.AllowUserToDeleteRows = false;
            this.DgvBusquedas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvBusquedas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvBusquedas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvBusquedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBusquedas.Location = new System.Drawing.Point(12, 122);
            this.DgvBusquedas.MultiSelect = false;
            this.DgvBusquedas.Name = "DgvBusquedas";
            this.DgvBusquedas.ReadOnly = true;
            this.DgvBusquedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBusquedas.Size = new System.Drawing.Size(526, 248);
            this.DgvBusquedas.TabIndex = 81;
            this.DgvBusquedas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBusquedas_CellContentClick);
            this.DgvBusquedas.SelectionChanged += new System.EventHandler(this.DgvBusquedas_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(28, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 85;
            this.label2.Text = "Seleccione la modificacion:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cambio de Estado",
            "Actualizar Datos",
            "Actualizar Imagenes",
            "Ver Imagenes"});
            this.comboBox1.Location = new System.Drawing.Point(233, 448);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 24);
            this.comboBox1.TabIndex = 84;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PnlInfo
            // 
            this.PnlInfo.Controls.Add(this.txtDescripcion);
            this.PnlInfo.Controls.Add(this.txtNombre);
            this.PnlInfo.Controls.Add(this.txtId);
            this.PnlInfo.Controls.Add(this.label7);
            this.PnlInfo.Controls.Add(this.label5);
            this.PnlInfo.Controls.Add(this.label4);
            this.PnlInfo.Controls.Add(this.lblTitulo);
            this.PnlInfo.Location = new System.Drawing.Point(504, 398);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(603, 132);
            this.PnlInfo.TabIndex = 86;
            this.PnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlInfo_Paint);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(119, 85);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(425, 33);
            this.txtDescripcion.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(119, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 26);
            this.txtNombre.TabIndex = 6;
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(528, 49);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(13, 20);
            this.txtId.TabIndex = 5;
            this.txtId.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(491, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Id :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Descripcion :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre :";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTitulo.Location = new System.Drawing.Point(16, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label4";
            // 
            // PnlImagenes
            // 
            this.PnlImagenes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PnlImagenes.Controls.Add(this.label6);
            this.PnlImagenes.Controls.Add(this.Me);
            this.PnlImagenes.Controls.Add(this.label1);
            this.PnlImagenes.Controls.Add(this.BtnGuardarImagen);
            this.PnlImagenes.Controls.Add(this.BtnSeleccionarImagen);
            this.PnlImagenes.Location = new System.Drawing.Point(798, 37);
            this.PnlImagenes.Name = "PnlImagenes";
            this.PnlImagenes.Size = new System.Drawing.Size(331, 355);
            this.PnlImagenes.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Location = new System.Drawing.Point(112, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nueva imagen";
            // 
            // Me
            // 
            this.Me.Location = new System.Drawing.Point(21, 56);
            this.Me.Name = "Me";
            this.Me.Size = new System.Drawing.Size(292, 243);
            this.Me.TabIndex = 90;
            this.Me.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(60, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 89;
            this.label1.Text = "Modificaciones de imagen:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Me2
            // 
            this.Me2.Location = new System.Drawing.Point(11, 47);
            this.Me2.Name = "Me2";
            this.Me2.Size = new System.Drawing.Size(208, 177);
            this.Me2.TabIndex = 91;
            this.Me2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Location = new System.Drawing.Point(58, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 18);
            this.label8.TabIndex = 92;
            this.label8.Text = "Imagen Actual";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // PnlVer
            // 
            this.PnlVer.Controls.Add(this.label8);
            this.PnlVer.Controls.Add(this.Me2);
            this.PnlVer.Location = new System.Drawing.Point(544, 93);
            this.PnlVer.Name = "PnlVer";
            this.PnlVer.Size = new System.Drawing.Size(244, 249);
            this.PnlVer.TabIndex = 93;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BtnAdd.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAdd.BackGroundColor = System.Drawing.SystemColors.HotTrack;
            this.BtnAdd.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnAdd.BorderRadius = 20;
            this.BtnAdd.BorderSize = 2;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(1018, 557);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(111, 32);
            this.BtnAdd.TabIndex = 77;
            this.BtnAdd.Text = "Aceptar";
            this.BtnAdd.TextGroundColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 20;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(881, 557);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnGuardarImagen
            // 
            this.BtnGuardarImagen.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnGuardarImagen.BackGroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnGuardarImagen.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnGuardarImagen.BorderRadius = 40;
            this.BtnGuardarImagen.BorderSize = 0;
            this.BtnGuardarImagen.FlatAppearance.BorderSize = 0;
            this.BtnGuardarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarImagen.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarImagen.Location = new System.Drawing.Point(189, 305);
            this.BtnGuardarImagen.Name = "BtnGuardarImagen";
            this.BtnGuardarImagen.Size = new System.Drawing.Size(120, 28);
            this.BtnGuardarImagen.TabIndex = 1;
            this.BtnGuardarImagen.Text = "Guardar imagen";
            this.BtnGuardarImagen.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardarImagen.UseVisualStyleBackColor = false;
            this.BtnGuardarImagen.Click += new System.EventHandler(this.BtnGuardarImagen_Click);
            // 
            // BtnSeleccionarImagen
            // 
            this.BtnSeleccionarImagen.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSeleccionarImagen.BackGroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSeleccionarImagen.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSeleccionarImagen.BorderRadius = 40;
            this.BtnSeleccionarImagen.BorderSize = 0;
            this.BtnSeleccionarImagen.FlatAppearance.BorderSize = 0;
            this.BtnSeleccionarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSeleccionarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSeleccionarImagen.ForeColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.Location = new System.Drawing.Point(31, 305);
            this.BtnSeleccionarImagen.Name = "BtnSeleccionarImagen";
            this.BtnSeleccionarImagen.Size = new System.Drawing.Size(117, 28);
            this.BtnSeleccionarImagen.TabIndex = 0;
            this.BtnSeleccionarImagen.Text = "Seleccionar imagen";
            this.BtnSeleccionarImagen.TextGroundColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.UseVisualStyleBackColor = false;
            this.BtnSeleccionarImagen.Click += new System.EventHandler(this.BtnSeleccionarImagen_Click);
            // 
            // txtfiltro
            // 
            this.txtfiltro.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtfiltro.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtfiltro.BorderRadius = 0;
            this.txtfiltro.BorderSize = 2;
            this.txtfiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtfiltro.Location = new System.Drawing.Point(16, 72);
            this.txtfiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtfiltro.Multilinea = false;
            this.txtfiltro.Name = "txtfiltro";
            this.txtfiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfiltro.PasswordChar = false;
            this.txtfiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtfiltro.PlaceHolderText = "Buscar Tipo de Producto..";
            this.txtfiltro.Size = new System.Drawing.Size(420, 39);
            this.txtfiltro.TabIndex = 80;
            this.txtfiltro.Texts = "";
            this.txtfiltro.UnderLineFlat = true;
            this.txtfiltro._TextChanged += new System.EventHandler(this.txtfiltro__TextChanged);
            // 
            // PnlModificacionesServiciosContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1141, 601);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.PnlVer);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.PnlImagenes);
            this.Controls.Add(this.PnlInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DgvBusquedas);
            this.Controls.Add(this.txtfiltro);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlModificacionesServiciosContrato";
            this.Text = "PnlModificacionesServiciosContrato";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).EndInit();
            this.PnlInfo.ResumeLayout(false);
            this.PnlInfo.PerformLayout();
            this.PnlImagenes.ResumeLayout(false);
            this.PnlImagenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Me)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Me2)).EndInit();
            this.PnlVer.ResumeLayout(false);
            this.PnlVer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvBusquedas;
        private Controladores.LoginUserControl txtfiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitulo;
        private Especiales.EspecialButton BtnAdd;
        private Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Panel PnlImagenes;
        private System.Windows.Forms.Label label1;
        private Especiales.EspecialButton BtnGuardarImagen;
        private Especiales.EspecialButton BtnSeleccionarImagen;
        private System.Windows.Forms.PictureBox Me;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox Me2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PnlVer;
    }
}