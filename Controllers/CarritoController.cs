using Microsoft.AspNetCore.Mvc;
using ApiLibros.Models;
using ApiLibros.Repositories;
using Microsoft.AspNetCore.Cors;
namespace MyApp.Namespace
{
    [EnableCors]
    [Route("/Api/Carrito")]
    [ApiController]
    public class CarritoController : Controller
    {

        private readonly CarritoRepository _repository;
        private readonly IHttpContextAccessor _contextAccesor;

        public CarritoController(IHttpContextAccessor contextAccesor, CarritoRepository repository)
        {
            _repository = repository;
            _contextAccesor = contextAccesor;
        }

        [HttpPost]
        public IActionResult InsertCarrito([FromBody] Carrito request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.InsertCarrito(request));
        }
        [HttpGet]
        public IActionResult GetCarritos()
        {
            return Ok(_repository.GetCarritos());
        }
        [HttpGet("/Api/Carrito/search-id")]
        public IActionResult GetCarritoById([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.GetCarritoById(id));
        }

        [HttpPut]
        public IActionResult UpdateCarritoById([FromQuery] int id, [FromBody] Carrito request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.UpdateCarrito(id, request));
        }

        [HttpDelete]
        public IActionResult DeleteCarritoById([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.DeleteCarrito(id));
        }
    }
}
