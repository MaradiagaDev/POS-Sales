using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class ListaMermas : Form
    {
        int auxIdAlmacen;
        DataTable dataMerma = new DataTable();
        public ListaMermas(int AlmacenID)
        {
            InitializeComponent();
            auxIdAlmacen = AlmacenID;
        }

        private void ListaMermas_Load(object sender, EventArgs e)
        {

            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "  Ver Información  ";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            dgvCatalogo.Columns.Add(BtnCambioEstado);


            dataMerma.Columns.Add("MermaID", typeof(string));
            dataMerma.Columns.Add("LoteID", typeof(string));
            dataMerma.Columns.Add("Producto ID", typeof(string));
            dataMerma.Columns.Add("Producto", typeof(string));
            dataMerma.Columns.Add("Cantidad Mermada", typeof(string));
            dataMerma.Columns.Add("Identificador", typeof(string));
            dataMerma.Columns.Add("Fecha Creación", typeof(string));

            dgvCatalogo.DataSource = dataMerma;
  

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxIdAlmacen == 0)
                {
                    LblDynamico.Text = "Todas las Mermas";
                }
                else
                {
                    var itemAlmacen = db.Almacenes.Where(s => s.AlmacenId == auxIdAlmacen).FirstOrDefault();
                    LblDynamico.Text = $"Mermas del Almacén: {itemAlmacen.NombreAlmacen}";
                }

                BuscarMermas();
            }
        }

        private void BuscarMermas()
        {
            dataMerma.Rows.Clear();

            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                if (auxIdAlmacen == 0)
                {
                    var listaMermasTodas = db.Mermas.Where(s => s.Identificador.Contains(TxtFiltrar.Texts)).OrderByDescending(s => s.MermaId).ToList();

                    foreach (var item in listaMermasTodas)
                    {
                        LotesProducto lote = db.LotesProducto.Where(s => s.LoteId == item.LoteId).FirstOrDefault();
                        dataMerma.Rows.Add(item.MermaId, item.LoteId, lote.ProductoId, lote.Producto, item.CantidadMermada, item.Identificador, item.FechaRealizacion);
                    }
                }
                else
                {
                    var listaMermasTodas = db.Mermas.Where(s => s.Identificador.Contains(TxtFiltrar.Texts)).OrderByDescending(s => s.MermaId).ToList();

                    foreach (var item in listaMermasTodas)
                    {
                        LotesProducto lote = db.LotesProducto.Where(s => s.LoteId == item.LoteId).FirstOrDefault();

                        if (lote.AlmacenId == auxIdAlmacen)
                        {
                            dataMerma.Rows.Add(item.MermaId, item.LoteId, lote.ProductoId, lote.Producto, item.CantidadMermada, item.Identificador, item.FechaRealizacion);
                        }
                    }
                }
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                
                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    Mermas merma = db.Mermas.Where(s => s.MermaId == int.Parse(cellValue.ToString())).FirstOrDefault();

                    LotesProducto lote = db.LotesProducto.Where(s => s.LoteId == merma.LoteId).FirstOrDefault();

                    var compra = db.ComprasInventario.Where(s => s.CompraId == lote.CompraId).FirstOrDefault();

                    TxtIDMerma.Text = merma.MermaId.ToString();
                    TxtCompraId.Text = lote.CompraId.ToString(); 
                    TxtLoteId.Text = lote.LoteId.ToString();
                    TxtCantidadRemover.Text = merma.CantidadMermada.ToString();
                    TxtIdentificador.Text = merma.Identificador.ToString();
                    TxtRazon.Text = merma.Razon.ToString();
                    TxtCostoUnitario.Text = lote.CostoU.ToString();
                    TxtCostoCompra.Text = lote.SubTotal.ToString();
                    TxtRelacionCosto.Text = (merma.CantidadMermada * lote.CostoU).ToString();
                    TxtPrecioVenta.Text = merma.PrecioVenta.ToString();
                    TxtRelacionPrecioVenta.Text = (merma.PrecioVenta * merma.CantidadMermada).ToString();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarMermas();
        }
    }
}
