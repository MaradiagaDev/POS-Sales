using NeoCobranza.ModelObjectCobranza;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCobranza.ViewModels
{
    public class VMMenuPrincipal
    {

        public void InitModuloPrincipal(PnlPrincipal frm)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Usuario usuario = db.Usuario.Where(u => u.IdUsuarios == VariablesEntorno.idUsuarioSesion).FirstOrDefault();

                RolUsuario rol = db.RolUsuario.Where(r => r.RolId.ToString() == usuario.Rol).FirstOrDefault();

                RolPermisos permisos = db.RolPermisos.Where(p => p.RolId == rol.RolId).FirstOrDefault();

                //Catalogos
                frm.btnCatalogos.Visible = (bool)permisos.Catalogos;
                frm.clientesToolStripMenuItem.Visible = (bool)permisos.CatalogoClientes;
                //frm.proveedoresToolStripMenuItem.Visible = (bool)permisos.CatalogoProveedores;

                //verificar no dejar el boton sin funcionamiento
                if (permisos.CatalogoClientes == false && permisos.CatalogoProveedores == false)
                {
                    frm.btnCatalogos.Visible = false;
                }

                //Contratos
              
                frm.BtnProveedor.Visible = (bool)permisos.ContratosCrearContratos;
                //frm.buscarContratoToolStripMenuItem.Visible = (bool)permisos.ContratosBuscarProforma;
                //frm.crearProformaDeContratoToolStripMenuItem.Visible = (bool)permisos.ContratosCrearContratos;
                //frm.gestionDeCuotasToolStripMenuItem.Visible = (bool)permisos.ContratosGestionCuotas;
                //frm.contratosRetiradosToolStripMenuItem.Visible = (bool)permisos.ContratosContratosRetirados;
                //frm.informacionGeneralToolStripMenuItem.Visible = (bool)permisos.ContratosInformacionGeneral;
                //frm.retiroDeServiciosToolStripMenuItem.Visible = (bool)permisos.ContratosRetiroServicios;
                //frm.realizarFacturaPorRetiroToolStripMenuItem.Visible = (bool)permisos.ContratosFactura;

                //verificar no dejar el boton sin funcionamiento
                if (permisos.ContratosBuscarProforma == false &&
                    permisos.ContratosCrearProforma == false &&
                    permisos.ContratosCrearContratos == false &&
                    permisos.ContratosGestionCuotas == false &&
                    permisos.ContratosInformacionGeneral == false &&
                    permisos.ContratosContratosRetirados == false &&
                    permisos.ContratosFactura == false &&
                    permisos.ContratosRetiroServicios == false)
                {

                }

                //Ventas
                frm.BtnVentasDirectas.Visible = (bool)permisos.Ventas;

                frm.ventasDirectasDeAtaudesToolStripMenuItem.Visible = (bool)permisos.VentasDirectas;
                frm.BtnOrdenMesa.Visible = (bool)permisos.VentarRetiros;

                if (permisos.VentasCrearProforma == false &&
                    permisos.VentasBuscarProformas == false &&
                    permisos.VentasDirectas == false &&
                    permisos.VentarRetiros == false &&
                    permisos.VentasFacturas == false)
                {
                    frm.BtnVentasDirectas.Visible = false;
                }

                //Inventario
                frm.BtnInventario.Visible = (bool)permisos.Inventario;


                if (permisos.InventarioInventarioServicios == false && permisos.InventarioModificacionesProductos == false)
                {
                    frm.BtnInventario.Visible = false;
                }

                //Caja
                frm.btnDatosGenerales.Visible = (bool)permisos.Caja;
        

                if (permisos.CajaRecibosOficiales == false && permisos.CajaHistorialRecibos == false)
                {
                    frm.btnDatosGenerales.Visible = false;
                }

                //Personal
                frm.BtnConfigTurnos.Visible = (bool)permisos.Personal;

                //TODO: Agregar la parte de visibilidad para la parte de personal cuando ya este funcionando ese modulo

                //Seguridad
                frm.btnSeguridad.Visible = (bool)permisos.Seguridad;
                frm.auditoriasToolStripMenuItem.Visible = (bool)permisos.SeguridadAuditoria;
                frm.crearUsuarioToolStripMenuItem.Visible = (bool)permisos.SeguridadGestionUsuario;
                frm.permisosToolStripMenuItem.Visible = (bool)permisos.SeguridadGestionPermisos;
                if (permisos.SeguridadGestionUsuario == false && permisos.SeguridadGestionPermisos == false)
                {
                    frm.revisionDeSeguridadToolStripMenuItem.Visible = false;
                }

                if (permisos.SeguridadGestionUsuario == false && permisos.SeguridadGestionPermisos == false && permisos.SeguridadAuditoria == false)
                {
                    frm.btnSeguridad.Visible = false;
                }

                //
                frm.BtnOpciones.Visible = (bool)permisos.Opciones;
                //frm.BtnConfigInventario.Visible = (bool)permisos.OpcionesTipoCambio;

                if (permisos.OpcionesTipoCambio == false)
                {
                    frm.BtnOpciones.Visible = false;
                }
            }
        }
    }
}
