using ApiLibros.Models;


namespace ApiLibros.Repositories
{
    public class UsuarioRepository
    {

        private readonly ProyectosLibrosContext _context;

        public UsuarioRepository(ProyectosLibrosContext context)
        {
            _context = context;
        }

        public int InsertUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return _context.Usuarios
                .OrderBy(u => u.IdUsuario)
                .Last().IdUsuario;
        }

        public bool ExistUsuarioByUserNameAndPassword(string username, string password)
        {
            return _context.Usuarios.Where(u => u.NombreUsuario == username && u.Contrasena == password).Count() > 0;
        }

        public bool ExistUsuarioByUserName(string username)
        {
            return _context.Usuarios.Where(u => u.NombreUsuario == username).Count() > 0;
        }

        public Usuario GetUsuarioByUserNameAndPassword(string username,
                string password)
        {
            return _context.Usuarios.Where(u => u.NombreUsuario == username && u.Contrasena == password).First();
        }
    }
}
