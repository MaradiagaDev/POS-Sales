using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NeoCobranza.ModelsCobranza
{
    public partial class Clientes
    {
        public int IdCliente { get; set; }
        public string Pnombre { get; set; }
        public string Snombre { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public double? Estado { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Fax { get; set; }
        public double? Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string Profesion { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public string Observacion { get; set; }
    }
}
