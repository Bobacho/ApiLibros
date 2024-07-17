using System;
using System.Collections.Generic;

namespace ApiLibros.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contrasena { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
