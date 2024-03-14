using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NeoCobranza.ViewModels.VMInventarioGeneral;

namespace NeoCobranza.ViewModels
{
    public class VMInventarioAlmacenes
    {
        PnlInventarioAlmacenes auxFrm;
        public void InitModuloInventarioAlmacenes(PnlInventarioAlmacenes frm)
        {
            auxFrm = frm;
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                //Tipos Servicios
                List<TipoServicios> listTipoServicios = new List<TipoServicios>();

                TipoServicios tipoServicios = new TipoServicios()
                {
                    Descripcion = "Mostrar Todas",
                    Estado = "Activo",
                    TipoServicionId = 0
                };

                listTipoServicios.Add(tipoServicios);

                List<TipoServicios> listBdTipo = db.TipoServicios.Where(s => s.Estado == "Activo").OrderByDescending(s => s.TipoServicionId).ToList();
                listTipoServicios.AddRange(listBdTipo);

                frm.CmbBuscarPor.ValueMember = "TipoServicionId";
                frm.CmbBuscarPor.DisplayMember = "Descripcion";
                frm.CmbBuscarPor.DataSource = listTipoServicios;

                //Almacenes
                List<Almacenes> listAlmacenes = new List<Almacenes>();

                Almacenes almacen = new Almacenes()
                {
                    NombreAlmacen = "Mostrar Todas",
                    Estatus = "Activo",
                    AlmacenId = 0
                };

                listAlmacenes.Add(almacen);

                List<Almacenes> listBdAlmacenes = db.Almacenes.Where(s => s.Estatus == "Activo").OrderByDescending(s => s.AlmacenId).ToList();

                if (listBdAlmacenes.Count == 0)
                {
                    MessageBox.Show("No ha agregado almacenes o no hay almacenes activos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    auxFrm.Dispose();
                    return;
                }

                listAlmacenes.AddRange(listBdAlmacenes);

                frm.CmbAlmacenes.ValueMember = "AlmacenId";
                frm.CmbAlmacenes.DisplayMember = "NombreAlmacen";
                frm.CmbAlmacenes.DataSource = listAlmacenes;

                DataGridViewButtonColumn BtnAjuste = new DataGridViewButtonColumn();

                BtnAjuste.Text = " Merma de Producto ";
                BtnAjuste.Name = "...";
                BtnAjuste.UseColumnTextForButtonValue = true;
                BtnAjuste.DefaultCellStyle.ForeColor = Color.Blue;
                frm.dgvCatalogo.Columns.Add(BtnAjuste);
                BuscarInventario();
            }
        }

        public void BuscarInventario()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                IQueryable<MostrarInventarioGeneral> query = null;

                if (auxFrm.CmbAlmacenes.Text == "Mostrar Todas" || string.IsNullOrEmpty(auxFrm.CmbAlmacenes.Text))
                {
                    query = from inventario in db.Inventario
                            join servicio in db.ServiciosEstadares on inventario.ProductoId equals servicio.IdEstandar into gj
                            from subServicio in gj.DefaultIfEmpty()
                            select new MostrarInventarioGeneral
                            {
                                ID = subServicio.IdEstandar.ToString(),
                                Producto = subServicio.NombreEstandar,
                                Cantidad = inventario.Cantidad.ToString(),
                                CantidadMaxima = inventario.StockMaximo.ToString(),
                                CantidadMinima = inventario.StockMinimo.ToString()
                            };
                }
                else
                {
                    string selectedAlmacen = auxFrm.CmbAlmacenes.SelectedValue.ToString();
                    query = from relAlmacenProducto in db.RelAlmacenProducto
                            join servicio in db.ServiciosEstadares on relAlmacenProducto.ProductoId equals servicio.IdEstandar into gj
                            from subServicio in gj.DefaultIfEmpty()
                            join inventario in db.Inventario on relAlmacenProducto.ProductoId equals inventario.ProductoId into gj2
                            from subInventario in gj2.DefaultIfEmpty()
                            where relAlmacenProducto.AlmacenId.ToString() == selectedAlmacen
                            select new MostrarInventarioGeneral
                            {
                                ID = subServicio.IdEstandar.ToString(),
                                Producto = subServicio.NombreEstandar,
                                Cantidad = relAlmacenProducto.Cantidad.ToString(),
                                CantidadMaxima = subInventario.StockMaximo.ToString(),
                                CantidadMinima = subInventario.StockMinimo.ToString()
                            };
                }

                if (!string.IsNullOrEmpty(auxFrm.CmbBuscarPor.Text) && auxFrm.CmbBuscarPor.Text != "Mostrar Todas")
                {
                    TipoServicios objTipo = auxFrm.CmbBuscarPor.SelectedItem as TipoServicios;
                    query = query.Where(item => db.ServiciosEstadares
                                                 .Where(s => s.ClasificacionTipo == objTipo.TipoServicionId)
                                                 .Select(s => s.IdEstandar.ToString())
                                                 .Contains(item.ID));
                }

                var filteredQuery = query.Where(item => item.Producto.ToLower().Contains(auxFrm.TxtFiltrar.Text.ToLower())).ToList();
                auxFrm.dgvCatalogo.DataSource = filteredQuery;
            }
        }
    }
}
