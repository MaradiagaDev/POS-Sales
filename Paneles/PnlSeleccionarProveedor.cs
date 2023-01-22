using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.Paneles_ComprasComercial;
using NeoCobranza.PnlInventario;
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
    public partial class PnlSeleccionarProveedor : Form
    {
        public Conexion conexion;

        public Proveedor proveedor;

        public PnlSeleccionarProveedor(Conexion conexion)
        {
            InitializeComponent();

            this.conexion= conexion;
            this.proveedor = new Proveedor(conexion);

            //Estilo
            dgvProveedor.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvProveedor.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            dgvProveedor.DataSource = proveedor.Mostra_Proveedores(txtFiltro.Texts);
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            dgvProveedor.DataSource = proveedor.Mostra_Proveedores(txtFiltro.Texts);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedRows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
                return;
            }

            PnlCompras pnlCompras = Owner as PnlCompras;

            pnlCompras.txtNombreProveedor.Text = dgvProveedor.SelectedRows[0].Cells["NombreEmpresa"].Value.ToString();

            pnlCompras.txtIdProveedor.Text= dgvProveedor.SelectedRows[0].Cells["IdProveedor"].Value.ToString();

            pnlCompras.txtEstadoProveedor.ForeColor = Color.Green;

            pnlCompras.txtEstadoProveedor.Text = "Agregado en el sistema";

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PnlSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            dgvProveedor.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }
    }
}
