using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;

namespace MyApp.Namespace
{
    [Route("/Api/LibroCarrito")]
    [ApiController]
    public class LibroCarritoController : Controller
    {
        private readonly LibroRepository _repository;

        public LibroCarritoController(LibroRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetLibroCarrito()
        {
            return Ok(_repository.GetLibroCarrito());
        }
    }
}
