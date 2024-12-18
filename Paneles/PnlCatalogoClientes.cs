using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NeoCobranza.Paneles
{
    public partial class PnlCatalogoClientes : Form
    {
        VMCatalogoCliente vMCatalogoCliente = new VMCatalogoCliente();

        public PnlCatalogoClientes()
        {
            InitializeComponent();
        }

        private void PnlCatalogoClientes_Load(object sender, EventArgs e)
        {
            //Configuraciones UI
            UIUtilities.PersonalizarDataGridView(dgvCatalogoClientes);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarComboBox(CmbBuscarPor);
            UIUtilities.ConfigurarComboBox(CmbSucursal);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarBotonAnterior(BtnAnterior);
            UIUtilities.ConfigurarBotonSiguiente(BtnSiguiente);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);

            vMCatalogoCliente.InitModuloCatalogoClientes(this);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PanelModificarCliente frm = new PanelModificarCliente(this, "Crear");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogoClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogoClientes.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PanelModificarCliente frm = new PanelModificarCliente(this, cellValue.ToString());
                    frm.ShowDialog();
                }
            }
            else
            {
                //Validaciones

                MessageBox.Show("Debe seleccionar un cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvCatalogoClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoClientes.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoCliente.CambiarEstadoCliente(this, cellValue.ToString());
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (vMCatalogoCliente.currentPage < vMCatalogoCliente.totalPages)
            {
                vMCatalogoCliente.currentPage++;
                vMCatalogoCliente.UpdatePagination(this);
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (vMCatalogoCliente.currentPage > 1)
            {
                vMCatalogoCliente.currentPage--;
                vMCatalogoCliente.UpdatePagination(this);
            }
        }

        private void CmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }
    }
}
