using System;
using System.Collections.Generic;

namespace DISC_PruebaTecnica.Models;

public partial class DetalleOrden
{
    public int IdDetalle { get; set; }

    public decimal PrecioCompra { get; set; }

    public int Cantidad { get; set; }

    public int? IdOrden { get; set; }

    public int? IdProducto { get; set; }

    public virtual Orden? IdOrdenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
