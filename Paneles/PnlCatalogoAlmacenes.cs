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
            UIUtilities.PersonalizarDataGridView(dgvCatalogoAlmacenes);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            vMCatalogoAlmacenes.InitModuloCatalogoAlmacenes(this, "Buscar");
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoAlmacenes.auxSearch = TxtFiltrar.Text;
            vMCatalogoAlmacenes.InitModuloCatalogoAlmacenes(this, "Buscar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 3))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PnlAgregarAlmacen frm = new PnlAgregarAlmacen(this, "Crear", "");
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 4))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (!Utilidades.PermisosLevel(3, 25))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogoAlmacenes.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoAlmacenes.auxId = cellValue.ToString();
                vMCatalogoAlmacenes.FuncionesPrincipales(this, "Bloquear");
            }
        }
    }
}
