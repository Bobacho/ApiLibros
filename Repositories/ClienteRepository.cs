using ApiLibros.Models;


namespace ApiLibros.Repositories
{
    public class ClienteRepository
    {
        private readonly ProyectosLibrosContext _context;
        public ClienteRepository(ProyectosLibrosContext context)
        {
            _context = context;
        }

        public int InsertCliente(Cliente request)
        {
            _context.Clientes.Add(request);
            _context.SaveChanges();
            return _context.Clientes.OrderBy(c => c.IdCliente).Last().IdCliente;
        }

        public Cliente GetClienteByUsuarioId(int id)
        {
            return _context.Clientes.Where(c => c.IdUsuario == id).First();
        }

        public ICollection<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }
        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.Where(c => c.IdCliente == id).First();
        }
        public bool UpdateClienteById(int id, Cliente request)
        {
            try
            {
                if (_context.Clientes.Find(id) == null)
                {
                    return false;
                }
                request.IdCliente = id;
                _context.Clientes.Update(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteClienteById(int id)
        {
            try
            {
                if (_context.Clientes.Find(id) == null)
                {
                    return false;
                }
                var entity = _context.Clientes.Find(id);
                _context.Clientes.Remove(entity);
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
