using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class ConfigFacturacion
    {
        public int ConfigFacturacionId { get; set; }
        public int? SucursalId { get; set; }
        public string Serie { get; set; }
        public int? ConsecutivoFactura { get; set; }
        public int? RangoFactura { get; set; }
        public int? ConsecutivoOrden { get; set; }
        public int? RangoOrden { get; set; }
    }
}
