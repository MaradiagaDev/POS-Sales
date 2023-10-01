using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class FirmasCompañia
    {
        public FirmasCompañia()
        {
            Contratos = new HashSet<Contratos>();
        }

        public int IdFirmasCompañia { get; set; }
        public string EstadoCivil { get; set; }
        public string Cargo { get; set; }
        public string Pnombre { get; set; }
        public string Snombre { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }

        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
