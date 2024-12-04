
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
    public class VMCatalogoSalas
    {
        public DataTable auxDatatable = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloSalas(CatalogoSalas frm)
        {
            frm.dgvCatalogo.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

            //Datatable
            auxDatatable.Columns.Clear();
            auxDatatable.Rows.Clear();
            frm.dgvCatalogo.Columns.Clear();

            //Agregar Boton de Cambiar de estado
            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "  Cambiar Estado  ";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

            // Definir las columnas
            auxDatatable.Columns.Add("Id", typeof(string));
            auxDatatable.Columns.Add("Nombre Sala", typeof(string));
            auxDatatable.Columns.Add("Mesas en Sala", typeof(string));
            auxDatatable.Columns.Add("Estado", typeof(string));

            frm.dgvCatalogo.DataSource = auxDatatable;

           FuncionesPrincipales(frm, "Buscar", "");
        }

        public void FuncionesPrincipales(CatalogoSalas frm, string opc, string key)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (opc == "Buscar")
                {
                    auxDatatable.Rows.Clear();

                    DataTable dtResponse = dataUtilities.GetAllRecords("Salas");

                    var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("NombreSala")).Contains(key) && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId orderby row.Field<int>("SalaId") descending select row;

                    if (filterRow.Any())
                    {
                        foreach (DataRow item in filterRow.CopyToDataTable().Rows)
                        {
                            auxDatatable.Rows.Add(Convert.ToString(item["SalaId"]), Convert.ToString(item["NombreSala"]), Convert.ToString(item["NoMesas"]), Convert.ToString(item["Estado"]));
                        }
                    };
                }
                else if (opc == "Bloquear")
                {
                    DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("Salas", key);
                    string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                    dataUtilities.SetColumns("Estado", statusActual);
                    dataUtilities.UpdateRecordByPrimaryKey("Salas", key);

                    FuncionesPrincipales(frm, "Buscar", "");
                }
            }
        }

    }
}
