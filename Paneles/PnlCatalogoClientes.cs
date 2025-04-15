using iTextSharp.text.pdf;
using iTextSharp.text;
using NeoCobranza.Clases;
using NeoCobranza.Data;
using NeoCobranza.DataController;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using iTextSharp.text.pdf.draw;
using Font = iTextSharp.text.Font;

namespace NeoCobranza.Paneles
{
    public partial class PnlCatalogoClientes : Form
    {
        VMCatalogoCliente vMCatalogoCliente = new VMCatalogoCliente();

        public PnlCatalogoClientes()
        {
            InitializeComponent();
        }

        private void PnlCatalogoClientes_Load(object sender, EventArgs e)
        {
            //Configuraciones UI
            UIUtilities.PersonalizarDataGridView(dgvCatalogoClientes);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarComboBox(CmbBuscarPor);
            UIUtilities.ConfigurarComboBox(CmbSucursal);
            UIUtilities.ConfigurarBotonCrear(btnAgregar);
            UIUtilities.ConfigurarBotonActualizar(btnActualizar);
            UIUtilities.ConfigurarBotonAnterior(BtnAnterior);
            UIUtilities.ConfigurarBotonSiguiente(BtnSiguiente);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            UIUtilities.ConfigurarComboBox(CmbSegmentacion);

            vMCatalogoCliente.InitModuloCatalogoClientes(this);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 1))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PanelModificarCliente frm = new PanelModificarCliente(this, "Crear",null);
            frm.ShowDialog();

            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 2))
            {
                MessageBox.Show( "Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCatalogoClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalogoClientes.SelectedRows[0];
                object cellValue = selectedRow.Cells[1].Value;

                if (cellValue != null)
                {
                    PanelModificarCliente frm = new PanelModificarCliente(this, cellValue.ToString(),null);
                    frm.ShowDialog();
                }

                vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
            }
            else
            {
                //Validaciones

                MessageBox.Show("Debe seleccionar un cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public class HeaderFooterEvents : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                // Fecha de Generación
                PdfPTable dateTable = new PdfPTable(1);
                dateTable.TotalWidth = 150f;
                dateTable.HorizontalAlignment = Element.ALIGN_LEFT;
                dateTable.DefaultCell.Border = 0;

                PdfPCell dateCell = new PdfPCell(new Phrase("Fecha de Generación: " + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 8)));
                dateCell.Border = 0;
                dateTable.AddCell(dateCell);

                dateTable.WriteSelectedRows(0, -1, 30, document.PageSize.Height - 30, writer.DirectContent);


                // Usuario
                PdfPTable userTable = new PdfPTable(1);
                userTable.TotalWidth = 150f;
                userTable.HorizontalAlignment = Element.ALIGN_LEFT;
                userTable.DefaultCell.Border = 0;


                PdfPCell userCell = new PdfPCell(new Phrase("Usuario: " + Utilidades.Usuario, FontFactory.GetFont("Arial", 8)));
                userCell.Border = 0;
                userTable.AddCell(userCell);
                userTable.WriteSelectedRows(0, -1, 30, document.PageSize.Height - 45, writer.DirectContent);



                // No. de Página
                PdfPTable pageNumTable = new PdfPTable(1);
                pageNumTable.TotalWidth = 100f;
                pageNumTable.HorizontalAlignment = Element.ALIGN_RIGHT;
                pageNumTable.DefaultCell.Border = 0;

                PdfPCell pageNumCell = new PdfPCell(new Phrase("No. Página: " + writer.PageNumber, FontFactory.GetFont("Arial", 8)));
                pageNumCell.Border = 0;
                pageNumTable.AddCell(pageNumCell);

                pageNumTable.WriteSelectedRows(0, -1, document.PageSize.Width - 130, document.PageSize.Height - 30, writer.DirectContent);
            }
        }

        private void dgvCatalogoClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 24))
            {
                MessageBox.Show( "Su usuario no tiene permisos para realizar esta acción.","Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                DataUtilities dataUtilities = new DataUtilities();

                // Obtener el ID del cliente desde el DataGridView
                object cellValue = dgvCatalogoClientes.Rows[e.RowIndex].Cells[1].Value;

                // Establecer parámetro para obtener las órdenes a crédito del cliente
                dataUtilities.SetParameter("@clienteId", cellValue.ToString());
                DataTable dtOrdenes = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesCreditoCliente");

                // Si no hay órdenes, mostrar mensaje y salir.
                if (dtOrdenes.Rows.Count == 0)
                {
                    MessageBox.Show("El cliente no tiene cuentas pendientes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Definir ruta y nombre del PDF
                string fileName = $"EstadoCuenta_{cellValue}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string filePath = Path.Combine(Application.StartupPath, fileName);

                // Crear documento PDF con márgenes personalizados
                Document doc = new Document(PageSize.A4, 50, 50, 80, 60);
                try
                {

                    DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];

                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    writer.PageEvent = new HeaderFooterEvents(); // Clase para cabecera y pie de página
                    doc.Open();

                    // --- TÍTULO PRINCIPAL ---
                    Paragraph title = new Paragraph("Estado de Cuentas del Cliente",
                        FontFactory.GetFont("Century Gothic", 18, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\n"));

                    // --- ENCABEZADO GENERAL ---
                    // Obtener datos generales
                    string nombreCliente = dtOrdenes.Rows[0]["Cliente"].ToString();
                    string empresa = Convert.ToString(dtEmpresa["NombreEmpresa"]);
                    string sucursal = CmbSucursal.Text;

                    PdfPTable headerTable = new PdfPTable(2);
                    headerTable.WidthPercentage = 100;
                    headerTable.SetWidths(new float[] { 50, 50 });

                    PdfPCell cellEmpresa = new PdfPCell(new Phrase($"Empresa: {empresa}\nSucursal: {sucursal}",
                        FontFactory.GetFont("Century Gothic", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                    cellEmpresa.Border = PdfPCell.NO_BORDER;
                    cellEmpresa.HorizontalAlignment = Element.ALIGN_LEFT;

                    PdfPCell cellCliente = new PdfPCell(new Phrase($"Cliente: {nombreCliente}",
                        FontFactory.GetFont("Century Gothic", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                    cellCliente.Border = PdfPCell.NO_BORDER;
                    cellCliente.HorizontalAlignment = Element.ALIGN_RIGHT;

                    headerTable.AddCell(cellEmpresa);
                    headerTable.AddCell(cellCliente);
                    doc.Add(headerTable);
                    doc.Add(new Paragraph("\n"));

                    // --- RECORRER ÓRDENES ---
                    foreach (DataRow orden in dtOrdenes.Rows)
                    {
                        // Datos de la orden
                        string noOrden = orden["NoOrden"].ToString();
                        string factura = orden["Factura"].ToString();
                        string fechaOrden = Convert.ToDateTime(orden["Creacion"]).ToString("dd/MM/yyyy");
                        decimal totalOrden = Convert.ToDecimal(orden["Total"]);

                        // Información de la orden en tabla (Orden, Factura, Fecha)
                        PdfPTable orderInfoTable = new PdfPTable(3);
                        orderInfoTable.WidthPercentage = 100;
                        orderInfoTable.SetWidths(new float[] { 30, 40, 30 });

                        PdfPCell cellNoOrden = new PdfPCell(new Phrase($"Orden: {noOrden}",
                            FontFactory.GetFont("Century Gothic", 10, iTextSharp.text.Font.BOLD, BaseColor.BLUE)));
                        cellNoOrden.Border = PdfPCell.NO_BORDER;
                        orderInfoTable.AddCell(cellNoOrden);

                        PdfPCell cellFactura = new PdfPCell(new Phrase($"Factura: {factura}",
                            FontFactory.GetFont("Century Gothic", 10, iTextSharp.text.Font.BOLD, BaseColor.BLUE)));
                        cellFactura.Border = PdfPCell.NO_BORDER;
                        cellFactura.HorizontalAlignment = Element.ALIGN_CENTER;
                        orderInfoTable.AddCell(cellFactura);

                        PdfPCell cellFecha = new PdfPCell(new Phrase($"Fecha: {fechaOrden}",
                            FontFactory.GetFont("Century Gothic", 10, iTextSharp.text.Font.BOLD, BaseColor.BLUE)));
                        cellFecha.Border = PdfPCell.NO_BORDER;
                        cellFecha.HorizontalAlignment = Element.ALIGN_RIGHT;
                        orderInfoTable.AddCell(cellFecha);

                        doc.Add(orderInfoTable);
                        doc.Add(new Paragraph("\n"));

                        // --- DETALLE DE PAGOS ---
                        Paragraph detalleTitulo = new Paragraph("Detalle de Pagos:",
                            FontFactory.GetFont("Century Gothic", 10, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY));
                        detalleTitulo.SpacingAfter = 5;
                        doc.Add(detalleTitulo);

                        // Obtener pagos de la orden
                        dataUtilities.ClearParameters();
                        dataUtilities.SetParameter("@ordenId", noOrden);
                        DataTable dtPagos = dataUtilities.ExecuteStoredProcedure("sp_ObtenerPagosPorOrden");

                        // Tabla para los pagos con encabezados
                        PdfPTable pagosTable = new PdfPTable(4);
                        pagosTable.WidthPercentage = 100;
                        pagosTable.SetWidths(new float[] { 20, 30, 25, 25 });
                        pagosTable.SpacingBefore = 5;
                        pagosTable.SpacingAfter = 5;

                        PdfPCell hPagoId = new PdfPCell(new Phrase("ID Pago",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                        hPagoId.BackgroundColor = BaseColor.GRAY;
                        hPagoId.HorizontalAlignment = Element.ALIGN_CENTER;
                        pagosTable.AddCell(hPagoId);

                        PdfPCell hFecha = new PdfPCell(new Phrase("Fecha",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                        hFecha.BackgroundColor = BaseColor.GRAY;
                        hFecha.HorizontalAlignment = Element.ALIGN_CENTER;
                        pagosTable.AddCell(hFecha);

                        PdfPCell hMonto = new PdfPCell(new Phrase("Monto",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                        hMonto.BackgroundColor = BaseColor.GRAY;
                        hMonto.HorizontalAlignment = Element.ALIGN_CENTER;
                        pagosTable.AddCell(hMonto);

                        PdfPCell hEstado = new PdfPCell(new Phrase("Estado",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE)));
                        hEstado.BackgroundColor = BaseColor.GRAY;
                        hEstado.HorizontalAlignment = Element.ALIGN_CENTER;
                        pagosTable.AddCell(hEstado);

                        decimal totalPagado = 0;
                        Font dataFont = FontFactory.GetFont("Century Gothic", 8, BaseColor.BLACK);
                        foreach (DataRow pago in dtPagos.Rows)
                        {
                            pagosTable.AddCell(new PdfPCell(new Phrase(pago["PagoId"]?.ToString() ?? "", dataFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER
                            });
                            pagosTable.AddCell(new PdfPCell(new Phrase(Convert.ToDateTime(pago["Fecha"]).ToString("dd/MM/yyyy"), dataFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER
                            });
                            decimal montoPago = Convert.ToDecimal(pago["Monto"]);
                            pagosTable.AddCell(new PdfPCell(new Phrase("C$ " + montoPago.ToString("N2"), dataFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER
                            });
                            pagosTable.AddCell(new PdfPCell(new Phrase(pago["Estado"]?.ToString() ?? "", dataFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER
                            });
                            totalPagado += montoPago;
                        }
                        doc.Add(pagosTable);

                        // --- RESUMEN DE LA ORDEN ---
                        decimal restante = totalOrden - totalPagado;
                        PdfPTable resumenTable = new PdfPTable(3);
                        resumenTable.WidthPercentage = 100;
                        resumenTable.SetWidths(new float[] { 33, 33, 34 });
                        resumenTable.SpacingBefore = 5;
                        resumenTable.SpacingAfter = 10;

                        PdfPCell cellTotal = new PdfPCell(new Phrase($"Total Orden: C$ {totalOrden:N2}",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY)));
                        cellTotal.Border = PdfPCell.NO_BORDER;
                        cellTotal.HorizontalAlignment = Element.ALIGN_CENTER;
                        resumenTable.AddCell(cellTotal);

                        PdfPCell cellPagado = new PdfPCell(new Phrase($"Pagado: C$ {totalPagado:N2}",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY)));
                        cellPagado.Border = PdfPCell.NO_BORDER;
                        cellPagado.HorizontalAlignment = Element.ALIGN_CENTER;
                        resumenTable.AddCell(cellPagado);

                        PdfPCell cellRestante = new PdfPCell(new Phrase($"Restante: C$ {restante:N2}",
                            FontFactory.GetFont("Century Gothic", 9, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY)));
                        cellRestante.Border = PdfPCell.NO_BORDER;
                        cellRestante.HorizontalAlignment = Element.ALIGN_CENTER;
                        resumenTable.AddCell(cellRestante);

                        doc.Add(resumenTable);

                        // Línea divisoria elegante
                        LineSeparator ls = new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, 5);
                        doc.Add(new Chunk(ls));
                        doc.Add(new Paragraph("\n"));
                    }

                    MessageBox.Show("PDF generado correctamente en: " + filePath, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                }
            }
        }



        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages) &&
                currentPage < totalPages)
            {
                currentPage++;
                TxtPaginaNo.Text = currentPage.ToString();
                vMCatalogoCliente.UpdatePagination(this);
                ActualizarEstadoBotones();
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                vMCatalogoCliente.UpdatePagination(this);
                ActualizarEstadoBotones();
            }
        }

        private void ActualizarEstadoBotones()
        {
            // Habilita o deshabilita según el número de página actual y el total de páginas
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages))
            {
                BtnAnterior.Enabled = currentPage > 1;
                BtnSiguiente.Enabled = currentPage < totalPages;
            }
        }

        private void CmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }

        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }

        private void CmbSegmentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            vMCatalogoCliente.FuncionesPrincipales(this, "Buscar");
        }
    }
}
