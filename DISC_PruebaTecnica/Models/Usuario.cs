using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1{ get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int IdRol { get; set; }

    public int IdPuesto { get; set; }

    public virtual PuestoUsuario IdPuestoNavigation { get; set; } = null!;

    public virtual RolUsuario IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
