using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMInventarioGeneral
    {
        public class MostrarInventarioGeneral
        {
            public string ID { get; set; }
            public string Producto { get; set; }
            public string Cantidad { get; set; }
            public string CantidadMinima { get; set; }
            public string CantidadMaxima { get; set; }

        }

        public PnlRevisionInventario auxFrm;

        public void InitPantallaRevision(PnlRevisionInventario frm)
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

                auxFrm.CmbBuscarPor.ValueMember = "TipoServicionId";
                auxFrm.CmbBuscarPor.DisplayMember = "Descripcion";
                auxFrm.CmbBuscarPor.DataSource = listTipoServicios;

                ////Sucursales
                List<Sucursales> listSucursales = new List<Sucursales>();

                Sucursales sucursales = new Sucursales()
                {
                    SucursalId = 0,
                    NombreSucursal = "Mostrar Todas"
                };

                listSucursales.Add(sucursales);
                List<Sucursales> listBdSucursales = db.Sucursales.OrderByDescending(s => s.SucursalId).ToList();

                if (listBdSucursales.Count == 0)
                {
                    MessageBox.Show("No ha agregado Sucursales o no hay Sucursales activas.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    auxFrm.Dispose();
                    return;
                }

                listSucursales.AddRange(listBdSucursales);

                auxFrm.CmbSucursales.ValueMember = "SucursalId";
                auxFrm.CmbSucursales.DisplayMember = "NombreSucursal";
                auxFrm.CmbSucursales.DataSource = listSucursales;
            }

            BuscarInventario();
        }

        public void BuscarInventario()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                IQueryable<MostrarInventarioGeneral> queryMostrar = null;
                object objTipo = auxFrm.CmbBuscarPor.SelectedValue;

                if (auxFrm.CmbSucursales.Text == "Mostrar Todas")
                {
                    auxFrm.TbTitulo.Text = "Inventario General";

                        var inventarioPorProducto = db.Inventario
                        .GroupBy(i => i.ProductoId)
                        .Select(g => new MostrarInventarioGeneral
                        {
                            ID = g.Key.ToString(),
                            Cantidad = g.Sum(i => i.Cantidad).ToString(),
                            CantidadMinima = g.Max(i => i.StockMinimo).ToString(),
                            CantidadMaxima = g.Max(i => i.StockMaximo).ToString()
                        });

                     var productos = db.ServiciosEstadares
                    .Where(s => inventarioPorProducto.Any(q => q.ID == s.IdEstandar.ToString()))
                    .ToDictionary(s => s.IdEstandar, s => s.NombreEstandar);

                    queryMostrar = inventarioPorProducto.Select(q => new MostrarInventarioGeneral
                    {
                        ID = q.ID,
                        Producto = productos.ContainsKey(int.Parse(q.ID)) ? productos[int.Parse(q.ID)] : "",
                        Cantidad = q.Cantidad,
                        CantidadMaxima = q.CantidadMaxima,
                        CantidadMinima = q.CantidadMinima,
                    });
                }
                else if (!string.IsNullOrEmpty(auxFrm.CmbSucursales.Text))
                {
                    int sucursalId = int.Parse(auxFrm.CmbSucursales.SelectedValue.ToString());
                    var almacenes = db.Almacenes.Where(a => a.SucursalId == sucursalId).ToList();

                    if (almacenes.Count > 0)
                    {
                        var almacenesIds = almacenes.Select(a => a.AlmacenId).ToList();

                        // Obtener los productos relacionados con los almacenes específicos
                        var relAlmacenProductosList = db.RelAlmacenProducto
                            .Where(r => almacenesIds.Contains((int)r.AlmacenId))
                            .ToList();

                        // Obtener los nombres de los productos
                        var productosIds = relAlmacenProductosList.Select(r => r.ProductoId).ToList();
                        var productos = db.ServiciosEstadares
                            .Where(s => productosIds.Contains(s.IdEstandar))
                            .ToDictionary(s => s.IdEstandar, s => s.NombreEstandar);

                        // Crear una consulta para mostrar el inventario
                        queryMostrar = (from r in relAlmacenProductosList
                                        join i in db.Inventario on r.ProductoId equals i.ProductoId
                                        where almacenesIds.Contains((int)r.AlmacenId)
                                        group new { r, i } by r.ProductoId into g
                                        select new MostrarInventarioGeneral
                                        {
                                            ID = g.Key.ToString(),
                                            Producto = productos.ContainsKey((int)g.Key) ? productos[(int)g.Key] : "",
                                            Cantidad = g.Max(x => x.i.Cantidad).ToString(),
                                            CantidadMinima = g.Max(i => i.i.StockMinimo).ToString(),
                                            CantidadMaxima = g.Max(x => x.i.StockMaximo).ToString()
                                        }).AsQueryable();
                    }
                    else
                    {
                        auxFrm.dgvCatalogo.DataSource = null; 
                        MessageBox.Show("La Sucursal seleccionada no tiene almacenes agregados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (queryMostrar != null)
                {
                    if (objTipo != null && auxFrm.CmbBuscarPor.Text != "Mostrar Todas")
                    {
                        int tipoId = (int)objTipo;
                        queryMostrar = queryMostrar.Where(m => db.ServiciosEstadares.Any(s => s.IdEstandar.ToString() == m.ID && s.ClasificacionTipo == tipoId));
                    }

                    if (!string.IsNullOrEmpty(auxFrm.TxtFiltrar.Text))
                    {
                        string filtro = auxFrm.TxtFiltrar.Text.ToLowerInvariant();
                        queryMostrar = queryMostrar.Where(m => m.Producto.ToLowerInvariant().Contains(filtro));
                    }

                    auxFrm.dgvCatalogo.DataSource = queryMostrar.ToList();
                }
            }
        }




    }
}
