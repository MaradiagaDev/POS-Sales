using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles_Auditorias
{
    public partial class GestionPermisos : Form
    {

        VMPermisosUsuario vMPermisosUsuario = new VMPermisosUsuario();

        public GestionPermisos()
        {
            InitializeComponent();
        }

        private void GestionPermisos_Load(object sender, EventArgs e)
        {
            vMPermisosUsuario.InitGestionPermisosUsuario(this);
        }

        private void BtnBuscarPermisos_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.FuncionesPrincipales(this, "Buscar");
        }

        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.FuncionesPrincipales(this, "Bloquear");
        }

        private void BtnConfigurar_Click(object sender, EventArgs e)
        {
            if(LvRol.SelectedRows.Count > 0) {

                vMPermisosUsuario.ConfigUI(this, "Generales");
            }
            else
            {
                MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TIGeneral_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkSeguridad_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkPersonal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkCaja_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkInventario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkCatalogos_Click(object sender, EventArgs e)
        {
            if(ChkCatalogos.Checked)
            {
                ChkCatalogoClientes.Enabled = true;
                ChkCatalogoProveedores.Enabled = true;
            }
            else
            {
                ChkCatalogoClientes.Enabled = false;
                ChkCatalogoProveedores.Enabled = false;
            }
        }

        private void ChkContratos_Click(object sender, EventArgs e)
        {
            if(ChkContratos.Checked)
            {
                ChkContratosBuscarProformas.Enabled = true;
                ChkContratosCrearProforma.Enabled = true;
                ChkContratosCrearContratos.Enabled = true;
                ChkContratosGestionCuotas.Enabled = true;
                ChkContratosInformacionGeneral.Enabled = true;
                ChkContratosRetirados.Enabled = true;
                ChkContratosRealizarFactura.Enabled = true;
                ChkContratosRetiroServicios.Enabled = true;
            }
            else
            {
                ChkContratosBuscarProformas.Enabled = false;
                ChkContratosCrearProforma.Enabled = false;
                ChkContratosCrearContratos.Enabled = false;
                ChkContratosGestionCuotas.Enabled = false;
                ChkContratosInformacionGeneral.Enabled = false;
                ChkContratosRetirados.Enabled = false;
                ChkContratosRealizarFactura.Enabled = false;
                ChkContratosRetiroServicios.Enabled = false;

            }
        }

        private void ChkVentas_Click(object sender, EventArgs e)
        {
            if(ChkVentas.Checked)
            {
                ChkVentasBuscarProformas.Enabled = true;
                ChkVentasCrearProforma.Enabled=true;
                ChkVentasDirectas.Enabled = true;
                ChkVentasFacturas.Enabled = true;
                ChkRetiroVentas.Enabled = true;
            }
            else 
            {
                ChkVentasBuscarProformas.Enabled = false;
                ChkVentasCrearProforma.Enabled = false;
                ChkVentasDirectas.Enabled = false;
                ChkVentasFacturas.Enabled = false;
                ChkRetiroVentas.Enabled = false;
            }
        }

        private void ChkInventario_Click(object sender, EventArgs e)
        {
            if(ChkInventario.Checked)
            {
                ChkInventarioServicios.Enabled = true;
                ChkInventarioTipoProducto.Enabled = true;
            }
            else 
            {
                ChkInventarioServicios.Enabled = false;
                ChkInventarioTipoProducto.Enabled = false;
            }
        }

        private void ChkCaja_Click(object sender, EventArgs e)
        {
            if(ChkCaja.Checked)
            {
                ChkCajaHistorialRecibos.Enabled = true;
                ChkCajaReciboOficial.Enabled = true;
            }
            else 
            {
                ChkCajaHistorialRecibos.Enabled = false;
                ChkCajaReciboOficial.Enabled = false;
            }
        }

        private void ChkPersonal_Click(object sender, EventArgs e)
        {
            if(ChkPersonal.Checked)
            {

            }
            else 
            {
            }
        }

        private void ChkSeguridad_Click(object sender, EventArgs e)
        {
            if(ChkSeguridad.Checked)
            {
                ChkSeguridadAuditoria.Enabled = true;
                ChkSeguridadPermisos.Enabled = true;
                ChkSeguridadUsuario.Enabled = true;
            }
            else 
            {
                ChkSeguridadAuditoria.Enabled = false;
                ChkSeguridadPermisos.Enabled = false;
                ChkSeguridadUsuario.Enabled = false;
            }
        }

        private void ChkOpciones_Click(object sender, EventArgs e)
        {
            if (ChkOpciones.Checked)
            {
                ChkOpcionesTipoCambio.Enabled = true;
            }
            else
            {
                ChkOpcionesTipoCambio.Enabled = false;
            }
        }

        private void BtnCancelarGenerales_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "Buscar");
        }

        private void BtnGuardarGenerales_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.FuncionesPrincipales(this, "GuardarGenerales");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "CrearRol");
        }

        private void BtnCancelarRol_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.ConfigUI(this, "Buscar");
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (LvRol.SelectedRows.Count > 0)
            {

                vMPermisosUsuario.ConfigUI(this, "ActualizarRol");
            }
            else
            {
                MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnGuardarRol_Click(object sender, EventArgs e)
        {
            vMPermisosUsuario.VerificarRol(this);
        }
    }
}
