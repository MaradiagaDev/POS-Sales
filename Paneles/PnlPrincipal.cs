﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.Paneles_Auditorias;
using NeoCobranza.Paneles_Caja;
using NeoCobranza.Paneles_Contrato;
using NeoCobranza.Paneles_Venta;
using NeoCobranza.PnlInventario;
using System.Runtime.InteropServices;
using NeoCobranza.ViewModels;
using NeoCobranza.ModelsCobranza;
using System.Threading;
using NeoCobranza.Paneles_Venta.Informes;
using System.Windows.Forms.VisualStyles;
using NeoCobranza.PanelesHoteles;

namespace NeoCobranza.Paneles
{
    public partial class PnlPrincipal : Form
    {
        public Conexion conexion;
        public PnlBuscarProforma pnlBuscarProforma;
        public BuscarContrato buscarContrato;
        public CSeguridad cSeguridad;
        VMMenuPrincipal vMMenuPrincipal = new VMMenuPrincipal();

        //Variable de ancho para menu desplegable
        int ancho = 165;
        public PnlPrincipal()
        {
            InitializeComponent();
            LblUsuario.Text = Utilidades.Usuario;
            LblSucursal.Text = Utilidades.Sucursal;

            System.Windows.Forms.Timer Hora = new System.Windows.Forms.Timer();
            Hora.Tick += new EventHandler(EventoHora);
            Hora.Enabled = true;

            //cSeguridad = new CSeguridad(conexion);
        }

        private void EventoHora(Object ob, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            LblHora.Text = hoy.ToString("G");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wmsg,int wparam, int lparam);


        private void PnlPrincipal_Load(object sender, EventArgs e)
        {
            //UIUtilities.ConfigurarPanelPrincipal(PnlTitulo,LblTitulo,LblHora);

            //vMMenuPrincipal.InitModuloPrincipal(this);

            //SEGURIDAD


            if (!Utilidades.PermisosLevel(1, 1))
            {
                btnCatalogos.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 2))
            {
                BtnVentasDirectas.Visible = false;
                BtnVentaRapida.Visible = false;
                BtnAgenda.Visible = false;
                BtnMesas.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 3))
            {
                BtnInventario.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 4))
            {
                BtnCaja.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 5))
            {
                BtnReportes.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 6))
            {
                BtnOpciones.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 7))
            {
                btnSeguridad.Visible = false;
            }
            if (!Utilidades.PermisosLevel(1, 8))
            {
                BtnCatalogoGeneral.Visible = false;
            }

            //NIVEL DOS - CATALOGOS SUCURSAL
            if (!Utilidades.PermisosLevel(2, 1))
            {
                clientesToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 2))
            {
                BtnAlmacenes.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 3))
            {
                salasToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 21))
            {
                segmentaciónDeClientesToolStripMenuItem.Visible = false;
            }

            //NIVEL DOS - VENTAS
            if (!Utilidades.PermisosLevel(2, 4))
            {
                ventasDirectasDeAtaudesToolStripMenuItem.Visible = false;
                BtnVentaRapida.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 5))
            {
                BtnOrdenMesa.Visible = false;
                BtnMesas.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 6))
            {
                agendaToolStripMenuItem.Visible=false;
                BtnAgenda.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 7))
            {
                listaDeOrdenesActivasToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 8))
            {
                cuentasPorCobrarToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 9))
            {
                listaDeOrdenesFacturaToolStripMenuItem.Visible = false;
            }

            //NIVEL DOS - INVENTARIO
            if (!Utilidades.PermisosLevel(2, 10))
            {
                kardexToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 11))
            {
                trasladosDeProductoToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 12))
            {
                BtnCompras.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 13))
            {
                BtnAlertas.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 14))
            {
                inventarioEnSucursalesAlmacenesToolStripMenuItem.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 15))
            {
                BtnInventarioGeneral.Visible=false;
            }

            //Cierre de Caja
            if (!Utilidades.PermisosLevel(2, 20))
            {
                CierreCajaToolStripMenuItem.Visible=false;
            }

            //Sistema
            if (!Utilidades.PermisosLevel(2, 17))
            {
                configFacturaciónToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 18))
            {
                BtnTasaCambio.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 19))
            {
                datosDeLaEmpresaToolStripMenuItem.Visible = false;
            }

            //SEGURIDAD
            if (!Utilidades.PermisosLevel(2, 22))
            {
                revisionDeSeguridadToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 23))
            {
                auditoriasToolStripMenuItem.Visible = false;
            }

            //CATALOGO GENERAL
            if (!Utilidades.PermisosLevel(2, 24))
            {
                BtnProveedor.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 25))
            {
                BtnCargorizacion.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 26))
            {
                BtnSucursales.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 27))
            {
                BtnMotivoCancelacion.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 28))
            {
                BtnBancos.Visible = false;
                BtnBancosTarjeta.Visible=false;
            }
            if (!Utilidades.PermisosLevel(2, 29))
            {
                productosToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 30))
            {
                serviciosToolStripMenuItem.Visible = false;
            }
            if (!Utilidades.PermisosLevel(2, 31))
            {
                BtnBancosTarjeta.Visible = false;
            }
        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }
        public void limpiar()
        {
            if (PnlCentral.Controls.Count > 0)
            {
                PnlCentral.Controls.RemoveAt(0);
                
            }
        }


        private void especialButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres salir de la aplicación?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void crearContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            limpiar();
            PnlContrato pnlContrato = new PnlContrato(conexion);
            AddOwnedForm(pnlContrato);
            pnlContrato.TopLevel = false;
            pnlContrato.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlContrato);
            PnlCentral.Tag = pnlContrato;
            pnlContrato.Show();

        }

        private void BtnVentasDirectas_Click(object sender, EventArgs e)
        {
            MenuVentasDirectas.Show(BtnVentasDirectas,ancho,0 );
        }

        private void BtnCrearProforma_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlProforma pnlProforma = new PnlProforma(conexion);
            this.AddOwnedForm(pnlProforma);
            pnlProforma.TopLevel = false;
            pnlProforma.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlProforma);
            PnlCentral.Tag = pnlProforma;

            pnlProforma.Show();
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
                MenuOpc.Show(BtnOpciones, ancho, 0);
        }


        private void BtnbuscarProformaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            limpiar();
            pnlBuscarProforma = new PnlBuscarProforma(conexion);
            AddOwnedForm(pnlBuscarProforma);
            pnlBuscarProforma.TopLevel = false;
            pnlBuscarProforma.Dock = DockStyle.Fill;
            

            PnlCentral.Controls.Add(pnlBuscarProforma);
            PnlCentral.Tag = pnlBuscarProforma;
            pnlBuscarProforma.Show();
        }

        private void DesplegableContrato_Opening(object sender, CancelEventArgs e)
        {
            limpiar();
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            this.Close();

            frmLogin login = new frmLogin();
            login.Show(); // Muestra de nuevo el login
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            limpiar();
           MenuCatalogo.Show(btnCatalogos,ancho, 0);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            limpiar();
            PnlCatalogoClientes pnlCatalogoClientes = new PnlCatalogoClientes();
            pnlCatalogoClientes.TopLevel = false;
            pnlCatalogoClientes.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlCatalogoClientes);
            this.PnlCentral.Tag = pnlCatalogoClientes;
            pnlCatalogoClientes.Show();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
                MenuSeguridad.Show(btnSeguridad, ancho, 0);
        }

        private void auditoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreacionUsuario creacionU = new CreacionUsuario();
            limpiar();
            creacionU.TopLevel = false;
            creacionU.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(creacionU);

            creacionU.Show();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreacionUsuario creacionU = new CreacionUsuario();
            limpiar();
            creacionU.TopLevel = false;
            creacionU.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(creacionU);

            creacionU.Show();
        }

        private void buscarContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            buscarContrato = new BuscarContrato(conexion);
            AddOwnedForm(buscarContrato);
            buscarContrato.TopLevel = false;
            buscarContrato.Dock = DockStyle.Fill;

            PnlCentral.Controls.Add(buscarContrato);
            PnlCentral.Tag = buscarContrato;
            buscarContrato.Show();
        }

        private void crearProformaDeContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlProformaContrato pnlProformaContrato = new PnlProformaContrato(conexion);
            pnlProformaContrato.TopLevel = false;
            pnlProformaContrato.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlProformaContrato);
            PnlCentral.Tag = pnlProformaContrato;
            pnlProformaContrato.Show();

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            limpiar();
            MenuInventario.Show(BtnInventario, ancho, 0);
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ventasDirectasDeAtaudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlVentas directas = new PnlVentas("OrdenRapida", this, Utilidades.SucursalId);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(directas);
            directas.Visible = false;
            directas.Show();
            directas.Visible = true;

        }

        private void registroDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirMesas();
        }

        private void especialButton4_Click(object sender, EventArgs e)
        {
            limpiar();
            MenuCaja.Show(BtnCaja, ancho, 0);
        }

        private void reciboOficialDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlReciboOficialCaja pnlReciboOficial = new PnlReciboOficialCaja(conexion);
            pnlReciboOficial.TopLevel = false;
            PnlCentral.Controls.Add(pnlReciboOficial);
            pnlReciboOficial.Show();
        }

        private void realizacionDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlVentasFacturacion pnlVentasFact = new PnlVentasFacturacion(conexion);
            AddOwnedForm(pnlVentasFact);
            pnlVentasFact.TopLevel = false;
            PnlCentral.Controls.Add(pnlVentasFact);
           
            pnlVentasFact.Show();
        }

        private void historialDeRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlHistorialRecibos pnlhistorial = new PnlHistorialRecibos(conexion);
            AddOwnedForm(pnlhistorial);
            pnlhistorial.TopLevel = false;
            PnlCentral.Controls.Add(pnlhistorial);

            pnlhistorial.Show();
        }

        private void pagoDePrimeraCuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlPagoCuotas pnlhistorial = new PnlPagoCuotas(conexion);
            AddOwnedForm(pnlhistorial);
            pnlhistorial.TopLevel = false;
            pnlhistorial.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlhistorial);
            PnlCentral.Tag = pnlhistorial;

            pnlhistorial.Show();
        }

        private void pagoDeCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //limpiar();
            //PnlPagoGeneral pnlGeneral = new PnlPagoGeneral(conexion);
            //AddOwnedForm(pnlGeneral);
            //pnlGeneral.TopLevel = false;
            //pnlGeneral.Dock = DockStyle.Fill;
            //PnlCentral.Controls.Add(pnlGeneral);
            //PnlCentral.Tag = pnlGeneral;

            //pnlGeneral.Show();
        }

        private void contratosRetiradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlRetirado pnlGeneral = new PnlRetirado(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlGeneral);
            PnlCentral.Tag = pnlGeneral;

            pnlGeneral.Show();
        }

        private void informacionGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlGeneralContrato pnlGeneral = new PnlGeneralContrato(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlGeneral);
            PnlCentral.Tag = pnlGeneral;

            pnlGeneral.Show();
        }

        private void retiroDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlRetiroServicios pnlGeneral = new PnlRetiroServicios(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);

            pnlGeneral.Show();
        }

        private void realizarFacturaPorRetiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlFacturaContrato pnlGeneral = new PnlFacturaContrato(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);

            pnlGeneral.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 170)
            {
                MenuVertical.Width = 63;
                ancho = 60;
            }
            else
            {
                MenuVertical.Width = 170;
                ancho = 165;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }else if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
           
            ReleaseCapture();
             SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void especialButton4_Click_1(object sender, EventArgs e)
        {
            PnlAsistencia frm = new PnlAsistencia();
            frm.ShowDialog();
        }

        private void BtnCategoriasProductos_Click(object sender, EventArgs e)
        {
            
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnAlmacenes_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCatalogoAlmacenes pnlGeneral = new PnlCatalogoAlmacenes();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnCatalogoProductos_Click(object sender, EventArgs e)
        {
            
        }

        private void catalogoDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogosInventario pnlGeneral = new CatalogosInventario("Servicios");
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnConfigInventario_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlConfigInventario pnlGeneral = new PnlConfigInventario();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnInventarioGeneral_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlRevisionInventario pnlGeneral = new PnlRevisionInventario();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void inventarioEnSucursalesAlmacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlInventarioAlmacenes pnlGeneral = new PnlInventarioAlmacenes();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnMotivosCancelacion_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCatalogoBanco_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnTasaCambio_Click(object sender, EventArgs e)
        {
            limpiar();
            TasaCambio pnlGeneral = new TasaCambio();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnPromociones_Click(object sender, EventArgs e)
        {
            limpiar();
            Promociones pnlGeneral = new Promociones();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnTiposTarjetas_Click(object sender, EventArgs e)
        {
            
        }

        private void configFacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            ConfigFacturacion pnlGeneral = new ConfigFacturacion();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            limpiar();
            ComprasInventario pnlGeneral = new ComprasInventario();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnAlertas_Click(object sender, EventArgs e)
        {
            limpiar();
            AlertasInventario pnlGeneral = new AlertasInventario();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogoSalas pnlGeneral = new CatalogoSalas();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void datosDeLaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlEmpresa pnlGeneral = new PnlEmpresa();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            limpiar();
            ConsultaPrecio pnlGeneral = new ConsultaPrecio();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void trasladosDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlTrasladoProduco pnlGeneral = new PnlTrasladoProduco();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlKardx pnlGeneral = new PnlKardx();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void listaDeOrdenesActivasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            frmBusquedasOrdenes directas = new frmBusquedasOrdenes(this,"Lista");
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void BtnCatalogoGeneral_Click(object sender, EventArgs e)
        {
            DesplegableContrato.Show(BtnCatalogoGeneral, ancho, 0);
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCatalogoProveedores pnlCatalogoProveedores = new PnlCatalogoProveedores();
            pnlCatalogoProveedores.TopLevel = false;
            pnlCatalogoProveedores.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(pnlCatalogoProveedores);
            this.PnlCentral.Tag = pnlCatalogoProveedores;
            pnlCatalogoProveedores.Show();
        }

        private void BtnCargorizacion_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCatologoTiposServicios pnlGeneral = new PnlCatologoTiposServicios();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnMotivoCancelacion_Click(object sender, EventArgs e)
        {
            limpiar();
            CatologoMotivosCancelacion pnlGeneral = new CatologoMotivosCancelacion();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnBancos_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogoBancos pnlGeneral = new CatalogoBancos();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnBancosTarjeta_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogoTiposTarjeta pnlGeneral = new CatalogoTiposTarjeta();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void BtnSucursales_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCatalogoSucursales pnlGeneral = new PnlCatalogoSucursales();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogosInventario pnlGeneral = new CatalogosInventario("Productos");
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogosInventario pnlGeneral = new CatalogosInventario("Servicios");
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void cuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            frmBusquedasOrdenes directas = new frmBusquedasOrdenes(this, "ListaCredito");
            directas.TopLevel = false; // No es formulario de nivel superior
            directas.Dock = DockStyle.Fill; // Se ajusta al tamaño del contenedor
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void CierreCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCierreCuadreCaja directas = new PnlCierreCuadreCaja();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void BtnVentaRapida_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlVentas directas = new PnlVentas( "OrdenRapida",this, Utilidades.SucursalId);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(directas);
            directas.Visible = false;
            directas.Show();
            directas.Visible = true;
        }

        public void AbrirVenta(decimal orden,string sucursal,string mesa = "-",string idCliente = "0")
        {
            limpiar();
            PnlVentas directas = new PnlVentas("OrdenRapida",this,sucursal,orden,mesa,idCliente);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(directas);
            directas.Visible = false;
            directas.Show();
            directas.Visible = true;
        }
       
        public void AbrirListaVentas()
        {
            limpiar();
            frmBusquedasOrdenes directas = new frmBusquedasOrdenes(this, "Lista");
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        public void AbrirMesas()
        {
            limpiar();
            frmBusquedasMesas directas = new frmBusquedasMesas(this);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        public void AbrirProductos(decimal orden,string sucursal,string opc,bool dgi,bool alcaldia,string descuento)
        {
            limpiar();
            frmAgregarProductosServicios directas = new frmAgregarProductosServicios(this,orden,sucursal,opc,dgi,alcaldia,descuento);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void listaDeOrdenesFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            frmBusquedasOrdenes directas = new frmBusquedasOrdenes(this, "ListaPagadas");
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlAgenda directas = new PnlAgenda(this);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void revisionDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            GestionPermisos frm = new GestionPermisos();
            AddOwnedForm(frm);
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            PnlCentral.Controls.Add(frm);
            frm.Show();
            return;
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlAgenda directas = new PnlAgenda(this);
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void especialButton4_Click_2(object sender, EventArgs e)
        {
            AbrirMesas();
        }

        private void especialButton6_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlInformes directas = new PnlInformes();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void segmentaciónDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PnlSegmentación directas = new PnlSegmentación();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void MenuInventario_Opening(object sender, CancelEventArgs e)
        {

        }

        private void BtnListaVentasActivas_Click(object sender, EventArgs e)
        {
            limpiar();
            frmBusquedasOrdenes directas = new frmBusquedasOrdenes(this, "Lista");
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void BtnHoteleria_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlPrincipalHoteleria directas = new PnlPrincipalHoteleria();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void definiciónDeHabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCatalogoHabitaciones directas = new PnlCatalogoHabitaciones();
            directas.TopLevel = false;
            directas.Dock = DockStyle.Fill;
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void respaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlRespaldos pnlGeneral = new PnlRespaldos();
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }

        private void extrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            CatalogosInventario pnlGeneral = new CatalogosInventario("Adiciones");
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);
            pnlGeneral.Dock = DockStyle.Fill;
            PnlCentral.Tag = pnlGeneral;
            pnlGeneral.Show();
        }
    }
}
