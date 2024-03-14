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
    public class VMMotivosCancelacion
    {
        public DataTable auxDatatable = new DataTable();

        public void InitModuloMotivosCancelacion(CatologoMotivosCancelacion frm)
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
            auxDatatable.Columns.Add("Motivo Cancelación", typeof(string));
            auxDatatable.Columns.Add("Estado", typeof(string));

            frm.dgvCatalogo.DataSource = auxDatatable;

            FuncionesPrincipales(frm, "Buscar", "");
        }

        public void FuncionesPrincipales(CatologoMotivosCancelacion frm,string opc, string key)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if(opc == "Buscar")
                {
                    auxDatatable.Rows.Clear();

                    var ListaMotivos = db.MotivosCancelacion.Where(e => e.Motivo.Contains(frm.TxtFiltrar.Texts)).ToList();

                    foreach(var item in ListaMotivos)
                    {
                        auxDatatable.Rows.Add(item.MotivoCancelacionId,item.Motivo,item.Estado);
                    }
                }
                else if(opc == "Bloquear")
                {
                    var Motivo = db.MotivosCancelacion.Where(m => m.MotivoCancelacionId == int.Parse(key)).FirstOrDefault();

                    if(Motivo != null)
                    {
                        Motivo.Estado = Motivo.Estado == "Activo" ? "Bloqueado" : "Activo";

                        db.Update(Motivo);
                        db.SaveChanges();

                        FuncionesPrincipales(frm, "Buscar", "");
                    }
                }
            }
        }
    }
}
