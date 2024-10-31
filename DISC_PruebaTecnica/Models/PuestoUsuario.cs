using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class PuestoUsuario
{
    public int IdPuesto { get; set; }

    public string NombrePuesto { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
