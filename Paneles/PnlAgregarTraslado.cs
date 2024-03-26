using NeoCobranza.ModelsCobranza;
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
    public partial class PnlAgregarTraslado : Form
    {
        PnlTrasladoProduco auxFrm;
        int auxIdProducto;
        int auxAlmacenSalida;
        int auxAlmacenEntrada;
        public DataTable auxTablaDinamicaAgregar = new DataTable();
        public PnlAgregarTraslado(PnlTrasladoProduco frm,int idProducto, int idAlmacenSalida, int idAlmacenEntrada)
        {
            InitializeComponent();
            auxFrm = frm;
            auxIdProducto = idProducto;
            auxAlmacenEntrada = idAlmacenEntrada;
            auxAlmacenSalida = idAlmacenSalida;
        }

        private void PnlAgregarTraslado_Load(object sender, EventArgs e)
        {
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvCatalogo.RowsDefaultCellStyle.BackColor = Color.White;

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

            dgvCatalogo.DataSource = auxTablaDinamicaAgregar;

            using(NeoCobranzaContext db = new NeoCobranzaContext())
            {
                Almacenes entrada = db.Almacenes.Where(s => s.AlmacenId == auxAlmacenEntrada).FirstOrDefault();
                TxtEntrada.Text = entrada.NombreAlmacen;
                Almacenes salida = db.Almacenes.Where(s => s.AlmacenId == auxAlmacenSalida).FirstOrDefault();
                TxtSalida.Text = salida.NombreAlmacen;

                var lotes = db.LotesProducto.Where(s => s.ProductoId == auxIdProducto && s.AlmacenId == auxAlmacenSalida && s.CantidadRestante > 0).OrderBy(s => s.FechaCreacion).ToList();

                foreach (var lote in lotes)
                {
                    var prov = db.Proveedores.Where(p => p.IdProveedor == lote.ProveedorId).FirstOrDefault();
                    auxTablaDinamicaAgregar.Rows.Add(lote.LoteId, lote.CompraId, lote.ProductoId, lote.Producto, prov.NombreEmpresa, lote.Cantidad, lote.CantidadRestante, lote.FechaCreacion, lote.FechaExpiracion, lote.CostoU);
                }
            }

            TxtCantidad.Focus();
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un dígito o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un dígito o la tecla de retroceso, ignora la pulsación de tecla
                e.Handled = true;
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if(TxtCantidad.Text.Trim() == "" || int.Parse(TxtCantidad.Text.Trim()) == 0)
            {
                MessageBox.Show("La cantidad trasladada debe ser mayor a cero.","Atención",MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if(dgvCatalogo.SelectedRows.Count == 0 )
            {
                MessageBox.Show("Debe seleccionar un lote para trasladar.", "Atención", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            if(int.Parse(TxtCantidad.Text) > int.Parse(dgvCatalogo.SelectedRows[0].Cells[6].Value.ToString()))
            {
                MessageBox.Show("La cantidad trasladada no puede ser mayor a la restante en el lote.", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            bool agregado = false;

            foreach (DataRow item in auxFrm.auxTablaDinamica.Rows)
            {
                if (item[0].ToString() == dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString())
                {
                    if((int.Parse(item[5].ToString()) + int.Parse(TxtCantidad.Text)) > int.Parse(dgvCatalogo.SelectedRows[0].Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("La cantidad trasladada no puede ser mayor a la restante en el lote.", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                        return;
                    }

                    item[5] = (int.Parse(item[5].ToString()) + int.Parse(TxtCantidad.Text)).ToString();
                    agregado = true;
                }
            }

            if (!agregado)
            {

                string guidString = Guid.NewGuid().ToString().Replace("-", "");

                string numeroAleatorio = guidString.Substring(0, 5);

                auxFrm.auxTablaDinamica.Rows.Add(dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString(),
                    dgvCatalogo.SelectedRows[0].Cells[0].Value.ToString()+"-"+numeroAleatorio,
                    dgvCatalogo.SelectedRows[0].Cells[2].Value.ToString(),
                    dgvCatalogo.SelectedRows[0].Cells[3].Value.ToString(),
                    dgvCatalogo.SelectedRows[0].Cells[4].Value.ToString(),
                    TxtCantidad.Text.Trim(),
                    dgvCatalogo.SelectedRows[0].Cells[7].Value.ToString(),
                    dgvCatalogo.SelectedRows[0].Cells[8].Value.ToString());
            }

            if(auxFrm.auxTablaDinamica.Rows.Count > 0)
            {
                auxFrm.CmbAlmacenEntrado.Enabled = false;
                auxFrm.CmbAlmacenSalida.Enabled = false;
            }
            else
            {
                auxFrm.CmbAlmacenEntrado.Enabled = true;
                auxFrm.CmbAlmacenSalida.Enabled = true;
            }

            this.Close();

        }
    }
}
