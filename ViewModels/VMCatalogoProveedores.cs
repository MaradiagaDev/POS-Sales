
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
        private DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloProveedores(PnlCatalogoProveedores frm)
        {
            ConfigUI(frm, "Buscar");
        }

        public void InitModuloCrearProveedor(PnlCatalogoProveedores frmCatalogo, PnlAgregarProveedor frmAgregar, string opc, string key)
        {
            auxFrmCatalogo = frmCatalogo;
            switch (opc)
            {
                case "Crear":
                    frmAgregar.LblDynamicoProveedor.Text = "Nuevo Proveedor";
                    auxAccion = "Crear";
                    frmAgregar.btnAgregar.Text = "Crear";
                    break;
                case "Modificar":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        auxAccion = "Modificar";
                        auxId = key;

                        frmAgregar.btnAgregar.Text = "Modificar";

                        DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Proveedores", auxId);

                        frmAgregar.LblDynamicoProveedor.Text = "Modificar Proveedor: " + Convert.ToString(dtRespuesta.Rows[0]["NombreEmpresa"]);
                        frmAgregar.TxtNombreEmpresa.Text = Convert.ToString(dtRespuesta.Rows[0]["NombreEmpresa"]);
                        frmAgregar.TxtNoRuc.Text = Convert.ToString(dtRespuesta.Rows[0]["NoRuc"]);
                        frmAgregar.TxtNoTelefono.Text = Convert.ToString(dtRespuesta.Rows[0]["NoTelefono"]);
                        frmAgregar.txtDireccion.Text = Convert.ToString(dtRespuesta.Rows[0]["Direccion"]);
                        frmAgregar.TxtCelularRepresentante.Text = Convert.ToString(dtRespuesta.Rows[0]["NoCelularRepresentante"]);
                        frmAgregar.TxtNombreRepresentante.Text = Convert.ToString(dtRespuesta.Rows[0]["NombreRepresentante"]);
                        frmAgregar.TxtCorreo.Text = Convert.ToString(dtRespuesta.Rows[0]["Correo"]);
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
                    dynamicDataTable.Columns.Add("Representante", typeof(string));
                    dynamicDataTable.Columns.Add("Contacto", typeof(string));

                    frm.dgvCatalogoProveedores.DataSource = dynamicDataTable;

                    frm.CmbBuscarPor.Items.Add("ID");
                    frm.CmbBuscarPor.Items.Add("Nombre");
                    frm.CmbBuscarPor.Items.Add("RUC");

                    frm.CmbBuscarPor.SelectedIndex = 1;

                    FuncionesPrincipales(frm, "Buscar", "");
                    frm.dgvCatalogoProveedores.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                    break;
            }
        }

        public void FuncionesPrincipalesClientes(PnlAgregarProveedor frm)
        {
            if (frm.TxtNombreEmpresa.Text.Trim().Length == 0)
            {
                MessageBox.Show("El Nombre de la empresa no puede estar vacío.", "Atención",
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

            switch (auxAccion)
            {

                case "Crear":

                    dataUtilities.SetColumns("NombreEmpresa", frm.TxtNombreEmpresa.Text.Trim());
                    dataUtilities.SetColumns("NoTelefono", frm.TxtNoTelefono.Text.Trim());
                    dataUtilities.SetColumns("NoRuc", frm.TxtNoRuc.Text.Trim());
                    dataUtilities.SetColumns("Correo", frm.TxtCorreo.Text.Trim());
                    dataUtilities.SetColumns("Direccion", frm.txtDireccion.Text.Trim());
                    dataUtilities.SetColumns("Estatus", "Activo");
                    dataUtilities.SetColumns("NombreRepresentante", frm.TxtNombreRepresentante.Text.Trim());
                    dataUtilities.SetColumns("NoCelularRepresentante", frm.TxtCelularRepresentante.Text.Trim());
                    dataUtilities.InsertRecord("Proveedores");

                    MessageBox.Show("El Proveedor se ha creado correctamente.", "Correcto", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ConfigUI(auxFrmCatalogo, "Buscar");
                    frm.Close();

                    break;
                case "Modificar":

                    dataUtilities.SetColumns("NombreEmpresa", frm.TxtNombreEmpresa.Text.Trim());
                    dataUtilities.SetColumns("NoTelefono", frm.TxtNoTelefono.Text.Trim());
                    dataUtilities.SetColumns("NoRuc", frm.TxtNoRuc.Text.Trim());
                    dataUtilities.SetColumns("Correo", frm.TxtCorreo.Text.Trim());
                    dataUtilities.SetColumns("Direccion", frm.txtDireccion.Text.Trim());
                    dataUtilities.SetColumns("Estatus", "Activo");
                    dataUtilities.SetColumns("NombreRepresentante", frm.TxtNombreRepresentante.Text.Trim());
                    dataUtilities.SetColumns("NoCelularRepresentante", frm.TxtCelularRepresentante.Text.Trim());
                    dataUtilities.UpdateRecordByPrimaryKey("Proveedores", auxId);

                    MessageBox.Show("El Proveedor se ha modificado correctamente.", "Correcto", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                    ConfigUI(auxFrmCatalogo, "Buscar");
                    frm.Close();

                    break;
            }


        }

        public void FuncionesPrincipales(PnlCatalogoProveedores frm, string opc, string key)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                switch (opc)
                {
                    case "Buscar":
                        DataTable dtResponse = dataUtilities.GetAllRecords("Proveedores");
                        DataTable proveedores = new DataTable();

                        frm.dgvCatalogoProveedores.DataSource = "";

                        if (frm.CmbBuscarPor.SelectedIndex == 0)
                        {
                           var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<int>("IdProveedor")) == frm.TxtFiltrar.Texts.Trim() orderby row.Field<int>("IdProveedor") descending select row;

                            if (filterRow.Any())
                            {
                                proveedores = filterRow.CopyToDataTable();
                            }
                        }
                        else if (frm.CmbBuscarPor.SelectedIndex == 1)
                        {
                            var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("NombreEmpresa")).Contains(frm.TxtFiltrar.Texts.Trim()) orderby row.Field<int>("IdProveedor") descending select row;

                            if (filterRow.Any())
                            {
                                proveedores = filterRow.CopyToDataTable();
                            }
                        }
                        else if (frm.CmbBuscarPor.SelectedIndex == 2)
                        {
                            var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("NoRuc")).Contains(frm.TxtFiltrar.Texts.Trim()) orderby row.Field<int>("IdProveedor") descending select row;

                            if (filterRow.Any())
                            {
                                proveedores = filterRow.CopyToDataTable();
                            }
                        }

                        foreach (DataRow item in proveedores.Rows)
                        {
                            string idProveedor = Convert.ToString(item["IdProveedor"]);
                            string nombreProveedor = Convert.ToString(item["NombreEmpresa"]);
                            string estado = Convert.ToString(item["Estatus"]);
                            string telefono = Convert.ToString(item["NoTelefono"]);
                            string ruc = Convert.ToString(item["NoRuc"]) == ""  ? "Desconocido" : Convert.ToString(item["NoRuc"]);
                            string correo = Convert.ToString(item["Correo"]) == null ? "Desconocido" : Convert.ToString(item["Correo"]);
                            string direccion = Convert.ToString(item["Direccion"]) == null ? "Desconocido" : Convert.ToString(item["Direccion"]);


                            dynamicDataTable.Rows.Add(idProveedor, nombreProveedor, estado, telefono, ruc, correo, direccion,
                                Convert.ToString(item["NombreRepresentante"]), Convert.ToString(item["NoCelularRepresentante"]));
                        }

                        frm.dgvCatalogoProveedores.DataSource = dynamicDataTable;
                        frm.dgvCatalogoProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajustar automáticamente al contenido

                        break;
                    case "CambiarEstado":
                        auxId = key.ToString();
                        DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Proveedores", auxId);
                        string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estatus"]) == "Activo" ? "Bloqueado" : "Activo"; 

                        dataUtilities.SetColumns("Estatus", statusActual);
                        dataUtilities.UpdateRecordByPrimaryKey("Proveedores", auxId);

                        ConfigUI(frm, "Buscar");
                        break;
                }
            }
        }
    }
}
