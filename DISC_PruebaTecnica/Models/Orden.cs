using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class Orden
{
    public int IdOrden { get; set; }

    public DateTime Fecha { get; set; }

    public int IdEstado { get; set; }

    public decimal Total { get; set; }

    public int? IdCliente { get; set; }

    public int? IdSucursal { get; set; }

    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual EstadoEnvio IdEstadoNavigation { get; set; } = null!;

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
