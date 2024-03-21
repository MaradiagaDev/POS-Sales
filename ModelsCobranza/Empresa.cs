using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreComercial { get; set; }
        public string Telefono { get; set; }
        public string Ruc { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
