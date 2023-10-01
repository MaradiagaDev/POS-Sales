using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Contratos
    {
        public Contratos()
        {
            ClienteContrato = new HashSet<ClienteContrato>();
        }

        public int IdcontratoReal { get; set; }
        public DateTime? FechaDeApertura { get; set; }
        public DateTime? FechaDeCancelacion { get; set; }
        public double? CuotasTotales { get; set; }
        public double? ValorNominalDeServicio { get; set; }
        public double? ValorDeCuota { get; set; }
        public string SituacionDelContrato { get; set; }
        public string ObservacionesContrato { get; set; }
        public int? IdFirmaCompania { get; set; }
        public string IdAgenciaReal { get; set; }
        public int? IdTasaCambio { get; set; }
        public int? IdVendedor { get; set; }
        public string Modalidad { get; set; }
        public string Estado { get; set; }

        public virtual FirmasCompañia IdFirmaCompaniaNavigation { get; set; }
        public virtual TipoCambio IdTasaCambioNavigation { get; set; }
        public virtual ICollection<ClienteContrato> ClienteContrato { get; set; }
    }
}
