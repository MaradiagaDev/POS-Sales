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
    public partial class PnlRevisionInventario : Form
    {
        VMInventarioGeneral vMInventarioGeneral = new VMInventarioGeneral();
        private bool busquedaInicialRealizada = false;
        public PnlRevisionInventario()
        {
            InitializeComponent();
            dgvCatalogo.EnableHeadersVisualStyles = false;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCatalogo.RowsDefaultCellStyle.Font = new Font("Century Gothic", 9);
        }

        private void PnlRevisionInventario_Load(object sender, EventArgs e)
        {
            if (!busquedaInicialRealizada)
            {
                vMInventarioGeneral.InitPantallaRevision(this);
                busquedaInicialRealizada = true;
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMInventarioGeneral.BuscarInventario();
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busquedaInicialRealizada)
            {
                vMInventarioGeneral.BuscarInventario();
            }
        }

        private void CmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busquedaInicialRealizada)
            {
                vMInventarioGeneral.BuscarInventario();
            }
        }

        private void PnlRevisionInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                vMInventarioGeneral.BuscarInventario();
            }
        }
    }
}
