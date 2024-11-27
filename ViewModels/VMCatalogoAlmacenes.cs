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
    public class VMCatalogoAlmacenes
    {
        DataTable dynamicDataTable = new DataTable();
        public string auxSearch;
        public string auxId;
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloCatalogoAlmacenes(PnlCatalogoAlmacenes frm, string opc)
        {
            ConfigUI(frm, opc);
        }

        public void ConfigUI(PnlCatalogoAlmacenes frm, string opc)
        {
            switch (opc)
            {
                case "Buscar":
                    if (dynamicDataTable.Columns.Count == 0)
                    {
                        frm.dgvCatalogoAlmacenes.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = " Cambiar Estado ";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogoAlmacenes.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre Almacén", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("EsMostrador", typeof(string));
                        dynamicDataTable.Columns.Add("Sucursal", typeof(string));
                        dynamicDataTable.Columns.Add("Dirección", typeof(string));
                    }

                    FuncionesPrincipales(frm, opc);
                    break;
            }
        }

        public void FuncionesPrincipales(PnlCatalogoAlmacenes frm, string opc)
        {
            dynamicDataTable.Rows.Clear();

            switch (opc)
            {
                case "Buscar":
                    //Almacenes Propios sucursal
                    DataTable dtRespuesta = dataUtilities.getRecordByColumn("Almacenes", "SucursalId", Utilidades.SucursalId);
                    //Almacenes Sin Sucursal asignada
                    DataTable dtRespuestaSinSucursal = dataUtilities.getRecordByColumn("Almacenes", "SucursalId", "");

                    foreach (DataRow item in dtRespuesta.Rows)
                    {
                        string sucursal;
                        if (Convert.ToString(item["SucursalId"]) == "")
                        {
                            sucursal = "Sin Sucursal";
                        }
                        else
                        {
                            sucursal = dataUtilities.getRecordByPrimaryKey("Sucursal", Convert.ToString(item["SucursalId"])).Rows[0]["NombreSucursal"].ToString();
                        }

                        dynamicDataTable.Rows.Add(item["AlmacenId"], item["NombreAlmacen"], item["Estatus"], item["EsMostrador"], sucursal, item["Direccion"]);
                    }

                    foreach (DataRow item in dtRespuestaSinSucursal.Rows)
                    {
                        string sucursal;
                        if (Convert.ToString(item["SucursalId"]) == "")
                        {
                            sucursal = "Sin Sucursal";
                        }
                        else
                        {
                            sucursal = dataUtilities.getRecordByPrimaryKey("Sucursal", Convert.ToString(item["SucursalId"])).Rows[0]["NombreSucursal"].ToString();
                        }

                        dynamicDataTable.Rows.Add(item["AlmacenId"], item["NombreAlmacen"], item["Estatus"], item["EsMostrador"], sucursal, item["Direccion"]);
                    }

                    frm.dgvCatalogoAlmacenes.DataSource = dynamicDataTable;

                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        //Verificar el estatus
                        string status = Convert.ToString(dataUtilities.getRecordByPrimaryKey("Almacenes", auxId).Rows[0]["Estatus"]) == "Activo" ? "Bloqueado" : "Activo";

                        //Actualizar tabla
                        dataUtilities.SetColumns("Estatus", status);
                        dataUtilities.UpdateRecordByPrimaryKey("Almacenes", auxId);
                    }

                    InitModuloCatalogoAlmacenes(frm, "Buscar");
                    break;
            }


        }
    }
}
