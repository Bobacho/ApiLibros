using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using ApiLibros.Repositories;
using ApiLibros.Models;

namespace ApiLibros.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("/Api/Admin")]
    public class AdministradorController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UsuarioRepository _repository;

        public AdministradorController(IHttpContextAccessor contextAccesor, UsuarioRepository repository)
        {
            _contextAccessor = contextAccesor;
            _repository = repository;
        }

        [HttpGet("/Api/Admin/is-admin")]
        public IActionResult IsAdministrador([FromQuery] int id)
        {
            return Ok(_repository.IsAdmin(id));
        }
        [HttpGet("/Api/Admin/search-id")]
        public IActionResult GetAdministradorById([FromQuery] int id)
        {
            var result = _repository.GetAdministradorById(id);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAdministradores()
        {
            return Ok(_repository.GetAdministradores());
        }
        [HttpPost]
        public IActionResult InsertAdministrador([FromBody] Administrador request)
        {
            return Ok(_repository.InsertAdministrador(request));
        }
        [HttpPut]
        public IActionResult UpdateAdministrador([FromQuery] int id, [FromBody] Administrador request)
        {
            if (!_repository.UpdateAdministrador(id, request))
            {
                return BadRequest(false);
            }
            return Ok(true);
        }
        [HttpDelete]
        public IActionResult DeleteAdministrador([FromQuery] int id)
        {
            if (!_repository.DeleteAdministrador(id))
            {
                return BadRequest(false);
            }
            return Ok(true);
        }
    }
}
