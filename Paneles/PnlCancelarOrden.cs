using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Venta;
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
    public partial class PnlCancelarOrden : Form
    {
        public DataTable dynamicDataTable = new DataTable();
        public string auxKey = string.Empty;
        PnlVentas auxFrm = null;
        DataUtilities dataUtilities = new DataUtilities();

        public PnlCancelarOrden(string key, PnlVentas frm)
        {
            this.auxKey = key;
            this.auxFrm = frm;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarOrden_Click(object sender, EventArgs e)
        {
            dataUtilities.SetColumns("MotivoCancelacion", TxtMotivoCancelacion.Text.Trim());
            dataUtilities.SetColumns("OrdenProceso", "Orden Cancelada");

            dataUtilities.UpdateRecordByPrimaryKey("Ordenes", auxKey);

            //Obtener el almacen mostrador
            DataTable dtResponse = dataUtilities.GetAllRecords("Almacenes");
            var filterRow =
                from row in dtResponse.AsEnumerable()
                where Convert.ToBoolean(row.Field<bool>("EsMostrador")) == true
                && Convert.ToString(row.Field<string>("SucursalId")) == Utilidades.SucursalId
                select row;

            string idAlmacenMostrador = "";

            if (filterRow.Any())
            {
                DataTable dtAlmacenMostrador = filterRow.CopyToDataTable();
                idAlmacenMostrador = Convert.ToString(dtAlmacenMostrador.Rows[0]["AlmacenId"]);
            }

            //Quitar el detalle
            DataTable dtResponseDetalle = dataUtilities.getRecordByColumn("OrdenDetalle", "OrdenId", auxKey);

            foreach (DataRow item in dtResponseDetalle.Rows)
            {
                //Verificar que el item sea producto
                DataRow itemProducto = dataUtilities.getRecordByPrimaryKey("ProductosServicios", item["ProductoId"]).Rows[0];

                if (Convert.ToString(itemProducto["ClasificacionProducto"]) == "Productos")
                {
                    //Obtener el rel para agregar el inventario
                    DataTable dtResponseRel = dataUtilities.GetAllRecords("RelAlmacenProducto");
                    var filterRowRel =
                        from row in dtResponseRel.AsEnumerable()
                        where Convert.ToString(row.Field<string>("AlmacenId")) == idAlmacenMostrador
                        && Convert.ToString(row.Field<string>("ProductoId")) == Convert.ToString(item["ProductoId"])
                        select row;

                    if (filterRowRel.Any())
                    {
                        DataRow itemRel = filterRowRel.CopyToDataTable().Rows[0];

                        decimal cantidadAlmacen = Convert.ToDecimal(itemRel["Cantidad"]) + Convert.ToDecimal(item["Cantidad"]);

                        dataUtilities.SetColumns("Cantidad", cantidadAlmacen);
                        dataUtilities.UpdateRecordByPrimaryKey("RelAlmacenProducto", itemRel["RelAlmacenProductoId"]);
                    }
                }
            }

            MessageBox.Show("La orden ha sido Cancelada", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            auxFrm.Close();
        }

        private void PnlCancelarOrden_Load(object sender, EventArgs e)
        {
            dynamicDataTable.Columns.Add("Lista Motivos", typeof(string));
            DgvItems.DataSource = dynamicDataTable;

            // Agregar una columna de botón
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "...";
            buttonColumn.Text = "Agregar";
            buttonColumn.UseColumnTextForButtonValue = true;
            DgvItems.Columns.Add(buttonColumn);


            DataTable dtResponse = dataUtilities.GetAllRecords("vwMotivosCancelacion");

            foreach (DataRow item in dtResponse.Rows)
            {
                dynamicDataTable.Rows.Add(Convert.ToString(item["Motivo"]));
            }

        }

        private void DgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                object cellValue = DgvItems.Rows[e.RowIndex].Cells[0].Value;

                if (TxtMotivoCancelacion.Text.Trim() == "")
                {
                    TxtMotivoCancelacion.Text = $"{cellValue.ToString()}";
                }
                else
                {
                    TxtMotivoCancelacion.Text = $"{TxtMotivoCancelacion.Text} ,{cellValue.ToString()}";
                }

            }
        }
    }
}
