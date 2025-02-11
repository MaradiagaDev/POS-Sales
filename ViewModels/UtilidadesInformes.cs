using ClosedXML.Excel;
using NeoCobranza.ModelsCobranza;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NeoCobranza.ViewModels
{
    internal static class UtilidadesInformes
    {
        static DataUtilities dataUtilities = new DataUtilities();

        public static void CargarInformeVentas(string SucursalId, DateTime FechaInit, DateTime FechaFin)
        {

            try
            {
                //\\InformeEquiposTotales.xlsx"
                CultureInfo culturaEspañol = new CultureInfo("es-ES");

                string rutaProyecto = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
                string carpetaExcel = Path.Combine(rutaProyecto, "EXCELS PROGRAMA");

                if (!Directory.Exists(carpetaExcel))
                {
                    Directory.CreateDirectory(carpetaExcel);
                }

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteVentas.xlsx");

                //Nombre temporal 
                string tempFileName = "InformeEquiposTotales_" + DateTime.Now + ".xlsx";
                tempFileName = tempFileName.Replace("/", "-").Replace(":", ".");

                //Crear la nueva ruta de reportes
                string carpetaReportes = Path.Combine(carpetaExcel, "Reportes");

                string tempFileYearPath = $"{carpetaReportes}\\{DateTime.Now.Year}";
                string tempFileYearMonthPath = $"{carpetaReportes}\\{DateTime.Now.Year}\\{culturaEspañol.DateTimeFormat.GetMonthName(DateTime.Now.Month)}";

                if (!File.Exists(tempFileYearPath))
                {
                    DirectoryInfo Dif = new DirectoryInfo(tempFileYearPath);
                    Dif.Create();
                }

                if (!File.Exists(tempFileYearMonthPath))
                {
                    DirectoryInfo Dif = new DirectoryInfo(tempFileYearMonthPath);
                    Dif.Create();
                }

                string tempFilePath = Path.Combine(tempFileYearMonthPath, tempFileName);

                File.Copy(rutaArchivo, tempFilePath, true);

                //Llenar el Excel
                using (var workbook = new XLWorkbook(tempFilePath))
                {
                    var worksheet = workbook.Worksheet("Ventas");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("spReportOrdenes");

                    if (dataResponseOrdenes.Rows.Count == 0) 
                    { 
                        MessageBox.Show("No hay suficientes datos para crear el informe.","Atención",MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Serie").SetValue(Convert.ToString(item["Serie"]));
                        newRow.Field("NoFactura").SetValue(Convert.ToString(item["NoFactura"]));
                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));
                        newRow.Field("Fecha").SetValue(Convert.ToString(item["FechaRealizacion"]));
                        newRow.Field("Cliente").SetValue(Convert.ToString(item["Cliente"]));
                        newRow.Field("NoRuc").SetValue(Convert.ToString(item["Ruc"]));
                        newRow.Field("Empleado").SetValue(Convert.ToString(item["Empleado"]));
                        newRow.Field("Proceso").SetValue(Convert.ToString(item["OrdenProceso"]));
                        newRow.Field("SubTotal").SetValue(Convert.ToDecimal(item["SubTotal"]));
                        newRow.Field("Descuento").SetValue(Convert.ToDecimal(item["Descuento"]));
                        newRow.Field("Credito").SetValue(Convert.ToDecimal(item["MontoCredito"]));
                        newRow.Field("IVA").SetValue(Convert.ToDecimal(item["Iva"]));
                        newRow.Field("DGI(2%)").SetValue(Convert.ToDecimal(item["RetencionDgi"]));
                        newRow.Field("Alcaldia(1%)").SetValue(Convert.ToDecimal(item["RetencionAlcaldia"]));
                        newRow.Field("TotalColocado").SetValue(Convert.ToDecimal(item["TotalOrden"]));
                        newRow.Field("PagadoCliente").SetValue(Convert.ToDecimal(item["Pagado"]));
                        newRow.Field("Restante").SetValue(Convert.ToDecimal(item["Restante"]));
                    }

                    var rowToDelete = worksheet.Row(2);
                    rowToDelete.Delete();

                    //Detalles
                    var worksheetDetalle = workbook.Worksheet("Detalle");
                    var tableDetalle = worksheetDetalle.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenesDetalle = dataUtilities.ExecuteStoredProcedure("spReportOrdenesDetalle");

                    foreach (DataRow item in dataResponseOrdenesDetalle.Rows)
                    {
                        var newRow = tableDetalle.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));
                        newRow.Field("Producto").SetValue(Convert.ToString(item["NombreProducto"]));
                        newRow.Field("Cantidad").SetValue(Convert.ToDecimal(item["Cantidad"]));
                        newRow.Field("Precio").SetValue(Convert.ToDecimal(item["PrecioUnitario"]));
                        newRow.Field("SubTotal").SetValue(Convert.ToDecimal(item["Subtotal"]));
                    }
                    var rowToDeleteDetalle = worksheetDetalle.Row(2);
                    rowToDeleteDetalle.Delete();

                    //Pagos
                    var worksheetPagos = workbook.Worksheet("Pagos");
                    var tablepagos = worksheetPagos.Table(0); // Obtén la tabla en el índice 1

                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenesPagos = dataUtilities.ExecuteStoredProcedure("spReportOrdenesPagos");

                    foreach (DataRow item in dataResponseOrdenesPagos.Rows)
                    {
                        var newRow = tablepagos.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));
                        newRow.Field("TotalPagado").SetValue(Convert.ToString(item["Total"]));
                        newRow.Field("Pagado").SetValue(Convert.ToDecimal(item["Pagado"]));
                        newRow.Field("Cambio").SetValue(Convert.ToDecimal(item["Cambio"]));
                        newRow.Field("CobroTarjeta").SetValue(Convert.ToDecimal(item["MontoTarjeta"]));
                        newRow.Field("FormaPago").SetValue(Convert.ToString(item["FormaPago"]));
                        newRow.Field("Referencia").SetValue(Convert.ToString(item["NoReferencia"]));
                    }
                    var rowToDeletePago = worksheetPagos.Row(2);
                    rowToDeletePago.Delete();

                    // Guardar el archivo
                    workbook.SaveAs(tempFilePath);

                    workbook.Save();
                }

                Thread.Sleep(500);

                Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ah ocurrido un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
