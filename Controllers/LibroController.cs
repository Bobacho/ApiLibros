using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using ApiLibros.Models;
using Microsoft.AspNetCore.Cors;

namespace ApiLibros.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("/Api/Libro")]
    public class LibroController : Controller
    {
        private readonly LibroRepository _repository;
        private readonly IHttpContextAccessor _contextAccesor;

        public LibroController(IHttpContextAccessor contextAccesor, LibroRepository repository)
        {
            _contextAccesor = contextAccesor;
            _repository = repository;
        }
        // GET: LibroController
        [HttpGet("/Api/Libro/search-id")]
        public IActionResult GetLibroById([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.GetById(id));
        }
        [HttpPost]
        public IActionResult InsertLibro([FromBody] Libro request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
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
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.GetLibros());
        }
        [HttpPut]
        public IActionResult UpdateLibro([FromQuery] int id, [FromBody] Libro request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.UpdateLibro(id, request));
        }
        [HttpDelete]
        public IActionResult DeleteLibro([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.DeleteLibro(id));
        }
    }
}
