using System;
using System.Collections.Generic;

namespace ApiLibros.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? MetodoPago { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
