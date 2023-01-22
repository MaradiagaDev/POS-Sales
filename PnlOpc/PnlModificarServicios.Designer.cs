namespace NeoCobranza.PnlOpc
{
    partial class PnlModificarServicios
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvBusquedas = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.PnlVer = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.Me2 = new System.Windows.Forms.PictureBox();
            this.PnlImagenes = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.Me = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnGuardarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.BtnSeleccionarImagen = new NeoCobranza.Especiales.EspecialButton();
            this.txtfiltro = new NeoCobranza.Controladores.LoginUserControl();
            this.BtnAdd = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).BeginInit();
            this.PnlInfo.SuspendLayout();
            this.PnlVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Me2)).BeginInit();
            this.PnlImagenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Me)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1155, 31);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Modificaciones de Servicios ";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.Controls.Add(this.BtnAdd);
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Location = new System.Drawing.Point(2, 565);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1155, 35);
            this.panel5.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(65, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 18);
            this.label1.TabIndex = 80;
            this.label1.Text = "Seleccion de servicio para modificar:";
            // 
            // DgvBusquedas
            // 
            this.DgvBusquedas.AllowUserToAddRows = false;
            this.DgvBusquedas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvBusquedas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvBusquedas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvBusquedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBusquedas.Location = new System.Drawing.Point(47, 160);
            this.DgvBusquedas.Name = "DgvBusquedas";
            this.DgvBusquedas.ReadOnly = true;
            this.DgvBusquedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBusquedas.Size = new System.Drawing.Size(514, 248);
            this.DgvBusquedas.TabIndex = 79;
            this.DgvBusquedas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBusquedas_CellContentClick);
            this.DgvBusquedas.SelectionChanged += new System.EventHandler(this.DgvBusquedas_SelectionChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cambio de Estado",
            "Actualizar Datos",
            "Actualizar imagen",
            "Ver imagen"});
            this.comboBox1.Location = new System.Drawing.Point(236, 482);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 21);
            this.comboBox1.TabIndex = 82;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Seleccione la modificacion:";
            // 
            // PnlInfo
            // 
            this.PnlInfo.Controls.Add(this.txtDescripcion);
            this.PnlInfo.Controls.Add(this.txtNombre);
            this.PnlInfo.Controls.Add(this.txtId);
            this.PnlInfo.Controls.Add(this.label7);
            this.PnlInfo.Controls.Add(this.label6);
            this.PnlInfo.Controls.Add(this.label4);
            this.PnlInfo.Controls.Add(this.lblTitulo);
            this.PnlInfo.Location = new System.Drawing.Point(465, 431);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(653, 115);
            this.PnlInfo.TabIndex = 84;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(430, 42);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(211, 49);
            this.txtDescripcion.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(102, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(182, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(616, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(11, 16);
            this.txtId.TabIndex = 5;
            this.txtId.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(582, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Id :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(326, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Descripcion :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre :";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label4";
            // 
            // PnlVer
            // 
            this.PnlVer.Controls.Add(this.label8);
            this.PnlVer.Controls.Add(this.Me2);
            this.PnlVer.Location = new System.Drawing.Point(576, 81);
            this.PnlVer.Name = "PnlVer";
            this.PnlVer.Size = new System.Drawing.Size(226, 249);
            this.PnlVer.TabIndex = 95;
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
            // 
            // Me2
            // 
            this.Me2.Location = new System.Drawing.Point(11, 47);
            this.Me2.Name = "Me2";
            this.Me2.Size = new System.Drawing.Size(208, 177);
            this.Me2.TabIndex = 91;
            this.Me2.TabStop = false;
            // 
            // PnlImagenes
            // 
            this.PnlImagenes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PnlImagenes.Controls.Add(this.label9);
            this.PnlImagenes.Controls.Add(this.Me);
            this.PnlImagenes.Controls.Add(this.label10);
            this.PnlImagenes.Controls.Add(this.BtnGuardarImagen);
            this.PnlImagenes.Controls.Add(this.BtnSeleccionarImagen);
            this.PnlImagenes.Location = new System.Drawing.Point(817, 42);
            this.PnlImagenes.Name = "PnlImagenes";
            this.PnlImagenes.Size = new System.Drawing.Size(331, 355);
            this.PnlImagenes.TabIndex = 94;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label9.Location = new System.Drawing.Point(46, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "Nueva imagen";
            // 
            // Me
            // 
            this.Me.Location = new System.Drawing.Point(21, 56);
            this.Me.Name = "Me";
            this.Me.Size = new System.Drawing.Size(292, 243);
            this.Me.TabIndex = 90;
            this.Me.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(18, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 18);
            this.label10.TabIndex = 89;
            this.label10.Text = "Modificaciones de imagen:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.BtnGuardarImagen.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarImagen.Location = new System.Drawing.Point(172, 305);
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
            this.BtnSeleccionarImagen.ForeColor = System.Drawing.Color.White;
            this.BtnSeleccionarImagen.Location = new System.Drawing.Point(49, 305);
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
            this.txtfiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfiltro.ForeColor = System.Drawing.Color.DimGray;
            this.txtfiltro.Location = new System.Drawing.Point(21, 122);
            this.txtfiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtfiltro.Multilinea = false;
            this.txtfiltro.Name = "txtfiltro";
            this.txtfiltro.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfiltro.PasswordChar = false;
            this.txtfiltro.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtfiltro.PlaceHolderText = "Buscar Servicio..";
            this.txtfiltro.Size = new System.Drawing.Size(512, 31);
            this.txtfiltro.TabIndex = 78;
            this.txtfiltro.Texts = "";
            this.txtfiltro.UnderLineFlat = true;
            this.txtfiltro._TextChanged += new System.EventHandler(this.txtfiltro__TextChanged);
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
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(1029, 0);
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
            this.btnCancelar.BorderRadius = 40;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(900, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // PnlModificarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1157, 601);
            this.Controls.Add(this.PnlVer);
            this.Controls.Add(this.PnlImagenes);
            this.Controls.Add(this.PnlInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvBusquedas);
            this.Controls.Add(this.txtfiltro);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlModificarServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlModificarServicios";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBusquedas)).EndInit();
            this.PnlInfo.ResumeLayout(false);
            this.PnlInfo.PerformLayout();
            this.PnlVer.ResumeLayout(false);
            this.PnlVer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Me2)).EndInit();
            this.PnlImagenes.ResumeLayout(false);
            this.PnlImagenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Me)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private Especiales.EspecialButton BtnAdd;
        private Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvBusquedas;
        private Controladores.LoginUserControl txtfiltro;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PnlVer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox Me2;
        private System.Windows.Forms.Panel PnlImagenes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox Me;
        private System.Windows.Forms.Label label10;
        private Especiales.EspecialButton BtnGuardarImagen;
        private Especiales.EspecialButton BtnSeleccionarImagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}