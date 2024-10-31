using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class RolUsuario
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
