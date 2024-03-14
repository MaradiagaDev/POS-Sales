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
    public class VMCatalogoSucursales
    {


        DataTable dynamicDataTable = new DataTable();
        public string auxSearch;
        public string auxId;

        public void InitModuloCatalogoSucursales(PnlCatalogoSucursales frm, string opc)
        {
           ConfigUI(frm, opc);
        }

        public void ConfigUI(PnlCatalogoSucursales frm, string opc)
        {
            switch (opc)
            {
                case "Buscar":

                    if(dynamicDataTable.Columns.Count == 0)
                    {
                        frm.dgvCatalogoSucursales.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogoSucursales.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre de Sucursal", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Telefono", typeof(string));
                        dynamicDataTable.Columns.Add("Correo", typeof(string));
                        dynamicDataTable.Columns.Add("Dirección", typeof(string));
                    }

                    FuncionesPrincipales(frm, opc);
                    break;
            }
        }

        public void FuncionesPrincipales(PnlCatalogoSucursales frm, string opc)
        {

            dynamicDataTable.Rows.Clear();

            switch (opc)
            {
                case "Buscar":
                    using(NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        List<Sucursales> list = db.Sucursales.Where(c => c.NombreSucursal.Contains(auxSearch)).ToList();

                        foreach (Sucursales sucursales in list.OrderByDescending(c => c.SucursalId))
                        {
                            dynamicDataTable.Rows.Add(sucursales.SucursalId,sucursales.NombreSucursal,sucursales.Estado,sucursales.Telefono,
                                sucursales.Correo,sucursales.Direccion);
                        }

                        frm.dgvCatalogoSucursales.DataSource = dynamicDataTable;
                    }
                    break;
                case "Bloquear":
                    using (NeoCobranzaContext db = new NeoCobranzaContext())
                    {
                        Sucursales sucursal = db.Sucursales.Where(p => p.SucursalId == int.Parse(auxId)).FirstOrDefault();
                        sucursal.Estado = sucursal.Estado == "Activo" ? "Bloqueado" : "Activo";

                        db.Update(sucursal);
                        db.SaveChanges();

                        ConfigUI(frm, "Buscar");
                    }
                    break;
            }
        }

    }
}
