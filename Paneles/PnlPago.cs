using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NeoCobranza.Informes.Informes_Formato_Ticket;
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

                    //Agregarle el numero de factura
                    DataTable dtConfigFacturacion = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

                    decimal NoFactura = Convert.ToDecimal(dtConfigFacturacion.Rows[0]["ConsecutivoFactura"]) + 1;

                    dataUtilities.SetColumns("ConsecutivoFactura", NoFactura);

                    dataUtilities.UpdateRecordByPrimaryKey(
                        "ConfigFacturacion",
                        Convert.ToString(dtConfigFacturacion.Rows[0]["ConfigFacturacionId"]));

                    //Actualizar en la orden

                    dataUtilities.SetParameter("@IdOrden", auxFrm.vMOrdenes.OrdenAux);
                    dataUtilities.SetParameter("@IdSucursal",Utilidades.SucursalId);
                    dataUtilities.SetParameter("@Factura",NoFactura);
                    dataUtilities.SetParameter("@serie", Convert.ToString(dtConfigFacturacion.Rows[0]["Serie"]));

                    dataUtilities.ExecuteStoredProcedure("spActualizarFacturaOrden");

                    DialogResult result = MessageBox.Show("¿Desea imprimir factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        PrintPDF(false);
                        //FUNCION REPORTE
                        //FrmFacturaTicket frmTicketFactura = new FrmFacturaTicket(Utilidades.SucursalId, auxFrm.vMOrdenes.OrdenAux);
                        //frmTicketFactura.ShowDialog();
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
            }
        }

        private void DgvItemsPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                dataUtilities.SetParameter("@PagoOrdenId", dynamicDataTable.Rows[e.RowIndex][0]);
                dataUtilities.ExecuteStoredProcedure("sp_EliminarPago");

                CargarValores();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
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
            
            doc.PrintPage += new PrintPageEventHandler(imprimeTicket);

            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
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

        private void imprimeTicket(object sender, PrintPageEventArgs e)
        {
            dataUtilities.SetParameter("@OrdenId", auxFrm.vMOrdenes.OrdenAux);
            dataUtilities.SetParameter("@sucursarlId", Utilidades.SucursalId);

            DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");

            const float baseHeight = 115; // Espacio fijo para encabezado, totales, etc. (en mm)
            const float productRowHeight = 16; // Altura de cada fila de productos (en mm)
            float totalHeight = baseHeight + (dtResponseOrden.Rows.Count * productRowHeight);

            // Definir el tamaño de la página (Ancho: 76mm, Altura calculada previamente)
            float pageWidth = Utilities.MillimetersToPoints(76); // Ancho de la página
            float pageHeight = Utilities.MillimetersToPoints(totalHeight); // Altura de la página (ya calculada)

            // Establecer el área de impresión
            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Fuentes
            System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 8.5f);
            System.Drawing.Font boldFont = new System.Drawing.Font("Arial", 8.5f, FontStyle.Bold);
            System.Drawing.Font smallerFont = new System.Drawing.Font("Arial", 8f);

            float yPosition = 10; // Posición inicial en la página (márgenes superiores)
            float leftMargin = 35;

            // Cabecera hacia la izquierda
            e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"])}", titleFont, Brushes.Black, leftMargin, yPosition, new StringFormat { Alignment = StringAlignment.Near });
            yPosition += 15; // Ajustar para siguiente línea

            e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"])}", regularFont, Brushes.Black, leftMargin, yPosition, new StringFormat { Alignment = StringAlignment.Near });
            yPosition += 12;

            e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"])}", regularFont, Brushes.Black, leftMargin, yPosition, new StringFormat { Alignment = StringAlignment.Near });
            yPosition += 12;

            e.Graphics.DrawString($"Teléfono: {Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"])}", regularFont, Brushes.Black, leftMargin, yPosition, new StringFormat { Alignment = StringAlignment.Near });
            yPosition += 18; // Espacio antes de los datos de la factura

            // Datos de la factura
            e.Graphics.DrawString($"Fecha: {DateTime.Now.ToShortDateString():dd/MM/yyyy}", regularFont, Brushes.Black, 10, yPosition);
            yPosition += 12;

            e.Graphics.DrawString($"Cliente:", regularFont, Brushes.Black, 10, yPosition);
            yPosition += 12;
            e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"])}", regularFont, Brushes.Black, 10, yPosition);
            yPosition += 12;

            e.Graphics.DrawString($"No. Orden: {Convert.ToString(dtResponseOrden.Rows[0]["OrdenId"])}", regularFont, Brushes.Black, 10, yPosition);
            yPosition += 12;

            if (AuxEsProforma)
            {
                e.Graphics.DrawString($"PROFORMA-VIGENCIA 10 DÍAS", boldFont, Brushes.Black, 10, yPosition);
            }
            else
            {
                e.Graphics.DrawString($"No. Factura: {Convert.ToString(dtResponseOrden.Rows[0]["factura"])}", regularFont, Brushes.Black, 10, yPosition);
            }
            yPosition += 18; // Espacio antes de la tabla de productos

            // Tabla de productos
            e.Graphics.DrawString("Productos/Servicios", boldFont, Brushes.Black, 10, yPosition);
            //e.Graphics.DrawString("Cant", boldFont, Brushes.Black, pageWidth / 4, yPosition);
            //e.Graphics.DrawString("P.Unit", boldFont, Brushes.Black, pageWidth / 2, yPosition);
            //e.Graphics.DrawString("SubT", boldFont, Brushes.Black, 3 * pageWidth / 4, yPosition);
            yPosition += 12; // Espacio antes de los datos de los productos

            // Recorrer productos y dibujarlos en la página
            foreach (DataRow row in dtResponseOrden.Rows)
            {
                // Imprimir la cantidad y el precio unitario en una misma línea
                string cantidad = Convert.ToString(row["cantidad"]);
                string precioUnitario = Convert.ToDouble(row["precioUnitario"]).ToString("0.00");
                string producto = Convert.ToString(row["nombreProducto"]);

                // Ajustamos la cantidad, el precio unitario y el subtotales
                e.Graphics.DrawString($"{cantidad}x{precioUnitario}                      \t{Convert.ToDouble(row["subTotal"]).ToString("0.00")}", smallerFont, Brushes.Black, 10, yPosition);
  
                // Imprimir el nombre del producto en la siguiente línea
                yPosition += 12; // Siguiente línea para el nombre del producto
                e.Graphics.DrawString(producto, smallerFont, Brushes.Black, 10, yPosition);

                // Ajustar la posición para la siguiente línea de producto
                yPosition += 15; // Espacio para el siguiente producto
            }

            // Totales
            yPosition += 10;
            e.Graphics.DrawString($"Sub Total:             \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["SubtotalOrden"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);

            if(Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]) != 0)
            {
                yPosition += 10;
                e.Graphics.DrawString($"Adicional Crédito:     \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["MontoCredito"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
            }
            
            if(Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]) != 0)
            {
                yPosition += 10;
                e.Graphics.DrawString($"Descuento:             \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["Descuento"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
            }           

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]) != 0)
            {
                yPosition += 10;
                e.Graphics.DrawString($"DGI (2%):              \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionDgi"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]) != 0)
            {
                yPosition += 10;
                e.Graphics.DrawString($"Alcaldía (1%):        \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["RetencionAlcaldia"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
            }

            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]) != 0)
            {
                yPosition += 10;
                e.Graphics.DrawString($"IVA:                          \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["Iva"]):0.00} NIO", regularFont, Brushes.Black, 10, yPosition);
            }

            yPosition += 12;
            e.Graphics.DrawString($"TOTAL:                 \t{Convert.ToDecimal(dtResponseOrden.Rows[0]["totalCordoba"]):0.00} NIO", boldFont, Brushes.Black, 10, yPosition);
           
            if (Convert.ToDecimal(dtResponseOrden.Rows[0]["totalDolar"]) != 0)
            {
                yPosition += 10;
                e.Graphics.DrawString($"TOTAL:                 \t{Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"])} $", boldFont, Brushes.Black, 10, yPosition);
            }
          
            // Pie de página
            yPosition += 20;
            e.Graphics.DrawString("Gracias por su preferencia", regularFont, Brushes.Black, 10, yPosition);

            // Indicar que la página ha sido procesada
            e.HasMorePages = false;
        }

    }
}
