using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Usuario
    {
        public int IdUsuarios { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Pass { get; set; }
    }
}
