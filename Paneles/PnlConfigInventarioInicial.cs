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
    public partial class PnlConfigInventarioInicial : Form
    {
        PnlAgregarProductos auxFrm;
        DataUtilities dataUtilities = new DataUtilities();
        public PnlConfigInventarioInicial(PnlAgregarProductos frm)
        {
            InitializeComponent();
            auxFrm = frm;
        }

        private void PnlConfigInventarioInicial_Load(object sender, EventArgs e)
        {
            this.TxtCantidad.Focus();
            this.TxtCantidad.Select();

            if (auxFrm.bitTieneInventarioInicial)
            {
                TxtCantidad.Text = Convert.ToString(auxFrm.DecCantidad);
                TxtCosto.Text = Convert.ToString(auxFrm.DecSubTotal);
            }


            //ALMACENES
            DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");
            var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable() where Convert.ToString(row.Field<string>("Estatus")) == "Activo" select row;

            if (filterRowAlmacenes.Any())
            {
                DataTable dataCmbAlmacenes = new DataTable();
                dataCmbAlmacenes = filterRowAlmacenes.CopyToDataTable();
 
                CmbAlmacen.ValueMember = "AlmacenId";
                CmbAlmacen.DisplayMember = "NombreAlmacen";
                CmbAlmacen.DataSource = dataCmbAlmacenes;
            }

            //OBTENER EL ALMACEN MOSTRADOR
            DataTable dtResponseMostrador = dataUtilities.GetAllRecords("Almacenes");
            var filterRowMostrador =
                from row in dtResponseMostrador.AsEnumerable()
                where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                select row;

            DataTable dtAlmacenMostrador = filterRowMostrador.CopyToDataTable();

            if (dtAlmacenMostrador.Rows.Count > 0)
            {
                CmbAlmacen.SelectedValue = Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]);
            }

            UIUtilities.PersonalizarDataGridView(DgvProveedor);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);

            FiltrarProveedor();
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            auxFrm.DecSubTotal = 0;
            auxFrm.DecCantidad = 0;
            auxFrm.bitTieneInventarioInicial = false;

            Dispose();
        }

        private void BtnAgregarCompra_Click(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(TxtCantidad.Text, out Decimal cantidad) || cantidad == 0)
            {
                MessageBox.Show("Debe digitar la cantidad de producto que desea agregar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Decimal.TryParse(TxtCosto.Text, out Decimal costo) || costo == 0)
            {

            }

            if (CmbAlmacen.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar almacenes para poder realizar una compra.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DgvProveedor.SelectedRows.Count != 0)
            {
                auxFrm.strProveedor = DgvProveedor.SelectedRows[0].Cells[0].Value.ToString();
                auxFrm.bitTieneInventarioInicial = true;
                auxFrm.DecCantidad = cantidad;
                auxFrm.DecSubTotal = costo;
                auxFrm.strAlmacen = Convert.ToString(CmbAlmacen.SelectedValue);

                DialogResult result = MessageBox.Show("¿Desea seguir modificando el producto?", "Confirmación",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Dispose();
                }
                else
                {
                    auxFrm.FuncionesPrincipales();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado un proveedor. Los proveedores se agregan en la sección de catalogo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
        }

        public void FiltrarProveedor()
        {
            dataUtilities.SetParameter("@NombreProveedor", TxtFiltrar.Text);
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

        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProveedor();
        }
    }
}
