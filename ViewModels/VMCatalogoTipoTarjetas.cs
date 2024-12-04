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
    public class VMCatalogoTipoTarjetas
    {
        public DataTable auxDatatable = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        public void InitModuloBancos(CatalogoTiposTarjeta frm)
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
            auxDatatable.Columns.Add("Tipo de Tarjeta", typeof(string));
            auxDatatable.Columns.Add("Porcentaje Por Uso", typeof(string));
            auxDatatable.Columns.Add("Estado", typeof(string));
            auxDatatable.Columns.Add("Banco", typeof(string));

            frm.dgvCatalogo.DataSource = auxDatatable;

            FuncionesPrincipales(frm, "Buscar", "");
        }

        public void FuncionesPrincipales(CatalogoTiposTarjeta frm, string opc, string key)
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (opc == "Buscar")
                {
                    auxDatatable.Rows.Clear();

                    DataTable dtResponse = dataUtilities.GetAllRecords("TipoTarjeta");

                    var filterRow = from row in dtResponse.AsEnumerable() where Convert.ToString(row.Field<string>("NombreTipo")).Contains(key) orderby row.Field<int>("BancoId") descending select row;

                    if (filterRow.Any())
                    {
                        DataTable auxFilter = filterRow.CopyToDataTable();

                        foreach(DataRow dr in auxFilter.Rows)
                        {
                            DataTable dtBanco = dataUtilities.getRecordByPrimaryKey("Bancos", Convert.ToString(dr["BancoId"]));

                            string banco = Convert.ToString(dtBanco.Rows[0]["Banco"]);
                            string porcentaje = Convert.ToDouble(dr["Porcentaje"])+" %";

                            auxDatatable.Rows.Add(Convert.ToString(dr["TipoTarjetaId"]), Convert.ToString(dr["NombreTipo"]),porcentaje,
                                Convert.ToString(dr["Estado"]), banco);
                        }
                    };

                    frm.dgvCatalogo.DataSource = auxDatatable;

                }
                else if (opc == "Bloquear")
                {
                    DataTable dtRespuesta = dataUtilities.getRecordByPrimaryKey("TipoTarjeta", key);
                    string statusActual = Convert.ToString(dtRespuesta.Rows[0]["Estado"]) == "Activo" ? "Bloqueado" : "Activo";

                    dataUtilities.SetColumns("Estado", statusActual);
                    dataUtilities.UpdateRecordByPrimaryKey("TipoTarjeta", key);

                    FuncionesPrincipales(frm, "Buscar", "");
                }
            }
        }
    }
}
