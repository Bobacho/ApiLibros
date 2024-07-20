using ApiLibros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibros.Repositories
{

    public class ComprobantePagoRepository
    {

        private readonly ProyectosLibrosContext _context;

        public ComprobantePagoRepository(ProyectosLibrosContext context)
        {
            _context = context;
        }

        public int InsertComprobantePago(ComprobantePago request)
        {
            _context.ComprobantePagos.Add(request);
            _context.SaveChanges();
            return _context.ComprobantePagos
                .OrderBy(c => c.IdComprobante)
                .Last()
                .IdComprobante;
        }

        public ICollection<ComprobantePago> GetComprobantes()
        {
            return _context.ComprobantePagos.ToList();
        }

        public ComprobantePago GetComprobantePagoById(int id)
        {
            return _context.ComprobantePagos
                .Where(c => c.IdComprobante == id)
                .First();
        }

        public bool UpdateComprobantePago(int id, ComprobantePago request)
        {
            try
            {
                var existingEntity = _context.ComprobantePagos.Find(id);
                if (existingEntity == null)
                {
                    return false;
                }
                _context.Entry(existingEntity).State = EntityState.Detached;
                request.IdComprobante = id;
                _context.ComprobantePagos.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteComprobantePago(int id)
        {
            try
            {
                if (_context.ComprobantePagos.Find(id) == null)
                {
                    return false;
                }
                var entity = _context.ComprobantePagos.Find(id);
                _context.ComprobantePagos.Remove(entity);
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
