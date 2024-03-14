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
            auxDatatable.Columns.Add("TipoTarjeta", typeof(string));
            auxDatatable.Columns.Add("Estado", typeof(string));

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

                    var ListaTipo = db.TipoTarjeta.Where(e => e.NombreTipo.Contains(frm.TxtFiltrar.Texts)).ToList();

                    foreach (var item in ListaTipo)
                    {
                        auxDatatable.Rows.Add(item.TipoTarjetaId, item.NombreTipo, item.Estado);
                    }
                }
                else if (opc == "Bloquear")
                {
                    var tipo = db.TipoTarjeta.Where(m => m.TipoTarjetaId == int.Parse(key)).FirstOrDefault();

                    if (tipo != null)
                    {
                        tipo.Estado = tipo.Estado == "Activo" ? "Bloqueado" : "Activo";

                        db.Update(tipo);
                        db.SaveChanges();

                        FuncionesPrincipales(frm, "Buscar", "");
                    }
                }
            }
        }
    }
}
