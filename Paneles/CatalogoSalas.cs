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
    public partial class CatalogoSalas : Form
    {
        VMCatalogoSalas vMCatalogoSalas = new VMCatalogoSalas();
        public CatalogoSalas()
        {
            InitializeComponent();
        }

        private void CatalogoSalas_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscar);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            vMCatalogoSalas.InitModuloSalas(this);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vMCatalogoSalas.FuncionesPrincipales(this, "Buscar", TxtFiltrar.Text);
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                vMCatalogoSalas.FuncionesPrincipales(this, "Bloquear", cellValue.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(dgvCatalogo.Rows.Count == 10)
            {
                MessageBox.Show("No se puede agregar mas de 10 Salas por sucursal.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarSala agregarSala = new AgregarSala("Crear", "");
            agregarSala.ShowDialog();
            vMCatalogoSalas.FuncionesPrincipales(this, "Buscar", "");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    AgregarSala motivoCancelacion = new AgregarSala("Modificar", cellValue.ToString());
                    motivoCancelacion.ShowDialog();
                    vMCatalogoSalas.FuncionesPrincipales(this, "Buscar", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Banco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
