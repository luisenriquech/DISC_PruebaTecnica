using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public string? Direccion { get; set; }

    public bool? Activo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
