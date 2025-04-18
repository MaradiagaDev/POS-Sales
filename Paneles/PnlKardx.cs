﻿using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NeoCobranza.ViewModels;
using System.Diagnostics;
using NeoCobranza.ModelsCobranza;
using NeoCobranza.Clases;

namespace NeoCobranza.Paneles
{
    public partial class PnlKardx : Form
    {
        public DataTable dataTable = new DataTable();
        public PnlKardx()
        {
            InitializeComponent();
        }

        private void PnlKardx_Load(object sender, EventArgs e)
        {
            UIUtilities.PersonalizarDataGridView(DgvKardex);
            UIUtilities.EstablecerFondo(this);

            DgvKardex.DataSource = dataTable;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            PnlConfigurarKardex frm = new PnlConfigurarKardex(this);
            frm.ShowDialog();   
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            // Ruta donde se guardará el PDF
            string fileName = $"Kardex{DateTime.Now.ToString().Replace("/","").Replace(" ","").Replace(".","").Replace(":","")}{Utilidades.Sucursal}.pdf";
            string filePath = Path.Combine(Application.StartupPath, fileName);

            if(dataTable.Rows.Count == 0 )
            {
                MessageBox.Show("No hay datos para generar el reporte.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

                iTextSharp.text.Paragraph tituloGrandeGrande = new iTextSharp.text.Paragraph($"Informe Kardex - SysAdmin", FontFactory.GetFont("Century Gothic", "", true, 14, 1, BaseColor.BLACK));
                tituloGrandeGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrandeGrande);

                // Crear un primer título grande con letra Century Gothic
                iTextSharp.text.Paragraph tituloGrande = new iTextSharp.text.Paragraph($"EMPRESA: {Convert.ToString(dtEmpresa["NombreComercial"])}", FontFactory.GetFont("Century Gothic","",true, 12,1,BaseColor.BLUE));
                tituloGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrande);

                // Crear un segundo título más pequeño
                iTextSharp.text.Paragraph tituloPequeno = new iTextSharp.text.Paragraph($"Desde: {LblFechaInicial.Text} - Hasta: {LblFechaFinal.Text} Almacén: {LblAlmacen.Text} Producto: {LblProducto.Text}", FontFactory.GetFont("Century Gothic", 10));
                tituloPequeno.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloPequeno);

                // Añadir un espacio en blanco después de los títulos
                doc.Add(new iTextSharp.text.Paragraph(" "));

                // Crear una tabla
                PdfPTable table = new PdfPTable(12); // Número de columnas

                table.DefaultCell.BorderColor = BaseColor.BLACK; // Color del borde
                table.DefaultCell.BorderWidth = 1; // Ancho del borde
                table.WidthPercentage = 100;
                var headerStyle = FontFactory.GetFont("Century Gothic", "", true, 8, 1, BaseColor.DARK_GRAY);

                table.AddCell(new PdfPCell(new Phrase("Fecha", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("Id Documento", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("Operación", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("Unidades Entrada", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("C/U Entrada", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("C. Total Entrada", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("Unidades Salida", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("C/U Salida", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("C. Total Salida", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("Unidades Saldo", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("C/U Saldo", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase("C. Total Saldo", headerStyle)));

                // Agregar las filas y columnas a la tabla usando un bucle foreach
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        var blackListTextFont = FontFactory.GetFont("Century Gothic", "", true, 7, 0, BaseColor.BLACK);
                        PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), blackListTextFont));
                        table.AddCell(cell); // Agregar celda con texto
                    }
                }

                // Agregar la tabla al documento
                doc.Add(table);

                MessageBox.Show("PDF generado correctamente en: " + filePath, "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

    }
}
