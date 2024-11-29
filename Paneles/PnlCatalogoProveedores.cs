using NeoCobranza.Clases;
using NeoCobranza.Data;
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
    public partial class PnlCatalogoProveedores : Form
    {
        VMCatalogoProveedores vMCatalogoProveedores = new VMCatalogoProveedores();

        public PnlCatalogoProveedores()
        {
            InitializeComponent();
        }

        private void PnlCatalogoProveedores_Load(object sender, EventArgs e)
        {
            dgvCatalogoProveedores.EnableHeadersVisualStyles = false;
            dgvCatalogoProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgvCatalogoProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogoProveedores.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogoProveedores.RowsDefaultCellStyle.BackColor = Color.White;
            vMCatalogoProveedores.InitModuloProveedores(this);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            //TODO: Mostrar el dashboard\
            this.Dispose();
        }

        private void dgvCatalogoProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoProveedores.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoProveedores.FuncionesPrincipales(this,"CambiarEstado",cellValue.ToString());
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoProveedores.FuncionesPrincipales(this, "Buscar", "");

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregarProveedor frm = new PnlAgregarProveedor(this,"Crear","");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoProveedores.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogoProveedores.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    vMCatalogoProveedores.auxId = cellValue.ToString();
                    PnlAgregarProveedor frm = new PnlAgregarProveedor(this, "Modificar",cellValue.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                //Validaciones

                MessageBox.Show("Debe seleccionar un proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
