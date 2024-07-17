using System;
using System.Collections.Generic;

namespace ApiLibros.Models
{

    public partial class LibroCaracteristica
    {
        public int IdLibroCaracteristicas { get; set; }

        public string? Titulo { get; set; }

        public string? Autor { get; set; }

        public string? Categoria { get; set; }

        public decimal? Precio { get; set; }

        public decimal? Descuento { get; set; }

        public string? ImagenUrl { get; set; }

        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
