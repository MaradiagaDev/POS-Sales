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
    public partial class PnlComandaVenta : Form
    {
        string auxOrden;
        string auxSucursal;
        DataUtilities dataUtilities = new DataUtilities();
        DataTable dynamicDataTable;

        public PnlComandaVenta(string Orden, string sucursalId)
        {
            InitializeComponent();
            auxOrden = Orden;
            auxSucursal = sucursalId;
        }

        private void PnlComandaVenta_Load(object sender, EventArgs e)
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


            dataUtilities.SetParameter("@OrdenId", auxOrden);
            dataUtilities.SetParameter("@SucursalId", auxSucursal);
            DataTable dtDetalle = dataUtilities.ExecuteStoredProcedure("sp_GetHistorialProductosComanda");

            foreach (DataRow item in dtDetalle.Rows)
            {
                // Se agrega la fila con el CheckBox en false por defecto
                dynamicDataTable.Rows.Add(
                    false,  // Valor inicial del CheckBox
                    Convert.ToString(item["HistorialId"]),
                    Convert.ToString(item["NombreProducto"]));
            }

            // Asignar la tabla al DataGridView
            DgvItemsOrden.DataSource = dynamicDataTable;

            // Opcional: ajustar la columna de CheckBox si es necesario
            DgvItemsOrden.Columns["Seleccionar"].ReadOnly = false;
            DgvItemsOrden.Columns["Seleccionar"].Width = 50;
            DgvItemsOrden.Columns["Clave"].Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
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
            doc.PrintPage += (s, a) => imprimeTicketComanda(s, a, ticketSize);

            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
        }

        private void imprimeTicketComanda(object sender, PrintPageEventArgs e, int ticketSize)
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
            Pen dottedPen = new Pen(System.Drawing.Color.Black);
            dottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            float yPosition = 20; // Posición vertical inicial

            // ----------------------------------------------------------------
            // CABECERA: Datos de la empresa y de la orden (igual que en la factura)
            // ----------------------------------------------------------------
            DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];
            dataUtilities.SetParameter("@OrdenId", auxOrden);
            dataUtilities.SetParameter("@sucursarlId", auxSucursal);
            DataTable dtResponseOrden = dataUtilities.ExecuteStoredProcedure("vwFacturaTicket");
            
            // Título del ticket
            string headerText = "COMANDA A COCINA";
            SizeF headerSize = e.Graphics.MeasureString(headerText, titleFont, (int)availableWidth);
            e.Graphics.DrawString(headerText, titleFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, headerSize.Height),
                new StringFormat { Alignment = StringAlignment.Center });
            yPosition += headerSize.Height + 5;

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

            string salaMesa = "Sala-Mesa: "+Convert.ToString(dtResponseOrden.Rows[0]["SalaMesa"]);
            SizeF SalaMesaSize = e.Graphics.MeasureString(salaMesa, regularFont, (int)availableWidth);
            e.Graphics.DrawString(salaMesa, regularFont, Brushes.Black,
                new RectangleF(marginLeft, yPosition, availableWidth, SalaMesaSize.Height));
            yPosition += SalaMesaSize.Height + 5;

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
            .Where(r => r.Cells["Clave"].Value != null)
            .GroupBy(r => Convert.ToString(r.Cells["Clave"].Value))
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
                    // Recorrer cada ítem del grupo
                    foreach (DataGridViewRow row in group)
                    {
                        string producto = Convert.ToString(row.Cells["Producto"].Value);

                        string idHistorial = Convert.ToString(row.Cells["Clave"].Value);

                        // Imprimir el nombre del producto (permitiendo wrap)
                        RectangleF prodRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                        SizeF prodSize = e.Graphics.MeasureString(producto, boldFont, (int)availableWidth);
                        prodRect.Height = prodSize.Height;
                        e.Graphics.DrawString(producto, boldFont, Brushes.Black, prodRect);
                        yPosition += prodSize.Height;

                        //// Imprimir detalle: cantidad, precio unitario y subtotal
                        //string detail = $"Cant: {cantidad}  P.U.: {precio}  Sub: {subTotal}";
                        //RectangleF detailRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                        //SizeF detailSize = e.Graphics.MeasureString(detail, smallerFont, (int)availableWidth);
                        //detailRect.Height = detailSize.Height;
                        //e.Graphics.DrawString(detail, smallerFont, Brushes.Black, detailRect);
                        //yPosition += detailSize.Height + 5;

     
                        dataUtilities.SetParameter("@HistorialId", idHistorial);
                        DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("spConsultarPorProductos");

                        foreach(DataRow item in dtResponse.Rows) 
                        {
                            // Imprimir los detalles adicionales con el formato que desees
                            RectangleF additionalRect = new RectangleF(marginLeft, yPosition, availableWidth, 1000);
                            SizeF additionalSize = e.Graphics.MeasureString("- " + item[0].ToString(), regularFont, (int)availableWidth);
                            additionalRect.Height = additionalSize.Height;
                            e.Graphics.DrawString("- "+item[0].ToString(), regularFont, Brushes.Black, additionalRect);
                            yPosition += additionalSize.Height + 2;
                        }

                        dataUtilities.SetColumns("FechaHoraComanda", DateTime.Now);
                        dataUtilities.UpdateRecordByPrimaryKey("OrdenDetalleHistorial", row.Cells["Clave"].Value);
                        dataUtilities.ClearParameters();
                    }

                    // Línea separadora entre grupos de fecha
                    e.Graphics.DrawLine(dottedPen, marginLeft, yPosition, pageWidth - marginRight, yPosition);
                    yPosition += 5;
                }


            }

            this.Close();
            e.HasMorePages = false;
        }
    }
}
