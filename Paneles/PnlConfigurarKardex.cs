using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlConfigurarKardex : Form
    {
        PnlKardx auxFrm;
        public DataTable auxTablaProducto = new DataTable();
        private bool buscado = false;
        public PnlConfigurarKardex(PnlKardx frm)
        {
            InitializeComponent();
            auxFrm = frm;
        }

        private void PnlConfigurarKardex_Load(object sender, EventArgs e)
        {
            DgvProducto.EnableHeadersVisualStyles = false;
            DgvProducto.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            DgvProducto.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvProducto.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            DgvProducto.RowsDefaultCellStyle.BackColor = Color.White;

            using(NeoCobranzaContext db = new NeoCobranzaContext()) 
            {
                List<Almacenes> listBdAlmacenes = db.Almacenes.Where(s => s.Estatus == "Activo").OrderByDescending(s => s.AlmacenId).ToList();

                CmbAlmacen.ValueMember = "AlmacenId";
                CmbAlmacen.DisplayMember = "NombreAlmacen";
                CmbAlmacen.DataSource = listBdAlmacenes;

                auxTablaProducto.Columns.Add("Producto ID", typeof(string));
                auxTablaProducto.Columns.Add("Producto", typeof(string));

                DgvProducto.DataSource = auxTablaProducto;
            }

            Buscador();

            buscado = true;
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            Buscador();
        }

        private void Buscador()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                var serviciosProductos = db.ServiciosEstadares
                    .AsNoTracking()
                    .Where(s => s.Estado == "Activo" && s.MontoVd != 0 && s.NombreEstandar.Contains(TxtFiltroProducto.Text) && s.ClasificacionProducto == 0)
                    .ToList();

                var almacenId = int.Parse(CmbAlmacen.SelectedValue.ToString());

                var productos = (from sp in serviciosProductos
                                 join rap in db.RelAlmacenProducto
                                 on sp.IdEstandar equals rap.ProductoId
                                 where rap.AlmacenId == almacenId
                                 select new
                                 {
                                     sp.IdEstandar,
                                     sp.NombreEstandar
                                 }).ToList();

                auxTablaProducto.Rows.Clear();

                foreach (var producto in productos)
                {
                    auxTablaProducto.Rows.Add(producto.IdEstandar, producto.NombreEstandar);
                }
            }
        }

        private void CmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(DgvProducto.SelectedRows.Count > 0) 
            {
                auxFrm.LblProducto.Text = DgvProducto.SelectedRows[0].Cells[1].Value.ToString();
                auxFrm.LblAlmacen.Text = CmbAlmacen.Text;
                auxFrm.LblFechaInicial.Text = DtInicial.Text;
                auxFrm.LblFechaFinal.Text = DtFinal.Text;

                using(NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    var listaKardex = db.Kardex.Where(s => s.AlmacenId == int.Parse(CmbAlmacen.SelectedValue.ToString()) && s.ProductoId == int.Parse(DgvProducto.SelectedRows[0].Cells[0].Value.ToString())
                    && (s.Fecha >= DtInicial.Value && s.Fecha <= DtFinal.Value)).ToList();

                    auxFrm.dataTable.Rows.Clear();
                    foreach (var item in listaKardex)
                    {
                        auxFrm.dataTable.Rows.Add(item.Fecha,item.IdDocumento,item.Operacion,item.UnidadesEntrada,item.CostoUnitarioEntrada,item.TotalEntrada,
                            item.UnidadesSalida, item.CostoUnitarioSalida, item.TotalSalida, item.UnidadesSaldo,item.CostoUnitarioSaldo,item.CostoTotalSaldo);
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("No hay productos Seleccionados.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
    }
}
