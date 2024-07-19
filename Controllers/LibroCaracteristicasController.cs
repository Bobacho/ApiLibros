using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using ApiLibros.Models;

namespace ApiLibros.Controllers
{
    [ApiController]
    [Route("/Api/LibroCaracteristicas")]
    public class LibroCaracteristicasController : Controller
    {

        private readonly LibroRepository _repository;
        private readonly IHttpContextAccessor _contextAccesor;

        public LibroCaracteristicasController(IHttpContextAccessor contextAccesor, LibroRepository repository)
        {
            _contextAccesor = contextAccesor;
            _repository = repository;
        }
        [HttpGet("/Api/LibroCaracteristicas/search-autor")]
        public IActionResult GetLibroCaracteristicasByAutor([FromQuery] string autor)
        {
            var result = _repository.GetLibroCaracteristicaByAutor(autor);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("/Api/LibroCaracteristiacs/count")]
        public IActionResult GetLibroCountByIdCaracteristicas([FromQuery] int id)
        {
            var result = _repository.GetCountLibroByIdLibroCaracteristicas(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult InsertLibroCaracteristicas([FromBody] LibroCaracteristica request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere Authenticacion");
            }
            LibroCaracteristica caracteristicas = new LibroCaracteristica()
            {
                Titulo = request.Titulo,
                Autor = request.Autor,
                Categoria = request.Categoria,
                Precio = request.Precio,
                Descuento = request.Descuento,
                ImagenUrl = request.ImagenUrl,
            };
            return Ok(_repository.InsertLibroCaracteristicas(caracteristicas));
        }
        [HttpPut]
        public IActionResult UpdateLibroCaracteristicas([FromQuery] int id, [FromBody] LibroCaracteristica request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.UpdateLibroCaracteristicas(id, request));
        }

        [HttpDelete]
        public IActionResult DeleteLibroCaracteristicas([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.DeleteLibroCaracteristicas(id));
        }
    }
}
