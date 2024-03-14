using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class RelAlmacenDetalle
    {
        public int IdRelAlmacenDetalle { get; set; }
        public int RelAlmacenProducto { get; set; }
        public int? AjusteId { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public string Talla { get; set; }
        public string Modelo { get; set; }
        public string Estado { get; set; }
    }
}
