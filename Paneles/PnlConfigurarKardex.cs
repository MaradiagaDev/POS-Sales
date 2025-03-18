
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoCobranza.Paneles
{
    public partial class PnlConfigurarKardex : Form
    {
        PnlKardx auxFrm;
        public DataTable auxTablaProducto = new DataTable();
        private bool buscado = false;
        DataUtilities dataUtilities = new DataUtilities();
        public PnlConfigurarKardex(PnlKardx frm)
        {
            InitializeComponent();
            auxFrm = frm;
        }

        private void PnlConfigurarKardex_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvProducto);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltroProducto);
            UIUtilities.ConfigurarComboBox(CmbAlmacen);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarProducto);
            UIUtilities.ConfigurarBotonCrear(BtnGuardar);

            //ALMACENES
            DataTable dtResponseAlmacenes = dataUtilities.GetAllRecords("Almacenes");
            var filterRowAlmacenes = from row in dtResponseAlmacenes.AsEnumerable() where Convert.ToString(row.Field<string>("Estatus")) == "Activo" select row;

            if (filterRowAlmacenes.Any())
            {
                CmbAlmacen.ValueMember = "AlmacenId";
                CmbAlmacen.DisplayMember = "NombreAlmacen";
                CmbAlmacen.DataSource = filterRowAlmacenes.CopyToDataTable();
            }
            else
            {
                MessageBox.Show("Debe agregar un almacén para realizar alertas.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            Buscador();

            buscado = true;
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            Buscador();
        }

        private void Buscador()
        {
            int pageNumber = 1;
            if (!int.TryParse(TxtPaginaNo.Text, out pageNumber))
            {
                pageNumber = 1;
                TxtPaginaNo.Text = "1";
            }

            // Definir el tamño de página (en este ejemplo se usan 20 registros por página)
            int pageSize = 20;

            auxTablaProducto.Rows.Clear();

            dataUtilities.SetParameter("@AlmacenId", CmbAlmacen.SelectedValue);
            dataUtilities.SetParameter("@CategoriaId", 0);
            dataUtilities.SetParameter("@Filtro", TxtFiltroProducto.Text);
            dataUtilities.SetParameter("@PageNumber", pageNumber);
            dataUtilities.SetParameter("@PageSize", pageSize);
            dataUtilities.SetParameter("@TotalRecords", System.Data.SqlDbType.Int, direction: System.Data.ParameterDirection.Output);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacen");

            if (auxTablaProducto.Columns.Count != 2)
            {
                auxTablaProducto.Columns.Add("ID", typeof(string));
                auxTablaProducto.Columns.Add("Producto", typeof(string));
            }

            foreach (DataRow item in dtResponse.Rows)
            {
                auxTablaProducto.Rows.Add(
                    Convert.ToString(item["ID"]),
                    Convert.ToString(item["PRODUCTO"])
                    );
            }

            int totalRecords = Convert.ToInt32(dataUtilities.GetParameterValue("@TotalRecords"));
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            TxtPaginaDe.Text = totalPages.ToString();

            dataUtilities.ClearOutPutParameters();

            DgvProducto.DataSource = auxTablaProducto;

            DgvProducto.Columns[0].Visible = false;

        }

        private void CmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(DgvProducto.SelectedRows.Count > 0) 
            {
                auxFrm.LblProducto.Text = Convert.ToString(DgvProducto.SelectedRows[0].Cells[1].Value);
                auxFrm.LblAlmacen.Text = CmbAlmacen.Text;
                auxFrm.LblFechaInicial.Text = DtInicial.Text;
                auxFrm.LblFechaFinal.Text = DtFinal.Text;

                dataUtilities.SetParameter("@ProductoId", Convert.ToString(DgvProducto.SelectedRows[0].Cells[0].Value));
                dataUtilities.SetParameter("@AlmacenId",CmbAlmacen.SelectedValue);
                dataUtilities.SetParameter("@FechaInicial",DtInicial.Value);
                dataUtilities.SetParameter("@FechaFinal",DtFinal.Value);

                auxFrm.dataTable.Rows.Clear();
                auxFrm.dataTable = dataUtilities.ExecuteStoredProcedure("Sp_KardexPromedio");
                auxFrm.DgvKardex.DataSource = auxFrm.dataTable;
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay productos Seleccionados.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                Buscador();
                ActualizarEstadoBotones();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            // Se compara con el total de páginas que se muestra en TxtPaginaDe
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages) &&
                currentPage < totalPages)
            {
                currentPage++;
                TxtPaginaNo.Text = currentPage.ToString();
                Buscador();
                ActualizarEstadoBotones();
            }
        }

        private void ActualizarEstadoBotones()
        {
            // Habilita o deshabilita según el número de página actual y el total de páginas
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages))
            {
                BtnAnterior.Enabled = currentPage > 1;
                BtnSiguiente.Enabled = currentPage < totalPages;
            }
        }
    }
}
