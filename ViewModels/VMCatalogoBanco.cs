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
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (opc == "Buscar")
                {
                    auxDatatable.Rows.Clear();

                    var ListaBanco = db.Bancos.Where(e => e.Banco.Contains(frm.TxtFiltrar.Texts)).ToList();

                    foreach (var item in ListaBanco)
                    {
                        auxDatatable.Rows.Add(item.BancoId, item.Banco, item.Estado);
                    }
                }
                else if (opc == "Bloquear")
                {
                    var banco = db.Bancos.Where(m => m.BancoId == int.Parse(key)).FirstOrDefault();

                    if (banco != null)
                    {
                        banco.Estado = banco.Estado == "Activo" ? "Bloqueado" : "Activo";

                        db.Update(banco);
                        db.SaveChanges();

                        FuncionesPrincipales(frm, "Buscar", "");
                    }
                }
            }
        }
    }
}
