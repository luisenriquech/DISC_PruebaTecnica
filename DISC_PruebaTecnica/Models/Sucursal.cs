using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public bool? Activo { get; set; }

    public int? IdGerente { get; set; }

    public virtual Usuario? IdGerenteNavigation { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
