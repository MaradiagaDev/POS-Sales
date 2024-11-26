using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlTrasladoProduco : Form
    {
        public DataTable auxTablaDinamica = new DataTable();
        public DataTable auxTablaProducto = new DataTable();
        public bool buscado = false;

        public PnlTrasladoProduco()
        {
            InitializeComponent();

            
        }

        private void PnlTrasladoProduco_Load(object sender, EventArgs e)
        {
            DgvProducto.EnableHeadersVisualStyles = false;
            DgvProducto.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            DgvProducto.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvProducto.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            DgvProducto.RowsDefaultCellStyle.BackColor = Color.White;

            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Almacenes> listBdAlmacenesSalida = db.Almacenes.Where(s => s.Estatus == "Activo").OrderByDescending(s => s.AlmacenId).ToList();
                List<Almacenes> listBdAlmacenesEntrada = db.Almacenes.Where(s => s.Estatus == "Activo").OrderByDescending(s => s.AlmacenId).ToList();

                if (listBdAlmacenesSalida.Count == 0)
                {
                    MessageBox.Show("No ha agregado almacenes o no hay almacenes activos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Close();
                    return;
                }

                CmbAlmacenEntrado.ValueMember = "AlmacenId";
                CmbAlmacenEntrado.DisplayMember = "NombreAlmacen";
                CmbAlmacenEntrado.DataSource = listBdAlmacenesEntrada;

                CmbAlmacenSalida.ValueMember = "AlmacenId";
                CmbAlmacenSalida.DisplayMember = "NombreAlmacen";
                CmbAlmacenSalida.DataSource = listBdAlmacenesSalida;

                DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

                BtnCambioEstado.Text = " Quitar ";
                BtnCambioEstado.Name = "...";
                BtnCambioEstado.UseColumnTextForButtonValue = true;
                BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
                dgvCatalogo.Columns.Add(BtnCambioEstado);

                auxTablaDinamica.Columns.Add("Lote-ID", typeof(string));
                auxTablaDinamica.Columns.Add("Lote-ID Traslado", typeof(string));
                auxTablaDinamica.Columns.Add("ProductoID", typeof(string));
                auxTablaDinamica.Columns.Add("Producto", typeof(string));
                auxTablaDinamica.Columns.Add("Proveedor", typeof(string));
                auxTablaDinamica.Columns.Add("Cantidad Trasladada", typeof(string));
                auxTablaDinamica.Columns.Add("Fecha Creación", typeof(string));
                auxTablaDinamica.Columns.Add("Fecha Expira", typeof(string));

                dgvCatalogo.DataSource = auxTablaDinamica;

                //Productos

                auxTablaProducto.Columns.Add("Producto ID", typeof(string));
                auxTablaProducto.Columns.Add("Existencias", typeof(string));
                auxTablaProducto.Columns.Add("Producto", typeof(string));

                DgvProducto.DataSource = auxTablaProducto;

                Buscador();
                buscado = true;
            }
        }

        private void Buscador()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var serviciosProductos = db.ServiciosEstadares
                    .AsNoTracking()
                    .Where(s => s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(TxtFiltroProducto.Text) && s.ClasificacionProducto == 0)
                    .ToList();

                var almacenId = int.Parse(CmbAlmacenSalida.SelectedValue.ToString());

                var productos = (from sp in serviciosProductos
                                 join rap in db.RelAlmacenProducto
                                 on sp.IdEstandar equals rap.ProductoId
                                 where rap.AlmacenId == almacenId
                                 select new
                                 {
                                     sp.IdEstandar,
                                     rap.Cantidad,
                                     sp.NombreEstandar
                                 }).ToList();

                auxTablaProducto.Rows.Clear();

                foreach (var producto in productos)
                {
                    auxTablaProducto.Rows.Add(producto.IdEstandar, producto.Cantidad, producto.NombreEstandar);
                }
            }
        }


        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            if(buscado == true)
            {
                Buscador();
            }
        }

        private void CmbAlmacenSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buscado == true)
            {
                Buscador();
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (DgvProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvProducto.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    if(int.Parse(cellValue.ToString()) == 0) 
                    {
                        MessageBox.Show("No hay Existencias del Producto Seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if(int.Parse(CmbAlmacenSalida.SelectedValue.ToString()) == int.Parse(CmbAlmacenEntrado.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Debe seleccionar almacenes distintos para realizar el traslado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    PnlAgregarTraslado traslado = new PnlAgregarTraslado(this, int.Parse(selectedRow.Cells[0].Value.ToString()),int.Parse(CmbAlmacenSalida.SelectedValue.ToString()), int.Parse(CmbAlmacenEntrado.SelectedValue.ToString()));
                    traslado.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                auxTablaDinamica.Rows.RemoveAt(e.RowIndex);

                if (auxTablaDinamica.Rows.Count > 0)
                {
                    CmbAlmacenEntrado.Enabled = false;
                    CmbAlmacenSalida.Enabled = false;
                }
                else
                {
                    CmbAlmacenEntrado.Enabled = true;
                    CmbAlmacenSalida.Enabled = true;
                }
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            auxTablaDinamica.Rows.Clear();
            CmbAlmacenSalida.Enabled = true;
            CmbAlmacenEntrado.Enabled = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(auxTablaDinamica.Rows.Count == 0)
            {
                MessageBox.Show("No se han agregado productos al traslado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Crear traslado

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                TrasladosInventario traslados = new TrasladosInventario()
                {
                    FechaTraslado = DateTime.Now,
                    IdUsuario = int.Parse(Utilidades.IdUsuario),
                    SucursalId = int.Parse(Utilidades.SucursalId)
                };

                db.Add(traslados);
                db.SaveChanges();

                foreach(DataRow item in auxTablaDinamica.Rows)
                {
                    //Verificar por cantidades
                    LotesProducto lote = db.LotesProducto.Where(s => s.LoteId == item[0].ToString()).FirstOrDefault();

                    if (int.Parse(item[5].ToString()) > lote.CantidadRestante)
                    {
                        MessageBox.Show($"La cantidad de producto ({lote.Producto}) del lote (SALIDA) ha sido modificada durante" +
                            "se realizaba el traslado por lo que ya no se encuentra la misma cantidad que la que se contempló en el lote" +
                            ".Esto pudo ocurrir por un traslado o venta al momento de realizar el traslado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        TrasladoDetalle detalleTraslado = new TrasladoDetalle()
                        {
                            TrasladoId = traslados.TrasladoId,
                            LoteInicial = item[0].ToString(),
                            LoteFinal = item[1].ToString(),
                            AlmacenEntrada = int.Parse(CmbAlmacenEntrado.SelectedValue.ToString()),
                            AlmacenSalida = int.Parse(CmbAlmacenSalida.SelectedValue.ToString()),
                            ProductoId = lote.ProductoId,
                            CantidadTrasladada = int.Parse(item[5].ToString()),
                        };

                        db.Add(detalleTraslado);
                        db.SaveChanges();

                        //Actualizar los datos de los lotes
                        lote.CantidadRestante -= int.Parse(item[5].ToString());

                        db.Update(lote);
                        db.SaveChanges();


                        //Kardex de lote viejo

                        Kardex kardexUltimo = db.Kardex.Where(s => s.ProductoId == lote.ProductoId
                            && s.AlmacenId == int.Parse(CmbAlmacenSalida.SelectedValue.ToString())).OrderByDescending(s => s.MovimientoId).FirstOrDefault();

                        //if (kardexUltimo != null)
                        //{
                        //    Kardex kardex = new Kardex()
                        //    {
                        //        Fecha = DateTime.Now.Date,
                        //        Operacion = "Traslado",
                        //        AlmacenId = int.Parse(CmbAlmacenSalida.SelectedValue.ToString()),
                        //        ProductoId = lote.ProductoId,
                        //        UnidadesSalida = int.Parse(item[5].ToString()),
                        //        CostoUnitarioSalida = lote.CostoU,
                        //        TotalSalida = lote.CostoU * int.Parse(item[5].ToString()),
                        //        UnidadesSaldo = kardexUltimo.UnidadesSaldo - int.Parse(item[5].ToString()),
                        //        CostoUnitarioSaldo = (kardexUltimo.CostoTotalSaldo - (lote.CostoU * int.Parse(item[5].ToString()))) / (kardexUltimo.UnidadesSaldo - int.Parse(item[5].ToString())),
                        //        CostoTotalSaldo = kardexUltimo.CostoTotalSaldo - (lote.CostoU * int.Parse(item[5].ToString())),
                        //        IdDocumento = traslados.TrasladoId.ToString(),
                        //        Lote = lote.LoteId
                        //    };

                        //    db.Add(kardex);
                        //    db.SaveChanges();
                        //}
                        //else
                        //{
                        //    Kardex kardex = new Kardex()
                        //    {
                        //        Fecha = DateTime.Now.Date,
                        //        Operacion = "Traslado",
                        //        AlmacenId = int.Parse(CmbAlmacenSalida.SelectedValue.ToString()),
                        //        ProductoId = lote.ProductoId,
                        //        UnidadesSaldo = int.Parse(item[5].ToString()),
                        //        CostoUnitarioSaldo = lote.CostoU * int.Parse(item[5].ToString()),
                        //        CostoTotalSaldo = lote.CostoU * int.Parse(item[5].ToString()),
                        //        UnidadesSalida = int.Parse(item[5].ToString()),
                        //        CostoUnitarioSalida = lote.CostoU,
                        //        TotalSalida = lote.CostoU * int.Parse(item[5].ToString()),
                        //        IdDocumento = traslados.TrasladoId.ToString(),
                        //        Lote = lote.LoteId
                        //    };

                        //    db.Add(kardex);
                        //    db.SaveChanges();
                        //}

                        //Kardex de lote viejo

                        //Agregar el lote nuevo

                        LotesProducto loteNuevo = new LotesProducto() { 
                        LoteId = item[1].ToString(),
                        Producto = lote.Producto,
                        ProductoId = lote.ProductoId,
                        CompraId = lote.CompraId,
                        Cantidad = int.Parse(item[5].ToString()),
                        CantidadRestante = int.Parse(item[5].ToString()),
                        FechaCreacion = lote.FechaCreacion,
                        FechaExpiracion = lote.FechaExpiracion,
                        AlmacenId = int.Parse(CmbAlmacenEntrado.SelectedValue.ToString()),
                        ProveedorId = lote.ProveedorId,
                        CostoU =lote.CostoU,
                        SubTotal = (lote.CostoU * int.Parse(item[5].ToString()))
                        };

                        db.Add(loteNuevo);
                        db.SaveChanges();

                        //Kardex lote nuevo
                        Kardex kardexUltimoNuevo = db.Kardex.Where(s => s.ProductoId == loteNuevo.ProductoId
                         && s.AlmacenId == int.Parse(CmbAlmacenEntrado.SelectedValue.ToString())).OrderByDescending(s => s.MovimientoId).FirstOrDefault();

                        //if (kardexUltimoNuevo != null)
                        //{
                        //    Kardex kardex = new Kardex()
                        //    {
                        //        Fecha = DateTime.Now.Date,
                        //        Operacion = "Traslado",
                        //        AlmacenId = int.Parse(CmbAlmacenEntrado.SelectedValue.ToString()),
                        //        ProductoId = loteNuevo.ProductoId,
                        //        UnidadesEntrada = int.Parse(item[5].ToString()),
                        //        CostoUnitarioEntrada = loteNuevo.CostoU,
                        //        TotalEntrada = loteNuevo.CostoU * int.Parse(item[5].ToString()),
                        //        UnidadesSaldo = kardexUltimoNuevo.UnidadesSaldo + int.Parse(item[5].ToString()),
                        //        CostoUnitarioSaldo = (kardexUltimoNuevo.CostoTotalSaldo + (loteNuevo.CostoU * int.Parse(item[5].ToString()))) / (kardexUltimoNuevo.UnidadesSaldo + int.Parse(item[5].ToString())),
                        //        CostoTotalSaldo = kardexUltimoNuevo.CostoTotalSaldo + (lote.CostoU * int.Parse(item[5].ToString())),
                        //        IdDocumento = traslados.TrasladoId.ToString(),
                        //        Lote = loteNuevo.LoteId
                        //    };

                        //    db.Add(kardex);
                        //    db.SaveChanges();
                        //}
                        //else
                        //{
                        //    Kardex kardex = new Kardex()
                        //    {
                        //        Fecha = DateTime.Now.Date,
                        //        Operacion = "Traslado",
                        //        AlmacenId = int.Parse(CmbAlmacenEntrado.SelectedValue.ToString()),
                        //        ProductoId = lote.ProductoId,
                        //        UnidadesSaldo = int.Parse(item[5].ToString()),
                        //        CostoUnitarioSaldo = lote.CostoU * int.Parse(item[5].ToString()),
                        //        CostoTotalSaldo = lote.CostoU * int.Parse(item[5].ToString()),
                        //         UnidadesEntrada = int.Parse(item[5].ToString()),
                        //        CostoUnitarioEntrada = lote.CostoU,
                        //        TotalEntrada = lote.CostoU * int.Parse(item[5].ToString()),
                        //        IdDocumento = traslados.TrasladoId.ToString(),
                        //        Lote = loteNuevo.LoteId
                        //    };

                        //    db.Add(kardex);
                        //    db.SaveChanges();
                        //}
                        //Kardex lote nuevo

                        //Actualizar los datos de  almacenes

                        RelAlmacenProducto almacenEntrada = db.RelAlmacenProducto.Where(s => s.ProductoId == lote.ProductoId && s.AlmacenId == int.Parse(CmbAlmacenEntrado.SelectedValue.ToString())).FirstOrDefault();

                        almacenEntrada.Cantidad += int.Parse(item[5].ToString());

                        db.Update(almacenEntrada);

                        //Salida

                        RelAlmacenProducto almacenSalida = db.RelAlmacenProducto.Where(s => s.ProductoId == lote.ProductoId && s.AlmacenId == int.Parse(CmbAlmacenSalida.SelectedValue.ToString())).FirstOrDefault();

                        almacenSalida.Cantidad -= int.Parse(item[5].ToString());

                        db.Update(almacenSalida);

                        db.SaveChanges();

                    }

                    
                }
                auxTablaDinamica.Rows.Clear();
                CmbAlmacenSalida.Enabled = true;
                CmbAlmacenEntrado.Enabled = true;

                MessageBox.Show("Traslado realizado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
