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
    public partial class PnlCatalogoSucursales : Form
    {

        public VMCatalogoSucursales vMCatalogoSucursales = new VMCatalogoSucursales();

        public PnlCatalogoSucursales()
        {
            InitializeComponent();
        }

        private void PnlCatalogoSucursales_Load(object sender, EventArgs e)
        {
            dgvCatalogoSucursales.EnableHeadersVisualStyles = false;
            dgvCatalogoSucursales.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgvCatalogoSucursales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogoSucursales.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogoSucursales.RowsDefaultCellStyle.BackColor = Color.White;
            vMCatalogoSucursales.auxSearch = TxtFiltrar.Texts;
            vMCatalogoSucursales.InitModuloCatalogoSucursales(this, "Buscar");
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoSucursales.auxSearch = TxtFiltrar.Texts;
            vMCatalogoSucursales.InitModuloCatalogoSucursales(this, "Buscar");
        }

        private void dgvCatalogoSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoSucursales.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoSucursales.auxId = cellValue.ToString();
                vMCatalogoSucursales.FuncionesPrincipales(this, "Bloquear");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregarSucursal frm = new PnlAgregarSucursal(this,"Crear","");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoSucursales.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogoSucursales.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PnlAgregarSucursal frm = new PnlAgregarSucursal(this, "Modificar", cellValue.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Sucursal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
