using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Mermas
    {
        public int MermaId { get; set; }
        public string LoteId { get; set; }
        public string Identificador { get; set; }
        public string Razon { get; set; }
        public int? CantidadMermada { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public decimal? PrecioVenta { get; set; }
    }
}
