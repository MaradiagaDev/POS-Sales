using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Inventario
    {
        public int InventarioId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public int? StockMaximo { get; set; }
        public int? StockMinimo { get; set; }
    }
}
