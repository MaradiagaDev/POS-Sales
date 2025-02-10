namespace NeoCobranza.ViewGestionUsuario
{
    partial class PnlCMUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlCMUsuario));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbRol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CHKMostrar = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.LblDynamicoCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregarSucursal = new System.Windows.Forms.Button();
            this.DgvSucursales = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.CmbSucursales = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtIdentificacion = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtCelular = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtCorreo = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtDireccion = new NeoCobranza.Controladores.LoginUserControl();
            this.BtnCrearUsuario = new NeoCobranza.Especiales.EspecialButton();
            this.TxtContraseñaConfirmar = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtContraseña = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtApellido = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtNombre = new NeoCobranza.Controladores.LoginUserControl();
            this.TxtUsuario = new NeoCobranza.Controladores.LoginUserControl();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtCargo = new NeoCobranza.Controladores.LoginUserControl();
            this.label15 = new System.Windows.Forms.Label();
            this.DtFechaContratacion = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre de Usuario(*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombres (*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellidos(*)";
            // 
            // CmbRol
            // 
            this.CmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRol.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRol.FormattingEnabled = true;
            this.CmbRol.Location = new System.Drawing.Point(15, 345);
            this.CmbRol.Name = "CmbRol";
            this.CmbRol.Size = new System.Drawing.Size(377, 30);
            this.CmbRol.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rol del usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(102, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Información General";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(507, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nueva Contraseña";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(417, 494);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Repita la Contraseña";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(417, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Digite la Contraseña";
            // 
            // CHKMostrar
            // 
            this.CHKMostrar.AutoSize = true;
            this.CHKMostrar.Location = new System.Drawing.Point(741, 565);
            this.CHKMostrar.Name = "CHKMostrar";
            this.CHKMostrar.Size = new System.Drawing.Size(61, 17);
            this.CHKMostrar.TabIndex = 51;
            this.CHKMostrar.Text = "Mostrar";
            this.CHKMostrar.UseVisualStyleBackColor = true;
            this.CHKMostrar.CheckedChanged += new System.EventHandler(this.CHKMostrar_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.lblId);
            this.panel3.Controls.Add(this.LblDynamicoCliente);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1137, 38);
            this.panel3.TabIndex = 52;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblId.Location = new System.Drawing.Point(161, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 20);
            this.lblId.TabIndex = 1;
            // 
            // LblDynamicoCliente
            // 
            this.LblDynamicoCliente.AutoSize = true;
            this.LblDynamicoCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDynamicoCliente.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblDynamicoCliente.Location = new System.Drawing.Point(12, 11);
            this.LblDynamicoCliente.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.LblDynamicoCliente.Name = "LblDynamicoCliente";
            this.LblDynamicoCliente.Size = new System.Drawing.Size(146, 18);
            this.LblDynamicoCliente.TabIndex = 0;
            this.LblDynamicoCliente.Text = "Gestión de Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 54;
            this.label1.Text = "Dirección";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(418, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 19);
            this.label10.TabIndex = 56;
            this.label10.Text = "Correo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(418, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 19);
            this.label11.TabIndex = 58;
            this.label11.Text = "Celular";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.BtnAgregarSucursal);
            this.panel1.Controls.Add(this.DgvSucursales);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.CmbSucursales);
            this.panel1.Location = new System.Drawing.Point(824, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 393);
            this.panel1.TabIndex = 59;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(66, 81);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(106, 33);
            this.btnEliminar.TabIndex = 64;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // BtnAgregarSucursal
            // 
            this.BtnAgregarSucursal.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnAgregarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarSucursal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAgregarSucursal.Location = new System.Drawing.Point(178, 81);
            this.BtnAgregarSucursal.Name = "BtnAgregarSucursal";
            this.BtnAgregarSucursal.Size = new System.Drawing.Size(106, 33);
            this.BtnAgregarSucursal.TabIndex = 63;
            this.BtnAgregarSucursal.Text = "AGREGAR";
            this.BtnAgregarSucursal.UseVisualStyleBackColor = false;
            this.BtnAgregarSucursal.Click += new System.EventHandler(this.BtnAgregarSucursal_Click);
            // 
            // DgvSucursales
            // 
            this.DgvSucursales.AllowUserToAddRows = false;
            this.DgvSucursales.AllowUserToDeleteRows = false;
            this.DgvSucursales.AllowUserToResizeColumns = false;
            this.DgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSucursales.Location = new System.Drawing.Point(15, 120);
            this.DgvSucursales.Name = "DgvSucursales";
            this.DgvSucursales.Size = new System.Drawing.Size(269, 245);
            this.DgvSucursales.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(91, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 19);
            this.label12.TabIndex = 61;
            this.label12.Text = "SUCURSALES (*)";
            // 
            // CmbSucursales
            // 
            this.CmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSucursales.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSucursales.FormattingEnabled = true;
            this.CmbSucursales.Location = new System.Drawing.Point(15, 45);
            this.CmbSucursales.Name = "CmbSucursales";
            this.CmbSucursales.Size = new System.Drawing.Size(269, 30);
            this.CmbSucursales.TabIndex = 60;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(419, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 19);
            this.label13.TabIndex = 61;
            this.label13.Text = "Identificación";
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.BackColor = System.Drawing.Color.White;
            this.TxtIdentificacion.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtIdentificacion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtIdentificacion.BorderRadius = 0;
            this.TxtIdentificacion.BorderSize = 1;
            this.TxtIdentificacion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdentificacion.ForeColor = System.Drawing.Color.Black;
            this.TxtIdentificacion.Location = new System.Drawing.Point(422, 273);
            this.TxtIdentificacion.Margin = new System.Windows.Forms.Padding(4);
            this.TxtIdentificacion.Multilinea = false;
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtIdentificacion.PasswordChar = false;
            this.TxtIdentificacion.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtIdentificacion.PlaceHolderText = "Identificación ...";
            this.TxtIdentificacion.Size = new System.Drawing.Size(377, 38);
            this.TxtIdentificacion.TabIndex = 60;
            this.TxtIdentificacion.Texts = "";
            this.TxtIdentificacion.UnderLineFlat = false;
            this.TxtIdentificacion._TextChanged += new System.EventHandler(this.loginUserControl2__TextChanged);
            // 
            // TxtCelular
            // 
            this.TxtCelular.BackColor = System.Drawing.Color.White;
            this.TxtCelular.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtCelular.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtCelular.BorderRadius = 0;
            this.TxtCelular.BorderSize = 1;
            this.TxtCelular.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCelular.ForeColor = System.Drawing.Color.Black;
            this.TxtCelular.Location = new System.Drawing.Point(421, 203);
            this.TxtCelular.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCelular.Multilinea = false;
            this.TxtCelular.Name = "TxtCelular";
            this.TxtCelular.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtCelular.PasswordChar = false;
            this.TxtCelular.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtCelular.PlaceHolderText = "Celular ...";
            this.TxtCelular.Size = new System.Drawing.Size(377, 38);
            this.TxtCelular.TabIndex = 57;
            this.TxtCelular.Texts = "";
            this.TxtCelular.UnderLineFlat = false;
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.BackColor = System.Drawing.Color.White;
            this.TxtCorreo.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtCorreo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtCorreo.BorderRadius = 0;
            this.TxtCorreo.BorderSize = 1;
            this.TxtCorreo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreo.ForeColor = System.Drawing.Color.Black;
            this.TxtCorreo.Location = new System.Drawing.Point(421, 129);
            this.TxtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCorreo.Multilinea = false;
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtCorreo.PasswordChar = false;
            this.TxtCorreo.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtCorreo.PlaceHolderText = "Correo ...";
            this.TxtCorreo.Size = new System.Drawing.Size(377, 38);
            this.TxtCorreo.TabIndex = 55;
            this.TxtCorreo.Texts = "";
            this.TxtCorreo.UnderLineFlat = false;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.BackColor = System.Drawing.Color.White;
            this.TxtDireccion.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtDireccion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtDireccion.BorderRadius = 0;
            this.TxtDireccion.BorderSize = 1;
            this.TxtDireccion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDireccion.ForeColor = System.Drawing.Color.Black;
            this.TxtDireccion.Location = new System.Drawing.Point(15, 411);
            this.TxtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDireccion.Multilinea = true;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtDireccion.PasswordChar = false;
            this.TxtDireccion.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtDireccion.PlaceHolderText = "Dirección..";
            this.TxtDireccion.Size = new System.Drawing.Size(377, 108);
            this.TxtDireccion.TabIndex = 53;
            this.TxtDireccion.Texts = "";
            this.TxtDireccion.UnderLineFlat = false;
            // 
            // BtnCrearUsuario
            // 
            this.BtnCrearUsuario.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCrearUsuario.BackGroundColor = System.Drawing.SystemColors.Highlight;
            this.BtnCrearUsuario.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCrearUsuario.BorderRadius = 10;
            this.BtnCrearUsuario.BorderSize = 0;
            this.BtnCrearUsuario.FlatAppearance.BorderSize = 0;
            this.BtnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.Location = new System.Drawing.Point(954, 548);
            this.BtnCrearUsuario.Name = "BtnCrearUsuario";
            this.BtnCrearUsuario.Size = new System.Drawing.Size(171, 40);
            this.BtnCrearUsuario.TabIndex = 50;
            this.BtnCrearUsuario.Text = "Guardar";
            this.BtnCrearUsuario.TextGroundColor = System.Drawing.Color.White;
            this.BtnCrearUsuario.UseVisualStyleBackColor = false;
            this.BtnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            // 
            // TxtContraseñaConfirmar
            // 
            this.TxtContraseñaConfirmar.BackColor = System.Drawing.Color.White;
            this.TxtContraseñaConfirmar.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtContraseñaConfirmar.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtContraseñaConfirmar.BorderRadius = 0;
            this.TxtContraseñaConfirmar.BorderSize = 1;
            this.TxtContraseñaConfirmar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContraseñaConfirmar.ForeColor = System.Drawing.Color.Black;
            this.TxtContraseñaConfirmar.Location = new System.Drawing.Point(421, 517);
            this.TxtContraseñaConfirmar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtContraseñaConfirmar.Multilinea = false;
            this.TxtContraseñaConfirmar.Name = "TxtContraseñaConfirmar";
            this.TxtContraseñaConfirmar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtContraseñaConfirmar.PasswordChar = true;
            this.TxtContraseñaConfirmar.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtContraseñaConfirmar.PlaceHolderText = "";
            this.TxtContraseñaConfirmar.Size = new System.Drawing.Size(377, 38);
            this.TxtContraseñaConfirmar.TabIndex = 14;
            this.TxtContraseñaConfirmar.Texts = "";
            this.TxtContraseñaConfirmar.UnderLineFlat = false;
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.BackColor = System.Drawing.Color.White;
            this.TxtContraseña.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtContraseña.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtContraseña.BorderRadius = 0;
            this.TxtContraseña.BorderSize = 1;
            this.TxtContraseña.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContraseña.ForeColor = System.Drawing.Color.Black;
            this.TxtContraseña.Location = new System.Drawing.Point(421, 443);
            this.TxtContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.TxtContraseña.Multilinea = false;
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtContraseña.PasswordChar = true;
            this.TxtContraseña.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtContraseña.PlaceHolderText = "";
            this.TxtContraseña.Size = new System.Drawing.Size(377, 38);
            this.TxtContraseña.TabIndex = 12;
            this.TxtContraseña.Texts = "";
            this.TxtContraseña.UnderLineFlat = false;
            // 
            // TxtApellido
            // 
            this.TxtApellido.BackColor = System.Drawing.Color.White;
            this.TxtApellido.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtApellido.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtApellido.BorderRadius = 0;
            this.TxtApellido.BorderSize = 1;
            this.TxtApellido.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApellido.ForeColor = System.Drawing.Color.Black;
            this.TxtApellido.Location = new System.Drawing.Point(15, 273);
            this.TxtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.TxtApellido.Multilinea = false;
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtApellido.PasswordChar = false;
            this.TxtApellido.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtApellido.PlaceHolderText = "Apellido ...";
            this.TxtApellido.Size = new System.Drawing.Size(377, 38);
            this.TxtApellido.TabIndex = 6;
            this.TxtApellido.Texts = "";
            this.TxtApellido.UnderLineFlat = false;
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtNombre.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtNombre.BorderRadius = 0;
            this.TxtNombre.BorderSize = 1;
            this.TxtNombre.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.Black;
            this.TxtNombre.Location = new System.Drawing.Point(15, 203);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNombre.Multilinea = false;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtNombre.PasswordChar = false;
            this.TxtNombre.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtNombre.PlaceHolderText = "Nombre ...";
            this.TxtNombre.Size = new System.Drawing.Size(377, 38);
            this.TxtNombre.TabIndex = 4;
            this.TxtNombre.Texts = "";
            this.TxtNombre.UnderLineFlat = false;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.White;
            this.TxtUsuario.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtUsuario.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtUsuario.BorderRadius = 0;
            this.TxtUsuario.BorderSize = 1;
            this.TxtUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.Color.Black;
            this.TxtUsuario.Location = new System.Drawing.Point(15, 129);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.Multilinea = false;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtUsuario.PasswordChar = false;
            this.TxtUsuario.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtUsuario.PlaceHolderText = "Usuario ...";
            this.TxtUsuario.Size = new System.Drawing.Size(377, 38);
            this.TxtUsuario.TabIndex = 2;
            this.TxtUsuario.Texts = "";
            this.TxtUsuario.UnderLineFlat = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 524);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 19);
            this.label14.TabIndex = 63;
            this.label14.Text = "Cargo (*)";
            // 
            // TxtCargo
            // 
            this.TxtCargo.BackColor = System.Drawing.Color.White;
            this.TxtCargo.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtCargo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.TxtCargo.BorderRadius = 0;
            this.TxtCargo.BorderSize = 1;
            this.TxtCargo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCargo.ForeColor = System.Drawing.Color.Black;
            this.TxtCargo.Location = new System.Drawing.Point(16, 547);
            this.TxtCargo.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCargo.Multilinea = false;
            this.TxtCargo.Name = "TxtCargo";
            this.TxtCargo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtCargo.PasswordChar = false;
            this.TxtCargo.PlaceHolderColor = System.Drawing.Color.Gray;
            this.TxtCargo.PlaceHolderText = "Cargo ...";
            this.TxtCargo.Size = new System.Drawing.Size(377, 38);
            this.TxtCargo.TabIndex = 62;
            this.TxtCargo.Texts = "";
            this.TxtCargo.UnderLineFlat = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(420, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(188, 19);
            this.label15.TabIndex = 65;
            this.label15.Text = "Fecha de Contratación";
            // 
            // DtFechaContratacion
            // 
            this.DtFechaContratacion.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.DtFechaContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaContratacion.Location = new System.Drawing.Point(421, 345);
            this.DtFechaContratacion.Name = "DtFechaContratacion";
            this.DtFechaContratacion.Size = new System.Drawing.Size(377, 31);
            this.DtFechaContratacion.TabIndex = 66;
            // 
            // PnlCMUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 600);
            this.Controls.Add(this.DtFechaContratacion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TxtCargo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TxtIdentificacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtCelular);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtCorreo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.CHKMostrar);
            this.Controls.Add(this.BtnCrearUsuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtContraseñaConfirmar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtContraseña);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbRol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1153, 639);
            this.MinimumSize = new System.Drawing.Size(1153, 639);
            this.Name = "PnlCMUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.PnlCMUsuario_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSucursales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controladores.LoginUserControl TxtUsuario;
        private System.Windows.Forms.Label label2;
        private Controladores.LoginUserControl TxtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controladores.LoginUserControl TxtApellido;
        private System.Windows.Forms.ComboBox CmbRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Controladores.LoginUserControl TxtContraseñaConfirmar;
        private System.Windows.Forms.Label label9;
        private Controladores.LoginUserControl TxtContraseña;
        private Especiales.EspecialButton BtnCrearUsuario;
        private System.Windows.Forms.CheckBox CHKMostrar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblId;
        public System.Windows.Forms.Label LblDynamicoCliente;
        private Controladores.LoginUserControl TxtDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private Controladores.LoginUserControl TxtCorreo;
        private System.Windows.Forms.Label label11;
        private Controladores.LoginUserControl TxtCelular;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAgregarSucursal;
        private System.Windows.Forms.DataGridView DgvSucursales;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CmbSucursales;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label13;
        private Controladores.LoginUserControl TxtIdentificacion;
        private System.Windows.Forms.Label label14;
        private Controladores.LoginUserControl TxtCargo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker DtFechaContratacion;
    }
}