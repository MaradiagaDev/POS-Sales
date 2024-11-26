using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Pagos
    {
        public int PagoOrdenId { get; set; }
        public int? OrdenId { get; set; }
        public string FormaPago { get; set; }
        public decimal? Pagado { get; set; }
        public decimal? Cambio { get; set; }
        public int? BancoId { get; set; }
        public string Estado { get; set; }
        public decimal? Total { get; set; }
        public string NoReferencia { get; set; }
    }
}
