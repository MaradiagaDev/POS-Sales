using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class TrasladoDetalle
    {
        public int DetalleTrasladoId { get; set; }
        public int? TrasladoId { get; set; }
        public string LoteInicial { get; set; }
        public string LoteFinal { get; set; }
        public int? AlmacenEntrada { get; set; }
        public int? AlmacenSalida { get; set; }
        public int? ProductoId { get; set; }
        public int? CantidadTrasladada { get; set; }
    }
}
