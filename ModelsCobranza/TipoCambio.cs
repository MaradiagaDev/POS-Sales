using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class TipoCambio
    {
        public int IdTasaCambio { get; set; }
        public double Tasa { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
