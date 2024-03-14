using NeoCobranza.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        /*
         * Scaffold-DbContext "Server=192.168.1.165;Database=NeoCobranza;UID=cobranzanew;PWD=12345678;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "ModelsCobranza"-Tables Usuario,RolUsuario,AuditoriaSistema,TipoCambio,Proveedores,TipoServicios,Clientes,RolPermisos,Sucursales,Almacenes,Servicios_Estadares,Imagenes,RelProductoSucursales, RelAlmacenProducto,Inventario,RelAlmacenDetalle,AjustesInventario,MotivosCancelacion,Bancos,TipoTarjeta,RelBancoTipo,ConfigFacturacion,ConfigInventario,ComprasInventario,LotesProducto,RelProveedorProducto,Mermas,Salas   -force 
         */
    }
}
