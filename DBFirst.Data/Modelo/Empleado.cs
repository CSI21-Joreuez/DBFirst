using System;
using System.Collections.Generic;

namespace DBFirst.Data.Modelo
{
    public partial class Empleado
    {
        public Empleado()
        {
            NivelAccesos = new HashSet<NivelAcceso>();
        }

        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int? Edad { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<NivelAcceso> NivelAccesos { get; set; }
    }
}
