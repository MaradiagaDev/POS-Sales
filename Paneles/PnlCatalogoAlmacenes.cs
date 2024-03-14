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
    public partial class PnlCatalogoAlmacenes : Form
    {
        public VMCatalogoAlmacenes vMCatalogoAlmacenes = new VMCatalogoAlmacenes();

        public PnlCatalogoAlmacenes()
        {
            InitializeComponent();
        }

        private void PnlCatalogoAlmacenes_Load(object sender, EventArgs e)
        {
            vMCatalogoAlmacenes.auxSearch = TxtFiltrar.Texts;
            vMCatalogoAlmacenes.InitModuloCatalogoAlmacenes(this, "Buscar");
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoAlmacenes.auxSearch = TxtFiltrar.Texts;
            vMCatalogoAlmacenes.InitModuloCatalogoAlmacenes(this, "Buscar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregarAlmacen frm = new PnlAgregarAlmacen(this, "Crear", "");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoAlmacenes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogoAlmacenes.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PnlAgregarAlmacen frm = new PnlAgregarAlmacen(this, "Modificar", cellValue.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacén.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCatalogoAlmacenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoAlmacenes.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoAlmacenes.auxId = cellValue.ToString();
                vMCatalogoAlmacenes.FuncionesPrincipales(this, "Bloquear");
            }
        }
    }
}
