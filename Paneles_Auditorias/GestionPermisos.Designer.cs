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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridPermisos = new System.Windows.Forms.SplitContainer();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TIGeneral = new System.Windows.Forms.TabPage();
            this.BtnGuardarGenerales = new System.Windows.Forms.Button();
            this.BtnCancelarGenerales = new System.Windows.Forms.Button();
            this.ChkOpcionesTipoCambio = new System.Windows.Forms.CheckBox();
            this.ChkSeguridadPermisos = new System.Windows.Forms.CheckBox();
            this.ChkSeguridadUsuario = new System.Windows.Forms.CheckBox();
            this.ChkSeguridadAuditoria = new System.Windows.Forms.CheckBox();
            this.ChkCajaHistorialRecibos = new System.Windows.Forms.CheckBox();
            this.ChkCajaReciboOficial = new System.Windows.Forms.CheckBox();
            this.ChkInventarioTipoProducto = new System.Windows.Forms.CheckBox();
            this.ChkInventarioServicios = new System.Windows.Forms.CheckBox();
            this.ChkVentasFacturas = new System.Windows.Forms.CheckBox();
            this.ChkVentasDirectas = new System.Windows.Forms.CheckBox();
            this.ChkVentasBuscarProformas = new System.Windows.Forms.CheckBox();
            this.ChkVentasCrearProforma = new System.Windows.Forms.CheckBox();
            this.ChkContratosRealizarFactura = new System.Windows.Forms.CheckBox();
            this.ChkContratosRetiroServicios = new System.Windows.Forms.CheckBox();
            this.ChkContratosInformacionGeneral = new System.Windows.Forms.CheckBox();
            this.ChkContratosRetirados = new System.Windows.Forms.CheckBox();
            this.ChkContratosGestionCuotas = new System.Windows.Forms.CheckBox();
            this.ChkContratosCrearProforma = new System.Windows.Forms.CheckBox();
            this.ChkContratosBuscarProformas = new System.Windows.Forms.CheckBox();
            this.ChkContratosCrearContratos = new System.Windows.Forms.CheckBox();
            this.ChkCatalogoProveedores = new System.Windows.Forms.CheckBox();
            this.ChkCatalogoClientes = new System.Windows.Forms.CheckBox();
            this.ChkOpciones = new System.Windows.Forms.CheckBox();
            this.ChkSeguridad = new System.Windows.Forms.CheckBox();
            this.ChkPersonal = new System.Windows.Forms.CheckBox();
            this.ChkCaja = new System.Windows.Forms.CheckBox();
            this.ChkInventario = new System.Windows.Forms.CheckBox();
            this.ChkVentas = new System.Windows.Forms.CheckBox();
            this.ChkContratos = new System.Windows.Forms.CheckBox();
            this.ChkCatalogos = new System.Windows.Forms.CheckBox();
            this.TbTitulosGenerales = new System.Windows.Forms.Label();
            this.TIBuscar = new System.Windows.Forms.TabPage();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.BtnConfigurar = new System.Windows.Forms.Button();
            this.BtnBloquear = new System.Windows.Forms.Button();
            this.LvRol = new System.Windows.Forms.DataGridView();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnBuscarPermisos = new System.Windows.Forms.Button();
            this.TbTituloGenerales = new System.Windows.Forms.Label();
            this.TxtBuscar = new NeoCobranza.Controladores.LoginUserControl();
            this.TICrearRol = new System.Windows.Forms.TabPage();
            this.BtnGuardarRol = new System.Windows.Forms.Button();
            this.BtnCancelarRol = new System.Windows.Forms.Button();
            this.TxtNombrePermiso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlTitulo = new System.Windows.Forms.Panel();
            this.TbTitulo = new System.Windows.Forms.Label();
            this.ChkRetiroVentas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridPermisos)).BeginInit();
            this.GridPermisos.Panel1.SuspendLayout();
            this.GridPermisos.Panel2.SuspendLayout();
            this.GridPermisos.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.TIGeneral.SuspendLayout();
            this.TIBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LvRol)).BeginInit();
            this.TICrearRol.SuspendLayout();
            this.PnlTitulo.SuspendLayout();
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
            this.TCMain.Controls.Add(this.TIGeneral);
            this.TCMain.Controls.Add(this.TIBuscar);
            this.TCMain.Controls.Add(this.TICrearRol);
            this.TCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCMain.Location = new System.Drawing.Point(0, 0);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(1157, 554);
            this.TCMain.TabIndex = 1;
            // 
            // TIGeneral
            // 
            this.TIGeneral.Controls.Add(this.ChkRetiroVentas);
            this.TIGeneral.Controls.Add(this.BtnGuardarGenerales);
            this.TIGeneral.Controls.Add(this.BtnCancelarGenerales);
            this.TIGeneral.Controls.Add(this.ChkOpcionesTipoCambio);
            this.TIGeneral.Controls.Add(this.ChkSeguridadPermisos);
            this.TIGeneral.Controls.Add(this.ChkSeguridadUsuario);
            this.TIGeneral.Controls.Add(this.ChkSeguridadAuditoria);
            this.TIGeneral.Controls.Add(this.ChkCajaHistorialRecibos);
            this.TIGeneral.Controls.Add(this.ChkCajaReciboOficial);
            this.TIGeneral.Controls.Add(this.ChkInventarioTipoProducto);
            this.TIGeneral.Controls.Add(this.ChkInventarioServicios);
            this.TIGeneral.Controls.Add(this.ChkVentasFacturas);
            this.TIGeneral.Controls.Add(this.ChkVentasDirectas);
            this.TIGeneral.Controls.Add(this.ChkVentasBuscarProformas);
            this.TIGeneral.Controls.Add(this.ChkVentasCrearProforma);
            this.TIGeneral.Controls.Add(this.ChkContratosRealizarFactura);
            this.TIGeneral.Controls.Add(this.ChkContratosRetiroServicios);
            this.TIGeneral.Controls.Add(this.ChkContratosInformacionGeneral);
            this.TIGeneral.Controls.Add(this.ChkContratosRetirados);
            this.TIGeneral.Controls.Add(this.ChkContratosGestionCuotas);
            this.TIGeneral.Controls.Add(this.ChkContratosCrearProforma);
            this.TIGeneral.Controls.Add(this.ChkContratosBuscarProformas);
            this.TIGeneral.Controls.Add(this.ChkContratosCrearContratos);
            this.TIGeneral.Controls.Add(this.ChkCatalogoProveedores);
            this.TIGeneral.Controls.Add(this.ChkCatalogoClientes);
            this.TIGeneral.Controls.Add(this.ChkOpciones);
            this.TIGeneral.Controls.Add(this.ChkSeguridad);
            this.TIGeneral.Controls.Add(this.ChkPersonal);
            this.TIGeneral.Controls.Add(this.ChkCaja);
            this.TIGeneral.Controls.Add(this.ChkInventario);
            this.TIGeneral.Controls.Add(this.ChkVentas);
            this.TIGeneral.Controls.Add(this.ChkContratos);
            this.TIGeneral.Controls.Add(this.ChkCatalogos);
            this.TIGeneral.Controls.Add(this.TbTitulosGenerales);
            this.TIGeneral.Location = new System.Drawing.Point(4, 22);
            this.TIGeneral.Name = "TIGeneral";
            this.TIGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TIGeneral.Size = new System.Drawing.Size(1149, 528);
            this.TIGeneral.TabIndex = 0;
            this.TIGeneral.Text = "General";
            this.TIGeneral.UseVisualStyleBackColor = true;
            this.TIGeneral.Click += new System.EventHandler(this.TIGeneral_Click);
            // 
            // BtnGuardarGenerales
            // 
            this.BtnGuardarGenerales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardarGenerales.BackColor = System.Drawing.Color.Black;
            this.BtnGuardarGenerales.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic);
            this.BtnGuardarGenerales.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnGuardarGenerales.Location = new System.Drawing.Point(1023, 480);
            this.BtnGuardarGenerales.Name = "BtnGuardarGenerales";
            this.BtnGuardarGenerales.Size = new System.Drawing.Size(112, 42);
            this.BtnGuardarGenerales.TabIndex = 56;
            this.BtnGuardarGenerales.Text = "Guardar";
            this.BtnGuardarGenerales.UseVisualStyleBackColor = false;
            this.BtnGuardarGenerales.Click += new System.EventHandler(this.BtnGuardarGenerales_Click);
            // 
            // BtnCancelarGenerales
            // 
            this.BtnCancelarGenerales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelarGenerales.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic);
            this.BtnCancelarGenerales.Location = new System.Drawing.Point(853, 480);
            this.BtnCancelarGenerales.Name = "BtnCancelarGenerales";
            this.BtnCancelarGenerales.Size = new System.Drawing.Size(112, 42);
            this.BtnCancelarGenerales.TabIndex = 55;
            this.BtnCancelarGenerales.Text = "Cancelar";
            this.BtnCancelarGenerales.UseVisualStyleBackColor = true;
            this.BtnCancelarGenerales.Click += new System.EventHandler(this.BtnCancelarGenerales_Click);
            // 
            // ChkOpcionesTipoCambio
            // 
            this.ChkOpcionesTipoCambio.AutoSize = true;
            this.ChkOpcionesTipoCambio.BackColor = System.Drawing.Color.Transparent;
            this.ChkOpcionesTipoCambio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkOpcionesTipoCambio.Location = new System.Drawing.Point(853, 348);
            this.ChkOpcionesTipoCambio.Name = "ChkOpcionesTipoCambio";
            this.ChkOpcionesTipoCambio.Size = new System.Drawing.Size(220, 23);
            this.ChkOpcionesTipoCambio.TabIndex = 31;
            this.ChkOpcionesTipoCambio.Text = "Opciones -  Tipo Cambio";
            this.ChkOpcionesTipoCambio.UseVisualStyleBackColor = false;
            // 
            // ChkSeguridadPermisos
            // 
            this.ChkSeguridadPermisos.AutoSize = true;
            this.ChkSeguridadPermisos.BackColor = System.Drawing.Color.Transparent;
            this.ChkSeguridadPermisos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkSeguridadPermisos.Location = new System.Drawing.Point(853, 278);
            this.ChkSeguridadPermisos.Name = "ChkSeguridadPermisos";
            this.ChkSeguridadPermisos.Size = new System.Drawing.Size(282, 23);
            this.ChkSeguridadPermisos.TabIndex = 30;
            this.ChkSeguridadPermisos.Text = "Seguridad - Gestión de Permisos ";
            this.ChkSeguridadPermisos.UseVisualStyleBackColor = false;
            // 
            // ChkSeguridadUsuario
            // 
            this.ChkSeguridadUsuario.AutoSize = true;
            this.ChkSeguridadUsuario.BackColor = System.Drawing.Color.Transparent;
            this.ChkSeguridadUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkSeguridadUsuario.Location = new System.Drawing.Point(853, 249);
            this.ChkSeguridadUsuario.Name = "ChkSeguridadUsuario";
            this.ChkSeguridadUsuario.Size = new System.Drawing.Size(271, 23);
            this.ChkSeguridadUsuario.TabIndex = 29;
            this.ChkSeguridadUsuario.Text = "Seguridad - Gestión de Usuario ";
            this.ChkSeguridadUsuario.UseVisualStyleBackColor = false;
            // 
            // ChkSeguridadAuditoria
            // 
            this.ChkSeguridadAuditoria.AutoSize = true;
            this.ChkSeguridadAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.ChkSeguridadAuditoria.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkSeguridadAuditoria.Location = new System.Drawing.Point(853, 220);
            this.ChkSeguridadAuditoria.Name = "ChkSeguridadAuditoria";
            this.ChkSeguridadAuditoria.Size = new System.Drawing.Size(194, 23);
            this.ChkSeguridadAuditoria.TabIndex = 28;
            this.ChkSeguridadAuditoria.Text = "Seguridad - Auditoría";
            this.ChkSeguridadAuditoria.UseVisualStyleBackColor = false;
            // 
            // ChkCajaHistorialRecibos
            // 
            this.ChkCajaHistorialRecibos.AutoSize = true;
            this.ChkCajaHistorialRecibos.BackColor = System.Drawing.Color.Transparent;
            this.ChkCajaHistorialRecibos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkCajaHistorialRecibos.Location = new System.Drawing.Point(409, 433);
            this.ChkCajaHistorialRecibos.Name = "ChkCajaHistorialRecibos";
            this.ChkCajaHistorialRecibos.Size = new System.Drawing.Size(233, 23);
            this.ChkCajaHistorialRecibos.TabIndex = 27;
            this.ChkCajaHistorialRecibos.Text = "Caja - Historial de Recibos";
            this.ChkCajaHistorialRecibos.UseVisualStyleBackColor = false;
            // 
            // ChkCajaReciboOficial
            // 
            this.ChkCajaReciboOficial.AutoSize = true;
            this.ChkCajaReciboOficial.BackColor = System.Drawing.Color.Transparent;
            this.ChkCajaReciboOficial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkCajaReciboOficial.Location = new System.Drawing.Point(409, 404);
            this.ChkCajaReciboOficial.Name = "ChkCajaReciboOficial";
            this.ChkCajaReciboOficial.Size = new System.Drawing.Size(260, 23);
            this.ChkCajaReciboOficial.TabIndex = 26;
            this.ChkCajaReciboOficial.Text = "Caja - Recibo Oficial de Caja";
            this.ChkCajaReciboOficial.UseVisualStyleBackColor = false;
            // 
            // ChkInventarioTipoProducto
            // 
            this.ChkInventarioTipoProducto.AutoSize = true;
            this.ChkInventarioTipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.ChkInventarioTipoProducto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkInventarioTipoProducto.Location = new System.Drawing.Point(409, 334);
            this.ChkInventarioTipoProducto.Name = "ChkInventarioTipoProducto";
            this.ChkInventarioTipoProducto.Size = new System.Drawing.Size(404, 23);
            this.ChkInventarioTipoProducto.TabIndex = 25;
            this.ChkInventarioTipoProducto.Text = "Inventario - Modificaciones de Tipo de Producto";
            this.ChkInventarioTipoProducto.UseVisualStyleBackColor = false;
            // 
            // ChkInventarioServicios
            // 
            this.ChkInventarioServicios.AutoSize = true;
            this.ChkInventarioServicios.BackColor = System.Drawing.Color.Transparent;
            this.ChkInventarioServicios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkInventarioServicios.Location = new System.Drawing.Point(409, 305);
            this.ChkInventarioServicios.Name = "ChkInventarioServicios";
            this.ChkInventarioServicios.Size = new System.Drawing.Size(298, 23);
            this.ChkInventarioServicios.TabIndex = 24;
            this.ChkInventarioServicios.Text = "Inventario - Inventario de Servicios";
            this.ChkInventarioServicios.UseVisualStyleBackColor = false;
            // 
            // ChkVentasFacturas
            // 
            this.ChkVentasFacturas.AutoSize = true;
            this.ChkVentasFacturas.BackColor = System.Drawing.Color.Transparent;
            this.ChkVentasFacturas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkVentasFacturas.Location = new System.Drawing.Point(409, 211);
            this.ChkVentasFacturas.Name = "ChkVentasFacturas";
            this.ChkVentasFacturas.Size = new System.Drawing.Size(285, 23);
            this.ChkVentasFacturas.TabIndex = 23;
            this.ChkVentasFacturas.Text = "Ventas - Realización de Facturas";
            this.ChkVentasFacturas.UseVisualStyleBackColor = false;
            // 
            // ChkVentasDirectas
            // 
            this.ChkVentasDirectas.AutoSize = true;
            this.ChkVentasDirectas.BackColor = System.Drawing.Color.Transparent;
            this.ChkVentasDirectas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkVentasDirectas.Location = new System.Drawing.Point(409, 182);
            this.ChkVentasDirectas.Name = "ChkVentasDirectas";
            this.ChkVentasDirectas.Size = new System.Drawing.Size(223, 23);
            this.ChkVentasDirectas.TabIndex = 22;
            this.ChkVentasDirectas.Text = "Ventas - Ventas Directas";
            this.ChkVentasDirectas.UseVisualStyleBackColor = false;
            // 
            // ChkVentasBuscarProformas
            // 
            this.ChkVentasBuscarProformas.AutoSize = true;
            this.ChkVentasBuscarProformas.BackColor = System.Drawing.Color.Transparent;
            this.ChkVentasBuscarProformas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkVentasBuscarProformas.Location = new System.Drawing.Point(409, 153);
            this.ChkVentasBuscarProformas.Name = "ChkVentasBuscarProformas";
            this.ChkVentasBuscarProformas.Size = new System.Drawing.Size(223, 23);
            this.ChkVentasBuscarProformas.TabIndex = 21;
            this.ChkVentasBuscarProformas.Text = "Ventas - Buscar Proforma";
            this.ChkVentasBuscarProformas.UseVisualStyleBackColor = false;
            this.ChkVentasBuscarProformas.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // ChkVentasCrearProforma
            // 
            this.ChkVentasCrearProforma.AutoSize = true;
            this.ChkVentasCrearProforma.BackColor = System.Drawing.Color.Transparent;
            this.ChkVentasCrearProforma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkVentasCrearProforma.Location = new System.Drawing.Point(409, 124);
            this.ChkVentasCrearProforma.Name = "ChkVentasCrearProforma";
            this.ChkVentasCrearProforma.Size = new System.Drawing.Size(217, 23);
            this.ChkVentasCrearProforma.TabIndex = 20;
            this.ChkVentasCrearProforma.Text = "Ventas - Crear Proforma";
            this.ChkVentasCrearProforma.UseVisualStyleBackColor = false;
            this.ChkVentasCrearProforma.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // ChkContratosRealizarFactura
            // 
            this.ChkContratosRealizarFactura.AutoSize = true;
            this.ChkContratosRealizarFactura.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosRealizarFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosRealizarFactura.Location = new System.Drawing.Point(48, 433);
            this.ChkContratosRealizarFactura.Name = "ChkContratosRealizarFactura";
            this.ChkContratosRealizarFactura.Size = new System.Drawing.Size(329, 23);
            this.ChkContratosRealizarFactura.TabIndex = 19;
            this.ChkContratosRealizarFactura.Text = "Contratos - Realizar Factura Por Retiro";
            this.ChkContratosRealizarFactura.UseVisualStyleBackColor = false;
            // 
            // ChkContratosRetiroServicios
            // 
            this.ChkContratosRetiroServicios.AutoSize = true;
            this.ChkContratosRetiroServicios.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosRetiroServicios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosRetiroServicios.Location = new System.Drawing.Point(48, 404);
            this.ChkContratosRetiroServicios.Name = "ChkContratosRetiroServicios";
            this.ChkContratosRetiroServicios.Size = new System.Drawing.Size(264, 23);
            this.ChkContratosRetiroServicios.TabIndex = 18;
            this.ChkContratosRetiroServicios.Text = "Contratos - Retiro de Servicios";
            this.ChkContratosRetiroServicios.UseVisualStyleBackColor = false;
            // 
            // ChkContratosInformacionGeneral
            // 
            this.ChkContratosInformacionGeneral.AutoSize = true;
            this.ChkContratosInformacionGeneral.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosInformacionGeneral.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosInformacionGeneral.Location = new System.Drawing.Point(48, 375);
            this.ChkContratosInformacionGeneral.Name = "ChkContratosInformacionGeneral";
            this.ChkContratosInformacionGeneral.Size = new System.Drawing.Size(286, 23);
            this.ChkContratosInformacionGeneral.TabIndex = 17;
            this.ChkContratosInformacionGeneral.Text = "Contratos - Información General";
            this.ChkContratosInformacionGeneral.UseVisualStyleBackColor = false;
            // 
            // ChkContratosRetirados
            // 
            this.ChkContratosRetirados.AutoSize = true;
            this.ChkContratosRetirados.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosRetirados.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosRetirados.Location = new System.Drawing.Point(48, 346);
            this.ChkContratosRetirados.Name = "ChkContratosRetirados";
            this.ChkContratosRetirados.Size = new System.Drawing.Size(282, 23);
            this.ChkContratosRetirados.TabIndex = 16;
            this.ChkContratosRetirados.Text = "Contratos - Contratos Retirados";
            this.ChkContratosRetirados.UseVisualStyleBackColor = false;
            // 
            // ChkContratosGestionCuotas
            // 
            this.ChkContratosGestionCuotas.AutoSize = true;
            this.ChkContratosGestionCuotas.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosGestionCuotas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosGestionCuotas.Location = new System.Drawing.Point(48, 317);
            this.ChkContratosGestionCuotas.Name = "ChkContratosGestionCuotas";
            this.ChkContratosGestionCuotas.Size = new System.Drawing.Size(270, 23);
            this.ChkContratosGestionCuotas.TabIndex = 15;
            this.ChkContratosGestionCuotas.Text = "Contratos - Gestión de Cuotas";
            this.ChkContratosGestionCuotas.UseVisualStyleBackColor = false;
            // 
            // ChkContratosCrearProforma
            // 
            this.ChkContratosCrearProforma.AutoSize = true;
            this.ChkContratosCrearProforma.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosCrearProforma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosCrearProforma.Location = new System.Drawing.Point(48, 259);
            this.ChkContratosCrearProforma.Name = "ChkContratosCrearProforma";
            this.ChkContratosCrearProforma.Size = new System.Drawing.Size(242, 23);
            this.ChkContratosCrearProforma.TabIndex = 14;
            this.ChkContratosCrearProforma.Text = "Contratos - Crear Proforma";
            this.ChkContratosCrearProforma.UseVisualStyleBackColor = false;
            // 
            // ChkContratosBuscarProformas
            // 
            this.ChkContratosBuscarProformas.AutoSize = true;
            this.ChkContratosBuscarProformas.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosBuscarProformas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosBuscarProformas.Location = new System.Drawing.Point(48, 288);
            this.ChkContratosBuscarProformas.Name = "ChkContratosBuscarProformas";
            this.ChkContratosBuscarProformas.Size = new System.Drawing.Size(248, 23);
            this.ChkContratosBuscarProformas.TabIndex = 13;
            this.ChkContratosBuscarProformas.Text = "Contratos - Buscar Proforma";
            this.ChkContratosBuscarProformas.UseVisualStyleBackColor = false;
            // 
            // ChkContratosCrearContratos
            // 
            this.ChkContratosCrearContratos.AutoSize = true;
            this.ChkContratosCrearContratos.BackColor = System.Drawing.Color.Transparent;
            this.ChkContratosCrearContratos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratosCrearContratos.Location = new System.Drawing.Point(48, 230);
            this.ChkContratosCrearContratos.Name = "ChkContratosCrearContratos";
            this.ChkContratosCrearContratos.Size = new System.Drawing.Size(251, 23);
            this.ChkContratosCrearContratos.TabIndex = 12;
            this.ChkContratosCrearContratos.Text = "Contratos - Crear Contratos";
            this.ChkContratosCrearContratos.UseVisualStyleBackColor = false;
            // 
            // ChkCatalogoProveedores
            // 
            this.ChkCatalogoProveedores.AutoSize = true;
            this.ChkCatalogoProveedores.BackColor = System.Drawing.Color.Transparent;
            this.ChkCatalogoProveedores.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkCatalogoProveedores.Location = new System.Drawing.Point(48, 156);
            this.ChkCatalogoProveedores.Name = "ChkCatalogoProveedores";
            this.ChkCatalogoProveedores.Size = new System.Drawing.Size(218, 23);
            this.ChkCatalogoProveedores.TabIndex = 11;
            this.ChkCatalogoProveedores.Text = "Catalogo -  Proveedores";
            this.ChkCatalogoProveedores.UseVisualStyleBackColor = false;
            // 
            // ChkCatalogoClientes
            // 
            this.ChkCatalogoClientes.AutoSize = true;
            this.ChkCatalogoClientes.BackColor = System.Drawing.Color.Transparent;
            this.ChkCatalogoClientes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkCatalogoClientes.Location = new System.Drawing.Point(48, 127);
            this.ChkCatalogoClientes.Name = "ChkCatalogoClientes";
            this.ChkCatalogoClientes.Size = new System.Drawing.Size(188, 23);
            this.ChkCatalogoClientes.TabIndex = 10;
            this.ChkCatalogoClientes.Text = "Catalogo -  Clientes";
            this.ChkCatalogoClientes.UseVisualStyleBackColor = false;
            // 
            // ChkOpciones
            // 
            this.ChkOpciones.AutoSize = true;
            this.ChkOpciones.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkOpciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkOpciones.Location = new System.Drawing.Point(839, 319);
            this.ChkOpciones.Name = "ChkOpciones";
            this.ChkOpciones.Size = new System.Drawing.Size(103, 23);
            this.ChkOpciones.TabIndex = 9;
            this.ChkOpciones.Text = "Opciones";
            this.ChkOpciones.UseVisualStyleBackColor = false;
            this.ChkOpciones.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.ChkOpciones.Click += new System.EventHandler(this.ChkOpciones_Click);
            // 
            // ChkSeguridad
            // 
            this.ChkSeguridad.AutoSize = true;
            this.ChkSeguridad.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkSeguridad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkSeguridad.Location = new System.Drawing.Point(834, 191);
            this.ChkSeguridad.Name = "ChkSeguridad";
            this.ChkSeguridad.Size = new System.Drawing.Size(108, 23);
            this.ChkSeguridad.TabIndex = 8;
            this.ChkSeguridad.Text = "Seguridad";
            this.ChkSeguridad.UseVisualStyleBackColor = false;
            this.ChkSeguridad.CheckedChanged += new System.EventHandler(this.ChkSeguridad_CheckedChanged);
            this.ChkSeguridad.Click += new System.EventHandler(this.ChkSeguridad_Click);
            // 
            // ChkPersonal
            // 
            this.ChkPersonal.AutoSize = true;
            this.ChkPersonal.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkPersonal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkPersonal.Location = new System.Drawing.Point(834, 102);
            this.ChkPersonal.Name = "ChkPersonal";
            this.ChkPersonal.Size = new System.Drawing.Size(93, 23);
            this.ChkPersonal.TabIndex = 7;
            this.ChkPersonal.Text = "Personal";
            this.ChkPersonal.UseVisualStyleBackColor = false;
            this.ChkPersonal.CheckedChanged += new System.EventHandler(this.ChkPersonal_CheckedChanged);
            this.ChkPersonal.Click += new System.EventHandler(this.ChkPersonal_Click);
            // 
            // ChkCaja
            // 
            this.ChkCaja.AutoSize = true;
            this.ChkCaja.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkCaja.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkCaja.Location = new System.Drawing.Point(389, 372);
            this.ChkCaja.Name = "ChkCaja";
            this.ChkCaja.Size = new System.Drawing.Size(67, 23);
            this.ChkCaja.TabIndex = 6;
            this.ChkCaja.Text = "Caja";
            this.ChkCaja.UseVisualStyleBackColor = false;
            this.ChkCaja.CheckedChanged += new System.EventHandler(this.ChkCaja_CheckedChanged);
            this.ChkCaja.Click += new System.EventHandler(this.ChkCaja_Click);
            // 
            // ChkInventario
            // 
            this.ChkInventario.AutoSize = true;
            this.ChkInventario.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkInventario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkInventario.Location = new System.Drawing.Point(389, 273);
            this.ChkInventario.Name = "ChkInventario";
            this.ChkInventario.Size = new System.Drawing.Size(109, 23);
            this.ChkInventario.TabIndex = 5;
            this.ChkInventario.Text = "Inventario";
            this.ChkInventario.UseVisualStyleBackColor = false;
            this.ChkInventario.CheckedChanged += new System.EventHandler(this.ChkInventario_CheckedChanged);
            this.ChkInventario.Click += new System.EventHandler(this.ChkInventario_Click);
            // 
            // ChkVentas
            // 
            this.ChkVentas.AutoSize = true;
            this.ChkVentas.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkVentas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkVentas.Location = new System.Drawing.Point(389, 95);
            this.ChkVentas.Name = "ChkVentas";
            this.ChkVentas.Size = new System.Drawing.Size(84, 23);
            this.ChkVentas.TabIndex = 4;
            this.ChkVentas.Text = "Ventas";
            this.ChkVentas.UseVisualStyleBackColor = false;
            this.ChkVentas.Click += new System.EventHandler(this.ChkVentas_Click);
            // 
            // ChkContratos
            // 
            this.ChkContratos.AutoSize = true;
            this.ChkContratos.BackColor = System.Drawing.Color.Gainsboro;
            this.ChkContratos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkContratos.Location = new System.Drawing.Point(29, 201);
            this.ChkContratos.Name = "ChkContratos";
            this.ChkContratos.Size = new System.Drawing.Size(109, 23);
            this.ChkContratos.TabIndex = 3;
            this.ChkContratos.Text = "Contratos";
            this.ChkContratos.UseVisualStyleBackColor = false;
            this.ChkContratos.Click += new System.EventHandler(this.ChkContratos_Click);
            // 
            // ChkCatalogos
            // 
            this.ChkCatalogos.AutoSize = true;
            this.ChkCatalogos.BackColor = System.Drawing.Color.LightGray;
            this.ChkCatalogos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkCatalogos.Location = new System.Drawing.Point(29, 95);
            this.ChkCatalogos.Name = "ChkCatalogos";
            this.ChkCatalogos.Size = new System.Drawing.Size(112, 23);
            this.ChkCatalogos.TabIndex = 2;
            this.ChkCatalogos.Text = "Catalogos";
            this.ChkCatalogos.UseVisualStyleBackColor = false;
            this.ChkCatalogos.Click += new System.EventHandler(this.ChkCatalogos_Click);
            // 
            // TbTitulosGenerales
            // 
            this.TbTitulosGenerales.AutoSize = true;
            this.TbTitulosGenerales.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Italic);
            this.TbTitulosGenerales.Location = new System.Drawing.Point(30, 41);
            this.TbTitulosGenerales.Name = "TbTitulosGenerales";
            this.TbTitulosGenerales.Size = new System.Drawing.Size(381, 28);
            this.TbTitulosGenerales.TabIndex = 1;
            this.TbTitulosGenerales.Text = "Permisos de Acceso a Módulos";
            // 
            // TIBuscar
            // 
            this.TIBuscar.Controls.Add(this.BtnModificar);
            this.TIBuscar.Controls.Add(this.BtnCrear);
            this.TIBuscar.Controls.Add(this.BtnConfigurar);
            this.TIBuscar.Controls.Add(this.BtnBloquear);
            this.TIBuscar.Controls.Add(this.LvRol);
            this.TIBuscar.Controls.Add(this.BtnBuscarPermisos);
            this.TIBuscar.Controls.Add(this.TbTituloGenerales);
            this.TIBuscar.Controls.Add(this.TxtBuscar);
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
            this.BtnModificar.Location = new System.Drawing.Point(792, 235);
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
            this.BtnCrear.Location = new System.Drawing.Point(792, 180);
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
            this.BtnConfigurar.Location = new System.Drawing.Point(792, 294);
            this.BtnConfigurar.Name = "BtnConfigurar";
            this.BtnConfigurar.Size = new System.Drawing.Size(146, 42);
            this.BtnConfigurar.TabIndex = 55;
            this.BtnConfigurar.Text = "Configurar";
            this.BtnConfigurar.UseVisualStyleBackColor = false;
            this.BtnConfigurar.Click += new System.EventHandler(this.BtnConfigurar_Click);
            // 
            // BtnBloquear
            // 
            this.BtnBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBloquear.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Italic);
            this.BtnBloquear.Location = new System.Drawing.Point(792, 352);
            this.BtnBloquear.Name = "BtnBloquear";
            this.BtnBloquear.Size = new System.Drawing.Size(146, 42);
            this.BtnBloquear.TabIndex = 54;
            this.BtnBloquear.Text = "Bloquear";
            this.BtnBloquear.UseVisualStyleBackColor = true;
            this.BtnBloquear.Click += new System.EventHandler(this.BtnBloquear_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LvRol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LvRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rol});
            this.LvRol.EnableHeadersVisualStyles = false;
            this.LvRol.Location = new System.Drawing.Point(38, 180);
            this.LvRol.MultiSelect = false;
            this.LvRol.Name = "LvRol";
            this.LvRol.ReadOnly = true;
            this.LvRol.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LvRol.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LvRol.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.LvRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LvRol.Size = new System.Drawing.Size(738, 312);
            this.LvRol.TabIndex = 53;
            // 
            // Rol
            // 
            this.Rol.DataPropertyName = "Rol";
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            this.Rol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BtnBuscarPermisos
            // 
            this.BtnBuscarPermisos.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Italic);
            this.BtnBuscarPermisos.Location = new System.Drawing.Point(523, 106);
            this.BtnBuscarPermisos.Name = "BtnBuscarPermisos";
            this.BtnBuscarPermisos.Size = new System.Drawing.Size(127, 42);
            this.BtnBuscarPermisos.TabIndex = 1;
            this.BtnBuscarPermisos.Text = "Buscar";
            this.BtnBuscarPermisos.UseVisualStyleBackColor = true;
            this.BtnBuscarPermisos.Click += new System.EventHandler(this.BtnBuscarPermisos_Click);
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
            // TxtBuscar
            // 
            this.TxtBuscar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TxtBuscar.BorderColor = System.Drawing.Color.Gray;
            this.TxtBuscar.BorderFocusColor = System.Drawing.Color.Blue;
            this.TxtBuscar.BorderRadius = 10;
            this.TxtBuscar.BorderSize = 1;
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.TxtBuscar.Location = new System.Drawing.Point(38, 108);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBuscar.Multilinea = false;
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtBuscar.PasswordChar = false;
            this.TxtBuscar.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.TxtBuscar.PlaceHolderText = "Buscar...";
            this.TxtBuscar.Size = new System.Drawing.Size(478, 40);
            this.TxtBuscar.TabIndex = 52;
            this.TxtBuscar.Texts = "";
            this.TxtBuscar.UnderLineFlat = false;
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
            // ChkRetiroVentas
            // 
            this.ChkRetiroVentas.AutoSize = true;
            this.ChkRetiroVentas.BackColor = System.Drawing.Color.Transparent;
            this.ChkRetiroVentas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.ChkRetiroVentas.Location = new System.Drawing.Point(409, 239);
            this.ChkRetiroVentas.Name = "ChkRetiroVentas";
            this.ChkRetiroVentas.Size = new System.Drawing.Size(229, 23);
            this.ChkRetiroVentas.TabIndex = 57;
            this.ChkRetiroVentas.Text = "Ventas - Retiro de Ventas";
            this.ChkRetiroVentas.UseVisualStyleBackColor = false;
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
            this.TIGeneral.ResumeLayout(false);
            this.TIGeneral.PerformLayout();
            this.TIBuscar.ResumeLayout(false);
            this.TIBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LvRol)).EndInit();
            this.TICrearRol.ResumeLayout(false);
            this.TICrearRol.PerformLayout();
            this.PnlTitulo.ResumeLayout(false);
            this.PnlTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer GridPermisos;
        private System.Windows.Forms.Panel PnlTitulo;
        public System.Windows.Forms.TabControl TCMain;
        public System.Windows.Forms.TabPage TIGeneral;
        public System.Windows.Forms.TabPage TIBuscar;
        private System.Windows.Forms.Label TbTituloGenerales;
        private System.Windows.Forms.Button BtnBuscarPermisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        public System.Windows.Forms.Label TbTitulo;
        public System.Windows.Forms.DataGridView LvRol;
        public Controladores.LoginUserControl TxtBuscar;
        private System.Windows.Forms.Button BtnBloquear;
        private System.Windows.Forms.Button BtnConfigurar;
        public System.Windows.Forms.Label TbTitulosGenerales;
        public System.Windows.Forms.CheckBox ChkContratosCrearContratos;
        public System.Windows.Forms.CheckBox ChkCatalogoProveedores;
        public System.Windows.Forms.CheckBox ChkCatalogoClientes;
        public System.Windows.Forms.CheckBox ChkVentasCrearProforma;
        public System.Windows.Forms.CheckBox ChkContratosRealizarFactura;
        public System.Windows.Forms.CheckBox ChkContratosRetiroServicios;
        public System.Windows.Forms.CheckBox ChkContratosInformacionGeneral;
        public System.Windows.Forms.CheckBox ChkContratosRetirados;
        public System.Windows.Forms.CheckBox ChkContratosGestionCuotas;
        public System.Windows.Forms.CheckBox ChkContratosCrearProforma;
        public System.Windows.Forms.CheckBox ChkContratosBuscarProformas;
        public System.Windows.Forms.CheckBox ChkVentasBuscarProformas;
        public System.Windows.Forms.CheckBox ChkVentasFacturas;
        public System.Windows.Forms.CheckBox ChkVentasDirectas;
        public System.Windows.Forms.CheckBox ChkInventarioTipoProducto;
        public System.Windows.Forms.CheckBox ChkInventarioServicios;
        public System.Windows.Forms.CheckBox ChkSeguridadUsuario;
        public System.Windows.Forms.CheckBox ChkSeguridadAuditoria;
        public System.Windows.Forms.CheckBox ChkCajaHistorialRecibos;
        public System.Windows.Forms.CheckBox ChkCajaReciboOficial;
        public System.Windows.Forms.CheckBox ChkOpcionesTipoCambio;
        public System.Windows.Forms.CheckBox ChkSeguridadPermisos;
        public System.Windows.Forms.CheckBox ChkCatalogos;
        public System.Windows.Forms.CheckBox ChkContratos;
        public System.Windows.Forms.CheckBox ChkInventario;
        public System.Windows.Forms.CheckBox ChkVentas;
        public System.Windows.Forms.CheckBox ChkCaja;
        public System.Windows.Forms.CheckBox ChkPersonal;
        public System.Windows.Forms.CheckBox ChkSeguridad;
        public System.Windows.Forms.CheckBox ChkOpciones;
        private System.Windows.Forms.Button BtnCancelarGenerales;
        private System.Windows.Forms.Button BtnGuardarGenerales;
        private System.Windows.Forms.TabPage TICrearRol;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardarRol;
        private System.Windows.Forms.Button BtnCancelarRol;
        public System.Windows.Forms.TextBox TxtNombrePermiso;
        public System.Windows.Forms.CheckBox ChkRetiroVentas;
    }
}