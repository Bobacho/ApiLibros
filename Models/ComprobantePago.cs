using System;
using System.Collections.Generic;

namespace ApiLibros.Models;

public partial class ComprobantePago
{
    public int IdComprobante { get; set; }

    public decimal? Monto { get; set; }

    public DateOnly? FechaPago { get; set; }

    public string? Direccion { get; set; }

    public string? Ruc { get; set; }

    public int? IdCarrito { get; set; }

    public virtual Carrito? IdCarritoNavigation { get; set; }
}
