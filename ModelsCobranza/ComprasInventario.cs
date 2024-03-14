using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class ComprasInventario
    {
        public int CompraId { get; set; }
        public int? UsuarioId { get; set; }
        public int? AlmacenId { get; set; }
        public string SucursalId { get; set; }
        public string Descripcion { get; set; }
        public decimal? CostoTotal { get; set; }
        public DateTime? FechaAlta { get; set; }
    }
}
