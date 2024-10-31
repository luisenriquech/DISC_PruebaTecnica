using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Direccion { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public bool? Activo { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
