using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlAgregarProductoSerie : Form
    {
        int auxIdProducto;
        int auxIdAlmacen;
        public DataTable auxTablaDinamicaAgregar = new DataTable();
        public DataTable auxTablaDinamicaEliminar = new DataTable();

        private class OrdenarPorClass
        {
            public int id { get; set; }
            public string opc { get; set; }
        }

        public PnlAgregarProductoSerie(int idProducto, int idAlmacen)
        {
            InitializeComponent();
            this.auxIdProducto = idProducto;
            this.auxIdAlmacen = idAlmacen;
        }

        private void PnlAgregarProductoSerie_Load(object sender, EventArgs e)
        {
            List<OrdenarPorClass> ordenar = new List<OrdenarPorClass> { new OrdenarPorClass() {id = 0,opc = "Fecha Agregarción (Ascendente)" },
            new OrdenarPorClass() {id = 1,opc = "Fecha Agregarción (Descendente)" },
            new OrdenarPorClass() {id = 2,opc = "Fecha Expiración (Ascendente)" },
            new OrdenarPorClass() {id = 0,opc = "Fecha Expiración (Descendente)" }};

            CmbOrdenarPor.DataSource = ordenar;
            CmbOrdenarPor.DisplayMember = "opc";
            CmbOrdenarPor.ValueMember = "id";

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ServiciosEstadares productos = db.ServiciosEstadares.Where(s => s.IdEstandar == this.auxIdProducto).FirstOrDefault();
                Almacenes almacenes = db.Almacenes.Where(s => s.AlmacenId == this.auxIdAlmacen).FirstOrDefault();

                LblDinamico.Text = "Merma de Producto/ Producto: " + productos.NombreEstandar + "             Almacén: " + almacenes.NombreAlmacen;


                //Configuracion del data
                auxTablaDinamicaAgregar.Columns.Add("Lote ID", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("CompraID", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Producto ID", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Producto", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Proveedor", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Cantidad Inicial", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Restante", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Fecha Creación", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Fecha Expira", typeof(string));
                auxTablaDinamicaAgregar.Columns.Add("Costo Unitario", typeof(string));

                DgvLotes.DataSource = auxTablaDinamicaAgregar;

                var lotes = db.LotesProducto.Where(s => s.ProductoId == productos.IdEstandar && s.AlmacenId == almacenes.AlmacenId && s.CantidadRestante > 0).OrderBy(s => s.FechaCreacion).ToList();

                if(lotes.Count == 0)
                {
                    MessageBox.Show("No hay lotes con producto.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                foreach ( var lote in lotes )
                {
                    var prov = db.Proveedores.Where(p => p.IdProveedor == lote.ProveedorId).FirstOrDefault();
                    auxTablaDinamicaAgregar.Rows.Add(lote.LoteId, lote.CompraId, lote.ProductoId, lote.Producto, prov.NombreEmpresa, lote.Cantidad, lote.CantidadRestante, lote.FechaCreacion,lote.FechaExpiracion,lote.CostoU);
                }

                TxtIdentificador.Focus();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtIdentificador.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe agregar un identificador a la merma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtIdentificador.Focus();
                return;
            }

            if (TxtRazon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe agregar una razón o motivo a la merma.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtRazon.Focus();
                return;
            }

            int Cantidad = 0;

            if(int.TryParse(TxtCantidad.Text.Trim(), out Cantidad) == false || Cantidad == 0)
            {
                MessageBox.Show("Debe agregar una cantidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCantidad.Focus();
                return;
            }

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                //Verificar que la cantidad se puede quitar

                LotesProducto lote = db.LotesProducto.Where(s => s.LoteId == DgvLotes.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();

                if(int.Parse(TxtCantidad.Text) > lote.CantidadRestante)
                {
                    MessageBox.Show("La cantidad a mermar no puede ser mayor a la cantidad existente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCantidad.Focus();
                    return;
                }

                //Crear Merma

                ServiciosEstadares servicio = db.ServiciosEstadares.Where(s => s.IdEstandar == auxIdProducto).FirstOrDefault();

                Mermas merma = new Mermas();
                merma.Razon = TxtRazon.Text.Trim();
                merma.Identificador = TxtIdentificador.Text.Trim();
                merma.LoteId = DgvLotes.SelectedRows[0].Cells[0].Value.ToString();
                merma.CantidadMermada = int.Parse(TxtCantidad.Text);
                merma.FechaRealizacion = DateTime.Now;
                merma.PrecioVenta = decimal.Parse(servicio.MontoVd.ToString());

                db.Add(merma);
                db.SaveChanges();

                //lote

                lote.CantidadRestante -= int.Parse(TxtCantidad.Text);
                db.Update(lote);

                //Almacen

                RelAlmacenProducto relAlmacenProducto = db.RelAlmacenProducto.Where(s => s.ProductoId == auxIdProducto && s.AlmacenId == auxIdAlmacen).FirstOrDefault();
                relAlmacenProducto.Cantidad -= int.Parse(TxtCantidad.Text);
                db.Update(relAlmacenProducto);
                //Inventario

                Inventario inventario = db.Inventario.Where(s => s.ProductoId == auxIdProducto).FirstOrDefault();
                inventario.Cantidad -= int.Parse(TxtCantidad.Text);
                db.Update(inventario);

                db.SaveChanges();

                PnlInventarioAlmacenes frm  = Owner as PnlInventarioAlmacenes;
                frm.vMInventarioAlmacenes.BuscarInventario();

                this.Close();
            }

        }



        private void dgvBorrarProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado no es un número y no es una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, ignorar el evento de pulsación de tecla
                e.Handled = true;
            }
        }

        private void CmbOrdenarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                ServiciosEstadares productos = db.ServiciosEstadares.Where(s => s.IdEstandar == this.auxIdProducto).FirstOrDefault();
                Almacenes almacenes = db.Almacenes.Where(s => s.AlmacenId == this.auxIdAlmacen).FirstOrDefault();

                auxTablaDinamicaAgregar.Rows.Clear();

                if(CmbOrdenarPor.SelectedValue.ToString() == "0") 
                {
                    var lotes = db.LotesProducto.Where(s => s.ProductoId == productos.IdEstandar && s.AlmacenId == almacenes.AlmacenId && s.CantidadRestante > 0).OrderBy(s => s.FechaCreacion).ToList();

                    foreach (var lote in lotes)
                    {
                        var prov = db.Proveedores.Where(p => p.IdProveedor == lote.ProveedorId).FirstOrDefault();
                        auxTablaDinamicaAgregar.Rows.Add(lote.LoteId, lote.CompraId, lote.ProductoId, lote.Producto, prov.NombreEmpresa, lote.Cantidad, lote.CantidadRestante, lote.FechaCreacion, lote.FechaExpiracion, lote.CostoU);
                    }
                }

                if(CmbOrdenarPor.SelectedValue.ToString() == "1")
                {
                    var lotes = db.LotesProducto.Where(s => s.ProductoId == productos.IdEstandar && s.AlmacenId == almacenes.AlmacenId && s.CantidadRestante > 0).OrderByDescending(s => s.FechaCreacion).ToList();

                    foreach (var lote in lotes)
                    {
                        var prov = db.Proveedores.Where(p => p.IdProveedor == lote.ProveedorId).FirstOrDefault();
                        auxTablaDinamicaAgregar.Rows.Add(lote.LoteId, lote.CompraId, lote.ProductoId, lote.Producto, prov.NombreEmpresa, lote.Cantidad, lote.CantidadRestante, lote.FechaCreacion, lote.FechaExpiracion, lote.CostoU);
                    }
                }

                if (CmbOrdenarPor.SelectedValue.ToString() == "2")
                {

                    var lotes = db.LotesProducto.Where(s => s.ProductoId == productos.IdEstandar && s.AlmacenId == almacenes.AlmacenId && s.CantidadRestante > 0).OrderBy(s => s.FechaExpiracion).ToList();

                    foreach (var lote in lotes)
                    {
                        var prov = db.Proveedores.Where(p => p.IdProveedor == lote.ProveedorId).FirstOrDefault();
                        auxTablaDinamicaAgregar.Rows.Add(lote.LoteId, lote.CompraId, lote.ProductoId, lote.Producto, prov.NombreEmpresa, lote.Cantidad, lote.CantidadRestante, lote.FechaCreacion, lote.FechaExpiracion, lote.CostoU);
                    }
                }

                if (CmbOrdenarPor.SelectedValue.ToString() == "3")
                {
                    var lotes = db.LotesProducto.Where(s => s.ProductoId == productos.IdEstandar && s.AlmacenId == almacenes.AlmacenId && s.CantidadRestante > 0).OrderByDescending(s => s.FechaExpiracion).ToList();

                    foreach (var lote in lotes)
                    {
                        var prov = db.Proveedores.Where(p => p.IdProveedor == lote.ProveedorId).FirstOrDefault();
                        auxTablaDinamicaAgregar.Rows.Add(lote.LoteId, lote.CompraId, lote.ProductoId, lote.Producto, prov.NombreEmpresa, lote.Cantidad, lote.CantidadRestante, lote.FechaCreacion, lote.FechaExpiracion, lote.CostoU);
                    }
                }

            }
        }
    }
}
