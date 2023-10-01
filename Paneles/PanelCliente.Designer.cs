
namespace NeoCobranza.Paneles
{
    partial class PanelCliente
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
            this.rbtnSoltero = new System.Windows.Forms.RadioButton();
            this.rbtnCasado = new System.Windows.Forms.RadioButton();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFecha = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSexo = new System.Windows.Forms.Label();
            this.rbtnMasculino = new System.Windows.Forms.RadioButton();
            this.rbtnFemenino = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtCedula = new System.Windows.Forms.MaskedTextBox();
            this.mtxtEmail = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dataSetFinal1 = new NeoCobranza.DataSetFinal();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.mtxtCelular = new NeoCobranza.Controladores.LoginUserControl();
            this.txtObservacion = new NeoCobranza.Controladores.LoginUserControl();
            this.btnAgregar = new NeoCobranza.Especiales.EspecialButton();
            this.btnCancelar = new NeoCobranza.Especiales.EspecialButton();
            this.txtDireccion = new NeoCobranza.Controladores.LoginUserControl();
            this.lblProfesion = new NeoCobranza.Controladores.LoginUserControl();
            this.lblSA = new NeoCobranza.Controladores.LoginUserControl();
            this.lblPA = new NeoCobranza.Controladores.LoginUserControl();
            this.lblSN = new NeoCobranza.Controladores.LoginUserControl();
            this.lblPn = new NeoCobranza.Controladores.LoginUserControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFinal1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtnSoltero
            // 
            this.rbtnSoltero.AutoSize = true;
            this.rbtnSoltero.Location = new System.Drawing.Point(3, 21);
            this.rbtnSoltero.Name = "rbtnSoltero";
            this.rbtnSoltero.Size = new System.Drawing.Size(74, 22);
            this.rbtnSoltero.TabIndex = 14;
            this.rbtnSoltero.TabStop = true;
            this.rbtnSoltero.Text = "Soltero";
            this.rbtnSoltero.UseVisualStyleBackColor = true;
            // 
            // rbtnCasado
            // 
            this.rbtnCasado.AutoSize = true;
            this.rbtnCasado.Location = new System.Drawing.Point(3, 49);
            this.rbtnCasado.Name = "rbtnCasado";
            this.rbtnCasado.Size = new System.Drawing.Size(78, 22);
            this.rbtnCasado.TabIndex = 15;
            this.rbtnCasado.TabStop = true;
            this.rbtnCasado.Text = "Casado";
            this.rbtnCasado.UseVisualStyleBackColor = true;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Items.AddRange(new object[] {
            "Managua",
            "Boaco",
            "Carazo",
            "Chinandega",
            "Chontales",
            "Esteli",
            "Granada",
            "Jinotega",
            "Leon",
            "Madriz",
            "Masaya",
            "Matagalpa",
            "Nueva Segovia",
            "Rio San Juan",
            "Rivas",
            "RAAS",
            "RAAN"});
            this.cmbDepartamento.Location = new System.Drawing.Point(112, 239);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(180, 24);
            this.cmbDepartamento.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Estado Civil";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.rbtnSoltero);
            this.flowLayoutPanel1.Controls.Add(this.rbtnCasado);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(454, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 85);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // lblFecha
            // 
            this.lblFecha.CustomFormat = "dd-MM-yyyy";
            this.lblFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lblFecha.Location = new System.Drawing.Point(3, 21);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(160, 24);
            this.lblFecha.TabIndex = 37;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.lblFecha);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(788, 46);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 60);
            this.flowLayoutPanel2.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha de Nacimiento";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblSexo);
            this.flowLayoutPanel3.Controls.Add(this.rbtnMasculino);
            this.flowLayoutPanel3.Controls.Add(this.rbtnFemenino);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(589, 45);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(137, 82);
            this.flowLayoutPanel3.TabIndex = 37;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(3, 0);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(42, 18);
            this.lblSexo.TabIndex = 0;
            this.lblSexo.Text = "Sexo";
            // 
            // rbtnMasculino
            // 
            this.rbtnMasculino.AutoSize = true;
            this.rbtnMasculino.Location = new System.Drawing.Point(3, 21);
            this.rbtnMasculino.Name = "rbtnMasculino";
            this.rbtnMasculino.Size = new System.Drawing.Size(94, 22);
            this.rbtnMasculino.TabIndex = 17;
            this.rbtnMasculino.TabStop = true;
            this.rbtnMasculino.Text = "Masculino";
            this.rbtnMasculino.UseVisualStyleBackColor = true;
            // 
            // rbtnFemenino
            // 
            this.rbtnFemenino.AutoSize = true;
            this.rbtnFemenino.Location = new System.Drawing.Point(3, 49);
            this.rbtnFemenino.Name = "rbtnFemenino";
            this.rbtnFemenino.Size = new System.Drawing.Size(92, 22);
            this.rbtnFemenino.TabIndex = 18;
            this.rbtnFemenino.TabStop = true;
            this.rbtnFemenino.Text = "Femenino";
            this.rbtnFemenino.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(454, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Direccion ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(16, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "(*) Primer Nombre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(214, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Segundo Nombre:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(16, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "(*) Primer Apellido:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(214, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Segundo Apellido:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(18, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "(*) Cedula:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(214, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 41;
            this.label11.Text = "Profesion:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(16, 295);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 16);
            this.label12.TabIndex = 42;
            this.label12.Text = "Email:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(16, 345);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 43;
            this.label13.Text = "Telefono:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(214, 345);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 16);
            this.label14.TabIndex = 44;
            this.label14.Text = "(*) Celular:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(10, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 45;
            this.label15.Text = "Departamento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Informacion de Contacto";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(989, 33);
            this.panel3.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Cliente";
            // 
            // mtxtCedula
            // 
            this.mtxtCedula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtxtCedula.Location = new System.Drawing.Point(10, 204);
            this.mtxtCedula.Mask = "000-000000-0000L";
            this.mtxtCedula.Name = "mtxtCedula";
            this.mtxtCedula.Size = new System.Drawing.Size(182, 13);
            this.mtxtCedula.TabIndex = 30;
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.Location = new System.Drawing.Point(15, 311);
            this.mtxtEmail.Mask = "LCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC@LLLLLLLLLLLL";
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(277, 20);
            this.mtxtEmail.TabIndex = 33;
            // 
            // mtxtTelefono
            // 
            this.mtxtTelefono.Location = new System.Drawing.Point(10, 384);
            this.mtxtTelefono.Mask = "00000000000000000000000";
            this.mtxtTelefono.Name = "mtxtTelefono";
            this.mtxtTelefono.Size = new System.Drawing.Size(182, 20);
            this.mtxtTelefono.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label16.Location = new System.Drawing.Point(537, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(228, 16);
            this.label16.TabIndex = 47;
            this.label16.Text = "(*) significa: Llenado obligatorio";
            // 
            // dataSetFinal1
            // 
            this.dataSetFinal1.DataSetName = "DataSetFinal";
            this.dataSetFinal1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbPais
            // 
            this.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Items.AddRange(new object[] {
            "NICARAGUA",
            "AFGANISTÁN",
            "ALBANIA",
            "ALEMANIA",
            "ANDORRA",
            "ANGOLA",
            "ANTIGUA Y BARBUDA",
            "ARABIA SAUDITA",
            "ARGELIA",
            "ARGENTINA",
            "ARMENIA",
            "AUSTRALIA",
            "AUSTRIA",
            "AZERBAIYÁN",
            "BAHAMAS",
            "BANGLADÉS",
            "BARBADOS",
            "BARÉIN",
            "BÉLGICA",
            "BELICE",
            "BENIN",
            "BIELORRUSIA",
            "BOLIVIA",
            "BOSNIA Y HERZEGOVINA",
            "BOTSUANA",
            "BRASIL",
            "BRUNEI",
            "BULGARIA",
            "BURKINA FASO",
            "BURUNDI",
            "BUTÁN",
            "CABO VERDE",
            "CAMBOYA",
            "CAMERÚN",
            "CANADÁ",
            "CATAR",
            "CHAD",
            "CHILE",
            "CHINA",
            "CHIPRE",
            "COLOMBIA",
            "COMORAS",
            "COREA DEL NORTE",
            "COREA DEL SUR",
            "COSTA DE MARFIL",
            "COSTA RICA",
            "CROACIA",
            "CUBA",
            "DINAMARCA",
            "DOMINICA",
            "ECUADOR",
            "EGIPTO",
            "EL SALVADOR",
            "EMIRATOS ARABES UNIDOS",
            "ERITREA",
            "ESLOVAQUIA",
            "ESLOVENIA",
            "ESPAÑA",
            "ESTADOS UNIDOS",
            "ESTONIA",
            "ETIOPÍA",
            "FILIPINAS",
            "FINLANDIA",
            "FIYI",
            "FRANCIA",
            "GABÓN",
            "GAMBIA",
            "GEORGIA",
            "GHANA",
            "GRANADA",
            "GRECIA",
            "GUATEMALA",
            "GUINEA",
            "GUINEA ECUATORIAL",
            "GUINEA-BISSAU",
            "GUYANA",
            "HAITÍ",
            "HONDURAS",
            "HUNGRÍA",
            "INDIA",
            "INDONESIA",
            "IRÁN",
            "IRAQ",
            "IRLANDA",
            "ISLANDIA",
            "ISLAS MARSHALL",
            "ISLAS SALOMÓN",
            "ISRAEL",
            "ITALIA",
            "JAMAICA",
            "JAPÓN",
            "JORDANIA",
            "KAZAJISTÁN",
            "KENIA",
            "KIRGUISTÁN",
            "KIRIBATI",
            "KUWAIT",
            "LAOS",
            "LESOTO",
            "LETONIA",
            "LÍBANO",
            "LIBERIA",
            "LIBIA",
            "LIECHTENSTEIN",
            "LITUANIA",
            "LUXEMBURGO",
            "MADAGASCAR",
            "MALASIA",
            "MALAUI",
            "MALDIVAS",
            "MALI",
            "MALTA",
            "MARRUECOS",
            "MAURICIO",
            "MAURITANIA",
            "MÉXICO",
            "MICRONESIA",
            "MOLDAVIA",
            "MÓNACO",
            "MONGOLIA",
            "MONTENEGRO",
            "MOZAMBIQUE",
            "MYANMAR (BIRMANIA)",
            "NAMIBIA",
            "NAURU",
            "NEPAL",
            "NÍGER",
            "NIGERIA",
            "NORUEGA",
            "NUEVA ZELANDA",
            "OMÁN",
            "PAÍSES BAJOS",
            "PAKISTÁN",
            "PALAOS",
            "PALESTINA",
            "PANAMÁ",
            "PAPÚA NUEVA GUINEA",
            "PARAGUAY",
            "PERÚ",
            "POLONIA",
            "PORTUGAL",
            "PUERTO RICO",
            "REINO UNIDO",
            "REPÚBLICA CENTROAFRICANA",
            "REPÚBLICA CHECA",
            "REPÚBLICA DE MACEDONIA",
            "REPÚBLICA DEL CONGO",
            "REPÚBLICA DEMOCRÁTICA DEL CONGO",
            "REPÚBLICA DOMINICANA",
            "RUANDA",
            "RUMANIA",
            "RUSIA",
            "SAMOA",
            "SAN CRISTÓBAL Y NIEVES",
            "SAN MARINO",
            "SAN VICENTE Y LAS GRANADINAS",
            "SANTA LUCÍA",
            "SANTO TOMÉ Y PRÍNCIPE",
            "SENEGAL",
            "SERBIA",
            "SEYCHELLES",
            "SIERRA LEONA",
            "SIRIA",
            "SOMALIA",
            "SRI LANKA",
            "SUAZILANDIA",
            "SUDÁFRICA",
            "SUDÁN",
            "SUDÁN DEL SUR",
            "SUECIA",
            "SUIZA",
            "SURINAM",
            "TAILANDIA",
            "TANZANIA",
            "TAYIKISTÁN",
            "TIMOR ORIENTAL",
            "TOGO",
            "TONGA",
            "TRINIDAD Y TOBAGO",
            "TÚNEZ",
            "TURKMENISTÁN",
            "TURQUÍA",
            "TUVALU",
            "UCRANIA",
            "UGANDA",
            "URUGUAY",
            "UZBEKISTÁN",
            "VANUATU",
            "VENEZUELA",
            "VIETNAM",
            "YEMEN",
            "YIBUTI",
            "ZAMBIA",
            "ZIMBABUE",
            "NICARAGUA"});
            this.cmbPais.Location = new System.Drawing.Point(457, 150);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(251, 24);
            this.cmbPais.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label17.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label17.Location = new System.Drawing.Point(454, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 16);
            this.label17.TabIndex = 49;
            this.label17.Text = "Pais";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label18.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label18.Location = new System.Drawing.Point(454, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 16);
            this.label18.TabIndex = 50;
            this.label18.Text = "Observaciones";
            // 
            // mtxtCelular
            // 
            this.mtxtCelular.BorderColor = System.Drawing.Color.RoyalBlue;
            this.mtxtCelular.BorderFocusColor = System.Drawing.Color.HotPink;
            this.mtxtCelular.BorderRadius = 0;
            this.mtxtCelular.BorderSize = 2;
            this.mtxtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCelular.ForeColor = System.Drawing.Color.DimGray;
            this.mtxtCelular.Location = new System.Drawing.Point(217, 373);
            this.mtxtCelular.Margin = new System.Windows.Forms.Padding(4);
            this.mtxtCelular.Multilinea = false;
            this.mtxtCelular.Name = "mtxtCelular";
            this.mtxtCelular.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.mtxtCelular.PasswordChar = false;
            this.mtxtCelular.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.mtxtCelular.PlaceHolderText = "Celular";
            this.mtxtCelular.Size = new System.Drawing.Size(182, 31);
            this.mtxtCelular.TabIndex = 52;
            this.mtxtCelular.Texts = "";
            this.mtxtCelular.UnderLineFlat = true;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtObservacion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtObservacion.BorderRadius = 10;
            this.txtObservacion.BorderSize = 2;
            this.txtObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.ForeColor = System.Drawing.Color.DimGray;
            this.txtObservacion.Location = new System.Drawing.Point(454, 204);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacion.Multilinea = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtObservacion.PasswordChar = false;
            this.txtObservacion.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtObservacion.PlaceHolderText = "Observaciones";
            this.txtObservacion.Size = new System.Drawing.Size(497, 59);
            this.txtObservacion.TabIndex = 51;
            this.txtObservacion.Texts = "";
            this.txtObservacion.UnderLineFlat = false;
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
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(715, 389);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(162, 42);
            this.btnAgregar.TabIndex = 40;
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
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(528, 389);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(162, 42);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextGroundColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtDireccion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtDireccion.BorderRadius = 10;
            this.txtDireccion.BorderSize = 2;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDireccion.Location = new System.Drawing.Point(454, 291);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Multilinea = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDireccion.PasswordChar = false;
            this.txtDireccion.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txtDireccion.PlaceHolderText = "Direccion";
            this.txtDireccion.Size = new System.Drawing.Size(497, 66);
            this.txtDireccion.TabIndex = 39;
            this.txtDireccion.Texts = "";
            this.txtDireccion.UnderLineFlat = false;
            // 
            // lblProfesion
            // 
            this.lblProfesion.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblProfesion.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblProfesion.BorderRadius = 0;
            this.lblProfesion.BorderSize = 2;
            this.lblProfesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesion.ForeColor = System.Drawing.Color.DimGray;
            this.lblProfesion.Location = new System.Drawing.Point(217, 193);
            this.lblProfesion.Margin = new System.Windows.Forms.Padding(4);
            this.lblProfesion.Multilinea = false;
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblProfesion.PasswordChar = false;
            this.lblProfesion.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblProfesion.PlaceHolderText = "Profesion";
            this.lblProfesion.Size = new System.Drawing.Size(182, 31);
            this.lblProfesion.TabIndex = 31;
            this.lblProfesion.Texts = "";
            this.lblProfesion.UnderLineFlat = true;
            // 
            // lblSA
            // 
            this.lblSA.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblSA.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblSA.BorderRadius = 0;
            this.lblSA.BorderSize = 2;
            this.lblSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSA.ForeColor = System.Drawing.Color.DimGray;
            this.lblSA.Location = new System.Drawing.Point(217, 132);
            this.lblSA.Margin = new System.Windows.Forms.Padding(4);
            this.lblSA.Multilinea = false;
            this.lblSA.Name = "lblSA";
            this.lblSA.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblSA.PasswordChar = false;
            this.lblSA.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblSA.PlaceHolderText = "Segundo Apellido";
            this.lblSA.Size = new System.Drawing.Size(182, 31);
            this.lblSA.TabIndex = 29;
            this.lblSA.Texts = "";
            this.lblSA.UnderLineFlat = true;
            // 
            // lblPA
            // 
            this.lblPA.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblPA.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblPA.BorderRadius = 0;
            this.lblPA.BorderSize = 2;
            this.lblPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPA.ForeColor = System.Drawing.Color.DimGray;
            this.lblPA.Location = new System.Drawing.Point(10, 132);
            this.lblPA.Margin = new System.Windows.Forms.Padding(4);
            this.lblPA.Multilinea = false;
            this.lblPA.Name = "lblPA";
            this.lblPA.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblPA.PasswordChar = false;
            this.lblPA.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblPA.PlaceHolderText = "Primer Apellido";
            this.lblPA.Size = new System.Drawing.Size(182, 31);
            this.lblPA.TabIndex = 28;
            this.lblPA.Texts = "";
            this.lblPA.UnderLineFlat = true;
            // 
            // lblSN
            // 
            this.lblSN.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblSN.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblSN.BorderRadius = 0;
            this.lblSN.BorderSize = 2;
            this.lblSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSN.ForeColor = System.Drawing.Color.DimGray;
            this.lblSN.Location = new System.Drawing.Point(217, 63);
            this.lblSN.Margin = new System.Windows.Forms.Padding(4);
            this.lblSN.Multilinea = false;
            this.lblSN.Name = "lblSN";
            this.lblSN.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblSN.PasswordChar = false;
            this.lblSN.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblSN.PlaceHolderText = "Segundo Nombre";
            this.lblSN.Size = new System.Drawing.Size(182, 31);
            this.lblSN.TabIndex = 27;
            this.lblSN.Texts = "";
            this.lblSN.UnderLineFlat = true;
            // 
            // lblPn
            // 
            this.lblPn.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lblPn.BorderFocusColor = System.Drawing.Color.HotPink;
            this.lblPn.BorderRadius = 0;
            this.lblPn.BorderSize = 2;
            this.lblPn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPn.ForeColor = System.Drawing.Color.DimGray;
            this.lblPn.Location = new System.Drawing.Point(13, 63);
            this.lblPn.Margin = new System.Windows.Forms.Padding(4);
            this.lblPn.Multilinea = false;
            this.lblPn.Name = "lblPn";
            this.lblPn.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.lblPn.PasswordChar = false;
            this.lblPn.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.lblPn.PlaceHolderText = "Primer Nombre";
            this.lblPn.Size = new System.Drawing.Size(182, 31);
            this.lblPn.TabIndex = 26;
            this.lblPn.Texts = "";
            this.lblPn.UnderLineFlat = true;
            this.lblPn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblPn_KeyPress);
            // 
            // PanelCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(987, 443);
            this.Controls.Add(this.mtxtCelular);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.mtxtTelefono);
            this.Controls.Add(this.mtxtEmail);
            this.Controls.Add(this.mtxtCedula);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblProfesion);
            this.Controls.Add(this.lblSA);
            this.Controls.Add(this.lblPA);
            this.Controls.Add(this.lblSN);
            this.Controls.Add(this.lblPn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PanelCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Cliente";
            this.Load += new System.EventHandler(this.PanelCliente_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFinal1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private DataSetFinal dataSetFinal1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.RadioButton rbtnSoltero;
        public System.Windows.Forms.RadioButton rbtnCasado;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.DateTimePicker lblFecha;
        public System.Windows.Forms.ComboBox cmbDepartamento;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public System.Windows.Forms.RadioButton rbtnMasculino;
        public System.Windows.Forms.RadioButton rbtnFemenino;
        public Controladores.LoginUserControl lblPn;
        public Controladores.LoginUserControl lblSN;
        public Controladores.LoginUserControl lblPA;
        public Controladores.LoginUserControl lblSA;
        public Controladores.LoginUserControl lblProfesion;
        public Controladores.LoginUserControl txtDireccion;
        public System.Windows.Forms.MaskedTextBox mtxtCedula;
        public System.Windows.Forms.MaskedTextBox mtxtEmail;
        public System.Windows.Forms.MaskedTextBox mtxtTelefono;
        public Especiales.EspecialButton btnCancelar;
        public Especiales.EspecialButton btnAgregar;
        public System.Windows.Forms.ComboBox cmbPais;
        public Controladores.LoginUserControl txtObservacion;
        public Controladores.LoginUserControl mtxtCelular;
    }
}