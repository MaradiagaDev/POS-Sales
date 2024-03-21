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
    public partial class CatalogosInventario : Form
    {
        public VMCatalogosInventario vMCatalogosInventario = new VMCatalogosInventario();
        public string auxModulo;

        public CatalogosInventario(string opc)
        {
            InitializeComponent();
            this.auxModulo = opc;
            vMCatalogosInventario.InitModuloCatalogosInventario(this, opc);
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogo.RowsDefaultCellStyle.BackColor = Color.White;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregarProductos frm = new PnlAgregarProductos(this,"Crear",auxModulo,"");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PnlAgregarProductos frm = new PnlAgregarProductos(this, "Modificar", auxModulo, cellValue.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacén.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogosInventario.auxId = cellValue.ToString();
                vMCatalogosInventario.FuncionesPrincipales(this, "Bloquear");
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogosInventario.FuncionesPrincipales(this, "Buscar");
        }

        private void CatalogosInventario_Load(object sender, EventArgs e)
        {
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogo.RowsDefaultCellStyle.BackColor = Color.White;
        }
    }
}
