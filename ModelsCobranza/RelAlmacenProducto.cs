using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class RelAlmacenProducto
    {
        public int RelAlmacenProductoId { get; set; }
        public int? AlmacenId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
    }
}
