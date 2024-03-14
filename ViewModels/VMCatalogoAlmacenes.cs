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
    public class VMCatalogoAlmacenes
    {
        DataTable dynamicDataTable = new DataTable();
        public string auxSearch;
        public string auxId;

        public void InitModuloCatalogoAlmacenes(PnlCatalogoAlmacenes frm, string opc)
        {
            ConfigUI(frm, opc);
        }

        public void ConfigUI(PnlCatalogoAlmacenes frm, string opc)
        {
            switch (opc)
            {
                case "Buscar":
                    if (dynamicDataTable.Columns.Count == 0)
                    {
                        frm.dgvCatalogoAlmacenes.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = " Cambiar Estado ";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogoAlmacenes.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre Almacén", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("EsMostrador", typeof(string));
                        dynamicDataTable.Columns.Add("Sucursal", typeof(string));
                    }

                    FuncionesPrincipales(frm, opc);
                    break;
            }
        }

        public void FuncionesPrincipales(PnlCatalogoAlmacenes frm, string opc)
        {
            dynamicDataTable.Rows.Clear();

            switch (opc)
            {
                case "Buscar":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        List<Almacenes> list = db.Almacenes.Where(c => c.NombreAlmacen.Contains(auxSearch)).ToList();

                        foreach (Almacenes almacen in list.OrderByDescending(c => c.AlmacenId))
                        {
                            string sucursal;
                            if (db.Sucursales.Where(c => c.SucursalId == almacen.SucursalId).FirstOrDefault() == null)
                            {
                                sucursal = "Sin Sucursal";
                            }
                            else
                            {
                                sucursal = db.Sucursales.Where(c => c.SucursalId == almacen.SucursalId).FirstOrDefault().NombreSucursal.ToString(); 
                            }
              
                            dynamicDataTable.Rows.Add(almacen.AlmacenId, almacen.NombreAlmacen, almacen.Estatus, almacen.EsMostrador, sucursal);
                        }

                        frm.dgvCatalogoAlmacenes.DataSource = dynamicDataTable;
                    }
                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        Almacenes almacen = db.Almacenes.Where(c => c.AlmacenId == int.Parse(auxId)).FirstOrDefault();
                        almacen.Estatus = almacen.Estatus == "Activo" ? "Bloqueado" : "Activo";
                        db.Update(almacen);
                        db.SaveChanges();
                    }

                    InitModuloCatalogoAlmacenes(frm, "Buscar");
                    break;
            }


        }
    }
}
