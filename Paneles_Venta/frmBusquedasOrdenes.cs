using NeoCobranza.ModelsCobranza;
using NeoCobranza.Paneles;
using NeoCobranza.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace NeoCobranza.Paneles_Venta
{
    public partial class frmBusquedasOrdenes : Form
    {
        DataUtilities dataUtilities = new DataUtilities();
        PnlPrincipal auxPnlPrincipal = null;
        string auxOpc = "";
        public DataTable dynamicDataTableOrdenes = new DataTable();
        private int currentPage = 1;
        private int totalPages = 1;
        private const int pageSize = 20;
        private bool EsCredito = false;
        private decimal colocado = 0;
        private decimal pagado = 0;
        private decimal restante = 0;
        private bool EsPagada = false;
        private bool _formCargado = false;



        public frmBusquedasOrdenes(PnlPrincipal pnlPrincipal, string opc)
        {
            InitializeComponent();

            auxPnlPrincipal = pnlPrincipal;
            auxOpc = opc;

            ConfigUI();
        }

        private void ConfigUI()
        {
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(1);

            // Asignar las fechas a los DateTimePicker
            DtInicio.Value = fechaInicio;
            DtFin.Value = fechaFin;

            UIUtilities.PersonalizarDataGridView(dgvCatalogoOrdenes);

            CmbBuscarPor.SelectedIndex = 0;
            CmbFiltrarFecha.SelectedIndex = 0;

            // Obtiene todos los registros de la tabla Sucursal
            DataTable dtResponseSucursales = dataUtilities.GetAllRecords("Sucursal");

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSucursales = from row in dtResponseSucursales.AsEnumerable()
                                      where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                                      select row;
            // Configura el DataSource del combo box
            CmbSucursal.ValueMember = "IdSucursal";
            CmbSucursal.DisplayMember = "NombreSucursal";
            CmbSucursal.DataSource = filterRowSucursales.CopyToDataTable();

            CmbSucursal.SelectedValue = Utilidades.SucursalId;

            switch (auxOpc)
            {
                case "Lista":
                    EsCredito = false;
                    llbTitulo.Text = "Lista de Ventas Activas";
                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();
                    dgvCatalogoOrdenes.DataSource = null;

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Factura", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));

                        DataGridViewButtonColumn buttonColumnSeleccionar = new DataGridViewButtonColumn();
                        buttonColumnSeleccionar.HeaderText = "...";
                        buttonColumnSeleccionar.Text = " Abrir Orden ";
                        buttonColumnSeleccionar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnSeleccionar);

                        DataGridViewButtonColumn buttonColumnCancelar = new DataGridViewButtonColumn();
                        buttonColumnCancelar.HeaderText = "...";
                        buttonColumnCancelar.Text = " Cancelar ";
                        buttonColumnCancelar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnCancelar);
                        dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    }
                    break;

                case "ListaCredito":
                    EsCredito = true;
                    llbTitulo.Text = "Cuentas Por Cobrar";

                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Factura", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha del Próximo Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cantidad de Pagos", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Frecuencia de Pago", typeof(string));

                        DataGridViewButtonColumn buttonColumnSeleccionar = new DataGridViewButtonColumn();
                        buttonColumnSeleccionar.HeaderText = "...";
                        buttonColumnSeleccionar.Text = " Abrir Orden ";
                        buttonColumnSeleccionar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnSeleccionar);

                        DataGridViewButtonColumn buttonColumnCancelar = new DataGridViewButtonColumn();
                        buttonColumnCancelar.HeaderText = "...";
                        buttonColumnCancelar.Text = " Cancelar ";
                        buttonColumnCancelar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnCancelar);
                        dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    }

                    break;

                case "ListaPagadas":
                    EsPagada = true;
                    llbTitulo.Text = "Lista de Ventas Pagadas";
                    dynamicDataTableOrdenes.Columns.Clear();
                    dynamicDataTableOrdenes.Rows.Clear();
                    dgvCatalogoOrdenes.Columns.Clear();
                    dgvCatalogoOrdenes.DataSource = null;

                    if (dgvCatalogoOrdenes.Columns.Count == 0)
                    {
                        dynamicDataTableOrdenes.Columns.Add("No Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Factura", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente Id", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Cliente", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Fecha", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Orden", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Estado Pago", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Total", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Pagado", typeof(string));
                        dynamicDataTableOrdenes.Columns.Add("Restante", typeof(string));

                        DataGridViewButtonColumn buttonColumnSeleccionar = new DataGridViewButtonColumn();
                        buttonColumnSeleccionar.HeaderText = "...";
                        buttonColumnSeleccionar.Text = " Abrir Orden ";
                        buttonColumnSeleccionar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnSeleccionar);

                        DataGridViewButtonColumn buttonColumnCancelar = new DataGridViewButtonColumn();
                        buttonColumnCancelar.HeaderText = "...";
                        buttonColumnCancelar.Text = " Cancelar ";
                        buttonColumnCancelar.UseColumnTextForButtonValue = true;

                        dgvCatalogoOrdenes.Columns.Add(buttonColumnCancelar);
                        dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;
                    }
                    break;
            }

            FuncionesPrincipales();
        }

        private void FuncionesPrincipales()
        {
            colocado = 0;
            pagado = 0;
            restante = 0;

            dynamicDataTableOrdenes.Rows.Clear();

            string segmentacion = "0";

            if (!string.IsNullOrEmpty(Convert.ToString(CmbSegmentacion.SelectedValue)))
            {
                segmentacion = Convert.ToString(CmbSegmentacion.SelectedValue);
            }


            // Parámetros comunes
            dataUtilities.SetParameter("@idSucursal", CmbSucursal.SelectedValue);
            dataUtilities.SetParameter("@filtro", TxtFiltrar.Texts);
            dataUtilities.SetParameter("@startDate", DtInicio.Value.Date);
            dataUtilities.SetParameter("@endDate", DtFin.Value.Date);
            dataUtilities.SetParameter("@pageNumber", currentPage);
            dataUtilities.SetParameter("@pageSize", pageSize);
            dataUtilities.SetParameter("@bitEsCredito", EsCredito);
            dataUtilities.SetParameter("@bitEsPagada", EsPagada);
            dataUtilities.SetParameter("@OpcBuscador", CmbBuscarPor.SelectedIndex);
            dataUtilities.SetParameter("@OpcFecha", CmbFiltrarFecha.SelectedIndex);
            dataUtilities.SetParameter("@segmentacion", segmentacion);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesCreditoPorSucursal");

            switch (auxOpc)
            {
                case "Lista":
                    foreach (DataRow orden in dtResponse.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(
                            Convert.ToString(orden["OrdenId"]),
                            Convert.ToString(orden["NoFactura"]),
                            Convert.ToString(orden["ClienteId"]),
                            Convert.ToString(orden["NombreCliente"]),
                            Convert.ToString(orden["FechaRealizacion"]),
                            Convert.ToString(orden["OrdenProceso"]),
                            Convert.ToString(orden["PagoProceso"]),
                            Convert.ToString(orden["TotalOrden"]),
                            Convert.ToString(orden["Pagado"]),
                            Convert.ToString(orden["RestantePago"])
                        );
                    }
                    break;

                case "ListaCredito":
                    

                    foreach (DataRow orden in dtResponse.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(
                            Convert.ToString(orden["OrdenId"]),
                            Convert.ToString(orden["NoFactura"]),
                            Convert.ToString(orden["ClienteId"]),
                            Convert.ToString(orden["NombreCliente"]),
                            Convert.ToString(orden["FechaRealizacion"]),
                            Convert.ToString(orden["OrdenProceso"]),
                            Convert.ToString(orden["PagoProceso"]),
                            Convert.ToString(orden["TotalOrden"]),
                            Convert.ToString(orden["Pagado"]),
                            Convert.ToString(orden["RestantePago"]),
                            Convert.ToString(orden["FechaCredito"]),
                            Convert.ToString(orden["CantidadPagos"]),
                            Convert.ToString(orden["FrecuenciaPagos"])
                        );
                    }
                    break;

                case "ListaPagadas":
                    foreach (DataRow orden in dtResponse.Rows)
                    {
                        dynamicDataTableOrdenes.Rows.Add(
                            Convert.ToString(orden["OrdenId"]),
                            Convert.ToString(orden["NoFactura"]),
                            Convert.ToString(orden["ClienteId"]),
                            Convert.ToString(orden["NombreCliente"]),
                            Convert.ToString(orden["FechaRealizacion"]),
                            Convert.ToString(orden["OrdenProceso"]),
                            Convert.ToString(orden["PagoProceso"]),
                            Convert.ToString(orden["TotalOrden"]),
                            Convert.ToString(orden["Pagado"]),
                            Convert.ToString(orden["RestantePago"])
                        );
                    }
                    break;

                default:
                    MessageBox.Show("Opción no válida.");
                    return;
            }

            if(dtResponse.Rows.Count > 0)
            {
                totalPages = dtResponse.Rows[dtResponse.Rows.Count-1]["TotalPages"] == null ? 0 : Convert.ToInt16(dtResponse.Rows[0]["TotalPages"]);
                colocado = dtResponse.Rows[dtResponse.Rows.Count - 1]["TotalSumaTotalOrden"] == null ? 0 : Convert.ToDecimal(dtResponse.Rows[0]["TotalSumaTotalOrden"]);
                pagado = dtResponse.Rows[dtResponse.Rows.Count - 1]["TotalSumaPagado"] == null ? 0 : Convert.ToDecimal(dtResponse.Rows[0]["TotalSumaPagado"]);
                restante = dtResponse.Rows[dtResponse.Rows.Count - 1]["TotalSumaRestante"] == null ? 0 : Convert.ToDecimal(dtResponse.Rows[0]["TotalSumaRestante"]);
            }

            // Llenar la tabla con los resultados de la consulta
            TxtColocado.Text = colocado.ToString() + "C$";
            TxtRecuperado.Text = pagado.ToString() + "C$";
            TxtRestante.Text = restante.ToString() + "C$";

            dgvCatalogoOrdenes.DataSource = dynamicDataTableOrdenes;

            // Actualizar información de paginación
            UpdatePaginationInfo();
        }
        private void UpdatePaginationInfo()
        {
            TxtPaginaNo.Text = currentPage.ToString();
            TxtPaginaDe.Text = totalPages.ToString();

            BtnAnterior.Enabled = currentPage > 1;
            BtnSiguiente.Enabled = currentPage < totalPages;
        }


        private void dgvCatalogoOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                auxPnlPrincipal.AbrirVenta(Decimal.Parse(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString()));
            }
            else if (e.ColumnIndex == 1)
            {
                PnlCancelarOrden pnlCancelarOrden = new PnlCancelarOrden(dgvCatalogoOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString(), null);
                pnlCancelarOrden.ShowDialog();
            }
        }

        private void especialButton2_Click(object sender, EventArgs e)
        {
            FuncionesPrincipales();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                FuncionesPrincipales();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                FuncionesPrincipales();
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 73))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarExcel();
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            if (!Utilidades.PermisosLevel(3, 73))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta acción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataUtilities.SetParameter("@idSucursal", CmbSucursal.SelectedValue);
            dataUtilities.SetParameter("@filtro", TxtFiltrar.Texts);
            dataUtilities.SetParameter("@startDate", DtInicio.Value.Date);
            dataUtilities.SetParameter("@endDate", DtFin.Value.Date);
            dataUtilities.SetParameter("@bitEsCredito", EsCredito);
            dataUtilities.SetParameter("@bitEsPagada", EsPagada);
            dataUtilities.SetParameter("@OpcBuscador", CmbBuscarPor.SelectedIndex);
            dataUtilities.SetParameter("@OpcFecha", CmbFiltrarFecha.SelectedIndex);
            dataUtilities.SetParameter("@segmentacion", CmbSegmentacion.SelectedValue);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesNormalesPorSucursal1");


            // Ruta donde se guardará el PDF
            string fileName = $"ListasNotas{DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(".", "").Replace(":", "")}{Utilidades.Sucursal}.pdf";
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

                if (auxOpc == "Lista")
                {
                    iTextSharp.text.Paragraph tituloGrandeGrande = new iTextSharp.text.Paragraph($"Lista de Notas Activas - SysAdmin", FontFactory.GetFont("Century Gothic", "", true, 14, 1, BaseColor.BLACK));
                    tituloGrandeGrande.Alignment = Element.ALIGN_CENTER;
                    doc.Add(tituloGrandeGrande);
                }
                else if (auxOpc == "ListaPagadas")
                {
                    iTextSharp.text.Paragraph tituloGrandeGrande = new iTextSharp.text.Paragraph($"Lista de Notas Totalmente Pagadas - SysAdmin", FontFactory.GetFont("Century Gothic", "", true, 14, 1, BaseColor.BLACK));
                    tituloGrandeGrande.Alignment = Element.ALIGN_CENTER;
                    doc.Add(tituloGrandeGrande);
                }
                else if (auxOpc == "ListaCredito")
                {
                    iTextSharp.text.Paragraph tituloGrandeGrande = new iTextSharp.text.Paragraph($"Lista de Cuentas Por Cobrar - SysAdmin", FontFactory.GetFont("Century Gothic", "", true, 14, 1, BaseColor.BLACK));
                    tituloGrandeGrande.Alignment = Element.ALIGN_CENTER;
                    doc.Add(tituloGrandeGrande);
                }

                // Crear un primer título grande con letra Century Gothic
                iTextSharp.text.Paragraph tituloGrande = new iTextSharp.text.Paragraph($"EMPRESA: {Convert.ToString(dtEmpresa["NombreComercial"])} / Sucursal: "+CmbSucursal.Text, FontFactory.GetFont("Century Gothic", "", true, 12, 1, BaseColor.BLUE));
                tituloGrande.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloGrande);

                // Crear un segundo título más pequeño
                iTextSharp.text.Paragraph tituloPequeno = new iTextSharp.text.Paragraph($"Colocado: " + TxtColocado.Text + " / Recuperado: " + TxtRecuperado.Text + " / Restante: " +TxtRestante.Text, FontFactory.GetFont("Century Gothic", 10));
                tituloPequeno.Alignment = Element.ALIGN_CENTER;
                doc.Add(tituloPequeno);

                // Añadir un espacio en blanco después de los títulos
                doc.Add(new iTextSharp.text.Paragraph(" "));

                // Crear una tabla
               

                if (auxOpc == "ListaCredito")
                {
                    PdfPTable table = new PdfPTable(13); // Número de columnas
                    table.DefaultCell.BorderColor = BaseColor.BLACK; // Color del borde
                    table.DefaultCell.BorderWidth = 1; // Ancho del borde
                    table.WidthPercentage = 100;
                    var headerStyle = FontFactory.GetFont("Century Gothic", "", true, 6.5f, 1, BaseColor.DARK_GRAY);

                    table.AddCell(new PdfPCell(new Phrase(" NoOrden ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Factura ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Clave ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Cliente ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Creación ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Estado Orden ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Estado Pago ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Total ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Pagado ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Restante ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Fecha Pago ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Cantidad Pagos ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Frecuencia ", headerStyle)));

                    foreach (DataRow row in dtResponse.Rows)
                    {
                        for (int i = 0; i <= 12; i++)
                        {

                            var blackListTextFont = FontFactory.GetFont("Century Gothic", "", true, 7, 0, BaseColor.BLACK);
                            PdfPCell pdfCell = new PdfPCell(new Phrase(row[i]?.ToString() ?? "", blackListTextFont));
                            table.AddCell(pdfCell); // Agregar celda con texto
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);
                }
                else
                {
                    PdfPTable table = new PdfPTable(10); // Número de columnas
                    table.DefaultCell.BorderColor = BaseColor.BLACK; // Color del borde
                    table.DefaultCell.BorderWidth = 1; // Ancho del borde
                    table.WidthPercentage = 100;
                    var headerStyle = FontFactory.GetFont("Century Gothic", "", true, 8, 1, BaseColor.DARK_GRAY);

                    table.AddCell(new PdfPCell(new Phrase(" NoOrden ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Factura ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Clave ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Cliente ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Creación ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Estado Orden ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Estado Pago ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Total ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Pagado ", headerStyle)));
                    table.AddCell(new PdfPCell(new Phrase(" Restante ", headerStyle)));
      

                    foreach (DataRow row in dtResponse.Rows)
                    {
                        for (int i = 0; i <= 9; i++)
                        {

                            var blackListTextFont = FontFactory.GetFont("Century Gothic", "", true, 7, 0, BaseColor.BLACK);
                            PdfPCell pdfCell = new PdfPCell(new Phrase(row[i]?.ToString() ?? "", blackListTextFont));
                            table.AddCell(pdfCell); // Agregar celda con texto
                        }
                    }

                    // Agregar la tabla al documento
                    doc.Add(table);
                }

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

        public void ExportarExcel()
        {
            dataUtilities.SetParameter("@idSucursal", CmbSucursal.SelectedValue);
            dataUtilities.SetParameter("@filtro", TxtFiltrar.Texts);
            dataUtilities.SetParameter("@startDate", DtInicio.Value.Date);
            dataUtilities.SetParameter("@endDate", DtFin.Value.Date);
            dataUtilities.SetParameter("@bitEsCredito", EsCredito);
            dataUtilities.SetParameter("@bitEsPagada", EsPagada);
            dataUtilities.SetParameter("@OpcBuscador", CmbBuscarPor.SelectedIndex);
            dataUtilities.SetParameter("@OpcFecha", CmbFiltrarFecha.SelectedIndex);
            dataUtilities.SetParameter("@segmentacion", CmbSegmentacion.SelectedValue);

            DataTable dtResponse = dataUtilities.ExecuteStoredProcedure("sp_ObtenerOrdenesNormalesPorSucursal1");

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
                if(auxOpc == "Lista")
                {
                    ws.Cells[currentRow, 1] = "Informe de Cuentas Activas - SysAdmin";
                }
                else if (auxOpc == "ListaPagadas")
                {
                    ws.Cells[currentRow, 1] = "Informe de Cuentas Totalmente Pagadas - SysAdmin";
                }
                else if(auxOpc == "ListaCredito")
                {
                    ws.Cells[currentRow, 1] = "Informe de Cuentas Por Cobrar - SysAdmin";
                }

                Excel.Range titleRange = ws.get_Range("A" + currentRow, "N" + currentRow);
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
                string nombreEmpresa = Convert.ToString(dtEmpresa["NombreComercial"])+" - "+CmbSucursal.Text;
                ws.Cells[currentRow, 1] = "EMPRESA: " + nombreEmpresa;
                Excel.Range companyRange = ws.get_Range("A" + currentRow, "N" + currentRow);
                companyRange.Merge();
                companyRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                companyRange.Font.Name = "Century Gothic";
                companyRange.Font.Size = 12;
                companyRange.Font.Bold = true;
                companyRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                currentRow++;

                // 3. Información adicional (Almacén y Tipo Producto)
                ws.Cells[currentRow, 1] = "Colocado: " + TxtColocado.Text + "  /  Recuperado: " + TxtRecuperado.Text + "  /  Restante: " +TxtRestante.Text;
                Excel.Range infoRange = ws.get_Range("A" + currentRow, "N" + currentRow);
                infoRange.Merge();
                infoRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                infoRange.Font.Name = "Century Gothic";
                infoRange.Font.Size = 10;
                currentRow += 2; // Espacio adicional

                if (auxOpc == "ListaCredito")
                {
                    //// 4. Encabezados de la tabla
                    ws.Cells[currentRow, 1] = "NoOrden";
                    ws.Cells[currentRow, 2] = "Factura";
                    ws.Cells[currentRow, 3] = "Clave";
                    ws.Cells[currentRow, 4] = "Cliente";
                    ws.Cells[currentRow, 5] = "Fecha Generación";
                    ws.Cells[currentRow, 6] = "Estado Orden";
                    ws.Cells[currentRow, 7] = "Estado Pago";
                    ws.Cells[currentRow, 8] = "Total";
                    ws.Cells[currentRow, 9] = "Pagado";
                    ws.Cells[currentRow, 10] = "Restante";
                    ws.Cells[currentRow, 11] = "Fecha de Pago";
                    ws.Cells[currentRow, 12] = "Cantidad de Pagos";
                    ws.Cells[currentRow, 13] = "Frecuencia de Pago";
                    Excel.Range headerRange = ws.get_Range("A" + currentRow, "N" + currentRow);
                    headerRange.Font.Name = "Century Gothic";
                    headerRange.Font.Size = 8;
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    currentRow++;

                    // 5. Agregar los datos de la DataGridView (dgvCatalogo)
                    foreach (DataRow row in dtResponse.Rows)
                    {
                        /*if (row.RowState == DataRowState.Added) continue;*/ // Omitir la fila de nueva entrada

                        // Se recorren las columnas 1 a 4 (siguiendo la lógica de tu código de PDF)
                        for (int i = 0; i <= 12; i++)
                        {
                            object cellValue = row[i];
                            string text = cellValue != null ? cellValue.ToString() : "";
                            ws.Cells[currentRow, i + 1] = text;
                        }
                        currentRow++;
                    }
                }
                else
                {
                    //// 4. Encabezados de la tabla
                    ws.Cells[currentRow, 1] = "NoOrden";
                    ws.Cells[currentRow, 2] = "Factura";
                    ws.Cells[currentRow, 4] = "Cliente";
                    ws.Cells[currentRow, 5] = "Fecha Generación";
                    ws.Cells[currentRow, 6] = "Estado Orden";
                    ws.Cells[currentRow, 7] = "Estado Pago";
                    ws.Cells[currentRow, 8] = "Total";
                    ws.Cells[currentRow, 9] = "Pagado";
                    ws.Cells[currentRow, 10] = "Restante";

                    Excel.Range headerRange = ws.get_Range("A" + currentRow, "N" + currentRow);
                    headerRange.Font.Name = "Century Gothic";
                    headerRange.Font.Size = 8;
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    currentRow++;

                    // 5. Agregar los datos de la DataGridView (dgvCatalogo)
                    foreach (DataRow row in dtResponse.Rows)
                    {
                        /*if (row.RowState == DataRowState.Added) continue;*/ // Omitir la fila de nueva entrada

                        // Se recorren las columnas 1 a 4 (siguiendo la lógica de tu código de PDF)
                        for (int i = 0; i <= 9; i++)
                        {
                            object cellValue = row[i];
                            string text = cellValue != null ? cellValue.ToString() : "";
                            ws.Cells[currentRow, i + 1] = text;
                        }
                        currentRow++;
                    }

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

        private void frmBusquedasOrdenes_Load(object sender, EventArgs e)
        {
            // Obtiene todos los registros de la tabla Sucursal
            DataTable dtResponseSegmentacion = dataUtilities.getRecordByColumn("SegmentacionCliente", "SucursalId", Utilidades.SucursalId);

            // Filtra las filas donde el campo Estado sea "Activo"
            var filterRowSeg = from row in dtResponseSegmentacion.AsEnumerable()
                               where Convert.ToString(row.Field<string>("Estado")) == "Activo"
                               select row;

            if (filterRowSeg.Any())
            {
                // Crea un DataTable para los datos filtrados
                DataTable dataCmbSucursal = new DataTable();
                dataCmbSucursal = filterRowSeg.CopyToDataTable();

                // Crea una nueva fila para "Mostrar Todo"
                DataRow newRow = dataCmbSucursal.NewRow();
                newRow["Clave"] = "0";
                newRow["Descripcion"] = "Sin Segmentación";

                // Inserta la nueva fila en la posición 0
                dataCmbSucursal.Rows.InsertAt(newRow, 0);

                // Configura el DataSource del combo box
                CmbSegmentacion.ValueMember = "Clave";
                CmbSegmentacion.DisplayMember = "Descripcion";
                CmbSegmentacion.DataSource = dataCmbSucursal;

                CmbSegmentacion.SelectedValue = "0";
            }

            _formCargado = true;
        }

        private void TxtFiltrar__TextChanged(object sender, EventArgs e)
        {
            if (_formCargado)
                FuncionesPrincipales();
        }

        private void CmbSegmentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formCargado)
                FuncionesPrincipales();
        }

        private void CmbFiltrarFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formCargado)
                FuncionesPrincipales();
        }

        private void CmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formCargado)
                FuncionesPrincipales();
        }

        private void CmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formCargado)
                FuncionesPrincipales();
        }

    }
}
