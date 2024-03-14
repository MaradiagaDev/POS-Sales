using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMCatalogosInventario
    {

        public string auxOpc;
        public string auxId;
        public CatalogosInventario auxFrm;
        DataTable dynamicDataTable = new DataTable();

        public void InitModuloCatalogosInventario(CatalogosInventario frm, string opc)
        {
            this.auxOpc = opc;
            this.auxFrm = frm;

            switch(opc) 
            {
                case "Productos":
                    frm.TbTitulo.Text = "Catalogo de Productos";
                    frm.btnActualizar.Text = "Actualizar Producto";
                    frm.btnAgregar.Text = "Agregar Producto";
                    break;
                case "Servicios":
                    frm.TbTitulo.Text = "Catalogo de Servicios";
                    frm.btnActualizar.Text = "Actualizar Servicio";
                    frm.btnAgregar.Text = "Agregar Servicio";
                    break;
            }

            ConfigUI(frm);
        }

        public void ConfigUI(CatalogosInventario frm)
        {
            switch (auxOpc)
            {
                case "Productos":

                    if (dynamicDataTable.Columns.Count == 0)
                    {
                        frm.dgvCatalogo.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre del Producto", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Tipo Producto", typeof(string));
                    }
                    break;

                case "Servicios":
                    if ( dynamicDataTable.Columns.Count == 0 )
                    {
                        frm.dgvCatalogo.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ECECEC");

                        //Agregar Boton de Cambiar de estado
                        DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                        BtnCambioEstado.Text = "Cambiar Estado";
                        BtnCambioEstado.Name = "...";
                        BtnCambioEstado.UseColumnTextForButtonValue = true;
                        BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                        frm.dgvCatalogo.Columns.Add(BtnCambioEstado);

                        // Definir las columnas
                        dynamicDataTable.Columns.Add("Id", typeof(string));
                        dynamicDataTable.Columns.Add("Nombre del Servicio", typeof(string));
                        dynamicDataTable.Columns.Add("Estado", typeof(string));
                        dynamicDataTable.Columns.Add("Tipo Servicio", typeof(string));
                    }
                    break;
            }

            FuncionesPrincipales(frm, "Buscar");
        }

        public void FuncionesPrincipales(CatalogosInventario frm, string opc)
        {
            if(opc == "Bloquear")
            {
                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    ServiciosEstadares servicio = db.ServiciosEstadares.Where(c => c.IdEstandar == int.Parse(auxId) && c.NombreEstandar.Contains(auxFrm.TxtFiltrar.Texts)).FirstOrDefault();

                    servicio.Estado = servicio.Estado == "Activo" ? "Bloqueado" : "Activo";

                    db.Update(servicio);
                    db.SaveChanges();
                }

                FuncionesPrincipales(frm, "Buscar");
            }

            switch (auxOpc)
            {
                case "Productos":

                    if (opc == "Buscar")
                    {
                        dynamicDataTable.Rows.Clear();
                        using (NeoCobranzaContext db = new NeoCobranzaContext())
                        {
                            var query = from se in db.ServiciosEstadares
                                        join ts in db.TipoServicios on se.ClasificacionTipo equals ts.TipoServicionId
                                        where se.ClasificacionProducto == 0 && se.NombreEstandar.Contains(auxFrm.TxtFiltrar.Text)
                                        orderby se.IdEstandar descending
                                        select new
                                        {
                                            se.IdEstandar,
                                            se.NombreEstandar,
                                            se.Estado,
                                            TipoServicioDescripcion = ts.Descripcion
                                        };

                            List<object[]> data = query.AsNoTracking().ToList().Select(item => new object[] { item.IdEstandar, item.NombreEstandar, item.Estado, item.TipoServicioDescripcion }).ToList();

                            foreach (var rowData in data)
                            {
                                dynamicDataTable.Rows.Add(rowData);
                            }

                            frm.dgvCatalogo.DataSource = dynamicDataTable;
                        }
                    }

                    break;

                case "Servicios":

                    if (opc == "Buscar")
                    {
                        dynamicDataTable.Rows.Clear();
                        using (NeoCobranzaContext db = new NeoCobranzaContext())
                        {
                            var query = from se in db.ServiciosEstadares
                                        join ts in db.TipoServicios on se.ClasificacionTipo equals ts.TipoServicionId
                                        where se.ClasificacionProducto == 1 && se.NombreEstandar.Contains(auxFrm.TxtFiltrar.Text)
                                        orderby se.IdEstandar descending
                                        select new
                                        {
                                            se.IdEstandar,
                                            se.NombreEstandar,
                                            se.Estado,
                                            TipoServicioDescripcion = ts.Descripcion
                                        };

                            List<object[]> data = query.AsNoTracking().ToList().Select(item => new object[] { item.IdEstandar, item.NombreEstandar, item.Estado, item.TipoServicioDescripcion }).ToList();

                            foreach (var rowData in data)
                            {
                                dynamicDataTable.Rows.Add(rowData);
                            }

                            frm.dgvCatalogo.DataSource = dynamicDataTable;
                        }
                    }

                    break;
            }
        }

    }
}
