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
                        dynamicDataTable.Columns.Add("Nombre Tipo", typeof(string));
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

                        List<TipoServicios> list = db.TipoServicios.Where(c => c.Descripcion.Contains(auxBuscador)).ToList();

                        foreach (TipoServicios t in list.OrderByDescending(c => c.TipoServicionId))
                        {
                            dynamicDataTable.Rows.Add(t.TipoServicionId, t.Descripcion,t.Estado);
                        }

                        frm.dgvCatalogoTipos.DataSource = dynamicDataTable; 
                    }
                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        TipoServicios tipo = db.TipoServicios.Where(c => c.TipoServicionId == int.Parse(auxId)).FirstOrDefault();
                        tipo.Estado = tipo.Estado == "Activo" ? "Bloqueado" : "Activo";
                        db.Update(tipo);
                        db.SaveChanges();
                    }

                    AccionesPrincipales(frm, "Buscar");

                    break;
            }
        }
    }
}
