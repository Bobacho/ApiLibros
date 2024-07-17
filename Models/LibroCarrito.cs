using System;
using System.Collections.Generic;

namespace ApiLibros.Models;

public partial class LibroCarrito
{
    public int IdLibroCarrito { get; set; }

    public int? IdCarrito { get; set; }

    public int? IdLibro { get; set; }

    public virtual Carrito? IdCarritoNavigation { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
