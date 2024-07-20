using System.Linq;
using ApiLibros.Models;
using Microsoft.EntityFrameworkCore;

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

        public bool UpdateLibro(int id, Libro request)
        {
            try
            {
                var existingEntity = _context.Libros.Find(id);
                if (existingEntity == null)
                {
                    Console.WriteLine("Entidad no encontrada");
                    return false;
                }

                // Detach the existing entity
                _context.Entry(existingEntity).State = EntityState.Detached;
                request.IdLibro = id;
                _context.Libros.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool DeleteLibro(int id)
        {
            try
            {
                var result = _context.Libros.Find(id);
                if (result == null)
                {
                    Console.WriteLine("Entidad no encontrada");
                    return false;
                }
                _context.Libros.Remove(result);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
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

        public ICollection<LibroCaracteristica> GetLibroCaracteristicas()
        {
            return _context.LibroCaracteristicas.ToList();
        }

        public int GetCountLibroByIdLibroCaracteristicas(int id)
        {
            return _context.Libros.Where(l => l.IdLibroCaracteristicas == id).Count();
        }

        public bool UpdateLibroCaracteristicas(int id, LibroCaracteristica request)
        {
            try
            {
                var existingEntity = _context.LibroCaracteristicas.Find(id);
                if (existingEntity == null)
                {
                    Console.WriteLine("Entidad no encontrada");
                    return false;
                }
                _context.Entry(existingEntity).State = EntityState.Detached;
                request.IdLibroCaracteristicas = id;
                _context.LibroCaracteristicas.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool DeleteLibroCaracteristicas(int id)
        {
            try
            {
                if (_context.LibroCaracteristicas.Find(id) == null)
                {
                    Console.WriteLine("Entidad no encontrada");
                    return false;
                }
                var entity = _context.LibroCaracteristicas.Find(id);
                _context.LibroCaracteristicas.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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
                var existingEntity = _context.LibroCarritos.Find(id);
                if (existingEntity == null)
                {
                    return false;
                }
                _context.Entry(existingEntity).State = EntityState.Detached;
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
