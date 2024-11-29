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
    public partial class CatologoMotivosCancelacion : Form
    {
        VMMotivosCancelacion vMMotivosCancelacion = new VMMotivosCancelacion();

        public CatologoMotivosCancelacion()
        {
            InitializeComponent();
        }

        private void CatologoMotivosCancelacion_Load(object sender, EventArgs e)
        {
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvCatalogo.RowsDefaultCellStyle.BackColor = Color.White;
            vMMotivosCancelacion.InitModuloMotivosCancelacion(this);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            vMMotivosCancelacion.FuncionesPrincipales(this, "Buscar", "");
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;
                vMMotivosCancelacion.FuncionesPrincipales(this, "Bloquear", cellValue.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarMotivoCancelacion motivoCancelacion = new AgregarMotivoCancelacion("Crear", "");
            motivoCancelacion.ShowDialog();
            vMMotivosCancelacion.FuncionesPrincipales(this, "Buscar", "");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogo.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    AgregarMotivoCancelacion motivoCancelacion = new AgregarMotivoCancelacion("Modificar", cellValue.ToString());
                    motivoCancelacion.ShowDialog();
                    vMMotivosCancelacion.FuncionesPrincipales(this, "Buscar", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacén.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
