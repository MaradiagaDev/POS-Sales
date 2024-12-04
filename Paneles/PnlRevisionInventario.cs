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
using System.Security.Cryptography;

namespace NeoCobranza.Paneles
{
    public partial class  PnlRevisionInventario : Form
    {
        VMInventarioGeneral vMInventarioGeneral = new VMInventarioGeneral();
        private bool busquedaInicialRealizada = false;
        public PnlRevisionInventario()
        {
            InitializeComponent();
        }

        private void PnlRevisionInventario_Load(object sender, EventArgs e)
        {
            if (!busquedaInicialRealizada)
            {
                vMInventarioGeneral.InitPantallaRevision(this);
                busquedaInicialRealizada = true;
            }

            UIUtilities.PersonalizarDataGridView(dgvCatalogo);
            UIUtilities.EstablecerFondo(this);
            UIUtilities.ConfigurarBotonBuscar(BtnBuscarCliente);
            UIUtilities.ConfigurarTextBoxBuscar(TxtFiltrar);
            UIUtilities.ConfigurarTituloPantalla(TbTitulo, PnlTitulo);
            UIUtilities.ConfigurarComboBox(CmbBuscarPor);
            UIUtilities.ConfigurarComboBox(CmbSucursales);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            vMInventarioGeneral.BuscarInventario();
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busquedaInicialRealizada)
            {
                vMInventarioGeneral.BuscarInventario();
            }
        }

        private void CmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busquedaInicialRealizada)
            {
                vMInventarioGeneral.BuscarInventario();
            }
        }

        private void PnlRevisionInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                vMInventarioGeneral.BuscarInventario();
            }
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            // Ruta donde se guardará el PDF
            string fileName = $"InventarioGeneral{DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(".", "").Replace(":", "")}{Utilidades.Sucursal}.pdf";
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

                Empresa empresa = new Empresa();

                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    empresa = db.Empresa.FirstOrDefault();

                    if (empresa == null)
                    {
                        MessageBox.Show("Debe agregar los datos de la empresa primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                iTextSharp.text.Paragraph tituloGrandeGrande = new iTextSharp.text.Paragraph($"Informe Inventario General - SysAdmin", FontFactory.GetFont("Century Gothic", "", true, 14, 1, BaseColor.BLACK));
                tituloGrandeGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrandeGrande);

                // Crear un primer título grande con letra Century Gothic
                iTextSharp.text.Paragraph tituloGrande = new iTextSharp.text.Paragraph($"EMPRESA: {empresa.NombreComercial}", FontFactory.GetFont("Century Gothic", "", true, 12, 1, BaseColor.BLUE));
                tituloGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrande);

                // Crear un segundo título más pequeño
                iTextSharp.text.Paragraph tituloPequeno = new iTextSharp.text.Paragraph($"Sucursal: {CmbSucursales.Text}  / Tipo Producto: {CmbBuscarPor.Text}", FontFactory.GetFont("Century Gothic", 10));
                tituloPequeno.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloPequeno);

                // Añadir un espacio en blanco después de los títulos
                doc.Add(new iTextSharp.text.Paragraph(" "));

                // Crear una tabla
                PdfPTable table = new PdfPTable(5); // Número de columnas

                table.DefaultCell.BorderColor = BaseColor.BLACK; // Color del borde
                table.DefaultCell.BorderWidth = 1; // Ancho del borde
                table.WidthPercentage = 100;
                var headerStyle = FontFactory.GetFont("Century Gothic", "", true, 8, 1, BaseColor.DARK_GRAY);

                table.AddCell(new PdfPCell(new Phrase(" ID ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Producto ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Cantidad ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Cantidad Máxima ", headerStyle)));
                table.AddCell(new PdfPCell(new Phrase(" Cantidad Minima ", headerStyle)));

                foreach (DataGridViewRow row in dgvCatalogo.Rows)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var blackListTextFont = FontFactory.GetFont("Century Gothic", "", true, 7, 0, BaseColor.BLACK);
                        PdfPCell pdfCell = new PdfPCell(new Phrase(row.Cells[i].Value?.ToString() ?? "", blackListTextFont));
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

                using (NeoCobranzaContext db = new NeoCobranzaContext())
                {
                    ModelsCobranza.Usuario usuario = db.Usuario.Where(s => s.IdUsuarios == int.Parse(Utilidades.IdUsuario)).FirstOrDefault();

                    PdfPCell userCell = new PdfPCell(new Phrase("Usuario: " + usuario.Nombre, FontFactory.GetFont("Arial", 8)));
                    userCell.Border = 0;
                    userTable.AddCell(userCell);
                    userTable.WriteSelectedRows(0, -1, 30, document.PageSize.Height - 45, writer.DirectContent);
                }


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
