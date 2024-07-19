using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiLibros.Models
{

    public partial class LibroCaracteristica
    {
        public int IdLibroCaracteristicas { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Autor { get; set; }

        [Required]
        public string? Categoria { get; set; }

        [Required]
        public decimal? Precio { get; set; }

        [Required]
        public decimal? Descuento { get; set; }

        [Required]
        public string? ImagenUrl { get; set; }

        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
