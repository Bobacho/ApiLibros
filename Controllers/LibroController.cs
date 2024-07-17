using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using ApiLibros.Models;

namespace ApiLibros.Controllers
{
    [ApiController]
    [Route("/Api/Libro")]
    public class LibroController : Controller
    {
        private readonly LibroRepository _repository;

        public LibroController(LibroRepository repository)
        {
            _repository = repository;
        }
        // GET: LibroController
        [HttpGet("{id}")]
        public IActionResult GetLibroById(int id)
        {
            return Ok(_repository.GetById(id));
        }
        [HttpPost]
        public IActionResult InsertLibro([FromBody] Libro request)
        {
            Libro libro = new Libro
            {
                Codigo = request.Codigo,
                Ubicacion = request.Ubicacion,
                IdLibroCaracteristicas = request.IdLibroCaracteristicas
            };
            return Ok(_repository.InsertLibro(libro));
        }
        [HttpGet]
        public IActionResult GetLibros()
        {
            return Ok(_repository.GetLibros());
        }
    }
}
