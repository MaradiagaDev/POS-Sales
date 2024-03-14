using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class LotesProducto
    {
        public string LoteId { get; set; }
        public string Producto { get; set; }
        public int? ProductoId { get; set; }
        public int? CompraId { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string Expira { get; set; }
        public int? CantidadRestante { get; set; }
        public int? AlmacenId { get; set; }
        public int? ProveedorId { get; set; }
        public decimal? CostoU { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
