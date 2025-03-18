
using NeoCobranza.Data;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_ComprasComercial;
using NeoCobranza.PnlInventario;
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
    public partial class PnlSeleccionarProveedor : Form
    {
        DataUtilities dataUtilities = new DataUtilities();


        public PnlSeleccionarProveedor()
        {
            InitializeComponent();

            DataTable dataBuscar = new DataTable();
        }

        private void PnlSeleccionarProveedor_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvProveedor);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);

            TxtCantidad.Focus();
            TxtCantidad.Select();

            FiltrarProveedor();
        }

        public void FiltrarProveedor()
        {
            dataUtilities.SetParameter("@NombreProveedor",TxtFiltrar.Text);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_GetProveedoresActivos");

                DataTable dt = new DataTable();

                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Proveedor", typeof(string));
                dt.Columns.Add("RUC", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));

                foreach (DataRow item in dtResponse.Rows)
                {
                    dt.Rows.Add(Convert.ToString(item["IdProveedor"]),
                        Convert.ToString(item["NombreEmpresa"]),
                        Convert.ToString(item["NoRuc"]),
                        Convert.ToString(item["NoTelefono"]));
                }

                DgvProveedor.DataSource = dt;
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
            if (!Decimal.TryParse(TxtCantidad.Text, out Decimal cantidad) || cantidad == 0)
            {
                MessageBox.Show("Debe digitar la cantidad de producto que desea agregar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCantidad.Select();
                TxtCantidad.Focus();
                return;
            }

            if (!Decimal.TryParse(TxtCosto.Text, out Decimal costo) || costo == 0)
            {
                MessageBox.Show("Debe digitar el costo de los productos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCosto.Select();
                TxtCosto.Focus();
                return;
            }


            if (DgvProveedor.SelectedRows.Count != 0)
            {
                ComprasInventario compras = Owner as ComprasInventario;

                compras.cantidad = cantidad;
                compras.costo = costo;
                compras.proveedor = DgvProveedor.SelectedRows[0].Cells[0].Value.ToString();
                compras.NombreProveedor = DgvProveedor.SelectedRows[0].Cells[1].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("No ha seleccionado un proveedor. Los proveedores se agregan en la sección de catalogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProveedor();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar más de un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar más de un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
