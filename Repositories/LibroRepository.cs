using System.Linq;
using ApiLibros.Models;

namespace ApiLibros.Repositories
{
    public class LibroRepository
    {
        private readonly ProyectosLibrosContext _context;

        public LibroRepository(ProyectosLibrosContext context)
        {
            _context = context;
        }
        public ICollection<Libro> GetLibros()
        {
            return _context.Libros.ToList();
        }
        public Libro GetById(int id)
        {
            Libro result = _context.Libros?
                .OrderBy(l => l.IdLibro)
                .FirstOrDefault(l => l.IdLibro == id);
            return result;
        }

        public int InsertLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
            return _context.Libros
                .OrderBy(l => l.IdLibro)
                .Last().IdLibro;
        }

        public int InsertLibroCaracteristicas(LibroCaracteristica caracteristicas)
        {
            _context.LibroCaracteristicas.Add(caracteristicas);
            _context.SaveChanges();
            return _context.LibroCaracteristicas.OrderBy(l => l.IdLibroCaracteristicas).Last().IdLibroCaracteristicas;
        }

        public ICollection<LibroCaracteristica> GetLibroCaracteristicaByAutor(string autor)
        {
            var result = _context.LibroCaracteristicas.Where(c => c.Autor == autor)
                .OrderBy(l => l.Autor).ToList();
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public ICollection<LibroCarrito> GetLibroCarrito()
        {
            return _context.LibroCarritos.ToList();
        }

        public bool UpdateLibroCaracteristicas(int id, LibroCaracteristica request)
        {
            try
            {
                if (_context.LibroCaracteristicas.Find(id) == null)
                {
                    return false;
                }
                request.IdLibroCaracteristicas = id;
                _context.LibroCaracteristicas.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteLibroCaracteristicas(int id)
        {
            try
            {
                if (_context.LibroCaracteristicas.Find(id) == null)
                {
                    return false;
                }
                var entity = _context.LibroCaracteristicas.Find(id);
                _context.LibroCaracteristicas.Remove(entity);
                _context.SaveChanges();
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int InsertLibroCarrito(LibroCarrito request)
        {
            _context.LibroCarritos.Add(request);
            _context.SaveChanges();
            return _context.LibroCarritos
                .OrderBy(l => l.IdLibroCarrito)
                .Last()
                .IdLibroCarrito;
        }

        public bool UpdateLibroCarrito(int id, LibroCarrito request)
        {
            try
            {
                if (_context.LibroCarritos.Find(id) == null)
                {
                    return false;
                }
                request.IdLibroCarrito = id;
                _context.LibroCarritos.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteLibroCarrito(int id)
        {
            try
            {
                if (_context.LibroCarritos.Find(id) == null)
                {
                    return false;
                }
                var entity = _context.LibroCarritos.Find(id);
                _context.LibroCarritos.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return true;
            }
        }
    }
}
