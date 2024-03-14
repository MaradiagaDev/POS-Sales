using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Bancos
    {
        public int BancoId { get; set; }
        public string Banco { get; set; }
        public string Estado { get; set; }
    }
}
