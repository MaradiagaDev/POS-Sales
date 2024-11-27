namespace NeoCobranza.Paneles
{
    partial class PnlAgregarAlmacen
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
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblDynamico = new System.Windows.Forms.Label();
            this.ChkAlmacenMostrador = new System.Windows.Forms.CheckBox();
            this.ChkAsignarSucursal = new System.Windows.Forms.CheckBox();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtNombre.Location = new System.Drawing.Point(22, 99);
            this.TxtNombre.MaxLength = 100;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(392, 23);
            this.TxtNombre.TabIndex = 89;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(18, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "Nombre del  Almacén";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.LblDynamico);
            this.panel3.Location = new System.Drawing.Point(-5, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 33);
            this.panel3.TabIndex = 86;
            // 
            // LblDynamico
            // 
            this.LblDynamico.AutoSize = true;
            this.LblDynamico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDynamico.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblDynamico.Location = new System.Drawing.Point(22, 9);
            this.LblDynamico.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.LblDynamico.Name = "LblDynamico";
            this.LblDynamico.Size = new System.Drawing.Size(76, 18);
            this.LblDynamico.TabIndex = 1;
            this.LblDynamico.Text = "Almacén";
            // 
            // ChkAlmacenMostrador
            // 
            this.ChkAlmacenMostrador.AutoSize = true;
            this.ChkAlmacenMostrador.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.ChkAlmacenMostrador.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ChkAlmacenMostrador.Location = new System.Drawing.Point(21, 185);
            this.ChkAlmacenMostrador.Name = "ChkAlmacenMostrador";
            this.ChkAlmacenMostrador.Size = new System.Drawing.Size(173, 22);
            this.ChkAlmacenMostrador.TabIndex = 91;
            this.ChkAlmacenMostrador.Text = "Almacén Mostrador";
            this.ChkAlmacenMostrador.UseVisualStyleBackColor = true;
            // 
            // ChkAsignarSucursal
            // 
            this.ChkAsignarSucursal.AutoSize = true;
            this.ChkAsignarSucursal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.ChkAsignarSucursal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ChkAsignarSucursal.Location = new System.Drawing.Point(22, 140);
            this.ChkAsignarSucursal.Name = "ChkAsignarSucursal";
            this.ChkAsignarSucursal.Size = new System.Drawing.Size(231, 22);
            this.ChkAsignarSucursal.TabIndex = 92;
            this.ChkAsignarSucursal.Text = "Asignar a la Sucursal Actual";
            this.ChkAsignarSucursal.UseVisualStyleBackColor = true;
            this.ChkAsignarSucursal.Click += new System.EventHandler(this.ChkAsignarSucursal_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.btnAgregar.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(186)))));
            this.btnAgregar.BorderColor = System.Drawing.Color.Lime;
            this.btnAgregar.BorderRadius = 5;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(879, 563);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(173, 35);
            this.btnAgregar.TabIndex = 87;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextGroundColor = System.Drawing.Color.White;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BackGroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.BorderRadius = 5;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(696, 563);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 35);
            this.btnCancelar.TabIndex = 88;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TxtDireccion.Location = new System.Drawing.Point(20, 258);
            this.TxtDireccion.MaxLength = 100;
            this.TxtDireccion.Multiline = true;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(481, 158);
            this.TxtDireccion.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(18, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 94;
            this.label1.Text = "Dirección";
            // 
            // PnlAgregarAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1056, 600);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkAsignarSucursal);
            this.Controls.Add(this.ChkAlmacenMostrador);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel3);
            this.MaximumSize = new System.Drawing.Size(1072, 639);
            this.MinimumSize = new System.Drawing.Size(1072, 639);
            this.Name = "PnlAgregarAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Almacén";
            this.Load += new System.EventHandler(this.PnlAgregarAlmacen_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TxtNombre;
        public System.Windows.Forms.Label label7;
        public Especiales.EspecialButton btnAgregar;
        public Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label LblDynamico;
        private System.Windows.Forms.CheckBox ChkAlmacenMostrador;
        private System.Windows.Forms.CheckBox ChkAsignarSucursal;
        public System.Windows.Forms.TextBox TxtDireccion;
        public System.Windows.Forms.Label label1;
    }
}