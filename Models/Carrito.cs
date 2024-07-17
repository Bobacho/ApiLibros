using System;
using System.Collections.Generic;

namespace ApiLibros.Models
{

    public partial class Carrito
    {
        public int IdCarrito { get; set; }

        public string? Estado { get; set; }

        public int? IdCliente { get; set; }

        public virtual ICollection<ComprobantePago> ComprobantePagos { get; set; } = new List<ComprobantePago>();

        public virtual Cliente? IdClienteNavigation { get; set; }

        public virtual ICollection<LibroCarrito> LibroCarritos { get; set; } = new List<LibroCarrito>();
    }
}
