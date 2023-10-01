using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class AuditoriaSistema
    {
        public int IdAuditoria { get; set; }
        public string Usuario { get; set; }
        public string Sector { get; set; }
        public string Campo { get; set; }
        public string Tipo { get; set; }
        public string Nivel { get; set; }
        public string Fecha { get; set; }
    }
}
