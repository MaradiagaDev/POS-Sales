using NeoCobranza.Informes.Informes_Formato_Ticket;
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
    public partial class PnlPago : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        PnlVentas auxFrm;
        DataTable dynamicDataTable = new DataTable();
        decimal porcentaje = 0;
        bool ordenPagada = false;

        public PnlPago(PnlVentas frm)
        {
            InitializeComponent();
            this.auxFrm = frm;

            //Llenar el datagridView
            dynamicDataTable.Columns.Add("Id Detalle", typeof(string));
            dynamicDataTable.Columns.Add("Forma de Pago", typeof(string));
            dynamicDataTable.Columns.Add("Abonado", typeof(string));
            dynamicDataTable.Columns.Add("(%) Tarjeta", typeof(string));
            dynamicDataTable.Columns.Add("Total Pagado", typeof(string));
            dynamicDataTable.Columns.Add("Cambio", typeof(string));
            dynamicDataTable.Columns.Add("#Referencia", typeof(string));

            DataGridViewButtonColumn buttonColumnAdd = new DataGridViewButtonColumn();
            buttonColumnAdd.HeaderText = "...";
            buttonColumnAdd.Text = " Quitar ";
            buttonColumnAdd.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn();
            buttonColumnDelete.HeaderText = "...";
            buttonColumnDelete.Text = " Imprimir ";
            buttonColumnDelete.UseColumnTextForButtonValue = true;


            DgvItemsPagos.Columns.Add(buttonColumnAdd);
            DgvItemsPagos.Columns.Add(buttonColumnDelete);
            DgvItemsPagos.DataSource = dynamicDataTable;

            DgvItemsPagos.Columns[2].Visible = false;

            UIUtilities.PersonalizarDataGridViewPequeños(DgvItemsPagos);

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

            CargarValores();
        }

        private void CmbBanco_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CmbBanco.SelectedValue != null)
            {
                DataTable dtResponseBanco = dataUtilities.getRecordByColumn("TipoTarjeta", "BancoId", CmbBanco.SelectedValue);
                var filterRow = from row in dtResponseBanco.AsEnumerable()
                                where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                select row;

                DataTable dataCmb = new DataTable();

                // Verificar si hay filas en el resultado del filtro
                if (filterRow.Any())
                {
                    dataCmb = filterRow.CopyToDataTable();
                }
                else
                {
                    // Crear una tabla vacía con las mismas columnas
                    dataCmb = dtResponseBanco.Clone();
                }

                // Agregar la fila "Sin Seleccionar"
                DataRow newRow = dataCmb.NewRow();
                newRow[0] = "0";
                newRow[1] = "Sin Seleccionar";
                newRow[2] = true;

                dataCmb.Rows.InsertAt(newRow, 0);

                // Configurar el combo box
                CmbTarjeta.ValueMember = "TipoTarjetaId";
                CmbTarjeta.DisplayMember = "NombreTipo";
                CmbTarjeta.DataSource = dataCmb;
            }

        }

        private void CmbTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbTarjeta.SelectedValue != null) 
            {
                porcentaje = 0;

                if (Convert.ToString(CmbTarjeta.SelectedValue) != "0")
                {
                    DataRow item = dataUtilities.getRecordByPrimaryKey("TipoTarjeta", CmbTarjeta.SelectedValue).Rows[0];

                    porcentaje = Convert.ToDecimal(item["Porcentaje"])/100;
                }
                Calcular();
            }
        }

        private void Calcular()
        {
            if (decimal.TryParse(TxtCantidadAbonada.Text, out decimal abono))
            {
                // Calcular los valores iniciales

                TxtMontoTarjeta.Text = Convert.ToString(Math.Round(abono * porcentaje, 2));
                TxtTotalPago.Text = Convert.ToString(Math.Round((abono * porcentaje) + abono, 2));

                // Obtener el valor restante
                decimal restante = decimal.Parse(TxtRestante.Text);

                // Verificar si el pago es en efectivo o con banco/tarjeta
                if (CmbTarjeta.SelectedValue != null && CmbBanco.SelectedValue != null)
                {
                    if (CmbTarjeta.SelectedValue.ToString() != "0" || CmbBanco.SelectedValue.ToString() != "0")
                    {
                        if (abono > restante)
                        {
                            // Si el pago no es en efectivo, el abono se ajusta al valor restante
                            TxtCantidadAbonada.Text = Convert.ToString(restante);
                        }
                        
                        TxtCambio.Text = "0";
                    }
                    else
                    {
                        // Si el pago es en efectivo, calcular el cambio
                        if (abono > restante)
                        {
                            decimal cambio = Math.Round(abono - restante, 2);
                            TxtTotalPago.Text = (abono - cambio).ToString();
                            TxtCambio.Text = cambio.ToString();
                        }
                        else
                        {
                            TxtCambio.Text = "0";
                        }
                    }
                }
            }
        }

        private void TxtCantidadAbonada_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void TxtCantidadAbonada_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, la tecla de retroceso y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es un número, un punto decimal ni una tecla de control, ignorar la entrada
                e.Handled = true;
            }

            // Verificar si ya hay un punto decimal en el texto
            if (e.KeyChar == '.' && ((sender as System.Windows.Forms.TextBox)?.Text.IndexOf('.') > -1))
            {
                // Si ya hay un punto decimal, ignorar la entrada
                e.Handled = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(decimal.TryParse(TxtTotalPago.Text, out decimal abono))
            {
                //verificar si el pago ya termina de pagar la factura
                
                if(((abono-decimal.Parse(TxtMontoTarjeta.Text))+decimal.Parse(TxtPagado.Text)) == decimal.Parse(TxtDeudaTotal.Text))
                {
                    string formaPago = (Convert.ToString(CmbBanco.SelectedValue) == "0" && Convert.ToString(CmbTarjeta.SelectedValue) == "0")
                         ? "Efectivo"
                           : "Tarjeta-Minuta";

                    dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
                    dataUtilities.SetParameter("@FormaPago", formaPago);
                    dataUtilities.SetParameter("@Pagado", TxtCantidadAbonada.Text);
                    dataUtilities.SetParameter("@MontoTarjeta", TxtMontoTarjeta.Text);
                    dataUtilities.SetParameter("@Cambio", TxtCambio.Text);
                    dataUtilities.SetParameter("@BancoId", CmbBanco.SelectedValue);
                    dataUtilities.SetParameter("@TarjetaId", CmbTarjeta.SelectedValue);
                    dataUtilities.SetParameter("@Total", TxtTotalPago.Text);
                    dataUtilities.SetParameter("@NoReferencia", TxtReferencia.Text);
                    dataUtilities.SetParameter("@FechaPago", DateTime.Now);

                    dataUtilities.ExecuteStoredProcedure("sp_AgregarPago");

                    BtnGuardar.Enabled = false;


                    DialogResult result = MessageBox.Show("¿Desea imprimir factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        FrmFacturaTicket frmTicketFactura = new FrmFacturaTicket(Utilidades.SucursalId, auxFrm.vMOrdenes.OrdenAux);
                        frmTicketFactura.ShowDialog();
                    }

                    auxFrm.Close();
                    this.Close();

                    TxtCantidadAbonada.Text = "";
                    TxtTotalPago.Text = "0";
                    TxtCambio.Text = "0";
                    TxtMontoTarjeta.Text = "0";
                }
                else
                {
                    string formaPago = (Convert.ToString(CmbBanco.SelectedValue) == "0" && Convert.ToString(CmbTarjeta.SelectedValue) == "0")
                       ? "Efectivo"
                       : "Tarjeta-Minuta";

                    dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
                    dataUtilities.SetParameter("@FormaPago", formaPago);
                    dataUtilities.SetParameter("@Pagado", TxtCantidadAbonada.Text);
                    dataUtilities.SetParameter("@MontoTarjeta", TxtMontoTarjeta.Text);
                    dataUtilities.SetParameter("@Cambio", TxtCambio.Text);
                    dataUtilities.SetParameter("@BancoId", CmbBanco.SelectedValue);
                    dataUtilities.SetParameter("@TarjetaId", CmbTarjeta.SelectedValue);
                    dataUtilities.SetParameter("@Total", TxtTotalPago.Text);
                    dataUtilities.SetParameter("@NoReferencia", TxtReferencia.Text);
                    dataUtilities.SetParameter("@FechaPago", DateTime.Now);

                    dataUtilities.ExecuteStoredProcedure("sp_AgregarPago");

                    TxtCantidadAbonada.Text = "";
                    TxtTotalPago.Text = "0";
                    TxtCambio.Text = "0";
                    TxtMontoTarjeta.Text = "0";

                    auxFrm.LblProcesoPago.Text = "En Proceso de Pago";

                }

                CargarValores();
            }
            else
            {
                MessageBox.Show("La cantidad abonada no es valida.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarValores()
        {
            //Cargar Pagos
            DataTable dtResponse = dataUtilities.getRecordByColumn("Pagos", "OrdenId", auxFrm.vMOrdenes.OrdenAux);

            dynamicDataTable.Rows.Clear();

            foreach(DataRow row in dtResponse.Rows) 
            {
                dynamicDataTable.Rows.Add(Convert.ToString(row["PagoOrdenId"]),
                    Convert.ToString(row["FormaPago"]),
                    Convert.ToString(row["Pagado"]),
                    Convert.ToString(row["MontoTarjeta"]),
                    Convert.ToString(row["Total"]),
                    Convert.ToString(row["Cambio"]),
                    Convert.ToString(row["NoReferencia"]));
            }

            //Cargar totales
            DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];
            TxtDeudaTotal.Text = Convert.ToString(item["TotalOrden"]);
            TxtRestante.Text = Convert.ToString(item["RestantePago"]);
            TxtPagado.Text = Convert.ToString(item["Pagado"]);

            if(Convert.ToDecimal(item["TotalOrden"]) == Convert.ToDecimal(Convert.ToString(item["Pagado"])))
            {
                ordenPagada = true;
                BtnGuardar.Enabled = false; 
            }
        }

        private void DgvItemsPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                dataUtilities.SetParameter("@PagoOrdenId", dynamicDataTable.Rows[e.RowIndex][0]);
                dataUtilities.ExecuteStoredProcedure("sp_EliminarPago");

                CargarValores();
            }
        }

        private void PnlPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            auxFrm.vMOrdenes.InitModuloOrdenes(auxFrm,"OrdenRapida", "");
        }
    }
}
