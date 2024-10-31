using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class EstadoEnvio
{
    public int IdEstado { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
