using NeoCobranza.Clases;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Auditorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMPermisosUsuario
    {
        public string auxRol;
        public int idRol;
        public string auxAccion;
        public void InitGestionPermisosUsuario(GestionPermisos frm)
        {
            frm.TCMain.Appearance = TabAppearance.FlatButtons;
            frm.TCMain.SizeMode = TabSizeMode.Fixed;
            frm.TCMain.ItemSize = new System.Drawing.Size(1, 1); // Establece un tamaño mínimo

            ConfigUI(frm, "Buscar");
        }

        public void ConfigUI(GestionPermisos frm, string option)
        {
            switch (option)
            {
                case "Generales":
                    frm.TCMain.SelectedIndex = 0;
                    frm.TbTitulo.Text = "Gestión de Acceso Por Rol";
                    auxRol = frm.LvRol.SelectedRows[0].Cells[1].Value.ToString();
                    idRol = int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString());
                    frm.TbTitulosGenerales.Text = "Permisos de Acceso a Módulos:  " + auxRol;
                    CargarPermisos(frm);
                    Limpiar(frm, "Generales");
                    break;
                case "CrearRol":
                    auxAccion = "Crear";
                    frm.TCMain.SelectedIndex = 2;
                    frm.TbTitulo.Text = "Creación de Rol de Usuario";
                    frm.TxtNombrePermiso.Text = string.Empty;
                    break;
                case "ActualizarRol":
                    auxRol = frm.LvRol.SelectedRows[0].Cells[1].Value.ToString();
                    idRol = int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString());
                    auxAccion = "Actualizar";
                    frm.TCMain.SelectedIndex = 2;
                    frm.TbTitulo.Text = "Actualización de Rol de Usuario";
                    frm.TxtNombrePermiso.Text = auxRol;
                    break;
                case "Buscar":
                    frm.TbTitulo.Text = "Configuración de Permisos de Ususario.";
                    frm.TCMain.SelectedIndex = 1;

                    FuncionesPrincipales(frm, "Buscar");
                    break;
            }
        }

        public void VerificarRol(GestionPermisos frm)
        {
            if (frm.TxtNombrePermiso.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FuncionesPrincipales(frm, "Rol");
        }

        public void FuncionesPrincipales(GestionPermisos frm, string option)
        {
            switch (option)
            {
                case "Buscar":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        List<RolUsuario> roles = db.RolUsuario.Where(r => r.Rol.Contains(frm.TxtBuscar.Texts.Trim())).ToList();

                        frm.LvRol.DataSource = roles;
                    }
                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        if (frm.LvRol.SelectedRows.Count > 0)
                        {
                            RolUsuario rol = db.RolUsuario.Where(r => r.RolId == int.Parse(frm.LvRol.SelectedRows[0].Cells[0].Value.ToString())).FirstOrDefault();
                            rol.Estado = rol.Estado == "Activo" ? "Bloqueado" : "Activo";
                            db.Update(rol);
                            db.SaveChanges();
                            FuncionesPrincipales(frm, "Buscar");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("No ha seleccionado un rol.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
                case "GuardarGenerales":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        RolPermisos permisos = db.RolPermisos.Where( r => r.RolId == idRol).FirstOrDefault();

                        //Catalogos
                        permisos.Catalogos = frm.ChkCatalogos.Checked;
                        permisos.CatalogoClientes = frm.ChkCatalogoClientes.Checked;
                        permisos.CatalogoProveedores = frm.ChkCatalogoProveedores.Checked;
                        //Contratos
                        permisos.Contratos = frm.ChkContratos.Checked;
                        permisos.ContratosBuscarProforma = frm.ChkContratosBuscarProformas.Checked;
                        permisos.ContratosCrearProforma = frm.ChkContratosCrearProforma.Checked;
                        permisos.ContratosCrearContratos = frm.ChkContratosCrearContratos.Checked;
                        permisos.ContratosGestionCuotas = frm.ChkContratosGestionCuotas.Checked;
                        permisos.ContratosInformacionGeneral = frm.ChkContratosInformacionGeneral.Checked;
                        permisos.ContratosContratosRetirados = frm.ChkContratosRetirados.Checked;
                        permisos.ContratosFactura = frm.ChkContratosRealizarFactura.Checked;
                        permisos.ContratosRetiroServicios = frm.ChkContratosRetiroServicios.Checked;
                        //Ventas
                        permisos.Ventas = frm.ChkVentas.Checked;
                        permisos.VentasBuscarProformas = frm.ChkVentasBuscarProformas.Checked;
                        permisos.VentasCrearProforma = frm.ChkVentasCrearProforma.Checked;
                        permisos.VentasDirectas = frm.ChkVentasDirectas.Checked;
                        permisos.VentasFacturas = frm.ChkVentasFacturas.Checked;
                        permisos.VentarRetiros = frm.ChkRetiroVentas.Checked;
                        //Inventario
                        permisos.Inventario = frm.ChkInventario.Checked;
                        permisos.InventarioInventarioServicios = frm.ChkInventarioServicios.Checked;
                        permisos.InventarioModificacionesProductos = frm.ChkInventarioTipoProducto.Checked;
                        //Caja
                        permisos.Caja = frm.ChkCaja.Checked;
                        permisos.CajaHistorialRecibos = frm.ChkCajaHistorialRecibos.Checked;
                        permisos.CajaRecibosOficiales = frm.ChkCajaReciboOficial.Checked;
                        //Personal
                        permisos.Personal = frm.ChkPersonal.Checked;
                        //Seguridad
                        permisos.Seguridad = frm.ChkSeguridad.Checked;
                        permisos.SeguridadAuditoria = frm.ChkSeguridadAuditoria.Checked;
                        permisos.SeguridadGestionPermisos = frm.ChkSeguridadPermisos.Checked;
                        permisos.SeguridadGestionUsuario = frm.ChkSeguridadUsuario.Checked;
                        //Opciones
                        permisos.Opciones = frm.ChkOpciones.Checked;
                        permisos.OpcionesTipoCambio = frm.ChkOpcionesTipoCambio.Checked;

                        db.Update(permisos);
                        db.SaveChanges();
                        ConfigUI(frm, "Buscar");
                    }
                    break;
                case "Rol":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        if (auxAccion == "Crear")
                        {
                            RolUsuario rol = new RolUsuario();
                            rol.Estado = "Activo";
                            rol.Rol = frm.TxtNombrePermiso.Text.Trim();
                            db.Add(rol);
                            db.SaveChanges();

                            ConfigUI(frm, "Buscar");
                        }
                        else
                        {
                            RolUsuario rol = db.RolUsuario.Where(r => r.RolId == idRol).FirstOrDefault();
                            rol.Rol = frm.TxtNombrePermiso.Text.Trim();
                            db.Update(rol);
                            db.SaveChanges();

                            ConfigUI(frm, "Buscar");
                        }
                    }
                    break;
            }
        }

        public void CargarPermisos(GestionPermisos frm)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                RolPermisos permisos = db.RolPermisos.Where(r => r.RolId == idRol).FirstOrDefault();

                if (permisos == null)
                {
                    permisos = new RolPermisos()
                    {
                        RolId = idRol,
                        Catalogos = true,
                        CatalogoClientes = true,
                        CatalogoProveedores = true,
                        Contratos = true,
                        ContratosBuscarProforma = true,
                        ContratosCrearProforma = true,
                        ContratosCrearContratos = true,
                        ContratosGestionCuotas = true,
                        ContratosInformacionGeneral = true,
                        ContratosContratosRetirados = true,
                        ContratosFactura = true,
                        ContratosRetiroServicios = true,
                        Ventas = true,
                        VentasBuscarProformas = true,
                        VentasCrearProforma = true,
                        VentasDirectas = true,
                        VentasFacturas = true,
                        VentarRetiros = true,
                        Inventario = true,
                        InventarioInventarioServicios = true,
                        InventarioModificacionesProductos = true,
                        Caja = true,
                        CajaHistorialRecibos = true,
                        CajaRecibosOficiales = true,
                        Personal = true,
                        Seguridad = true,
                        SeguridadAuditoria = true,
                        SeguridadGestionPermisos = true,
                        SeguridadGestionUsuario = true,
                        Opciones = true,
                        OpcionesTipoCambio = true
                    };

                    db.Add(permisos);
                    db.SaveChanges();

                    RolPermisos permisosAgregado = db.RolPermisos.Where(r => r.RolId == idRol).FirstOrDefault();
                    permisos = permisosAgregado;
                }
                //Catalogos
                frm.ChkCatalogos.Checked = (bool)permisos.Catalogos;
                frm.ChkCatalogoClientes.Checked = (bool)permisos.CatalogoClientes;
                frm.ChkCatalogoProveedores.Checked = (bool)permisos.CatalogoProveedores;
                
                //Contratos
                frm.ChkContratos.Checked = (bool)permisos.Contratos;
                frm.ChkContratosBuscarProformas.Checked = (bool)permisos.ContratosBuscarProforma;
                frm.ChkContratosCrearProforma.Checked = (bool)permisos.ContratosCrearProforma;
                frm.ChkContratosCrearContratos.Checked = (bool)permisos.ContratosCrearContratos;
                frm.ChkContratosGestionCuotas.Checked = (bool)permisos.ContratosGestionCuotas;
                frm.ChkContratosInformacionGeneral.Checked = (bool)permisos.ContratosInformacionGeneral;
                frm.ChkContratosRetirados.Checked = (bool)permisos.ContratosContratosRetirados;
                frm.ChkContratosRealizarFactura.Checked = (bool)permisos.ContratosFactura;
                frm.ChkContratosRetiroServicios.Checked = (bool)permisos.ContratosRetiroServicios;

                //Ventas
                frm.ChkVentas.Checked = (bool)permisos.Ventas;
                frm.ChkVentasBuscarProformas.Checked = (bool)permisos.VentasBuscarProformas;
                frm.ChkVentasCrearProforma.Checked = (bool)permisos.VentasCrearProforma;
                frm.ChkVentasDirectas.Checked = (bool)permisos.VentasDirectas;
                frm.ChkVentasFacturas.Checked = (bool)permisos.VentasFacturas;
                frm.ChkRetiroVentas.Checked = (bool)permisos.VentarRetiros;
                //Inventario
                frm.ChkInventario.Checked = (bool)permisos.Inventario;
                frm.ChkInventarioServicios.Checked = (bool)permisos.InventarioInventarioServicios;
                frm.ChkInventarioTipoProducto.Checked = (bool)permisos.InventarioModificacionesProductos;
                //Caja
                frm.ChkCaja.Checked = (bool)permisos.Caja;
                frm.ChkCajaHistorialRecibos.Checked = (bool)permisos.CajaHistorialRecibos;
                frm.ChkCajaReciboOficial.Checked = (bool)permisos.CajaRecibosOficiales;
                //Personal
                frm.ChkPersonal.Checked = (bool)permisos.Personal;
                //Seguridad
                frm.ChkSeguridad.Checked = (bool)permisos.Seguridad;
                frm.ChkSeguridadAuditoria.Checked = (bool)permisos.SeguridadAuditoria;
                frm.ChkSeguridadPermisos.Checked = (bool)permisos.SeguridadGestionPermisos;
                frm.ChkSeguridadUsuario.Checked = (bool)permisos.SeguridadGestionUsuario;
                //Opciones
                frm.ChkOpciones.Checked = (bool)permisos.Opciones;
                frm.ChkOpcionesTipoCambio.Checked = (bool)permisos.OpcionesTipoCambio;
            }
        }

        public void Limpiar(GestionPermisos frm, string option)
        {
            switch (option)
            {
                case "Generales":
                    //Catalogo
                    if (frm.ChkCatalogos.Checked)
                    {
                        frm.ChkCatalogoClientes.Enabled = true;
                        frm.ChkCatalogoProveedores.Enabled = true;
                    }
                    else
                    {
                        frm.ChkCatalogoClientes.Enabled = false;
                        frm.ChkCatalogoProveedores.Enabled = false;
                    }
                    //Contratos
                    if (frm.ChkContratos.Checked)
                    {
                        frm.ChkContratosBuscarProformas.Enabled = true;
                        frm.ChkContratosCrearProforma.Enabled = true;
                        frm.ChkContratosCrearContratos.Enabled = true;
                        frm.ChkContratosGestionCuotas.Enabled = true;
                        frm.ChkContratosInformacionGeneral.Enabled = true;
                        frm.ChkContratosRetirados.Enabled = true;
                        frm.ChkContratosRealizarFactura.Enabled = true;
                        frm.ChkContratosRetiroServicios.Enabled = true;
                    }
                    else
                    {
                        frm.ChkContratosBuscarProformas.Enabled = false;
                        frm.ChkContratosCrearProforma.Enabled = false;
                        frm.ChkContratosCrearContratos.Enabled = false;
                        frm.ChkContratosGestionCuotas.Enabled = false;
                        frm.ChkContratosInformacionGeneral.Enabled = false;
                        frm.ChkContratosRetirados.Enabled = false;
                        frm.ChkContratosRealizarFactura.Enabled = false;
                        frm.ChkContratosRetiroServicios.Enabled = false;

                    }
                    //Ventas
                    if (frm.ChkVentas.Checked)
                    {
                        frm.ChkVentasBuscarProformas.Enabled = true;
                        frm.ChkVentasCrearProforma.Enabled = true;
                        frm.ChkVentasDirectas.Enabled = true;
                        frm.ChkVentasFacturas.Enabled = true;
                        frm.ChkRetiroVentas.Enabled = true;
                    }
                    else
                    {
                        frm.ChkVentasBuscarProformas.Enabled = false;
                        frm.ChkVentasCrearProforma.Enabled = false;
                        frm.ChkVentasDirectas.Enabled = false;
                        frm.ChkVentasFacturas.Enabled = false;
                        frm.ChkRetiroVentas.Enabled = false;
                    }
                    //Inventario
                    if (frm.ChkInventario.Checked)
                    {
                        frm.ChkInventarioServicios.Enabled = true;
                        frm.ChkInventarioTipoProducto.Enabled = true;
                    }
                    else
                    {
                        frm.ChkInventarioServicios.Enabled = false;
                        frm.ChkInventarioTipoProducto.Enabled = false;
                    }
                    //Caja
                    if (frm.ChkCaja.Checked)
                    {
                        frm.ChkCajaHistorialRecibos.Enabled = true;
                        frm.ChkCajaReciboOficial.Enabled = true;
                    }
                    else
                    {
                        frm.ChkCajaHistorialRecibos.Enabled = false;
                        frm.ChkCajaReciboOficial.Enabled = false;
                    }
                    //Personal
                    if (frm.ChkPersonal.Checked)
                    {

                    }
                    else
                    {

                    }
                    //Seguridad
                    if (frm.ChkSeguridad.Checked)
                    {
                        frm.ChkSeguridadAuditoria.Enabled = true;
                        frm.ChkSeguridadPermisos.Enabled = true;
                        frm.ChkSeguridadUsuario.Enabled = true;
                    }
                    else
                    {
                        frm.ChkSeguridadAuditoria.Enabled = false;
                        frm.ChkSeguridadPermisos.Enabled = false;
                        frm.ChkSeguridadUsuario.Enabled = false;
                    }
                    //Opciones
                    if (frm.ChkOpciones.Checked)
                    {
                        frm.ChkOpcionesTipoCambio.Enabled = true;
                    }
                    else
                    {
                        frm.ChkOpcionesTipoCambio.Enabled = false;
                    }
                    break;
            }
        }

    }
}
