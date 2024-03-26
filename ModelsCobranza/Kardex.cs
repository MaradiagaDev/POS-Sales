using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Kardex
    {
        public int MovimientoId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Operacion { get; set; }
        public int? UnidadesEntrada { get; set; }
        public decimal? CostoUnitarioEntrada { get; set; }
        public decimal? TotalEntrada { get; set; }
        public int? UnidadesSalida { get; set; }
        public decimal? CostoUnitarioSalida { get; set; }
        public decimal? TotalSalida { get; set; }
        public int? UnidadesSaldo { get; set; }
        public decimal? CostoUnitarioSaldo { get; set; }
        public decimal? CostoTotalSaldo { get; set; }
        public int? ProductoId { get; set; }
        public int? AlmacenId { get; set; }
        public string Lote { get; set; }
        public string IdDocumento { get; set; }
    }
}
