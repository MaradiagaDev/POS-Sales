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
    public partial class CatalogoBancos : Form
    {
        VMCatalogoBanco vMCatalogoBanco = new VMCatalogoBanco();
        public CatalogoBancos()
        {
            InitializeComponent();
        }

        private void CatalogoBancos_Load(object sender, EventArgs e)
        {
            //Configuraciones UI
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscar);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            vMCatalogoBanco.InitModuloBancos(this);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vMCatalogoBanco.FuncionesPrincipales(this, "Buscar", TxtFiltrar.Text);
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoBanco.FuncionesPrincipales(this, "Bloquear", cellValue.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarBancos motivoCancelacion = new AgregarBancos("Crear", "");
            motivoCancelacion.ShowDialog();
            vMCatalogoBanco.FuncionesPrincipales(this, "Buscar", "");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    AgregarBancos motivoCancelacion = new AgregarBancos("Modificar", cellValue.ToString());
                    motivoCancelacion.ShowDialog();
                    vMCatalogoBanco.FuncionesPrincipales(this, "Buscar", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Banco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
