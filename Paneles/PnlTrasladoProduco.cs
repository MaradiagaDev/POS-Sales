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
                    }
                   // PnlAgregarTipoTarjeta tipo = new PnlAgregarTipoTarjeta("Modificar", cellValue.ToString());
                   // tipo.ShowDialog();
                   // vMCatalogoTipoTarjetas.FuncionesPrincipales(this, "Buscar", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
