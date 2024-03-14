using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class VMConfigInventario
    {
        PnlConfigInventario auxFrm;

        public VMConfigInventario(PnlConfigInventario frm) 
        {
            this.auxFrm = frm;
        }

        public void FuncionesPrincipales(string opc)
        {
            auxFrm.LblCargando.Visible = true;
            auxFrm.imgCargando.Visible = true;

            switch (opc) 
            {
                case "Conexiones":
                    try
                    {
                        using (NeoCobranzaContext db = new NeoCobranzaContext())
                        {
                            //Revisar que los servicios no tengan conexiones
                            List<ServiciosEstadares> servicios = db.ServiciosEstadares.Where(s => s.ClasificacionProducto == 1).ToList();

                            foreach (var item in servicios)
                            {
                                List<RelAlmacenProducto> listAlmacentesServicios = db.RelAlmacenProducto.Where(s => s.ProductoId == item.IdEstandar).ToList();

                                foreach (var itemAlmacen in listAlmacentesServicios)
                                {
                                    db.Remove(itemAlmacen);
                                }

                                List<Inventario> listInventarios = db.Inventario.Where(s => s.ProductoId == item.IdEstandar).ToList();

                                foreach (var itemInventario in listInventarios)
                                {
                                    db.Remove(itemInventario);
                                }

                                db.SaveChanges();
                            }

                            //Revisar que los productos tengan conexiones
                            List<ServiciosEstadares> productos = db.ServiciosEstadares.Where(s => s.ClasificacionProducto == 0).ToList();

                            foreach (var item in productos)
                            {
                                Inventario inventario = db.Inventario.Where(s => s.ProductoId == item.IdEstandar).FirstOrDefault();

                                if (inventario == null)
                                {
                                    inventario = new Inventario()
                                    {
                                        ProductoId = item.IdEstandar,
                                        Cantidad = 0,
                                        StockMaximo = 100,
                                        StockMinimo = 0,
                                    };
                                    db.Add(inventario);
                                }

                                List<Almacenes> almacenes = db.Almacenes.ToList();

                                foreach (var ItemAlmacen in almacenes)
                                {
                                    RelAlmacenProducto rel = db.RelAlmacenProducto.Where(s => s.ProductoId == item.IdEstandar && s.AlmacenId == ItemAlmacen.AlmacenId).FirstOrDefault();

                                    if (rel == null)
                                    {
                                        rel = new RelAlmacenProducto()
                                        {
                                            AlmacenId = ItemAlmacen.AlmacenId,
                                            ProductoId = item.IdEstandar,
                                            Cantidad = 0
                                        };

                                        db.Add(rel);
                                    }
                                }

                                db.SaveChanges();
                            }

                            auxFrm.LblCargando.Visible = false;
                            auxFrm.imgCargando.Visible = false;
                            MessageBox.Show("Conexiones Realizadas","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    catch(Exception ex)
                    {
                        auxFrm.LblCargando.Visible = false;
                        auxFrm.imgCargando.Visible = false;
                        MessageBox.Show($"Ocurrió un error al realizar las conexiones. Error: {ex.Message}","Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Borrar":
 
                    try
                    {
                        using (NeoCobranzaContext db = new NeoCobranzaContext())
                        {
                            //Borrar Ajustes y detalles
                            List<AjustesInventario> ajustes = db.AjustesInventario.ToList();
                            
                            foreach(var item in ajustes)
                            {
                                db.Remove(item);
                            }

                            List<RelAlmacenDetalle> almacenDetalles = db.RelAlmacenDetalle.ToList();

                            foreach (var item in almacenDetalles)
                            {
                                db.Remove(item);
                            }

                            List<Inventario> inventarios = db.Inventario.ToList();

                            foreach (var inventario in inventarios)
                            {
                                inventario.Cantidad = 0;
                                inventario.StockMaximo = 100;
                                inventario.StockMinimo = 0;

                                db.Update(inventario);
                            }

                            var listaCompras = db.ComprasInventario.ToList();

                            foreach (var item in listaCompras)
                            {
                                db.Remove(item);
                            }

                            var listaLotesProducto = db.LotesProducto.ToList();

                            foreach(var item in listaLotesProducto)
                            {
                                db.Remove(item);
                            }

                            var listaMerma = db.Mermas.ToList();

                            foreach (var item in listaMerma)
                            {
                                db.Remove(item);
                            }

                            List<RelAlmacenProducto> listRel = db.RelAlmacenProducto.ToList();

                            foreach (var rel in listRel)
                            {
                                rel.Cantidad = 0;

                                db.Update(rel);
                            }

                            db.SaveChanges();

                            auxFrm.LblCargando.Visible = false;
                            auxFrm.imgCargando.Visible = false;
                            MessageBox.Show("El inventario ha sido borrado.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch(Exception ex)
                    {
                        auxFrm.LblCargando.Visible = false;
                        auxFrm.imgCargando.Visible = false;
                        MessageBox.Show($"Ocurrió un error al borrar el inventario. Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }               
                    break;
            }
        }
    }
}
