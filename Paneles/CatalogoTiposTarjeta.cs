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
    public partial class CatalogoTiposTarjeta : Form
    {
        VMCatalogoTipoTarjetas vMCatalogoTipoTarjetas = new VMCatalogoTipoTarjetas();

        public CatalogoTiposTarjeta()
        {
            InitializeComponent();
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregarTipoTarjeta frm = new PnlAgregarTipoTarjeta("Crear","");
            frm.ShowDialog();
            vMCatalogoTipoTarjetas.FuncionesPrincipales(this, "Buscar", "");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PnlAgregarTipoTarjeta tipo = new PnlAgregarTipoTarjeta("Modificar", cellValue.ToString());
                    tipo.ShowDialog();
                    vMCatalogoTipoTarjetas.FuncionesPrincipales(this, "Buscar", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Tipo Tarjeta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoTipoTarjetas.FuncionesPrincipales(this, "Bloquear", cellValue.ToString());
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vMCatalogoTipoTarjetas.FuncionesPrincipales(this, "Buscar", "");
        }

        private void CatalogoTiposTarjeta_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscar);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            vMCatalogoTipoTarjetas.InitModuloBancos(this);
        }
    }
}
