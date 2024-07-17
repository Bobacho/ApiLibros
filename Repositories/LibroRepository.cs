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
    }
}
