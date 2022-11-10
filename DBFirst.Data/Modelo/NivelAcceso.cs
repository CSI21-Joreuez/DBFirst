using System;
using System.Collections.Generic;

namespace DBFirst.Data.Modelo
{
    public partial class NivelAcceso
    {
        public int Id { get; set; }
        public int GradoAcceso { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleadoid1 { get; set; }

        public virtual Empleado? Empleadoid1Navigation { get; set; }
    }
}
