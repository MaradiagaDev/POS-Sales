using iTextSharp.text;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace NeoCobranza.Paneles
{
    public partial class PnlImprimeTicketsDetalle : Form
    {
        string auxOrden;
        string auxSucursal;
        DataUtilities dataUtilities = new DataUtilities();
        DataTable dynamicDataTable;

        public PnlImprimeTicketsDetalle(string Orden,string sucursalId)
        {
            InitializeComponent();
            auxOrden = Orden;
            auxSucursal = sucursalId;
        }

        private void Buscar()
        {
            dynamicDataTable.Clear();

            dataUtilities.SetParameter("@OrdenId", auxOrden);
            dataUtilities.SetParameter("@SucursalId", auxSucursal);
            DataTable dtDetalle = dataUtilities.ExecuteStoredProcedure("sp_GetHistorialProductos");

            foreach (DataRow item in dtDetalle.Rows)
            {
                // Se agrega la fila con el CheckBox en false por defecto
                dynamicDataTable.Rows.Add(
                    false,  // Valor inicial del CheckBox
                    Convert.ToString(item["HistorialId"]),
                    Convert.ToString(item["NombreProducto"]),
                    Convert.ToString(item["Cantidad"]),
                    Convert.ToString(item["PrecioUnitario"]),
                    Convert.ToString(item["SubTotal"]),
                    Convert.ToString(item["Fecha"]),
                     Convert.ToString(item["UltimaImpresion"]),
                      Convert.ToString(item["CantidadImpresiones"])
                );
            }
        }

        private void PnlImprimeTicketsDetalle_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvItemsOrden);

            // Asegurarse de que la grilla sea editable
            DgvItemsOrden.ReadOnly = false;
            DgvItemsOrden.EditMode = DataGridViewEditMode.EditOnEnter;

            dynamicDataTable = new DataTable();

            // Agregar columna boolean para que se muestre como CheckBox
            dynamicDataTable.Columns.Add("Seleccionar", typeof(bool));
            dynamicDataTable.Columns.Add("Clave", typeof(string));
            dynamicDataTable.Columns.Add("Producto", typeof(string));
            dynamicDataTable.Columns.Add("Cantidad", typeof(string));
            dynamicDataTable.Columns.Add("Precio Unitario", typeof(string));
            dynamicDataTable.Columns.Add("SubTotal", typeof(string));
            dynamicDataTable.Columns.Add("Fecha Agregación", typeof(string));
            dynamicDataTable.Columns.Add("Fecha Ultimo Ticket", typeof(string));
            dynamicDataTable.Columns.Add("Cantidad Impresiones", typeof(string));

            dataUtilities.SetParameter("@OrdenId",auxOrden);
            dataUtilities.SetParameter("@SucursalId", auxSucursal);
            DataTable dtDetalle = dataUtilities.ExecuteStoredProcedure("sp_GetHistorialProductos");

            foreach (DataRow item in dtDetalle.Rows)
            {
                // Se agrega la fila con el CheckBox en false por defecto
                dynamicDataTable.Rows.Add(
                    false,  // Valor inicial del CheckBox
                    Convert.ToString(item["HistorialId"]),
                    Convert.ToString(item["NombreProducto"]),
                    Convert.ToString(item["Cantidad"]),
                    Convert.ToString(item["PrecioUnitario"]),
                    Convert.ToString(item["SubTotal"]),
                    Convert.ToString(item["Fecha"]),
                     Convert.ToString(item["UltimaImpresion"]),
                      Convert.ToString(item["CantidadImpresiones"])
                );
            }

            // Asignar la tabla al DataGridView
            DgvItemsOrden.DataSource = dynamicDataTable;

            // Opcional: ajustar la columna de CheckBox si es necesario
            DgvItemsOrden.Columns["Seleccionar"].ReadOnly = false;
            DgvItemsOrden.Columns["Seleccionar"].Width = 50;

            // Suscribirse al evento CellContentClick para forzar la edición del CheckBox
            DgvItemsOrden.CellContentClick += DgvItemsOrden_CellContentClick;
        }

        private void DgvItemsOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si se hizo clic en la columna "Seleccionar" y es una fila válida
            if (DgvItemsOrden.Columns[e.ColumnIndex].Name == "Seleccionar" && e.RowIndex >= 0)
            {
                // Forzar el commit de la edición para que se actualice el valor del CheckBox
                DgvItemsOrden.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PrintPDF();
        }

        // Dentro de tu clase PnlImprimeTicketsDetalle

        public void PrintPDF()
        {
            DataTable data = dataUtilities.getRecordByColumn("ConfigFacturacion", "SucursalId", Utilidades.SucursalId);

            // Verificar si hay ítems seleccionados en el DataGridView
            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in DgvItemsOrden.Rows)
            {
                if (row.Cells["Seleccionar"].Value != null && Convert.ToBoolean(row.Cells["Seleccionar"].Value) == true)
                {
                    selectedRows.Add(row);
                }
            }
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un ítem para imprimir el ticket", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determinar el tamaño del ticket (en milímetros). Se asume que si Bit58mm es verdadero se usará 58, de lo contrario, 80.
            int ticketSize = Convert.ToBoolean(data.Rows[0]["Bit58mm"]) ? 58 : (Convert.ToBoolean(data.Rows[0]["Bit80mm"]) ? 80 : 58);

            PrintDocument doc = new PrintDocument();
            if (string.IsNullOrEmpty(Convert.ToString(data.Rows[0]["ImpresoraTicket"])))
            {
                doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            }
            else
            {
                doc.PrinterSettings.PrinterName = Convert.ToString(data.Rows[0]["ImpresoraTicket"]);
            }

            // Asignar el manejador de impresión, pasando el tamaño del ticket
            doc.PrintPage += (s, e) => imprimeTicket(s, e, ticketSize);

            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
        }


        /// <summary>
        /// Imprime el ticket de venta. Se toman los ítems seleccionados en DgvItemsOrden,
        /// se agrupan por "Fecha Agregación" y se imprime cada grupo con sus respectivos detalles.
        /// El parámetro ticketSize determina el ancho del ticket (58 o 80 mm).
        /// </summary>
        private void imprimeTicket(object sender, PrintPageEventArgs e, int ticketSize)
        {
            // Convertir el ancho efectivo: para 58mm se usa 48mm efectivos, para 80mm se usa el mismo tamaño
            float effectiveWidthMm = (ticketSize == 58) ? 48 : ticketSize;
            float pageWidth = Utilities.MillimetersToPoints(effectiveWidthMm);
            float marginLeft = 10;
            float marginRight = 10;
            float availableWidth = pageWidth - marginLeft - marginRight;

            e.Graphics.PageUnit = GraphicsUnit.Point;
            e.Graphics.FillRectangle(Brushes.White, e.MarginBounds);

            // Definir fuentes y estilos
            Font titleFont = new Font("Arial", 10, FontStyle.Bold);
            Font regularFont = new Font("Arial", 8.5f);
            Font boldFont = new Font("Arial", 8.5f, FontStyle.Bold);
            Font smallerFont = new Font("Arial", 8f);
            Pen dottedPen = new Pen(Color.Black);
            dottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            float yPosition = 20; // Posición vertical inicial

            // ----------------------------------------------------------------
            // CABECERA: Datos de la empresa y de la orden (igual que en la factura)
            // ----------------------------------------------------------------
            DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];
            dataUtilities.SetParameter("@OrdenId", auxOrden);
            dataUtilities.SetParameter("@sucursarlId", auxSucursal);
            DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");

            // Logo de la empresa (imagen más pequeña, usando el 50% del ancho disponible)
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
                    // Reducir la imagen al 50% del ancho disponible
                    float desiredLogoWidth = availableWidth * 0.7f;
                    float scale = desiredLogoWidth / logo.Width;
                    float logoWidth = desiredLogoWidth;
                    float logoHeight = logo.Height * scale;
                    float logoX = marginLeft + ((availableWidth - logoWidth) / 2);
                    float logoY = yPosition;
                    RectangleF logoRect = new RectangleF(logoX, logoY, logoWidth, logoHeight);
                    e.Graphics.DrawImage(logo, logoRect);
                    yPosition += logoHeight + 5;
                }
            }

            // Título del ticket
            string headerText = "Ticket de Venta";
            SizeF headerSize = e.Graphics.MeasureString(headerText, titleFont, (int)availableWidth);
            e.Graphics.DrawString(headerText, titleFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, headerSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += headerSize.Height + 5;

            // Nombre de la empresa
            string companyName = Convert.ToString(dtResponseOrden.Rows[0]["NombreEmpresa"]);
            RectangleF headerRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
            SizeF companySize = e.Graphics.MeasureString(companyName, titleFont, (int)availableWidth);
            headerRect.Height = companySize.Height;
            e.Graphics.DrawString(companyName, titleFont, Brushes.Black, headerRect, new StringFormat { Alignment = StringAlignment.Center });
            yPosition += companySize.Height + 5;

            // RUC de la empresa
            string ruc = Convert.ToString(dtResponseOrden.Rows[0]["RucEmpresa"]);
            SizeF rucSize = e.Graphics.MeasureString(ruc, regularFont, (int)availableWidth);
            e.Graphics.DrawString(ruc, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, rucSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += rucSize.Height + 5;

            // Nombre de la sucursal
            string sucursal = Convert.ToString(dtResponseOrden.Rows[0]["NombreSucursal"]);
            SizeF sucursalSize = e.Graphics.MeasureString(sucursal, regularFont, (int)availableWidth);
            e.Graphics.DrawString(sucursal, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, sucursalSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += sucursalSize.Height + 5;

            // Dirección de la sucursal
            string direccion = Convert.ToString(dtResponseOrden.Rows[0]["DireccionSucursal"]);
            SizeF direccionSize = e.Graphics.MeasureString(direccion, regularFont, (int)availableWidth);
            e.Graphics.DrawString(direccion, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, direccionSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += direccionSize.Height + 5;

            // Teléfono de la sucursal
            string telefono = "Teléfono: " + Convert.ToString(dtResponseOrden.Rows[0]["TelefonoSucursal"]);
            SizeF telefonoSize = e.Graphics.MeasureString(telefono, regularFont, (int)availableWidth);
            e.Graphics.DrawString(telefono, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, telefonoSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += telefonoSize.Height + 10;

            // Datos del cliente
            string clienteLabel = "Cliente:";
            SizeF clienteLabelSize = e.Graphics.MeasureString(clienteLabel, regularFont, (int)availableWidth);
            e.Graphics.DrawString(clienteLabel, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, clienteLabelSize.Height));
            yPosition += clienteLabelSize.Height;

            string nombreCliente = Convert.ToString(dtResponseOrden.Rows[0]["NombreCliente"]);
            SizeF nombreClienteSize = e.Graphics.MeasureString(nombreCliente, regularFont, (int)availableWidth);
            e.Graphics.DrawString(nombreCliente, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, nombreClienteSize.Height));
            yPosition += nombreClienteSize.Height + 5;

            // Número de orden
            string ordenText = $"No. Orden: {Convert.ToString(dtResponseOrden.Rows[0]["OrdenId"])}";
            SizeF ordenSize = e.Graphics.MeasureString(ordenText, regularFont, (int)availableWidth);
            e.Graphics.DrawString(ordenText, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, ordenSize.Height));
            yPosition += ordenSize.Height + 5;

            // Línea separadora entre cabecera e ítems
            e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
            yPosition += 5;

            // ----------------------------------------------------------------
            // Impresión de los ítems seleccionados agrupados por "Fecha Agregación"
            // ----------------------------------------------------------------

            // Recoger las filas seleccionadas en el DataGridView
            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in DgvItemsOrden.Rows)
            {
                if (row.Cells["Seleccionar"].Value != null && Convert.ToBoolean(row.Cells["Seleccionar"].Value) == true)
                {
                    selectedRows.Add(row);
                }
            }

            // Agrupar los ítems por "Fecha Agregación"
            var groupedRows = selectedRows
            .Where(r => r.Cells["Fecha Agregación"].Value != null)
            .GroupBy(r => Convert.ToString(r.Cells["Fecha Agregación"].Value))
            .OrderByDescending(g => g.Key);

            if (selectedRows.Count == 0)
            {
                string noItems = "No hay ítems seleccionados";
                SizeF noItemsSize = e.Graphics.MeasureString(noItems, regularFont, (int)availableWidth);
                e.Graphics.DrawString(noItems, regularFont, Brushes.Black,
                    new RectangleF(marginLeft, yPosition, availableWidth, noItemsSize.Height),
                    new StringFormat { Alignment = StringAlignment.Center });
                yPosition += noItemsSize.Height + 5;
            }
            else
            {
                // Recorrer cada grupo (por fecha)

                foreach (var group in groupedRows)
                {
                    // Encabezado del grupo con la fecha
                    string groupHeader = "Fecha: " + group.Key;
                    SizeF groupHeaderSize = e.Graphics.MeasureString(groupHeader, boldFont, (int)availableWidth);
                    e.Graphics.DrawString(groupHeader, boldFont, Brushes.Black,
                        new RectangleF(marginLeft, yPosition, availableWidth, groupHeaderSize.Height));
                    yPosition += groupHeaderSize.Height + 3;

                    // Recorrer cada ítem del grupo
                    foreach (DataGridViewRow row in group)
                    {
                        string producto = Convert.ToString(row.Cells["Producto"].Value);
                        string cantidad = Convert.ToString(row.Cells["Cantidad"].Value);
                        string precio = Convert.ToString(row.Cells["Precio Unitario"].Value);
                        string subTotal = Convert.ToString(row.Cells["SubTotal"].Value);

                        // Imprimir el nombre del producto (permitiendo wrap)
                        RectangleF prodRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                        SizeF prodSize = e.Graphics.MeasureString(producto, regularFont, (int)availableWidth);
                        prodRect.Height = prodSize.Height;
                        e.Graphics.DrawString(producto, regularFont, Brushes.Black, prodRect);
                        yPosition += prodSize.Height;

                        // Imprimir detalle: cantidad, precio unitario y subtotal
                        string detail = $"Cant: {cantidad}  P.U.: {precio}  Sub: {subTotal}";
                        RectangleF detailRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                        SizeF detailSize = e.Graphics.MeasureString(detail, smallerFont, (int)availableWidth);
                        detailRect.Height = detailSize.Height;
                        e.Graphics.DrawString(detail, smallerFont, Brushes.Black, detailRect);
                        yPosition += detailSize.Height + 5;

                        dataUtilities.SetColumns("UltimaImpresion", DateTime.Now);
                        dataUtilities.SetColumns("CantidadImpresiones", (Convert.ToInt16(row.Cells["Cantidad Impresiones"].Value)+1));
                        dataUtilities.UpdateRecordByPrimaryKey("OrdenDetalleHistorial", row.Cells["Clave"].Value);
                        dataUtilities.ClearParameters();
                    }

                    // Línea separadora entre grupos de fecha
                    e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
                    yPosition += 5;
                }
                Buscar();
            }

            // ----------------------------------------------------------------
            // Pie de página
            // ----------------------------------------------------------------
            string agradecimiento = "Gracias por su preferencia";
            SizeF agradecimientoSize = e.Graphics.MeasureString(agradecimiento, regularFont, (int)availableWidth);
            e.Graphics.DrawString(agradecimiento, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, agradecimientoSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += agradecimientoSize.Height + 5;

            e.HasMorePages = false;
        }


    }
}
