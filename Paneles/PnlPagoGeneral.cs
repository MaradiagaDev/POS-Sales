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
    public partial class PnlPagoGeneral : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        List<(string orden, string sucursalId,string restante)> AuxListaOrdenes;
        public PnlPagoGeneral(List<(string orden, string sucursalId,string restante)> ListaOrdenes)
        {
            InitializeComponent();
            AuxListaOrdenes = ListaOrdenes;
        }

        private void BtnPagarOrdenes_Click(object sender, EventArgs e)
        {
            decimal decTotal = 0;
            decimal decCount = 0;

            if(Convert.ToString(CmbBanco.SelectedValue) == "0" && ChkTarjeta.Checked == true)
            {
                MessageBox.Show("Debe seleccionar una cuenta para pagar por tarjeta.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            string formaPago = (ChkTarjeta.Checked != true)
                       ? "Efectivo"
                         : "Tarjeta-Minuta";

            foreach (var item in AuxListaOrdenes)
            {
                string numeroOrden = item.orden;
                string sucursalId = item.sucursalId;
                string restante = item.restante;

                DataRow itemOrden = dataUtilities.getRecordByPrimaryKey("Ordenes", numeroOrden).Rows[0];

                if (Convert.ToString(itemOrden["NoFactura"]) == "0")
                {
                    DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                    decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFacturaCredito"]) + 1;

                    dataUtilities.SetColumns("ConsecutivoFacturaCredito", NoFactura);

                    dataUtilities.UpdateRecordByPrimaryKey(
                        "ConfigFacturacion",
                        Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                    //Actualizar en la orden

                    dataUtilities.SetParameter("@IdOrden", numeroOrden);
                    dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@Factura", NoFactura);
                    dataUtilities.SetParameter("@serie", Convert.ToString(dtConfigFacturacion.Rows[0]["SerieCredito"]));

                    dataUtilities.ExecuteStoredProcedure("spActualizarFacturaOrden");
                }

                    decTotal += Convert.ToDecimal(restante);

                dataUtilities.SetParameter("@OrdenId", numeroOrden);
                dataUtilities.SetParameter("@FormaPago", formaPago);
                dataUtilities.SetParameter("@Pagado", restante);
                dataUtilities.SetParameter("@MontoTarjeta", "0");
                dataUtilities.SetParameter("@Cambio", "0");
                dataUtilities.SetParameter("@BancoId", CmbBanco.SelectedValue);
                dataUtilities.SetParameter("@TarjetaId", "0");
                dataUtilities.SetParameter("@Total", restante);
                dataUtilities.SetParameter("@NoReferencia", "PAGADO GENERAL");
                dataUtilities.SetParameter("@FechaPago", DateTime.Now);

                dataUtilities.ExecuteStoredProcedure("sp_AgregarPago");

                decCount++;
            }

            MessageBox.Show($"Ordenes Pagadas Correctamente! Forma Pago: {formaPago} / Total de Ordenes: {decCount.ToString()} / Total pagado: ${decTotal.ToString()}C$.", "Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);

            this.Close();
        }

        private void PnlPagoGeneral_Load(object sender, EventArgs e)
        {
            //Llenar Bancos
            DataTable dtResponseBanco = dataUtilities.GetAllRecords("Bancos");
            var filterRow = from row in dtResponseBanco.AsEnumerable() where Convert.ToString(row.Field<string>("Estado")) == "Activo" select row;

            if (filterRow.Any())
            {
                DataTable dataCmb = new DataTable();
                dataCmb = filterRow.CopyToDataTable();
                DataRow newRow = dataCmb.NewRow();
                newRow[0] = "0";
                newRow[1] = "Sin Seleccionar";
                newRow[2] = true;

                dataCmb.Rows.InsertAt(newRow, 0);

                CmbBanco.ValueMember = "BancoId";
                CmbBanco.DisplayMember = "Banco";
                CmbBanco.DataSource = dataCmb;
            }
        }

        private void ChkTarjeta_Click(object sender, EventArgs e)
        {
            if(ChkTarjeta.Checked)
            {
                CmbBanco.Enabled = true;
            }
            else
            {
                CmbBanco.Enabled = false;
            }
        }
    }
}
