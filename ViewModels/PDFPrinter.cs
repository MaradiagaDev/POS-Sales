using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System;

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

            // 2. TITULOS AL LADO DEL LOGO
            float textStartX = marginLeft + 60; // Después del logo
            e.Graphics.DrawString($"{Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"])}", headerFont, yellowBrush, textStartX, yPosition);
            yPosition += 15;
            e.Graphics.DrawString("DIVISIÓN FERRETERA", subHeaderFont, Brushes.Black, textStartX, yPosition);
            yPosition += 15;
            e.Graphics.DrawString("Materiales de construcción y de ferretería general", smallFont, Brushes.Black, textStartX, yPosition);

            // Línea bajo el encabezado (imagen)
            yPosition = 70; // Ajusta la altura
            e.Graphics.DrawLine(Pens.Black, marginLeft, yPosition, e.MarginBounds.Right-155, yPosition);

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
            yPosition += proformaHeight + 0; // Espacio entre título y fecha
            string dateText = $"Fecha de generación: {DateTime.Now.ToShortDateString():dd/MM/yyyy}";
        
            float dateX = e.MarginBounds.Right - 290; // Alinear derecha
            e.Graphics.DrawString(dateText, regularFont, Brushes.Black, dateX, yPosition);

            // 5. CAMPOS CLIENTE Y ATENCIÓN
            yPosition += 10;
            // Dibujar el texto "Cliente:"
            //string clienteTexto = "Cliente: ";
            //e.Graphics.DrawString(clienteTexto, regularFont, Brushes.Black, marginLeft, yPosition);

            //// Calcular el ancho del texto "Cliente:" para alinear el nombre y subrayado
            //float clienteTextoWidth = e.Graphics.MeasureString(clienteTexto, regularFont).Width;

            // Dibujar el nombre del cliente y el subrayado
            //string nombreCliente = "Juan Pérez"; // Aquí colocas el nombre dinámico
            //float totalWidth = e.MarginBounds.Width - marginLeft - 20; // Ancho total disponible
            //float remainingWidth = totalWidth - clienteTextoWidth; // Espacio restante después del texto inicial

            //string subrayado = new string('_', (int)(remainingWidth / e.Graphics.MeasureString("_", regularFont).Width));
            //e.Graphics.DrawString(nombreCliente + subrayado, regularFont, Brushes.Black, marginLeft + clienteTextoWidth, yPosition);

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
                e.Graphics.DrawString(columnHeaders[i], tableHeaderFont, Brushes.White, cellHeader, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                xPosition += columnWidths[i];
            }

            // Dibujar filas de la tabla
            yPosition += 17;

            int productIndex = 0; // Índice para recorrer los productos
            int totalRows = 30; // Total de filas a pintar
            int totalColumns = columnHeaders.Length; // Número de columnas

            // Recorremos las filas que se deben pintar
            for (int row = 0; row < totalRows; row++)
            {
                xPosition = marginLeft;

                for (int col = 0; col < totalColumns; col++)
                {
                    RectangleF cell = new RectangleF(xPosition, yPosition, columnWidths[col], 17);
                    e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(cell));

                    // Si hay productos disponibles, llenamos las columnas con datos
                    if (productIndex < dtResponseOrden.Rows.Count)
                    {
                        DataRow currentProduct = dtResponseOrden.Rows[productIndex];

                        // Rellenar la celda con los datos correspondientes
                        string cellValue = "";
                        switch (col)
                        {
                            case 0: // ITEM (número de fila)
                                cellValue = (row + 1).ToString();
                                break;
                            case 1: // DESCRIPCIÓN
                                cellValue = Convert.ToString(currentProduct["nombreProducto"]);
                                break;
                            case 2: // CANT
                                cellValue = Convert.ToString(currentProduct["cantidad"]);
                                break;
                            case 3: // U/M
                                cellValue = ""; // Reemplaza esto con un valor real si es necesario
                                break;
                            case 4: // P/U
                                cellValue = Convert.ToDouble(currentProduct["precioUnitario"]).ToString("0.00");
                                break;
                            case 5: // TOTAL
                                cellValue = Convert.ToDouble(currentProduct["subTotal"]).ToString("0.00");
                                break;
                            default: // Valor por defecto
                                cellValue = "";
                                break;
                        }

                        StringFormat format = new StringFormat
                        {
                            Alignment = col == 1 ? StringAlignment.Near : StringAlignment.Center, // Alinea a la izquierda solo la columna "DESCRIPCIÓN"
                            LineAlignment = StringAlignment.Center // Verticalmente centrado
                        };

                        // Dibujar el texto en la celda
                        e.Graphics.DrawString(cellValue, regularFont, Brushes.Black, cell, format);

                        // Dibujar el texto en la celda
                        //e.Graphics.DrawString(cellValue, regularFont, Brushes.Black, cell, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        // Si no hay más productos, dejamos la celda vacía
                        e.Graphics.DrawString("", regularFont, Brushes.Black, cell, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }

                    xPosition += columnWidths[col];
                }

                // Pasamos al siguiente producto solo si hay más productos disponibles
                if (productIndex < dtResponseOrden.Rows.Count)
                {
                    productIndex++;
                }

                yPosition += 17; // Incrementamos la posición en Y para la siguiente fila
            }

            // Crear una fuente en negritas para los títulos
            System.Drawing.Font boldFont = new System.Drawing.Font(regularFont2, FontStyle.Bold);

            // Agregar filas finales (Impuestos, Retenciones, Descuento, Costo Total)
            string[] labels = { "Descuento", "Adicional Crédito", "Impuestos", "Costo Total C$", "Costo Total $" };
            // Ajustamos las columnas para abarcar solo "U/M" y "P/U"
            float labelColumnWidth = columnWidths[3] + columnWidths[4]; // Sumar los anchos de "U/M" y "P/U"
            float valueColumnStart = marginLeft + columnWidths[0] + columnWidths[1] + columnWidths[2] + columnWidths[3] + columnWidths[4]; // Inicio de la columna "Total"
            float valueColumnWidth = columnWidths[5]; // Ancho de la columna "Total"

            // Valores iniciales (puedes cambiarlos dinámicamente después)
            string[] initialValues = { $"{Convert.ToString(dtResponseOrden.Rows[0]["Descuento"]):0.00}"
                    ,$"{Convert.ToString(dtResponseOrden.Rows[0]["MontoCredito"]):0.00}"
                    ,$"{Convert.ToString(dtResponseOrden.Rows[0]["Iva"]):0.00}",
                     $"{Convert.ToString(dtResponseOrden.Rows[0]["totalCordoba"]):0.00}",
                     $"{Convert.ToString(dtResponseOrden.Rows[0]["totalDolar"]):0.00}"}; // Ejemplo de valores iniciales

            // Ajuste para la altura y posición
            int rowHeight = 17; // Reducimos un poco la altura de las filas

            for (int i = 0; i < labels.Length; i++)
            {
                // Columna de texto (Etiqueta)
                RectangleF labelCell = new RectangleF(
                    marginLeft + columnWidths[0] + columnWidths[1] + columnWidths[2], // Empieza en "U/M"
                    yPosition,
                    labelColumnWidth,
                    rowHeight
                );
                e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(labelCell));
                e.Graphics.DrawString(labels[i], boldFont, Brushes.Black, labelCell, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }); // Alineado centrado

                // Columna de valor (Con un valor inicial en "Total")
                RectangleF valueCell = new RectangleF(
                    valueColumnStart, // Posición de la columna "Total"
                    yPosition,
                    valueColumnWidth,
                    rowHeight
                );
                e.Graphics.DrawRectangle(Pens.Black, System.Drawing.Rectangle.Round(valueCell));
                e.Graphics.DrawString(initialValues[i], regularFont, Brushes.Black, valueCell, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                yPosition += rowHeight; // Incrementamos la posición en Y para la siguiente fila
            }

            // 7. PIE DE PÁGINA
            yPosition += 8;
            e.Graphics.DrawString("NOTA: COTIZACIÓN VÁLIDA POR 5 DÍAS LUEGO DE LA PRESENTE FECHA.", regularFont, Brushes.Black, marginLeft, yPosition);
            yPosition += 10;
            e.Graphics.DrawString($"Dirección: {Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"])}    RUC: {Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"])}.", regularFont, Brushes.Black, marginLeft, yPosition);
            yPosition += 10;
            // Define la fuente con estilo subrayado
            System.Drawing.Font linkFont = new System.Drawing.Font(smallFont.FontFamily, smallFont.Size, FontStyle.Underline);

            // Define el color celeste oscuro
            Brush linkBrush = new SolidBrush(Color.FromArgb(0, 102, 204)); // Código RGB para un celeste oscuro

            // Dibuja el texto 
            e.Graphics.DrawString($"Cel: {Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"])}    Email: {Convert.ToString(dtResponseOrden.Rows[0]["EmailSucursal"])}.", linkFont, linkBrush, marginLeft, yPosition);
        }

    }
}
