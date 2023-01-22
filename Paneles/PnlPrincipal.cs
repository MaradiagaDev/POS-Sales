using System;
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
using NeoCobranza.PnlOpc;

namespace NeoCobranza.Paneles
{
    public partial class PnlPrincipal : Form
    {
        public Conexion conexion;
        public PnlBuscarProforma pnlBuscarProforma;
        public BuscarContrato buscarContrato;
        public CSeguridad cSeguridad;
        public PnlPrincipal(string user,Conexion conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            LblUsuario.Text = user;


            cSeguridad = new CSeguridad(conexion);
        }

        
        private void PnlPrincipal_Load(object sender, EventArgs e)
        {
          
            
          
            
            
            
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
        private void especialButton2_Click(object sender, EventArgs e)
        {
           
            DesplegableContrato.Show(especialButton2, especialButton2.Width,0);
        }

        private void especialButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void crearContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


            PnlContrato pnlContrato = new PnlContrato(conexion);
            limpiar();
            pnlContrato.TopLevel = false;
            
            PnlCentral.Controls.Add(pnlContrato);
            
            pnlContrato.Show();
        }

        private void modificarEstadoDelContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
       

        }

        private void BtnVentasDirectas_Click(object sender, EventArgs e)
        {
            MenuVentasDirectas.Show(BtnVentasDirectas,BtnVentasDirectas.Width,0 );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCrearProforma_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlProforma pnlProforma = new PnlProforma(conexion);
            pnlProforma.TopLevel = false;
            PnlCentral.Controls.Add(pnlProforma);


            pnlProforma.Show();
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (cSeguridad.MostrarRol(LblUsuario.Text) == "SuperAdmin" || cSeguridad.MostrarRol(LblUsuario.Text) == "Gerente" || cSeguridad.MostrarRol(LblUsuario.Text) == "Informatico")
            {
                MenuOpc.Show(BtnOpciones, BtnOpciones.Width, 0);

            }
            else
            {
                MessageBox.Show("Su usuario no tiene permiso para realizar esta accion", "Alerta construccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
        }

        private void configTipoDeCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            limpiar();
            PnlTasaCambio pnlTasaCambio = new PnlTasaCambio(conexion);
            pnlTasaCambio.TopLevel = false;
            PnlCentral.Controls.Add(pnlTasaCambio);

            pnlTasaCambio.Show();


        }

        private void BtnbuscarProformaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            limpiar();
            pnlBuscarProforma = new PnlBuscarProforma(conexion);
            AddOwnedForm(pnlBuscarProforma);
            pnlBuscarProforma.TopLevel = false;
            

            PnlCentral.Controls.Add(pnlBuscarProforma);
            pnlBuscarProforma.Show();
        }

        private void ataudesYServiciosVentasDirectasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlModificarServicios pnlModificarServicios = new PnlModificarServicios(conexion);
            pnlModificarServicios.TopLevel = false;
            PnlCentral.Controls.Add(pnlModificarServicios);
            pnlModificarServicios.Show();


        }

        private void DesplegableContrato_Opening(object sender, CancelEventArgs e)
        {
            limpiar();
            
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = Owner as Form1;
            conexion.connect.Close();
            form1.Show();


            
            this.Close();


        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            limpiar();
           MenuCatalogo.Show(btnCatalogos, btnCatalogos.Width, 0);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            limpiar();
            PnlCatalogoClientes pnlCatalogoClientes = new PnlCatalogoClientes(conexion);
            pnlCatalogoClientes.TopLevel = false;
            PnlCentral.Controls.Add(pnlCatalogoClientes);
            pnlCatalogoClientes.Show();
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            if(cSeguridad.MostrarRol(LblUsuario.Text)=="SuperAdmin"|| cSeguridad.MostrarRol(LblUsuario.Text) == "Gerente"|| cSeguridad.MostrarRol(LblUsuario.Text) == "Informatico")
            {
                MenuSeguridad.Show(btnSeguridad, btnSeguridad.Width, 0);

            }
            else
            {
                MessageBox.Show("Su usuario no tiene permiso para realizar esta accion", "Alerta construccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

           




        }

        private void auditoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PnlPrincipalAuditorias pnlAuditorias = new PnlPrincipalAuditorias(conexion);
            limpiar();
            pnlAuditorias.TopLevel = false;

            PnlCentral.Controls.Add(pnlAuditorias);

            pnlAuditorias.Show();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreacionUsuario creacionU = new CreacionUsuario(conexion);
            limpiar();
            creacionU.TopLevel = false;

            PnlCentral.Controls.Add(creacionU);

            creacionU.Show();
        }

        private void buscarContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            limpiar();
            buscarContrato = new BuscarContrato(conexion);
            AddOwnedForm(buscarContrato);
            buscarContrato.TopLevel = false;


            PnlCentral.Controls.Add(buscarContrato);
            buscarContrato.Show();
        }

        private void crearProformaDeContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlProformaContrato pnlProformaContrato = new PnlProformaContrato(conexion);
            pnlProformaContrato.TopLevel = false;
            PnlCentral.Controls.Add(pnlProformaContrato);
            pnlProformaContrato.Show();

        }

        private void ataudesContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlModificacionesServiciosContrato pnlModificacionesServiciosContrato = new PnlModificacionesServiciosContrato(conexion);
            pnlModificacionesServiciosContrato.TopLevel = false;
            PnlCentral.Controls.Add(pnlModificacionesServiciosContrato);
            pnlModificacionesServiciosContrato.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCatalogoProveedores pnlCatalogoProveedores = new PnlCatalogoProveedores(conexion);
            pnlCatalogoProveedores.TopLevel = false;
            PnlCentral.Controls.Add(pnlCatalogoProveedores);
            pnlCatalogoProveedores.Show();
        }

        private void BtnBindarServicio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Panel aun en construccion. Espere por actualizaciones", "Alerta construccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            limpiar();
            MenuInventario.Show(BtnInventario, BtnInventario.Width, 0);

            

        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Panel aun en construccion. Espere por actualizaciones", "Alerta construccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        

        private void inventarioDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlCompras pnlCompras = new PnlCompras(conexion);
            AddOwnedForm(pnlCompras);
            pnlCompras.TopLevel = false;


            PnlCentral.Controls.Add(pnlCompras);
            pnlCompras.Show();
        }

        private void otrasModificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlModificacionesServiciosContrato pnlModificacionesServiciosContrato = new PnlModificacionesServiciosContrato(conexion);
            pnlModificacionesServiciosContrato.TopLevel = false;
            PnlCentral.Controls.Add(pnlModificacionesServiciosContrato);
            pnlModificacionesServiciosContrato.Show();
        }

        private void ventasDirectasDeAtaudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlVentas directas = new PnlVentas(conexion);
            directas.TopLevel = false;
            PnlCentral.Controls.Add(directas);
            directas.Show();
        }

        private void registroDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlHistorialVenta pnlHistorialVenta = new PnlHistorialVenta(conexion);
            AddOwnedForm(pnlHistorialVenta);
            pnlHistorialVenta.TopLevel = false;
            PnlCentral.Controls.Add(pnlHistorialVenta);
            pnlHistorialVenta.Show();
        }

        private void especialButton4_Click(object sender, EventArgs e)
        {
            limpiar();
            MenuCaja.Show(btnCaja, btnCaja.Width, 0);


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
            PnlCentral.Controls.Add(pnlhistorial);


            pnlhistorial.Show();
        }

        private void pagoDeCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlPagoGeneral pnlGeneral = new PnlPagoGeneral(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);


            pnlGeneral.Show();
        }

        private void contratosRetiradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlRetirado pnlGeneral = new PnlRetirado(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);


            pnlGeneral.Show();
        }

        private void informacionGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            PnlGeneralContrato pnlGeneral = new PnlGeneralContrato(conexion);
            AddOwnedForm(pnlGeneral);
            pnlGeneral.TopLevel = false;
            PnlCentral.Controls.Add(pnlGeneral);


            pnlGeneral.Show();
        }
    }
}
