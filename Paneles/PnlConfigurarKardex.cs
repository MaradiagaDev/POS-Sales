
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
            auxTablaProducto.Rows.Clear();

            dataUtilities.SetParameter("@AlmacenId", CmbAlmacen.SelectedValue);
            dataUtilities.SetParameter("@CategoriaId", 0);
            dataUtilities.SetParameter("@ProveedorId", 0);
            dataUtilities.SetParameter("@Filtro", TxtFiltroProducto.Text);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacenYProveedor");

            if(auxTablaProducto.Columns.Count != 2)
            {
                auxTablaProducto.Columns.Add("ID", typeof(string));
                auxTablaProducto.Columns.Add("Producto", typeof(string));
            }

            foreach (DataRow item in dtResponse.Rows)
            {
                auxTablaProducto.Rows.Add(
                    Convert.ToString(item["ProductoId"]),
                    Convert.ToString(item["NombreProducto"])
                    );
            }

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
                auxFrm.DgvKardex.DataSource = dataUtilities.ExecuteStoredProcedure("Sp_KardexPromedio");

                this.Close();
            }
            else
            {
                MessageBox.Show("No hay productos Seleccionados.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
    }
}
