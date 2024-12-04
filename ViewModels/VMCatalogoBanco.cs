
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
    public class VMCatalogoBanco
    {
        public DataTable auxDatatable = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloBancos(CatalogoBancos frm)
        {
            frm.dgvCatalogo.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

            //Datatable
            auxDatatable.Columns.Clear();
            auxDatatable.Rows.Clear();
            frm.dgvCatalogo.Columns.Clear();

            //Agregar Boton de Cambiar de estado
            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "Cambiar Estado";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

            // Definir las columnas
            auxDatatable.Columns.Add("Id", typeof(string));
            auxDatatable.Columns.Add("Banco", typeof(string));
            auxDatatable.Columns.Add("Estado", typeof(string));

            frm.dgvCatalogo.DataSource = auxDatatable;

            FuncionesPrincipales(frm, "Buscar", "");
        }

        public void FuncionesPrincipales(CatalogoBancos frm, string opc, string key)
        {
            if (opc == "Buscar")
            {
                DataTable dtResponse = dataUtilities.GetAllRecords("Bancos");

                var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("Banco")).Contains(key) orderby row.Field<string>("Banco") descending select row;

                if (filterRow.Any())
                {
                    auxDatatable = filterRow.CopyToDataTable();
                };

                frm.dgvCatalogo.DataSource = auxDatatable;
            }
            else if (opc == "Bloquear")
            {
                DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Bancos", key);
                string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                dataUtilities.SetColumns("Estado", statusActual);
                dataUtilities.UpdateRecordByPrimaryKey("Bancos", key);

                FuncionesPrincipales(frm, "Buscar", "");
            }
        }
    }
}
