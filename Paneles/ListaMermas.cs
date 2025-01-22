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
    public partial class ListaMermas : Form
    {
        string auxIdAlmacen;
        string auxIdAlmacenSeleccionado;
        string auxIdProducto;
        string nombreAlmacen;
        DataTable dataMerma = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();

        public ListaMermas(string AlmacenID)
        {
            InitializeComponent();
            auxIdAlmacen = AlmacenID;
        }

        private void ListaMermas_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);

            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = "  Ver Información  ";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            dgvCatalogo.Columns.Add(BtnCambioEstado);

            BtnRevertir.Enabled = false;

            dataMerma.Columns.Add("MermaID", typeof(string));
            dataMerma.Columns.Add("Producto", typeof(string));
            dataMerma.Columns.Add("Almacen", typeof(string));
            dataMerma.Columns.Add("Cantidad Mermada", typeof(string));
            dataMerma.Columns.Add("Identificador", typeof(string));
            dataMerma.Columns.Add("Fecha Creación", typeof(string));
            dataMerma.Columns.Add("Revertida", typeof(string));
            dataMerma.Columns.Add("Usuario Revirtió", typeof(string));

            dgvCatalogo.DataSource = dataMerma;

            if (auxIdAlmacen == "0")
            {
                LblDynamico.Text = "Todas las Mermas";
            }
            else
            {
                DataTable dtResponse = dataUtilities.getRecordByPrimaryKey("Almacenes", auxIdAlmacen);
                nombreAlmacen = Convert.ToString(dtResponse.Rows[0]["NombreAlmacen"]);
                LblDynamico.Text = $"Mermas del Almacén: {nombreAlmacen}";
            }

            BuscarMermas();
        }

        private void BuscarMermas()
        {
            dataMerma.Rows.Clear();
            DataTable dtResponse = dataUtilities.GetAllRecords("Mermas");

            if (auxIdAlmacen == "0")
            {
                var filterRow =
                    from row in dtResponse.AsEnumerable()
                    where Convert.ToString(row.Field<string>("Identificador")).Contains(TxtFiltrar.Text)
                    select row;

                if (filterRow.Any())
                {
                    dtResponse = filterRow.CopyToDataTable();

                    foreach (DataRow item in dtResponse.Rows)
                    {
                        DataTable dtResponseProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item["ProductoId"]));
                        DataTable dtResponseAlmacenes = dataUtilities.getRecordByPrimaryKey("Almacenes", Convert.ToString(item["AlmacenId"]));

                        string revertida = Convert.ToBoolean(item["BoolRevertida"]) == true ? "SI" : "NO";

                        dataMerma.Rows.Add(Convert.ToString(item["MermaId"]),
                            Convert.ToString(dtResponseProducto.Rows[0]["NombreProducto"]),
                             Convert.ToString(dtResponseAlmacenes.Rows[0]["NombreAlmacen"]),
                             Convert.ToString(item["CantidadMermada"]),
                             Convert.ToString(item["Identificador"]),
                              Convert.ToString(item["FechaRealizacion"]),
                              revertida, Convert.ToString(item["UsuarioRevirtio"]));
                    }
                }
            }
            else
            {
                var filterRow =
                   from row in dtResponse.AsEnumerable()
                   where Convert.ToString(row.Field<string>("Identificador")).Contains(TxtFiltrar.Text)
                   && Convert.ToString(row.Field<string>("AlmacenId")) == auxIdAlmacen
                   select row;

                if (filterRow.Any())
                {
                    dtResponse = filterRow.CopyToDataTable();

                    foreach (DataRow item in dtResponse.Rows)
                    {
                        DataTable dtResponseProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", Convert.ToString(item["ProductoId"]));

                        string revertida = Convert.ToBoolean(item["BoolRevertida"]) == true ? "SI" : "NO";

                        dataMerma.Rows.Add(Convert.ToString(item["MermaId"]),
                            Convert.ToString(dtResponseProducto.Rows[0]["NombreProducto"]),
                             nombreAlmacen,
                             Convert.ToString(item["CantidadMermada"]),
                             Convert.ToString(item["Identificador"]),
                              Convert.ToString(item["FechaRealizacion"]),
                              revertida, Convert.ToString(item["UsuarioRevirtio"]));
                    }
                }
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                object cellValue = dgvCatalogo.Rows[e.RowIndex].Cells[1].Value;

                DataTable dtResponseMerma = dataUtilities.getRecordByPrimaryKey("Mermas", Convert.ToString(cellValue));

                TxtIDMerma.Text = Convert.ToString(dtResponseMerma.Rows[0]["MermaId"]);
                TxtProducto.Text = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[2].Value);
                TxtCantidadRemover.Text = Convert.ToString(dtResponseMerma.Rows[0]["CantidadMermada"]);
                TxtIdentificador.Text = Convert.ToString(dtResponseMerma.Rows[0]["Identificador"]);
                TxtRazon.Text = Convert.ToString(dtResponseMerma.Rows[0]["Razon"]);
                TxtPrecioVenta.Text = Convert.ToString(dtResponseMerma.Rows[0]["PrecioVenta"]);
                TxtTipo.Text = Convert.ToString(dtResponseMerma.Rows[0]["TipoMerma"]);
                auxIdProducto = Convert.ToString(dtResponseMerma.Rows[0]["ProductoId"]);
                auxIdAlmacenSeleccionado = Convert.ToString(dtResponseMerma.Rows[0]["AlmacenId"]);
                BtnRevertir.Enabled = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[7].Value) == "SI" ? false : true;
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarMermas();
        }

        private void BtnRevertir_Click(object sender, EventArgs e)
        {
            DataTable dtResponse = dataUtilities.GetAllRecords("RelAlmacenProducto");
            var filterRow =
                from row in dtResponse.AsEnumerable()
                where Convert.ToString(row.Field<string>("AlmacenId")) == auxIdAlmacenSeleccionado
                && Convert.ToString(row.Field<string>("ProductoId")) == auxIdProducto
                select row;

            DataTable dtRelAlmacenProducto = filterRow.CopyToDataTable();

            decimal totalActual = Convert.ToDecimal(dtRelAlmacenProducto.Rows[0]["Cantidad"]);

            if (TxtTipo.Text == "Disminuir" )
            {
                dataUtilities.SetColumns("Cantidad", (totalActual + Convert.ToDecimal(TxtCantidadRemover.Text)));
            }
            else if (TxtTipo.Text == "Aumentar")
            {
                dataUtilities.SetColumns("Cantidad", (totalActual - Convert.ToDecimal(TxtCantidadRemover.Text)));
            }
            else
            {
                dataUtilities.SetColumns("Cantidad", (totalActual + Convert.ToDecimal(TxtCantidadRemover.Text)));
            }
          
            dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", Convert.ToDecimal(dtRelAlmacenProducto.Rows[0]["RelAlmacenProductoId"]));

            //Actualizar la merma
            dataUtilities.SetColumns("BoolRevertida",true);
            dataUtilities.SetColumns("UsuarioRevirtio", Utilidades.Usuario);
            dataUtilities.UpdateRecordByPrimaryKey("Mermas", TxtIDMerma.Text);

            MessageBox.Show("La merma se ha revertido.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
