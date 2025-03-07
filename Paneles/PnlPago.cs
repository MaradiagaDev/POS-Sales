using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NeoCobranza.Informes.Informes_Formato_Ticket;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles_Venta;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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
        public bool bit58mm = false;
        public bool bit80mm = false;

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
            if (CmbTarjeta.SelectedValue != null)
            {
                porcentaje = 0;

                if (Convert.ToString(CmbTarjeta.SelectedValue) != "0")
                {
                    DataRow item = dataUtilities.getRecordByPrimaryKey("TipoTarjeta", CmbTarjeta.SelectedValue).Rows[0];

                    porcentaje = Convert.ToDecimal(item["Porcentaje"]) / 100;
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
            if (!Utilidades.PermisosLevel(3, 33))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(TxtTotalPago.Text, out decimal abono))
            {
                //verificar si el pago ya termina de pagar la factura

                if (((abono - decimal.Parse(TxtMontoTarjeta.Text)) + decimal.Parse(TxtPagado.Text)) == decimal.Parse(TxtDeudaTotal.Text))
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

                    DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];

                    DataTable dtConfigTamaño = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                    bit58mm = Convert.ToBoolean(dtConfigTamaño.Rows[0]["Bit58mm"]);
                    bit80mm = Convert.ToBoolean(dtConfigTamaño.Rows[0]["Bit80mm"]);

                    if (Convert.ToString(item["NoFactura"]) == "0")
                    {
                        if (Convert.ToBoolean(item["BitEsCredito"]) == false)
                        {
                            //Agregarle el numero de factura
                            DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                            if (dtConfigFacturacion.Rows[0]["Serie"] == DBNull.Value || Convert.ToString(dtConfigFacturacion.Rows[0]["Serie"]) == "")
                            {
                                MessageBox.Show("Debe agregar los datos de facturación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFactura"]) + 1;

                            dataUtilities.SetColumns("ConsecutivoFactura", NoFactura);

                            dataUtilities.UpdateRecordByPrimaryKey(
                                "ConfigFacturacion",
                                Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                            //Actualizar en la orden

                            dataUtilities.SetParameter("@IdOrden", auxFrm.vMOrdenes.OrdenAux);
                            dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                            dataUtilities.SetParameter("@Factura", NoFactura);
                            dataUtilities.SetParameter("@serie", Convert.ToString(dtConfigFacturacion.Rows[0]["Serie"]));

                            dataUtilities.ExecuteStoredProcedure("spActualizarFacturaOrden");
                        }
                        else
                        {
                          

                            //Agregarle el numero de factura
                            DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                            if (dtConfigFacturacion.Rows[0]["SerieCredito"] == DBNull.Value || Convert.ToString(dtConfigFacturacion.Rows[0]["SerieCredito"]) == "")
                            {
                                MessageBox.Show("Debe agregar los datos de facturación de cuentas al crédito.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                return;
                            }

                                decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFacturaCredito"]) + 1;

                            dataUtilities.SetColumns("ConsecutivoFactura", NoFactura);

                            dataUtilities.UpdateRecordByPrimaryKey(
                                "ConfigFacturacion",
                                Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                            //Actualizar en la orden

                            dataUtilities.SetParameter("@IdOrden", auxFrm.vMOrdenes.OrdenAux);
                            dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                            dataUtilities.SetParameter("@Factura", NoFactura);
                            dataUtilities.SetParameter("@serie", Convert.ToString(dtConfigFacturacion.Rows[0]["SerieCredito"]));

                            dataUtilities.ExecuteStoredProcedure("spActualizarFacturaOrden");
                        }
                    }

                    DialogResult result = MessageBox.Show("¿Desea imprimir factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        PrintPDF(false);
                        //FUNCION REPORTE
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
                MessageBox.Show("La cantidad abonada no es valida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarValores()
        {
            //Cargar Pagos
            DataTable dtResponse = dataUtilities.getRecordByColumn("Pagos", "OrdenId", auxFrm.vMOrdenes.OrdenAux);

            dynamicDataTable.Rows.Clear();

            foreach (DataRow row in dtResponse.Rows)
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

            if (Convert.ToDecimal(item["TotalOrden"]) == Convert.ToDecimal(Convert.ToString(item["Pagado"])))
            {
                ordenPagada = true;
                BtnGuardar.Enabled = false;
                BtnImprimirFactura.Visible = true;
            }
            else
            {
                BtnImprimirFactura.Visible = false;
            }

            
                BtnImprimirFactura.Visible = true;
            
        }

        private void DgvItemsPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (!Utilidades.PermisosLevel(3, 26))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dataUtilities.SetParameter("@PagoOrdenId", dynamicDataTable.Rows[e.RowIndex][0]);
                dataUtilities.ExecuteStoredProcedure("sp_EliminarPago");

                CargarValores();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (!Utilidades.PermisosLevel(3, 34))
                {
                    MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PdfPrintPageEventHandler.PagoId = Convert.ToString(dynamicDataTable.Rows[e.RowIndex][0]);
                PdfPrintPageEventHandler.EsVenta = true;
                PdfPrintPageEventHandler.PrintPDFRecibo(false);
            }
        }

        private void PnlPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            auxFrm.vMOrdenes.InitModuloOrdenes(auxFrm, "OrdenRapida", "");
        }

        //----------------------------------- PARTE REPORTE ------------------------------------------------------------
        //public void GenerateInvoicePDF(bool EsProforma)
        //{
        //    //Obtener datos de la factura

        //    dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
        //    dataUtilities.SetParameter("@sucursarlId", Utilidades.SucursalId);

        //    DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");

        //    string filePath = "Factura.pdf";

        //    // Crear el documento
        //    const float baseHeight = 115; // Espacio fijo para encabezado, totales, etc. (en mm)
        //    const float productRowHeight = 8; // Altura de cada fila de productos (en mm)
        //    float totalHeight = baseHeight + (dtResponseOrden.Rows.Count * productRowHeight);
        //    iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(Utilities.MillimetersToPoints(76), Utilities.MillimetersToPoints(totalHeight));
        //    Document document = new Document(pageSize, 10, 10, 10, 10); // Márgenes: Izq, Der, Sup, Inf
        //    PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

        //    document.Open();

        //    // Fuentes
        //    iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
        //    iTextSharp.text.Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 8.5f);
        //    iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8.5f);
        //    iTextSharp.text.Font smallerFont = FontFactory.GetFont(FontFactory.HELVETICA, 7.5f);

        //    // Cabecera centrada
        //    Paragraph header = new Paragraph
        //    {
        //        Alignment = Element.ALIGN_CENTER
        //    };
        //    header.Add(new Phrase($"{Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"])}\n", titleFont));
        //    header.Add(new Phrase($"RUC: {Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"])}\n", regularFont));
        //    header.Add(new Phrase($"{Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"])}\n", regularFont));
        //    header.Add(new Phrase($"Teléfono: {Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"])}\n", regularFont));
        //    document.Add(header);
        //    document.Add(new Paragraph("\n")); // Espacio

        //    // Datos de la factura
        //    document.Add(new Paragraph($"Fecha: {Convert.ToDateTime(Convert.ToString(dtResponseOrden.Rows[0]["FechaRealizacion"])):dd/MM/yyyy}", regularFont));
        //    document.Add(new Paragraph($"No. Orden: {Convert.ToString(dtResponseOrden.Rows[0]["OrdenId"])}", regularFont));
        //    if (EsProforma)
        //    {
        //        document.Add(new Paragraph($"PROFORMA-VIGENCIA 10 DÍAS", boldFont));
        //    }
        //    else
        //    {
        //        document.Add(new Paragraph($"No. Factura: {Convert.ToString(dtResponseOrden.Rows[0]["factura"])}", regularFont));
        //    }

        //    document.Add(new Paragraph($"Cliente: {Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"])}", regularFont));
        //    document.Add(new Paragraph("\n")); // Espacio

        //    // Tabla de productos
        //    PdfPTable table = new PdfPTable(4);
        //    table.WidthPercentage = 100;
        //    table.SetWidths(new float[] { 3, 1, 1.2f, 1 }); // Anchos de las columnas

        //    // Cabecera de la tabla con border bottom
        //    PdfPCell cell;
        //    cell = new PdfPCell(new Phrase("Producto", boldFont)) { Border = iTextSharp.text.Rectangle.BOTTOM_BORDER, BorderWidthBottom = 1 };
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("Cant", boldFont)) { Border = iTextSharp.text.Rectangle.BOTTOM_BORDER, BorderWidthBottom = 1 };
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("P.Unit", boldFont)) { Border = iTextSharp.text.Rectangle.BOTTOM_BORDER, BorderWidthBottom = 1 };
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase("SubT", boldFont)) { Border = iTextSharp.text.Rectangle.BOTTOM_BORDER, BorderWidthBottom = 1 };
        //    table.AddCell(cell);

        //    decimal total = 0;
        //    for (int i = 0; i < dtResponseOrden.Rows.Count; i++)
        //    {
        //        table.AddCell(new PdfPCell(new Phrase(Convert.ToString(dtResponseOrden.Rows[i]["nombreProducto"]), smallerFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
        //        table.AddCell(new PdfPCell(new Phrase(Convert.ToString(dtResponseOrden.Rows[i]["cantidad"]), smallerFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
        //        table.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(dtResponseOrden.Rows[i]["precioUnitario"]).ToString("0.00"), smallerFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
        //        table.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(dtResponseOrden.Rows[i]["subTotal"]).ToString("0.00"), smallerFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
        //    }

        //    document.Add(table);
        //    document.Add(new Paragraph("\n")); // Espacio

        //    // Totales
        //    document.Add(new Paragraph($"Sub Total:             \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["SubtotalOrden"]):0.00} NIO", regularFont));
        //    document.Add(new Paragraph($"Adicional Crédito:  \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]):0.00} NIO", regularFont));
        //    document.Add(new Paragraph($"Descuento:            \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]):0.00} NIO", regularFont));

        //    if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0)
        //    {
        //        document.Add(new Paragraph($"DGI (2%):              \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]):0.00} NIO", regularFont));
        //    }

        //    if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
        //    {
        //        document.Add(new Paragraph($"Alcaldía (1%):        \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]):0.00} NIO", regularFont));
        //    }

        //    document.Add(new Paragraph($"TOTAL:                 \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["totalCordoba"]):0.00} NIO", boldFont));
        //    document.Add(new Paragraph($"TOTAL USD:         \t{Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"])}", boldFont));
        //    document.Add(new Paragraph("")); // Espacio

        //    // Pie de página
        //    document.Add(new Paragraph("Gracias por su preferencia", regularFont));

        //    document.Close();


        //    //// Abrir el PDF
        //    //Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });


        //    DataTable data = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

        //    if (data.Rows.Count == 1)
        //    {
        //        try
        //        {
        //            try
        //            {
        //                PrintPDF(filePath, Convert.ToString(data.Rows[0]["ImpresoraTicket"]));
        //                MessageBox.Show("Documento impreso exitosamente.");
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error al imprimir: {ex.Message}");
        //            }


        //            // Borrar el archivo después de la impresión
        //            File.Delete(filePath);
        //            MessageBox.Show("Archivo PDF borrado exitosamente.");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error al imprimir o manejar el archivo PDF: " + ex.Message);
        //        }
        //    }

        //}

        private bool AuxEsProforma; 

        public void PrintPDF(Boolean EsProforma)
        {
            AuxEsProforma = EsProforma;

            DataTable data = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            PrintDocument doc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();

            if (Convert.ToString(data.Rows[0]["ImpresoraTicket"]) == null || Convert.ToString(data.Rows[0]["ImpresoraTicket"]) == "")
            {
                doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            }
            else
            {
                doc.PrinterSettings.PrinterName = Convert.ToString(data.Rows[0]["ImpresoraTicket"]);
            }


            if (bit58mm)
            {
                doc.PrintPage += new PrintPageEventHandler(imprimeTicket58mm);
            }
            else if (bit80mm)
            {
                doc.PrintPage += new PrintPageEventHandler(imprimeTicket80mm);
            }
            else
            {
                MessageBox.Show("Debes de seleccionar un tamaño de factura en Configuración de Facturación","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
        }

        private void imprimeTicket80mm(object sender, PrintPageEventArgs e)
        {
            DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];
            dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
            dataUtilities.SetParameter("@sucursarlId", Utilidades.SucursalId);

            DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");

            // Alturas fijas (en mm)
            const float baseHeight = 105; // Espacio fijo para encabezado, totales, etc.
            const float productRowHeight = 16; // Altura estimada de cada producto (se puede ajustar)
            float totalHeight = baseHeight + (dtResponseOrden.Rows.Count * productRowHeight);

            // Definir el tamaño de la página (Ancho: 80mm, Altura calculada previamente)
            float pageWidth = Utilities.MillimetersToPoints(76); // Ancho de la página de 80 mm
            float pageHeight = Utilities.MillimetersToPoints(totalHeight);

            // Márgenes laterales para evitar desbordes
            float marginLeft = 10;
            float marginRight = 10;
            float availableWidth = pageWidth - marginLeft - marginRight;

            // Establecer el área de impresión
            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Definir las fuentes
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 8.5f);
            System.Drawing.Font boldFont = new System.Drawing.Font("Arial", 8.5f, FontStyle.Bold);
            System.Drawing.Font smallerFont = new System.Drawing.Font("Arial", 8f);

            // Definir un Pen punteado para las líneas
            Pen dottedPen = new Pen(Color.Black);
            dottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            // Agregar un margen superior extra para el encabezado
            float marginTop = 45;
            float yPosition = marginTop; // Posición inicial con margen superior

            if (dtEmpresa["BitImgFac"] != DBNull.Value && Convert.ToBoolean(dtEmpresa["BitImgFac"]))
            {
                System.Drawing.Image logo = null;

                try
                {
                    byte[] imagenBytes = dtEmpresa["Logo"] as byte[];

                    if (imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            logo = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    logo = null;
                }
                if (logo != null)
                {
                    // Escalar la imagen para que se ajuste al ancho disponible
                    float scale = availableWidth / logo.Width;
                    float logoWidth = availableWidth;
                    float logoHeight = logo.Height * scale;
                    // Calcular posición horizontal para centrar el logo
                    float logoX = marginLeft + ((availableWidth - logoWidth) / 2);
                    float logoY = yPosition;
                    RectangleF logoRect = new RectangleF(logoX, logoY, logoWidth, logoHeight);
                    e.Graphics.DrawImage(logo, logoRect);
                    yPosition += logoHeight + 5; // Espacio después del logo
                }
            }

            // StringFormat centrado para los encabezados
            StringFormat centeredFormat = new StringFormat { Alignment = StringAlignment.Center };

            // --- Encabezado ---
            // Nombre de la empresa (wrap aplicado)
            string companyName = Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"]);
            RectangleF headerRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF headerSize = e.Graphics.MeasureString(companyName, titleFont, (int)availableWidth);
            headerRect.Height = headerSize.Height;
            e.Graphics.DrawString(companyName, titleFont, Brushes.Black, headerRect, centeredFormat);
            yPosition += headerSize.Height + 5;

            // RUC de la empresa (wrap aplicado)
            string ruc = Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"]);
            RectangleF rucRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF rucSize = e.Graphics.MeasureString(ruc, regularFont, (int)availableWidth);
            rucRect.Height = rucSize.Height;
            e.Graphics.DrawString(ruc, regularFont, Brushes.Black, rucRect, centeredFormat);
            yPosition += rucSize.Height + 5;

            // Sucursal (wrap aplicado)
            string suc = Convert.ToString(dtResponseOrden.Rows[0]["NombreSucursal"]);
            RectangleF sucRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF sucSize = e.Graphics.MeasureString(suc, regularFont, (int)availableWidth);
            sucRect.Height = sucSize.Height;
            e.Graphics.DrawString(suc, regularFont, Brushes.Black, sucRect, centeredFormat);
            yPosition += sucSize.Height + 5;

            // Dirección de la sucursal (wrap aplicado)
            string direccion = Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"]);
            RectangleF dirRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF dirSize = e.Graphics.MeasureString(direccion, regularFont, (int)availableWidth);
            dirRect.Height = dirSize.Height;
            e.Graphics.DrawString(direccion, regularFont, Brushes.Black, dirRect, centeredFormat);
            yPosition += dirSize.Height + 5;

            // Teléfono de la sucursal (wrap aplicado)
            string telefono = "Teléfono: " + Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"]);
            RectangleF telRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF telSize = e.Graphics.MeasureString(telefono, regularFont, (int)availableWidth);
            telRect.Height = telSize.Height;
            e.Graphics.DrawString(telefono, regularFont, Brushes.Black, telRect, centeredFormat);
            yPosition += telSize.Height + 10; // Espacio antes de los datos de factura

            DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];

            if (Convert.ToBoolean(item["BitEsCredito"]))
            {
                string credito = "Condición de pago: Crédito";
                SizeF sizeCredito = e.Graphics.MeasureString(credito, boldFont, (int)availableWidth);
                RectangleF creditoRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeCredito.Height);
                e.Graphics.DrawString(credito, boldFont, Brushes.Black, creditoRect);
                yPosition += sizeCredito.Height;
            }

            // Datos de la factura
            string fecha = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
            SizeF sizeFecha = e.Graphics.MeasureString(fecha, regularFont, (int)availableWidth);
            RectangleF fechaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeFecha.Height);
            e.Graphics.DrawString(fecha, regularFont, Brushes.Black, fechaRect);
            yPosition += sizeFecha.Height;

            string clienteLabel = "Cliente:";
            SizeF sizeClienteLabel = e.Graphics.MeasureString(clienteLabel, regularFont, (int)availableWidth);
            RectangleF clienteLabelRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeClienteLabel.Height);
            e.Graphics.DrawString(clienteLabel, regularFont, Brushes.Black, clienteLabelRect);
            yPosition += sizeClienteLabel.Height;

            string nombreCliente = Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"]);
            SizeF sizeNombreCliente = e.Graphics.MeasureString(nombreCliente, regularFont, (int)availableWidth);
            RectangleF nombreClienteRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeNombreCliente.Height);
            e.Graphics.DrawString(nombreCliente, regularFont, Brushes.Black, nombreClienteRect);
            yPosition += sizeNombreCliente.Height;

            string rucCliente = "RUC: " + Convert.ToString(dtResponseOrden.Rows[0]["NoRuc"]);

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0 || Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
            {
                SizeF sizeRucCliente = e.Graphics.MeasureString(rucCliente, regularFont, (int)availableWidth);
                RectangleF rucClienteRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeRucCliente.Height);
                e.Graphics.DrawString(rucCliente, regularFont, Brushes.Black, rucClienteRect);
                yPosition += sizeRucCliente.Height;
            }

            string ordenText = $"No. Orden: {Convert.ToString(dtResponseOrden.Rows[0]["OrdenId"])}";
            SizeF sizeOrden = e.Graphics.MeasureString(ordenText, regularFont, (int)availableWidth);
            RectangleF ordenRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeOrden.Height);
            e.Graphics.DrawString(ordenText, regularFont, Brushes.Black, ordenRect);
            yPosition += sizeOrden.Height;

            if (AuxEsProforma)
            {
                string proformaText = $"PROFORMA-VIGENCIA {Convert.ToString(dtEmpresa["proforma"])} DÍAS";
                SizeF sizeProforma = e.Graphics.MeasureString(proformaText, boldFont, (int)availableWidth);
                RectangleF proformaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeProforma.Height);
                e.Graphics.DrawString(proformaText, boldFont, Brushes.Black, proformaRect);
            }
            else
            {
                string facturaText = $"No. Factura: {Convert.ToString(dtResponseOrden.Rows[0]["factura"])}";
                SizeF sizeFactura = e.Graphics.MeasureString(facturaText, regularFont, (int)availableWidth);
                RectangleF facturaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeFactura.Height);
                e.Graphics.DrawString(facturaText, regularFont, Brushes.Black, facturaRect);
            }
            yPosition += 18;

            // Línea punteada separadora entre encabezado y productos
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 5;

            // Encabezado de productos/servicios
            string prodHeader = "Productos/Servicios";
            SizeF sizeProdHeader = e.Graphics.MeasureString(prodHeader, boldFont, (int)availableWidth);
            RectangleF prodHeaderRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeProdHeader.Height);
            e.Graphics.DrawString(prodHeader, boldFont, Brushes.Black, prodHeaderRect);
            yPosition += sizeProdHeader.Height + 2;

            // Recorrer productos y dibujarlos con wrap
            foreach (DataRow row in dtResponseOrden.Rows)
            {
                string producto = Convert.ToString(row["nombreProducto"]);
                string cantidad = Convert.ToString(row["cantidad"]);
                string precioUnitario = Convert.ToDouble(row["precioUnitario"]).ToString("0.00");
                string subTotal = Convert.ToDouble(row["subTotal"]).ToString("0.00");

                // Dibujar primero el nombre del producto, permitiendo wrap
                RectangleF productRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                SizeF productSize = e.Graphics.MeasureString(producto, smallerFont, (int)availableWidth);
                productRect.Height = productSize.Height;
                e.Graphics.DrawString(producto, smallerFont, Brushes.Black, productRect);
                yPosition += productSize.Height;

                // Dibujar detalle (cantidad x precio unitario y subtotal)
                string detalle = $"{cantidad}x{precioUnitario}     {subTotal}";
                RectangleF detailRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                SizeF detailSize = e.Graphics.MeasureString(detalle, smallerFont, (int)availableWidth);
                detailRect.Height = detailSize.Height;
                e.Graphics.DrawString(detalle, smallerFont, Brushes.Black, detailRect);
                yPosition += detailSize.Height + 3;
            }

            // Línea punteada antes de los totales
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 5;

            // Totales
            string subTotalText = $"Sub Total:    {Convert.ToDecimal(dtResponseOrden.Rows[0]["SubtotalOrden"]):0.00} NIO";
            SizeF sizeSubTotal = e.Graphics.MeasureString(subTotalText, regularFont, (int)availableWidth);
            RectangleF subTotalRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeSubTotal.Height);
            e.Graphics.DrawString(subTotalText, regularFont, Brushes.Black, subTotalRect);
            yPosition += sizeSubTotal.Height;

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]) != 0)
            {
                string adicionalCredito = $"Adicional Crédito: {Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]):0.00} NIO";
                SizeF sizeAdicional = e.Graphics.MeasureString(adicionalCredito, regularFont, (int)availableWidth);
                RectangleF adicionalRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeAdicional.Height);
                e.Graphics.DrawString(adicionalCredito, regularFont, Brushes.Black, adicionalRect);
                yPosition += sizeAdicional.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]) != 0)
            {
                string descuento = $"Descuento:    {Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]):0.00} NIO";
                SizeF sizeDescuento = e.Graphics.MeasureString(descuento, regularFont, (int)availableWidth);
                RectangleF descuentoRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeDescuento.Height);
                e.Graphics.DrawString(descuento, regularFont, Brushes.Black, descuentoRect);
                yPosition += sizeDescuento.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0)
            {
                string retDgi = $"DGI (2%):     {Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]):0.00} NIO";
                SizeF sizeRetDgi = e.Graphics.MeasureString(retDgi, regularFont, (int)availableWidth);
                RectangleF retDgiRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeRetDgi.Height);
                e.Graphics.DrawString(retDgi, regularFont, Brushes.Black, retDgiRect);
                yPosition += sizeRetDgi.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
            {
                string retAlc = $"Alcaldía (1%): {Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]):0.00} NIO";
                SizeF sizeRetAlc = e.Graphics.MeasureString(retAlc, regularFont, (int)availableWidth);
                RectangleF retAlcRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeRetAlc.Height);
                e.Graphics.DrawString(retAlc, regularFont, Brushes.Black, retAlcRect);
                yPosition += sizeRetAlc.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]) != 0)
            {
                string iva = $"IVA:          {Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]):0.00} NIO";
                SizeF sizeIva = e.Graphics.MeasureString(iva, regularFont, (int)availableWidth);
                RectangleF ivaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeIva.Height);
                e.Graphics.DrawString(iva, regularFont, Brushes.Black, ivaRect);
                yPosition += sizeIva.Height;
            }

            if (Convert.ToString(dtResponseOrden.Rows[0]["SalaMesa"]) != "-")
            {
                if (Convert.ToBoolean(dtResponseOrden.Rows[0]["BitPropina"]))
                {
                    if (Convert.ToString(dtResponseOrden.Rows[0]["propina"]).Trim() != "" && Convert.ToString(dtResponseOrden.Rows[0]["propina"]).Trim() != "0"
                        && Convert.ToString(dtResponseOrden.Rows[0]["propina"]).Trim() != "0.00")
                    {
                        string propinaText = $"Propina:      {Convert.ToString(dtResponseOrden.Rows[0]["propina"]):0.00} NIO";
                        SizeF sizePropina = e.Graphics.MeasureString(propinaText, regularFont, (int)availableWidth);
                        RectangleF propinaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizePropina.Height);
                        e.Graphics.DrawString(propinaText, regularFont, Brushes.Black, propinaRect);
                        yPosition += sizePropina.Height;
                    }
                }
            }

            yPosition += 12;
            string totalText = $"TOTAL:        {Convert.ToDecimal(dtResponseOrden.Rows[0]["totalCordoba"]):0.00} NIO";
            SizeF sizeTotal = e.Graphics.MeasureString(totalText, boldFont, (int)availableWidth);
            RectangleF totalRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeTotal.Height);
            e.Graphics.DrawString(totalText, boldFont, Brushes.Black, totalRect);
            yPosition += sizeTotal.Height;

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["totalDolar"]) != 0)
            {
                string totalDolar = $"TOTAL:        {Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"])} $";
                SizeF sizeTotalDolar = e.Graphics.MeasureString(totalDolar, boldFont, (int)availableWidth);
                RectangleF totalDolarRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeTotalDolar.Height);
                e.Graphics.DrawString(totalDolar, boldFont, Brushes.Black, totalDolarRect);
                yPosition += sizeTotalDolar.Height;
            }

            // Línea punteada antes del pie de página
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 10;

            // Pie de página
            string agradecimiento = "Gracias por su preferencia";
            SizeF sizeAgradecimiento = e.Graphics.MeasureString(agradecimiento, regularFont, (int)availableWidth);
            RectangleF agradecimientoRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeAgradecimiento.Height);
            e.Graphics.DrawString(agradecimiento, regularFont, Brushes.Black, agradecimientoRect);

            e.HasMorePages = false;
        }


        public void PrintPDFA4()
        {

            DataTable data = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            PrintDocument doc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();

            if (Convert.ToString(data.Rows[0]["Impresora"]) == null || Convert.ToString(data.Rows[0]["Impresora"]) == "")
            {
                doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            }
            else
            {
                doc.PrinterSettings.PrinterName = Convert.ToString(data.Rows[0]["Impresora"]);
            }

            PdfPrintPageEventHandler.OrdenAux = auxFrm.vMOrdenes.OrdenAux;

            doc.PrintPage += new PrintPageEventHandler(PdfPrintPageEventHandler.ImprimeProforma);

            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
        }

        private void imprimeTicket58mm(object sender, PrintPageEventArgs e)
        {
            DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];
            dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
            dataUtilities.SetParameter("@sucursarlId", Utilidades.SucursalId);

            DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");

            // Alturas fijas (en mm)
            const float baseHeight = 105; // Espacio fijo para encabezado, totales, etc.
            const float productRowHeight = 16; // Altura estimada de cada producto (se puede ajustar)
            float totalHeight = baseHeight + (dtResponseOrden.Rows.Count * productRowHeight);

            // Definir el tamaño de la página (Ancho: 48mm, Altura calculada previamente)
            float pageWidth = Utilities.MillimetersToPoints(48); // Ancho de la página de 48 mm
            float pageHeight = Utilities.MillimetersToPoints(totalHeight);

            // Márgenes laterales para evitar desbordes
            float marginLeft = 10;
            float marginRight = 10;
            float availableWidth = pageWidth - marginLeft - marginRight;

            // Establecer el área de impresión
            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Definir las fuentes
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 8.5f);
            System.Drawing.Font boldFont = new System.Drawing.Font("Arial", 8.5f, FontStyle.Bold);
            System.Drawing.Font smallerFont = new System.Drawing.Font("Arial", 8f);

            // Definir un Pen punteado para las líneas
            Pen dottedPen = new Pen(Color.Black);
            dottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            // Agregar un margen superior extra para el encabezado
            float marginTop = 45;
            float yPosition = marginTop; // Posición inicial con margen superior

            if (dtEmpresa["BitImgFac"] != DBNull.Value && Convert.ToBoolean(dtEmpresa["BitImgFac"]))
            {
                System.Drawing.Image logo = null;

                try
                {
                    byte[] imagenBytes = dtEmpresa["Logo"] as byte[];

                    if (imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {

                            logo = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    logo = null;
                }
                if (logo != null)
                {
                    // Escalar la imagen para que se ajuste al ancho disponible
                    float scale = availableWidth / logo.Width;
                    float logoWidth = availableWidth;
                    float logoHeight = logo.Height * scale;
                    // Calcular posición horizontal para centrar el logo
                    float logoX = marginLeft + ((availableWidth - logoWidth) / 2);
                    float logoY = yPosition;
                    RectangleF logoRect = new RectangleF(logoX, logoY, logoWidth, logoHeight);
                    e.Graphics.DrawImage(logo, logoRect);
                    yPosition += logoHeight + 5; // Espacio después del logo
                }
            }

            // StringFormat centrado para los encabezados
            StringFormat centeredFormat = new StringFormat { Alignment = StringAlignment.Center };

            // --- Encabezado ---
            // Nombre de la empresa (wrap aplicado)
            string companyName = Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"]);
            RectangleF headerRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF headerSize = e.Graphics.MeasureString(companyName, titleFont, (int)availableWidth);
            headerRect.Height = headerSize.Height;
            e.Graphics.DrawString(companyName, titleFont, Brushes.Black, headerRect, centeredFormat);
            yPosition += headerSize.Height + 5;

            // RUC de la empresa (wrap aplicado)
            string ruc = Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"]);
            RectangleF rucRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF rucSize = e.Graphics.MeasureString(ruc, regularFont, (int)availableWidth);
            rucRect.Height = rucSize.Height;
            e.Graphics.DrawString(ruc, regularFont, Brushes.Black, rucRect, centeredFormat);
            yPosition += rucSize.Height + 5;

            // RUC de la empresa (wrap aplicado)
            string suc = Convert.ToString(dtResponseOrden.Rows[0]["NombreSucursal"]);
            RectangleF sucRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF sucSize = e.Graphics.MeasureString(suc, regularFont, (int)availableWidth);
            rucRect.Height = sucSize.Height;
            e.Graphics.DrawString(suc, regularFont, Brushes.Black, sucRect, centeredFormat);
            yPosition += sucSize.Height + 5;

            // Dirección de la sucursal (wrap aplicado)
            string direccion = Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"]);
            RectangleF dirRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF dirSize = e.Graphics.MeasureString(direccion, regularFont, (int)availableWidth);
            dirRect.Height = dirSize.Height;
            e.Graphics.DrawString(direccion, regularFont, Brushes.Black, dirRect, centeredFormat);
            yPosition += dirSize.Height + 5;

            // Teléfono de la sucursal (wrap aplicado)
            string telefono = "Teléfono: " + Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"]);
            RectangleF telRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF telSize = e.Graphics.MeasureString(telefono, regularFont, (int)availableWidth);
            telRect.Height = telSize.Height;
            e.Graphics.DrawString(telefono, regularFont, Brushes.Black, telRect, centeredFormat);
            yPosition += telSize.Height + 10; // Espacio antes de los datos de factura

            DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];

            if (Convert.ToBoolean(item["BitEsCredito"]))
            {
                string credito = "Condición de pago: Crédito";
                SizeF sizeCredito = e.Graphics.MeasureString(credito, boldFont, (int)availableWidth);
                RectangleF creditoRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeCredito.Height);
                e.Graphics.DrawString(credito, boldFont, Brushes.Black, creditoRect);
                yPosition += sizeCredito.Height;
            }

            // Datos de la factura
            string fecha = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
            SizeF sizeFecha = e.Graphics.MeasureString(fecha, regularFont, (int)availableWidth);
            RectangleF fechaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeFecha.Height);
            e.Graphics.DrawString(fecha, regularFont, Brushes.Black, fechaRect);
            yPosition += sizeFecha.Height;

            string clienteLabel = "Cliente:";
            SizeF sizeClienteLabel = e.Graphics.MeasureString(clienteLabel, regularFont, (int)availableWidth);
            RectangleF clienteLabelRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeClienteLabel.Height);
            e.Graphics.DrawString(clienteLabel, regularFont, Brushes.Black, clienteLabelRect);
            yPosition += sizeClienteLabel.Height;

            string nombreCliente = Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"]);
            SizeF sizeNombreCliente = e.Graphics.MeasureString(nombreCliente, regularFont, (int)availableWidth);
            RectangleF nombreClienteRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeNombreCliente.Height);
            e.Graphics.DrawString(nombreCliente, regularFont, Brushes.Black, nombreClienteRect);
            yPosition += sizeNombreCliente.Height;

            string rucCliente = "RUC: "+Convert.ToString(dtResponseOrden.Rows[0]["NoRuc"]);

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0 || Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
            {
                SizeF sizeRucCliente = e.Graphics.MeasureString(rucCliente, regularFont, (int)availableWidth);
                RectangleF rucClienteRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeRucCliente.Height);
                e.Graphics.DrawString(rucCliente, regularFont, Brushes.Black, rucClienteRect);
                yPosition += sizeRucCliente.Height;
            }

            string ordenText = $"No. Orden: {Convert.ToString(dtResponseOrden.Rows[0]["OrdenId"])}";
            SizeF sizeOrden = e.Graphics.MeasureString(ordenText, regularFont, (int)availableWidth);
            RectangleF ordenRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeOrden.Height);
            e.Graphics.DrawString(ordenText, regularFont, Brushes.Black, ordenRect);
            yPosition += sizeOrden.Height;

            if (AuxEsProforma)
            {
                string proformaText = $"PROFORMA-VIGENCIA {Convert.ToString(dtEmpresa["proforma"])} DÍAS";
                SizeF sizeProforma = e.Graphics.MeasureString(proformaText, boldFont, (int)availableWidth);
                RectangleF proformaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeProforma.Height);
                e.Graphics.DrawString(proformaText, boldFont, Brushes.Black, proformaRect);
            }
            else
            {
                string facturaText = $"No. Factura: {Convert.ToString(dtResponseOrden.Rows[0]["factura"])}";
                SizeF sizeFactura = e.Graphics.MeasureString(facturaText, regularFont, (int)availableWidth);
                RectangleF facturaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeFactura.Height);
                e.Graphics.DrawString(facturaText, regularFont, Brushes.Black, facturaRect);
            }
            yPosition += 18;

            // Línea punteada separadora entre encabezado y productos
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 5;

            // Encabezado de productos/servicios
            string prodHeader = "Productos/Servicios";
            SizeF sizeProdHeader = e.Graphics.MeasureString(prodHeader, boldFont, (int)availableWidth);
            RectangleF prodHeaderRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeProdHeader.Height);
            e.Graphics.DrawString(prodHeader, boldFont, Brushes.Black, prodHeaderRect);
            yPosition += sizeProdHeader.Height + 2;

            // Recorrer productos y dibujarlos con wrap
            foreach (DataRow row in dtResponseOrden.Rows)
            {
                string producto = Convert.ToString(row["nombreProducto"]);
                string cantidad = Convert.ToString(row["cantidad"]);
                string precioUnitario = Convert.ToDouble(row["precioUnitario"]).ToString("0.00");
                string subTotal = Convert.ToDouble(row["subTotal"]).ToString("0.00");

                // Dibujar primero el nombre del producto, permitiendo wrap
                RectangleF productRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                SizeF productSize = e.Graphics.MeasureString(producto, smallerFont, (int)availableWidth);
                productRect.Height = productSize.Height;
                e.Graphics.DrawString(producto, smallerFont, Brushes.Black, productRect);
                yPosition += productSize.Height;

                // Dibujar detalle (cantidad x precio unitario y subtotal)
                string detalle = $"{cantidad}x{precioUnitario}     {subTotal}";
                RectangleF detailRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                SizeF detailSize = e.Graphics.MeasureString(detalle, smallerFont, (int)availableWidth);
                detailRect.Height = detailSize.Height;
                e.Graphics.DrawString(detalle, smallerFont, Brushes.Black, detailRect);
                yPosition += detailSize.Height + 3;
            }

            // Línea punteada antes de los totales
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 5;

            // Totales
            string subTotalText = $"Sub Total:    {Convert.ToDecimal(dtResponseOrden.Rows[0]["SubtotalOrden"]):0.00} NIO";
            SizeF sizeSubTotal = e.Graphics.MeasureString(subTotalText, regularFont, (int)availableWidth);
            RectangleF subTotalRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeSubTotal.Height);
            e.Graphics.DrawString(subTotalText, regularFont, Brushes.Black, subTotalRect);
            yPosition += sizeSubTotal.Height;

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]) != 0)
            {
                string adicionalCredito = $"Adicional Crédito: {Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]):0.00} NIO";
                SizeF sizeAdicional = e.Graphics.MeasureString(adicionalCredito, regularFont, (int)availableWidth);
                RectangleF adicionalRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeAdicional.Height);
                e.Graphics.DrawString(adicionalCredito, regularFont, Brushes.Black, adicionalRect);
                yPosition += sizeAdicional.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]) != 0)
            {
                string descuento = $"Descuento:    {Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]):0.00} NIO";
                SizeF sizeDescuento = e.Graphics.MeasureString(descuento, regularFont, (int)availableWidth);
                RectangleF descuentoRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeDescuento.Height);
                e.Graphics.DrawString(descuento, regularFont, Brushes.Black, descuentoRect);
                yPosition += sizeDescuento.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0)
            {
                string retDgi = $"DGI (2%):     {Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]):0.00} NIO";
                SizeF sizeRetDgi = e.Graphics.MeasureString(retDgi, regularFont, (int)availableWidth);
                RectangleF retDgiRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeRetDgi.Height);
                e.Graphics.DrawString(retDgi, regularFont, Brushes.Black, retDgiRect);
                yPosition += sizeRetDgi.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
            {
                string retAlc = $"Alcaldía (1%): {Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]):0.00} NIO";
                SizeF sizeRetAlc = e.Graphics.MeasureString(retAlc, regularFont, (int)availableWidth);
                RectangleF retAlcRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeRetAlc.Height);
                e.Graphics.DrawString(retAlc, regularFont, Brushes.Black, retAlcRect);
                yPosition += sizeRetAlc.Height;
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]) != 0)
            {
                string iva = $"IVA:          {Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]):0.00} NIO";
                SizeF sizeIva = e.Graphics.MeasureString(iva, regularFont, (int)availableWidth);
                RectangleF ivaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeIva.Height);
                e.Graphics.DrawString(iva, regularFont, Brushes.Black, ivaRect);
                yPosition += sizeIva.Height;
            }

            if(Convert.ToString(dtResponseOrden.Rows[0]["SalaMesa"]) != "-")
            {
                if (Convert.ToBoolean(dtResponseOrden.Rows[0]["BitPropina"]))
                {
                    if (Convert.ToString(dtResponseOrden.Rows[0]["propina"]).Trim() != "" && Convert.ToString(dtResponseOrden.Rows[0]["propina"]).Trim() != "0"
                        && Convert.ToString(dtResponseOrden.Rows[0]["propina"]).Trim() != "0.00")
                    {
                        string propinaText = $"Propina:      {Convert.ToString(dtResponseOrden.Rows[0]["propina"]):0.00} NIO";
                        SizeF sizePropina = e.Graphics.MeasureString(propinaText, regularFont, (int)availableWidth);
                        RectangleF propinaRect = new RectangleF(marginLeft, yPosition, availableWidth, sizePropina.Height);
                        e.Graphics.DrawString(propinaText, regularFont, Brushes.Black, propinaRect);
                        yPosition += sizePropina.Height;
                    }
                }
            }

            yPosition += 12;
            string totalText = $"TOTAL:        {Convert.ToDecimal(dtResponseOrden.Rows[0]["totalCordoba"]):0.00} NIO";
            SizeF sizeTotal = e.Graphics.MeasureString(totalText, boldFont, (int)availableWidth);
            RectangleF totalRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeTotal.Height);
            e.Graphics.DrawString(totalText, boldFont, Brushes.Black, totalRect);
            yPosition += sizeTotal.Height;

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["totalDolar"]) != 0)
            {
                string totalDolar = $"TOTAL:        {Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"])} $";
                SizeF sizeTotalDolar = e.Graphics.MeasureString(totalDolar, boldFont, (int)availableWidth);
                RectangleF totalDolarRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeTotalDolar.Height);
                e.Graphics.DrawString(totalDolar, boldFont, Brushes.Black, totalDolarRect);
                yPosition += sizeTotalDolar.Height;
            }

            // Línea punteada antes del pie de página
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 10;

            // Pie de página
            string agradecimiento = "Gracias por su preferencia";
            SizeF sizeAgradecimiento = e.Graphics.MeasureString(agradecimiento, regularFont, (int)availableWidth);
            RectangleF agradecimientoRect = new RectangleF(marginLeft, yPosition, availableWidth, sizeAgradecimiento.Height);
            e.Graphics.DrawString(agradecimiento, regularFont, Brushes.Black, agradecimientoRect);

            e.HasMorePages = false;
        }



        //private void imprimeTicket(object sender, PrintPageEventArgs e)
        //{
        //    DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];
        //    dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
        //    dataUtilities.SetParameter("@sucursarlId", Utilidades.SucursalId);

        //    DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");

        //    const float baseHeight = 105; // Espacio fijo para encabezado, totales, etc. (en mm)
        //    const float productRowHeight = 16; // Altura de cada fila de productos (en mm)
        //    float totalHeight = baseHeight + (dtResponseOrden.Rows.Count * productRowHeight);

        //    // Definir el tamaño de la página (Ancho: 76mm, Altura calculada previamente)
        //    float pageWidth = Utilities.MillimetersToPoints(76); // Ancho de la página
        //    float pageHeight = Utilities.MillimetersToPoints(totalHeight); // Altura de la página (ya calculada)

        //    // Establecer el área de impresión
        //    e.Graphics.PageUnit = GraphicsUnit.Point;
        //    e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

        //    // Fuentes
        //    System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
        //    System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 8.5f);
        //    System.Drawing.Font boldFont = new System.Drawing.Font("Arial", 8.5f, FontStyle.Bold);
        //    System.Drawing.Font smallerFont = new System.Drawing.Font("Arial", 8f);

        //    float yPosition = 10; // Posición inicial en la página (márgenes superiores)
        //    float leftMargin = 35;

        //    // Creamos un StringFormat para centrar el texto
        //    StringFormat centeredFormat = new StringFormat
        //    {
        //        Alignment = StringAlignment.Center
        //    };

        //    // --- Encabezado centrado ---

        //    // Nombre de la empresa
        //    string companyName = Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"]);
        //    RectangleF rect = new RectangleF(0, yPosition, pageWidth, titleFont.GetHeight(e.Graphics));
        //    e.Graphics.DrawString(companyName, titleFont, Brushes.Black, rect, centeredFormat);
        //    yPosition += 15;

        //    // RUC de la empresa
        //    string ruc = Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"]);
        //    rect = new RectangleF(0, yPosition, pageWidth, regularFont.GetHeight(e.Graphics));
        //    e.Graphics.DrawString(ruc, regularFont, Brushes.Black, rect, centeredFormat);
        //    yPosition += 12;

        //    // Dirección de la sucursal
        //    string direccion = Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"]);
        //    rect = new RectangleF(0, yPosition, pageWidth, regularFont.GetHeight(e.Graphics));
        //    e.Graphics.DrawString(direccion, regularFont, Brushes.Black, rect, centeredFormat);
        //    yPosition += 12;

        //    // Teléfono de la sucursal
        //    string telefono = "Teléfono: " + Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"]);
        //    rect = new RectangleF(0, yPosition, pageWidth, regularFont.GetHeight(e.Graphics));
        //    e.Graphics.DrawString(telefono, regularFont, Brushes.Black, rect, centeredFormat);
        //    yPosition += 18; // Espacio antes de los datos de la factura

        //    DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];


        //    if (Convert.ToBoolean(item["BitEsCredito"]))
        //    {
        //        e.Graphics.DrawString($"Condición de pago: Crédito", boldFont, Brushes.Black, 10, yPosition);
        //        yPosition += 12;
        //    }

        //    // Datos de la factura
        //    e.Graphics.DrawString($"Fecha: {DateTime.Now.ToShortDateString():dd/MM/yyyy}", regularFont, Brushes.Black, 10, yPosition);
        //    yPosition += 12;

        //    e.Graphics.DrawString($"Cliente:", regularFont, Brushes.Black, 10, yPosition);
        //    yPosition += 12;
        //    e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"])}", regularFont, Brushes.Black, 10, yPosition);
        //    yPosition += 12;

        //    e.Graphics.DrawString($"No. Orden: {Convert.ToString(dtResponseOrden.Rows[0]["OrdenId"])}", regularFont, Brushes.Black, 10, yPosition);
        //    yPosition += 12;

        //    if (AuxEsProforma)
        //    {
        //        e.Graphics.DrawString($"PROFORMA-VIGENCIA {Convert.ToString(dtEmpresa["proforma"])} DÍAS", boldFont, Brushes.Black, 10, yPosition);
        //    }
        //    else
        //    {
        //        e.Graphics.DrawString($"No. Factura: {Convert.ToString(dtResponseOrden.Rows[0]["factura"])}", regularFont, Brushes.Black, 10, yPosition);
        //    }
        //    yPosition += 18; // Espacio antes de la tabla de productos

        //    // Tabla de productos
        //    e.Graphics.DrawString("Productos/Servicios", boldFont, Brushes.Black, 10, yPosition);
        //    //e.Graphics.DrawString("Cant", boldFont, Brushes.Black, pageWidth / 4, yPosition);
        //    //e.Graphics.DrawString("P.Unit", boldFont, Brushes.Black, pageWidth / 2, yPosition);
        //    //e.Graphics.DrawString("SubT", boldFont, Brushes.Black, 3 * pageWidth / 4, yPosition);
        //    yPosition += 12; // Espacio antes de los datos de los productos

        //    // Recorrer productos y dibujarlos en la página
        //    foreach (DataRow row in dtResponseOrden.Rows)
        //    {
        //        // Imprimir la cantidad y el precio unitario en una misma línea
        //        string cantidad = Convert.ToString(row["cantidad"]);
        //        string precioUnitario = Convert.ToDouble(row["precioUnitario"]).ToString("0.00");
        //        string producto = Convert.ToString(row["nombreProducto"]);

        //        // Ajustamos la cantidad, el precio unitario y el subtotales
        //        e.Graphics.DrawString($"{cantidad}x{precioUnitario}                      \t{Convert.ToDouble(row["subTotal"]).ToString("0.00")}", smallerFont, Brushes.Black, 10, yPosition);

        //        // Imprimir el nombre del producto en la siguiente línea
        //        yPosition += 12; // Siguiente línea para el nombre del producto
        //        e.Graphics.DrawString(producto, smallerFont, Brushes.Black, 10, yPosition);

        //        // Ajustar la posición para la siguiente línea de producto
        //        yPosition += 15; // Espacio para el siguiente producto
        //    }

        //    // Totales
        //    yPosition += 10;
        //    e.Graphics.DrawString($"Sub Total:             \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["SubtotalOrden"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);

        //    if(Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]) != 0)
        //    {
        //        yPosition += 10;
        //        e.Graphics.DrawString($"Adicional Crédito:     \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
        //    }

        //    if(Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]) != 0)
        //    {
        //        yPosition += 10;
        //        e.Graphics.DrawString($"Descuento:             \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
        //    }           

        //    if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0)
        //    {
        //        yPosition += 10;
        //        e.Graphics.DrawString($"DGI (2%):              \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
        //    }

        //    if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
        //    {
        //        yPosition += 10;
        //        e.Graphics.DrawString($"Alcaldía (1%):        \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
        //    }

        //    if (Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]) != 0)
        //    {
        //        yPosition += 10;
        //        e.Graphics.DrawString($"IVA:                          \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
        //    }

        //    yPosition += 12;
        //    e.Graphics.DrawString($"TOTAL:                 \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["totalCordoba"]):0.00} NIO", boldFont, Brushes.Black, 10, yPosition);

        //    if (Convert.ToDecimal(dtResponseOrden.Rows[0]["totalDolar"]) != 0)
        //    {
        //        yPosition += 10;
        //        e.Graphics.DrawString($"TOTAL:                 \t{Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"])} $", boldFont, Brushes.Black, 10, yPosition);
        //    }

        //    // Pie de página
        //    yPosition += 20;
        //    e.Graphics.DrawString("Gracias por su preferencia", regularFont, Brushes.Black, 10, yPosition);

        //    // Indicar que la página ha sido procesada
        //    e.HasMorePages = false;
        //}

        private void BtnImprimirFactura_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 27))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtConfigFacturacion1 = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            bit58mm = Convert.ToBoolean(dtConfigFacturacion1.Rows[0]["Bit58mm"]);
            bit80mm = Convert.ToBoolean(dtConfigFacturacion1.Rows[0]["Bit80mm"]);


            DataRow item = dataUtilities.getRecordByPrimaryKey("Ordenes", auxFrm.vMOrdenes.OrdenAux).Rows[0];

            if( Convert.ToString(item["NoFactura"]) == "0")
            {
                if (Convert.ToBoolean(item["BitEsCredito"]) == false)
                {
                    //Agregarle el numero de factura
                    DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                   bit58mm = Convert.ToBoolean(dtConfigFacturacion.Rows[0]["Bit58mm"]);
                   bit80mm = Convert.ToBoolean(dtConfigFacturacion.Rows[0]["Bit80mm"]);

                    decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFactura"]) + 1;

                    dataUtilities.SetColumns("ConsecutivoFactura", NoFactura);

                    dataUtilities.UpdateRecordByPrimaryKey(
                        "ConfigFacturacion",
                        Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                    //Actualizar en la orden

                    dataUtilities.SetParameter("@IdOrden", auxFrm.vMOrdenes.OrdenAux);
                    dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@Factura", NoFactura);
                    dataUtilities.SetParameter("@serie", Convert.ToString(dtConfigFacturacion.Rows[0]["Serie"]));

                    dataUtilities.ExecuteStoredProcedure("spActualizarFacturaOrden");
                }
                else
                {
                    //Agregarle el numero de factura
                    DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                    bit58mm = Convert.ToBoolean(dtConfigFacturacion.Rows[0]["Bit58mm"]);
                    bit80mm = Convert.ToBoolean(dtConfigFacturacion.Rows[0]["Bit80mm"]);

                    decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFacturaCredito"]) + 1;

                    dataUtilities.SetColumns("ConsecutivoFacturaCredito", NoFactura);

                    dataUtilities.UpdateRecordByPrimaryKey(
                        "ConfigFacturacion",
                        Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                    //Actualizar en la orden

                    dataUtilities.SetParameter("@IdOrden", auxFrm.vMOrdenes.OrdenAux);
                    dataUtilities.SetParameter("@IdSucursal", Utilidades.SucursalId);
                    dataUtilities.SetParameter("@Factura", NoFactura);
                    dataUtilities.SetParameter("@serie", Convert.ToString(dtConfigFacturacion.Rows[0]["SerieCredito"]));

                    dataUtilities.ExecuteStoredProcedure("spActualizarFacturaOrden");
                }
            }

            PrintPDF(false);
        }

        private void PnlPago_Load(object sender, EventArgs e)
        {
            TxtCantidadAbonada.Focus();
            TxtCantidadAbonada.Select();
        }
    }
}
