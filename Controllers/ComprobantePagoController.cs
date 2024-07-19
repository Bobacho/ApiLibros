using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using ApiLibros.Models;

namespace MyApp.Namespace
{
    public class ComprobantePagoController : Controller
    {
        private readonly IHttpContextAccessor _contextAccesor;
        private readonly ComprobantePagoRepository _repository;
        public ComprobantePagoController(IHttpContextAccessor contextAccesor, ComprobantePagoRepository repository)
        {
            _repository = repository;
            _contextAccesor = contextAccesor;
        }

        [HttpGet]
        public IActionResult GetComprobantes()
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.GetComprobantes());
        }
        [HttpGet("/Api/ComprobantePagos/search-id")]
        public IActionResult GetComprobanteById([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.GetComprobantePagoById(id));
        }
        [HttpPost]
        public IActionResult InsertComprobante([FromBody] ComprobantePago request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.InsertComprobantePago(request));
        }
        [HttpPut]
        public IActionResult UpdateComprobante([FromQuery] int id, [FromBody] ComprobantePago request)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.UpdateComprobantePago(id, request));
        }
        [HttpDelete]
        public IActionResult DeleteComprobante([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.DeleteComprobantePago(id));
        }
    }
}
