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
    public partial class PnlAsociacionProveedor : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        public string auxProducto;
        public PnlAsociacionProveedor(string auxIdProducto)
        {
            InitializeComponent();

            this.auxProducto = auxIdProducto;

            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "Asociar";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            DgvProveedor.Columns.Add(BtnCambioEstado);

            DataGridViewButtonColumn BtnAsociar = new DataGridViewButtonColumn();
            BtnAsociar.Text = "Quitar";
            BtnAsociar.Name = "...";
            BtnAsociar.UseColumnTextForButtonValue = true;
            BtnAsociar.DefaultCellStyle.ForeColor = Color.Blue;
            DgvAsociados.Columns.Add(BtnAsociar);

            filtrarProveedores();
            filtrarAsociados();
        }

        private void PnlAsociacionProveedor_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridViewPequeños(DgvProveedor);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvAsociados);
            DgvProveedor.Columns[1].Visible = false;
            DgvAsociados.Columns[1].Visible = false;
        }

        private void filtrarProveedores()
        {
            dataUtilities.SetParameter("@NombreProveedor", TxtFiltro.Text);
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

        private void filtrarAsociados()
        {
            dataUtilities.SetParameter("@ProductoId", auxProducto);
            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_GetProveedoresActivosPorProducto");

            DgvAsociados.DataSource = dtResponse;
        }

        private void DgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    object cellValue = DgvProveedor.Rows[e.RowIndex].Cells[1].Value;

                    //Verificar
                    dataUtilities.SetParameter("@IdProducto", auxProducto);
                    dataUtilities.SetParameter("@IdProveedor", cellValue.ToString());

                    DataRow row = dataUtilities.ExecuteStoredProcedure("spVerificarProveedoresAsociados").Rows[0];

                    if (Convert.ToString(row[0]) != "0")
                    {
                        MessageBox.Show("El vendedor ya fue asociado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Agregar
                    dataUtilities.SetColumns("ProductoId", auxProducto);
                    dataUtilities.SetColumns("ProveedorId", cellValue.ToString());
                    dataUtilities.InsertRecord("RelProveedoresProducto");

                    DataTable dtResponseRelAlmacen = dataUtilities.getRecordByColumn("RelAlmacenProducto", "ProductoId",auxProducto);

                    foreach(DataRow item in dtResponseRelAlmacen.Rows)
                    {
                        //Agregar el rel
                        dataUtilities.SetColumns("RelAlmacenProductoId", Convert.ToString(item[0]));
                        dataUtilities.SetColumns("ProveedorId", cellValue.ToString());
                        dataUtilities.SetColumns("Cantidad", 0);
                        dataUtilities.InsertRecord("DetalleAlmacenProveedor");
                    }

                    filtrarAsociados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvAsociados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    object cellValue = DgvAsociados.Rows[e.RowIndex].Cells[1].Value;

                    dataUtilities.SetParameter("@IdProducto", auxProducto );
                    dataUtilities.SetParameter("@IdProveedor", cellValue.ToString());
                    dataUtilities.ExecuteStoredProcedure("spDeleteAsociacionesProveedores");

                    filtrarAsociados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
