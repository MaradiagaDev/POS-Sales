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
    public partial class PnlInventarioAlmacenes : Form
    {
        public VMInventarioAlmacenes vMInventarioAlmacenes = new VMInventarioAlmacenes();

        public PnlInventarioAlmacenes()
        {
            InitializeComponent();
        }

        private void PnlInventarioAlmacenes_Load(object sender, EventArgs e)
        {
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);

            vMInventarioAlmacenes.InitModuloInventarioAlmacenes(this);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMInventarioAlmacenes.BuscarInventario();
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMInventarioAlmacenes.BuscarInventario();
        }

        private void CmbAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMInventarioAlmacenes.BuscarInventario();
        }


        private void BtnListaMermas_Click(object sender, EventArgs e)
        {
            if(CmbAlmacenes.Items.Count == 0)
            {
                MessageBox.Show("Para ver la lista de mermas debe haber almacenes en catalogos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ListaMermas frm = new ListaMermas(int.Parse(CmbAlmacenes.SelectedValue.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvCatalogo_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (CmbAlmacenes.Text == "Mostrar Todas")
                {
                    MessageBox.Show("Para hacer Ajuste de inventario tiene que seleccionar el almacén.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;

                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    ServiciosEstadares productos = db.ServiciosEstadares.Where(s => s.IdEstandar == int.Parse(cellValue.ToString())).FirstOrDefault();

                    PnlAgregarProductoSerie frmSerie = new PnlAgregarProductoSerie(int.Parse(cellValue.ToString()), int.Parse(CmbAlmacenes.SelectedValue.ToString()));
                    AddOwnedForm(frmSerie);
                    frmSerie.ShowDialog();

                }
            }
        }
    }
}
