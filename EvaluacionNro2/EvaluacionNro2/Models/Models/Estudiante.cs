using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionNro2.Models.Models
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Correo { get; set; }
    }
}
