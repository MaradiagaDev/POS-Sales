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
            auxDatatable.Columns.Add("Sucursal", typeof(string));
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

                   var salas = db.Salas.Where(s => s.NombreSala.Contains(frm.TxtFiltrar.Texts) && s.SucursalId == int.Parse(Utilidades.SucursalId)).OrderByDescending(s => s.SucursalId).ToList();

                    foreach(var item in salas)
                    {
                        Sucursales sucursales = db.Sucursales.Where(s => s.SucursalId == item.SucursalId).FirstOrDefault();

                        auxDatatable.Rows.Add(item.SalaId,item.NombreSala,item.NoMesas,sucursales.NombreSucursal,item.Estado);
                    }
                }
                else if (opc == "Bloquear")
                {
                    var sala = db.Salas.Where(s => s.SalaId == int.Parse(key)).FirstOrDefault();

                    sala.Estado = sala.Estado == "Activo" ? "Bloqueado" : "Activo";

                    db.Update(sala);
                    db.SaveChanges();

                    FuncionesPrincipales(frm, "Buscar", "");
                }
            }
        }

    }
}
