using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMCatalogoProveedores
    {

        DataTable dynamicDataTable = new DataTable();
        public string auxId;
        PnlCatalogoProveedores auxFrmCatalogo;
        public string auxAccion;

        public void InitModuloProveedores(PnlCatalogoProveedores frm)
        {
            ConfigUI(frm, "Buscar");
        }

        public void InitModuloCrearProveedor(PnlCatalogoProveedores frmCatalogo,PnlAgregarProveedor frmAgregar, string opc,string key)
        {
            auxFrmCatalogo = frmCatalogo;
            switch(opc)
            {
                case "Crear":
                    frmAgregar.LblDynamicoProveedor.Text = "Nuevo Proveedor";
                    auxAccion = "Crear";
                    frmAgregar.btnAgregar.Text = "Crear";
                    break;
                case "Modificar":
                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        auxAccion = "Modificar";
                        auxId = key;

                        frmAgregar.btnAgregar.Text = "Modificar";

                        Proveedores proveedor = db.Proveedores.Where(c => c.IdProveedor == int.Parse(key)).FirstOrDefault();
                        frmAgregar.LblDynamicoProveedor.Text = "Modificar Proveedor: "+proveedor.NombreEmpresa;
                        frmAgregar.TxtNombreEmpresa.Text = proveedor.NombreEmpresa;
                        frmAgregar.TxtNoRuc.Text = proveedor.NoRuc;
                        frmAgregar.TxtNoTelefono.Text= proveedor.NoTelefono;
                        frmAgregar.txtDireccion.Text = proveedor.Direccion;
                    }
                    break;
            }
        }

        public void ConfigUI(PnlCatalogoProveedores frm, string opc)
        {
            switch (opc)
            {
                case "Buscar":

                   

                    //Datatable
                    dynamicDataTable.Columns.Clear();
                    dynamicDataTable.Rows.Clear();
                    frm.dgvCatalogoProveedores.Columns.Clear();

                    //Agregar Boton de Cambiar de estado
                    DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                    BtnCambioEstado.Text = "Cambiar Estado";
                    BtnCambioEstado.Name = "...";
                    BtnCambioEstado.UseColumnTextForButtonValue = true;
                    BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                    frm.dgvCatalogoProveedores.Columns.Add(BtnCambioEstado);

                    dynamicDataTable.Columns.Add("Id", typeof(string));
                    dynamicDataTable.Columns.Add("Nombre de la Empresa", typeof(string));
                    dynamicDataTable.Columns.Add("Estado", typeof(string));
                    dynamicDataTable.Columns.Add("Telefono", typeof(string));
                    dynamicDataTable.Columns.Add("RUC", typeof(string));
                    dynamicDataTable.Columns.Add("Correo", typeof(string));
                    dynamicDataTable.Columns.Add("Dirección", typeof(string));

                    frm.dgvCatalogoProveedores.DataSource = dynamicDataTable;

                    frm.CmbBuscarPor.Items.Add("ID");
                    frm.CmbBuscarPor.Items.Add("Nombre");
                    frm.CmbBuscarPor.Items.Add("RUC");

                    frm.CmbBuscarPor.SelectedIndex = 1;

                    FuncionesPrincipales(frm, "Buscar","");
                    frm.dgvCatalogoProveedores.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                    break;
            }
        }

        public void FuncionesPrincipalesClientes(PnlAgregarProveedor frm)
        {
            if (frm.TxtNombreEmpresa.Text.Trim().Length == 0)
            {
                MessageBox.Show("El Nombre de la empresa no puede estar vacío.","Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frm.TxtNoRuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("El No RUC de la empresa no puede estar vacío.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frm.TxtNoTelefono.Text.Trim().Length == 0)
            {
                MessageBox.Show("El No Telefono de la empresa no puede estar vacío.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                switch (auxAccion)
                {

                    case "Crear":
                        Proveedores proveedor = new Proveedores()
                        {
                            NombreEmpresa = frm.TxtNombreEmpresa.Text.Trim(),
                            NoRuc = frm.TxtNoRuc.Text.Trim(),
                            NoTelefono = frm.TxtNoTelefono.Text.Trim(),
                            Direccion = frm.txtDireccion.Text.Trim(),
                            Estatus = true
                        };

                        db.Add(proveedor);
                        db.SaveChanges();

                        MessageBox.Show("El Proveedor se ha creado correctamente.", "Correcto", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                        ConfigUI(auxFrmCatalogo, "Buscar");
                        frm.Close();

                        break;
                    case "Modificar":
                        Proveedores proveedorMod = db.Proveedores.Where(p => p.IdProveedor == int.Parse(auxId)).FirstOrDefault();

                        proveedorMod.NombreEmpresa = frm.TxtNombreEmpresa.Text.Trim();
                        proveedorMod.NoRuc = frm.TxtNoRuc.Text.Trim();
                        proveedorMod.NoTelefono = frm.TxtNoTelefono.Text.Trim();
                        proveedorMod.Direccion = frm.txtDireccion.Text.Trim();

                        db.Update(proveedorMod);
                        db.SaveChanges();

                        MessageBox.Show("El Proveedor se ha modificado correctamente.", "Correcto", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

                        ConfigUI(auxFrmCatalogo, "Buscar");
                        frm.Close();

                        break;
                }
            }

        }

        public void FuncionesPrincipales(PnlCatalogoProveedores frm, string opc,string key)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                switch (opc)
                {
                    case "Buscar":
                        List<Proveedores> proveedores = new List<Proveedores>();

                        frm.dgvCatalogoProveedores.DataSource = "";

                        if (frm.CmbBuscarPor.SelectedIndex == 0)
                        {
                            proveedores = db.Proveedores.Where(c => c.IdProveedor.ToString() == frm.TxtFiltrar.Texts.Trim()).OrderByDescending(c => c.IdProveedor).ToList();
                        }
                        else if (frm.CmbBuscarPor.SelectedIndex == 1)
                        {
                            proveedores = db.Proveedores.Where(c => c.NombreEmpresa.Contains(frm.TxtFiltrar.Texts.Trim())).OrderByDescending(c => c.IdProveedor).ToList();
                        }
                        else if (frm.CmbBuscarPor.SelectedIndex == 2)
                        {
                            proveedores = db.Proveedores.Where(c => c.NoRuc.Contains(frm.TxtFiltrar.Texts.Trim())).OrderByDescending(c => c.IdProveedor).ToList();
                        }



                        foreach (var item in proveedores.OrderByDescending( c => c.IdProveedor))
                        {
                            string idProveedor = item.IdProveedor.ToString();
                            string nombreProveedor = item.NombreEmpresa;
                            string estado = item.Estatus == null || item.Estatus == false ? "Inactivo" : "Activo";
                            string telefono = item.NoTelefono.ToString();
                            string ruc = item.NoRuc == null || item.NoRuc.Trim() == "" ? "Desconocido" : item.NoRuc;
                            string correo = item.Correo == null ? "Desconocido" : item.Correo;
                            string direccion = item.Direccion == null ? "Desconocido" : item.Direccion;
                            

                            dynamicDataTable.Rows.Add(idProveedor, nombreProveedor, estado, telefono, ruc, correo, direccion);
                        }

                        frm.dgvCatalogoProveedores.DataSource = dynamicDataTable;
                        frm.dgvCatalogoProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajustar automáticamente al contenido
                        break;
                    case "CambiarEstado":

                        Proveedores proveedorEstado = db.Proveedores.Where( p => p.IdProveedor == int.Parse(key) ).FirstOrDefault();
                        proveedorEstado.Estatus = proveedorEstado.Estatus == true ? false : true;

                        db.Update(proveedorEstado);
                        db.SaveChanges();

                        ConfigUI(frm, "Buscar");

                        break;
                }
            }
        }
    }
}
