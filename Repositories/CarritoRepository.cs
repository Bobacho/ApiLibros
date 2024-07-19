using ApiLibros.Models;

namespace ApiLibros.Repositories
{
    public class CarritoRepository
    {

        private readonly ProyectosLibrosContext _context;

        public CarritoRepository(ProyectosLibrosContext context)
        {
            _context = context;
        }

        public int InsertCarrito(Carrito request)
        {
            _context.Carritos.Add(request);
            _context.SaveChanges();
            return _context.ComprobantePagos.OrderBy(c => c.IdComprobante).First().IdComprobante;
        }

        public ICollection<Carrito> GetCarritos()
        {
            return _context.Carritos.ToList();
        }

        public Carrito GetCarritoById(int id)
        {
            return _context.Carritos
                .Where(c => c.IdCarrito == id)
                .First();
        }

        public bool UpdateCarrito(int id, Carrito request)
        {
            try
            {
                if (_context.Carritos.Find(id) == null)
                {
                    return false;
                }
                request.IdCarrito = id;
                _context.Carritos.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCarrito(int id)
        {
            try
            {
                if (_context.Carritos.Find(id) == null)
                {
                    return false;
                }
                var entity = _context.Carritos.Find(id);
                _context.Carritos.Remove(entity);
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
