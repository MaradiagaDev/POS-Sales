﻿using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System;
using NeoCobranza.DataController;

namespace NeoCobranza.ViewModels
{
    public static class PdfPrintPageEventHandler
    {
        static DataUtilities dataUtilities = new DataUtilities();

        public static decimal OrdenAux;

        public static void ImprimeProforma(object sender, PrintPageEventArgs e)
        {
            dataUtilities.SetParameter("@OrdenId", OrdenAux);
            dataUtilities.SetParameter("@sucursarlId", Utilidades.SucursalId);

            DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");
            DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];

            // Establecer el área de impresión
            e.Graphics.PageUnit = GraphicsUnit.Point;

            // Fuentes y pinceles
            System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.Font subHeaderFont = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
            System.Drawing.Font tableHeaderFont = new System.Drawing.Font("Arial", 7.5f, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.Font regularFont2 = new System.Drawing.Font("Arial", 11);
            System.Drawing.Font smallFont = new System.Drawing.Font("Arial", 8);
            Brush yellowBrush = new SolidBrush(Color.DarkGoldenrod);
            Brush grayBrush = new SolidBrush(Color.Gray);

            // Margen izquierdo fijo para evitar desplazamientos no deseados
            float marginLeft = 20;
            float marginRight = e.MarginBounds.Right; // Asegurar el borde derecho

            float yPosition = 20; // Espacio inicial desde la parte superior

            // 1. LOGO DE LA EMPRESA
            RectangleF logoRectangle = new RectangleF(marginLeft, yPosition, 50, 50);
            e.Graphics.FillRectangle(Brushes.LightGray, logoRectangle); // Simula el logo como un cuadro gris
            e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(logoRectangle));

            byte[] imagenBytes = dtEmpresa["Logo"] as byte[];

            if (imagenBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    e.Graphics.DrawImage(System.Drawing.Image.FromStream(ms), logoRectangle);
                }
            }

            // 2. TITULOS AL LADO DEL LOGO
            float textStartX = marginLeft + 60; // Después del logo
            e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"])}", headerFont, yellowBrush, textStartX, yPosition);
            yPosition += 15;
            e.Graphics.DrawString(Convert.ToString(dtEmpresa["PrimerColumna"]), subHeaderFont, Brushes.Black, textStartX, yPosition);
            yPosition += 15;
            e.Graphics.DrawString(Convert.ToString(dtEmpresa["SegundaColumna"]), smallFont, Brushes.Black, textStartX, yPosition);

            // Línea bajo el encabezado (imagen)
            yPosition = 70; // Ajusta la altura
            e.Graphics.DrawLine(Pens.Black, marginLeft, yPosition, e.MarginBounds.Right - 155, yPosition);

            // Título "PROFORMA"
            yPosition += 10; // Espacio adicional
            string proformaText = "PROFORMA";

            // Coordenada X para la alineación izquierda
            marginLeft = 20; // Ajusta según el margen que desees
            e.Graphics.DrawString(proformaText, headerFont, Brushes.Black, marginLeft, yPosition);

            // Línea bajo el título "PROFORMA"
            float proformaHeight = e.Graphics.MeasureString(proformaText, headerFont).Height;
            float lineStartX = marginLeft; // Alineada con el texto
            float lineEndX = marginLeft + e.Graphics.MeasureString(proformaText, headerFont).Width;
            e.Graphics.DrawLine(Pens.Black, lineStartX, yPosition + proformaHeight + 2, lineEndX, yPosition + proformaHeight + 2);

            // Fecha en el margen derecho
            yPosition += proformaHeight;
            string dateText = $"Fecha de generación: {DateTime.Now.ToShortDateString():dd/MM/yyyy}";
            float dateX = e.MarginBounds.Right - 290; // Alinear derecha
            e.Graphics.DrawString(dateText, regularFont, Brushes.Black, dateX, yPosition);

            // 5. CAMPOS CLIENTE Y ATENCIÓN
            yPosition += 10;
            e.Graphics.DrawString($"Cliente:   {Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"])}", regularFont, Brushes.Black, marginLeft, yPosition);
            e.Graphics.DrawString("Atención: _______________________________________________________________________________", regularFont, Brushes.Black, marginLeft, yPosition + 20);

            // 6. TABLA
            yPosition += 45;
            float tableWidth = e.MarginBounds.Width - marginLeft - 20; // Aseguramos ancho dentro de los márgenes
            float[] columnWidths = { 50, 265, 50, 50, 70, 70 }; // Ancho de las columnas
            string[] columnHeaders = { "ITEM", "DESCRIPCIÓN", "CANT", "U/M", "P/U", "TOTAL" };

            // Dibujar encabezado de la tabla
            float xPosition = marginLeft;
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                RectangleF cellHeader = new RectangleF(xPosition, yPosition, columnWidths[i], 17);
                e.Graphics.FillRectangle(grayBrush, cellHeader);
                e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(cellHeader));
                e.Graphics.DrawString(columnHeaders[i], tableHeaderFont, Brushes.White, cellHeader,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                xPosition += columnWidths[i];
            }

            // Dibujar filas de la tabla
            yPosition += 17;

            int productIndex = 0; // Índice para recorrer los productos
            int totalRows = 30; // Total de filas a pintar
            int totalColumns = columnHeaders.Length; // Número de columnas

            // Recorremos las filas a pintar
            for (int row = 0; row < totalRows; row++)
            {
                // Primero, recorrer las columnas para determinar la altura máxima requerida en la fila
                float maxRowHeight = 17; // Altura mínima de la fila
                string[] cellValues = new string[totalColumns];

                for (int col = 0; col < totalColumns; col++)
                {
                    string cellValue = "";
                    if (productIndex < dtResponseOrden.Rows.Count)
                    {
                        DataRow currentProduct = dtResponseOrden.Rows[productIndex];
                        switch (col)
                        {
                            case 0: // ITEM
                                cellValue = (row + 1).ToString();
                                break;
                            case 1: // DESCRIPCIÓN
                                cellValue = Convert.ToString(currentProduct["nombreProducto"]);
                                break;
                            case 2: // CANT
                                cellValue = Convert.ToString(currentProduct["cantidad"]);
                                break;
                            case 3: // U/M
                                cellValue = ""; // Aquí puedes asignar un valor si es necesario
                                break;
                            case 4: // P/U
                                cellValue = Convert.ToDouble(currentProduct["precioUnitario"]).ToString("0.00");
                                break;
                            case 5: // TOTAL
                                cellValue = Convert.ToDouble(currentProduct["subTotal"]).ToString("0.00");
                                break;
                            default:
                                cellValue = "";
                                break;
                        }
                    }
                    // Guardamos el valor para el segundo recorrido
                    cellValues[col] = cellValue;

                    // Configurar la alineación (se alinea a la izquierda solo la "DESCRIPCIÓN")
                    StringFormat format = new StringFormat
                    {
                        Alignment = col == 1 ? StringAlignment.Near : StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    // Medir el tamaño requerido para el texto en el ancho de la celda
                    SizeF cellSize = e.Graphics.MeasureString(cellValue, regularFont, new SizeF(columnWidths[col], float.MaxValue), format);
                    if (cellSize.Height > maxRowHeight)
                        maxRowHeight = cellSize.Height;
                }

                // Ahora que tenemos la altura máxima de la fila, dibujar cada celda
                xPosition = marginLeft;
                for (int col = 0; col < totalColumns; col++)
                {
                    RectangleF cellRect = new RectangleF(xPosition, yPosition, columnWidths[col], maxRowHeight);
                    e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(cellRect));

                    StringFormat format = new StringFormat
                    {
                        Alignment = col == 1 ? StringAlignment.Near : StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    e.Graphics.DrawString(cellValues[col], regularFont, Brushes.Black, cellRect, format);
                    xPosition += columnWidths[col];
                }

                // Avanzar en los datos solo si hay productos disponibles
                if (productIndex < dtResponseOrden.Rows.Count)
                {
                    productIndex++;
                }

                // Incrementar la posición vertical por la altura de la fila
                yPosition += maxRowHeight;
            }

            // Crear una fuente en negritas para los títulos finales
            System.Drawing.Font boldFont = new System.Drawing.Font(regularFont2, FontStyle.Bold);

            // Agregar filas finales (Impuestos, Retenciones, Descuento, Costo Total)
            string[] labels = { "Descuento", "Adicional Crédito", "Impuestos", "Costo Total C$", "Costo Total $" };
            // Ajustamos las columnas para abarcar solo "U/M" y "P/U"
            float labelColumnWidth = columnWidths[3] + columnWidths[4]; // Sumar los anchos de "U/M" y "P/U"
            float valueColumnStart = marginLeft + columnWidths[0] + columnWidths[1] + columnWidths[2] + columnWidths[3] + columnWidths[4];
            float valueColumnWidth = columnWidths[5];

            // Valores iniciales (pueden ser modificados dinámicamente)
            string[] initialValues = {
        $"{Convert.ToString(dtResponseOrden.Rows[0]["Descuento"]):0.00}",
        $"{Convert.ToString(dtResponseOrden.Rows[0]["MontoCredito"]):0.00}",
        $"{Convert.ToString(dtResponseOrden.Rows[0]["Iva"]):0.00}",
        $"{Convert.ToString(dtResponseOrden.Rows[0]["totalCordoba"]):0.00}",
        $"{Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"]):0.00}"
    };

            int rowHeight = 17; // Altura fija para estas filas

            for (int i = 0; i < labels.Length; i++)
            {
                // Columna de etiqueta
                RectangleF labelCell = new RectangleF(
                    marginLeft + columnWidths[0] + columnWidths[1] + columnWidths[2],
                    yPosition,
                    labelColumnWidth,
                    rowHeight
                );
                e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(labelCell));
                e.Graphics.DrawString(labels[i], boldFont, Brushes.Black, labelCell,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                // Columna de valor
                RectangleF valueCell = new RectangleF(
                    valueColumnStart,
                    yPosition,
                    valueColumnWidth,
                    rowHeight
                );
                e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(valueCell));
                e.Graphics.DrawString(initialValues[i], regularFont, Brushes.Black, valueCell,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                yPosition += rowHeight;
            }

            // 7. PIE DE PÁGINA
            yPosition += 8;
            e.Graphics.DrawString($"NOTA: COTIZACIÓN VÁLIDA POR {Convert.ToString(dtEmpresa["proforma"])} DÍAS LUEGO DE LA PRESENTE FECHA.", regularFont, Brushes.Black, marginLeft, yPosition);
            yPosition += 10;
            e.Graphics.DrawString($"Dirección: {Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"])}    RUC: {Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"])}.", regularFont, Brushes.Black, marginLeft, yPosition);
            yPosition += 10;

            // Fuente subrayada para los enlaces
            System.Drawing.Font linkFont = new System.Drawing.Font(smallFont.FontFamily, smallFont.Size, FontStyle.Underline);
            Brush linkBrush = new SolidBrush(Color.FromArgb(0, 102, 204)); // Celeste oscuro

            e.Graphics.DrawString($"Cel: {Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"])}    Email: {Convert.ToString(dtResponseOrden.Rows[0]["EmailSucursal"])}.", linkFont, linkBrush, marginLeft, yPosition);
        }

        //COMPROBANTE DE CAJA
        // Variable auxiliar para determinar el tipo de movimiento de caja
        private static bool AuxEsSalida = false;

        public static void PrintPDFRecibo(bool esSalida)
        {
            // Asignar el tipo de movimiento a la variable auxiliar
            AuxEsSalida = esSalida;

            DataTable data = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);
            bool bit58mm = Convert.ToBoolean(data.Rows[0]["Bit58mm"]);
            bool bit80mm = Convert.ToBoolean(data.Rows[0]["Bit80mm"]);

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

            if(bit80mm)
            {
                doc.PrintPage += new PrintPageEventHandler(ImprimeComprobanteCaja80mm);
            }
            else if(bit58mm) 
            {
                doc.PrintPage += new PrintPageEventHandler(ImprimeComprobanteCaja58mm);
            }
            else 
            { 
                MessageBox.Show("Debe seleccionar un tamaño de factura en la configuración de facturación.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        public static string PagoId = "0";
        public static bool EsVenta = true;

        private static void ImprimeComprobanteCaja58mm(object sender, PrintPageEventArgs e)
        {
            DataTable dataEmpresa = dataUtilities.GetAllRecords("Empresa");
            DataTable dataSucursal = dataUtilities.getRecordByPrimaryKey("Sucursal", Utilidades.SucursalId);

            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Ancho total de la factura en puntos (48 mm convertidos a puntos)
            float anchoPagina = Utilities.MillimetersToPoints(48);
            float margenIzquierdo = 10;
            float margenDerecho = 10;
            float anchoRect = anchoPagina - (margenIzquierdo + margenDerecho);

            // Definir las fuentes: fuente más grande para el nombre de la empresa
            System.Drawing.Font fuenteEmpresa = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.Font fuenteTitulo = new System.Drawing.Font("Arial", 8, FontStyle.Bold);
            System.Drawing.Font fuenteRegular = new System.Drawing.Font("Arial", 10);
            System.Drawing.Font fuentePequeña = new System.Drawing.Font("Arial", 8);

            StringFormat formatoCentrado = new StringFormat { Alignment = StringAlignment.Center };

            float yPosicion = 10;

            // Sección opcional de imagen (logo)
            if (dataEmpresa.Rows[0]["BitImgFac"] != DBNull.Value && Convert.ToBoolean(dataEmpresa.Rows[0]["BitImgFac"]))
            {
                System.Drawing.Image logo = null;
                try
                {
                    byte[] imagenBytes = dataEmpresa.Rows[0]["Logo"] as byte[];
                    if (imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            logo = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
                catch { logo = null; }
                if (logo != null)
                {
                    float scale = anchoRect / logo.Width;
                    float logoWidth = anchoRect;
                    float logoHeight = logo.Height * scale;
                    float logoX = margenIzquierdo + ((anchoRect - logoWidth) / 2);
                    float logoY = yPosicion;
                    RectangleF logoRect = new RectangleF(logoX, logoY, logoWidth, logoHeight);
                    e.Graphics.DrawImage(logo, logoRect);
                    yPosicion += logoHeight + 5;
                }
            }

            // Nombre de la empresa (wrap y fuente mayor)
            string nombreEmpresa = Convert.ToString(dataEmpresa.Rows[0]["NombreEmpresa"]);
            SizeF sizeEmpresa = e.Graphics.MeasureString(nombreEmpresa, fuenteEmpresa, (int)anchoRect);
            RectangleF rectEmpresa = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeEmpresa.Height);
            e.Graphics.DrawString(nombreEmpresa, fuenteEmpresa, Brushes.Black, rectEmpresa, formatoCentrado);
            yPosicion += sizeEmpresa.Height + 5;

            // Dirección (wrap)
            string direccion = Convert.ToString(dataSucursal.Rows[0]["Direccion"]);
            SizeF sizeDireccion = e.Graphics.MeasureString(direccion, fuenteRegular, (int)anchoRect);
            RectangleF rectDireccion = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeDireccion.Height);
            e.Graphics.DrawString(direccion, fuenteRegular, Brushes.Black, rectDireccion, formatoCentrado);
            yPosicion += sizeDireccion.Height + 5;

            // Teléfono (wrap)
            string telefono = "Tel: " + Convert.ToString(dataSucursal.Rows[0]["Telefono"]);
            SizeF sizeTelefono = e.Graphics.MeasureString(telefono, fuenteRegular, (int)anchoRect);
            RectangleF rectTelefono = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeTelefono.Height);
            e.Graphics.DrawString(telefono, fuenteRegular, Brushes.Black, rectTelefono, formatoCentrado);
            yPosicion += sizeTelefono.Height + 10;

            // Título del comprobante
            string titulo = AuxEsSalida
                              ? "COMPROBANTE DE CAJA - SALIDA"
                              : "RECIBO OFICIAL DE CAJA - ENTRADA";
            SizeF sizeTitulo = e.Graphics.MeasureString(titulo, fuenteTitulo, (int)anchoRect);
            RectangleF rectTitulo = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeTitulo.Height);
            e.Graphics.DrawString(titulo, fuenteTitulo, Brushes.Black, rectTitulo, formatoCentrado);
            yPosicion += sizeTitulo.Height + 25;

            dataUtilities.SetParameter("@Id", PagoId);
            dataUtilities.SetParameter("@boolEsVenta", EsVenta);
            DataTable dataRecibo = dataUtilities.ExecuteStoredProcedure("sp_GetPagoTicket");

            // Fecha
            string fecha = "Fecha: " + Convert.ToDateTime(dataRecibo.Rows[0]["FechaPago"]).ToString("dd/MM/yyyy");
            SizeF sizeFecha = e.Graphics.MeasureString(fecha, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(fecha, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeFecha.Height + 5;

            // Número de recibo
            string numRecibo = $"Número de Recibo: {Convert.ToString(dataRecibo.Rows[0]["clave"])}";
            SizeF sizeRecibo = e.Graphics.MeasureString(numRecibo, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(numRecibo, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeRecibo.Height + 5;

            // Concepto o motivo
            string conceptoLabel = "Concepto:";
            SizeF sizeConceptoLabel = e.Graphics.MeasureString(conceptoLabel, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(conceptoLabel, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeConceptoLabel.Height + 5;

            string observaciones = Convert.ToString(dataRecibo.Rows[0]["Observaciones"]);
            SizeF sizeObservaciones = e.Graphics.MeasureString(observaciones, fuenteRegular, (int)anchoRect);
            RectangleF rectObservaciones = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeObservaciones.Height);
            e.Graphics.DrawString(observaciones, fuenteRegular, Brushes.Black, rectObservaciones, formatoCentrado);
            yPosicion += sizeObservaciones.Height + 20;

            // Monto del movimiento
            string montoLabel = "Monto:";
            SizeF sizeMontoLabel = e.Graphics.MeasureString(montoLabel, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(montoLabel, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeMontoLabel.Height + 5;
            string monto = $"{Convert.ToString(dataRecibo.Rows[0]["Total"])} (C$)";
            SizeF sizeMonto = e.Graphics.MeasureString(monto, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(monto, fuenteRegular, Brushes.Black, margenIzquierdo + 60, yPosicion);
            yPosicion += sizeMonto.Height + 20;

            // Línea y firma
            string lineaFirma = "________________________________";
            SizeF sizeLineaFirma = e.Graphics.MeasureString(lineaFirma, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(lineaFirma, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeLineaFirma.Height + 5;
            string firma = "Firma";
            SizeF sizeFirma = e.Graphics.MeasureString(firma, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(firma, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeFirma.Height + 5;

            // Pie de página o mensaje final
            string pie = "Gracias por su preferencia";
            SizeF sizePie = e.Graphics.MeasureString(pie, fuenteRegular, (int)anchoRect);
            RectangleF rectPie = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizePie.Height);
            e.Graphics.DrawString(pie, fuenteRegular, Brushes.Black, rectPie, formatoCentrado);

            e.HasMorePages = false;
        }


        private static void ImprimeComprobanteCaja80mm(object sender, PrintPageEventArgs e)
        {
            // Obtener los datos
            DataTable dataEmpresa = dataUtilities.GetAllRecords("Empresa");
            DataTable dataSucursal = dataUtilities.getRecordByPrimaryKey("Sucursal", Utilidades.SucursalId);

            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Ancho total de la factura en puntos (76 mm convertidos a puntos)
            float anchoPagina = Utilities.MillimetersToPoints(76);
            float margenIzquierdo = 10;
            float margenDerecho = 10;
            float anchoRect = anchoPagina - (margenIzquierdo + margenDerecho);

            // Definir las fuentes: se crea una fuente mayor para el nombre de la empresa
            System.Drawing.Font fuenteEmpresa = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.Font fuenteTitulo = new System.Drawing.Font("Arial", 8, FontStyle.Bold);
            System.Drawing.Font fuenteRegular = new System.Drawing.Font("Arial", 10);
            System.Drawing.Font fuentePequeña = new System.Drawing.Font("Arial", 8);

            // Formato centrado para los textos
            StringFormat formatoCentrado = new StringFormat { Alignment = StringAlignment.Center };

            float yPosicion = 10; // Posición vertical inicial

            // Sección opcional de imagen (logo)
            if (dataEmpresa.Rows[0]["BitImgFac"] != DBNull.Value && Convert.ToBoolean(dataEmpresa.Rows[0]["BitImgFac"]))
            {
                System.Drawing.Image logo = null;
                try
                {
                    byte[] imagenBytes = dataEmpresa.Rows[0]["Logo"] as byte[];
                    if (imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            logo = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
                catch { logo = null; }
                if (logo != null)
                {
                    float scale = anchoRect / logo.Width;
                    float logoWidth = anchoRect;
                    float logoHeight = logo.Height * scale;
                    float logoX = margenIzquierdo + ((anchoRect - logoWidth) / 2);
                    float logoY = yPosicion;
                    RectangleF logoRect = new RectangleF(logoX, logoY, logoWidth, logoHeight);
                    e.Graphics.DrawImage(logo, logoRect);
                    yPosicion += logoHeight + 5; // Espacio después del logo
                }
            }

            // Imprimir el nombre de la empresa con wrap y fuente mayor
            string nombreEmpresa = Convert.ToString(dataEmpresa.Rows[0]["NombreEmpresa"]);
            SizeF sizeEmpresa = e.Graphics.MeasureString(nombreEmpresa, fuenteEmpresa, (int)anchoRect);
            RectangleF rectEmpresa = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeEmpresa.Height);
            e.Graphics.DrawString(nombreEmpresa, fuenteEmpresa, Brushes.Black, rectEmpresa, formatoCentrado);
            yPosicion += sizeEmpresa.Height + 5;

            // Dirección de la sucursal (wrap)
            string direccion = Convert.ToString(dataSucursal.Rows[0]["Direccion"]);
            SizeF sizeDireccion = e.Graphics.MeasureString(direccion, fuenteRegular, (int)anchoRect);
            RectangleF rectDireccion = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeDireccion.Height);
            e.Graphics.DrawString(direccion, fuenteRegular, Brushes.Black, rectDireccion, formatoCentrado);
            yPosicion += sizeDireccion.Height + 5;

            // Teléfono (wrap)
            string telefono = "Tel: " + Convert.ToString(dataSucursal.Rows[0]["Telefono"]);
            SizeF sizeTelefono = e.Graphics.MeasureString(telefono, fuenteRegular, (int)anchoRect);
            RectangleF rectTelefono = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeTelefono.Height);
            e.Graphics.DrawString(telefono, fuenteRegular, Brushes.Black, rectTelefono, formatoCentrado);
            yPosicion += sizeTelefono.Height + 10;

            // Título del comprobante según el tipo de movimiento
            string titulo = AuxEsSalida
                              ? "COMPROBANTE DE CAJA - SALIDA"
                              : "RECIBO OFICIAL DE CAJA - ENTRADA";
            SizeF sizeTitulo = e.Graphics.MeasureString(titulo, fuenteTitulo, (int)anchoRect);
            RectangleF rectTitulo = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeTitulo.Height);
            e.Graphics.DrawString(titulo, fuenteTitulo, Brushes.Black, rectTitulo, formatoCentrado);
            yPosicion += sizeTitulo.Height + 25;

            // DATOS DEL RECIBO DE CAJA
            dataUtilities.SetParameter("@Id", PagoId);
            dataUtilities.SetParameter("@boolEsVenta", EsVenta);
            DataTable dataRecibo = dataUtilities.ExecuteStoredProcedure("sp_GetPagoTicket");

            // Fecha
            string fecha = "Fecha: " + Convert.ToDateTime(dataRecibo.Rows[0]["FechaPago"]).ToString("dd/MM/yyyy");
            SizeF sizeFecha = e.Graphics.MeasureString(fecha, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(fecha, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeFecha.Height + 5;

            // Número de recibo
            string numRecibo = $"Número de Recibo: {Convert.ToString(dataRecibo.Rows[0]["clave"])}";
            SizeF sizeRecibo = e.Graphics.MeasureString(numRecibo, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(numRecibo, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeRecibo.Height + 5;

            // Concepto o motivo
            string conceptoLabel = "Concepto:";
            SizeF sizeConceptoLabel = e.Graphics.MeasureString(conceptoLabel, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(conceptoLabel, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeConceptoLabel.Height + 5;

            string observaciones = Convert.ToString(dataRecibo.Rows[0]["Observaciones"]);
            SizeF sizeObservaciones = e.Graphics.MeasureString(observaciones, fuenteRegular, (int)anchoRect);
            RectangleF rectObservaciones = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizeObservaciones.Height);
            e.Graphics.DrawString(observaciones, fuenteRegular, Brushes.Black, rectObservaciones, formatoCentrado);
            yPosicion += sizeObservaciones.Height + 20;

            // Monto del movimiento
            string montoLabel = "Monto:";
            SizeF sizeMontoLabel = e.Graphics.MeasureString(montoLabel, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(montoLabel, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeMontoLabel.Height + 5;
            string monto = $"{Convert.ToString(dataRecibo.Rows[0]["Total"])} (C$)";
            SizeF sizeMonto = e.Graphics.MeasureString(monto, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(monto, fuenteRegular, Brushes.Black, margenIzquierdo + 60, yPosicion);
            yPosicion += sizeMonto.Height + 20;

            // Línea y firma
            string lineaFirma = "________________________________";
            SizeF sizeLineaFirma = e.Graphics.MeasureString(lineaFirma, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(lineaFirma, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeLineaFirma.Height + 5;
            string firma = "Firma";
            SizeF sizeFirma = e.Graphics.MeasureString(firma, fuenteRegular, (int)anchoRect);
            e.Graphics.DrawString(firma, fuenteRegular, Brushes.Black, margenIzquierdo, yPosicion);
            yPosicion += sizeFirma.Height + 5;

            // Pie de página o mensaje final
            string pie = "Gracias por su preferencia";
            SizeF sizePie = e.Graphics.MeasureString(pie, fuenteRegular, (int)anchoRect);
            RectangleF rectPie = new RectangleF(margenIzquierdo, yPosicion, anchoRect, sizePie.Height);
            e.Graphics.DrawString(pie, fuenteRegular, Brushes.Black, rectPie, formatoCentrado);

            e.HasMorePages = false;
        }
    }
}
