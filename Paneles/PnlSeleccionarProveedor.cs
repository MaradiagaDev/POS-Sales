
using NeoCobranza.Data;
using NeoCobranza.ModelsCobranza;
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


        public PnlSeleccionarProveedor()
        {
            InitializeComponent();

            DataTable dataBuscar = new DataTable();
        }

        private void PnlSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            FiltrarProveedor();
        }

        public void FiltrarProveedor()
        {
            using (NeoCobranzaContext db = new NeoCobranzaContext())
            {
                List<Proveedores> proveedors = db.Proveedores.Where(s => s.Estatus == true).Where(item => item.NombreEmpresa.Contains(txtFiltro.Texts) || item.NoRuc.Contains(txtFiltro.Texts)).OrderByDescending(s => s.IdProveedor).ToList();

                DataTable dt = new DataTable();

                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Proveedor", typeof(string));
                dt.Columns.Add("RUC", typeof(string));
                dt.Columns.Add("Celular", typeof(string));

                foreach (var item in proveedors)
                {
                    dt.Rows.Add(item.IdProveedor,item.NombreEmpresa, item.NoRuc, item.NoTelefono);
                }

                DgvProveedor.DataSource = dt;
            }
        }

        private void txtFiltro__TextChanged(object sender, EventArgs e)
        {
            FiltrarProveedor();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if(DgvProveedor.SelectedRows.Count != 0)
            {
                ComprasInventario compras = Owner as ComprasInventario;

                compras.TxtIdProveedor.Text = DgvProveedor.SelectedRows[0].Cells[0].Value.ToString();
                compras.TxtNombreProveedor.Text = DgvProveedor.SelectedRows[0].Cells[1].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No ha seleccionado un proveedor. Los proveedores se agregan en la sección de catalogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
