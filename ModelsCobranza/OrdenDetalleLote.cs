using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class OrdenDetalleLote
    {
        public int RelOrdenDetalleLote { get; set; }
        public int? OrdenDetalleId { get; set; }
        public string LoteId { get; set; }
        public int? Cantidad { get; set; }
    }
}
