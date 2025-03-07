using NeoCobranza.Clases;
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
    public partial class AlertasInventario : Form
    {
        DataTable data = new DataTable();
        DataUtilities dataUtilities = new DataUtilities();
        private string AlertaId = string.Empty;
        public AlertasInventario()
        {
            InitializeComponent();
        }

        private void AlertasInventario_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarComboBox(CmbAlmacenes);
            UIUtilities.ConfigurarBotonCrear(btnActualizar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);

            //ALMACENES
            DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");
            var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable() where Convert.ToString(row.Field<string>("Estatus")) == "Activo" select row;

            if (filterRowAlmacenes.Any())
            {
                CmbAlmacenes.ValueMember = "AlmacenId";
                CmbAlmacenes.DisplayMember = "NombreAlmacen";
                CmbAlmacenes.DataSource = filterRowAlmacenes.CopyToDataTable();
            }
            else
            {
                MessageBox.Show("Debe agregar un almacén para realizar alertas.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            DataGridViewButtonColumn BtnSeleccionar = new DataGridViewButtonColumn();

            BtnSeleccionar.Text = "  Seleccionar  ";
            BtnSeleccionar.Name = "...";
            BtnSeleccionar.UseColumnTextForButtonValue = true;
            BtnSeleccionar.DefaultCellStyle.ForeColor = Color.Blue;
            dgvCatalogo.Columns.Add(BtnSeleccionar);

            // Definir las columnas
            data.Columns.Add("Id Alerta", typeof(string));
            data.Columns.Add("Id Producto", typeof(string));
            data.Columns.Add("Producto", typeof(string));
            data.Columns.Add("Cantidad Minima", typeof(string));
            data.Columns.Add("Cantidad Maxima", typeof(string));

            dgvCatalogo.DataSource = data;
            dgvCatalogo.Columns[1].Visible = false;
            dgvCatalogo.Columns[2].Visible = false;

            BuscarProducto();
        }

        public void BuscarProducto()
        {
            try
            {
                data.Rows.Clear();

                dataUtilities.SetParameter("@FiltroNombre", TxtFiltrar.Texts);
                dataUtilities.SetParameter("@FiltroAlmacenId", CmbAlmacenes.SelectedValue);

                DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ListarProductosConAlertas");

                if (data.Columns.Count != 0) 
                {
                    foreach (DataRow item in dtResponse.Rows)
                    {
                        data.Rows.Add(
                            Convert.ToString(item["AlertaId"]),
                            Convert.ToString(item["ProductoId"]),
                            Convert.ToString(item["NombreProducto"]),
                            Convert.ToString(item["CantidadMinima"]),
                            Convert.ToString(item["CantidadMaxima"]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string ProductoId = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[2].Value);
                AlertaId = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[1].Value);

                TxtIdProducto.Enabled = true;
                TxtProducto.Enabled = true;
                TxtCantidadMaxima.Enabled = true;
                TxtCantidadMinima.Enabled = true;

                LblIdProducto.Enabled = true;
                LblProducto.Enabled = true;
                LblCantidadMaxima.Enabled = true;
                LblCantidadMinima.Enabled = true;

                TxtIdProducto.Text = ProductoId;
                TxtProducto.Text = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[3].Value);
                TxtCantidadMaxima.Text = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[5].Value);
                TxtCantidadMinima.Text = Convert.ToString(dgvCatalogo.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        private void TxtCantidadMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un dígito ni la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un dígito ni la tecla de retroceso, marcar el evento como manejado
                e.Handled = true;
            }
        }

        private void TxtCantidadMaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un dígito ni la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un dígito ni la tecla de retroceso, marcar el evento como manejado
                e.Handled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 40))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidadMaxima = 0;
            int cantidadMinima = 0;

            // Validar que la cantidad máxima sea un número válido
            if (!int.TryParse(TxtCantidadMaxima.Text.Trim(), out cantidadMaxima))
            {
                MessageBox.Show("La cantidad máxima no es válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la cantidad mínima sea un número válido
            if (!int.TryParse(TxtCantidadMinima.Text.Trim(), out cantidadMinima))
            {
                MessageBox.Show("La cantidad mínima no es válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la cantidad máxima sea mayor que la mínima, excepto cuando ambas sean cero
            if (cantidadMaxima < cantidadMinima && !(cantidadMaxima == 0 && cantidadMinima == 0))
            {
                MessageBox.Show("La cantidad máxima no puede ser menor que la mínima.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí puedes continuar con el guardado, ya que las validaciones pasaron.

            dataUtilities.SetColumns("CantidadMinima",TxtCantidadMinima.Text.Trim());
            dataUtilities.SetColumns("CantidadMaxima",TxtCantidadMaxima.Text.Trim());
            
            dataUtilities.UpdateRecordByPrimaryKey("AlertasInventario", AlertaId);

            BuscarProducto();

                MessageBox.Show("Alerta actualizada.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void CmbAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }
    }
}
