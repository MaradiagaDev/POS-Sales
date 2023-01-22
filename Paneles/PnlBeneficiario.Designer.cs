namespace NeoCobranza.Paneles
{
    partial class PnlBeneficiario
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
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSexo = new System.Windows.Forms.Label();
            this.rbtnMasculino = new System.Windows.Forms.RadioButton();
            this.rbtnFemenino = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAtaudes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCedula = new System.Windows.Forms.MaskedTextBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.txtObservaciones = new NeoCobranza.Controladores.LoginUserControl();
            this.txtDireccion = new NeoCobranza.Controladores.LoginUserControl();
            this.lblProfesion = new NeoCobranza.Controladores.LoginUserControl();
            this.lblSA = new NeoCobranza.Controladores.LoginUserControl();
            this.lblPA = new NeoCobranza.Controladores.LoginUserControl();
            this.lblSN = new NeoCobranza.Controladores.LoginUserControl();
            this.lblPn = new NeoCobranza.Controladores.LoginUserControl();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Direccion ";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblSexo);
            this.flowLayoutPanel3.Controls.Add(this.rbtnMasculino);
            this.flowLayoutPanel3.Controls.Add(this.rbtnFemenino);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(524, 28);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(136, 94);
            this.flowLayoutPanel3.TabIndex = 39;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(3, 0);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(45, 20);
            this.lblSexo.TabIndex = 0;
            this.lblSexo.Text = "Sexo";
            // 
            // rbtnMasculino
            // 
            this.rbtnMasculino.AutoSize = true;
            this.rbtnMasculino.Location = new System.Drawing.Point(3, 23);
            this.rbtnMasculino.Name = "rbtnMasculino";
            this.rbtnMasculino.Size = new System.Drawing.Size(98, 24);
            this.rbtnMasculino.TabIndex = 17;
            this.rbtnMasculino.TabStop = true;
            this.rbtnMasculino.Text = "Masculino";
            this.rbtnMasculino.UseVisualStyleBackColor = true;
            // 
            // rbtnFemenino
            // 
            this.rbtnFemenino.AutoSize = true;
            this.rbtnFemenino.Location = new System.Drawing.Point(3, 53);
            this.rbtnFemenino.Name = "rbtnFemenino";
            this.rbtnFemenino.Size = new System.Drawing.Size(98, 24);
            this.rbtnFemenino.TabIndex = 18;
            this.rbtnFemenino.TabStop = true;
            this.rbtnFemenino.Text = "Femenino";
            this.rbtnFemenino.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = " Informacion del Beneficiario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(457, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Observaciones ";
            // 
            // cmbAtaudes
            // 
            this.cmbAtaudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtaudes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAtaudes.FormattingEnabled = true;
            this.cmbAtaudes.Location = new System.Drawing.Point(461, 327);
            this.cmbAtaudes.Name = "cmbAtaudes";
            this.cmbAtaudes.Size = new System.Drawing.Size(199, 28);
            this.cmbAtaudes.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(457, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "Servicio del Beneficiario ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(233, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 60;
            this.label11.Text = "Profesion:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(6, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 59;
            this.label10.Text = "Cedula:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(233, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "Segundo Apellido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(6, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 57;
            this.label8.Text = "Primer Apellido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(233, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "Segundo Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(6, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Primer Nombre:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.lblFecha);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(685, 36);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(178, 74);
            this.flowLayoutPanel2.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha de Nacimiento";
            // 
            // lblFecha
            // 
            this.lblFecha.CustomFormat = "dd-MM-yyyy";
            this.lblFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lblFecha.Location = new System.Drawing.Point(3, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(160, 26);
            this.lblFecha.TabIndex = 16;
            // 
            // lblCedula
            // 
            this.lblCedula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(29, 222);
            this.lblCedula.Mask = "000-000000-0000L";
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(182, 19);
            this.lblCedula.TabIndex = 65;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Items.AddRange(new object[] {
            "Boaco (Boaco)",
            "Carazo (Jinotepe)",
            "Chinandega (Chinandega)",
            "Chontales (Juigalpa)",
            "Esteli (Esteli)",
            "Granada (Granada)",
            "Jinotega (Jinotega)",
            "Leon (Leon)",
            "Madriz (Somoto)",
            "Managua (Managua)",
            "Masaya (Masaya)",
            "Matagalpa (Matagalpa)",
            "Nueva Segovia (Ocotal)",
            "Rio San Juan (San Carlos)",
            "Rivas (Rivas)",
            "Region Autónoma del Atlantico Norte (Puerto Cabezas)",
            "Region Autónoma del Atlantico Sur (Bluefields)"});
            this.cmbDepartamento.Location = new System.Drawing.Point(163, 270);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(180, 28);
            this.cmbDepartamento.TabIndex = 48;
            this.cmbDepartamento.Text = "Departamento";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(28, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 20);
            this.label15.TabIndex = 61;
            this.label15.Text = "Departamento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(643, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 66;
            this.label12.Text = "(Obligatorio)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(72, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 20);
            this.label13.TabIndex = 67;
            this.label13.Text = "(Obligatorio)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(119, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 20);
            this.label14.TabIndex = 68;
            this.label14.Text = "(Obligatorio)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label16.Location = new System.Drawing.Point(119, 117);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 20);
            this.label16.TabIndex = 69;
            this.label16.Text = "(Obligatorio)";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAgregar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.BackGroundColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.BorderColor = System.Drawing.Color.Lime;
            this.btnAgregar.BorderRadius = 10;
            this.btnAgregar.BorderSize = 2;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(720, 414);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(189, 40);
            this.btnAgregar.TabIndex = 19;
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
            this.btnCancelar.BorderRadius = 10;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(523, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(191, 42);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtObservaciones.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtObservaciones.BorderRadius = 10;
            this.txtObservaciones.BorderSize = 2;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.DimGray;
            this.txtObservaciones.Location = new System.Drawing.Point(453, 193);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservaciones.Multilinea = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtObservaciones.PasswordChar = false;
            this.txtObservaciones.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtObservaciones.PlaceHolderText = "Observaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(456, 73);
            this.txtObservaciones.TabIndex = 63;
            this.txtObservaciones.Texts = "";
            this.txtObservaciones.UnderLineFlat = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtDireccion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDireccion.BorderRadius = 10;
            this.txtDireccion.BorderSize = 2;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDireccion.Location = new System.Drawing.Point(29, 363);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Multilinea = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDireccion.PasswordChar = false;
            this.txtDireccion.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtDireccion.PlaceHolderText = "Direccion";
            this.txtDireccion.Size = new System.Drawing.Size(365, 67);
            this.txtDireccion.TabIndex = 62;
            this.txtDireccion.Texts = "";
            this.txtDireccion.UnderLineFlat = false;
            // 
            // lblProfesion
            // 
            this.lblProfesion.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblProfesion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblProfesion.BorderRadius = 0;
            this.lblProfesion.BorderSize = 2;
            this.lblProfesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesion.ForeColor = System.Drawing.Color.DimGray;
            this.lblProfesion.Location = new System.Drawing.Point(236, 206);
            this.lblProfesion.Margin = new System.Windows.Forms.Padding(4);
            this.lblProfesion.Multilinea = false;
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblProfesion.PasswordChar = false;
            this.lblProfesion.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblProfesion.PlaceHolderText = "Profesion";
            this.lblProfesion.Size = new System.Drawing.Size(182, 35);
            this.lblProfesion.TabIndex = 54;
            this.lblProfesion.Texts = "";
            this.lblProfesion.UnderLineFlat = true;
            // 
            // lblSA
            // 
            this.lblSA.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblSA.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblSA.BorderRadius = 0;
            this.lblSA.BorderSize = 2;
            this.lblSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSA.ForeColor = System.Drawing.Color.DimGray;
            this.lblSA.Location = new System.Drawing.Point(236, 136);
            this.lblSA.Margin = new System.Windows.Forms.Padding(4);
            this.lblSA.Multilinea = false;
            this.lblSA.Name = "lblSA";
            this.lblSA.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblSA.PasswordChar = false;
            this.lblSA.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblSA.PlaceHolderText = "Segundo Apellido";
            this.lblSA.Size = new System.Drawing.Size(182, 35);
            this.lblSA.TabIndex = 52;
            this.lblSA.Texts = "";
            this.lblSA.UnderLineFlat = true;
            // 
            // lblPA
            // 
            this.lblPA.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblPA.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblPA.BorderRadius = 0;
            this.lblPA.BorderSize = 2;
            this.lblPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPA.ForeColor = System.Drawing.Color.DimGray;
            this.lblPA.Location = new System.Drawing.Point(29, 136);
            this.lblPA.Margin = new System.Windows.Forms.Padding(4);
            this.lblPA.Multilinea = false;
            this.lblPA.Name = "lblPA";
            this.lblPA.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblPA.PasswordChar = false;
            this.lblPA.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblPA.PlaceHolderText = "Primer Apellido";
            this.lblPA.Size = new System.Drawing.Size(182, 35);
            this.lblPA.TabIndex = 51;
            this.lblPA.Texts = "";
            this.lblPA.UnderLineFlat = true;
            // 
            // lblSN
            // 
            this.lblSN.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblSN.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblSN.BorderRadius = 0;
            this.lblSN.BorderSize = 2;
            this.lblSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSN.ForeColor = System.Drawing.Color.DimGray;
            this.lblSN.Location = new System.Drawing.Point(236, 67);
            this.lblSN.Margin = new System.Windows.Forms.Padding(4);
            this.lblSN.Multilinea = false;
            this.lblSN.Name = "lblSN";
            this.lblSN.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblSN.PasswordChar = false;
            this.lblSN.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblSN.PlaceHolderText = "Segundo Nombre";
            this.lblSN.Size = new System.Drawing.Size(182, 35);
            this.lblSN.TabIndex = 50;
            this.lblSN.Texts = "";
            this.lblSN.UnderLineFlat = true;
            // 
            // lblPn
            // 
            this.lblPn.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblPn.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblPn.BorderRadius = 0;
            this.lblPn.BorderSize = 2;
            this.lblPn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPn.ForeColor = System.Drawing.Color.DimGray;
            this.lblPn.Location = new System.Drawing.Point(32, 67);
            this.lblPn.Margin = new System.Windows.Forms.Padding(4);
            this.lblPn.Multilinea = false;
            this.lblPn.Name = "lblPn";
            this.lblPn.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblPn.PasswordChar = false;
            this.lblPn.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblPn.PlaceHolderText = "Primer Nombre";
            this.lblPn.Size = new System.Drawing.Size(182, 35);
            this.lblPn.TabIndex = 49;
            this.lblPn.Texts = "";
            this.lblPn.UnderLineFlat = true;
            // 
            // PnlBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(936, 466);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblProfesion);
            this.Controls.Add(this.lblSA);
            this.Controls.Add(this.lblPA);
            this.Controls.Add(this.lblSN);
            this.Controls.Add(this.lblPn);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAtaudes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlBeneficiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PnlBeneficiario";
            this.Load += new System.EventHandler(this.PnlBeneficiario_Load);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.RadioButton rbtnMasculino;
        private System.Windows.Forms.RadioButton rbtnFemenino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAtaudes;
        private System.Windows.Forms.Label label5;
        private Especiales.EspecialButton btnAgregar;
        private Especiales.EspecialButton btnCancelar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Controladores.LoginUserControl lblProfesion;
        private Controladores.LoginUserControl lblSA;
        private Controladores.LoginUserControl lblPA;
        private Controladores.LoginUserControl lblSN;
        private Controladores.LoginUserControl lblPn;
        private Controladores.LoginUserControl txtDireccion;
        private Controladores.LoginUserControl txtObservaciones;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker lblFecha;
        private System.Windows.Forms.MaskedTextBox lblCedula;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
    }
}