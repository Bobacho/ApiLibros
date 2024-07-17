using System;
using System.Collections.Generic;

namespace ApiLibros.Models
{

    public partial class Administrador
    {
        public int IdAdministrador { get; set; }

        public string? Privilegios { get; set; }

        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
