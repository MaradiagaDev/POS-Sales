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
    public class VMCatalogoTiposServicio
    {

        DataTable dynamicDataTable = new DataTable();
        public string auxId;
        PnlCatologoTiposServicios auxFrmCatalogo;
        public string auxAccion;
        public string auxBuscador;
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloPnlCatalogoServicio(PnlCatologoTiposServicios frm, string opc)
        {
            switch(opc)
            {
                case "Buscar":
                 
                    if(dynamicDataTable.Columns.Count == 0)
                    {
                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogoTipos.Columns.Add(BtnCambioEstado);

                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Descripción", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                    }
                    AccionesPrincipales(frm, "Buscar");
                    frm.dgvCatalogoTipos.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");
                    break;

                case "Crear":



                    break;
            }
        }

        public void AccionesPrincipales(PnlCatologoTiposServicios frm, string opc)
        {
            switch (opc)
            {
                case "Buscar":
                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {

                        dynamicDataTable.Rows.Clear();

                        DataTable dtResponse = dataUtilities.GetAllRecords("Categorizacion");

                        var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Descripcion")).Contains(frm.TxtFiltrar.Text.Trim()) orderby row.Field<int>("CategorizacionId") descending select row;

                        if (filterRow.Any())
                        {
                            dynamicDataTable = filterRow.CopyToDataTable();
                        }

                        frm.dgvCatalogoTipos.DataSource = dynamicDataTable; 
                    }
                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Categorizacion", auxId);
                        string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                        dataUtilities.SetColumns("Estado", statusActual);
                        dataUtilities.UpdateRecordByPrimaryKey("Categorizacion", auxId);
                    }

                    AccionesPrincipales(frm, "Buscar");
                    break;
            }
        }
    }
}
