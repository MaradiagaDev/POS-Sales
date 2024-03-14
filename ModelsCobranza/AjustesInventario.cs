using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class AjustesInventario
    {
        public int AjusteId { get; set; }
        public string Nombre { get; set; }
        public string Producto { get; set; }
        public string TipoProducto { get; set; }
        public int? IdProducto { get; set; }
        public int? IdRelAlmacenDetalle { get; set; }
        public int? CantidadAgregada { get; set; }
        public int? CantidadDisminuidad { get; set; }
    }
}
