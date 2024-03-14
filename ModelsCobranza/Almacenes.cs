using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Almacenes
    {
        public int AlmacenId { get; set; }
        public string NombreAlmacen { get; set; }
        public bool? EsMostrador { get; set; }
        public int? SucursalId { get; set; }
        public string Estatus { get; set; }
    }
}
