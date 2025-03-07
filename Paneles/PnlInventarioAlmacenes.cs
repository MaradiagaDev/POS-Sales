using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Document = iTextSharp.text.Document;

namespace NeoCobranza.Paneles
{
    public partial class PnlInventarioAlmacenes : Form
    {
        public VMInventarioAlmacenes vMInventarioAlmacenes = new VMInventarioAlmacenes();

        public PnlInventarioAlmacenes()
        {
            InitializeComponent();
        }

        private void PnlInventarioAlmacenes_Load(object sender, EventArgs e)
        {
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            UIUtilities.ConfigurarComboBox(CmbBuscarPor);
            UIUtilities.ConfigurarComboBox(CmbAlmacenes);

            vMInventarioAlmacenes.InitModuloInventarioAlmacenes(this);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMInventarioAlmacenes.BuscarInventario();
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vMInventarioAlmacenes.BuscarInventario();
        }

        private void CmbAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vMInventarioAlmacenes.BuscarInventario();
        }


        private void BtnListaMermas_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 42))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CmbAlmacenes.Items.Count == 0)
            {
                MessageBox.Show("Para ver la lista de mermas debe haber almacenes en catalogos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ListaMermas frm = new ListaMermas(Convert.ToString(CmbAlmacenes.SelectedValue));
                frm.ShowDialog();
                vMInventarioAlmacenes.BuscarInventario();
            }
        }

     
        private void especialButton1_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 43))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vMInventarioAlmacenes.dynamicDataTableProductos.Rows.Clear();

            // Limpiar parámetros previos y configurar los nuevos para la búsqueda de productos con paginación.
            vMInventarioAlmacenes.dataUtilities.ClearParameters();
            vMInventarioAlmacenes.dataUtilities.SetParameter("@AlmacenId", CmbAlmacenes.SelectedValue);
            vMInventarioAlmacenes.dataUtilities.SetParameter("@CategoriaId", CmbBuscarPor.SelectedValue);
            vMInventarioAlmacenes.dataUtilities.SetParameter("@Filtro", TxtFiltrar.Text);

            DataTable dtResponseSp1 = vMInventarioAlmacenes.dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacenReportes");

            foreach (DataRow row in dtResponseSp1.Rows)
            {
                vMInventarioAlmacenes.dynamicDataTableProductos.Rows.Add(
                    Convert.ToString(row["ID"]),
                    Convert.ToString(row["PRODUCTO"]),
                    Convert.ToString(row["PRECIO (NIO)"]),
                    Convert.ToString(row["EXISTENCIA"]),
                    Convert.ToString(row["Descripcion"])
                );
            }

            // Ruta donde se guardará el PDF
            string fileName = $"InventarioAlmacen{DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(".", "").Replace(":", "")}{Utilidades.Sucursal}.pdf";
            string filePath = Path.Combine(Application.StartupPath, fileName);


            // Crear el documento
            Document doc = new Document();

            try
            {
                // Crear el escritor PDF
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                writer.PageEvent = new HeaderFooterEvents(); // Agrega el evento HeaderFooterEvents al escritor PDF

                // Establecer márgenes
                doc.SetMargins(40, 40, 60, 110);

                // Abrir el documento para escribir
                doc.Open();

                DataUtilities dataUtilities = new DataUtilities();

                DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];

                if (dtEmpresa == null)
                {
                    MessageBox.Show("Debe agregar los datos de la empresa primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                iTextSharp.text.Paragraph tituloGrandeGrande = new iTextSharp.text.Paragraph($"Informe Inventario Almacén - SysAdmin", FontFactory.GetFont("Century Gothic", "", true, 14, 1, BaseColor.BLACK));
                tituloGrandeGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrandeGrande);

                // Crear un primer título grande con letra Century Gothic
                iTextSharp.text.Paragraph tituloGrande = new iTextSharp.text.Paragraph($"EMPRESA: {Convert.ToString(dtEmpresa["NombreComercial"])}", FontFactory.GetFont("Century Gothic", "", true, 12, 1, BaseColor.BLUE));
                tituloGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrande);

                // Crear un segundo título más pequeño
                iTextSharp.text.Paragraph tituloPequeno = new iTextSharp.text.Paragraph($"Almacén: {CmbAlmacenes.Text}  / Tipo Producto: {CmbBuscarPor.Text}", FontFactory.GetFont("Century Gothic", 10));
                tituloPequeno.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloPequeno);

                // Añadir un espacio en blanco después de los títulos
                doc.Add(new iTextSharp.text.Paragraph(" "));

                // Crear una tabla
                PdfPTable table = new PdfPTable(4); // Número de columnas

                table.DefaultCell.BorderColor = BaseColor.BLACK; // Color del borde
                table.DefaultCell.BorderWidth = 1; // Ancho del borde
                table.WidthPercentage = 100;
                var headerStyle = FontFactory.GetFont("Century Gothic", "", true, 8, 1, BaseColor.DARK_GRAY);

                table.AddCell(new PdfPCell(new Phrase(" ID ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Producto ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Precio ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Cantidad ", headerStyle)));

                foreach (DataRow row in vMInventarioAlmacenes.dynamicDataTableProductos.Rows)
                {
                    for (int i = 0; i <= 3; i++)
                    {

                        var blackListTextFont = FontFactory.GetFont("Century Gothic", "", true, 7, 0, BaseColor.BLACK);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(row[i]?.ToString() ?? "", blackListTextFont));
                        table.AddCell(pdfCell); // Agregar celda con texto
                    }
                }

                // Agregar la tabla al documento
                doc.Add(table);

                MessageBox.Show("PDF generado correctamente en: " + filePath, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el archivo PDF
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar el documento
                doc.Close();
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

        //private void btnExcel_Click(object sender, EventArgs e)
        //{
        //    Utilidades.ExportToExcel();
        //}

        private void BtnExcel_Click_1(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 43))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vMInventarioAlmacenes.dynamicDataTableProductos.Rows.Clear();

            // Limpiar parámetros previos y configurar los nuevos para la búsqueda de productos con paginación.
            vMInventarioAlmacenes.dataUtilities.ClearParameters();
            vMInventarioAlmacenes.dataUtilities.SetParameter("@AlmacenId", CmbAlmacenes.SelectedValue);
            vMInventarioAlmacenes.dataUtilities.SetParameter("@CategoriaId", CmbBuscarPor.SelectedValue);
            vMInventarioAlmacenes.dataUtilities.SetParameter("@Filtro", TxtFiltrar.Text);

            DataTable dtResponseSp1 = vMInventarioAlmacenes.dataUtilities.ExecuteStoredProcedure("sp_ObtenerCantidadProductoPorAlmacenReportes");

            foreach (DataRow row in dtResponseSp1.Rows)
            {
                vMInventarioAlmacenes.dynamicDataTableProductos.Rows.Add(
                    Convert.ToString(row["ID"]),
                    Convert.ToString(row["PRODUCTO"]),
                    Convert.ToString(row["PRECIO (NIO)"]),
                    Convert.ToString(row["EXISTENCIA"]),
                    Convert.ToString(row["Descripcion"])
                );
            }

            ExportarExcel();
        }

        public void ExportarExcel()
        {
            // Construir el nombre y ruta del archivo Excel
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"InventarioAlmacen{timestamp}{Utilidades.Sucursal}.xlsx";
            string filePath = Path.Combine(Application.StartupPath, fileName);

            // Crear la instancia de Excel
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel no está instalado o no se pudo iniciar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo libro y obtener la primera hoja
            Excel.Workbook wb = excelApp.Workbooks.Add();
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            int currentRow = 1;

            try
            {
                // 1. Título principal
                ws.Cells[currentRow, 1] = "Informe Inventario Almacén - SysAdmin";
                Excel.Range titleRange = ws.get_Range("A" + currentRow, "D" + currentRow);
                titleRange.Merge();
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.Font.Name = "Century Gothic";
                titleRange.Font.Size = 14;
                titleRange.Font.Bold = true;
                currentRow++;

                // 2. Datos de la Empresa (se usa la misma lógica que en el PDF)
                DataUtilities dataUtilities = new DataUtilities();
                DataRow dtEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];
                if (dtEmpresa == null)
                {
                    MessageBox.Show("Debe agregar los datos de la empresa primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    wb.Close(false);
                    excelApp.Quit();
                    return;
                }
                string nombreEmpresa = Convert.ToString(dtEmpresa["NombreComercial"]);
                ws.Cells[currentRow, 1] = "EMPRESA: " + nombreEmpresa;
                Excel.Range companyRange = ws.get_Range("A" + currentRow, "D" + currentRow);
                companyRange.Merge();
                companyRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                companyRange.Font.Name = "Century Gothic";
                companyRange.Font.Size = 12;
                companyRange.Font.Bold = true;
                companyRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                currentRow++;

                // 3. Información adicional (Almacén y Tipo Producto)
                ws.Cells[currentRow, 1] = "Almacén: " + CmbAlmacenes.Text + "  /  Tipo Producto: " + CmbBuscarPor.Text;
                Excel.Range infoRange = ws.get_Range("A" + currentRow, "D" + currentRow);
                infoRange.Merge();
                infoRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                infoRange.Font.Name = "Century Gothic";
                infoRange.Font.Size = 10;
                currentRow += 2; // Espacio adicional

                // 4. Encabezados de la tabla
                ws.Cells[currentRow, 1] = "ID";
                ws.Cells[currentRow, 2] = "Producto";
                ws.Cells[currentRow, 3] = "Precio";
                ws.Cells[currentRow, 4] = "Cantidad";
                Excel.Range headerRange = ws.get_Range("A" + currentRow, "D" + currentRow);
                headerRange.Font.Name = "Century Gothic";
                headerRange.Font.Size = 8;
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                currentRow++;

                // 5. Agregar los datos de la DataGridView (dgvCatalogo)
                foreach (DataRow row in vMInventarioAlmacenes.dynamicDataTableProductos.Rows)
                {
                    /*if (row.RowState == DataRowState.Added) continue;*/ // Omitir la fila de nueva entrada

                    // Se recorren las columnas 1 a 4 (siguiendo la lógica de tu código de PDF)
                    for (int i = 0; i <= 3; i++)
                    {
                        object cellValue = row[i];
                        string text = cellValue != null ? cellValue.ToString() : "";
                        ws.Cells[currentRow, i+1] = text;
                    }
                    currentRow++;
                }

                // Autoajustar el ancho de las columnas
                Excel.Range usedRange = ws.UsedRange;
                usedRange.Columns.AutoFit();

                // Guardar el archivo Excel
                wb.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook);
                MessageBox.Show("Excel generado correctamente en: " + filePath, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar y liberar recursos
                wb.Close(false);
                excelApp.Quit();

                // Liberar objetos COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        private void flowLayoutPanelProductos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) && currentPage > 1)
            {
                currentPage--;
                TxtPaginaNo.Text = currentPage.ToString();
                vMInventarioAlmacenes.BuscarInventario();
                ActualizarEstadoBotones();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            // Se compara con el total de páginas que se muestra en TxtPaginaDe
            if (int.TryParse(TxtPaginaNo.Text, out int currentPage) &&
                int.TryParse(TxtPaginaDe.Text, out int totalPages) &&
                currentPage < totalPages)
            {
                currentPage++;
                TxtPaginaNo.Text = currentPage.ToString();
                vMInventarioAlmacenes.BuscarInventario();
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
    }
}
