using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using ApiLibros.Models;
using Microsoft.AspNetCore.Cors;

namespace MyApp.Namespace
{
    [EnableCors]
    [Route("/Api/LibroCarrito")]
    [ApiController]
    public class LibroCarritoController : Controller
    {
        private readonly LibroRepository _repository;
        private readonly IHttpContextAccessor _contextAccesor;
        public LibroCarritoController(IHttpContextAccessor contextAccesor, LibroRepository repository)
        {
            _repository = repository;
            _contextAccesor = contextAccesor;
        }
        [HttpGet]
        public IActionResult GetLibroCarrito()
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.GetLibroCarrito());
        }
        [HttpPost]
        public IActionResult InsertLibroCarrito(LibroCarrito request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.InsertLibroCarrito(request));
        }
        [HttpPut]
        public IActionResult UpdateLibroCarrito(int id, LibroCarrito request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.UpdateLibroCarrito(id, request));
        }
        [HttpDelete]
        public IActionResult DeleteLibroCarrito(int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            return Ok(_repository.DeleteLibroCarrito(id));
        }
    }
}
