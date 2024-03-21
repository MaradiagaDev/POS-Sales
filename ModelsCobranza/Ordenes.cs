using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Ordenes
    {
        public int OrdenId { get; set; }
        public int? SucursalId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ClienteId { get; set; }
        public int? NoFactura { get; set; }
        public string Serie { get; set; }
        public string SalaMesa { get; set; }
        public decimal? TotalOrden { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Iva { get; set; }
        public decimal? RetencionDgi { get; set; }
        public decimal? RetencionAlcaldia { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Pagado { get; set; }
        public decimal? RestantePago { get; set; }
        public string OrdenProceso { get; set; }
        public string PagoProceso { get; set; }
        public string MotivoCancelacion { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public decimal? CambioDolar { get; set; }
        public bool? CorteCaja { get; set; }
        public string NotaOrden { get; set; }
    }
}
