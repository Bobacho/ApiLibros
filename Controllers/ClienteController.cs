using Microsoft.AspNetCore.Mvc;
using ApiLibros.Models;
using ApiLibros.Repositories;
using Microsoft.AspNetCore.Cors;

namespace MyApp.Namespace
{
    [EnableCors]
    [Route("/Api/Cliente")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ClienteRepository _repository;
        private readonly IHttpContextAccessor _contextAccesor;
        public ClienteController(IHttpContextAccessor contextAccesor, ClienteRepository repository)
        {
            _repository = repository;
            _contextAccesor = contextAccesor;
        }

        [HttpGet("/Api/Cliente/search-by-user-id")]
        public IActionResult GetClienteByUserId([FromQuery] int id)
        {
            return Ok(_repository.GetClienteByUsuarioId(id));
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.GetClientes());
        }

        [HttpGet("/Api/Cliente/search-id")]
        public IActionResult GetCliente([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.GetClienteById(id));
        }

        [HttpPost]
        public IActionResult InsertCliente([FromBody] Cliente request)
        {
            return Ok(_repository.InsertCliente(request));
        }

        [HttpPut]
        public IActionResult UpdateCliente([FromQuery] int id, [FromBody] Cliente request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.UpdateClienteById(id, request));
        }

        [HttpDelete]
        public IActionResult DeleteCliente([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.DeleteClienteById(id));
        }
    }
}
