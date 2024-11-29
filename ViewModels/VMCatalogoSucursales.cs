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
    public class VMCatalogoSucursales
    {


        DataTable dynamicDataTable = new DataTable();
        public string auxSearch;
        public string auxId;
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloCatalogoSucursales(PnlCatalogoSucursales frm, string opc)
        {
           ConfigUI(frm, opc);
        }

        public void ConfigUI(PnlCatalogoSucursales frm, string opc)
        {
            switch (opc)
            {
                case "Buscar":

                    if(dynamicDataTable.Columns.Count == 0)
                    {
                        frm.dgvCatalogoSucursales.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogoSucursales.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre de Sucursal", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Telefono", typeof(string));
                        dynamicDataTable.Columns.Add("Correo", typeof(string));
                        dynamicDataTable.Columns.Add("Dirección", typeof(string));
                    }

                    FuncionesPrincipales(frm, opc);
                    break;
            }
        }

        public void FuncionesPrincipales(PnlCatalogoSucursales frm, string opc)
        {

            dynamicDataTable.Rows.Clear();

            switch (opc)
            {
                case "Buscar":
                        DataTable dtResponse = dataUtilities.GetAllRecords("Sucursal");

                        var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("NombreSucursal")).Contains(auxSearch) orderby row.Field<string>("NombreSucursal") descending select row;

                        if (filterRow.Any())
                        {
                            dynamicDataTable = filterRow.CopyToDataTable();
                        };

                        frm.dgvCatalogoSucursales.DataSource = dynamicDataTable;
                    break;
                case "Bloquear":
                    DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("IdSucursal", auxId);
                    string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                    dataUtilities.SetColumns("Estado", statusActual);
                    dataUtilities.UpdateRecordByPrimaryKey("Proveedores", auxId);

                        ConfigUI(frm, "Buscar");
                    
                    break;
            }
        }

    }
}
