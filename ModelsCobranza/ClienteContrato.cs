using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class ClienteContrato
    {
        public int IdClienteContrato { get; set; }
        public int? IdCliente { get; set; }
        public int? IdContrato { get; set; }
        public string Estado { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Contratos IdContratoNavigation { get; set; }
    }
}
