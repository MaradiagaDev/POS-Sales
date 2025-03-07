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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (auxModulo == "Productos")
            {
                if (!Utilidades.PermisosLevel(3, 65))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (!Utilidades.PermisosLevel(3, 68))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            PnlAgregarProductos frm = new PnlAgregarProductos(this,"Crear",auxModulo,"");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //if (dgvCatalogo.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
            //    object cellValue = selectedRow.Cells[1].Value;

            //    if (cellValue != null)
            //    {
            //        PnlAgregarProductos frm = new PnlAgregarProductos(this, "Modificar", auxModulo, cellValue.ToString());
            //        frm.ShowDialog();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un Almacén.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
            //    vMCatalogosInventario.auxId = cellValue.ToString();
            //    vMCatalogosInventario.FuncionesPrincipales(this, "Bloquear");
            //}
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogosInventario.FuncionesPrincipales(this, "Buscar");
        }

        private void CatalogosInventario_Load(object sender, EventArgs e)
        {
            //Configuraciones UI
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);

            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                vMCatalogosInventario.FuncionesPrincipales(this, "Buscar");
                ActualizarEstadoBotones();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            // Se compara con el total de páginas que se muestra en TxtPaginaDe
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages) &&
                currentPage < totalPages)
            {
                currentPage++;
                TxtPaginaNo.Text = currentPage.ToString();
                vMCatalogosInventario.FuncionesPrincipales(this, "Buscar");
                ActualizarEstadoBotones();
            }
        }

        private void ActualizarEstadoBotones()
        {
            // Habilita o deshabilita según el número de página actual y el total de páginas
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages))
            {
                BtnAnterior.Enabled = currentPage > 1;
                BtnSiguiente.Enabled = currentPage < totalPages;
            }
        }

        private void flowLayoutPanelProductos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
