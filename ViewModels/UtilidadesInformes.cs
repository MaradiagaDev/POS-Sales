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
                string tempFileName = $"InformeVentas_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
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

                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

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
                    if (worksheetPagos.RowsUsed().Count() > 1)
                    {
                        worksheetPagos.Row(2).Delete();
                    }

                    //OTROS INGRESOS
                    var worksheetOtrosIngresos = workbook.Worksheet("Otros Ingresos");
                    var tableOtrosIngreso = worksheetOtrosIngresos.Table(0); // Obtén la tabla en el índice 1

                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);
                    dataUtilities.SetParameter("@EsIngreso", true);

                    DataTable dataResponseOtrosIngresos = dataUtilities.ExecuteStoredProcedure("sp_ObtenerPagosPorFecha");

                    bool Ingresos = false;

                    foreach (DataRow item in dataResponseOtrosIngresos.Rows)
                    {
                        Ingresos = true;
                        var newRow = tableOtrosIngreso.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Fecha").SetValue(Convert.ToString(item["FechaPago"]));
                        newRow.Field("Total").SetValue(Convert.ToDecimal(item["Pagado"]));
                        newRow.Field("Referencia").SetValue(Convert.ToString(item["Referencia"]));
                    }

                    if (Ingresos)
                    {
                        worksheetOtrosIngresos.Row(2).Delete();
                    }

                    //OTROS GASTOS
                    var worksheetOtrosGastos = workbook.Worksheet("Otros Gastos");
                    var tableOtrosGastos = worksheetOtrosGastos.Table(0); // Obtén la tabla en el índice 1

                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);
                    dataUtilities.SetParameter("@EsIngreso", false);

                    DataTable dataResponseOtrosGastos = dataUtilities.ExecuteStoredProcedure("sp_ObtenerPagosPorFecha");

                    bool Gastos = false;

                    foreach (DataRow item in dataResponseOtrosGastos.Rows)
                    {
                        Gastos = true;

                        var newRow = tableOtrosGastos.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Fecha").SetValue(Convert.ToString(item["FechaPago"]));
                        newRow.Field("Total").SetValue(Convert.ToDecimal(item["Pagado"]));
                        newRow.Field("Referencia").SetValue(Convert.ToString(item["Referencia"]));
                    }

                    if (Gastos)
                    {
                        worksheetOtrosGastos.Row(2).Delete();
                    }

                    //COMPRAS
                    var worksheetCompras = workbook.Worksheet("Compras");
                    var tableCompras = worksheetCompras.Table(0); // Obtén la tabla en el índice 1

                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseCompras = dataUtilities.ExecuteStoredProcedure("sp_ObtenerComprasPorFecha");

                    bool Compras = false;

                    foreach (DataRow item in dataResponseCompras.Rows)
                    {
                        Compras = true;

                        var newRow = tableCompras.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Clave").SetValue(Convert.ToString(item["CompraId"]));
                        newRow.Field("Fecha").SetValue(Convert.ToString(item["FechaCompra"]));

                        // Si no se puede convertir a decimal, asigna 0
                        newRow.Field("Total C$").SetValue(decimal.TryParse(item["TotalCompra"]?.ToString(), out decimal totalCompra) ? totalCompra : 0);

                        newRow.Field("Descripción").SetValue(Convert.ToString(item["Descripcion"]));
                        newRow.Field("Almacén").SetValue(Convert.ToString(item["Almacen"]));
                        newRow.Field("Usuario").SetValue(Convert.ToString(item["Usuario"]));
                    }


                    if (Compras)
                    {
                        worksheetCompras.Row(2).Delete();
                    }

                    //DETALLES DE COMPRAS
                    var worksheetDetallesCompras = workbook.Worksheet("Detalle Compras");
                    var tableDetallesCompras = worksheetDetallesCompras.Table(0); // Obtén la tabla en el índice 1

                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseDetalleCompras = dataUtilities.ExecuteStoredProcedure("sp_ObtenerDetalleComprasPorFecha");

                    bool DetalleCompras = false;

                    foreach (DataRow item in dataResponseDetalleCompras.Rows)
                    {
                        DetalleCompras = true;

                        var newRow = tableDetallesCompras.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Clave").SetValue(Convert.ToString(item["CompraId"]));
                        newRow.Field("Producto").SetValue(Convert.ToString(item["NombreProducto"]));
                        newRow.Field("Cantidad").SetValue(Convert.ToDecimal(item["Cantidad"]));
                        newRow.Field("Costo Unitario").SetValue(Convert.ToDecimal(item["CostoU"]));
                        newRow.Field("SubTotal").SetValue(Convert.ToDecimal(item["SubTotal"]));
                    }

                    if (DetalleCompras)
                    {
                        worksheetDetallesCompras.Row(2).Delete();
                    }

                    //Datos Finales
                    var worksheetDetallesFinales = workbook.Worksheet("Presentación - Totales");

                    DataRow itemEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];

                    worksheetDetallesFinales.Cell("C1").Value = Convert.ToString(itemEmpresa["NombreEmpresa"]);
                    worksheetDetallesFinales.Cell("B2").Value = Utilidades.Sucursal;
                    worksheetDetallesFinales.Cell("F2").Value = FechaInit.ToShortDateString();
                    worksheetDetallesFinales.Cell("H2").Value = FechaFin.ToShortDateString();

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

        public static void CargarInformeVentasCredito(string SucursalId,DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteCuentasPorCobrar.xlsx");

                //Nombre temporal 
                string tempFileName = $"ReporteCuentasPorCobrar_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Cuentas de Credito");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("spReportOrdenesCredito");


                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Serie").SetValue(Convert.ToString(item["Serie"]));
                        newRow.Field("NoFactura").SetValue(Convert.ToString(item["NoFactura"]));
                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));
                        newRow.Field("CantidadPagosEsperados").SetValue(Convert.ToString(item["CantidadPagos"]));
                        newRow.Field("Frecuencia").SetValue(Convert.ToString(item["FrecuenciaPagos"]));
                        newRow.Field("ProximoPago").SetValue(Convert.ToString(item["Proximo"]));
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

                    //var rowToDelete = worksheet.Row(2);
                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

                    //rowToDelete.Delete();

                    //Todas Activas
                    var worksheetActivas = workbook.Worksheet("TODAS LAS CUENTAS ACTIVAS");

                    // Agregar datos         
                    var tableActivas = worksheetActivas.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);

                    DataTable dataResponseOrdenesActivas = dataUtilities.ExecuteStoredProcedure("spReportOrdenesCreditoActivas");

                    foreach (DataRow item in dataResponseOrdenesActivas.Rows)
                    {
                        var newRow = tableActivas.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Serie").SetValue(Convert.ToString(item["Serie"]));
                        newRow.Field("NoFactura").SetValue(Convert.ToString(item["NoFactura"]));
                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));
                        newRow.Field("CantidadPagosEsperados").SetValue(Convert.ToString(item["CantidadPagos"]));
                        newRow.Field("Frecuencia").SetValue(Convert.ToString(item["FrecuenciaPagos"]));
                        newRow.Field("ProximoPago").SetValue(Convert.ToString(item["Proximo"]));
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

                    if (worksheetActivas.RowsUsed().Count() > 1)
                    {
                        worksheetActivas.Row(2).Delete();
                    }


                    //Detalles
                    var worksheetDetalle = workbook.Worksheet("Detalle");
                    var tableDetalle = worksheetDetalle.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenesDetalle = dataUtilities.ExecuteStoredProcedure("spReportOrdenesDetalleCredito");

                    foreach (DataRow item in dataResponseOrdenesDetalle.Rows)
                    {
                        var newRow = tableDetalle.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));
                        newRow.Field("Producto").SetValue(Convert.ToString(item["NombreProducto"]));
                        newRow.Field("Cantidad").SetValue(Convert.ToDecimal(item["Cantidad"]));
                        newRow.Field("Precio").SetValue(Convert.ToDecimal(item["PrecioUnitario"]));
                        newRow.Field("SubTotal").SetValue(Convert.ToDecimal(item["Subtotal"]));
                    }
                    if (worksheetDetalle.RowsUsed().Count() > 1)
                    {
                        worksheetDetalle.Row(2).Delete();
                    }

                    //Pagos
                    var worksheetPagos = workbook.Worksheet("Pagos");
                    var tablepagos = worksheetPagos.Table(0); // Obtén la tabla en el índice 1

                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenesPagos = dataUtilities.ExecuteStoredProcedure("spReportOrdenesPagosCredito");

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
                    if (worksheetPagos.RowsUsed().Count() > 1)
                    {
                        worksheetPagos.Row(2).Delete();
                    }


                    //Cuentas por Cobrar en mora

                    var worksheetMora = workbook.Worksheet("Cuentas en Mora");

                    // Agregar datos         
                    var tableMora = worksheetMora.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);

                    DataTable dataResponseOrdenesMora = dataUtilities.ExecuteStoredProcedure("spReportOrdenesMora");

                    foreach (DataRow item in dataResponseOrdenesMora.Rows)
                    {
                        var newRow = tableMora.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Serie").SetValue(Convert.ToString(item["Serie"]));
                        newRow.Field("NoFactura").SetValue(Convert.ToString(item["NoFactura"]));
                        newRow.Field("NoOrden").SetValue(Convert.ToString(item["OrdenId"]));

                        newRow.Field("CantidadPagosEsperados").SetValue(Convert.ToString(item["CantidadPagos"]));
                        newRow.Field("Frecuencia").SetValue(Convert.ToString(item["FrecuenciaPagos"]));
                        newRow.Field("ProximoPago").SetValue(Convert.ToString(item["Proximo"]));

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

                    if (worksheetMora.RowsUsed().Count() > 1)
                    {
                        worksheetMora.Row(2).Delete();
                    }

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

        public static void CargarInformeAsistencia(string SucursalId, DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteAsistencias.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeAsistencias_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Asistencias");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalID", SucursalId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("sp_ObtenerAsistenciaFiltro");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("USUARIO").SetValue(Convert.ToString(item["UsuarioID"]));
                        newRow.Field("NOMBRE").SetValue(Convert.ToString(item["empleado"]));
                        newRow.Field("ENTRADA").SetValue(Convert.ToString(item["FechaEntrada"]));
                        newRow.Field("SALIDA").SetValue(Convert.ToString(item["FechaSalida"]));
                    }

                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

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

        public static void CargarInformeVentasAnuladas(string SucursalId, DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteVentasAnuladas.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeVentasAnuladas_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Ventas Anuladas");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@DateInit", FechaInit);
                    dataUtilities.SetParameter("@DateFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("spReportOrdenesCanceladas");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
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
                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

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

        public static void CargarInformeProductos(string SucursalId, DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteProductos.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeProductos_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Datos");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("sp_ReportePerdidasGanancias");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("PRODUCTO").SetValue(Convert.ToString(item["NombreProducto"]));
                        newRow.Field("Unidades Vendidas").SetValue(Convert.ToDecimal(item["CantidadVendida"]));
                        newRow.Field("Unidades Compradas").SetValue(Convert.ToDecimal(item["CantidadComprada"]));
                        newRow.Field("Costo Total").SetValue(Convert.ToDecimal(item["CostoTotal"]));
                        newRow.Field("Monto de Venta").SetValue(Convert.ToDecimal(item["IngresoTotal"]));
                        newRow.Field("GANANCIA NETA").SetValue(Convert.ToDecimal(item["GananciaNeta"]));
                        
                    }
                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

                    //Datos Finales
                    var worksheetDetallesFinales = workbook.Worksheet("Datos");

                    DataRow itemEmpresa = dataUtilities.GetAllRecords("Empresa").Rows[0];

                    worksheetDetallesFinales.Cell("C1").Value = Convert.ToString(itemEmpresa["NombreEmpresa"]);
                    worksheetDetallesFinales.Cell("B2").Value = Utilidades.Sucursal;
                    worksheetDetallesFinales.Cell("F2").Value = FechaInit.ToShortDateString();
                    worksheetDetallesFinales.Cell("H2").Value = FechaFin.ToShortDateString();

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

        //Limites
        public static void CargarInformeLimites(string AlmacenId)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteProductosLimites.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeProductosLimites_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Datos");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@AlmacenId", AlmacenId);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("sp_ReporteAlertasInventario");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("PRODUCTO").SetValue(Convert.ToString(item["NombreProducto"]));
                        newRow.Field("CANTIDAD").SetValue(Convert.ToDecimal(item["CantidadActual"]));
                        newRow.Field("CANTIDAD MINIMA").SetValue(Convert.ToDecimal(item["CantidadMinima"]));
                        newRow.Field("CANTIDAD MAXIMA").SetValue(Convert.ToDecimal(item["CantidadMaxima"]));
                        newRow.Field("ESTADO").SetValue(Convert.ToString(item["EstadoInventario"]));
                    }
                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

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

        //Cortes de Caja
        public static void CargarInformeCortes(string SucursalId, DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteCortes.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeCortesCaja_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Datos");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("sp_ReporteCierreCajaPorSucursal");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("FECHA REALIZACION").SetValue(Convert.ToString(item["FechaCierre"]));
                        newRow.Field("USUARIO").SetValue(Convert.ToString(item["Usuario"]));
                        newRow.Field("VENTAS").SetValue(Convert.ToDecimal(item["Ventas"]));
                        newRow.Field("INGRESOS EFECTIVO").SetValue(Convert.ToDecimal(item["Ingresos"]));
                        newRow.Field("GASTOS EFECTIVO").SetValue(Convert.ToDecimal(item["Gastos"]));
                        newRow.Field("TOTAL TARJETAS").SetValue(Convert.ToDecimal(item["Tarjeta"]));
                        newRow.Field("TOTAL EN CAJA").SetValue(Convert.ToDecimal(item["Total"]));
                        newRow.Field("EFECTIVO CALCULADO EN CAJA").SetValue(Convert.ToDecimal(item["Calculo"]));
                        newRow.Field("DIFERENCIA").SetValue(Convert.ToDecimal(item["Diferencia"]));

                    }
                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }

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

        //Compras
        public static void CargarInformeCompras(string SucursalId, DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteCompras.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeCompras_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Compras Detalle");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("spReporteComprasDetalle");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("CompraID").SetValue(Convert.ToString(item["CompraId"]));
                        newRow.Field("Fecha").SetValue(Convert.ToString(item["FechaAlta"]));
                        newRow.Field("Producto").SetValue(Convert.ToString(item["NombreProducto"]));
                        newRow.Field("Cantidad").SetValue(Convert.ToDecimal(item["Cantidad"]));
                        newRow.Field("Costo").SetValue(Convert.ToDecimal(item["SubTotal"]));
                    }

                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    var worksheetTotales = workbook.Worksheet("Totales");

                    // Agregar datos         
                    var tableTotales = worksheetTotales.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalId", SucursalId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseTotales = dataUtilities.ExecuteStoredProcedure("spReporteComprasAgregado");

                    foreach (DataRow item in dataResponseTotales.Rows)
                    {
                        var newRow = tableTotales.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("TotalCompras").SetValue(Convert.ToString(item["TotalCompras"]));
                        newRow.Field("Gasto").SetValue(Convert.ToString(item["TotalGastado"]));
                        newRow.Field("TotalProductos").SetValue(Convert.ToDecimal(item["TotalProductosComprados"]));
                    }

                    if (worksheetTotales.RowsUsed().Count() > 1)
                    {
                        worksheetTotales.Row(2).Delete();
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    var worksheetProveedores = workbook.Worksheet("Proveedores");

                    // Agregar datos         
                    var tableProveedores = worksheetProveedores.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@SucursalID", SucursalId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseProveedores = dataUtilities.ExecuteStoredProcedure("spReporteEstadisticasProveedores");

                    foreach (DataRow item in dataResponseProveedores.Rows)
                    {
                        var newRow = tableProveedores.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("Proveedor").SetValue(Convert.ToString(item["NombreEmpresa"]));
                        newRow.Field("TotalCompras").SetValue(Convert.ToString(item["TotalCompras"]));
                        newRow.Field("TotalGasto").SetValue(Convert.ToDecimal(item["TotalGasto"]));
                    }

                    if (worksheetProveedores.RowsUsed().Count() > 1)
                    {
                        worksheetProveedores.Row(2).Delete();
                    }
                    //-----------------------------------------------------------------------------------------------------------
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

        //Co
        public static void CargarInformeAjustes(string AlmacenId, DateTime FechaInit, DateTime FechaFin)
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

                string rutaArchivo = Path.Combine(carpetaExcel, "ReporteAjustes.xlsx");

                //Nombre temporal 
                string tempFileName = $"InformeCompras_{Utilidades.Sucursal}" + DateTime.Now + ".xlsx";
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
                    var worksheet = workbook.Worksheet("Datos");

                    // Agregar datos         
                    var table = worksheet.Table(0); // Obtén la tabla en el índice 1

                    //Obtener los datos
                    dataUtilities.SetParameter("@AlmacenId", AlmacenId);
                    dataUtilities.SetParameter("@FechaInicio", FechaInit);
                    dataUtilities.SetParameter("@FechaFin", FechaFin);

                    DataTable dataResponseOrdenes = dataUtilities.ExecuteStoredProcedure("spReporteAjustesInventario");

                    if (dataResponseOrdenes.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay suficientes datos para crear el informe.", "Atención", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    foreach (DataRow item in dataResponseOrdenes.Rows)
                    {
                        var newRow = table.DataRange.InsertRowsBelow(1).First();

                        newRow.Field("AjusteID").SetValue(Convert.ToString(item["MermaId"]));
                        newRow.Field("Identificador").SetValue(Convert.ToString(item["Identificador"]));
                        newRow.Field("Descripcion").SetValue(Convert.ToString(item["Razon"]));
                        newRow.Field("Cantidad Ajuste").SetValue(Convert.ToDecimal(item["CantidadMermada"]));
                        newRow.Field("Fecha").SetValue(Convert.ToString(item["FechaRealizacion"]));
                        newRow.Field("Almacen").SetValue(Convert.ToString(item["NombreAlmacen"]));
                        newRow.Field("Usuario").SetValue(Convert.ToString(item["Usuario"]));
                        newRow.Field("Producto").SetValue(Convert.ToString(item["NombreProducto"]));
                    }

                    if (worksheet.RowsUsed().Count() > 1)
                    {
                        worksheet.Row(2).Delete();
                    }
   
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
