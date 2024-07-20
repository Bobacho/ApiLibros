using ApiLibros.Models;
using Microsoft.EntityFrameworkCore;


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

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Find(id);
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

        public bool IsAdmin(int id)
        {
            return _context.Administradors.Where(a => a.IdUsuario == id).Count() > 0;
        }

        public int InsertAdministrador(Administrador request)
        {
            _context.Administradors.Add(request);
            _context.SaveChanges();
            return _context.Administradors.OrderBy(a => a.IdAdministrador)
                .Last().IdAdministrador;
        }

        public Administrador GetAdministradorById(int id)
        {
            return _context.Administradors.Where(a => a.IdAdministrador == id).First();
        }

        public ICollection<Administrador> GetAdministradores()
        {
            return _context.Administradors.ToList();
        }

        public bool UpdateAdministrador(int id, Administrador request)
        {
            try
            {
                var existingEntity = _context.Administradors.Find(id);
                if (existingEntity == null)
                {
                    return false;
                }
                _context.Entry(existingEntity).State = EntityState.Detached;
                request.IdAdministrador = id;
                _context.Administradors.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteAdministrador(int id)
        {
            try
            {
                if (_context.Administradors.Find(id) == null)
                {
                    return false;
                }
                var entity = _context.Administradors.Find(id);
                _context.Administradors.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
