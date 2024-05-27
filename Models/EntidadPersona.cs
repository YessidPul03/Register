using System;
using System.Collections.Generic;

namespace App_DVP.Models
{
    public partial class EntidadPersona
    {
        public int Identificador { get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; } = null!;
        public string? Pais { get; set; } = null!;
        public string? Departamento { get; set; } = null!;
        public string? Municipio { get; set; } = null!;
    }
}
