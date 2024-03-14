using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Proveedores
    {
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string NoTelefono { get; set; }
        public string NoRuc { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool? Estatus { get; set; }
    }
}
