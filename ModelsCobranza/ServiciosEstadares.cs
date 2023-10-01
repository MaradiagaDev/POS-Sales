using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class ServiciosEstadares
    {
        public int IdEstandar { get; set; }
        public string NombreEstandar { get; set; }
        public int? IdImagen { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public double? MontoVd { get; set; }
        public double? MontoContrato { get; set; }
        public int? IdProveedor { get; set; }
        public string TipoServicio { get; set; }
        public double? MontoMejora { get; set; }
    }
}
