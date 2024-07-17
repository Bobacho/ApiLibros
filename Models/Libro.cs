using System;
using System.Collections.Generic;

namespace ApiLibros.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Codigo { get; set; }

    public string? Ubicacion { get; set; }

    public int? IdLibroCaracteristicas { get; set; }

    public virtual LibroCaracteristica? IdLibroCaracteristicasNavigation { get; set; }

    public virtual ICollection<LibroCarrito> LibroCarritos { get; set; } = new List<LibroCarrito>();
}
