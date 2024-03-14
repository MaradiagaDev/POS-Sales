namespace NeoCobranza.Paneles
{
    partial class PnlConfigInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlConfigInventario));
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.LblCargando = new System.Windows.Forms.Label();
            this.imgCargando = new System.Windows.Forms.PictureBox();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtInformativoUno = new System.Windows.Forms.TextBox();
            this.BtnRealizarConexiones = new NeoCobranza.Especiales.EspecialButton();
            this.TxtInformativoDos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBorrarInventario = new NeoCobranza.Especiales.EspecialButton();
            this.ChkInventario = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkInventarioNegativo = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnGuardarInformacion = new NeoCobranza.Especiales.EspecialButton();
            this.PnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTitulo
            // 
            this.PnlTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlTitulo.Controls.Add(this.LblCargando);
            this.PnlTitulo.Controls.Add(this.imgCargando);
            this.PnlTitulo.Controls.Add(this.TbTitulo);
            this.PnlTitulo.Location = new System.Drawing.Point(0, 479);
            this.PnlTitulo.Name = "PnlTitulo";
            this.PnlTitulo.Size = new System.Drawing.Size(1127, 44);
            this.PnlTitulo.TabIndex = 134;
            // 
            // LblCargando
            // 
            this.LblCargando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCargando.AutoSize = true;
            this.LblCargando.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCargando.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblCargando.Location = new System.Drawing.Point(977, 13);
            this.LblCargando.Name = "LblCargando";
            this.LblCargando.Size = new System.Drawing.Size(94, 19);
            this.LblCargando.TabIndex = 144;
            this.LblCargando.Text = "Cargando ";
            this.LblCargando.Visible = false;
            // 
            // imgCargando
            // 
            this.imgCargando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgCargando.Image = ((System.Drawing.Image)(resources.GetObject("imgCargando.Image")));
            this.imgCargando.Location = new System.Drawing.Point(1077, 5);
            this.imgCargando.Name = "imgCargando";
            this.imgCargando.Size = new System.Drawing.Size(40, 34);
            this.imgCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCargando.TabIndex = 144;
            this.imgCargando.TabStop = false;
            this.imgCargando.Visible = false;
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
            this.TbTitulo.Size = new System.Drawing.Size(390, 33);
            this.TbTitulo.TabIndex = 1;
            this.TbTitulo.Text = "Configuración de Inventario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(11, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 16);
            this.label7.TabIndex = 138;
            this.label7.Text = "Realizar Conexiones ";
            // 
            // TxtInformativoUno
            // 
            this.TxtInformativoUno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtInformativoUno.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInformativoUno.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TxtInformativoUno.Location = new System.Drawing.Point(16, 42);
            this.TxtInformativoUno.Multiline = true;
            this.TxtInformativoUno.Name = "TxtInformativoUno";
            this.TxtInformativoUno.ReadOnly = true;
            this.TxtInformativoUno.Size = new System.Drawing.Size(1086, 29);
            this.TxtInformativoUno.TabIndex = 140;
            this.TxtInformativoUno.Text = "Realizar Conexiones se trata de revisar que las conexiones entre productos, almac" +
    "enes e inventarios sean correctas o realizar si faltan algunas.";
            // 
            // BtnRealizarConexiones
            // 
            this.BtnRealizarConexiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnRealizarConexiones.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnRealizarConexiones.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnRealizarConexiones.BorderRadius = 5;
            this.BtnRealizarConexiones.BorderSize = 0;
            this.BtnRealizarConexiones.FlatAppearance.BorderSize = 0;
            this.BtnRealizarConexiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRealizarConexiones.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRealizarConexiones.ForeColor = System.Drawing.Color.White;
            this.BtnRealizarConexiones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRealizarConexiones.Location = new System.Drawing.Point(15, 76);
            this.BtnRealizarConexiones.Name = "BtnRealizarConexiones";
            this.BtnRealizarConexiones.Size = new System.Drawing.Size(185, 25);
            this.BtnRealizarConexiones.TabIndex = 137;
            this.BtnRealizarConexiones.Text = "Conexiones";
            this.BtnRealizarConexiones.TextGroundColor = System.Drawing.Color.White;
            this.BtnRealizarConexiones.UseVisualStyleBackColor = false;
            this.BtnRealizarConexiones.Click += new System.EventHandler(this.BtnRealizarConexiones_Click);
            // 
            // TxtInformativoDos
            // 
            this.TxtInformativoDos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtInformativoDos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInformativoDos.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TxtInformativoDos.Location = new System.Drawing.Point(18, 133);
            this.TxtInformativoDos.Multiline = true;
            this.TxtInformativoDos.Name = "TxtInformativoDos";
            this.TxtInformativoDos.ReadOnly = true;
            this.TxtInformativoDos.Size = new System.Drawing.Size(1086, 23);
            this.TxtInformativoDos.TabIndex = 142;
            this.TxtInformativoDos.Text = "Borrar todos los datos de inventario y dejar las cantidades en cero. Esta opción " +
    "no borra los productos registrados.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(15, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 141;
            this.label1.Text = "Borrar Inventario";
            // 
            // BtnBorrarInventario
            // 
            this.BtnBorrarInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnBorrarInventario.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnBorrarInventario.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnBorrarInventario.BorderRadius = 5;
            this.BtnBorrarInventario.BorderSize = 0;
            this.BtnBorrarInventario.FlatAppearance.BorderSize = 0;
            this.BtnBorrarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBorrarInventario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBorrarInventario.ForeColor = System.Drawing.Color.White;
            this.BtnBorrarInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBorrarInventario.Location = new System.Drawing.Point(17, 165);
            this.BtnBorrarInventario.Name = "BtnBorrarInventario";
            this.BtnBorrarInventario.Size = new System.Drawing.Size(182, 27);
            this.BtnBorrarInventario.TabIndex = 143;
            this.BtnBorrarInventario.Text = "Borrar";
            this.BtnBorrarInventario.TextGroundColor = System.Drawing.Color.White;
            this.BtnBorrarInventario.UseVisualStyleBackColor = false;
            this.BtnBorrarInventario.Click += new System.EventHandler(this.BtnBorrarInventario_Click);
            // 
            // ChkInventario
            // 
            this.ChkInventario.AutoSize = true;
            this.ChkInventario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkInventario.Location = new System.Drawing.Point(17, 267);
            this.ChkInventario.Name = "ChkInventario";
            this.ChkInventario.Size = new System.Drawing.Size(169, 21);
            this.ChkInventario.TabIndex = 149;
            this.ChkInventario.Text = "Trabajar Sin Inventario";
            this.ChkInventario.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox2.Location = new System.Drawing.Point(16, 237);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1086, 23);
            this.textBox2.TabIndex = 148;
            this.textBox2.Text = "Trabajar sin inventario indica que en la facturación no descontará el inventario " +
    "y no se tendrá acceso al módulo de inventario.\r\n\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(15, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(367, 16);
            this.label3.TabIndex = 147;
            this.label3.Text = "Trabajar Sin Inventario (Opción Individual de Sucursal)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ChkInventarioNegativo
            // 
            this.ChkInventarioNegativo.AutoSize = true;
            this.ChkInventarioNegativo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkInventarioNegativo.Location = new System.Drawing.Point(18, 355);
            this.ChkInventarioNegativo.Name = "ChkInventarioNegativo";
            this.ChkInventarioNegativo.Size = new System.Drawing.Size(209, 21);
            this.ChkInventarioNegativo.TabIndex = 152;
            this.ChkInventarioNegativo.Text = "Permitir Inventario Negativo";
            this.ChkInventarioNegativo.UseVisualStyleBackColor = true;
            this.ChkInventarioNegativo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox1.Location = new System.Drawing.Point(17, 325);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1086, 23);
            this.textBox1.TabIndex = 151;
            this.textBox1.Text = "Permitir el inventario negativo indica que se pueden hacer ventas sin tener exist" +
    "encias en inventario, asi como realizar ajustes que reduzcan el inventario.\r\n";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(16, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 16);
            this.label2.TabIndex = 150;
            this.label2.Text = "Permitir Inventario Negativo (Opción Individual de Sucursal)";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // BtnGuardarInformacion
            // 
            this.BtnGuardarInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardarInformacion.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.BtnGuardarInformacion.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnGuardarInformacion.BorderRadius = 5;
            this.BtnGuardarInformacion.BorderSize = 0;
            this.BtnGuardarInformacion.FlatAppearance.BorderSize = 0;
            this.BtnGuardarInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarInformacion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarInformacion.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarInformacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardarInformacion.Location = new System.Drawing.Point(16, 384);
            this.BtnGuardarInformacion.Name = "BtnGuardarInformacion";
            this.BtnGuardarInformacion.Size = new System.Drawing.Size(182, 27);
            this.BtnGuardarInformacion.TabIndex = 153;
            this.BtnGuardarInformacion.Text = "Guardar Configuración";
            this.BtnGuardarInformacion.TextGroundColor = System.Drawing.Color.White;
            this.BtnGuardarInformacion.UseVisualStyleBackColor = false;
            this.BtnGuardarInformacion.Click += new System.EventHandler(this.BtnGuardarInformacion_Click);
            // 
            // PnlConfigInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1125, 523);
            this.Controls.Add(this.BtnGuardarInformacion);
            this.Controls.Add(this.ChkInventarioNegativo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkInventario);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBorrarInventario);
            this.Controls.Add(this.TxtInformativoDos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtInformativoUno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnRealizarConexiones);
            this.Controls.Add(this.PnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlConfigInventario";
            this.Text = "PnlConfigInventario";
            this.Load += new System.EventHandler(this.PnlConfigInventario_Load);
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCargando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.Label TbTitulo;
        public Especiales.EspecialButton BtnRealizarConexiones;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtInformativoUno;
        private System.Windows.Forms.TextBox TxtInformativoDos;
        public System.Windows.Forms.Label label1;
        public Especiales.EspecialButton BtnBorrarInventario;
        public System.Windows.Forms.Label LblCargando;
        public System.Windows.Forms.PictureBox imgCargando;
        private System.Windows.Forms.CheckBox ChkInventario;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkInventarioNegativo;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label2;
        public Especiales.EspecialButton BtnGuardarInformacion;
    }
}