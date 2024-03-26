using NeoCobranza.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    internal static class Utilidades
    {
        //Conexion
        public static Conexion conexion = new Conexion("123456", "sa");

        //Imagen
        public static int IdImagenInicial = 27;

        //Tasa
        public static string IdTasa = "1198";
        public static string Tasa = "36,6243";

        //Usuario
        public static string IdUsuario;
        public static string RolUsuario;
        public static string SucursalId;
        public static string Sucursal;

        public static void ExportToExcel(DataTable dataTable,string documento)
        {
            // Crear una aplicación Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            try
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    Excel.Range headerCell = (Excel.Range)worksheet.Cells[1, i + 1];
                    headerCell.Value = dataTable.Columns[i].ColumnName;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                    headerCell.Font.Bold = true;
                    headerCell.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                    worksheet.Columns[i + 1].ColumnWidth = 40;
                }

                // Escribir los datos
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
                    }
                }

                // Guardar el archivo Excel
                string fileName = $"{documento}{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
                string filePath = Path.Combine(Application.StartupPath, fileName);
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Visible = true;
                excelApp.Workbooks.Open(filePath);

                MessageBox.Show("Datos exportados correctamente a Excel en: " + filePath, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Liberar recursos
                ReleaseObject(worksheet);
                ReleaseObject(workbook);
                ReleaseObject(excelApp);
            }
        }

        // Método para liberar los objetos COM
        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error al liberar objeto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /*
         * Scaffold-DbContext "Server=192.168.1.165;Database=NeoCobranza;UID=cobranzanew;PWD=12345678;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "ModelsCobranza"-Tables Usuario,RolUsuario,AuditoriaSistema,TipoCambio,Proveedores,TipoServicios,Clientes,RolPermisos,Sucursales,Almacenes,Servicios_Estadares,Imagenes,RelProductoSucursales, RelAlmacenProducto,Inventario,RelAlmacenDetalle,AjustesInventario,MotivosCancelacion,Bancos,TipoTarjeta,RelBancoTipo,ConfigFacturacion,ConfigInventario,ComprasInventario,LotesProducto,RelProveedorProducto,Mermas,Salas,Ordenes,OrdenDetalle,Empresa,TrasladosInventario,TrasladoDetalle,Kardex   -force 
         */
    }
}
