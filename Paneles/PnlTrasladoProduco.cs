using NeoCobranza.Clases;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlTrasladoProduco : Form
    {
        public DataTable auxTablaDinamica = new DataTable();
        public DataTable auxTablaProducto = new DataTable();
        public bool buscado = false;
        DataUtilities dataUtilities = new DataUtilities();

        public PnlTrasladoProduco()
        {
            InitializeComponent();
        }

        private void PnlTrasladoProduco_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridViewPequeños(dgvCatalogo);
            UIUtilities.PersonalizarDataGridViewPequeños(DgvProducto);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarProducto);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltroProducto);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            UIUtilities.ConfigurarComboBox(CmbAlmacenEntrado);
            UIUtilities.ConfigurarComboBox(CmbAlmacenSalida);

            DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");

            var filterRow = from row in
                                dtResponse.AsEnumerable()
                            where
                                Convert.ToString(row.Field<string>("Estatus")) == "Activo"
                            orderby
                                row.Field<string>("NombreAlmacen") descending
                            select row;


            if (!filterRow.Any())
            {
                MessageBox.Show("No ha agregado almacenes o no hay almacenes activos.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
                return;
            }

            CmbAlmacenEntrado.ValueMember = "AlmacenId";
            CmbAlmacenEntrado.DisplayMember = "NombreAlmacen";
            CmbAlmacenEntrado.DataSource = filterRow.CopyToDataTable();

            CmbAlmacenSalida.ValueMember = "AlmacenId";
            CmbAlmacenSalida.DisplayMember = "NombreAlmacen";
            CmbAlmacenSalida.DataSource = filterRow.CopyToDataTable();

            DataGridViewButtonColumn BtnCambioEstado = new DataGridViewButtonColumn();

            BtnCambioEstado.Text = " Quitar ";
            BtnCambioEstado.Name = "...";
            BtnCambioEstado.UseColumnTextForButtonValue = true;
            BtnCambioEstado.DefaultCellStyle.ForeColor = Color.Blue;
            dgvCatalogo.Columns.Add(BtnCambioEstado);

            auxTablaDinamica.Columns.Add("ProductoID", typeof(string));
            auxTablaDinamica.Columns.Add("Producto", typeof(string));
            auxTablaDinamica.Columns.Add("Cantidad Trasladada", typeof(string));

            dgvCatalogo.DataSource = auxTablaDinamica;
            dgvCatalogo.Columns[1].Visible = false;
            auxTablaProducto.Columns.Add("Producto ID", typeof(string));
            auxTablaProducto.Columns.Add("Existencias", typeof(string));
            auxTablaProducto.Columns.Add("Producto", typeof(string));

            DgvProducto.DataSource = auxTablaProducto;
            DgvProducto.Columns[0].Visible = false;

            Buscador();
            buscado = true;
        }

        private void Buscador()
        {
            auxTablaProducto.Rows.Clear();

            dataUtilities.SetParameter("@AlmacenId", CmbAlmacenSalida.SelectedValue);
            dataUtilities.SetParameter("@CategoriaId", 0);
            dataUtilities.SetParameter("@ProveedorId", 0);
            dataUtilities.SetParameter("@Filtro", TxtFiltroProducto.Text);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacenYProveedor");

            foreach (DataRow producto in dtResponse.Rows)
            {
                auxTablaProducto.Rows.Add(Convert.ToString(producto["ProductoId"])
                    , Convert.ToString(producto["cantidad"]), Convert.ToString (producto["NombreProducto"]));
            }
        }


        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (buscado == true)
            {
                Buscador();
            }
        }

        private void CmbAlmacenSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buscado == true)
            {
                Buscador();
            }
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (DgvProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvProducto.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    if (cellValue == null ||
                     !decimal.TryParse(cellValue.ToString(), out decimal valor) ||
                       valor == 0)
                    {
                        MessageBox.Show("No hay existencias del producto seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (CmbAlmacenSalida.SelectedValue.ToString() == CmbAlmacenEntrado.SelectedValue.ToString())
                    {
                        MessageBox.Show("Debe seleccionar almacenes distintos para realizar el traslado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TxtCantidad.Text.Trim()) ||
                     !decimal.TryParse(TxtCantidad.Text.Trim(), out decimal cantidad) ||
                        cantidad <= 0)
                    {
                        MessageBox.Show("Debe agregar una cantidad válida y mayor a cero para trasladar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cantidad > valor)
                    {
                        MessageBox.Show("No hay suficiente cantidad de producto para trasladar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach(DataRow item in auxTablaDinamica.Rows)
                    {
                        if (Convert.ToString(selectedRow.Cells[0].Value) == Convert.ToString(item[0]))
                        {
                            MessageBox.Show("El producto ya fue agregado al traslado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    auxTablaDinamica.Rows.Add(Convert.ToString(selectedRow.Cells[0].Value),
                        Convert.ToString(selectedRow.Cells[2].Value),
                        TxtCantidad.Text.Trim());

                    CmbAlmacenSalida.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                auxTablaDinamica.Rows.RemoveAt(e.RowIndex);

                if (auxTablaDinamica.Rows.Count > 0)
                {
                    CmbAlmacenEntrado.Enabled = false;
                    CmbAlmacenSalida.Enabled = false;
                }
                else
                {
                    CmbAlmacenEntrado.Enabled = true;
                    CmbAlmacenSalida.Enabled = true;
                }
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            auxTablaDinamica.Rows.Clear();
            CmbAlmacenSalida.Enabled = true;
            CmbAlmacenEntrado.Enabled = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (auxTablaDinamica.Rows.Count == 0)
                {
                    MessageBox.Show("No se han agregado productos al traslado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Crear traslado
                string IdTraslado = Guid.NewGuid().ToString();

                dataUtilities.SetParameter("@TrasladoId", IdTraslado);
                dataUtilities.SetParameter("@FechaTraslado", DateTime.Now);
                dataUtilities.SetParameter("@Usuario", Utilidades.Usuario);
                dataUtilities.SetParameter("@SucursalId", Utilidades.SucursalId);
                dataUtilities.SetParameter("@AlmacenIdEntrada", CmbAlmacenEntrado.SelectedValue);
                dataUtilities.SetParameter("@AlmacenIdSalida", CmbAlmacenSalida.SelectedValue);

                dataUtilities.ExecuteStoredProcedure("Sp_CrearTrasladoInventario");

                foreach (DataRow item in auxTablaDinamica.Rows)
                {
                    //Insertar detalle
                    dataUtilities.SetParameter("@TrasladoId", IdTraslado);
                    dataUtilities.SetParameter("@ProductoId", Convert.ToString(item[0]));
                    dataUtilities.SetParameter("@Cantidad", Convert.ToString(item[2]));

                    dataUtilities.ExecuteStoredProcedure("Sp_CrearTrasladoDetalle");
                }
                auxTablaDinamica.Rows.Clear();
                CmbAlmacenSalida.Enabled = true;
                CmbAlmacenEntrado.Enabled = true;

                MessageBox.Show("Traslado realizado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbAlmacenEntrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true; // Esto indica que el evento ha sido manejado, por lo que el carácter no será mostrado en el TextBox
            }
        }
    }
}
