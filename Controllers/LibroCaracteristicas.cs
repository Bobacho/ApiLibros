using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using ApiLibros.Models;

namespace ApiLibros.Controllers
{
    [ApiController]
    [Route("/Api/LibroCaracteristicas")]
    public class LibroCaracteristicas : Controller
    {

        private readonly LibroRepository _repository;

        public LibroCaracteristicas(LibroRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("/search-autor")]
        public IActionResult GetLibroCaracteristicasByAutor([FromQuery] string autor)
        {
            var result = _repository.GetLibroCaracteristicaByAutor(autor);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult InsertLibroCaracteristicas([FromBody] LibroCaracteristica request)
        {
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

    }
}
